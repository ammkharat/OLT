using System;
// ReSharper disable once RedundantUsingDirective  
// ReSharper will remove this because it thinks ServiceProcess isn't needed since we are in Debug mode. But we build to Release Mode, 
// thus ServiceBase which is is System.ServiceProcess is required.
using System.ServiceProcess;

namespace RemoteApp.Shift.Scheduler
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
#if !DEBUG
            ServiceBase[] ServicesToRun = new ServiceBase[] { new ShiftScheduler() };
            ServiceBase.Run(ServicesToRun);
#else
            var testForm = new ShiftSchedulerTestRunner();
            testForm.ShowDialog();
#endif
        }
    }
}