using System;
using System.Windows.Forms;

namespace RemoteApp.Restriction.Scheduler
{
    public partial class RestrictionSchedulerTestRunner : Form
    {
        private RestrictionScheduler scheduler;

        public RestrictionSchedulerTestRunner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduler = new RestrictionScheduler();
            scheduler.StartService();
        }
    }
}