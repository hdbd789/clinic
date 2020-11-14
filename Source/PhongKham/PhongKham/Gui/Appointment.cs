using Clinic.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Clinic.Gui
{
    public partial class Appointment : Form
    {
        private IDatabase db;
        public Appointment()
        {
            InitializeComponent();
            db = DatabaseFactory.Instance;
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string strcmd = string.Format("select Namepatient,{0}.Namedoctor,{2},phone,benh,Reason from {0} left join {4} on {0}.IdHistory = {4}.IdHistory where {1} = 0 or ({2} >= '{3}' and {1} is null)", DatabaseContants.tables.lichHen, DatabaseContants.LichHen.status, DatabaseContants.LichHen.Time, DateTime.Now.ToString("yyyy-MM-dd"),DatabaseContants.tables.history);
            LoadDataIntoDataGrid(strcmd);
        }

        private void buttonNgay_Click(object sender, EventArgs e)
        {
            string strcmd = string.Format("select Namepatient,{0}.Namedoctor,{2},phone,benh,Reason from {0} left join {4} on {0}.IdHistory = {4}.IdHistory where ({1} = 0 or ({2} >= '{3}' and {1} is null)) and {2} = '{5}'", DatabaseContants.tables.lichHen, DatabaseContants.LichHen.status, DatabaseContants.LichHen.Time, DateTime.Now.ToString("yyyy-MM-dd"), DatabaseContants.tables.history,dateTimeInput1.Value.ToString("yyyy-MM-dd"));
            LoadDataIntoDataGrid(strcmd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strcmd = string.Format("select Namepatient,{0}.Namedoctor,{2},phone,benh,Reason from {0} left join {4} on {0}.IdHistory = {4}.IdHistory where ({1} = 0 or ({2} >= '{3}' and {1} is null)) and month({2}) = {5}", DatabaseContants.tables.lichHen, DatabaseContants.LichHen.status, DatabaseContants.LichHen.Time, DateTime.Now.ToString("yyyy-MM-dd"), DatabaseContants.tables.history, dateTimeInput1.Value.Month);
            LoadDataIntoDataGrid(strcmd);
        }
        private void LoadDataIntoDataGrid(string strCmd)
        {
            using (MySqlDataReader reader = db.ExecuteReader(strCmd, null) as MySqlDataReader)
            {
                DataTable tb = new DataTable();
                tb.Load(reader);
                tb.Columns[DatabaseContants.LichHen.Namepatient].ColumnName = "Tên bệnh nhân";
                tb.Columns[DatabaseContants.LichHen.Namedoctor].ColumnName = "Tên bác sĩ";
                tb.Columns[DatabaseContants.LichHen.Time].ColumnName = "Thời gian hẹn";
                tb.Columns[DatabaseContants.LichHen.phone].ColumnName = "Điện thoại";
                tb.Columns[DatabaseContants.LichHen.sick].ColumnName = "Bệnh";
                tb.Columns[DatabaseContants.history.Reason].ColumnName = "Lí do tái khám";
                dataGridView1.DataSource = tb;
                dataGridView1.Columns[0].Width = 350;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[4].Width = 250;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView1.Columns[0]
            }
        }

        
    }
}
