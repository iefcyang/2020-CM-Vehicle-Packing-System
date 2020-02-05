using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehiclePackingSystem
{
    //public enum VehicleModel : byte
    //{
    //    大車, 中車, T16車
    //}

    //public class VehicleOwner
    //{
    //    [DisplayName("貨運承攬業")]
    //    public int id { get; set; }
    //    [DisplayName("貨運承攬業者的名稱")]
    //    string title { get; set; }

    //    internal void Save(BinaryWriter bw)
    //    {
    //        bw.Write(title);
    //        bw.Write(id);
    //    }

    //    internal void Read(BinaryReader br)
    //    {
    //        title = br.ReadString();
    //        id = br.ReadInt32();
    //    }
    //}
    //public class Area
    //{
    //    [DisplayName("名稱")]
    //    public string title { set; get; }

    //    [DisplayName("郵遞區號")]
    //    public int zipCode { set; get; }

    //    [DisplayName("區別號")]
    //    public int groupID { set; get; }

    //    public Area() { }
 
    //    public void Save(BinaryWriter bw)
    //    {
    //        bw.Write(title);
    //        bw.Write(zipCode);
    //        bw.Write(groupID);
    //    }

    //    public void Read(BinaryReader br)
    //    {
    //        title = br.ReadString();
    //        zipCode = br.ReadInt32();
    //        groupID = br.ReadInt32();
    //    }
    //}


    //public class Vehicle
    //{
    //    // properties
    //    [DisplayName("車牌號碼")]
    //    public string licensePlate { get; set; }

    //    [DisplayName("車型")] 
    //    public VehicleModel model { get; set; } = VehicleModel.中車;

    //    [DisplayName("載重噸限")]
    //    public double weightLimit { get; set; }

    //    [DisplayName("車屬業者")]
    //    public VehicleOwner owner { get; set; }

    //    [DisplayName("運行區域集合")]
    //    public Area[] deliveryAreas { get; set; }

    //    // decision variables
    //    [DisplayName("啟用與否")]
    //    public bool enabled { get; set; }  = true;

    //    internal void Save(BinaryWriter bw, List<VehicleOwner> owners, List<Area> areas )
    //    {
    //        bw.Write(licensePlate);
    //        bw.Write((byte)model);
    //        bw.Write(weightLimit);
    //        bw.Write( owners.IndexOf( owner));
    //        bw.Write(deliveryAreas.Length);
    //        foreach (Area a in deliveryAreas)
    //            bw.Write( areas.IndexOf(a));
    //    }

    //    internal void Read(BinaryReader br, List<VehicleOwner> owners, List<Area> areas )
    //    {
    //        licensePlate = br.ReadString();
    //        byte mid = br.ReadByte();
    //        model = (VehicleModel)mid;
    //        weightLimit = br.ReadDouble();
    //        int oid = br.ReadInt32();
    //        owner = owners[oid];
    //        int num = br.ReadInt32();
    //        deliveryAreas = new Area[num];
    //        for (int i = 0; i < num; i++)
    //        {
    //            oid = br.ReadInt32();
    //            deliveryAreas[i] = areas[oid];
    //        }
    //    }
    //}


    //public class VehiclePackingProblemOLD
    //{
    //    // 必須使用可以編輯添加刪除的動態list，才能在 binded data grid view
    //    // 內編輯新增刪除
    //    public List<Area> areas = new List<Area>();
    //    public List<VehicleOwner> owners = new List<VehicleOwner>();
    //    public List<Vehicle> vehicles = new List<Vehicle>();

    //    public void SaveConfiguration()
    //    {
    //        string file = "configuration";
    //        FileStream fs = new FileStream(file, FileMode.Truncate);
    //        BinaryWriter bw = new BinaryWriter(fs);
    //        bw.Write(areas.Count);
    //        foreach (Area a in areas)
    //            a.Save(bw);
    //        bw.Write(owners.Count);
    //        foreach (VehicleOwner vo in owners)
    //            vo.Save(bw);
    //        bw.Write(vehicles.Count);
    //        foreach (Vehicle v in vehicles)
    //            v.Save(bw, owners, areas );
    //        bw.Close();
    //        fs.Close();
    //    }

    //    // 載入組態檔案，內定檔名 configuration。二進位編碼。
    //    public void ReadConfiguration()
    //    {
    //        string file = "configuration";
    //        FileStream fs;

    //        if ( !File.Exists(file))
    //        {
    //            bool createEmpty = true;
    //            if( MessageBox.Show("組態檔案 configuration 不在內定的目錄內。是否儲存在他處？\nYes 是: 會要求找到組態檔。\nNo 否: 會另外建立空的組態檔。","檔案找不到", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes )
    //            {
    //                OpenFileDialog dlg = new OpenFileDialog();
    //                dlg.FileName = file;
    //                if (dlg.ShowDialog() == DialogResult.OK)
    //                {
    //                    if (File.Exists(dlg.FileName))
    //                    {
    //                        // Copy to 
    //                        File.Copy(dlg.FileName, file);
    //                        createEmpty = false;
    //                    }
    //                }
    //                else MessageBox.Show("系統會另外建立空的組態檔。","未選取任何檔案", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            }
    //            if( createEmpty)
    //            {
    //                fs = new FileStream(file, FileMode.CreateNew);
    //                BinaryWriter bw = new BinaryWriter(fs);
    //                bw.Write(0); // No areas
    //                bw.Write(0); // No owners
    //                bw.Write(0); // No vehicles
    //                bw.Close();
    //                fs.Close();
    //            }
    //        }
    //        // read configuration file to construct the model
    //        fs = new FileStream(file, FileMode.Open);
    //        BinaryReader br = new BinaryReader(fs);
    //        int num =  br.ReadInt32();
    //        areas.Clear();
    //        for (int i = 0; i < num; i++)
    //        {
    //            areas.Add( new Area() );
    //            areas[i].Read(br);
    //        }
    //        num = br.ReadInt32();
    //        owners.Clear();
    //        for (int i = 0; i < num; i++)
    //        {
    //            owners.Add( new VehicleOwner() );
    //            owners[i].Read(br);
    //        }

    //        num = br.ReadInt32();
    //        vehicles.Clear();
    //        for (int i = 0; i < num; i++)
    //        {
    //            vehicles.Add(new Vehicle());
    //            vehicles[i].Read(br, owners, areas);
    //        }

    //        br.Close();
    //        fs.Close();

    //    }

    //}
}
