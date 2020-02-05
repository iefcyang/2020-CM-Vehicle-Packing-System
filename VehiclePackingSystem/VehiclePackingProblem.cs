using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePackingSystem.VehiclePackingDataSetTableAdapters;
using static VehiclePackingSystem.VehiclePackingDataSet;
using NTU.IIE.CALAB.OrganismGA;
using System.ComponentModel;

namespace VehiclePackingSystem
{
    public enum VehicleOrder {  Big, Small, Auto }
    public enum GASolverModel
    {
        None, OnePermutationForSolution, OneGroupingForSolution, NPermutationForSolution
    }

    public class VehiclePackingInfo 
    {
        public VehicleRow theVehicle;

        // 貨單涵蓋的地區陣列
        public List<int> deliveredAreaIds = new List<int>();
        // 貨單地區分布的區群代碼
        List<int> crossedGroups = new List<int>();

        [Category("容量參數"), Description("載重上限KG")]
        public int WeightLimitKG { set; get; } = 1000;

        [Category("派車結果數"), Description("上載貨單貨物總重(kg)")]
        public double TotalWeight { set; get; } = 0;

        [Category("派車結果數"), Description("上載貨單總數。")]
        public int NumberOfLoads { set; get; } = 0;

        [Category("派車結果數"), Description("繞行地區總數。")]
        public int DeliveryAreaCount { get => deliveredAreaIds.Count; }

        [Category("派車結果數"), Description("跨越地區群數。")]
        public int CrossedGroupCount { get => crossedGroups.Count; }

        [Category("派車結果數"), Description("載貨率。")]
        public double LoadRatio { get => TotalWeight / WeightLimitKG; }

        // 分析所有貨單的地區，確立涵蓋的區群代碼集合
        public void updateCrossedGroups( AreaDataTable allAreas )
        {
            crossedGroups.Clear();
            foreach(int aid in deliveredAreaIds)
            {
                int gid = (from a in allAreas where a.Id == aid select a.groupID).ToArray<int>()[0];
                if (!crossedGroups.Contains(gid)) crossedGroups.Add(gid);
            }
        }
    }


    // Grouping GA 模型 使用的 目標函數參數
    public class GroupingParameters
    {
        //[Category("Objective Value Parameters"), Description("")]
        [Category("目標函數參數"), Description("載貨率標準差的權重值，內定5.0。")]
        public double WeightOnSTD { set; get; } = 5.0;

        [Category("目標函數參數"), Description("未排入貨單數的懲罰值，內定10.0。")]
        public double NotLoadedPenalty { set; get; } = 10.0;

        //[Category("目標函數參數"), Description("拆單數的懲罰值，內定1.0。")]
        //public double SplittedPenalty { set; get; } = 1.0;

        [Category("目標函數參數"), Description("跨群數超過1的懲罰值，內定1.0。")]
        public double CrossGroupPenalty { set; get; } = 1.0;
    }

    // Permutation GA 模型 使用的 目標函數參數
    public class PermutationParameters
    {
        [Category("目標函數參數"), Description("未排入貨單數的懲罰值，內定1.0。")]
        public double NotLoadedPenalty { set; get; } = 1.0;

        [Category("目標函數參數"), Description("拆單數的懲罰值，內定1.0。")]
        public double SplittedPenalty { set; get; } = 1.0;

        [Category("目標函數參數"), Description("跨群數超過1的懲罰值，內定1.0。")]
        public double CrossGroupPenality { set; get; } = 1.0;
    }


    // 貨單合車分配最佳化問題
    public class VehiclePackingProblem
    {
        // 選用的 GA 求解法
        GASolverModel GAModel = GASolverModel.None;
        public Dictionary<int, int> VehicleIndexes { get; set; } = new Dictionary<int, int>();
        // 問題的資料集物件，以 data table 為物件集合，以 data row 為物件個體。
        VehiclePackingDataSet problemDS = new VehiclePackingDataSet();
        OrdersTableAdapter orderTA = new OrdersTableAdapter();
        AreaTableAdapter areaTA = new AreaTableAdapter();
        VehicleTableAdapter vehicleTA = new VehicleTableAdapter();
        OrdersRow[] orders;
        VehicleRow[] vehicles;
        VehiclePackingInfo[] vehicleInfos;
        int numberOfDispatchedVehicles;
        string DeliveryDateString;
        string DatabasePath;
        int[] orderCountsOfGroups;

        public int NumberOfAreaGroups { get => orderCountsOfGroups.Length;  }

        #region 屬性

        public VehiclePackingDataSet ProblemDS { get => problemDS; }
        public VehicleRow[] Vehicles { get => vehicles; }
        public VehiclePackingInfo[] VehicleInfos { get => vehicleInfos; }
        public double STDofLoadRatios { set; get; } = 0;
        public OrdersRow[] Orders { get => orders; }

        public int NumberOfDispatchedVehicles { get => numberOfDispatchedVehicles; }
        double averageLoadRatio;
        public double AverageLoadRate { get => averageLoadRatio;}
        double averageDeliveryAreaCount;
        public double AverageDeliveryAreas { get => averageDeliveryAreaCount; }
        double averageCrossedGroupCount;
        public double AverageGroupCrossed { get => averageCrossedGroupCount; }
 
        public List<OrdersRow> SplitNewOrders { set; get; } = new List<OrdersRow>();
     //   public List<OrdersRow> SplitHosts { set; get; } = new List<OrdersRow>();
        public List<OrdersRow> NonLoadedOrders { set; get; } = new List<OrdersRow>();

        public GroupingParameters ParametersOfGroupingGA { get; set; } = new GroupingParameters();
        public PermutationParameters ParametersOfPermutationGA { get; set; } = new PermutationParameters();



        public string BestSolutionString
        {
            get
            {
                int weight = 0;
                foreach (OrdersRow or in NonLoadedOrders) weight += or.netWeight;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"**未排入的貨單數：{NonLoadedOrders.Count}  \t總重：{weight/1000:0.00}噸  \t拆單數：{SplitNewOrders.Count}");
                sb.AppendLine($"派車總數：{numberOfDispatchedVehicles} (可用車數 {vehicleInfos.Length})");
                sb.AppendLine($"平均載貨率：{averageLoadRatio:0.00}   \t載貨率標準差：{STDofLoadRatios:0.00}");
                sb.AppendLine($"平均配送地區數：{averageDeliveryAreaCount:0.00}   \t平均跨群數：{averageCrossedGroupCount:0.00}");
                sb.AppendLine($"總成本：出車成本({numberOfDispatchedVehicles}車) + 員工成本({numberOfDispatchedVehicles}人) + 上下載成本({orders.Length+SplitNewOrders.Count-NonLoadedOrders.Count}下載點) + 繞行成本 = ??");
                return sb.ToString();
            }
        }
        #endregion


