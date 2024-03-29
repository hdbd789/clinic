﻿using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using PhongKham;

namespace Clinic.Business
{
    public static class StartApplication
    {
        private static Form1 mainForm;
        private static LoginForm login;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void StartApp()
        {
            login = new LoginForm();
            try
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    mainForm = new Form1(LoginForm.Authority, LoginForm.Name1);
                    Application.Run(mainForm);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
            if (mainForm != null && mainForm.IsLogout)
            {
                Close();
                StartApp();
            }
        }

        public static void Close()
        {
            mainForm?.Dispose();
            login?.Dispose();
            login = null;
            mainForm = null;
        }
    }
}
