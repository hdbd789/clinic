using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinic.Helpers
{
    public class ErrorProviderHelper
    {
        private static ErrorProviderHelper instance;
        private ErrorProvider errorProvider;
        private ErrorProviderHelper()
        {
            TextBox textBox = new TextBox();
            errorProvider = new ErrorProvider();
            errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(textBox, 2);
            errorProvider.BlinkRate = 1000;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        public void SetError(Control control,string message)
        {
            this.errorProvider.SetError(control, message);
        }

        public string GetError(Control control)
        {
            return this.errorProvider.GetError(control);
        }
        public static ErrorProviderHelper GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ErrorProviderHelper();
                }
                return instance;
            }
        }
    }
}