        /// <summary>
        ///  建構函式。一個問題只能排單一日的貨單。
        /// </summary>
        /// <param name="deliveryDate"></param>
        public VehiclePackingProblem( string deliveryDate)
        {
            DeliveryDateString = deliveryDate;

            // 擷取啟用的貨車到 problemDS.Vehicle 資料表，每個 Vehicle 是一個 vehicleRow 物件(參照)
            vehicleTA.FillByEnabled(problemDS.Vehicle);

            // 擷取擬排貨單到 problemDS.Orders 資料表，每個 Order 是一個 orderRow 物件，給訂單一日。
            orderTA.FillByDate(problemDS.Orders, deliveryDate);

            // 貨單需要參看 群別：擷取擬所有地區到 problemDS.Area 資料表，每個 Area 是一個 areaRow 物件
            areaTA.Fill(problemDS.Area);
        }



        /// <summary>
        /// 本問題使用 不同 GA models 求解後，展示迄今最佳解。
        /// </summary>
        /// <param name="theSolver"></param>
        public void GASolverAssignFinalSolution(GASolver theSolver)
        {
            switch (GAModel)
            {
                case GASolverModel.OneGroupingForSolution:
                    GroupingGAAssignFinalSolution((int[])theSolver.SoFarTheBestSolution[0]);
                    break;
                case GASolverModel.OnePermutationForSolution:
                    PermutationGAAssignFinalSolution((int[])theSolver.SoFarTheBestSolution[0]);
                    break;
                case GASolverModel.NPermutationForSolution:
                    int[][] arrayOfintArray = new int[theSolver.SoFarTheBestSolution.Length][];
                    for (int i = 0; i < arrayOfintArray.Length; i++)
                        arrayOfintArray[i] = (int[])theSolver.SoFarTheBestSolution[i];
                    NPermutationGAAssignFinalSolution(arrayOfintArray);
                    break;
            }
        }



        public void GAOrganizeData(   )
        {
            if ( GAVehicleSorting == VehicleOrder.Big)
                OrganizeVehicleList(true); // 檢出啟用的 貨車資料
            else if (GAVehicleSorting == VehicleOrder.Small)
                OrganizeVehicleList(false);
            else OrganizeVehicleList(true);

            OrganizeOrderList();   // 檢出你運送的貨單
            if (originalWeights == null || originalWeights.Length != orders.Length)
                originalWeights = new int[orders.Length];
            // 拷貝一份原始重量
            for (int i = 0; i < originalWeights.Length; i++)
                originalWeights[i] = orders[i].netWeight;
        }

        /// <summary>
        ///  建立一個GA grouping 的求解系統。
        /// </summary>
        /// <returns></returns>
        public GASolver CreateAGroupingGASolver()
        {
            GAModel = GASolverModel.OneGroupingForSolution;

            GAOrganizeData();
            //OrganizeVehicleList(); // 檢出啟用的 貨車資料
            //OrganizeOrderList();   // 檢出你運送的貨單

            int[] lowBs = new int[orders.Length];
            int[] upBs = new int[orders.Length];
            for( int i =0;i < orders.Length; i++ )
            {
                lowBs[i] = 0;
                upBs[i] = vehicles.Length-1;
            }
            GASolver solver =  GASolver.CreateIntegerNumberGASolver(OptimizationType.Min, orders.Length, lowBs, upBs, GroupingGAGetObjective);
            solver.IterationLimit = 500;
            return solver;
        }

        /// <summary>
        ///  Grouping 編碼法的解評估函式
        /// </summary>
        /// <param name="aSolution"></param>
        /// <returns></returns>
        public double GroupingGAGetObjective( int[] aSolution )
        {

            int NonLoadedOrdersCount = 0;
            // Reset 
            for (int i = 0; i < vehicleInfos.Length; i++)
            {
                vehicleInfos[i].TotalWeight = 0;
                vehicleInfos[i].NumberOfLoads = 0;
                vehicleInfos[i].deliveredAreaIds.Clear();
            }
            for (int i = 0; i < aSolution.Length; i++)
            {
                OrdersRow od = orders[i];
                int vehicleId = aSolution[i];
                
                if (vehicleInfos[vehicleId].TotalWeight + od.netWeight > vehicleInfos[vehicleId].WeightLimitKG)
                {
                    // 如果加入 車 vehicleID 報表，因此放棄。
                    NonLoadedOrdersCount++;
                }
                else // 加入
                {
                    vehicleInfos[vehicleId].NumberOfLoads++;
                    vehicleInfos[vehicleId].TotalWeight += od.netWeight;
                    // 添加此地區
                    if (!vehicleInfos[vehicleId].deliveredAreaIds.Contains(od.areaId))
                        vehicleInfos[vehicleId].deliveredAreaIds.Add(od.areaId);
                }
            }
            // 結算統計資料供輸出
            calculateDispatchStatistics();
            // 目標函式 
            return STDofLoadRatios * ParametersOfGroupingGA.WeightOnSTD + ParametersOfGroupingGA.CrossGroupPenalty * ((averageCrossedGroupCount - 1.0) / NumberOfAreaGroups) + NonLoadedOrdersCount * ParametersOfGroupingGA.NotLoadedPenalty;
        }
    

        /// <summary>
        ///  解碼迄今最佳解，登錄到 DataSet。
        /// </summary>
        /// <param name="bestSolution"></param>
        void GroupingGAAssignFinalSolution( int[] bestSolution )
        {

      //      SplitNewOrders.Clear();
    //        SplitHosts.Clear();
            NonLoadedOrders.Clear();
            // Reset 
            for (int i = 0; i < vehicleInfos.Length; i++)
            {
                vehicleInfos[i].TotalWeight = 0;
                vehicleInfos[i].NumberOfLoads = 0;
                vehicleInfos[i].deliveredAreaIds.Clear();
            }

            for (int i = 0; i < bestSolution.Length; i++)
            {
                OrdersRow od = orders[i];
                int vehicleId = bestSolution[i];
                if (vehicleInfos[vehicleId].TotalWeight + od.netWeight > vehicleInfos[vehicleId].WeightLimitKG)
                {
                   // NonLoadedOrdersCount++;
                    od.planVehicleId = -1;
                    NonLoadedOrders.Add(od);
                }
                else
                {
                    vehicleInfos[vehicleId].NumberOfLoads++;
                    vehicleInfos[vehicleId].TotalWeight += od.netWeight;
                    // 添加此地區
                    if (!vehicleInfos[vehicleId].deliveredAreaIds.Contains(od.areaId))
                        vehicleInfos[vehicleId].deliveredAreaIds.Add(od.areaId);
                    od.planVehicleId = vehicles[vehicleId].Id; // 寫入 dataTable
                }
            }

            // 結算統計資料供成果輸出
            calculateDispatchStatistics();
        }

        public VehicleOrder GAVehicleSorting { get; set; } = VehicleOrder.Auto;

        public GASolver CreateNPermutationGASolver( )
        {
            GAModel = GASolverModel.NPermutationForSolution;

            GAOrganizeData( );
            GASolver theSolver;
            if (GAVehicleSorting == VehicleOrder.Auto)
            {
                int[] counts = new int[orderCountsOfGroups.Length + 1];
                for (int i = 0; i < orderCountsOfGroups.Length; i++) counts[i] = orderCountsOfGroups[i];
                counts[counts.Length - 1] = vehicles.Length;
                theSolver = GASolver.CreateNPermutationGASolver(counts, OptimizationType.Min, NPermutationGetObjective);
            }
            else
                theSolver = GASolver.CreateNPermutationGASolver(orderCountsOfGroups, OptimizationType.Min, NPermutationGetObjective);
            theSolver.IterationLimit = 500;
            return theSolver;
        }

