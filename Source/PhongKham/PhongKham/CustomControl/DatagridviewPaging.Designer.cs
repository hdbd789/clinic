
namespace Clinic.CustomControl
{
    partial class DatagridviewPaging
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCountItem = new DevComponents.DotNetBar.LabelX();
            this.btnNext = new DevComponents.DotNetBar.ButtonX();
            this.btnPrevious = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRecord = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecord);
            this.panel1.Controls.Add(this.lblCountItem);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 40);
            this.panel1.TabIndex = 1;
            // 
            // lblCountItem
            // 
            // 
            // 
            // 
            this.lblCountItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCountItem.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountItem.Location = new System.Drawing.Point(53, 4);
            this.lblCountItem.Name = "lblCountItem";
            this.lblCountItem.Size = new System.Drawing.Size(121, 32);
            this.lblCountItem.TabIndex = 2;
            this.lblCountItem.Text = "0 of 0";
            this.lblCountItem.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNext.Location = new System.Drawing.Point(185, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 33);
            this.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrevious.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrevious.Location = new System.Drawing.Point(5, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(38, 33);
            this.btnPrevious.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AllowUserToAddRows = false;
            this.dataGridViewData.AllowUserToDeleteRows = false;
            this.dataGridViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(3, 50);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.RowHeadersVisible = false;
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.RowTemplate.Height = 24;
            this.dataGridViewData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewData.ShowEditingIcon = false;
            this.dataGridViewData.ShowRowErrors = false;
            this.dataGridViewData.Size = new System.Drawing.Size(848, 350);
            this.dataGridViewData.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dataGridViewData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 403);
            this.panel2.TabIndex = 3;
            // 
            // lblRecord
            // 
            this.lblRecord.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(228, 3);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(209, 32);
            this.lblRecord.TabIndex = 3;
            this.lblRecord.Text = "0 records";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DatagridviewPaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "DatagridviewPaging";
            this.Size = new System.Drawing.Size(854, 403);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX lblCountItem;
        private DevComponents.DotNetBar.ButtonX btnNext;
        private DevComponents.DotNetBar.ButtonX btnPrevious;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRecord;
    }
}