using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public partial class ReportPrintPreviewForm : XtraForm, IReportPrintPreviewView
    {
        public event Action OnPrintButtonClicked;
        
        public event EventHandler OnFormLoad;

        private XtraReport report;

        public ReportPrintPreviewForm()
        {
            InitializeComponent();            
            InitializeFormEvents();
        }

        private void InitializeFormEvents()
        {
            embeddedRtfPrintControl.Print += Print;
        }

        private void RemoveAllCurrentFormEvents()
        {
            embeddedRtfPrintControl.Print -= Print;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                RemoveAllCurrentFormEvents();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Print(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoNothing;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnPrintButtonClicked != null)
            {
                OnPrintButtonClicked();
            }
        }

        // This is because the ToolStripButton (that we use for the print button) doesn't return from its click event. It's a known issue on the internets.
        // For some reason, having the event kick off a dummy background thread and then return works. You can't run the printing in the background thread. Print
        // Dialogs have to be kicked off on the UI thread. I tried to do the whole thing in the background for a while and it ended badly. (Dustin, Nov 2012)
        private void DoNothing(object sender, DoWorkEventArgs e)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (OnFormLoad != null)
            {
                splashScreenManager.ShowWaitForm();
                OnFormLoad(this, e);
                splashScreenManager.CloseWaitForm();
                splashScreenManager.WaitForSplashFormClose();
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (splashScreenManager.IsSplashFormVisible)
            {
                splashScreenManager.CloseWaitForm();
            }
        }

        public XtraReport Report
        {
            set
            {
                if (value != null)
                {
                    report = value;
                    embeddedRtfPrintControl.ReportSource = report;
                }
            }
        }

        public string Title
        {
            set { Text = value; }
        }


    }

    public interface IReportPrintPreviewView
    {
        event EventHandler OnFormLoad;
        event Action OnPrintButtonClicked;
        XtraReport Report { set; }
        DialogResult ShowDialog();
        string Title { set; }
    }
}