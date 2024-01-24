using System;
using System.Threading;
using System.Windows.Forms;
using log4net.Config;

namespace TestTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += HandleApplicationException;
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            Application.Run(new MainForm());
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        private static void HandleApplicationException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("{0}\n{1}", e.Exception.Message, e.Exception.StackTrace));                                          
        }
    }
}