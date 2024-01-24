using System;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraSplashScreen;

namespace Com.Suncor.Olt.Client
{
    public partial class OLTSplashScreen : SplashScreen
    {
        public OLTSplashScreen()
        {
            InitializeComponent();

            labelControl.Text = StringResources.StartingOLT;
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}