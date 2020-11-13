namespace Clinic
{
    partial class TuThuocForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TuThuocForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInputDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHDSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddCount = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_history = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CoTableLayoutPanel3 = new Clinic.CoTableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineNewName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineNewCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineNewCostIn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxInputMedicineNewCostOut = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label33 = new System.Windows.Forms.Label();
            this.textBoxMedicineHdsd = new System.Windows.Forms.TextBox();
            this.lblInputMedicineNewId = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInputMedicineNewOk = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PDFShowMedicines = new AxAcroPDFLib.AxAcroPDF();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.CoTableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDFShowMedicines)).BeginInit();
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
            this.ColumnCount,
            this.ColumnCostIn,
            this.ColumnCostOut,
            this.ColumnInputDay,
            this.ColumnHDSD,
            this.ColumnAddCount,
            this.ColumnUpdate,
            this.ColumnDelete,
            this.col_history});
            this.dataGridView1.Location = new System.Drawing.Point(3, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1221, 482);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Width = 60;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Tên Thuốc";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 200;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Số Lượng";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            this.ColumnCount.Width = 80;
            // 
            // ColumnCostIn
            // 
            this.ColumnCostIn.HeaderText = "Giá vào";
            this.ColumnCostIn.Name = "ColumnCostIn";
            // 
            // ColumnCostOut
            // 
            this.ColumnCostOut.HeaderText = "Giá ra";
            this.ColumnCostOut.Name = "ColumnCostOut";
            // 
            // ColumnInputDay
            // 
            this.ColumnInputDay.HeaderText = "Ngày Nhập";
            this.ColumnInputDay.Name = "ColumnInputDay";
            this.ColumnInputDay.ReadOnly = true;
            this.ColumnInputDay.Width = 150;
            // 
            // ColumnHDSD
            // 
            this.ColumnHDSD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnHDSD.HeaderText = "HDSD";
            this.ColumnHDSD.Name = "ColumnHDSD";
            // 
            // ColumnAddCount
            // 
            this.ColumnAddCount.HeaderText = "Thêm số lượng";
            this.ColumnAddCount.Name = "ColumnAddCount";
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
            this.ColumnDelete.Width = 60;
            // 
            // col_history
            // 
            this.col_history.HeaderText = "History";
            this.col_history.Name = "col_history";
            this.col_history.Width = 60;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1235, 733);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.CoTableLayoutPanel3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnInputMedicineNewOk);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1227, 707);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách thuốc";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CoTableLayoutPanel3
            // 
            this.CoTableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CoTableLayoutPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.CoTableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.CoTableLayoutPanel3.ColumnCount = 7;
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.57658F));
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.42342F));
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.CoTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 387F));
            this.CoTableLayoutPanel3.Controls.Add(this.label13, 0, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.label20, 1, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewName, 1, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.label21, 2, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewCount, 2, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.label8, 3, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewCostIn, 3, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.label12, 4, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.txtBoxInputMedicineNewCostOut, 4, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.label25, 5, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.dateTimePicker3, 5, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.label33, 6, 0);
            this.CoTableLayoutPanel3.Controls.Add(this.textBoxMedicineHdsd, 6, 1);
            this.CoTableLayoutPanel3.Controls.Add(this.lblInputMedicineNewId, 0, 1);
            this.CoTableLayoutPanel3.Location = new System.Drawing.Point(8, 6);
            this.CoTableLayoutPanel3.Name = "CoTableLayoutPanel3";
            this.CoTableLayoutPanel3.RowCount = 2;
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CoTableLayoutPanel3.Size = new System.Drawing.Size(1198, 78);
            this.CoTableLayoutPanel3.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "ID:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(89, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Tên Thuốc";
            // 
            // txtBoxInputMedicineNewName
            // 
            this.txtBoxInputMedicineNewName.Location = new System.Drawing.Point(89, 46);
            this.txtBoxInputMedicineNewName.Name = "txtBoxInputMedicineNewName";
            this.txtBoxInputMedicineNewName.Size = new System.Drawing.Size(400, 20);
            this.txtBoxInputMedicineNewName.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(498, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 8;
            this.label21.Text = "Số lượng";
            // 
            // txtBoxInputMedicineNewCount
            // 
            this.txtBoxInputMedicineNewCount.Location = new System.Drawing.Point(498, 46);
            this.txtBoxInputMedicineNewCount.Name = "txtBoxInputMedicineNewCount";
            this.txtBoxInputMedicineNewCount.Size = new System.Drawing.Size(58, 20);
            this.txtBoxInputMedicineNewCount.TabIndex = 7;
            this.txtBoxInputMedicineNewCount.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxInputMedicineNewCount_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(565, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Giá In";
            // 
            // txtBoxInputMedicineNewCostIn
            // 
            this.txtBoxInputMedicineNewCostIn.Location = new System.Drawing.Point(565, 46);
            this.txtBoxInputMedicineNewCostIn.Name = "txtBoxInputMedicineNewCostIn";
            this.txtBoxInputMedicineNewCostIn.Size = new System.Drawing.Size(66, 20);
            this.txtBoxInputMedicineNewCostIn.TabIndex = 8;
            this.txtBoxInputMedicineNewCostIn.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxInputMedicineNewCount_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(640, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Giá Out";
            // 
            // txtBoxInputMedicineNewCostOut
            // 
            this.txtBoxInputMedicineNewCostOut.Location = new System.Drawing.Point(640, 46);
            this.txtBoxInputMedicineNewCostOut.Name = "txtBoxInputMedicineNewCostOut";
            this.txtBoxInputMedicineNewCostOut.Size = new System.Drawing.Size(65, 20);
            this.txtBoxInputMedicineNewCostOut.TabIndex = 9;
            this.txtBoxInputMedicineNewCostOut.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxInputMedicineNewCount_Validating);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(714, 3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 13);
            this.label25.TabIndex = 25;
            this.label25.Text = "Ngày Nhập";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(714, 46);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(83, 20);
            this.dateTimePicker3.TabIndex = 10;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(810, 3);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(59, 13);
            this.label33.TabIndex = 28;
            this.label33.Text = "Cách dùng";
            // 
            // textBoxMedicineHdsd
            // 
            this.textBoxMedicineHdsd.Location = new System.Drawing.Point(810, 46);
            this.textBoxMedicineHdsd.Name = "textBoxMedicineHdsd";
            this.textBoxMedicineHdsd.Size = new System.Drawing.Size(326, 20);
            this.textBoxMedicineHdsd.TabIndex = 29;
            // 
            // lblInputMedicineNewId
            // 
            this.lblInputMedicineNewId.AutoSize = true;
            this.lblInputMedicineNewId.Location = new System.Drawing.Point(6, 43);
            this.lblInputMedicineNewId.Name = "lblInputMedicineNewId";
            this.lblInputMedicineNewId.Size = new System.Drawing.Size(35, 13);
            this.lblInputMedicineNewId.TabIndex = 30;
            this.lblInputMedicineNewId.Text = "label1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(396, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Salmon;
            this.button4.Location = new System.Drawing.Point(373, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 35);
            this.button4.TabIndex = 11;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(214, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnInputMedicineNewOk
            // 
            this.btnInputMedicineNewOk.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInputMedicineNewOk.Location = new System.Drawing.Point(214, 90);
            this.btnInputMedicineNewOk.Name = "btnInputMedicineNewOk";
            this.btnInputMedicineNewOk.Size = new System.Drawing.Size(92, 35);
            this.btnInputMedicineNewOk.TabIndex = 10;
            this.btnInputMedicineNewOk.Text = "Nhập mới";
            this.btnInputMedicineNewOk.UseVisualStyleBackColor = false;
            this.btnInputMedicineNewOk.Click += new System.EventHandler(this.btnInputMedicineNewOk_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PDFShowMedicines);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1227, 707);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Print";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PDFShowMedicines
            // 
            this.PDFShowMedicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PDFShowMedicines.Enabled = true;
            this.PDFShowMedicines.Location = new System.Drawing.Point(3, 3);
            this.PDFShowMedicines.Name = "PDFShowMedicines";
            this.PDFShowMedicines.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFShowMedicines.OcxState")));
            this.PDFShowMedicines.Size = new System.Drawing.Size(1221, 701);
            this.PDFShowMedicines.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.Location = new System.Drawing.Point(576, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 35);
            this.button3.TabIndex = 26;
            this.button3.Text = "Xem thống kê";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TuThuocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 733);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TuThuocForm";
            this.Text = "Tủ Thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TuThuocForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.CoTableLayoutPanel3.ResumeLayout(false);
            this.CoTableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PDFShowMedicines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private AxAcroPDFLib.AxAcroPDF PDFShowMedicines;
        private CoTableLayoutPanel CoTableLayoutPanel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtBoxInputMedicineNewName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtBoxInputMedicineNewCount;
        private System.Windows.Forms.TextBox txtBoxInputMedicineNewCostOut;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxInputMedicineNewCostIn;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBoxMedicineHdsd;
        private System.Windows.Forms.Button btnInputMedicineNewOk;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblInputMedicineNewId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInputDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHDSD;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnAddCount;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnUpdate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewButtonColumn col_history;
        private System.Windows.Forms.Button button3;
    }
}