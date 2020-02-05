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
    public partial class ModelEdit : Form
    {
        public ModelEdit()
        {
            InitializeComponent();
        }


        private void ModelEdit_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Model' 資料表。您可以視需要進行移動或移除。
            this.modelTableAdapter.Fill(this.vehiclePackingDataSet.Model);
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Model' 資料表。您可以視需要進行移動或移除。
            this.modelTableAdapter.Fill(this.vehiclePackingDataSet.Model);
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Model' 資料表。您可以視需要進行移動或移除。
            //this.modelTableAdapter.Fill(this.vehiclePackingDataSet.Model);
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Model' 資料表。您可以視需要進行移動或移除。
            //this.modelTableAdapter.Fill(this.vehiclePackingDataSet.Model);
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Model' 資料表。您可以視需要進行移動或移除。

        }

        private void modelBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.modelBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vehiclePackingDataSet);

        }

        private void modelDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < modelDataGridView.Rows.Count - 1; i++)
            {
                modelDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void modelBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.modelBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vehiclePackingDataSet);

        }
    }
}
