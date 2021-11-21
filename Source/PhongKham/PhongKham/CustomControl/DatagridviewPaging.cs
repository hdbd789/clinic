using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Clinic.CustomControl
{
    public partial class DatagridviewPaging : UserControl
    {
        private DataTable dataTable = new DataTable();
        private DataRow[] dataRows;
        private int currentPage = 1;
        private int totalPage;
        private int amountEachPage = 1;
        public DatagridviewPaging()
        {
            InitializeComponent();
            dataGridViewData.DataSource = dataTable;
            dataGridViewData.ScrollBars = ScrollBars.Both;
            btnPrevious.Enabled = btnNext.Enabled = false;
        }
        public int AmountEachPage
        {
            get
            {
                return amountEachPage;
            }
            set
            {
                amountEachPage = value;
            }
        }

        public int RowCount 
        {
            get
            {
                return dataGridViewData.Rows.Count;
            }
        }

        public DataRow NewRow()
        {
            return dataTable.NewRow();
        }

        public void AddColumns(DataGridViewColumn[] columns)
        {
            foreach (var column in columns)
            {
                DataColumn dataColumn = new DataColumn(column.Name);
                dataTable.Columns.Add(dataColumn);
                dataGridViewData.Columns[column.Name].Width = column.Width;
                dataGridViewData.Columns[column.Name].HeaderText = column.HeaderText;
                dataGridViewData.Columns[column.Name].AutoSizeMode = column.AutoSizeMode;
            }
        }

        public void AddRowDatas(DataRow[] rows)
        {
            dataRows = rows;
            totalPage = (rows.Length / AmountEachPage) + 1;
            Paging(1);
        }

        private void Paging(int currentPage)
        {
            dataTable.Rows.Clear();
            UpdateUI(currentPage);
            int skip = (currentPage - 1) * AmountEachPage;
            foreach (var row in dataRows.Skip(skip).Take(AmountEachPage))
            {
                DataRow rowClone = dataTable.NewRow();
                rowClone.ItemArray = row.ItemArray;
                dataTable.Rows.Add(rowClone);
            }
            dataGridViewData.Refresh();
        }
        private void UpdateUI(int currentPage)
        {
            lblCountItem.Text = string.Format("{0} of {1}", currentPage, totalPage);
            lblRecord.Text = string.Format("{0} records", dataRows.Length);
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            if (currentPage >= totalPage)
            {
                btnNext.Enabled = false;
            }
            else if (currentPage == 1)
            {
                btnPrevious.Enabled = false;
            }
        }

        private void btnPrevious_Click(object sender, System.EventArgs e)
        {
            currentPage--;
            Paging(currentPage);
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            currentPage++;
            Paging(currentPage);
        }
    }
}