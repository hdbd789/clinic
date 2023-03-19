using Clinic.ClinicException;
using Clinic.Extensions;
using log4net;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Helpers
{
    public class HelperControl
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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

        public void DoAsyncAction(Action action, string messageSuccess = "", string messageFail = "Có lỗi xảy ra. Xin hãy liên hệ admin.")
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
                if (t1.Status == TaskStatus.Faulted)
                {
                    if (t1.Exception.InnerException is FunctionalException functional)
                    {
                        MessageBox.Show(functional.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Log.Error(t1.Exception.InnerException.Message, t1.Exception.InnerException);
                        MessageBox.Show(messageFail, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(t1.Status == TaskStatus.Canceled)
                {
                    MessageBox.Show("Bạn đã dừng xử lí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!string.IsNullOrEmpty(messageSuccess))
                {
                    MessageBox.Show(messageSuccess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            Instance.ShowProgress(ts);
        }

        public void DoAsyncAction(
            Action action, 
            Action actionBefore,
            Action actionAfter,
            string messageSuccess = "", 
            string messageFail = "Có lỗi xảy ra. Xin hãy liên hệ admin.")
        {
            var ts = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(() =>
            {
                action();
            }, ts.Token).ContinueWith((t1) =>
            {
                actionAfter();
                if (t1.Status == TaskStatus.Faulted)
                {
                    if (t1.Exception.InnerException is FunctionalException functional)
                    {
                        MessageBox.Show(functional.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Log.Error(t1.Exception.InnerException.Message, t1.Exception.InnerException);
                        MessageBox.Show(messageFail, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (t1.Status == TaskStatus.Canceled)
                {
                    MessageBox.Show("Bạn đã dừng xử lí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!string.IsNullOrEmpty(messageSuccess))
                {
                    MessageBox.Show(messageSuccess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
            actionBefore();
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