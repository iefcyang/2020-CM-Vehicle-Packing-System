using NTU.IIE.CALAB.OrganismGA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VehiclePackingSystem.VehiclePackingDataSetTableAdapters;
using static VehiclePackingSystem.VehiclePackingDataSet;

namespace VehiclePackingSystem
{
    public partial class MainForm : Form
    {
        bool targetLeft = true;


        DataGridViewCellStyle discardStyle = new DataGridViewCellStyle();


            DataGridViewCellStyle splitStyle = new DataGridViewCellStyle();


            DataGridViewCellStyle splitAndDiscardStyle = new DataGridViewCellStyle();


        //內定 13 種分群顏色
       public static Color[] BorderColors =
        {
               Color.FromArgb(100,100,100),  Color.FromArgb(100,0,0), Color.FromArgb(0, 100,0 ),Color.FromArgb(0,0,100),
            Color.FromArgb(100,100,0), Color.FromArgb(100, 0, 100 ), Color.FromArgb(0,100,100), Color.FromArgb(150,0,100),
                Color.FromArgb(0,150,100), Color.FromArgb(100, 0, 150 ), Color.FromArgb(100,150,0), Color.FromArgb(0,100,150), Color.FromArgb(150, 100, 0 )
        };

        Random rnd = new Random();
        Dictionary<int, int> GroupIdForIds = new Dictionary<int, int>();
     Dictionary<int,Color>  ColorForIds;
        double[] cumulatedValues;

        VehiclePackingProblem theProblem;
        Series blockSeries;

        OrdersTableAdapter ordersTA = new OrdersTableAdapter();
        AreaDataTable areasTB = new AreaDataTable();
        GASolver theGASolver;

        public MainForm()
        {
            InitializeComponent();


            // 交付使用後
            rtbDate.TextBoxText = DateTime.Now.Date.ToShortDateString();
            // 現在除錯、示範用 Hard set for debugging
            rcbDeliveryDate.Checked = true;
            rtbDate.TextBoxText = "2018/3/6";
            rtbDate.Enabled = true;

            blockSeries = chtPackingResults.Series[0];
            labMessage.Text = $"Database: {AppDomain.CurrentDomain.GetData("DataDirectory").ToString()}VehiclePackingDatabase.mdf";

            discardStyle.BackColor = Color.Black;
            discardStyle.ForeColor = Color.White;

            splitAndDiscardStyle.BackColor = Color.Maroon;
            splitAndDiscardStyle.ForeColor = Color.Gold;

            splitStyle.BackColor = Color.Pink;
            splitStyle.ForeColor = Color.Maroon;

            rcbOrders.SelectedItem = rlbBig;
            rcbOrders_TextBoxTextChanged(null, null);
        }


