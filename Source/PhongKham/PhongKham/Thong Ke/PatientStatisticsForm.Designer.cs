
namespace Clinic.Thong_Ke
{
    partial class PatientStatisticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientStatisticsForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbExportType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CSVType = new DevComponents.Editors.ComboItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datagridviewPaging1 = new Clinic.CustomControl.DatagridviewPaging();
            this.coTableLayoutPatient = new Clinic.CoTableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.coTableLayoutPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(8, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 50);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExport.Location = new System.Drawing.Point(195, 23);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(136, 50);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Xuất dữ liệu";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.cbbExportType);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Location = new System.Drawing.Point(1, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 100);
            this.panel1.TabIndex = 3;
            // 
            // cbbExportType
            // 
            this.cbbExportType.DisplayMember = "Text";
            this.cbbExportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbExportType.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbExportType.FormattingEnabled = true;
            this.cbbExportType.ItemHeight = 27;
            this.cbbExportType.Items.AddRange(new object[] {
            this.CSVType});
            this.cbbExportType.Location = new System.Drawing.Point(337, 38);
            this.cbbExportType.Name = "cbbExportType";
            this.cbbExportType.Size = new System.Drawing.Size(216, 33);
            this.cbbExportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbExportType.TabIndex = 4;
            this.cbbExportType.SelectedIndexChanged += new System.EventHandler(this.cbbExportType_SelectedIndexChanged);
            // 
            // CSVType
            // 
            this.CSVType.Text = "CSV File";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clinic.Properties.Resources.icon_patient;
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(133, 35);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(65, 25);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Demo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ngày khám :";
            // 
            // datagridviewPaging1
            // 
            this.datagridviewPaging1.AmountEachPage = 1;
            this.datagridviewPaging1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridviewPaging1.Location = new System.Drawing.Point(1, 308);
            this.datagridviewPaging1.Name = "datagridviewPaging1";
            this.datagridviewPaging1.Size = new System.Drawing.Size(1049, 327);
            this.datagridviewPaging1.TabIndex = 8;
            // 
            // coTableLayoutPatient
            // 
            this.coTableLayoutPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coTableLayoutPatient.BackColor = System.Drawing.Color.Gainsboro;
            this.coTableLayoutPatient.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.coTableLayoutPatient.ColumnCount = 4;
            this.coTableLayoutPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.coTableLayoutPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.coTableLayoutPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.coTableLayoutPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 541F));
            this.coTableLayoutPatient.Controls.Add(this.label2, 2, 0);
            this.coTableLayoutPatient.Controls.Add(this.dtpToDate, 3, 0);
            this.coTableLayoutPatient.Controls.Add(this.label1, 0, 0);
            this.coTableLayoutPatient.Controls.Add(this.dtpFromDate, 1, 0);
            this.coTableLayoutPatient.Location = new System.Drawing.Point(1, 146);
            this.coTableLayoutPatient.Name = "coTableLayoutPatient";
            this.coTableLayoutPatient.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.coTableLayoutPatient.RowCount = 1;
            this.coTableLayoutPatient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.coTableLayoutPatient.Size = new System.Drawing.Size(1049, 50);
            this.coTableLayoutPatient.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(462, 8);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(108, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tới ngày: ";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(615, 11);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 32);
            this.dtpToDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(103, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(159, 11);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(199, 32);
            this.dtpFromDate.TabIndex = 1;
            // 
            // PatientStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 636);
            this.Controls.Add(this.datagridviewPaging1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.coTableLayoutPatient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatientStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bệnh nhân";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.coTableLayoutPatient.ResumeLayout(false);
            this.coTableLayoutPatient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CoTableLayoutPanel coTableLayoutPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbExportType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblInfo;
        private DevComponents.Editors.ComboItem CSVType;
        private System.Windows.Forms.Label label3;
        private CustomControl.DatagridviewPaging datagridviewPaging1;
    }
}