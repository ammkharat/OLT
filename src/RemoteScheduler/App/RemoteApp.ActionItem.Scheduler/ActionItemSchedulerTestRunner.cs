using System;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Remote.Scheduling.Services
{
    public partial class ActionItemSchedulerTest : Form
    {
        private ActionItemScheduler scheduler;

        public ActionItemSchedulerTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Red;
            scheduler = new ActionItemScheduler();
            scheduler.StartService();
        }
    }
}