using System;
using System.Windows.Forms;

namespace RemoteApp.LabAlert.Scheduler
{
    public partial class LabAlertSchedulerTestRunner : Form
    {
        private LabAlertScheduler scheduler;

        public LabAlertSchedulerTestRunner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduler = new LabAlertScheduler();
            scheduler.StartService();
        }
    }
}