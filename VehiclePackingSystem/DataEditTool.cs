using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehiclePackingSystem.VehiclePackingDataSetTableAdapters;

namespace VehiclePackingSystem
{
    public class DataEditTool
    {
        static public int AddAnArea( string AreaTitle, int AreaCode )
        {
            VehiclePackingDataSet.AreaDataTable atable = new VehiclePackingDataSet.AreaDataTable( );
            VehiclePackingDataSet.AreaRow row = atable.NewAreaRow( );
            row.titleArea = AreaTitle;
            row.zipCode = AreaCode;
            AreaTableAdapter ata = new AreaTableAdapter( );
            atable.Rows.Add( row );
            int num = ata.Update( atable );
            if( num != 1 ) return -1;
            return atable[ 0 ].Id;

            //ata.Fill( atable );
            //var aid = from a in atable
            //          where a.zipCode == AreaCode // && a.titleArea == AreaTitle
            //          select a.Id;
            //int id = -1;
            //if( aid.Count( ) != 0 ) 
            //    id = ( (int[ ]) aid.ToArray<int>( ) )[ 0 ];
            //return id;
        }

        static public void PasteClipboard( int numberOfColumns, DataGridView dgvData, BindingSource bs )
        {
            int start = 0;
            dgvData.AllowUserToAddRows = false;
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                start = dgvData.Rows.Count;
                for( int i = 0; i < lines.Length;i++) bs.AddNew();
                foreach (string line in lines)
                {
                    string[] items = line.Split('\t');
                    if (items.Length != numberOfColumns)
                    {
                        MessageBox.Show($"剪貼簿資料欄位數 {items.Length} 和資料表蘭欄數 {dgvData.ColumnCount} 不吻合！", "無法添加", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int k = 0;
                    for (int c = 0; c < items.Length; c++,k++)
                    {
                        while (!dgvData.Columns[k].Visible) k++;
                        dgvData[k, start].Value = Convert.ChangeType(items[c], dgvData.Columns[k].ValueType);
                    }
                    start++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"剪貼簿資料格式和資料表格式不吻合！\n{e.Message}", "貼入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if( start > 0 ) dgvData.Rows[start - 1].Cells[0].Selected = true;
           dgvData.AllowUserToAddRows = true;
        }


    }
}
