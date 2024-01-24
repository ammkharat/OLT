using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class RtfReportsPage : UserControl, IReportsPage
    {
        private readonly SplashScreenManager splashScreenManager;

        public RtfReportsPage()
        {
            InitializeComponent();
            InitializeEvents();
            Dock = DockStyle.Fill;
            splashScreenManager = new SplashScreenManager(ParentForm, typeof (WaitForm), true, true);
    
        }

        public event EventHandler RunReportClicked;

        public string Title
        {
            get { return Text; }
            set
            {
                Text = value;
                reportNameLabel.Text = value;
            }
        }

        public XtraReport Report { set { embeddedRtfPrintControl.ReportSource = value; } }

        public IReportParametersControl ParametersControl
        {
            set
            {
                splitContainer.Panel1.Controls.Clear();
                var control = value as Control;

                if (control != null)
                {
                    control.Dock = DockStyle.Fill;

                    splitContainer.SplitterDistance = control.Height;
                    splitContainer.Panel1MinSize = 90;
                    splitContainer.Panel1.Controls.Add(control);
                }
            }
        }

        public void DisplayErrorMessage(string message)
        {
            OltMessageBox.Show(Form.ActiveForm, message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void InitializeEvents()
        {
            runReportButton.Click += OnReportRun;
        }

        private void OnReportRun(object sender, EventArgs e)
        {
            if (null != RunReportClicked)
            {
                splashScreenManager.ShowWaitForm();
                RunReportClicked(sender, e);
                splashScreenManager.CloseWaitForm();
                splashScreenManager.WaitForSplashFormClose();
            }
        }
    }
}