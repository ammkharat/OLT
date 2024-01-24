using System;
using System.Windows.Forms;

namespace RemoteApp.Shift.Scheduler
{
    public partial class ShiftSchedulerTestRunner : Form
    {
        private ShiftScheduler scheduler;

        public ShiftSchedulerTestRunner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduler = new ShiftScheduler();
            scheduler.StartService();
        }
    }
}