       int[] aSolution;

        double NPermutationGetObjective(int[][] organism)
        {
            if( aSolution == null || aSolution.Length != orders.Length )
                aSolution = new int[orders.Length];

            int up = 0;
            int k = 0;
            int numberOfsegment = organism.Length;
            if (GAVehicleSorting == VehicleOrder.Auto)
            {
                numberOfsegment = organism.Length - 1;
                ShuffledVehicleIndices = organism[numberOfsegment];
            }
            for ( int i = 0; i < numberOfsegment; i++ )
            {
                for( int j = 0; j < organism[i].Length; j++ )
                {
                    aSolution[k++] = organism[i][j] + up;
                }
                up += organism[i].Length;
            }

            return  PermutationGAGetObjective(aSolution);
        }


        void NPermutationGAAssignFinalSolution(int[][] organism)
        {
            if (aSolution == null || aSolution.Length != orders.Length)
                aSolution = new int[orders.Length];

            int up = 0;
            int k = 0;
            int numberOfsegment = organism.Length;
            if (GAVehicleSorting == VehicleOrder.Auto)
            {
                numberOfsegment = organism.Length - 1;
                ShuffledVehicleIndices = organism[numberOfsegment];
            }

            for (int i = 0; i < numberOfsegment; i++)
            {
                for (int j = 0; j < organism[i].Length; j++)
                {
                    aSolution[k++] = organism[i][j] + up;
                }
                up += organism[i].Length;
            }

            PermutationGAAssignFinalSolution(aSolution);
        }

        // 使用在 貨車也由GA排序下登錄解，供解碼用，不需要 allocate 記憶體，直接參照 solver 內的解
        int[] ShuffledVehicleIndices;
        double PermutationPlusGetObjective(int[][] organism)
        {
            // 第0段是貨單排序，第1段是貨車排序
            ShuffledVehicleIndices = organism[1];
            return PermutationGAGetObjective(organism[0]);

        }

        /// <summary>
        ///  建立一個 permutation 編碼 的 GA 求解系統。
        /// </summary>
        /// <returns></returns>
        public GASolver CreateAPermutationGASolver( )
        {
   
            GAModel = GASolverModel.OnePermutationForSolution;

            GAOrganizeData( );
            GASolver solver;
            if (GAVehicleSorting == VehicleOrder.Auto)
            {
                solver = GASolver.CreateNPermutationGASolver(new int[] { orders.Length, vehicles.Length }, OptimizationType.Min, PermutationPlusGetObjective);
                //if (ShuffledVehicleIndices == null || ShuffledVehicleIndices.Length != vehicles.Length)
                //    ShuffledVehicleIndices = new int[vehicles.Length];
            }
            else
                solver = GASolver.CreatePermutationGASolver(OptimizationType.Min, orders.Length, PermutationGAGetObjective);
            solver.IterationLimit = 500;
            return solver;
        }
        int[] originalWeights;
        OrdersRow[] tempOrders = new OrdersRow[50];




