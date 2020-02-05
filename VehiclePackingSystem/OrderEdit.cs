using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace VehiclePackingSystem
{
    public partial class OrderEdit : Form
    {
        string DateFilterString = "";
        public OrderEdit( string dateString = "" )
        {
            DateFilterString = dateString;

            InitializeComponent();

            tableAdapterManager.AreaTableAdapter = new VehiclePackingDataSetTableAdapters.AreaTableAdapter();
            updateAreaCombox( );
            //tableAdapterManager.AreaTableAdapter.Fill(vehiclePackingDataSet.Area);
            //colArea.DataSource = vehiclePackingDataSet.Area;
            //colArea.DisplayMember = "titleArea";
            //colArea.ValueMember = "Id";

            tableAdapterManager.VehicleTableAdapter = new VehiclePackingDataSetTableAdapters.VehicleTableAdapter();
            tableAdapterManager.VehicleTableAdapter.Fill(vehiclePackingDataSet.Vehicle);
            colExeVehicle.DataSource = colPlanVehicle.DataSource = vehiclePackingDataSet.Vehicle;
            colExeVehicle.DisplayMember = colPlanVehicle.DisplayMember = "licensePlate";
            colExeVehicle.ValueMember = colPlanVehicle.ValueMember = "Id";
        }

        void updateAreaCombox()
        {
            tableAdapterManager.AreaTableAdapter.Fill( vehiclePackingDataSet.Area );
            colArea.DataSource = vehiclePackingDataSet.Area;
            colArea.DisplayMember = "titleArea";
            colArea.ValueMember = "Id";
        }

        private void ordersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ordersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vehiclePackingDataSet);

        }

        private void OrderEdit_Load(object sender, EventArgs e)
        {


            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Orders' 資料表。您可以視需要進行移動或移除。
           // this.ordersTableAdapter.Fill(this.vehiclePackingDataSet.Orders);
             if( DateFilterString != "" )
            {
                this.ordersTableAdapter.FillByDate(this.vehiclePackingDataSet.Orders, DateFilterString);
                // 加入過濾條件
                //ordersTableAdapter.Adapter.SelectCommand = new System.Data.SqlClient.SqlCommand( $"SELECT Id, netWeight, areaId, product, exeVehicleId, planVehicleId, deliveryDate FROM dbo.Orders WHERE dbo.deliveryDate = '{DateFilterString}'" );
            }
            else this.ordersTableAdapter.Fill(this.vehiclePackingDataSet.Orders);

        }

        private void ordersDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < ordersDataGridView.Rows.Count - 1; i++)
            {
                ordersDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void tsbPaste_Click( object sender, EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog( );
            if( dlg.ShowDialog( ) != DialogResult.OK ) return;
            bool clearAll = false;
            if( MessageBox.Show( "是否要先清空資料庫內現有貨單資料？", "現有資料保存與否", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
                clearAll = true;

            // 展示表單確認欄位
            string[ ] titles = { "物料", "收貨人地址", "淨重", "運輸地區", "檢貨日期", "交貨運輸區" };
            int[ ] fields = new int[6];

            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook theBook = Excel.Workbooks.Open(dlg.FileName);
           // Worksheet theSheet = theBook.Worksheets["工作表1"];
            Worksheet theSheet = theBook.Worksheets[ 1 ];
            for( int c = 0 ; c < titles.Length ; c++ )
            {
                int k = 1;
                while( theSheet.Cells[1,k] != null )
                {
                    if( (string) theSheet.Cells[ 1, k ].Value == titles[c] )
                    {
                        fields[ c ] = k;
                        break;
                    }
                    k++;
                }
            }
            int start = ordersDataGridView.RowCount - 1;

            if( clearAll)
            {               
                for( int i = vehiclePackingDataSet.Orders.Count - 1 ; i >= 0 ; i-- )
                    vehiclePackingDataSet.Orders[ i ].Delete( );
               // this.vehiclePackingDataSet.Orders.Clear( );
                ordersBindingSource.ResetBindings( false );
                // ordersDataGridView.Rows.Clear( );
                //ordersBindingSource.Clear( );
                start = 0;
            }
            int row = 2;

            while (theSheet.Cells[row, 1].value != null)
            {
                string product = (string) theSheet.Cells[row, fields[0]].Value;
                float weightKG = (float)theSheet.Cells[row, fields[ 2 ] ].Value;
                string address = (string) theSheet.Cells[ row, fields[ 1 ] ].Value;
                DateTime date = (DateTime)theSheet.Cells[row, fields[ 4 ] ].Value;
                int areaID = Convert.ToInt32((string)theSheet.Cells[row, fields[ 3 ] ].Value);
                string areaName = (string) theSheet.Cells[ row, fields[5 ] ].Value;
                int key;
                var aid = from a in vehiclePackingDataSet.Area
                          where a.zipCode == areaID
                          select a.Id;
                if( aid.Count( ) == 0 )
                {
                    key = DataEditTool.AddAnArea( areaName, areaID );
                    updateAreaCombox( );
                }
                else
                    key = ( (int[ ]) aid.ToArray<int>( ) )[ 0 ];

                ordersBindingSource.AddNew();

                //colAddress colProduct colWeight colLongitude colLatitude colArea colRoutingOrder colDate
                //int k = 0;
                //while (!ordersDataGridView.Columns[k].Visible) k++;
                //ordersDataGridView[k++, start].Value = product;
                //while (!ordersDataGridView.Columns[k].Visible) k++;
                //ordersDataGridView[k++, start].Value = weightKG;
                //while (!ordersDataGridView.Columns[k].Visible) k++;
                //ordersDataGridView[k++, start].Value =  aaids[0];
                //while (!ordersDataGridView.Columns[k].Visible) k++;
                //ordersDataGridView[k++, start].Value = date;
                ordersDataGridView["colProduct", start ].Value = product;
                ordersDataGridView["colWeight", start ].Value = weightKG;
                ordersDataGridView["colArea", start ].Value = key;
                ordersDataGridView[ "colDate", start ].Value = date;
                ordersDataGridView[ "colAddress", start ].Value = address;

                start++;
                row++;
                ordersDataGridView.RefreshEdit();
            }
            theBook.Close();
            Excel.Quit();
            Marshal.ReleaseComObject(theBook);
            Marshal.ReleaseComObject(Excel);
            //ex.Workbook wk = Ex
        }
 
        private void tsbSetCoordinates_Click( object sender, EventArgs e )
        {
            for( int i = 0 ; i < this.ordersDataGridView.Rows.Count ; i++  )
            {
                string address = ordersDataGridView[ "colAddress", i ].Value.ToString( );
                string url = $"http://maps.google.com/maps/api/geocode/json?sensor=false&address={address}";

                string result = String.Empty;
                HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create( url );
                using( var response = request.GetResponse( ) )
                using( StreamReader sr = new StreamReader( response.GetResponseStream( ) ) )
                {
                    //Json格式: 請參考http://code.google.com/intl/zh-TW/apis/maps/documentation/geocoding/
                    result = sr.ReadToEnd( );
                }

            }


        }
    }
}
