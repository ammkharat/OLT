using System;
using System.Windows.Forms;

namespace RemoteApp.OLTProcess.Scheduler
{
    public partial class OLTProcessTestRunner : Form
    {
        private OLTProcessScheduler scheduler;

        public OLTProcessTestRunner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduler = new OLTProcessScheduler();
            scheduler.StartService();
        }
    }
}