        // 僅求算目標函數值
        /// <summary>
        ///  Permutation 編碼法的解評估函式
        /// </summary>
        /// <param name="aSolution"></param>
        /// <returns></returns>
        public double PermutationGAGetObjective( int[] aSolution )
        {
            int SplitNewOrdersCount = 0;
            int NonLoadedOrdersCount = 0;

            if (GAVehicleSorting == VehicleOrder.Auto)
            {
                for (int i = 0; i < vehicleInfos.Length; i++)
                {
                    vehicleInfos[i].theVehicle = vehicles[ShuffledVehicleIndices[i]];
                    vehicleInfos[i].WeightLimitKG = (int)(vehicleInfos[i].theVehicle.weightLimit * 1000);
                    vehicleInfos[i].TotalWeight = 0;
                    vehicleInfos[i].NumberOfLoads = 0;
                    vehicleInfos[i].deliveredAreaIds.Clear();
                }
            }
            else
            {
                for (int i = 0; i < vehicleInfos.Length; i++)
                {
                    vehicleInfos[i].theVehicle = vehicles[i];
                    vehicleInfos[i].WeightLimitKG = (int)( vehicles[i].weightLimit * 1000);
                    vehicleInfos[i].TotalWeight = 0;
                    vehicleInfos[i].NumberOfLoads = 0;
                    vehicleInfos[i].deliveredAreaIds.Clear();
                }
            }


                int vid =  0;

            for (int i = 0; i < aSolution.Length; i++)
            {
                OrdersRow od = orders[aSolution[i]];

                bool terminate = false;
                int condition = 0;  // 
                if (vehicleInfos[vid].TotalWeight + od.netWeight <=  vehicleInfos[vid].WeightLimitKG )
                {
                    // 裝得進去
                    condition = 0;
                }
                else // 裝不進去=> 能裝新車，裝新車，不行的話可分時，分線車和新車，否則放棄
                {
                    // 如果達到分裝標準，分裝
                    if (OrderSplitThresh > 0 && od.netWeight > OrderSplitThresh)
                    {
                        condition = 1;
                    }
                    else
                    {


                        // 查看新車有無及容量
                        if (vid + 1 >= vehicleInfos.Length)
                            condition = -1; // 沒新車，只能放棄
                        else // 有新車
                        {
                            if (od.netWeight < vehicleInfos[vid + 1].WeightLimitKG)
                            {
                                // 新車容量可以收納 開新車放入
                                vid++;
                                //weightLimit = loadRatio * vehicleInfos[vid].WeightLimitKG;
                                //vehicleInfos[vid].TotalWeight = 0;
                                condition = 0; // 放入 新的 vid 內
                            }
                            else // 新車容量無法完整收納
                            {
                                if (OrderSplitThresh == 0)
                                {

                                    // 分出一塊填滿 車 vid 後，開新車，重新排本貨單

                                    vehicleInfos[vid].TotalWeight += (int)(vehicleInfos[vid].WeightLimitKG - vehicleInfos[vid].TotalWeight);//  newOrder.netWeight;
                                    vehicleInfos[vid].NumberOfLoads++;
                                    if (!vehicleInfos[vid].deliveredAreaIds.Contains(od.areaId))
                                        vehicleInfos[vid].deliveredAreaIds.Add(od.areaId);
                                    //problemDS.Orders.Rows.Add(newOrder);
                                    //SplitNewOrders.Add(newOrder);

                                    SplitNewOrdersCount++;

                                    // 貨單 oid 扣減分出的重量
                                    od.netWeight -= (int)(vehicleInfos[vid].WeightLimitKG - vehicleInfos[vid].TotalWeight);
                                    // 此車塞滿開下一輛車
                                    vid++;
                                    if (vid >= vehicleInfos.Length) // 沒車了
                                        condition = -1;
                                    else
                                    {
                                        // 更新重量上限
                                        //weightLimit = loadRatio * vehicleInfos[vid].WeightLimitKG;
                                        //vehicleInfos[vid].TotalWeight = 0;
                                        // 倒帶回去重新進行 貨單 oid 的裝填
                                        i--;
                                        continue;
                                    }
                                }
                                else
                                    condition = -2; // 單獨放棄
                            }
                        }
                    }

                }
                switch (condition)
                {
                    case 1:
                        // 分出一塊填滿 車 vid 後，開新車，重新排本貨單

                        //OrdersRow newOrder = problemDS.Orders.NewOrdersRow();
                        //newOrder.areaId = od.areaId;
                        //newOrder.deliveryDate = od.deliveryDate;
                        //newOrder.netWeight = (int)(vehicleInfos[vid].WeightLimitKG - vehicleInfos[vid].TotalWeight);
                        //newOrder.product = od.product;
                        //newOrder.planVehicleId = vehicles[vid].Id;
                        //newOrder.Id = od.Id;

                        SplitNewOrdersCount++;
                        vehicleInfos[vid].TotalWeight += (int)(vehicleInfos[vid].WeightLimitKG - vehicleInfos[vid].TotalWeight);
                        vehicleInfos[vid].NumberOfLoads++;
                        if (!vehicleInfos[vid].deliveredAreaIds.Contains(od.areaId))
                            vehicleInfos[vid].deliveredAreaIds.Add(od.areaId);
                        //SplitNewOrders.Add(newOrder);

                        // 貨單 oid 扣減分出的重量
                        if (vid + 1 >= vehicleInfos.Length)
                        {
                            for (int j = i; j < aSolution.Length; j++)
                            {
                                OrdersRow or = orders[aSolution[i]];
                                tempOrders[NonLoadedOrdersCount] = or;
                                NonLoadedOrdersCount++;
                                //or.planVehicleId = -1;
                            }
                            terminate = true;
                        }
                        else
                        {
                            od.netWeight -= (int)(vehicleInfos[vid].WeightLimitKG - vehicleInfos[vid].TotalWeight);
                            i--;
                            vid++;
                        }
                        break;
                    case 0: // // 放入 vid 內// 貨單oid 裝入 車 vid
                        //od.planVehicleId = vehicles[vid].Id;
                        // 更新車輛裝載統計資料
                        vehicleInfos[vid].TotalWeight += od.netWeight;
                        vehicleInfos[vid].NumberOfLoads++;
                        if (!vehicleInfos[vid].deliveredAreaIds.Contains(od.areaId))
                            // 添加此地區
                            vehicleInfos[vid].deliveredAreaIds.Add(od.areaId);
                        if (od.netWeight != originalWeights[aSolution[i]])
                            od.netWeight = originalWeights[aSolution[i]];
                        break;
                    case -1: //沒新車，放棄該物及後續所有貨單後立即結束
                        for (int j = i; j < aSolution.Length; j++)
                        {
                            OrdersRow or = orders[aSolution[i]];
                            tempOrders[NonLoadedOrdersCount]=or;
                            NonLoadedOrdersCount++;
                            //or.planVehicleId = -1;
                        }
                        terminate = true;
                        break;
                    case -2: //單獨放棄該物
                        tempOrders[NonLoadedOrdersCount] = od;
                        //od.planVehicleId = -1;
                        NonLoadedOrdersCount++;
                        break;
                }
                if (terminate) break;
                if (i == aSolution.Length - 1 && NonLoadedOrdersCount > 0)
                {
                    // 嘗試再塞入
                    int lastV = vid;
                    for (int k = NonLoadedOrdersCount - 1; k >= 0; k--)
                    {
                        OrdersRow or = tempOrders[k];
                        lastV = vid;
                        while (lastV < vehicleInfos.Length)
                        {
                            if (vehicleInfos[lastV].TotalWeight + or.netWeight <=  vehicleInfos[lastV].WeightLimitKG)
                            {
                                //or.planVehicleId = vehicles[lastV].Id;
                                // 更新車輛裝載統計資料
                                vehicleInfos[lastV].TotalWeight += or.netWeight;
                                vehicleInfos[lastV].NumberOfLoads++;
                                if (!vehicleInfos[lastV].deliveredAreaIds.Contains(or.areaId))
                                    // 添加此地區
                                    vehicleInfos[lastV].deliveredAreaIds.Add(or.areaId);
                                NonLoadedOrdersCount--;
                                break;
                            }
                            lastV++;
                        }
                    }
                }
            }



            //for (int i = 0; i < aSolution.Length; i++)
            //{
            //    OrdersRow od =  orders[aSolution[i]];

            //    // cumWeight += od.netWeight;
            //    if ( vehicleInfos[vid].TotalWeight + od.netWeight > vehicleInfos[vid].WeightLimitKG)
            //    {
            //        // 超車，開啟下一輛
            //        vid++;
            //        if (vid >= vehicles.Length)
            //        {
            //            // 沒有車子了
            //            for (int j = i; j < aSolution.Length; j++) NonLoadedOrdersCount++;
            //            break;
            //        }
            //        //cumWeight = od.netWeight;
            //        if ( od.netWeight > vehicleInfos[vid].WeightLimitKG)
            //        {
            //            // 此貨單無法裝入新車
            //            if (splittable)
            //            {
            //                int weightLeft = od.netWeight - vehicleInfos[vid].WeightLimitKG;
            //                // 分出後，本貨單變更重量
            //                od.netWeight = weightLeft;

            //                // 更新車輛裝載統計資料
            //                vehicleInfos[vid].TotalWeight +=  vehicleInfos[vid].WeightLimitKG;
            //                vehicleInfos[vid].NumberOfLoads++;
            //                if (!vehicleInfos[vid].deliveredAreaIds.Contains(od.areaId))
            //                    vehicleInfos[vid].deliveredAreaIds.Add(od.areaId);
            //                SplitNewOrdersCount++;
            //                vid++;
            //                if (vid >= vehicles.Length)
            //                {
            //                    // 沒有車子了
            //                    for (int j = i; j < aSolution.Length; j++) NonLoadedOrdersCount++;
            //                    break;
            //                }
            //            }
            //            else
            //            {
            //                NonLoadedOrdersCount++;   
            //                continue;
            //            }
            //        }
            //    }

            //    // 更新車輛裝載統計資料
            //    vehicleInfos[vid].TotalWeight += od.netWeight;
            //    vehicleInfos[vid].NumberOfLoads++;
            //    if (!vehicleInfos[vid].deliveredAreaIds.Contains(od.areaId))
            //    {
            //        // 添加此地區
            //        vehicleInfos[vid].deliveredAreaIds.Add(od.areaId);
            //    }
            //}

            // 結算統計資料供輸出
            calculateDispatchStatistics();
 
            return NumberOfDispatchedVehicles * (1.0 - averageLoadRatio ) + ( (averageCrossedGroupCount - 1.0 ) / NumberOfAreaGroups) * ParametersOfPermutationGA.CrossGroupPenality + NonLoadedOrdersCount * ParametersOfPermutationGA.NotLoadedPenalty + SplitNewOrdersCount * ParametersOfPermutationGA.SplittedPenalty;
        }

        public int OrderSplitThresh { set; get; } = -1; // <0 不能 split = 0 新車重， >0 使用者設定

