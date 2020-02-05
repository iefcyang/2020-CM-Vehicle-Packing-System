using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehiclePackingSystem
{
    public partial class VehicleEdit : Form
    {
        public VehicleEdit()
        {
            InitializeComponent();

            tableAdapterManager.ModelTableAdapter = new VehiclePackingDataSetTableAdapters.ModelTableAdapter();
            tableAdapterManager.ModelTableAdapter.Fill(vehiclePackingDataSet.Model);
            colVehicleModel.DataSource = vehiclePackingDataSet.Model;
            colVehicleModel.DisplayMember = "titleModel";
            colVehicleModel.ValueMember = "Id";

            tableAdapterManager.VehicleOwnerTableAdapter = new VehiclePackingDataSetTableAdapters.VehicleOwnerTableAdapter();
            tableAdapterManager.VehicleOwnerTableAdapter.Fill(vehiclePackingDataSet.VehicleOwner);
            colVehicleOwner.DataSource = vehiclePackingDataSet.VehicleOwner;
            colVehicleOwner.DisplayMember = "ownerTitle";
            colVehicleOwner.ValueMember = "Id";

            tableAdapterManager.AreaTableAdapter = new VehiclePackingDataSetTableAdapters.AreaTableAdapter();
            tableAdapterManager.AreaTableAdapter.Fill(vehiclePackingDataSet.Area);
            colArea.DataSource = vehiclePackingDataSet.Area;
            colArea.DisplayMember = "titleArea";
            colArea.ValueMember = "Id";

            // 使用 LINQ 檢出區群別代號
            var gids = (from a in vehiclePackingDataSet.Area  select a.groupID).Distinct<int>();
            foreach( int g in gids ) cbxGroup.Items.Add(g);
            cbxGroup.SelectedIndex = 0;
            // groupID
            //Dictionary<string, int> groups = new Dictionary<string, int>();
            //groups.Add("Group 1", 1);
            //groups.Add("Group 2", 2);
            //groups.Add("Group 3", 3);
            //groups.Add("Group 4", 4);
            //groups.Add("Group 5", 5);


        }

        private void vehicleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vehicleBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vehiclePackingDataSet);

        }

        private void VehicleEdit_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.VehicleArea' 資料表。您可以視需要進行移動或移除。
            this.vehicleAreaTableAdapter.Fill(this.vehiclePackingDataSet.VehicleArea);
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Vehicle' 資料表。您可以視需要進行移動或移除。
            this.vehicleTableAdapter.Fill(this.vehiclePackingDataSet.Vehicle);

        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            DataEditTool.PasteClipboard(5, vehicleDataGridView, vehicleBindingSource );
        }

        private void vehicleDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < vehicleDataGridView.Rows.Count - 1; i++)
            {
                vehicleDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void vehicleAreaDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < vehicleAreaDataGridView.Rows.Count - 1; i++)
            {
                vehicleAreaDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void tsbAddAreas_Click(object sender, EventArgs e)
        {
            int vid = 0;
            //vehicleBindingNavigator.
            //
            int gid = (int)cbxGroup.SelectedItem;
            // get areas with group id gid
            // LINQ 檢出 區群 gid 的地區 ids
            var aids = from anArea in vehiclePackingDataSet.Area where (anArea.groupID == gid) select anArea.Id;
            // 新增一筆運行地區id到目前貨車
            int start = vehicleAreaDataGridView.Rows.Count-1;
            foreach (var aid in aids) vehicleAreaBindingSource.AddNew();
            foreach ( var aid in aids)
            {
                // 新增 grid row method
                int k = 0;
                while (!vehicleAreaDataGridView.Columns[k].Visible) k++;
                vehicleAreaDataGridView[k, start].Value = aid;
                start++;
                // 新增 datatable datarow method
                //VehiclePackingDataSet.VehicleAreaRow row =
                //    ( VehiclePackingDataSet.VehicleAreaRow )vehiclePackingDataSet.VehicleArea.NewRow();
                //row.areaId = aid;
                ////row.vehicleId = vid;
                //vehiclePackingDataSet.VehicleArea.Rows.Add(row);
            }
            vehicleAreaDataGridView.RefreshEdit();

        }

        private void tsbDeleteAll_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show(this,$"現有 {vehicleAreaDataGridView.Rows.Count-1} 個地區，是否全部清空變成沒有限制？","取消限制警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK  )
            {
                for (int i = vehicleAreaDataGridView.Rows.Count - 2; i >= 0; i--)
                    vehicleAreaDataGridView.Rows.RemoveAt(i);
            }
        }
    }
}
