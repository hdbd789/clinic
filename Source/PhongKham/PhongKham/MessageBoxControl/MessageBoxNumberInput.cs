using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinic.MessageBoxControl
{
    public partial class MessageBoxNumberInput : Form
    {
        private bool isOK = false;
        public MessageBoxNumberInput()
        {
            InitializeComponent();
        }
        public MessageBoxNumberInput(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        public static DialogResult Show(string title,ref long result)
        {
            MessageBoxNumberInput message = new MessageBoxNumberInput(title);
            message.Show();
            if (message.DialogResult == DialogResult.OK)
            {
                result = (long)message.numericUpDown1.Value;
            }
            return message.DialogResult;
        }

        public static DialogResult ShowDialog(string title, ref long result)
        {
            MessageBoxNumberInput message = new MessageBoxNumberInput(title);
            message.ShowDialog();
            if (message.DialogResult == DialogResult.OK)
            {
                result = (long)message.numericUpDown1.Value;
            }
            return message.DialogResult;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {           
            if (this.numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Bạn nhập số lượng chưa đúng. Xin vui lòng nhập lại.","Thông báo",MessageBoxButtons.OK);
                return;
            }
            this.DialogResult = DialogResult.OK;
            isOK = true;
        }

        private void MessageBoxNumberInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isOK)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