        // 已登錄的最解解，即貨單的排序結果，進行配置得出最好的派車結果
        /// <summary>
        ///  解碼迄今最佳解，登錄到 DataSet。
        /// </summary>
        /// <param name="bestSolution"></param>
        void PermutationGAAssignFinalSolution( int[] bestSolution )
        {
            if (GAVehicleSorting == VehicleOrder.Auto)
            {
                for (int i = 0; i < vehicleInfos.Length; i++)
                {
                    vehicleInfos[i].theVehicle = vehicles[ShuffledVehicleIndices[i]];
                    vehicleInfos[i].WeightLimitKG = (int)(vehicleInfos[i].theVehicle.weightLimit * 1000);
                    vehicleInfos[i].TotalWeight = 0;
                    vehicleInfos[i].NumberOfLoads = 0;
                    vehicleInfos[i].deliveredAreaIds.Clear();
                }
            }
            else
            {
                for (int i = 0; i < vehicleInfos.Length; i++)
                {
                    vehicleInfos[i].theVehicle = vehicles[i];
                    vehicleInfos[i].WeightLimitKG = (int)(vehicles[i].weightLimit * 1000);
                    vehicleInfos[i].TotalWeight = 0;
                    vehicleInfos[i].NumberOfLoads = 0;
                    vehicleInfos[i].deliveredAreaIds.Clear();
                }
            }

            SplitNewOrders.Clear();
            NonLoadedOrders.Clear();

            int vid = 0;


            for (int i = 0; i < bestSolution.Length; i++)
            {
                OrdersRow od = orders[bestSolution[i]];

                bool terminate = false;
                int condition = 0;  // 
                if (vehicleInfos[vid].TotalWeight + od.netWeight <= vehicleInfos[vid].WeightLimitKG)
                {
                    // 裝得進去
                    condition = 0;
                }
                else // 裝不進去=> 能裝新車，裝新車，不行的話可分時，分線車和新車，否則放棄
                {
                    if (OrderSplitThresh > 0 && od.netWeight > OrderSplitThresh)
                    {
                        condition = 1;
                    }
                    else
                    {


                        // 查看新車有無及容量
                        if (vid + 1 >= vehicleInfos.Length)
                            condition = -1; // 沒新車，只能放棄
                        else // 有新車
                        {
                            if (od.netWeight < vehicleInfos[vid + 1].WeightLimitKG)
                            {
                                // 新車容量可以收納 開新車放入
                                vid++;
                                //weightLimit = loadRatio * vehicleInfos[vid].WeightLimitKG;
                                //vehicleInfos[vid].TotalWeight = 0;
                                condition = 0; // 放入 新的 vid 內
                            }
                            else // 新車容量無法完整收納
                            {
                                if (OrderSplitThresh == 0)
                                {
                                    // 分出一塊填滿 車 vid 後，開新車，重新排本貨單

                                    OrdersRow newOrder = problemDS.Orders.NewOrdersRow();
                                    newOrder.areaId = od.areaId;
                                    newOrder.deliveryDate = od.deliveryDate;
                                    newOrder.netWeight = (int)(vehicleInfos[vid].WeightLimitKG - vehicleInfos[vid].TotalWeight);
                                    newOrder.product = od.product;
                                    newOrder.Id = od.Id;
                                    newOrder.planVehicleId = vehicleInfos[vid].theVehicle.Id;
                                    vehicleInfos[vid].TotalWeight += newOrder.netWeight;
                                    vehicleInfos[vid].NumberOfLoads++;
                                    if (!vehicleInfos[vid].deliveredAreaIds.Contains(newOrder.areaId))
                                        vehicleInfos[vid].deliveredAreaIds.Add(newOrder.areaId);
                                    //problemDS.Orders.Rows.Add(newOrder);
                                    SplitNewOrders.Add(newOrder);
                                    //                             SplitHosts.Add(od);

                                    // 貨單 oid 扣減分出的重量
                                    od.netWeight -= newOrder.netWeight;
                                    // 此車塞滿開下一輛車
                                    vid++;
                                    if (vid >= vehicleInfos.Length) // 沒車了
                                        condition = -1;
                                    else
                                    {
                                        // 更新重量上限
                                        //weightLimit = loadRatio * vehicleInfos[vid].WeightLimitKG;
                                        //vehicleInfos[vid].TotalWeight = 0;
                                        // 倒帶回去重新進行 貨單 oid 的裝填
                                        i--;
                                        continue;
                                    }
                                }
                                else
                                    condition = -2; // 單獨放棄
                            }
                        }
                    }
                }
                switch (condition)
                {
                    case 1:
                        // 分出一塊填滿 車 vid 後，開新車，重新排本貨單

                        OrdersRow newOrder = problemDS.Orders.NewOrdersRow();
                        newOrder.areaId = od.areaId;
                        newOrder.deliveryDate = od.deliveryDate;
                        newOrder.netWeight = (int)(vehicleInfos[vid].WeightLimitKG - vehicleInfos[vid].TotalWeight);
                        newOrder.product = od.product;
                        newOrder.planVehicleId = vehicleInfos[vid].theVehicle.Id;
                        newOrder.Id = od.Id;
                        vehicleInfos[vid].TotalWeight += newOrder.netWeight;
                        vehicleInfos[vid].NumberOfLoads++;
                        if (!vehicleInfos[vid].deliveredAreaIds.Contains(newOrder.areaId))
                            vehicleInfos[vid].deliveredAreaIds.Add(newOrder.areaId);
                        SplitNewOrders.Add(newOrder);

                        // 貨單 oid 扣減分出的重量
                        od.netWeight -= newOrder.netWeight;
                        i--;
                        vid++;
                        if (vid >= vehicleInfos.Length)
                        {
                            for (int j = i; j < aSolution.Length; j++)
                            {
                                OrdersRow or = orders[bestSolution[i]];
                                NonLoadedOrders.Add(or);
                                or.planVehicleId = -1;
                            }
                            terminate = true;
                        }
                        break;
                    case 0: // // 放入 vid 內// 貨單oid 裝入 車 vid
                        od.planVehicleId = vehicleInfos[vid].theVehicle.Id;
                        // 更新車輛裝載統計資料
                        vehicleInfos[vid].TotalWeight += od.netWeight;
                        vehicleInfos[vid].NumberOfLoads++;
                        if (!vehicleInfos[vid].deliveredAreaIds.Contains(od.areaId))
                            // 添加此地區
                            vehicleInfos[vid].deliveredAreaIds.Add(od.areaId);
                        break;
                    case -1: //沒新車，放棄該物及後續所有貨單後立即結束
                        for (int j = i; j < bestSolution.Length; j++)
                        {
                            OrdersRow or = orders[bestSolution[i]];

                            NonLoadedOrders.Add(or);
                            or.planVehicleId = -1;
                        }
                        terminate = true;
                        break;
                    case -2: //單獨放棄該物
                        NonLoadedOrders.Add(od);
                        od.planVehicleId = -1;
                        break;
                }
                if (terminate) break;
                if (i == bestSolution.Length - 1 && NonLoadedOrders.Count > 0)
                {
                    // 嘗試再塞入
                    int lastV = vid;
                    for (int k = NonLoadedOrders.Count - 1; k >= 0; k--)
                    {
                        OrdersRow or = NonLoadedOrders[k];
                        lastV = vid;
                        while (lastV < vehicleInfos.Length)
                        {
                            if (vehicleInfos[lastV].TotalWeight + or.netWeight <= vehicleInfos[lastV].WeightLimitKG)
                            {
                                or.planVehicleId = vehicleInfos[lastV].theVehicle.Id;
                                // 更新車輛裝載統計資料
                                vehicleInfos[lastV].TotalWeight += or.netWeight;
                                vehicleInfos[lastV].NumberOfLoads++;
                                if (!vehicleInfos[lastV].deliveredAreaIds.Contains(or.areaId))
                                    // 添加此地區
                                    vehicleInfos[lastV].deliveredAreaIds.Add(or.areaId);
                                NonLoadedOrders.RemoveAt(k);
                                break;
                            }
                            lastV++;
                        }
                    }
                }
            }
















            // bestsolution 內是 貨單編號的 排列組合
            //for (int i = 0; i < bestSolution.Length; i++)
            //{
            //    OrdersRow od = orders[bestSolution[i]];

            //    cumWeight += od.netWeight;
            //    if (cumWeight > vehicleInfos[vid].WeightLimitKG)
            //    {
            //        // 超車，開啟下一輛
            //        vid++;
            //        if (vid >= vehicles.Length)
            //        {
            //            // 沒有車子了
            //            for (int j = i; j < orders.Length; j++)
            //                NonLoadedOrders.Add(orders[j]);
            //            break;
            //        }
            //        cumWeight = od.netWeight;
            //        if (cumWeight > vehicleInfos[vid].WeightLimitKG)
            //        {
            //            // 此貨單無法裝入新車
            //            if (splittable)
            //            {
            //                int weightLeft = od.netWeight - vehicleInfos[vid].WeightLimitKG;
            //                // 分出後，本貨單變更重量
            //                od.netWeight = weightLeft;

            //                // 添加分割的貨單
            //                OrdersRow newOrder = problemDS.Orders.NewOrdersRow();
            //                newOrder.areaId = od.areaId;
            //                newOrder.deliveryDate = od.deliveryDate;
            //                newOrder.netWeight = (int)vehicleInfos[vid].WeightLimitKG;
            //                newOrder.product = od.product;
            //                newOrder.planVehicleId = vehicles[vid].Id;
            //                //problemDS.Orders.Rows.Add(newOrder);

            //                // 更新車輛裝載統計資料
            //                vehicleInfos[vid].TotalWeight += newOrder.netWeight;
            //                vehicleInfos[vid].NumberOfLoads++;
            //                if (!vehicleInfos[vid].deliveredAreaIds.Contains(newOrder.areaId))
            //                    vehicleInfos[vid].deliveredAreaIds.Add(newOrder.areaId);

            //                SplitNewOrders.Add(newOrder);

            //                vid++;
            //                cumWeight = od.netWeight;
            //            }
            //            else
            //            {
            //                NonLoadedOrders.Add(od);
            //                cumWeight = 0;
            //                continue;
            //            }
            //        }
            //    }

            //    // 貨單i 裝入 車 vid
            //    od.planVehicleId = vehicles[vid].Id;

            //    // 更新車輛裝載統計資料
            //    vehicleInfos[vid].TotalWeight += od.netWeight;
            //    vehicleInfos[vid].NumberOfLoads++;
            //    if (!vehicleInfos[vid].deliveredAreaIds.Contains(od.areaId))
            //        vehicleInfos[vid].deliveredAreaIds.Add(od.areaId);
            //}

            // 結算統計資料供輸出
            calculateDispatchStatistics();
        }


