namespace Clinic
{
    partial class Services
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Services));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonServicesOK = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.CoTableLayoutPanel7 = new Clinic.CoTableLayoutPanel();
            this.lblNewIdService = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.textBoxServices = new System.Windows.Forms.TextBox();
            this.textBoxServicesCost = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.textBoxAdminOfService = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.CoTableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnCostOut,
            this.ColumnAdmin,
            this.ColumnUpdate,
            this.ColumnDelete});
            this.dataGridView1.Location = new System.Drawing.Point(0, 175);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1184, 566);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Tên dịch vụ";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 250;
            // 
            // ColumnCostOut
            // 
            this.ColumnCostOut.HeaderText = "Giá";
            this.ColumnCostOut.Name = "ColumnCostOut";
            this.ColumnCostOut.Width = 150;
            // 
            // ColumnAdmin
            // 
            this.ColumnAdmin.HeaderText = "Người phụ trách";
            this.ColumnAdmin.Name = "ColumnAdmin";
            this.ColumnAdmin.Width = 200;
            // 
            // ColumnUpdate
            // 
            this.ColumnUpdate.HeaderText = "Cập Nhật";
            this.ColumnUpdate.Name = "ColumnUpdate";
            this.ColumnUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.HeaderText = "Xóa";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonServicesOK
            // 
            this.buttonServicesOK.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonServicesOK.Location = new System.Drawing.Point(878, 15);
            this.buttonServicesOK.Name = "buttonServicesOK";
            this.buttonServicesOK.Size = new System.Drawing.Size(170, 50);
            this.buttonServicesOK.TabIndex = 27;
            this.buttonServicesOK.Text = "OK/ Cập Nhật";
            this.buttonServicesOK.UseVisualStyleBackColor = false;
            this.buttonServicesOK.Click += new System.EventHandler(this.buttonServicesOK_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Salmon;
            this.buttonClear.Location = new System.Drawing.Point(878, 85);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(170, 48);
            this.buttonClear.TabIndex = 28;
            this.buttonClear.Text = "Cancel";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // CoTableLayoutPanel7
            // 
            this.CoTableLayoutPanel7.BackColor = System.Drawing.Color.LightGray;
            this.CoTableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.CoTableLayoutPanel7.ColumnCount = 2;
            this.CoTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.59006F));
            this.CoTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.40993F));
            this.CoTableLayoutPanel7.Controls.Add(this.lblNewIdService, 1, 0);
            this.CoTableLayoutPanel7.Controls.Add(this.label41, 0, 1);
            this.CoTableLayoutPanel7.Controls.Add(this.label42, 0, 2);
            this.CoTableLayoutPanel7.Controls.Add(this.textBoxServices, 1, 1);
            this.CoTableLayoutPanel7.Controls.Add(this.textBoxServicesCost, 1, 2);
            this.CoTableLayoutPanel7.Controls.Add(this.label43, 0, 0);
            this.CoTableLayoutPanel7.Controls.Add(this.label48, 0, 3);
            this.CoTableLayoutPanel7.Controls.Add(this.textBoxAdminOfService, 1, 3);
            this.CoTableLayoutPanel7.Location = new System.Drawing.Point(12, 12);
            this.CoTableLayoutPanel7.Name = "CoTableLayoutPanel7";
            this.CoTableLayoutPanel7.RowCount = 4;
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.CoTableLayoutPanel7.Size = new System.Drawing.Size(808, 117);
            this.CoTableLayoutPanel7.TabIndex = 27;
            // 
            // lblNewIdService
            // 
            this.lblNewIdService.AutoSize = true;
            this.lblNewIdService.Location = new System.Drawing.Point(213, 3);
            this.lblNewIdService.Name = "lblNewIdService";
            this.lblNewIdService.Size = new System.Drawing.Size(41, 13);
            this.lblNewIdService.TabIndex = 18;
            this.lblNewIdService.Text = "label44";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 26);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(70, 13);
            this.label41.TabIndex = 0;
            this.label41.Text = "Tên Dịch Vụ:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 56);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(26, 13);
            this.label42.TabIndex = 1;
            this.label42.Text = "Giá:";
            // 
            // textBoxServices
            // 
            this.textBoxServices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxServices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxServices.Location = new System.Drawing.Point(213, 29);
            this.textBoxServices.Name = "textBoxServices";
            this.textBoxServices.Size = new System.Drawing.Size(589, 20);
            this.textBoxServices.TabIndex = 2;
            this.textBoxServices.Text = "@";
            // 
            // textBoxServicesCost
            // 
            this.textBoxServicesCost.Location = new System.Drawing.Point(213, 59);
            this.textBoxServicesCost.Name = "textBoxServicesCost";
            this.textBoxServicesCost.Size = new System.Drawing.Size(589, 20);
            this.textBoxServicesCost.TabIndex = 3;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 3);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(21, 13);
            this.label43.TabIndex = 4;
            this.label43.Text = "ID:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 86);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(125, 13);
            this.label48.TabIndex = 19;
            this.label48.Text = "Người phụ trách(nếu có):";
            // 
            // textBoxAdminOfService
            // 
            this.textBoxAdminOfService.Location = new System.Drawing.Point(213, 89);
            this.textBoxAdminOfService.Name = "textBoxAdminOfService";
            this.textBoxAdminOfService.Size = new System.Drawing.Size(589, 20);
            this.textBoxAdminOfService.TabIndex = 20;
            // 
            // Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 741);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.CoTableLayoutPanel7);
            this.Controls.Add(this.buttonServicesOK);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Services";
            this.Text = "Các dịch vụ đang có";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Services_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.CoTableLayoutPanel7.ResumeLayout(false);
            this.CoTableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdmin;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnUpdate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
        private CoTableLayoutPanel CoTableLayoutPanel7;
        private System.Windows.Forms.Label lblNewIdService;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox textBoxServices;
        private System.Windows.Forms.TextBox textBoxServicesCost;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox textBoxAdminOfService;
        private System.Windows.Forms.Button buttonServicesOK;
        private System.Windows.Forms.Button buttonClear;
    }
}