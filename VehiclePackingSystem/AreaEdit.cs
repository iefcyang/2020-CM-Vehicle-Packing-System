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
    public partial class AreaEdit : Form
    {
        public AreaEdit()
        {
            InitializeComponent();
        }

        private void areaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.areaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.vehiclePackingDataSet);

        }

        private void AreaEdit_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'vehiclePackingDataSet.Area' 資料表。您可以視需要進行移動或移除。
            this.areaTableAdapter.Fill(this.vehiclePackingDataSet.Area);

        }

        private void areaDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < areaDataGridView.Rows.Count - 1; i++)
            {
                areaDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
                
                if ( !DBNull.Value.Equals(vehiclePackingDataSet.Area[i]["color"]))
                    areaDataGridView.Rows[i].Cells[4].Style.BackColor = Color.FromArgb((int)areaDataGridView.Rows[i].Cells[4].Value);
            }
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            DataEditTool.PasteClipboard(3, areaDataGridView, areaBindingSource );
            
        }
        Random rnd = new Random();

        private void tsbSetColor_Click(object sender, EventArgs e)
        {
            Color baseColor;
             
            for( int i = 0; i < this.vehiclePackingDataSet.Area.Count; i++  )
            {
                int gid = vehiclePackingDataSet.Area[i].groupID;
                if (gid >= MainForm.BorderColors.Length)
                    baseColor = Color.FromArgb(rnd.Next(150), rnd.Next(150), rnd.Next(150));
                else
                    baseColor = MainForm.BorderColors[gid];
                int off = (255 - baseColor.R) / 3;
                double delta = off / 2.0;
                double rng =  (rnd.NextDouble() - 0.5) * delta;
                int r = 255 - off + (int)rng;
                off = (255 - baseColor.G) / 3;
                rng = (rnd.NextDouble() - 0.5) * delta;
                int g = 255 - off + (int)rng;
                off = (255 - baseColor.B) / 3;
                rng = (rnd.NextDouble() - 0.5) * delta;
                int b = 255 - off + (int)rng;
                Color c =  Color.FromArgb( r, g, b);
                 areaDataGridView.Rows[i].Cells[4].Style.BackColor = c;

                vehiclePackingDataSet.Area[i].color = c.ToArgb();
            }

            areaDataGridView.Refresh();
        }
    }
}