        /// <summary>
        ///  由資料庫撈取原始資料組成貨車清單
        /// </summary>
        /// <param name="FromLargeToSmall"></param>
        public void OrganizeVehicleList( bool FromLargeToSmall = true)
        {
            // vehicles 可能有變動，每次執行時，從新自 資料庫載入最新啟用與否的資料
            // 擷取可用貨車到 problemDS.Vehicle 資料表，每個 Vehicle 是一個 vehicleRow 物件
            vehicleTA.FillByEnabled(problemDS.Vehicle);

            // 將貨車依照容量由大到小量排序
            if (FromLargeToSmall)
                vehicles = (from v in problemDS.Vehicle orderby v.weightLimit descending select v).ToArray<VehicleRow>(); // 大到小
            else
                vehicles = (from v in problemDS.Vehicle orderby v.weightLimit select v).ToArray<VehicleRow>(); // 小到大
                                                                                                               // 重建索引
            VehicleIndexes.Clear();
            for (int i = 0; i < vehicles.Length; i++)
            {
                VehicleIndexes.Add(vehicles[i].Id, i);
            }

            if (vehicleInfos == null || vehicleInfos.Length != vehicles.Length)
            {
                vehicleInfos = new VehiclePackingInfo[vehicles.Length];
                for (int i = 0; i < vehicleInfos.Length; i++)
                    vehicleInfos[i] = new VehiclePackingInfo();
            }
            for (int i = 0; i < vehicleInfos.Length; i++)
            {
                // 內定順序和 vehicles 一樣，但某些 GA 法會有自己的排序，此時須重設 infor 對應的 vehicle
                vehicleInfos[i].theVehicle = vehicles[i];
                vehicleInfos[i].WeightLimitKG = (int)(vehicles[i].weightLimit * 1000);
                vehicleInfos[i].TotalWeight = 0;
                vehicleInfos[i].NumberOfLoads = 0;
                vehicleInfos[i].deliveredAreaIds.Clear();
            }
        }


        void OrganizeOrderList(bool groupIdIncreasing = true)
        {
            // 將貨單依照區群別、區別、重量排序
            // 將貨單依照區群別、區別排序
            // orders 是從 problemDS.Orders table 擷取 OrdersRow 參照組成陣列，
            // 因此過程如果是 splittable 改變 orders 內的內容，也改變了 problemDS.Orders的內容
            // 因此每次重新執行時，必須反覆從資料庫擷取原始資料。

            // 擷取擬排貨單到 problemDS.Orders 資料表，每個 Order 是一個 orderRow 物件

            orderTA.FillByDate(problemDS.Orders, DeliveryDateString);

            if (groupIdIncreasing)
                orders = (from o in problemDS.Orders join a in problemDS.Area on o.areaId equals a.Id orderby a.groupID, o.areaId select o).ToArray<OrdersRow>();
            else
                orders = (from o in problemDS.Orders join a in problemDS.Area on o.areaId equals a.Id orderby a.groupID descending, o.areaId select o). ToArray<OrdersRow>();

            //var groups = (from o in problemDS.Orders join a in problemDS.Area on o.areaId equals a.Id orderby a.groupID select  a.groupID).Distinct<int>();
            //NumberOfAreaGroups = groups.Count<int>();

            if (groupIdIncreasing)
            {
                var groupedList = (from o in problemDS.Orders
                                   join a in problemDS.Area on o.areaId equals a.Id
                                   orderby a.groupID
                                   select new { o.Id, o.areaId, a.groupID }).GroupBy(e => e.groupID);
                orderCountsOfGroups = new int[groupedList.Count()];
                int i = 0;
                foreach (var gp in groupedList) orderCountsOfGroups[i++] = gp.Count();
            }
            else
            {
                var groupedList = (from o in problemDS.Orders
                                   join a in problemDS.Area on o.areaId equals a.Id
                                   orderby a.groupID descending
                                   select new { o.Id, o.areaId, a.groupID }).GroupBy(e => e.groupID);
                orderCountsOfGroups = new int[groupedList.Count()];
                int i = 0;
                foreach (var gp in groupedList) orderCountsOfGroups[i++] = gp.Count();
            }

        }


