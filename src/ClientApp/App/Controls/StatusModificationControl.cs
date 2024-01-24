using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class StatusModificationControl : UserControl
    {
        public StatusModificationControl()
        {
            InitializeComponent();
        }
        
        public string ModificationUser
        {
            set { modificationUser.Text = value; }   
        }

        public string ModificationDateTime
        {
            set { modificationDateTime.Text = value; }   
        }

        public string PreviousStatus
        {
            set { previousStatus.Text = value; }   
        }
    }
}
