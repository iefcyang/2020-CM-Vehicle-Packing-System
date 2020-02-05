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
    public partial class OwnerEdit : Form
    {
        public OwnerEdit()
        {
            InitializeComponent();
        }

        private void vehicleOwnerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vehicleOwnerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vehiclePackingDataSet);

        }

        private void OwnerEdit_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.VehicleOwner' 資料表。您可以視需要進行移動或移除。
            this.vehicleOwnerTableAdapter.Fill(this.vehiclePackingDataSet.VehicleOwner);

        }


        private void vehicleOwnerDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < vehicleOwnerDataGridView.Rows.Count - 1; i++)
            {
                vehicleOwnerDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
    }
}