        // 人工派車法，將貨單依照區群、地區排序妥當，將貨車依照容量排妥先後順序，逐一進行貨單分派。
        public void ExperienceGuidedSolverForSmallest(bool areaConstraintsApplied,  bool largeVehicleFirst, bool groupIdIncreasing)
        {
            ExperiencePack(areaConstraintsApplied,  largeVehicleFirst, groupIdIncreasing, true);
           // ExperienceGuidedSolverForSmallestOLD(areaConstraintsApplied, splittable, largeVehicleFirst, groupIdIncreasing);
        }

        // 人工派車法，將貨單依照區群、地區排序妥當，將貨車依照容量排妥先後順序，逐一進行貨單分派。
        public void ExperienceGuidedSolverForSmallestOLD( bool areaConstraintsApplied,   bool largeVehicleFirst, bool groupIdIncreasing)
        {
            // 區群由小到大順向 或 由大到小逆向
            OrganizeOrderList(groupIdIncreasing);

            // 將貨車依照容量 由大到小 或 由小到大排序
            OrganizeVehicleList(largeVehicleFirst);

            SplitNewOrders.Clear();
  //          SplitHosts.Clear();
            NonLoadedOrders.Clear();

            //if (sequenctCuts == null || sequenctCuts.Length != vehicles.Length) sequenctCuts = new int[vehicles.Length];
            int cumWeight = 0;
            int vid = 0;
            for( int i = 0; i < orders.Length; i++)
            {
                cumWeight += orders[i].netWeight;
                if (cumWeight > vehicleInfos[vid].WeightLimitKG )
                {
                    // 超車，開啟下一輛
                    vid++;
                    if( vid >= vehicles.Length)
                    {
                        // 沒有車子了
                        for( int j = i; j < orders.Length; j++)
                            NonLoadedOrders.Add(orders[j]);
                        break;
                    }
                    cumWeight = orders[i].netWeight;
                    if( cumWeight > vehicleInfos[vid].WeightLimitKG )
                    {
                        // 此貨單無法裝入新車
                        if(  OrderSplitThresh == 0 )
                        {
                            int weightLeft = orders[i].netWeight - vehicleInfos[vid].WeightLimitKG;
                            // 分出後，本貨單變更重量
                            orders[i].netWeight = weightLeft;
                            
                            // 添加分割的貨單
                            OrdersRow newOrder = problemDS.Orders.NewOrdersRow();
                            newOrder.areaId = orders[i].areaId;
                            newOrder.deliveryDate = orders[i].deliveryDate;
                            newOrder.netWeight = (int) vehicleInfos[vid].WeightLimitKG;
                            newOrder.product = orders[i].product;
                            newOrder.Id = orders[i].Id;
                            newOrder.planVehicleId = vehicles[vid].Id;
                            problemDS.Orders.Rows.Add(newOrder);

                            // 更新車輛裝載統計資料
                            vehicleInfos[vid].TotalWeight += newOrder.netWeight;
                            vehicleInfos[vid].NumberOfLoads++;
                            if (!vehicleInfos[vid].deliveredAreaIds.Contains(newOrder.areaId))
                            {
                                // 添加此地區
                                vehicleInfos[vid].deliveredAreaIds.Add(newOrder.areaId);
                            }

                            SplitNewOrders.Add( newOrder );
//                            SplitHosts.Add(orders[i]);

                            vid++;
                            cumWeight = orders[i].netWeight;
                        }
                        else
                        {
                            NonLoadedOrders.Add(orders[i]);
                            cumWeight = 0;
                            continue;
                        }
                    }
                }

                // 貨單i 裝入 車 vid
                orders[i].planVehicleId = vehicles[vid].Id;

                // 更新車輛裝載統計資料
                vehicleInfos[vid].TotalWeight += orders[i].netWeight;
                vehicleInfos[vid].NumberOfLoads++;
                if (!vehicleInfos[vid].deliveredAreaIds.Contains(orders[i].areaId))
                    vehicleInfos[vid].deliveredAreaIds.Add(orders[i].areaId);
            }

            // 結算統計資料供輸出
            calculateDispatchStatistics();
        }



        public void ExperienceGuidedSolverForEven(bool areaConstraintsApplied,   bool largeVehicleFirst, bool groupIdIncreasing)
        {
            ExperiencePack(areaConstraintsApplied,   largeVehicleFirst, groupIdIncreasing, false);
        }



