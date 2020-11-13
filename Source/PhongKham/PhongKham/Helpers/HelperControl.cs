using Clinic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Clinic.Helpers
{
    public class HelperControl
    {
        private static HelperControl instance;
        public ProgressForm form;
        private Thread thread;
        public static HelperControl Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HelperControl();
                }
                return instance;
            }
        }

        public void ShowProgress(Thread thread)
        {
            form = new ProgressForm();
            form.FormClosed += form_FormClosed;
            this.thread = thread;
            form.ShowDialog();
        }

        void form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ProgressForm form = (ProgressForm)sender;
            if (form.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                if (thread != null && thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }

        public void StopProgress()
        {
            if(form != null && !form.IsDisposed)
            form.Close();
        }
    }
}
