namespace VehiclePackingSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ribbonMain = new System.Windows.Forms.Ribbon();
            this.rtbConfiguration = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbnEditModels = new System.Windows.Forms.RibbonButton();
            this.rbnEditOwners = new System.Windows.Forms.RibbonButton();
            this.rplAreasAndVehicles = new System.Windows.Forms.RibbonPanel();
            this.rbnEditAreas = new System.Windows.Forms.RibbonButton();
            this.rbnEditVehicle = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.rbnAddRow = new System.Windows.Forms.RibbonButton();
            this.rtbPacking = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rcbAll = new System.Windows.Forms.RibbonCheckBox();
            this.rcbDeliveryDate = new System.Windows.Forms.RibbonCheckBox();
            this.rtbDate = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.rbnEditOrders = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.rckVehicleWeightSplitable = new System.Windows.Forms.RibbonCheckBox();
            this.rckWeightSplitable = new System.Windows.Forms.RibbonCheckBox();
            this.rtbWeightLimit = new System.Windows.Forms.RibbonTextBox();
            this.rckConstrainted = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.rbnCreateModel = new System.Windows.Forms.RibbonButton();
            this.rplSmallExperience = new System.Windows.Forms.RibbonPanel();
            this.rckLargeFirst = new System.Windows.Forms.RibbonCheckBox();
            this.rckSmallFirst = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.rckGroupOrder = new System.Windows.Forms.RibbonCheckBox();
            this.rckGroupReverse = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator5 = new System.Windows.Forms.RibbonSeparator();
            this.rbnSmallExperience = new System.Windows.Forms.RibbonButton();
            this.rbnEvenExperience = new System.Windows.Forms.RibbonButton();
            this.rplSmallGA = new System.Windows.Forms.RibbonPanel();
            this.rcbOrders = new System.Windows.Forms.RibbonComboBox();
            this.rlbBig = new System.Windows.Forms.RibbonLabel();
            this.rlbSmall = new System.Windows.Forms.RibbonLabel();
            this.rlbAuto = new System.Windows.Forms.RibbonLabel();
            this.rbnSmallGA = new System.Windows.Forms.RibbonButton();
            this.rbnSmallNGA = new System.Windows.Forms.RibbonButton();
            this.rplEvenGA = new System.Windows.Forms.RibbonPanel();
            this.rbnEvenGA = new System.Windows.Forms.RibbonButton();
            this.rtbAbout = new System.Windows.Forms.RibbonTab();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.spcPacking = new System.Windows.Forms.SplitContainer();
            this.spcOrderNVehicle = new System.Windows.Forms.SplitContainer();
            this.spcVehicle = new System.Windows.Forms.SplitContainer();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.pgdVehicleInfo = new System.Windows.Forms.PropertyGrid();
            this.labVehicle = new System.Windows.Forms.Label();
            this.labOrders = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.spcChartNGA = new System.Windows.Forms.SplitContainer();
            this.spcResults = new System.Windows.Forms.SplitContainer();
            this.spcResultLabels = new System.Windows.Forms.SplitContainer();
            this.labResultsLeft = new System.Windows.Forms.Label();
            this.labResultsRight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chtPackingResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.spcGACmdProp = new System.Windows.Forms.SplitContainer();
            this.tabGAParameters = new System.Windows.Forms.TabControl();
            this.pagSolver = new System.Windows.Forms.TabPage();
            this.pgdGAProperty = new System.Windows.Forms.PropertyGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pgdSolver = new System.Windows.Forms.PropertyGrid();
            this.labGAParameter = new System.Windows.Forms.Label();
            this.spcGA = new System.Windows.Forms.SplitContainer();
            this.btnRunToEnd = new System.Windows.Forms.Button();
            this.btnRunOneIteration = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.chtGA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.barProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tipTool = new System.Windows.Forms.ToolTip(this.components);
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.rpnOrdersVehicles = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton9 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.rtbGAPanelShowHide = new System.Windows.Forms.RibbonButton();
            this.ribbonButton11 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton12 = new System.Windows.Forms.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.spcPacking)).BeginInit();
            this.spcPacking.Panel1.SuspendLayout();
            this.spcPacking.Panel2.SuspendLayout();
            this.spcPacking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcOrderNVehicle)).BeginInit();
            this.spcOrderNVehicle.Panel1.SuspendLayout();
            this.spcOrderNVehicle.Panel2.SuspendLayout();
            this.spcOrderNVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcVehicle)).BeginInit();
            this.spcVehicle.Panel1.SuspendLayout();
            this.spcVehicle.Panel2.SuspendLayout();
            this.spcVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcChartNGA)).BeginInit();
            this.spcChartNGA.Panel1.SuspendLayout();
            this.spcChartNGA.Panel2.SuspendLayout();
            this.spcChartNGA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcResults)).BeginInit();
            this.spcResults.Panel1.SuspendLayout();
            this.spcResults.Panel2.SuspendLayout();
            this.spcResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcResultLabels)).BeginInit();
            this.spcResultLabels.Panel1.SuspendLayout();
            this.spcResultLabels.Panel2.SuspendLayout();
            this.spcResultLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtPackingResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcGACmdProp)).BeginInit();
            this.spcGACmdProp.Panel1.SuspendLayout();
            this.spcGACmdProp.Panel2.SuspendLayout();
            this.spcGACmdProp.SuspendLayout();
            this.tabGAParameters.SuspendLayout();
            this.pagSolver.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcGA)).BeginInit();
            this.spcGA.Panel1.SuspendLayout();
            this.spcGA.Panel2.SuspendLayout();
            this.spcGA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtGA)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.CaptionBarVisible = false;
            this.ribbonMain.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonMain.Minimized = false;
            this.ribbonMain.Name = "ribbonMain";
            // 
            // 
            // 
            this.ribbonMain.OrbDropDown.BorderRoundness = 8;
            this.ribbonMain.OrbDropDown.Enabled = false;
            this.ribbonMain.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.OrbDropDown.Name = "";
            this.ribbonMain.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbonMain.OrbDropDown.TabIndex = 0;
            this.ribbonMain.OrbImage = null;
            this.ribbonMain.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbonMain.OrbText = "Demo";
            this.ribbonMain.OrbVisible = false;
            // 
            // 
            // 
            this.ribbonMain.QuickAcessToolbar.Visible = false;
            this.ribbonMain.RibbonTabFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonMain.Size = new System.Drawing.Size(1286, 117);
            this.ribbonMain.TabIndex = 0;
            this.ribbonMain.Tabs.Add(this.rtbConfiguration);
            this.ribbonMain.Tabs.Add(this.rtbPacking);
            this.ribbonMain.Tabs.Add(this.rtbAbout);
            this.ribbonMain.Tabs.Add(this.ribbonTab1);
            this.ribbonMain.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbonMain.Text = "ribbonMain";
            this.ribbonMain.ThemeColor = System.Windows.Forms.RibbonTheme.Purple;
            // 
            // rtbConfiguration
            // 
            this.rtbConfiguration.Panels.Add(this.ribbonPanel1);
            this.rtbConfiguration.Panels.Add(this.rplAreasAndVehicles);
            this.rtbConfiguration.Panels.Add(this.ribbonPanel5);
            this.rtbConfiguration.Text = "Configure 組態";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rbnEditModels);
            this.ribbonPanel1.Items.Add(this.rbnEditOwners);
            this.ribbonPanel1.Text = "車型和承攬業者";
            // 
            // rbnEditModels
            // 
            this.rbnEditModels.Image = ((System.Drawing.Image)(resources.GetObject("rbnEditModels.Image")));
            this.rbnEditModels.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEditModels.SmallImage")));
            this.rbnEditModels.Text = "車種";
            this.rbnEditModels.ToolTip = "設定、編輯、變更車種。";
            this.rbnEditModels.ToolTipImage = ((System.Drawing.Image)(resources.GetObject("rbnEditModels.ToolTipImage")));
            this.rbnEditModels.ToolTipTitle = "車種編輯展示";
            this.rbnEditModels.Click += new System.EventHandler(this.rbnEditModel_Click);
            // 
            // rbnEditOwners
            // 
            this.rbnEditOwners.Image = ((System.Drawing.Image)(resources.GetObject("rbnEditOwners.Image")));
            this.rbnEditOwners.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEditOwners.SmallImage")));
            this.rbnEditOwners.Text = "業者";
            this.rbnEditOwners.ToolTip = "設定、編輯、變更承攬業者。";
            this.rbnEditOwners.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnEditOwners.ToolTipTitle = "承攬業者編輯展示";
            this.rbnEditOwners.Click += new System.EventHandler(this.rbnEditOwners_Click);
            // 
            // rplAreasAndVehicles
            // 
            this.rplAreasAndVehicles.Items.Add(this.rbnEditAreas);
            this.rplAreasAndVehicles.Items.Add(this.rbnEditVehicle);
            this.rplAreasAndVehicles.Text = "運送地區和貨車";
            // 
            // rbnEditAreas
            // 
            this.rbnEditAreas.Image = ((System.Drawing.Image)(resources.GetObject("rbnEditAreas.Image")));
            this.rbnEditAreas.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEditAreas.SmallImage")));
            this.rbnEditAreas.Text = "地區";
            this.rbnEditAreas.ToolTip = "設定、編輯、變更地區。";
            this.rbnEditAreas.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnEditAreas.ToolTipTitle = "地區編輯展示";
            this.rbnEditAreas.Click += new System.EventHandler(this.rbnEditArea_Click);
            // 
            // rbnEditVehicle
            // 
            this.rbnEditVehicle.Image = ((System.Drawing.Image)(resources.GetObject("rbnEditVehicle.Image")));
            this.rbnEditVehicle.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEditVehicle.SmallImage")));
            this.rbnEditVehicle.Text = "貨車";
            this.rbnEditVehicle.ToolTip = "設定、編輯、變更貨車。";
            this.rbnEditVehicle.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnEditVehicle.ToolTipTitle = "貨車編輯展示";
            this.rbnEditVehicle.Click += new System.EventHandler(this.rbnEditVehicle_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.rbnAddRow);
            this.ribbonPanel5.Text = "Data Editing";
            this.ribbonPanel5.Visible = false;
            // 
            // rbnAddRow
            // 
            this.rbnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("rbnAddRow.Image")));
            this.rbnAddRow.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnAddRow.SmallImage")));
            this.rbnAddRow.Text = "Paste";
            this.rbnAddRow.Click += new System.EventHandler(this.rbnAddRow_Click);
            // 
            // rtbPacking
            // 
            this.rtbPacking.Panels.Add(this.ribbonPanel3);
            this.rtbPacking.Panels.Add(this.ribbonPanel4);
            this.rtbPacking.Panels.Add(this.rplSmallExperience);
            this.rtbPacking.Panels.Add(this.rplSmallGA);
            this.rtbPacking.Panels.Add(this.rplEvenGA);
            this.rtbPacking.Text = "Packing 合車";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.rcbAll);
            this.ribbonPanel3.Items.Add(this.rcbDeliveryDate);
            this.ribbonPanel3.Items.Add(this.rtbDate);
            this.ribbonPanel3.Items.Add(this.ribbonSeparator1);
            this.ribbonPanel3.Items.Add(this.rbnEditOrders);
            this.ribbonPanel3.Text = "貨單";
            // 
            // rcbAll
            // 
            this.rcbAll.Checked = true;
            this.rcbAll.CheckedGroup = "OrderOptions";
            this.rcbAll.Text = "所有貨單";
            this.rcbAll.ToolTip = "檢出所有貨單供檢視。";
            this.rcbAll.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rcbAll.ToolTipTitle = "貨單選項";
            this.rcbAll.CheckBoxCheckChanged += new System.EventHandler(this.DateChecked);
            // 
            // rcbDeliveryDate
            // 
            this.rcbDeliveryDate.CheckedGroup = "OrderOptions";
            this.rcbDeliveryDate.Text = "檢出 送貨日";
            this.rcbDeliveryDate.ToolTip = "啟用單日貨單選擇模式。";
            this.rcbDeliveryDate.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rcbDeliveryDate.ToolTipTitle = "貨單選項";
            this.rcbDeliveryDate.CheckBoxCheckChanged += new System.EventHandler(this.DateChecked);
            // 
            // rtbDate
            // 
            this.rtbDate.AllowTextEdit = false;
            this.rtbDate.Enabled = false;
            this.rtbDate.Text = "日期";
            this.rtbDate.TextBoxText = "2019/10/10";
            this.rtbDate.ToolTip = "設定擬檢出的貨單所屬的出貨日。";
            this.rtbDate.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rtbDate.ToolTipTitle = "出貨日檢出";
            this.rtbDate.Value = "";
            this.rtbDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbDate_MouseDown);
            // 
            // rbnEditOrders
            // 
            this.rbnEditOrders.Image = ((System.Drawing.Image)(resources.GetObject("rbnEditOrders.Image")));
            this.rbnEditOrders.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEditOrders.SmallImage")));
            this.rbnEditOrders.Text = "檢視";
            this.rbnEditOrders.ToolTip = "檢視全部貨單，或選取的出貨日貨單。";
            this.rbnEditOrders.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnEditOrders.ToolTipTitle = "貨單選擇";
            this.rbnEditOrders.Click += new System.EventHandler(this.rbnEditOrders_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.rckVehicleWeightSplitable);
            this.ribbonPanel4.Items.Add(this.rckWeightSplitable);
            this.ribbonPanel4.Items.Add(this.rtbWeightLimit);
            this.ribbonPanel4.Items.Add(this.rckConstrainted);
            this.ribbonPanel4.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel4.Items.Add(this.rbnCreateModel);
            this.ribbonPanel4.Text = "合車演算";
            // 
            // rckVehicleWeightSplitable
            // 
            this.rckVehicleWeightSplitable.CheckedGroup = "Split";
            this.rckVehicleWeightSplitable.Text = "超全車時可拆單";
            this.rckVehicleWeightSplitable.ToolTip = "貨單裝填時，當重量超過新空車載重上限時候，啟用拆單。該貨單拆成一整車，剩餘者給另一新車。";
            this.rckVehicleWeightSplitable.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rckVehicleWeightSplitable.ToolTipTitle = "啟用拆單選項";
            this.rckVehicleWeightSplitable.CheckBoxCheckChanged += new System.EventHandler(this.rckSplitable_CheckBoxCheckChanged);
            // 
            // rckWeightSplitable
            // 
            this.rckWeightSplitable.CheckedGroup = "Split";
            this.rckWeightSplitable.Text = "超門檻重可拆單";
            this.rckWeightSplitable.ToolTip = "當貨單重超過設定的重限且貨車剩餘容量無法收納貨單時，拆單。拆出貨車剩餘容量塞滿，剩餘重量置入新車。";
            this.rckWeightSplitable.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rckWeightSplitable.ToolTipTitle = "啟用拆單選項";
            this.rckWeightSplitable.CheckBoxCheckChanged += new System.EventHandler(this.rckSplitable_CheckBoxCheckChanged);
            // 
            // rtbWeightLimit
            // 
            this.rtbWeightLimit.Text = "重限";
            this.rtbWeightLimit.TextBoxText = "7500";
            this.rtbWeightLimit.TextBoxWidth = 70;
            this.rtbWeightLimit.ToolTip = "拆單重量限制門檻設定。";
            this.rtbWeightLimit.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rtbWeightLimit.ToolTipTitle = "拆單條件";
            // 
            // rckConstrainted
            // 
            this.rckConstrainted.Text = "啟用車行地區限制";
            this.rckConstrainted.ToolTip = "目前本項限制尚未加入合車作業。";
            this.rckConstrainted.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rckConstrainted.ToolTipTitle = "合車演算前處理";
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Text = "bbbb";
            // 
            // rbnCreateModel
            // 
            this.rbnCreateModel.Image = ((System.Drawing.Image)(resources.GetObject("rbnCreateModel.Image")));
            this.rbnCreateModel.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnCreateModel.SmallImage")));
            this.rbnCreateModel.Text = "確認貨單&貨車";
            this.rbnCreateModel.ToolTip = "貨車啟用與否設定妥當，檢出選定的出貨日或單後確認，以載入合車系統。";
            this.rbnCreateModel.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnCreateModel.ToolTipTitle = "合車演算前處理";
            this.rbnCreateModel.Click += new System.EventHandler(this.rbnCreateModel_Click);
            // 
            // rplSmallExperience
            // 
            this.rplSmallExperience.Enabled = false;
            this.rplSmallExperience.Items.Add(this.rckLargeFirst);
            this.rplSmallExperience.Items.Add(this.rckSmallFirst);
            this.rplSmallExperience.Items.Add(this.ribbonSeparator4);
            this.rplSmallExperience.Items.Add(this.rckGroupOrder);
            this.rplSmallExperience.Items.Add(this.rckGroupReverse);
            this.rplSmallExperience.Items.Add(this.ribbonSeparator5);
            this.rplSmallExperience.Items.Add(this.rbnSmallExperience);
            this.rplSmallExperience.Items.Add(this.rbnEvenExperience);
            this.rplSmallExperience.Text = "經驗法";
            // 
            // rckLargeFirst
            // 
            this.rckLargeFirst.Checked = true;
            this.rckLargeFirst.CheckedGroup = "LargeSmall";
            this.rckLargeFirst.Enabled = false;
            this.rckLargeFirst.Text = "大車優先";
            this.rckLargeFirst.ToolTip = "派車時，由大容量先排。";
            this.rckLargeFirst.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rckLargeFirst.ToolTipTitle = "經驗合車法";
            // 
            // rckSmallFirst
            // 
            this.rckSmallFirst.CheckedGroup = "LargeSmall";
            this.rckSmallFirst.Enabled = false;
            this.rckSmallFirst.Text = "小車優先";
            this.rckSmallFirst.ToolTip = "派車時，由大容量先排。";
            this.rckSmallFirst.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rckSmallFirst.ToolTipTitle = "經驗合車法";
            // 
            // rckGroupOrder
            // 
            this.rckGroupOrder.Checked = true;
            this.rckGroupOrder.CheckedGroup = "GroupFR";
            this.rckGroupOrder.Enabled = false;
            this.rckGroupOrder.Text = "區群順向";
            this.rckGroupOrder.ToolTip = "派車時，由區群別小者先排。";
            this.rckGroupOrder.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rckGroupOrder.ToolTipTitle = "經驗合車法";
            // 
            // rckGroupReverse
            // 
            this.rckGroupReverse.CheckedGroup = "GroupFR";
            this.rckGroupReverse.Enabled = false;
            this.rckGroupReverse.Text = "區群逆向";
            this.rckGroupReverse.ToolTip = "派車時，由區群別大者先排。";
            this.rckGroupReverse.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rckGroupReverse.ToolTipTitle = "經驗合車法";
            // 
            // rbnSmallExperience
            // 
            this.rbnSmallExperience.CheckedGroup = "Methods";
            this.rbnSmallExperience.CheckOnClick = true;
            this.rbnSmallExperience.Enabled = false;
            this.rbnSmallExperience.Image = ((System.Drawing.Image)(resources.GetObject("rbnSmallExperience.Image")));
            this.rbnSmallExperience.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnSmallExperience.SmallImage")));
            this.rbnSmallExperience.Text = "望少車";
            this.rbnSmallExperience.ToolTip = "本派車法先將貨單依照群別、區別排序妥當。再將貨車依照噸位排妥，然後逐一將貨單排入第一部空車，擺不下在開下一輛空車。直到排完貨單或沒有空車為止。";
            this.rbnSmallExperience.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnSmallExperience.ToolTipTitle = "經驗法派車";
            this.rbnSmallExperience.Click += new System.EventHandler(this.rbnSmallExperience_Click);
            // 
            // rbnEvenExperience
            // 
            this.rbnEvenExperience.CheckedGroup = "Methods";
            this.rbnEvenExperience.CheckOnClick = true;
            this.rbnEvenExperience.Enabled = false;
            this.rbnEvenExperience.Image = ((System.Drawing.Image)(resources.GetObject("rbnEvenExperience.Image")));
            this.rbnEvenExperience.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEvenExperience.SmallImage")));
            this.rbnEvenExperience.Text = "望均勻";
            this.rbnEvenExperience.ToolTip = "此法先計算總貨單重量除以總貨車容量，求得每車應裝填的載貨率。用此載貨率作為各車的貨單裝填上限。依照望少車的演算程序，將貨單期能平均上載到各車。";
            this.rbnEvenExperience.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnEvenExperience.ToolTipTitle = "經驗法派車";
            this.rbnEvenExperience.Click += new System.EventHandler(this.rbnEvenExperience_Click);
            // 
            // rplSmallGA
            // 
            this.rplSmallGA.Enabled = false;
            this.rplSmallGA.Items.Add(this.rcbOrders);
            this.rplSmallGA.Items.Add(this.rbnSmallGA);
            this.rplSmallGA.Items.Add(this.rbnSmallNGA);
            this.rplSmallGA.Text = "望少車GA法";
            // 
            // rcbOrders
            // 
            this.rcbOrders.DropDownItems.Add(this.rlbBig);
            this.rcbOrders.DropDownItems.Add(this.rlbSmall);
            this.rcbOrders.DropDownItems.Add(this.rlbAuto);
            this.rcbOrders.Enabled = false;
            this.rcbOrders.Text = "車序";
            this.rcbOrders.TextBoxText = "";
            this.rcbOrders.TextBoxWidth = 70;
            this.rcbOrders.ToolTip = "裝填時空車排序模式選擇。選擇系統優化模式時，GA求解模型會多使用一段排序染色體進行車序變更，求解結果會較其他兩種優先依序者優。";
            this.rcbOrders.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rcbOrders.ToolTipTitle = "GA 演算派車望少車法";
            this.rcbOrders.TextBoxTextChanged += new System.EventHandler(this.rcbOrders_TextBoxTextChanged);
            // 
            // rlbBig
            // 
            this.rlbBig.Text = "大車優先";
            // 
            // rlbSmall
            // 
            this.rlbSmall.Text = "小車優先";
            // 
            // rlbAuto
            // 
            this.rlbAuto.Text = "系統優化";
            // 
            // rbnSmallGA
            // 
            this.rbnSmallGA.CheckedGroup = "Methods";
            this.rbnSmallGA.CheckOnClick = true;
            this.rbnSmallGA.Enabled = false;
            this.rbnSmallGA.Image = ((System.Drawing.Image)(resources.GetObject("rbnSmallGA.Image")));
            this.rbnSmallGA.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnSmallGA.SmallImage")));
            this.rbnSmallGA.Text = "單段排序編碼";
            this.rbnSmallGA.ToolTip = "本法將所有貨單視為一大群，使用一段排序編碼染色體，規劃各個貨單的裝載順序。裝填時先從大容量貨車開始，當滿載時再依序開啟新的空車。";
            this.rbnSmallGA.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnSmallGA.ToolTipTitle = "GA 演算派車望少車法";
            this.rbnSmallGA.Click += new System.EventHandler(this.rbnSmallGA_Click);
            // 
            // rbnSmallNGA
            // 
            this.rbnSmallNGA.CheckedGroup = "Methods";
            this.rbnSmallNGA.CheckOnClick = true;
            this.rbnSmallNGA.Enabled = false;
            this.rbnSmallNGA.Image = ((System.Drawing.Image)(resources.GetObject("rbnSmallNGA.Image")));
            this.rbnSmallNGA.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnSmallNGA.SmallImage")));
            this.rbnSmallNGA.Text = "多段排序編碼";
            this.rbnSmallNGA.ToolTip = "本法將貨單依照群別分組，各組使用一段排序染色體編碼，規劃各組內各個貨單的裝填順序。裝填時由最大容量的貨車開始，裝不下時依序開啟空車。";
            this.rbnSmallNGA.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnSmallNGA.ToolTipTitle = "GA 演算派車望少車法";
            this.rbnSmallNGA.Click += new System.EventHandler(this.rbnSmallNGA_Click);
            // 
            // rplEvenGA
            // 
            this.rplEvenGA.Enabled = false;
            this.rplEvenGA.Items.Add(this.rbnEvenGA);
            this.rplEvenGA.Text = "望均勻GA法";
            // 
            // rbnEvenGA
            // 
            this.rbnEvenGA.CheckedGroup = "Methods";
            this.rbnEvenGA.CheckOnClick = true;
            this.rbnEvenGA.Enabled = false;
            this.rbnEvenGA.Image = ((System.Drawing.Image)(resources.GetObject("rbnEvenGA.Image")));
            this.rbnEvenGA.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbnEvenGA.SmallImage")));
            this.rbnEvenGA.Text = "單段群組編碼";
            this.rbnEvenGA.ToolTip = "此法將貨單均勻分配到各車，期使各車裝車結果裝載率的標準差最小。使用一段的分群整數編碼染色體，依基因值代表的車別，將貨單依序裝入。";
            this.rbnEvenGA.ToolTipImage = global::VehiclePackingSystem.Properties.Resources.calabx24;
            this.rbnEvenGA.ToolTipTitle = "GA 演算派車望均勻法";
            this.rbnEvenGA.Click += new System.EventHandler(this.rbnEvenGA_Click);
            // 
            // rtbAbout
            // 
            this.rtbAbout.Panels.Add(this.ribbonPanel6);
            this.rtbAbout.Text = "About 關於";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            // 
            // spcPacking
            // 
            this.spcPacking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPacking.Location = new System.Drawing.Point(0, 117);
            this.spcPacking.Name = "spcPacking";
            // 
            // spcPacking.Panel1
            // 
            this.spcPacking.Panel1.AutoScroll = true;
            this.spcPacking.Panel1.Controls.Add(this.spcOrderNVehicle);
            // 
            // spcPacking.Panel2
            // 
            this.spcPacking.Panel2.Controls.Add(this.spcChartNGA);
            this.spcPacking.Size = new System.Drawing.Size(1286, 608);
            this.spcPacking.SplitterDistance = 173;
            this.spcPacking.TabIndex = 2;
            // 
            // spcOrderNVehicle
            // 
            this.spcOrderNVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcOrderNVehicle.Location = new System.Drawing.Point(0, 0);
            this.spcOrderNVehicle.Name = "spcOrderNVehicle";
            this.spcOrderNVehicle.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcOrderNVehicle.Panel1
            // 
            this.spcOrderNVehicle.Panel1.Controls.Add(this.spcVehicle);
            this.spcOrderNVehicle.Panel1.Controls.Add(this.labVehicle);
            // 
            // spcOrderNVehicle.Panel2
            // 
            this.spcOrderNVehicle.Panel2.Controls.Add(this.labOrders);
            this.spcOrderNVehicle.Panel2.Controls.Add(this.dgvOrders);
            this.spcOrderNVehicle.Size = new System.Drawing.Size(173, 608);
            this.spcOrderNVehicle.SplitterDistance = 392;
            this.spcOrderNVehicle.TabIndex = 0;
            // 
            // spcVehicle
            // 
            this.spcVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcVehicle.Location = new System.Drawing.Point(0, 23);
            this.spcVehicle.Name = "spcVehicle";
            this.spcVehicle.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcVehicle.Panel1
            // 
            this.spcVehicle.Panel1.Controls.Add(this.dgvVehicles);
            // 
            // spcVehicle.Panel2
            // 
            this.spcVehicle.Panel2.Controls.Add(this.pgdVehicleInfo);
            this.spcVehicle.Size = new System.Drawing.Size(173, 369);
            this.spcVehicle.SplitterDistance = 213;
            this.spcVehicle.TabIndex = 7;
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Location = new System.Drawing.Point(3, 3);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.RowTemplate.Height = 24;
            this.dgvVehicles.Size = new System.Drawing.Size(167, 207);
            this.dgvVehicles.TabIndex = 0;
            this.tipTool.SetToolTip(this.dgvVehicles, "貨車清單。");
            this.dgvVehicles.SelectionChanged += new System.EventHandler(this.dgvVehicles_SelectionChanged);
            // 
            // pgdVehicleInfo
            // 
            this.pgdVehicleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgdVehicleInfo.Location = new System.Drawing.Point(3, 3);
            this.pgdVehicleInfo.Name = "pgdVehicleInfo";
            this.pgdVehicleInfo.Size = new System.Drawing.Size(167, 146);
            this.pgdVehicleInfo.TabIndex = 6;
            this.tipTool.SetToolTip(this.pgdVehicleInfo, "合車結果細節展示介面。");
            // 
            // labVehicle
            // 
            this.labVehicle.BackColor = System.Drawing.Color.Purple;
            this.labVehicle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labVehicle.ForeColor = System.Drawing.Color.White;
            this.labVehicle.Location = new System.Drawing.Point(0, 0);
            this.labVehicle.Name = "labVehicle";
            this.labVehicle.Size = new System.Drawing.Size(173, 23);
            this.labVehicle.TabIndex = 1;
            this.labVehicle.Text = "貨車";
            this.labVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labOrders
            // 
            this.labOrders.BackColor = System.Drawing.Color.Teal;
            this.labOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.labOrders.ForeColor = System.Drawing.Color.White;
            this.labOrders.Location = new System.Drawing.Point(0, 0);
            this.labOrders.Name = "labOrders";
            this.labOrders.Size = new System.Drawing.Size(173, 23);
            this.labOrders.TabIndex = 2;
            this.labOrders.Text = "貨單";
            this.labOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvOrders
            // 
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(3, 26);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.Size = new System.Drawing.Size(167, 183);
            this.dgvOrders.TabIndex = 1;
            this.tipTool.SetToolTip(this.dgvOrders, "貨單細目，粉底表示有拆單；黑底表示沒有排入；深紅底表示有拆單且部分沒有排入。");
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // spcChartNGA
            // 
            this.spcChartNGA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcChartNGA.Location = new System.Drawing.Point(0, 0);
            this.spcChartNGA.Name = "spcChartNGA";
            // 
            // spcChartNGA.Panel1
            // 
            this.spcChartNGA.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.spcChartNGA.Panel1.Controls.Add(this.spcResults);
            // 
            // spcChartNGA.Panel2
            // 
            this.spcChartNGA.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spcChartNGA.Panel2.Controls.Add(this.spcGACmdProp);
            this.spcChartNGA.Size = new System.Drawing.Size(1109, 608);
            this.spcChartNGA.SplitterDistance = 844;
            this.spcChartNGA.TabIndex = 0;
            // 
            // spcResults
            // 
            this.spcResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcResults.Location = new System.Drawing.Point(0, 0);
            this.spcResults.Name = "spcResults";
            this.spcResults.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcResults.Panel1
            // 
            this.spcResults.Panel1.Controls.Add(this.spcResultLabels);
            this.spcResults.Panel1.Controls.Add(this.label1);
            // 
            // spcResults.Panel2
            // 
            this.spcResults.Panel2.Controls.Add(this.chtPackingResults);
            this.spcResults.Size = new System.Drawing.Size(844, 608);
            this.spcResults.SplitterDistance = 135;
            this.spcResults.TabIndex = 1;
            // 
            // spcResultLabels
            // 
            this.spcResultLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcResultLabels.Location = new System.Drawing.Point(0, 24);
            this.spcResultLabels.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.spcResultLabels.Name = "spcResultLabels";
            // 
            // spcResultLabels.Panel1
            // 
            this.spcResultLabels.Panel1.Controls.Add(this.labResultsLeft);
            // 
            // spcResultLabels.Panel2
            // 
            this.spcResultLabels.Panel2.Controls.Add(this.labResultsRight);
            this.spcResultLabels.Size = new System.Drawing.Size(844, 111);
            this.spcResultLabels.SplitterDistance = 427;
            this.spcResultLabels.TabIndex = 5;
            // 
            // labResultsLeft
            // 
            this.labResultsLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labResultsLeft.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labResultsLeft.ForeColor = System.Drawing.Color.Maroon;
            this.labResultsLeft.Location = new System.Drawing.Point(0, 0);
            this.labResultsLeft.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labResultsLeft.Name = "labResultsLeft";
            this.labResultsLeft.Size = new System.Drawing.Size(427, 111);
            this.labResultsLeft.TabIndex = 3;
            // 
            // labResultsRight
            // 
            this.labResultsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labResultsRight.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labResultsRight.ForeColor = System.Drawing.Color.Maroon;
            this.labResultsRight.Location = new System.Drawing.Point(0, 0);
            this.labResultsRight.Name = "labResultsRight";
            this.labResultsRight.Size = new System.Drawing.Size(413, 111);
            this.labResultsRight.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(844, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "派車結果";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chtPackingResults
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.Title = "貨車";
            chartArea1.AxisY.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.Title = "載重 (kg)";
            chartArea1.Name = "ChartArea1";
            this.chtPackingResults.ChartAreas.Add(chartArea1);
            this.chtPackingResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtPackingResults.Location = new System.Drawing.Point(0, 0);
            this.chtPackingResults.Name = "chtPackingResults";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chtPackingResults.Series.Add(series1);
            this.chtPackingResults.Size = new System.Drawing.Size(844, 469);
            this.chtPackingResults.TabIndex = 0;
            this.chtPackingResults.Text = "chart1";
            this.tipTool.SetToolTip(this.chtPackingResults, "最終派車結果，點押區塊指示貨單細節，點押車牌展示合車結果。");
            this.chtPackingResults.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chtPackingResults_MouseClick);
            // 
            // spcGACmdProp
            // 
            this.spcGACmdProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcGACmdProp.Enabled = false;
            this.spcGACmdProp.Location = new System.Drawing.Point(0, 0);
            this.spcGACmdProp.Name = "spcGACmdProp";
            this.spcGACmdProp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcGACmdProp.Panel1
            // 
            this.spcGACmdProp.Panel1.Controls.Add(this.tabGAParameters);
            this.spcGACmdProp.Panel1.Controls.Add(this.labGAParameter);
            // 
            // spcGACmdProp.Panel2
            // 
            this.spcGACmdProp.Panel2.Controls.Add(this.spcGA);
            this.spcGACmdProp.Size = new System.Drawing.Size(261, 608);
            this.spcGACmdProp.SplitterDistance = 273;
            this.spcGACmdProp.TabIndex = 0;
            // 
            // tabGAParameters
            // 
            this.tabGAParameters.Controls.Add(this.pagSolver);
            this.tabGAParameters.Controls.Add(this.tabPage2);
            this.tabGAParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGAParameters.Location = new System.Drawing.Point(0, 23);
            this.tabGAParameters.Name = "tabGAParameters";
            this.tabGAParameters.SelectedIndex = 0;
            this.tabGAParameters.Size = new System.Drawing.Size(261, 250);
            this.tabGAParameters.TabIndex = 5;
            // 
            // pagSolver
            // 
            this.pagSolver.Controls.Add(this.pgdGAProperty);
            this.pagSolver.Location = new System.Drawing.Point(4, 25);
            this.pagSolver.Name = "pagSolver";
            this.pagSolver.Padding = new System.Windows.Forms.Padding(3);
            this.pagSolver.Size = new System.Drawing.Size(253, 221);
            this.pagSolver.TabIndex = 0;
            this.pagSolver.Text = "GA Solver";
            this.pagSolver.UseVisualStyleBackColor = true;
            // 
            // pgdGAProperty
            // 
            this.pgdGAProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgdGAProperty.Location = new System.Drawing.Point(6, 6);
            this.pgdGAProperty.Name = "pgdGAProperty";
            this.pgdGAProperty.Size = new System.Drawing.Size(241, 209);
            this.pgdGAProperty.TabIndex = 0;
            this.tipTool.SetToolTip(this.pgdGAProperty, "基因演化派車系統的參數設定介面。");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pgdSolver);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(253, 224);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "目標函數";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pgdSolver
            // 
            this.pgdSolver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgdSolver.Location = new System.Drawing.Point(6, 6);
            this.pgdSolver.Name = "pgdSolver";
            this.pgdSolver.Size = new System.Drawing.Size(241, 215);
            this.pgdSolver.TabIndex = 4;
            this.tipTool.SetToolTip(this.pgdSolver, "本派車系統演化使用的目標函數權值和懲罰值設定介面。");
            // 
            // labGAParameter
            // 
            this.labGAParameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labGAParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.labGAParameter.ForeColor = System.Drawing.Color.White;
            this.labGAParameter.Location = new System.Drawing.Point(0, 0);
            this.labGAParameter.Name = "labGAParameter";
            this.labGAParameter.Size = new System.Drawing.Size(261, 23);
            this.labGAParameter.TabIndex = 3;
            this.labGAParameter.Text = "GA 參數設定";
            this.labGAParameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spcGA
            // 
            this.spcGA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcGA.Location = new System.Drawing.Point(0, 0);
            this.spcGA.Name = "spcGA";
            this.spcGA.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcGA.Panel1
            // 
            this.spcGA.Panel1.Controls.Add(this.btnRunToEnd);
            this.spcGA.Panel1.Controls.Add(this.btnRunOneIteration);
            this.spcGA.Panel1.Controls.Add(this.btnReset);
            // 
            // spcGA.Panel2
            // 
            this.spcGA.Panel2.Controls.Add(this.chtGA);
            this.spcGA.Size = new System.Drawing.Size(261, 331);
            this.spcGA.SplitterDistance = 90;
            this.spcGA.TabIndex = 0;
            // 
            // btnRunToEnd
            // 
            this.btnRunToEnd.Enabled = false;
            this.btnRunToEnd.Location = new System.Drawing.Point(5, 55);
            this.btnRunToEnd.Name = "btnRunToEnd";
            this.btnRunToEnd.Size = new System.Drawing.Size(134, 23);
            this.btnRunToEnd.TabIndex = 2;
            this.btnRunToEnd.Text = "Run to End";
            this.tipTool.SetToolTip(this.btnRunToEnd, "執行演化直到停止條件吻合為止。");
            this.btnRunToEnd.UseVisualStyleBackColor = true;
            this.btnRunToEnd.Click += new System.EventHandler(this.btnRunToEnd_Click);
            // 
            // btnRunOneIteration
            // 
            this.btnRunOneIteration.Enabled = false;
            this.btnRunOneIteration.Location = new System.Drawing.Point(5, 30);
            this.btnRunOneIteration.Name = "btnRunOneIteration";
            this.btnRunOneIteration.Size = new System.Drawing.Size(134, 23);
            this.btnRunOneIteration.TabIndex = 1;
            this.btnRunOneIteration.Text = "Run One Iteration";
            this.tipTool.SetToolTip(this.btnRunOneIteration, "執行一個代次的最佳派車演化。");
            this.btnRunOneIteration.UseVisualStyleBackColor = true;
            this.btnRunOneIteration.Click += new System.EventHandler(this.btnRunOneIteration_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(5, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(134, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset GA";
            this.tipTool.SetToolTip(this.btnReset, "變更 GA 參數後，重設基因演算需要的資料和記憶體。");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chtGA
            // 
            this.chtGA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.Title = "Iteration";
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.Title = "Objective Value";
            chartArea2.Name = "ChartArea1";
            this.chtGA.ChartAreas.Add(chartArea2);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend1";
            this.chtGA.Legends.Add(legend1);
            this.chtGA.Location = new System.Drawing.Point(5, 5);
            this.chtGA.Name = "chtGA";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.LimeGreen;
            series2.Legend = "Legend1";
            series2.Name = "Average";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.Name = "Iteration Best";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "So Far the Best";
            this.chtGA.Series.Add(series2);
            this.chtGA.Series.Add(series3);
            this.chtGA.Series.Add(series4);
            this.chtGA.Size = new System.Drawing.Size(253, 229);
            this.chtGA.TabIndex = 0;
            this.chtGA.Text = "chart1";
            this.tipTool.SetToolTip(this.chtGA, "基因演算過程冒標函數值變化過程。");
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Checked = true;
            this.ribbonButton4.CheckOnClick = true;
            this.ribbonButton4.FlashEnabled = true;
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "GA min Vehicle Number";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Checked = true;
            this.ribbonButton5.CheckOnClick = true;
            this.ribbonButton5.FlashEnabled = true;
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.ShowFlashImage = true;
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "GA min Vehicle Number";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Areas";
            // 
            // datePicker
            // 
            this.datePicker.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.datePicker.Location = new System.Drawing.Point(1077, 28);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(116, 23);
            this.datePicker.TabIndex = 3;
            this.datePicker.Visible = false;
            this.datePicker.CloseUp += new System.EventHandler(this.datePicker_CloseUp);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labMessage,
            this.barProgress});
            this.statusBar.Location = new System.Drawing.Point(0, 725);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1286, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusStrip1";
            // 
            // labMessage
            // 
            this.labMessage.ForeColor = System.Drawing.Color.Purple;
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(1069, 17);
            this.labMessage.Spring = true;
            // 
            // barProgress
            // 
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(200, 16);
            // 
            // tipTool
            // 
            this.tipTool.IsBalloon = true;
            this.tipTool.ShowAlways = true;
            this.tipTool.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipTool.ToolTipTitle = "說明";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.rpnOrdersVehicles);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "中區合車系統";
            // 
            // rpnOrdersVehicles
            // 
            this.rpnOrdersVehicles.Items.Add(this.ribbonButton8);
            this.rpnOrdersVehicles.Items.Add(this.ribbonButton9);
            this.rpnOrdersVehicles.Text = "貨單和貨車設定";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonButton7);
            this.ribbonPanel2.Items.Add(this.ribbonButton11);
            this.ribbonPanel2.Items.Add(this.ribbonButton12);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator3);
            this.ribbonPanel2.Items.Add(this.ribbonButton6);
            this.ribbonPanel2.Text = "合車";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "參數法則選項";
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.Image")));
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "執行合車";
            // 
            // ribbonButton8
            // 
            this.ribbonButton8.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.Image")));
            this.ribbonButton8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.SmallImage")));
            this.ribbonButton8.Text = "開啟貨單檔案";
            // 
            // ribbonButton9
            // 
            this.ribbonButton9.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton9.Image")));
            this.ribbonButton9.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton9.SmallImage")));
            this.ribbonButton9.Text = "選定可用貨車";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.rtbGAPanelShowHide);
            this.ribbonPanel6.Text = "演算細節";
            // 
            // rtbGAPanelShowHide
            // 
            this.rtbGAPanelShowHide.Image = ((System.Drawing.Image)(resources.GetObject("rtbGAPanelShowHide.Image")));
            this.rtbGAPanelShowHide.SmallImage = ((System.Drawing.Image)(resources.GetObject("rtbGAPanelShowHide.SmallImage")));
            this.rtbGAPanelShowHide.Text = "藏現GA視窗";
            this.rtbGAPanelShowHide.Click += new System.EventHandler(this.rtbGAPanelShowHide_Click);
            // 
            // ribbonButton11
            // 
            this.ribbonButton11.Enabled = false;
            this.ribbonButton11.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton11.Image")));
            this.ribbonButton11.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton11.SmallImage")));
            this.ribbonButton11.Text = "行車報表列印";
            // 
            // ribbonButton12
            // 
            this.ribbonButton12.Enabled = false;
            this.ribbonButton12.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton12.Image")));
            this.ribbonButton12.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton12.SmallImage")));
            this.ribbonButton12.Text = "結果會回SAP";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 747);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.spcPacking);
            this.Controls.Add(this.ribbonMain);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Packing Demo System 合車演算示範系統";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.spcPacking.Panel1.ResumeLayout(false);
            this.spcPacking.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPacking)).EndInit();
            this.spcPacking.ResumeLayout(false);
            this.spcOrderNVehicle.Panel1.ResumeLayout(false);
            this.spcOrderNVehicle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcOrderNVehicle)).EndInit();
            this.spcOrderNVehicle.ResumeLayout(false);
            this.spcVehicle.Panel1.ResumeLayout(false);
            this.spcVehicle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcVehicle)).EndInit();
            this.spcVehicle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.spcChartNGA.Panel1.ResumeLayout(false);
            this.spcChartNGA.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcChartNGA)).EndInit();
            this.spcChartNGA.ResumeLayout(false);
            this.spcResults.Panel1.ResumeLayout(false);
            this.spcResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcResults)).EndInit();
            this.spcResults.ResumeLayout(false);
            this.spcResultLabels.Panel1.ResumeLayout(false);
            this.spcResultLabels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcResultLabels)).EndInit();
            this.spcResultLabels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtPackingResults)).EndInit();
            this.spcGACmdProp.Panel1.ResumeLayout(false);
            this.spcGACmdProp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcGACmdProp)).EndInit();
            this.spcGACmdProp.ResumeLayout(false);
            this.tabGAParameters.ResumeLayout(false);
            this.pagSolver.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.spcGA.Panel1.ResumeLayout(false);
            this.spcGA.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcGA)).EndInit();
            this.spcGA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtGA)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbonMain;
        private System.Windows.Forms.RibbonTab rtbConfiguration;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbnEditModels;
        private System.Windows.Forms.RibbonPanel rplAreasAndVehicles;
        private System.Windows.Forms.RibbonButton rbnEditAreas;
        private System.Windows.Forms.RibbonTab rtbPacking;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rbnEditOrders;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonTab rtbAbout;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.SplitContainer spcPacking;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton rbnAddRow;
        private System.Windows.Forms.RibbonButton rbnEditOwners;
        private System.Windows.Forms.RibbonButton rbnEditVehicle;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonCheckBox rcbAll;
        private System.Windows.Forms.RibbonCheckBox rcbDeliveryDate;
        private System.Windows.Forms.RibbonTextBox rtbDate;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel labMessage;
        private System.Windows.Forms.ToolStripProgressBar barProgress;
        private System.Windows.Forms.RibbonCheckBox rckConstrainted;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton rbnEvenExperience;
        private System.Windows.Forms.RibbonButton rbnEvenGA;
        private System.Windows.Forms.RibbonButton rbnSmallGA;
        private System.Windows.Forms.RibbonButton rbnCreateModel;
        private System.Windows.Forms.SplitContainer spcOrderNVehicle;
        private System.Windows.Forms.SplitContainer spcChartNGA;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtPackingResults;
        private System.Windows.Forms.SplitContainer spcGA;
        private System.Windows.Forms.SplitContainer spcGACmdProp;
        private System.Windows.Forms.PropertyGrid pgdGAProperty;
        private System.Windows.Forms.Button btnRunToEnd;
        private System.Windows.Forms.Button btnRunOneIteration;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtGA;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label labVehicle;
        private System.Windows.Forms.Label labOrders;
        private System.Windows.Forms.SplitContainer spcResults;
        private System.Windows.Forms.Label labResultsLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RibbonCheckBox rckLargeFirst;
        private System.Windows.Forms.RibbonCheckBox rckSmallFirst;
        private System.Windows.Forms.RibbonCheckBox rckGroupOrder;
        private System.Windows.Forms.RibbonCheckBox rckGroupReverse;
        private System.Windows.Forms.RibbonPanel rplSmallExperience;
        private System.Windows.Forms.RibbonButton rbnSmallExperience;
        //private System.Windows.Forms.RibbonPanel rplEvenExperience;
        private System.Windows.Forms.RibbonPanel rplSmallGA;
        private System.Windows.Forms.RibbonPanel rplEvenGA;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator5;
        private System.Windows.Forms.RibbonCheckBox rckVehicleWeightSplitable;
        private System.Windows.Forms.PropertyGrid pgdSolver;
        private System.Windows.Forms.Label labGAParameter;
        private System.Windows.Forms.TabControl tabGAParameters;
        private System.Windows.Forms.TabPage pagSolver;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer spcResultLabels;
        private System.Windows.Forms.Label labResultsRight;
        private System.Windows.Forms.SplitContainer spcVehicle;
        private System.Windows.Forms.PropertyGrid pgdVehicleInfo;
        private System.Windows.Forms.RibbonButton rbnSmallNGA;
        private System.Windows.Forms.RibbonCheckBox rckWeightSplitable;
        private System.Windows.Forms.RibbonTextBox rtbWeightLimit;
        private System.Windows.Forms.ToolTip tipTool;
        private System.Windows.Forms.RibbonComboBox rcbOrders;
        private System.Windows.Forms.RibbonLabel rlbBig;
        private System.Windows.Forms.RibbonLabel rlbSmall;
        private System.Windows.Forms.RibbonLabel rlbAuto;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel rpnOrdersVehicles;
        private System.Windows.Forms.RibbonButton ribbonButton8;
        private System.Windows.Forms.RibbonButton ribbonButton9;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton rtbGAPanelShowHide;
        private System.Windows.Forms.RibbonButton ribbonButton11;
        private System.Windows.Forms.RibbonButton ribbonButton12;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
    }
}