        private void rbnAddRow_Click(object sender, EventArgs e)
        {
            PasteClipboard();
        }

 
        private void PasteClipboard()
        {
            //try
            //{
            //    string s = Clipboard.GetText();
            //    string[] lines = s.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            //    int start = dgvData.Rows.Count-1;

            //    switch (EditKey)
            //    {
            //        case "Area":
            //            for (int i = 0; i < lines.Length; i++) areaBinding.Add(new Area());
            //            break;
            //        case "Vehicle":
            //            for (int i = 0; i < lines.Length; i++) vehicleBinding.Add(new Vehicle());
            //            break;
            //    }

            //    foreach (string line in lines)
            //    {
            //        string[] items = line.Split('\t');
            //        if (items.Length != dgvData.ColumnCount)
            //        {
            //            MessageBox.Show($"剪貼簿資料欄位數 {items.Length} 和資料表蘭欄數 {dgvData.ColumnCount} 不吻合！", "無法添加", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //        for (int c = 0; c < items.Length; c++)
            //            dgvData[c, start].Value = Convert.ChangeType(items[c], dgvData.Columns[c].ValueType);
            //        start++;
            //    }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show($"剪貼簿資料格式和資料表格式不吻合！\n{e.Message}", "貼入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }


        private void rbnEditOwners_Click(object sender, EventArgs e)
        {
            OwnerEdit dlg = new OwnerEdit();
            dlg.ShowDialog(this);
        }

        private void rbnEditModel_Click(object sender, EventArgs e)
        {
            ModelEdit dlg = new ModelEdit();
            dlg.ShowDialog(this);
        }

        private void rbnEditArea_Click(object sender, EventArgs e)
        {
            AreaEdit dlg = new AreaEdit();
            dlg.ShowDialog(this);
        }

        private void rbnEditVehicle_Click(object sender, EventArgs e)
        {
            VehicleEdit dlg = new VehicleEdit();
            dlg.ShowDialog(this);
        }

        private void rbnEditOrders_Click(object sender, EventArgs e)
        {
            OrderEdit dlg = new OrderEdit();
            if (rcbAll.Checked)
                dlg = new OrderEdit();
            else
                dlg = new OrderEdit(rtbDate.TextBoxText);
            dlg.ShowDialog(this);
        }

        private void DateChecked(object sender, EventArgs e)
        {
            rtbDate.Enabled = rcbDeliveryDate.Checked;
        }


        private void rtbDate_MouseDown(object sender, MouseEventArgs e)
        {
            datePicker.Location = e.Location;
            datePicker.Left = e.Location.X - rtbDate.Bounds.X;
            datePicker.Top = rtbDate.Bounds.Top;
            //labMessage.Text = $"location = {datePicker.Location} e.mouse = {e.Location} box = {rtbDate.Bounds}";
            try
            {
                datePicker.Value =  Convert.ToDateTime(rtbDate.TextBoxText);
            }
            catch { }
            datePicker.Visible = true;
            datePicker.Select();
            SendKeys.Send("%{DOWN}");
        }

        CustomLabel hilightLabel = null;

        private void rbnCreateModel_Click(object sender, EventArgs e)
        {
            if( !rcbDeliveryDate.Checked || rtbDate.TextBoxText =="")
            {
                MessageBox.Show(this, "只能進行單日貨單的合車演算。\n請選擇有貨單尚未送貨的送貨日。", "出貨日未設定", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Cursor = Cursors.WaitCursor;

            theProblem = new VehiclePackingProblem(rtbDate.TextBoxText);

            rcbOrders_TextBoxTextChanged(null,null);
            rckSplitable_CheckBoxCheckChanged(null, null);
            // 問題產生後，已經載入到他的資料表內。檢出該問題內容視覺展出
            // dgvVehicles.DataSource = theProblem.ProblemDS.Vehicle;
            //theProblem.ProblemDS.Vehicle.Where<>()
            dgvVehicles.DataSource = (from v in theProblem.ProblemDS.Vehicle select new { v.licensePlate, v.weightLimit, v.Id }).ToList();
            dgvVehicles.AutoGenerateColumns = true;
            dgvVehicles.Columns[0].HeaderText = "車牌";
            dgvVehicles.Columns[1].HeaderText = "載種噸數";
            dgvVehicles.Columns[2].Visible = false;
            foreach (DataGridViewColumn c in dgvVehicles.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.RowHeadersVisible = false;
            labVehicle.Text = $"貨車啟用 {theProblem.ProblemDS.Vehicle.Rows.Count} 台";

            if (cumulatedValues == null || cumulatedValues.Length != theProblem.ProblemDS.Vehicle.Rows.Count)
                cumulatedValues = new double[theProblem.ProblemDS.Vehicle.Rows.Count];

            // 整理 area 顏色
            if( GroupIdForIds.Count == 0 )
            {
                AreaTableAdapter areaTA = new AreaTableAdapter();
                areaTA.Fill(areasTB);
                ColorForIds = new Dictionary<int, Color>();
                for( int i = 0; i< areasTB.Rows.Count; i++) 
                {
                    GroupIdForIds.Add(areasTB[i].Id, areasTB[i].groupID);
                    ColorForIds.Add(areasTB[i].Id, Color.FromArgb(areasTB[i].color));
                }
            }

            // 檢出 貨單
            dgvOrders.DataSource = (from o in theProblem.ProblemDS.Orders join a in areasTB on o.areaId equals a.Id  select new { o.Id, o.product, o.netWeight, a.titleArea, a.groupID }).ToList();
            dgvOrders.AutoGenerateColumns = true;
            dgvOrders.Columns[0].Visible = false;
            dgvOrders.Columns[1].HeaderText = "貨品名稱";
            dgvOrders.Columns[2].HeaderText = "重量";
            dgvOrders.Columns[3].HeaderText = "地區";
            dgvOrders.Columns[4].HeaderText = "區群別";
            foreach (DataGridViewColumn c in dgvOrders.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;
            dgvOrders.RowHeadersVisible = false;
            labOrders.Text = $"{rtbDate.TextBoxText} 貨單共有 {theProblem.ProblemDS.Orders.Rows.Count} 筆";


            // 啟動合車按鈕
            rplSmallGA.Enabled = rplEvenGA.Enabled = rplSmallExperience.Enabled = true;
            Cursor = Cursors.Default;
        }


        private void rbnSmallExperience_Click(object sender, EventArgs e)
        {
            spcGACmdProp.Enabled = false;

            MethodString = "***** 經驗法 望少車 *****\n\n";

            theProblem.ExperienceGuidedSolverForSmallest(rckConstrainted.Checked, rckLargeFirst.Checked, rckGroupOrder.Checked );

            // 求解後展示 Gantt 圖
            DisplayPackingResults();

            rbnEvenExperience.Checked = rbnEvenGA.Checked = rbnSmallGA.Checked = false;
        }


        private void rbnEvenExperience_Click(object sender, EventArgs e)
        {
            spcGACmdProp.Enabled = false;

            MethodString = "***** 經驗法 望均勻 *****\n\n";
            theProblem.ExperienceGuidedSolverForEven(rckConstrainted.Checked, rckLargeFirst.Checked, rckGroupOrder.Checked);

            // 求解後展示 Gantt 圖
            DisplayPackingResults();

        }

        void UpdateHilightedCustomLabel(CustomLabel theLabel )
        {
            if (hilightLabel != null)
            {
                int idx = -1;
                for (int i = 0; i < chtPackingResults.ChartAreas[0].AxisX.CustomLabels.Count; i++)
                {
                    if (chtPackingResults.ChartAreas[0].AxisX.CustomLabels[i].Text == hilightLabel.Text)
                    {
                        idx = i;
                        break;
                    }
                }
                if( idx >= 0 ) chtPackingResults.ChartAreas[0].AxisX.CustomLabels[idx].ForeColor = Color.Black;
            }

            hilightLabel = theLabel;
            hilightLabel.ForeColor = Color.Red;
            pgdVehicleInfo.SelectedObject = hilightLabel.Tag;
        }

        private void chtPackingResults_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult[] htr = chtPackingResults.HitTest(e.X, e.Y,true, ChartElementType.AxisLabels, ChartElementType.DataPoint );
            if (htr != null )
            {
                if (htr[0].Object is CustomLabel)
                {
                    CustomLabel theLabel = (CustomLabel)htr[0].Object;

                    // Funny! this does not work
                    // int idx = chtPackingResults.ChartAreas[0].AxisX.CustomLabels.IndexOf(theLabel);

                    //int idx = -1;
                    //for( int i = 0; i < chtPackingResults.ChartAreas[0].AxisX.CustomLabels.Count; i++ )
                    //{
                    //    if(chtPackingResults.ChartAreas[0].AxisX.CustomLabels[i].Text == theLabel.Text )
                    //    {
                    //        idx = i;
                    //        break;
                    //    }
                    //}
                    //if (idx >= 0)
                    //{
                    //    dgvVehicles.Rows[idx].Selected = true;
                    //    dgvVehicles.FirstDisplayedScrollingRowIndex = idx;
                    //}

                    for( int i = 0; i < dgvVehicles.RowCount; i++ )
                        if( ((int)dgvVehicles.Rows[i].Cells[2].Value)  ==((VehiclePackingInfo) theLabel.Tag).theVehicle.Id )
                        {
                            dgvVehicles.Rows[i].Selected = true;
                            dgvVehicles.FirstDisplayedScrollingRowIndex = i;
                            break;
                        }
                      
                }
                else if( htr[0].Object is DataPoint)
                {
                    DataPoint dp = ((DataPoint)htr[0].Object);
                    if (dp.Tag is OrdersRow)
                    {
                        int OrderID = ((OrdersRow)dp.Tag).Id;
                        for( int i = 0; i < dgvOrders.Rows.Count; i++ )
                        {
                            if( (int)(dgvOrders.Rows[i].Cells[0].Value) == OrderID )
                            {
                                dgvOrders.Rows[i].Selected = true;
                                dgvOrders.FirstDisplayedScrollingRowIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
        }

        DataPoint[] hilightedPoint  = new DataPoint[10];
        Color[] borderColorOfHilightedPoint = new Color[10];// Color.Empty;
        void UpdateHilightedPoint( DataPoint newPoint, int seq )
        {
            // if seq == 0 clear previous display
            if( seq == 0 )
                for (int i = 0; i < hilightedPoint.Length; i++)
                    if (hilightedPoint[i] != null)
                    {
                        hilightedPoint[i].BorderColor = borderColorOfHilightedPoint[i];
                    }
            hilightedPoint[seq] = newPoint;
            borderColorOfHilightedPoint[seq] = newPoint.BorderColor;
            newPoint.BorderColor = Color.Red;
        }



        void GAInitailized()
        { 
            pgdGAProperty.SelectedObject = theGASolver;
            spcGACmdProp.Enabled = true; //  spcGA.Enabled = true;
            btnReset.Enabled = true;
            btnRunOneIteration.Enabled = btnRunToEnd.Enabled = false;
            barProgress.Value = 0;
            statusBar.Refresh();
            foreach (Series s in chtGA.Series) s.Points.Clear();
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            if( !theGASolver.TerminationConditionMet())
            {
                theGASolver.ExecuteOneIteration();
                chtGA.Series[0].Points.AddXY(theGASolver.IterationCount, theGASolver.IterationAverage);
                chtGA.Series[1].Points.AddXY(theGASolver.IterationCount, theGASolver.IterationBestObjective);
                chtGA.Series[2].Points.AddXY(theGASolver.IterationCount, theGASolver.SoFarTheBestObjective);
                barProgress.Value =  theGASolver.IterationCount * 100 / theGASolver.IterationLimit;
                statusBar.Refresh();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            theProblem.GAOrganizeData( ); // Order may be split
            foreach (Series s in chtGA.Series) s.Points.Clear();
            theGASolver.Reset();

            btnRunToEnd.Enabled = btnRunOneIteration.Enabled = true;
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnRunOneIteration.Enabled = btnRunToEnd.Enabled = false;

            while (!theGASolver.TerminationConditionMet())
            {
                btnRunOneIteration_Click(null, null);
            }

            theProblem.GASolverAssignFinalSolution( theGASolver );
            Cursor = Cursors.Default;

            DisplayPackingResults();

        }

        private void datePicker_CloseUp(object sender, EventArgs e)
        {
            DateTime theDate = datePicker.Value;
            // 查驗是否有該日訂單
            SqlCommand cmd = new SqlCommand($"SELECT count(Id) FROM dbo.Orders WHERE deliveryDate = '{theDate.ToShortDateString()}'");
            cmd.Connection = ordersTA.Connection;
            cmd.Connection.Open();
            int cnt = (int)cmd.ExecuteScalar(); // cmd.ExecuteNonQuery();
            DateTime validDate = DateTime.Today;
            if (cnt == 0)
            {
                // Get Fist date 
                cmd.CommandText = $"SELECT deliveryDate FROM dbo.Orders WHERE [exeVehicleId] IS NULL";
                SqlDataReader sd = cmd.ExecuteReader();
                if (sd.HasRows)
                {
                    while (sd.Read())
                    {
                        validDate = sd.GetDateTime(0);
                        break;
                    }
                }
                sd.Close();
                MessageBox.Show(this, $"沒有送貨日是 {theDate.ToShortDateString()} 的訂單，改成最近尚未運送的貨單日期 {validDate.ToShortDateString()}！", "選取的日期沒有貨單", MessageBoxButtons.OK, MessageBoxIcon.Error);
                theDate = validDate;
            }
            cmd.Connection.Close();

            rtbDate.TextBoxText = theDate.ToShortDateString();
            datePicker.Visible = false;
        }

        string MethodString = "";

        private void DisplayPackingResults()
        {
            // 依照 problem 整理過的順序展示
            chtPackingResults.ChartAreas[0].AxisX.CustomLabels.Clear();

            blockSeries.Points.Clear();
            for (int i = 0; i < theProblem.Vehicles.Length; i++)
            {
                CustomLabel cl = new CustomLabel();
                foreach( VehiclePackingInfo vpi in theProblem.VehicleInfos )
                    if( vpi.theVehicle == theProblem.Vehicles[i])
                    {
                        cl.Tag = vpi;
                        break;
                    }
                
                cl.Text = theProblem.Vehicles[i].licensePlate;
                cl.FromPosition = i - 0.5;
                cl.ToPosition = i + 0.5;
                cl.RowIndex = 0;
                chtPackingResults.ChartAreas[0].AxisX.CustomLabels.Add(cl);
              
                cumulatedValues[i] = 0.0f;
 
                DataPoint dp = new DataPoint();
                dp.Color = Color.FromArgb(0, 255, 255, 255);
                dp.BorderColor = Color.Black;

                dp.BorderWidth = 1;
                dp.XValue = i;
                dp.YValues = new double[] { 0, theProblem.Vehicles[i].weightLimit * 1000 };
                blockSeries.Points.Add(dp);
            }
            OrdersRow[][] orderSets = { theProblem.Orders, theProblem.SplitNewOrders.ToArray<OrdersRow>() };
            for (int i = 0; i < orderSets.Length; i++)
                foreach (OrdersRow or in orderSets[i])
                {
                    int vid = -1, aid = -1;
                    try
                    {
                        vid = theProblem.VehicleIndexes[or.planVehicleId];
                        aid = GroupIdForIds[or.areaId];
                    }
                    catch
                    {
                        // 沒有排入，此時 DBNull
                        continue;
                    }
                    DataPoint dp = new DataPoint();
                    dp.Color = ColorForIds[or.areaId];
                    dp.BorderColor = MainForm.BorderColors[aid];
                    dp.Label = or.netWeight.ToString();
                    dp.Tag = or;
                    dp.BorderWidth = 3;
                    dp.XValue = vid;
                    dp.YValues = new double[] { cumulatedValues[vid], cumulatedValues[vid] + or.netWeight };
                    cumulatedValues[vid] = dp.YValues[1];
                    blockSeries.Points.Add(dp);
                }

            if (targetLeft)
            {
                labResultsLeft.ForeColor = Color.Maroon;
                labResultsLeft.Text = MethodString + theProblem.BestSolutionString;
                labResultsRight.ForeColor = Color.Gray;
            }
            else
            {
                labResultsRight.ForeColor = Color.Maroon;
                labResultsRight.Text = MethodString + theProblem.BestSolutionString;
                labResultsLeft.ForeColor = Color.Gray;
            }
            targetLeft = !targetLeft;



            foreach (DataGridViewRow dgvr in dgvOrders.Rows)
            {
                if (dgvr.DefaultCellStyle != dgvOrders.DefaultCellStyle)
                    dgvr.DefaultCellStyle = dgvOrders.DefaultCellStyle;
                bool discarded = false;
                // 先看是否是捨棄
                foreach (OrdersRow or in theProblem.NonLoadedOrders)
                    if ((int)dgvr.Cells[0].Value == or.Id)
                    {
                        dgvr.DefaultCellStyle = discardStyle;
                        discarded = true;
                        break;
                    }
                // 再看是否拆單
                foreach (OrdersRow or in theProblem.SplitNewOrders)
                    if ((int)dgvr.Cells[0].Value == or.Id)
                    {
                        if (discarded)
                            dgvr.DefaultCellStyle = splitAndDiscardStyle;
                        else
                            dgvr.DefaultCellStyle = splitStyle;
                        break;
                    }

            }
            dgvOrders.ClearSelection();
             
        }

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count <= 0) return;
            //int idx = dgvVehicles.SelectedRows[0].Index;

            int vkey = (int)( dgvVehicles.SelectedRows[0].Cells[2].Value );

            // CustomLabel theLabel = null;
            if (chtPackingResults.ChartAreas[0].AxisX.CustomLabels != null )
            {
                foreach (CustomLabel cl in chtPackingResults.ChartAreas[0].AxisX.CustomLabels)
                    if (((VehiclePackingInfo)cl.Tag).theVehicle.Id == vkey)
                    {
                        // theLabel = chtPackingResults.ChartAreas[0].AxisX.CustomLabels[idx];
                        UpdateHilightedCustomLabel(cl);
                        pgdVehicleInfo.SelectedObject = cl.Tag;
                    }
            }
        }

 
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count <= 0) return;
            if (theProblem == null || theProblem.Orders == null) return;

            int orderID = (int)dgvOrders.SelectedRows[0].Cells[0].Value;

            bool notHit = true;
            int seq = 0;
            // 搜尋 data point
            foreach( DataPoint dp in blockSeries.Points)
            {
                if( dp.Tag is OrdersRow )
                {
                   if( ((OrdersRow)dp.Tag).Id == orderID  )
                    {
                        UpdateHilightedPoint( dp, seq++ );
                        notHit = false;
                        //return;
                    }
                }
            }

            if( notHit || dgvOrders.SelectedRows[0].DefaultCellStyle == splitAndDiscardStyle )
            MessageBox.Show(this, $"貨單 {dgvOrders.SelectedRows[0].Cells[1].Value} 未排入！", "沒有排入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        private void rbnEvenGA_Click(object sender, EventArgs e)
        {
            MethodString = "*****  望均勻 GA 法 單段裝箱染色體 *****\n\n";

            theGASolver = theProblem.CreateAGroupingGASolver();

            pgdGAProperty.SelectedObject = theGASolver;
            pgdSolver.SelectedObject = theProblem.ParametersOfGroupingGA;
            rbnSmallNGA.Checked = rbnSmallExperience.Checked = rbnEvenExperience.Checked = rbnSmallGA.Checked = false;
            GAInitailized();
        }

        private void rbnSmallGA_Click(object sender, EventArgs e)
        {
            MethodString = "*****  望少車 GA 法 合體單段染色體 *****\n\n";

 

            theGASolver = theProblem.CreateAPermutationGASolver( );

            pgdGAProperty.SelectedObject = theGASolver;
            pgdSolver.SelectedObject = theProblem.ParametersOfPermutationGA;
            rbnSmallNGA.Checked = rbnSmallExperience.Checked = rbnEvenExperience.Checked = rbnEvenGA.Checked = false;
            GAInitailized();
        }

        private void rbnSmallNGA_Click(object sender, EventArgs e)
        {
            MethodString = "*****  望少車 GA 法 分群多段染色體 *****\n\n";



            theGASolver = theProblem.CreateNPermutationGASolver( );
            pgdGAProperty.SelectedObject = theGASolver;
            pgdSolver.SelectedObject = theProblem.ParametersOfPermutationGA;
            rbnSmallExperience.Checked = rbnEvenExperience.Checked = rbnEvenGA.Checked = rbnSmallGA.Checked = false;
            GAInitailized();
        }

        private void rckSplitable_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (theProblem == null) return;
            if (!rckVehicleWeightSplitable.Checked && !rckWeightSplitable.Checked) theProblem.OrderSplitThresh = -1;
            else
            {
                if (rckVehicleWeightSplitable.Checked) theProblem.OrderSplitThresh = 0;
                else  if(rckWeightSplitable.Checked)
                    theProblem.OrderSplitThresh = Convert.ToInt32(rtbWeightLimit.TextBoxText);
            }
        }

        private void rcbOrders_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (theProblem == null) return;
            VehicleOrder oldOrder = theProblem.GAVehicleSorting;
            VehicleOrder order = VehicleOrder.Auto;
            if (rcbOrders.SelectedItem == rlbBig) order = VehicleOrder.Big;
            else if (rcbOrders.SelectedItem == rlbSmall) order = VehicleOrder.Small;
            if (order != oldOrder)
            {
                rbnEvenGA.Checked = rbnSmallGA.Checked = rbnSmallNGA.Checked = false;
                foreach (Series s in chtGA.Series) s.Points.Clear();
               btnReset.Enabled =  btnRunToEnd.Enabled = btnRunOneIteration.Enabled = false;
                theProblem.GAVehicleSorting = order;
                pgdGAProperty.SelectedObject = pgdSolver.SelectedObject = null;
                spcGACmdProp.Enabled = false;
            }
        }

        private void rtbGAPanelShowHide_Click( object sender, EventArgs e )
        {
           spcGACmdProp.Visible = !spcGACmdProp.Visible;
            
            if( spcGACmdProp.Visible )
                spcChartNGA.SplitterDistance = spcChartNGA.Width * 3 / 4;
            else
                spcChartNGA.SplitterDistance= spcChartNGA.Width;           
        }
    }
}
