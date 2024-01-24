using System;
using System.Windows.Forms;

namespace RemoteApp.Log.Scheduler
{
    public partial class LogSchedulerTestRunner : Form
    {
        private LogScheduler scheduler;

        public LogSchedulerTestRunner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduler = new LogScheduler();
            scheduler.StartService();
        }
    }
}