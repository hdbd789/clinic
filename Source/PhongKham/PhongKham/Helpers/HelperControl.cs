using Clinic.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Helpers
{
    public class HelperControl
    {
        private static HelperControl instance;
        public ProgressForm form;
        private CancellationTokenSource _taskCancel;
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

        public void ShowProgress(CancellationTokenSource taskCancel)
        {
            _taskCancel = taskCancel;
            form = new ProgressForm();
            form.FormClosed += form_FormClosed;
            form.ShowDialog();
        }

        public void DoAsyncAction(Action action)
        {
            var ts = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(() =>
            {
                action();
            }, ts.Token).ContinueWith((t1) =>
            {
                if (t1.IsCompleted)
                {
                    Instance.StopProgress();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra. Xin hãy liên hệ admin.", "Thông báo", MessageBoxButtons.OK);
                }
            });
            Instance.ShowProgress(ts);
        }

        void form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ProgressForm form = (ProgressForm)sender;
            if (form.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                if (_taskCancel != null)
                {
                    _taskCancel.Cancel();
                }
            }
        }
        private delegate void StopProgressDelegate();
        public void StopProgress()
        {
            if (form.InvokeRequired)
            {
                form.BeginInvoke(new StopProgressDelegate(StopProgress));
                return;
            }
            if (form != null && !form.IsDisposed)
                form.Close();
        }
    }
}