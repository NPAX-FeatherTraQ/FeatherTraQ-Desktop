using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace ClouReaderDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string strLanguage = System.Configuration.ConfigurationSettings.AppSettings["Language"].ToString();
                if (strLanguage.Trim().Equals("en"))
                {
                    ClouReaderAPI.CLReader.SetAPILanguageType(1);           // 设置API英文
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    SingleMainForm.IsEnglish = true;
                }
                else 
                {
                    ClouReaderAPI.CLReader.SetAPILanguageType(0);           // 设置API中文
                }
            }
            catch { }
            Application.Run(new SingleMainForm());
            //Application.Run(new MyFormTemplet._360Form());
        }
    }
}
