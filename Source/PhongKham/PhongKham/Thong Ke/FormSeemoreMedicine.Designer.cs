namespace Clinic.Thong_Ke
{
    partial class FormSeemoreMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeemoreMedicine));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_dauki = new System.Windows.Forms.TextBox();
            this.btn_day = new System.Windows.Forms.Button();
            this.btn_month = new System.Windows.Forms.Button();
            this.btn_year = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_nhapthuoc = new System.Windows.Forms.TextBox();
            this.tbx_moneynhapthuoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_xuatthuoc = new System.Windows.Forms.TextBox();
            this.tbx_moneyxuatthuoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_cuoiki = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi tiết thêm cho thuôc : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tồn thuốc đầu kì :";
            // 
            // tbx_dauki
            // 
            this.tbx_dauki.BackColor = System.Drawing.Color.White;
            this.tbx_dauki.Location = new System.Drawing.Point(156, 119);
            this.tbx_dauki.Name = "tbx_dauki";
            this.tbx_dauki.ReadOnly = true;
            this.tbx_dauki.Size = new System.Drawing.Size(129, 20);
            this.tbx_dauki.TabIndex = 2;
            // 
            // btn_day
            // 
            this.btn_day.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_day.Location = new System.Drawing.Point(234, 48);
            this.btn_day.Name = "btn_day";
            this.btn_day.Size = new System.Drawing.Size(75, 25);
            this.btn_day.TabIndex = 3;
            this.btn_day.Text = "Ngày";
            this.btn_day.UseVisualStyleBackColor = false;
            this.btn_day.Click += new System.EventHandler(this.btn_day_Click);
            // 
            // btn_month
            // 
            this.btn_month.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_month.Location = new System.Drawing.Point(322, 47);
            this.btn_month.Name = "btn_month";
            this.btn_month.Size = new System.Drawing.Size(75, 26);
            this.btn_month.TabIndex = 4;
            this.btn_month.Text = "Tháng";
            this.btn_month.UseVisualStyleBackColor = false;
            this.btn_month.Click += new System.EventHandler(this.btn_month_Click);
            // 
            // btn_year
            // 
            this.btn_year.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_year.Location = new System.Drawing.Point(410, 46);
            this.btn_year.Name = "btn_year";
            this.btn_year.Size = new System.Drawing.Size(75, 27);
            this.btn_year.TabIndex = 5;
            this.btn_year.Text = "Năm";
            this.btn_year.UseVisualStyleBackColor = false;
            this.btn_year.Click += new System.EventHandler(this.btn_year_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số tiền (Cost In)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nhập thuốc trong kì :";
            // 
            // tbx_nhapthuoc
            // 
            this.tbx_nhapthuoc.BackColor = System.Drawing.Color.White;
            this.tbx_nhapthuoc.Location = new System.Drawing.Point(156, 160);
            this.tbx_nhapthuoc.Name = "tbx_nhapthuoc";
            this.tbx_nhapthuoc.ReadOnly = true;
            this.tbx_nhapthuoc.Size = new System.Drawing.Size(129, 20);
            this.tbx_nhapthuoc.TabIndex = 10;
            // 
            // tbx_moneynhapthuoc
            // 
            this.tbx_moneynhapthuoc.BackColor = System.Drawing.Color.White;
            this.tbx_moneynhapthuoc.Location = new System.Drawing.Point(316, 159);
            this.tbx_moneynhapthuoc.Name = "tbx_moneynhapthuoc";
            this.tbx_moneynhapthuoc.ReadOnly = true;
            this.tbx_moneynhapthuoc.Size = new System.Drawing.Size(169, 20);
            this.tbx_moneynhapthuoc.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Xuất thuốc bán :";
            // 
            // tbx_xuatthuoc
            // 
            this.tbx_xuatthuoc.BackColor = System.Drawing.Color.White;
            this.tbx_xuatthuoc.Location = new System.Drawing.Point(156, 205);
            this.tbx_xuatthuoc.Name = "tbx_xuatthuoc";
            this.tbx_xuatthuoc.ReadOnly = true;
            this.tbx_xuatthuoc.Size = new System.Drawing.Size(129, 20);
            this.tbx_xuatthuoc.TabIndex = 13;
            // 
            // tbx_moneyxuatthuoc
            // 
            this.tbx_moneyxuatthuoc.BackColor = System.Drawing.Color.White;
            this.tbx_moneyxuatthuoc.Location = new System.Drawing.Point(316, 206);
            this.tbx_moneyxuatthuoc.Name = "tbx_moneyxuatthuoc";
            this.tbx_moneyxuatthuoc.ReadOnly = true;
            this.tbx_moneyxuatthuoc.Size = new System.Drawing.Size(169, 20);
            this.tbx_moneyxuatthuoc.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tồn thuốc cuối kì :";
            // 
            // tbx_cuoiki
            // 
            this.tbx_cuoiki.BackColor = System.Drawing.Color.White;
            this.tbx_cuoiki.Location = new System.Drawing.Point(156, 241);
            this.tbx_cuoiki.Name = "tbx_cuoiki";
            this.tbx_cuoiki.ReadOnly = true;
            this.tbx_cuoiki.Size = new System.Drawing.Size(129, 20);
            this.tbx_cuoiki.TabIndex = 16;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(181, 12);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(47, 17);
            this.lbl_name.TabIndex = 19;
            this.lbl_name.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(319, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Số tiền (Cost Out)";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(216, 23);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // FormSeemoreMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 277);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.tbx_cuoiki);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbx_moneyxuatthuoc);
            this.Controls.Add(this.tbx_xuatthuoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbx_moneynhapthuoc);
            this.Controls.Add(this.tbx_nhapthuoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_year);
            this.Controls.Add(this.btn_month);
            this.Controls.Add(this.btn_day);
            this.Controls.Add(this.tbx_dauki);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(513, 316);
            this.Name = "FormSeemoreMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết thuốc";
            this.Load += new System.EventHandler(this.FormSeemoreMedicine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_dauki;
        private System.Windows.Forms.Button btn_day;
        private System.Windows.Forms.Button btn_month;
        private System.Windows.Forms.Button btn_year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_nhapthuoc;
        private System.Windows.Forms.TextBox tbx_moneynhapthuoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_xuatthuoc;
        private System.Windows.Forms.TextBox tbx_moneyxuatthuoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_cuoiki;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;

    }
}