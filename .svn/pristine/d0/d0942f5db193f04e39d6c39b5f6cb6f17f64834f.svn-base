using System.Threading;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ImportPermitRequestMultiDayProgressForm : BaseForm
    {
        private bool isWorkDone;

        public ImportPermitRequestMultiDayProgressForm()
        {
            InitializeComponent();
            progressBar.Step = 1;
            progressBar.Value = 0;
        }

        public int Maximum
        {
            set { progressBar.Maximum = value; }
        }

        public void SetProgressBarValue(int value)
        {
            progressBar.Value = value;
        }

        public bool IsWorkDone
        {            
            set { isWorkDone = value; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isWorkDone)
            {
                base.OnFormClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void WaitABit()
        {
            Thread.Sleep(1000);
        }
    }
}