using System;
using System.Windows.Forms;
using Clinic.Helpers;

namespace Clinic
{
    public partial class LoginForm : Form
    {
        public static int Authority;
        private static string name;

        public static string Name1
        {
            get { return LoginForm.name; }
            set { LoginForm.name = value; }
        }
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_ClickMySql(object sender, EventArgs e)
        {
            string user = txtBoxInputMedicineNewCostIn.Text;
            string pass = textBox2.Text;
            if (Helper.checkUserExists(user,pass,true))
            {
                    this.DialogResult = DialogResult.OK;
                    Name1 = user;
                    this.Close();
            }
            else
            {

                MessageBox.Show("Sai tên hoặc password");
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_ClickMySql(sender,e);
            }
        }
    }
}
