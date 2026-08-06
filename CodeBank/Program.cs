using System;
using System.Windows.Forms;

namespace CodeBank
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // تنظیم DPI برای دات‌نت ۴.۶
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCodeBank());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}