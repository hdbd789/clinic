﻿using Clinic.ClinicException;
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
                if (t1.Status == TaskStatus.Faulted || t1.Status == TaskStatus.Canceled)
                {
                    if (t1.Exception.InnerException is FunctionalException functional)
                    {
                        MessageBox.Show(functional.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(messageFail, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (!string.IsNullOrEmpty(messageSuccess))
                {
                    MessageBox.Show(messageSuccess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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