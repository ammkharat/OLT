using System.ComponentModel;
using System.Configuration.Install;

namespace RemoteApp.OLTProcess.Scheduler
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}