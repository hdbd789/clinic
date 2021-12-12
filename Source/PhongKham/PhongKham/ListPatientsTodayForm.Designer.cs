using System.Windows.Forms;
namespace Clinic
{
    partial class ListPatientsTodayForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namepatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNhietDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHuyetAp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách hôm nay:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Id,
            this.namepatient,
            this.ColAction,
            this.ColumnNhietDo,
            this.ColumnHuyetAp,
            this.ColWeight,
            this.ColHeight});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 69);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(945, 729);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 125;
            // 
            // namepatient
            // 
            this.namepatient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.namepatient.HeaderText = "Họ Và Tên";
            this.namepatient.MinimumWidth = 6;
            this.namepatient.Name = "namepatient";
            this.namepatient.ReadOnly = true;
            // 
            // ColAction
            // 
            this.ColAction.HeaderText = "Tác vụ";
            this.ColAction.MinimumWidth = 6;
            this.ColAction.Name = "ColAction";
            this.ColAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColAction.Text = "";
            this.ColAction.Width = 125;
            // 
            // ColumnNhietDo
            // 
            this.ColumnNhietDo.HeaderText = "Nhiệt độ";
            this.ColumnNhietDo.MinimumWidth = 6;
            this.ColumnNhietDo.Name = "ColumnNhietDo";
            this.ColumnNhietDo.ReadOnly = true;
            this.ColumnNhietDo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnNhietDo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnNhietDo.Width = 70;
            // 
            // ColumnHuyetAp
            // 
            this.ColumnHuyetAp.HeaderText = "Huyết Áp";
            this.ColumnHuyetAp.MinimumWidth = 6;
            this.ColumnHuyetAp.Name = "ColumnHuyetAp";
            this.ColumnHuyetAp.ReadOnly = true;
            this.ColumnHuyetAp.Width = 70;
            // 
            // ColWeight
            // 
            this.ColWeight.HeaderText = "Can nang";
            this.ColWeight.MinimumWidth = 6;
            this.ColWeight.Name = "ColWeight";
            this.ColWeight.Visible = false;
            this.ColWeight.Width = 125;
            // 
            // ColHeight
            // 
            this.ColHeight.HeaderText = "Chieu cao";
            this.ColHeight.MinimumWidth = 6;
            this.ColHeight.Name = "ColHeight";
            this.ColHeight.Visible = false;
            this.ColHeight.Width = 125;
            // 
            // ListPatientsTodayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(945, 798);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListPatientsTodayForm";
            this.Text = "ListPatientsTodayForm";
            this.MouseLeave += new System.EventHandler(this.Form2_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn namepatient;
        private DataGridViewButtonColumn ColAction;
        private DataGridViewTextBoxColumn ColumnNhietDo;
        private DataGridViewTextBoxColumn ColumnHuyetAp;
        private DataGridViewTextBoxColumn ColWeight;
        private DataGridViewTextBoxColumn ColHeight;
    }
}