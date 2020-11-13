namespace Clinic.Thong_Ke
{
    partial class DiagnosesHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagnosesHistory));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columncheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_delete = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.coTableLayoutPanel1 = new Clinic.CoTableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.coTableLayoutPanel1.SuspendLayout();
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
            this.columncheckbox,
            this.ID,
            this.ColumnName,
            this.ColumnUpdate});
            this.dataGridView1.Location = new System.Drawing.Point(12, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(948, 526);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // columncheckbox
            // 
            this.columncheckbox.HeaderText = "";
            this.columncheckbox.Name = "columncheckbox";
            this.columncheckbox.Width = 30;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Tên Chẩn Đoán";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnUpdate
            // 
            this.ColumnUpdate.HeaderText = "Cập nhật";
            this.ColumnUpdate.Name = "ColumnUpdate";
            this.ColumnUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btn_delete
            // 
            this.btn_delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_delete.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btn_delete.Location = new System.Drawing.Point(16, 57);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 31);
            this.btn_delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonX2.Location = new System.Drawing.Point(112, 57);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(84, 31);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "Thêm mới";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // coTableLayoutPanel1
            // 
            this.coTableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.coTableLayoutPanel1.ColumnCount = 2;
            this.coTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.coTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.coTableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.coTableLayoutPanel1.Controls.Add(this.textBoxX1, 1, 0);
            this.coTableLayoutPanel1.Location = new System.Drawing.Point(16, 13);
            this.coTableLayoutPanel1.Name = "coTableLayoutPanel1";
            this.coTableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.coTableLayoutPanel1.RowCount = 1;
            this.coTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.coTableLayoutPanel1.Size = new System.Drawing.Size(944, 37);
            this.coTableLayoutPanel1.TabIndex = 2;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(6, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(194, 25);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên chẩn đoán :";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX1.Location = new System.Drawing.Point(209, 6);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(714, 24);
            this.textBoxX1.TabIndex = 1;
            this.textBoxX1.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
            this.textBoxX1.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxX1_Validating);
            // 
            // DiagnosesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 632);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.coTableLayoutPanel1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DiagnosesHistory";
            this.Text = "Bảng Chẩn Đoán- Chỉ nên sửa cho đúng chuẩn - không sửa nội dung";
            this.Load += new System.EventHandler(this.DiagnosesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.coTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX btn_delete;
        private CoTableLayoutPanel coTableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columncheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnUpdate;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}