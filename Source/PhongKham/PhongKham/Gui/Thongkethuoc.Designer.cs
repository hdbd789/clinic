namespace Clinic.Gui
{
    partial class Thongkethuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Thongkethuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_day = new System.Windows.Forms.Button();
            this.btn_month = new System.Windows.Forms.Button();
            this.btn_year = new System.Windows.Forms.Button();
            this.coTableLayoutPanel1 = new Clinic.CoTableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_countInput = new System.Windows.Forms.Label();
            this.lbl_moneyInput = new System.Windows.Forms.Label();
            this.lbl_countSell = new System.Windows.Forms.Label();
            this.lbl_moneySell = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_subCount = new System.Windows.Forms.Label();
            this.lbl_subMoney = new System.Windows.Forms.Label();
            this.coTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê thuốc theo kì";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(485, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // btn_day
            // 
            this.btn_day.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_day.Location = new System.Drawing.Point(12, 82);
            this.btn_day.Name = "btn_day";
            this.btn_day.Size = new System.Drawing.Size(75, 35);
            this.btn_day.TabIndex = 2;
            this.btn_day.Text = "Ngày";
            this.btn_day.UseVisualStyleBackColor = false;
            this.btn_day.Click += new System.EventHandler(this.btn_day_Click);
            // 
            // btn_month
            // 
            this.btn_month.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_month.Location = new System.Drawing.Point(216, 82);
            this.btn_month.Name = "btn_month";
            this.btn_month.Size = new System.Drawing.Size(75, 35);
            this.btn_month.TabIndex = 3;
            this.btn_month.Text = "Tháng";
            this.btn_month.UseVisualStyleBackColor = false;
            this.btn_month.Click += new System.EventHandler(this.btn_month_Click);
            // 
            // btn_year
            // 
            this.btn_year.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_year.Location = new System.Drawing.Point(422, 82);
            this.btn_year.Name = "btn_year";
            this.btn_year.Size = new System.Drawing.Size(75, 35);
            this.btn_year.TabIndex = 4;
            this.btn_year.Text = "Năm";
            this.btn_year.UseVisualStyleBackColor = false;
            this.btn_year.Click += new System.EventHandler(this.btn_year_Click);
            // 
            // coTableLayoutPanel1
            // 
            this.coTableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.coTableLayoutPanel1.ColumnCount = 3;
            this.coTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.09779F));
            this.coTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.90221F));
            this.coTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.coTableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.coTableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.coTableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.coTableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.coTableLayoutPanel1.Controls.Add(this.lbl_countInput, 1, 1);
            this.coTableLayoutPanel1.Controls.Add(this.lbl_moneyInput, 2, 1);
            this.coTableLayoutPanel1.Controls.Add(this.lbl_countSell, 1, 2);
            this.coTableLayoutPanel1.Controls.Add(this.lbl_moneySell, 2, 2);
            this.coTableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.coTableLayoutPanel1.Controls.Add(this.lbl_subCount, 1, 3);
            this.coTableLayoutPanel1.Controls.Add(this.lbl_subMoney, 2, 3);
            this.coTableLayoutPanel1.Location = new System.Drawing.Point(12, 123);
            this.coTableLayoutPanel1.Name = "coTableLayoutPanel1";
            this.coTableLayoutPanel1.RowCount = 4;
            this.coTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.coTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.coTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.coTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.coTableLayoutPanel1.Size = new System.Drawing.Size(485, 166);
            this.coTableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng số lượng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tổng số tiền( Đồng )";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thuốc nhập trong kì :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 37);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thuốc bán trong kì :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_countInput
            // 
            this.lbl_countInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_countInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_countInput.Location = new System.Drawing.Point(189, 45);
            this.lbl_countInput.Name = "lbl_countInput";
            this.lbl_countInput.Size = new System.Drawing.Size(130, 36);
            this.lbl_countInput.TabIndex = 4;
            this.lbl_countInput.Text = "0";
            this.lbl_countInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_moneyInput
            // 
            this.lbl_moneyInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_moneyInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_moneyInput.Location = new System.Drawing.Point(328, 45);
            this.lbl_moneyInput.Name = "lbl_moneyInput";
            this.lbl_moneyInput.Size = new System.Drawing.Size(151, 36);
            this.lbl_moneyInput.TabIndex = 5;
            this.lbl_moneyInput.Text = "0";
            this.lbl_moneyInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_countSell
            // 
            this.lbl_countSell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_countSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_countSell.Location = new System.Drawing.Point(189, 84);
            this.lbl_countSell.Name = "lbl_countSell";
            this.lbl_countSell.Size = new System.Drawing.Size(130, 37);
            this.lbl_countSell.TabIndex = 6;
            this.lbl_countSell.Text = "0";
            this.lbl_countSell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_moneySell
            // 
            this.lbl_moneySell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_moneySell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_moneySell.Location = new System.Drawing.Point(328, 84);
            this.lbl_moneySell.Name = "lbl_moneySell";
            this.lbl_moneySell.Size = new System.Drawing.Size(151, 37);
            this.lbl_moneySell.TabIndex = 7;
            this.lbl_moneySell.Text = "0";
            this.lbl_moneySell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 39);
            this.label6.TabIndex = 8;
            this.label6.Text = "Thuốc bán - Thuốc mua :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_subCount
            // 
            this.lbl_subCount.AutoSize = true;
            this.lbl_subCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_subCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subCount.Location = new System.Drawing.Point(189, 124);
            this.lbl_subCount.Name = "lbl_subCount";
            this.lbl_subCount.Size = new System.Drawing.Size(130, 39);
            this.lbl_subCount.TabIndex = 9;
            this.lbl_subCount.Text = "0";
            this.lbl_subCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_subMoney
            // 
            this.lbl_subMoney.AutoSize = true;
            this.lbl_subMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_subMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subMoney.Location = new System.Drawing.Point(328, 124);
            this.lbl_subMoney.Name = "lbl_subMoney";
            this.lbl_subMoney.Size = new System.Drawing.Size(151, 39);
            this.lbl_subMoney.TabIndex = 10;
            this.lbl_subMoney.Text = "0";
            this.lbl_subMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thongkethuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 294);
            this.Controls.Add(this.coTableLayoutPanel1);
            this.Controls.Add(this.btn_year);
            this.Controls.Add(this.btn_month);
            this.Controls.Add(this.btn_day);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(525, 340);
            this.Name = "Thongkethuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê thuốc theo kì";
            this.coTableLayoutPanel1.ResumeLayout(false);
            this.coTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_day;
        private System.Windows.Forms.Button btn_month;
        private System.Windows.Forms.Button btn_year;
        private CoTableLayoutPanel coTableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_countInput;
        private System.Windows.Forms.Label lbl_moneyInput;
        private System.Windows.Forms.Label lbl_countSell;
        private System.Windows.Forms.Label lbl_moneySell;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_subCount;
        private System.Windows.Forms.Label lbl_subMoney;
    }
}