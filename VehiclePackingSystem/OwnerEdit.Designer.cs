namespace VehiclePackingSystem
{
    partial class OwnerEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerEdit));
            this.vehiclePackingDataSet = new VehiclePackingSystem.VehiclePackingDataSet();
            this.vehicleOwnerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vehicleOwnerTableAdapter = new VehiclePackingSystem.VehiclePackingDataSetTableAdapters.VehicleOwnerTableAdapter();
            this.tableAdapterManager = new VehiclePackingSystem.VehiclePackingDataSetTableAdapters.TableAdapterManager();
            this.vehicleOwnerBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.vehicleOwnerBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.vehicleOwnerDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclePackingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleOwnerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleOwnerBindingNavigator)).BeginInit();
            this.vehicleOwnerBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleOwnerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // vehiclePackingDataSet
            // 
            this.vehiclePackingDataSet.DataSetName = "VehiclePackingDataSet";
            this.vehiclePackingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vehicleOwnerBindingSource
            // 
            this.vehicleOwnerBindingSource.DataMember = "VehicleOwner";
            this.vehicleOwnerBindingSource.DataSource = this.vehiclePackingDataSet;
            // 
            // vehicleOwnerTableAdapter
            // 
            this.vehicleOwnerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AreaTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ModelTableAdapter = null;
            this.tableAdapterManager.OrdersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = VehiclePackingSystem.VehiclePackingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VehicleAreaTableAdapter = null;
            this.tableAdapterManager.VehicleOwnerTableAdapter = this.vehicleOwnerTableAdapter;
            this.tableAdapterManager.VehicleTableAdapter = null;
            // 
            // vehicleOwnerBindingNavigator
            // 
            this.vehicleOwnerBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.vehicleOwnerBindingNavigator.BindingSource = this.vehicleOwnerBindingSource;
            this.vehicleOwnerBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.vehicleOwnerBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.vehicleOwnerBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.vehicleOwnerBindingNavigatorSaveItem});
            this.vehicleOwnerBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.vehicleOwnerBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.vehicleOwnerBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.vehicleOwnerBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.vehicleOwnerBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.vehicleOwnerBindingNavigator.Name = "vehicleOwnerBindingNavigator";
            this.vehicleOwnerBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.vehicleOwnerBindingNavigator.Size = new System.Drawing.Size(288, 25);
            this.vehicleOwnerBindingNavigator.TabIndex = 0;
            this.vehicleOwnerBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // vehicleOwnerBindingNavigatorSaveItem
            // 
            this.vehicleOwnerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vehicleOwnerBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("vehicleOwnerBindingNavigatorSaveItem.Image")));
            this.vehicleOwnerBindingNavigatorSaveItem.Name = "vehicleOwnerBindingNavigatorSaveItem";
            this.vehicleOwnerBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.vehicleOwnerBindingNavigatorSaveItem.Text = "儲存資料";
            this.vehicleOwnerBindingNavigatorSaveItem.Click += new System.EventHandler(this.vehicleOwnerBindingNavigatorSaveItem_Click);
            // 
            // vehicleOwnerDataGridView
            // 
            this.vehicleOwnerDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vehicleOwnerDataGridView.AutoGenerateColumns = false;
            this.vehicleOwnerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehicleOwnerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.vehicleOwnerDataGridView.DataSource = this.vehicleOwnerBindingSource;
            this.vehicleOwnerDataGridView.Location = new System.Drawing.Point(7, 29);
            this.vehicleOwnerDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.vehicleOwnerDataGridView.Name = "vehicleOwnerDataGridView";
            this.vehicleOwnerDataGridView.RowHeadersWidth = 50;
            this.vehicleOwnerDataGridView.RowTemplate.Height = 24;
            this.vehicleOwnerDataGridView.Size = new System.Drawing.Size(275, 232);
            this.vehicleOwnerDataGridView.TabIndex = 1;
            this.vehicleOwnerDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.vehicleOwnerDataGridView_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ownerTitle";
            this.dataGridViewTextBoxColumn2.HeaderText = "貨運承攬業者名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // OwnerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 265);
            this.Controls.Add(this.vehicleOwnerDataGridView);
            this.Controls.Add(this.vehicleOwnerBindingNavigator);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OwnerEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "貨運承攬業者設定";
            this.Load += new System.EventHandler(this.OwnerEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vehiclePackingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleOwnerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleOwnerBindingNavigator)).EndInit();
            this.vehicleOwnerBindingNavigator.ResumeLayout(false);
            this.vehicleOwnerBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleOwnerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VehiclePackingDataSet vehiclePackingDataSet;
        private System.Windows.Forms.BindingSource vehicleOwnerBindingSource;
        private VehiclePackingDataSetTableAdapters.VehicleOwnerTableAdapter vehicleOwnerTableAdapter;
        private VehiclePackingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator vehicleOwnerBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton vehicleOwnerBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView vehicleOwnerDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}