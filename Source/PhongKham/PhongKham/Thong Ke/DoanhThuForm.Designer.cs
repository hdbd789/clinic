namespace Clinic
{
    partial class DoanhThuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoanhThuForm));
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIdPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNamePatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiagnose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLoaiKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_moneybuyMedicine = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_numberbuyMedicine = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_laikinhdoanh = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_year = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ColumnServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewAdminOfService = new System.Windows.Forms.DataGridView();
            this.ColumnAdminInAdminOfService = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewLoaiKham = new System.Windows.Forms.DataGridView();
            this.ColumnLkName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnLkCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientNumber = new System.Windows.Forms.Label();
            this.PatientCountLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PDFShowDoanhThu = new AxAcroPDFLib.AxAcroPDF();
            this.G2NameDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G2SoLuotKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G2TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdminOfService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiKham)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDFShowDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.date,
            this.NameDoctor,
            this.ColumnIdPatient,
            this.ColumnNamePatient,
            this.ColumnDiagnose,
            this.ColumnServices,
            this.ColumnLoaiKham,
            this.Money});
            this.dataGridViewMain.Location = new System.Drawing.Point(3, 340);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.Size = new System.Drawing.Size(1323, 337);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Ngày tháng";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // NameDoctor
            // 
            this.NameDoctor.HeaderText = "Tên bác sĩ";
            this.NameDoctor.Name = "NameDoctor";
            this.NameDoctor.ReadOnly = true;
            this.NameDoctor.Width = 200;
            // 
            // ColumnIdPatient
            // 
            this.ColumnIdPatient.HeaderText = "Id bệnh nhân";
            this.ColumnIdPatient.Name = "ColumnIdPatient";
            // 
            // ColumnNamePatient
            // 
            this.ColumnNamePatient.HeaderText = "Tên bệnh nhân";
            this.ColumnNamePatient.Name = "ColumnNamePatient";
            this.ColumnNamePatient.Width = 200;
            // 
            // ColumnDiagnose
            // 
            this.ColumnDiagnose.HeaderText = "Chẩn đoán";
            this.ColumnDiagnose.Name = "ColumnDiagnose";
            this.ColumnDiagnose.Width = 200;
            // 
            // ColumnServices
            // 
            this.ColumnServices.HeaderText = "Các dịch vụ";
            this.ColumnServices.Name = "ColumnServices";
            this.ColumnServices.Width = 350;
            // 
            // ColumnLoaiKham
            // 
            this.ColumnLoaiKham.HeaderText = "Loại Khám";
            this.ColumnLoaiKham.Name = "ColumnLoaiKham";
            // 
            // Money
            // 
            this.Money.HeaderText = "Số tiền";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            this.Money.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng cộng:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(60, 46);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(29, 31);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "0";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(11, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(10, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ngày";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(93, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Tháng";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1337, 733);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.btn_year);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.PatientNumber);
            this.tabPage1.Controls.Add(this.PatientCountLabel);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.dataGridViewMain);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.labelTotal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1329, 707);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doanh Thu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsl_moneybuyMedicine,
            this.toolStripStatusLabel2,
            this.tsl_numberbuyMedicine,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tsl_laikinhdoanh});
            this.statusStrip1.Location = new System.Drawing.Point(3, 680);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1323, 24);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(141, 19);
            this.toolStripStatusLabel1.Text = "Chi phí mua thuốc :";
            // 
            // tsl_moneybuyMedicine
            // 
            this.tsl_moneybuyMedicine.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsl_moneybuyMedicine.Name = "tsl_moneybuyMedicine";
            this.tsl_moneybuyMedicine.Size = new System.Drawing.Size(18, 19);
            this.tsl_moneybuyMedicine.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(83, 19);
            this.toolStripStatusLabel2.Text = "Số lượng : ";
            // 
            // tsl_numberbuyMedicine
            // 
            this.tsl_numberbuyMedicine.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsl_numberbuyMedicine.Name = "tsl_numberbuyMedicine";
            this.tsl_numberbuyMedicine.Size = new System.Drawing.Size(18, 19);
            this.tsl_numberbuyMedicine.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 19);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(117, 19);
            this.toolStripStatusLabel4.Text = "Lãi kinh doanh :";
            // 
            // tsl_laikinhdoanh
            // 
            this.tsl_laikinhdoanh.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsl_laikinhdoanh.Name = "tsl_laikinhdoanh";
            this.tsl_laikinhdoanh.Size = new System.Drawing.Size(18, 19);
            this.tsl_laikinhdoanh.Text = "0";
            // 
            // btn_year
            // 
            this.btn_year.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_year.Location = new System.Drawing.Point(175, 119);
            this.btn_year.Name = "btn_year";
            this.btn_year.Size = new System.Drawing.Size(75, 23);
            this.btn_year.TabIndex = 17;
            this.btn_year.Text = "Năm";
            this.btn_year.UseVisualStyleBackColor = false;
            this.btn_year.Click += new System.EventHandler(this.btn_year_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(259, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1062, 320);
            this.splitContainer1.SplitterDistance = 587;
            this.splitContainer1.TabIndex = 15;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewAdminOfService);
            this.splitContainer2.Size = new System.Drawing.Size(585, 320);
            this.splitContainer2.SplitterDistance = 203;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServiceName,
            this.ColumnServiceAdmin,
            this.ColumnServiceCount,
            this.ColumnServiceTotal});
            this.dataGridView3.Location = new System.Drawing.Point(7, 4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(564, 194);
            this.dataGridView3.TabIndex = 12;
            // 
            // ColumnServiceName
            // 
            this.ColumnServiceName.HeaderText = "Tên Dịch Vụ";
            this.ColumnServiceName.Name = "ColumnServiceName";
            this.ColumnServiceName.Width = 200;
            // 
            // ColumnServiceAdmin
            // 
            this.ColumnServiceAdmin.HeaderText = "Người phụ trách";
            this.ColumnServiceAdmin.Name = "ColumnServiceAdmin";
            this.ColumnServiceAdmin.Width = 200;
            // 
            // ColumnServiceCount
            // 
            this.ColumnServiceCount.HeaderText = "Số ca";
            this.ColumnServiceCount.Name = "ColumnServiceCount";
            this.ColumnServiceCount.Width = 35;
            // 
            // ColumnServiceTotal
            // 
            this.ColumnServiceTotal.HeaderText = "Tổng tiền";
            this.ColumnServiceTotal.Name = "ColumnServiceTotal";
            this.ColumnServiceTotal.Width = 138;
            // 
            // dataGridViewAdminOfService
            // 
            this.dataGridViewAdminOfService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAdminOfService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdminOfService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdminOfService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAdminInAdminOfService,
            this.Column2});
            this.dataGridViewAdminOfService.Location = new System.Drawing.Point(43, 10);
            this.dataGridViewAdminOfService.Name = "dataGridViewAdminOfService";
            this.dataGridViewAdminOfService.Size = new System.Drawing.Size(487, 96);
            this.dataGridViewAdminOfService.TabIndex = 14;
            this.dataGridViewAdminOfService.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAdminOfService_CellClick);
            // 
            // ColumnAdminInAdminOfService
            // 
            this.ColumnAdminInAdminOfService.HeaderText = "Người phụ trách";
            this.ColumnAdminInAdminOfService.Name = "ColumnAdminInAdminOfService";
            this.ColumnAdminInAdminOfService.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAdminInAdminOfService.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tổng tiền";
            this.Column2.Name = "Column2";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridViewLoaiKham);
            this.splitContainer3.Size = new System.Drawing.Size(471, 320);
            this.splitContainer3.SplitterDistance = 153;
            this.splitContainer3.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.G2NameDoctor,
            this.G2SoLuotKham,
            this.G2TongCong});
            this.dataGridView2.Location = new System.Drawing.Point(10, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(447, 102);
            this.dataGridView2.TabIndex = 2;
            // 
            // dataGridViewLoaiKham
            // 
            this.dataGridViewLoaiKham.AllowUserToAddRows = false;
            this.dataGridViewLoaiKham.AllowUserToDeleteRows = false;
            this.dataGridViewLoaiKham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLoaiKham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoaiKham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLkName,
            this.ColumnLkCount});
            this.dataGridViewLoaiKham.Location = new System.Drawing.Point(8, 11);
            this.dataGridViewLoaiKham.Name = "dataGridViewLoaiKham";
            this.dataGridViewLoaiKham.Size = new System.Drawing.Size(449, 147);
            this.dataGridViewLoaiKham.TabIndex = 13;
            this.dataGridViewLoaiKham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLoaiKham_CellClick);
            // 
            // ColumnLkName
            // 
            this.ColumnLkName.FillWeight = 194.9239F;
            this.ColumnLkName.HeaderText = "Tên Loại Khám";
            this.ColumnLkName.Name = "ColumnLkName";
            this.ColumnLkName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLkName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnLkName.Width = 300;
            // 
            // ColumnLkCount
            // 
            this.ColumnLkCount.FillWeight = 5.076141F;
            this.ColumnLkCount.HeaderText = "Số Ca";
            this.ColumnLkCount.Name = "ColumnLkCount";
            this.ColumnLkCount.Width = 50;
            // 
            // PatientNumber
            // 
            this.PatientNumber.AutoSize = true;
            this.PatientNumber.Location = new System.Drawing.Point(76, 15);
            this.PatientNumber.Name = "PatientNumber";
            this.PatientNumber.Size = new System.Drawing.Size(13, 13);
            this.PatientNumber.TabIndex = 11;
            this.PatientNumber.Text = "0";
            // 
            // PatientCountLabel
            // 
            this.PatientCountLabel.AutoSize = true;
            this.PatientCountLabel.Location = new System.Drawing.Point(8, 15);
            this.PatientCountLabel.Name = "PatientCountLabel";
            this.PatientCountLabel.Size = new System.Drawing.Size(62, 13);
            this.PatientCountLabel.TabIndex = 10;
            this.PatientCountLabel.Text = "Bệnh nhân:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(15, 278);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 56);
            this.button4.TabIndex = 9;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(14, 217);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 55);
            this.button3.TabIndex = 8;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PDFShowDoanhThu);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1329, 707);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Print";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PDFShowDoanhThu
            // 
            this.PDFShowDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PDFShowDoanhThu.Enabled = true;
            this.PDFShowDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.PDFShowDoanhThu.Name = "PDFShowDoanhThu";
            this.PDFShowDoanhThu.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFShowDoanhThu.OcxState")));
            this.PDFShowDoanhThu.Size = new System.Drawing.Size(1323, 701);
            this.PDFShowDoanhThu.TabIndex = 0;
            // 
            // G2NameDoctor
            // 
            this.G2NameDoctor.HeaderText = "Tên bác sĩ";
            this.G2NameDoctor.Name = "G2NameDoctor";
            this.G2NameDoctor.ReadOnly = true;
            this.G2NameDoctor.Width = 185;
            // 
            // G2SoLuotKham
            // 
            this.G2SoLuotKham.HeaderText = "Lượt Khám/0";
            this.G2SoLuotKham.Name = "G2SoLuotKham";
            // 
            // G2TongCong
            // 
            this.G2TongCong.HeaderText = "Tổng Cộng";
            this.G2TongCong.Name = "G2TongCong";
            this.G2TongCong.ReadOnly = true;
            // 
            // DoanhThuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 733);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DoanhThuForm";
            this.Text = "DoanhThuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdminOfService)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiKham)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PDFShowDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private AxAcroPDFLib.AxAcroPDF PDFShowDoanhThu;
        private System.Windows.Forms.Label PatientNumber;
        private System.Windows.Forms.Label PatientCountLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNamePatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiagnose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLoaiKham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceTotal;
        private System.Windows.Forms.DataGridView dataGridViewAdminOfService;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnAdminInAdminOfService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridViewLoaiKham;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnLkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLkCount;
        private System.Windows.Forms.Button btn_year;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsl_moneybuyMedicine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsl_numberbuyMedicine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsl_laikinhdoanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn G2NameDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn G2SoLuotKham;
        private System.Windows.Forms.DataGridViewTextBoxColumn G2TongCong;
    }
}