        void ExperiencePack( bool areaConstraintsApplied,  bool largeVehicleFirst, bool groupIdIncreasing, bool fullLoaded = true )
        {
            double loadRatio = 1.0;
            // 區群由小到大順向 或 由大到小逆向
            OrganizeOrderList(groupIdIncreasing);

            // 將貨車依照容量 由大到小 或 由小到大排序
            OrganizeVehicleList(largeVehicleFirst);

            if (!fullLoaded)
            {
                // 計算均分後每車的期望 載貨率
                var weights = (from o in orders select o.netWeight).ToArray<int>();
                double totalWeight = 0;
                foreach (int w in weights) totalWeight += w;
                var capacities = (from v in vehicles select v.weightLimit).ToArray<double>();
                double totalCapacity = 0;
                foreach (double c in capacities) totalCapacity += c;
                loadRatio = 1.0 * totalWeight / totalCapacity / 1000.0; // 
            }

            SplitNewOrders.Clear();
 //           SplitHosts.Clear();

            NonLoadedOrders.Clear();

            double weightLimit;

            int vid = 0;
            weightLimit = loadRatio * vehicleInfos[vid].WeightLimitKG;

            for (int oid = 0; oid < orders.Length; oid++)
            {
                bool terminate = false;
                int condition = 0;  // 
                if (vehicleInfos[vid].TotalWeight + orders[oid].netWeight <= weightLimit)
                {
                    // 裝得進去
                    condition = 0;
                }
                else // 裝不進去=> 能裝新車，裝新車，不行的話可分時，分線車和新車，否則放棄
                {
                    // 如果達到分裝標準，分裝
                    if (OrderSplitThresh > 0 && orders[oid].netWeight > OrderSplitThresh)
                    {
                        condition = 1;
                    }
                    else
                    {


                        // 查看新車有無及容量
                        if (vid + 1 >= vehicles.Length)
                            condition = -1; // 沒新車，只能放棄
                        else // 有新車
                        {
                            if (orders[oid].netWeight < loadRatio * vehicleInfos[vid + 1].WeightLimitKG)
                            {
                                // 新車容量可以收納 開新車放入
                                vid++;
                                weightLimit = loadRatio * vehicleInfos[vid].WeightLimitKG;
                                //vehicleInfos[vid].TotalWeight = 0;
                                condition = 0; // 放入 新的 vid 內
                            }
                            else // 新車容量無法完整收納
                            {
                                if (OrderSplitThresh == 0)
                                {
                                    // 分出一塊填滿 車 vid 後，開新車，重新排本貨單

                                    OrdersRow newOrder = problemDS.Orders.NewOrdersRow();
                                    newOrder.areaId = orders[oid].areaId;
                                    newOrder.deliveryDate = orders[oid].deliveryDate;
                                    newOrder.netWeight = (int)(weightLimit - vehicleInfos[vid].TotalWeight);
                                    newOrder.product = orders[oid].product;
                                    newOrder.planVehicleId = vehicles[vid].Id;
                                    newOrder.Id = orders[oid].Id;
                                    vehicleInfos[vid].TotalWeight += newOrder.netWeight;
                                    vehicleInfos[vid].NumberOfLoads++;
                                    if (!vehicleInfos[vid].deliveredAreaIds.Contains(newOrder.areaId))
                                        vehicleInfos[vid].deliveredAreaIds.Add(newOrder.areaId);
                                    SplitNewOrders.Add(newOrder);

                                    // 貨單 oid 扣減分出的重量
                                    orders[oid].netWeight -= newOrder.netWeight;
                                    // 此車塞滿開下一輛車
                                    vid++;
                                    if (vid >= vehicles.Length) // 沒車了
                                        condition = -1;
                                    else
                                    {
                                        // 更新重量上限
                                        weightLimit = loadRatio * vehicleInfos[vid].WeightLimitKG;
                                        //vehicleInfos[vid].TotalWeight = 0;
                                        // 倒帶回去重新進行 貨單 oid 的裝填
                                        oid--;
                                        continue;
                                    }
                                }
                                else
                                    condition = -2; // 單獨放棄
                            }
                        }
                    }

                }
                switch (condition)
                {
                    case 1: // 可拆單
                        // 分出一塊填滿 車 vid 後，開新車，重新排本貨單

                        OrdersRow newOrder = problemDS.Orders.NewOrdersRow();
                        newOrder.areaId = orders[oid].areaId;
                        newOrder.deliveryDate = orders[oid].deliveryDate;
                        newOrder.netWeight = (int)(weightLimit - vehicleInfos[vid].TotalWeight);
                        newOrder.product = orders[oid].product;
                        newOrder.planVehicleId = vehicles[vid].Id;
                        newOrder.Id = orders[oid].Id;
                        vehicleInfos[vid].TotalWeight += newOrder.netWeight;
                        vehicleInfos[vid].NumberOfLoads++;
                        if (!vehicleInfos[vid].deliveredAreaIds.Contains(newOrder.areaId))
                            vehicleInfos[vid].deliveredAreaIds.Add(newOrder.areaId);
                         SplitNewOrders.Add(newOrder);
 
                        // 貨單 oid 扣減分出的重量
                        orders[oid].netWeight -= newOrder.netWeight;
                        oid--;
                        vid++;
                        if (vid >= vehicleInfos.Length)
                        {
                            for (int j = oid; j < orders.Length; j++)
                            {
                                NonLoadedOrders.Add(orders[j]);
                                orders[j].planVehicleId = -1;
                            }
                            terminate = true;
                        }
                        break;
                    case 0: // // 放入 vid 內// 貨單oid 裝入 車 vid
                        orders[oid].planVehicleId = vehicles[vid].Id;
                        // 更新車輛裝載統計資料
                        vehicleInfos[vid].TotalWeight += orders[oid].netWeight;
                        vehicleInfos[vid].NumberOfLoads++;
                        if (!vehicleInfos[vid].deliveredAreaIds.Contains(orders[oid].areaId))
                            // 添加此地區
                            vehicleInfos[vid].deliveredAreaIds.Add(orders[oid].areaId);
                        break;
                    case -1: //沒新車，放棄該物及後續所有貨單後立即結束
                        for (int j = oid; j < orders.Length; j++)
                        {
                            NonLoadedOrders.Add(orders[j]);
                            orders[j].planVehicleId = -1;
                        }
                        terminate = true;
                        break;
                    case -2: //單獨放棄該物
                        NonLoadedOrders.Add(orders[oid]);
                        orders[oid].planVehicleId = -1;
                        break;
                }
                if (terminate) break;
                if( oid == orders.Length -1 && NonLoadedOrders.Count > 0 )
                {
                    // 嘗試再塞入
                    int lastV = vid;
                    for( int k = NonLoadedOrders.Count-1; k >=0; k-- )
                    {
                        OrdersRow or = NonLoadedOrders[k];
                        lastV = vid;
                        while (lastV < vehicles.Length)
                        {
                            if (vehicleInfos[lastV].TotalWeight + or.netWeight <= loadRatio * vehicleInfos[lastV].WeightLimitKG)
                            {
                                or.planVehicleId = vehicles[lastV].Id;
                                // 更新車輛裝載統計資料
                                vehicleInfos[lastV].TotalWeight += or.netWeight;
                                vehicleInfos[lastV].NumberOfLoads++;
                                if (!vehicleInfos[lastV].deliveredAreaIds.Contains(or.areaId))
                                    // 添加此地區
                                    vehicleInfos[lastV].deliveredAreaIds.Add(or.areaId);
                                NonLoadedOrders.RemoveAt(k);
                                break;
                            }
                            lastV++;
                        }
                    }
                }
            }

            // 結算統計資料供輸出
            calculateDispatchStatistics();

        }

        /// <summary>
        /// 
        /// </summary>
        // 結算分派結果統計資料
        void calculateDispatchStatistics()
        {
            numberOfDispatchedVehicles = 0;
            averageLoadRatio = 0;
            averageDeliveryAreaCount = 0;
            averageCrossedGroupCount = 0;
            for (int i = 0; i < vehicles.Length; i++)
            {
                // 注意，得先更新跨區統計
                vehicleInfos[i].updateCrossedGroups(problemDS.Area);
                // 更新車輛裝載統計資料
                if (vehicleInfos[i].NumberOfLoads > 0)
                {
                    if (vehicleInfos[i].TotalWeight <= 0 || vehicleInfos[i].DeliveryAreaCount < 1 || vehicleInfos[i].CrossedGroupCount < 1)
                        throw new Exception("Information in a none dispatched vehicle is not consistent with others!");
                    numberOfDispatchedVehicles++;
                    averageLoadRatio += vehicleInfos[i].LoadRatio;
                    averageDeliveryAreaCount += vehicleInfos[i].DeliveryAreaCount;
                    averageCrossedGroupCount += vehicleInfos[i].CrossedGroupCount;
                }
            }
            averageLoadRatio /= numberOfDispatchedVehicles;
            STDofLoadRatios = 0;
            foreach (VehiclePackingInfo vpi in vehicleInfos) STDofLoadRatios += (vpi.LoadRatio - averageLoadRatio) * (vpi.LoadRatio - averageLoadRatio);
            STDofLoadRatios = Math.Sqrt(STDofLoadRatios / numberOfDispatchedVehicles);

            averageDeliveryAreaCount /= numberOfDispatchedVehicles;
            averageCrossedGroupCount /= numberOfDispatchedVehicles;

        }

    }
}
