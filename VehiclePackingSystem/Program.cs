using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehiclePackingSystem
{
    delegate int f(int i);
        delegate double FunctionTakesDoubleArray(double[] asolution);



    static class Program
    {
        //static void ff()
        //{

        //    int ags; // number of solution agents
        //    int len; // number of variables
        //    double[][] slns; // solutions of all agents; newly given 
        //    double[] objs; // objective values of all agents; not updated yet; to be calculated
        //    double iBestObj;  // the best objective of the agents; to be computed
        //    double iAvg; // objective average of all agents; to be computed
        //    double gBestObj;  // so far the best objective; to be updated
        //    double[] gBestSln; // so far the best solution; to be updated
        //    FunctionTakesDoubleArray objFunction; // has been assigned in the constructor
        //    void ComputeObjectivesAndUpdateBest()
        //    {
        //        // Calculate objective values for each agent, objective average of all agents,
        //        // and the iteration best objective. Update the information of so far the best 
        //        // objective and solution, supposing that a minimization problem is dealt with.
        //        iBestObj = double.MaxValue;
        //        int bestIdx = -1;
        //        for (int i = 0; i < ags; i++)
        //        {
        //            objs[i] = objFunction(slns[i]);
        //            if (objs[i] < iBestObj)
        //            {
        //                bestIdx = i;
        //                iBestObj = objs[i];
        //             }
        //        }
        //        if( iBestObj < gBestObj )
        //        {
        //            gBestObj = iBestObj;
        //            for (int j = 0; j < len; j++)
        //                gBestSln[j] = slns[bestIdx][j];
        //        }
        //    }

        //}

        /// </summary>
        [STAThread]
        static void Main()
        {
            // 先找應用程式所在目錄，是否有 DB。
            string directory = Path.GetDirectoryName( Application.ExecutablePath );
            string dbPath = Path.Combine( directory, "VehiclePackingDatabase.mdf" );

            if (!File.Exists( dbPath ) )
            {
                // 適用開發階段 尋找位於專案目錄內的 DB
                dbPath = Path.GetFullPath( Path.Combine( directory, @"..\..\VehiclePackingDatabase.mdf" ) );

                // 找原始專案上面的目錄
                if( File.Exists( dbPath ) )
                {
                    AppDomain.CurrentDomain.SetData( "DataDirectory", Path.GetDirectoryName(dbPath) );  // 溫州街 南港
                }
                else
                {
                    // 沒有資料庫
                    throw new Exception( "需要的資料庫 VehiclePackingDatabase.mdf 不存在！請洽軟體開發者！" );
                }
            }
 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
