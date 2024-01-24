using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltLastModifiedDateAuthorHeader : UserControl
    {
        private DateTime lastModifiedDate;

        public OltLastModifiedDateAuthorHeader()
        {
            InitializeComponent();
        }

        public DateTime LastModifiedDate
        {
            set
            {
                lastModifiedDate = value;
                lastModifiedData.Text = lastModifiedDate.ToLongDateAndTimeString();
            }
            get { return lastModifiedDate; }
        }

        public User LastModifiedUser
        {
            set { lastModifiedUserData.Text = value.FullNameWithUserName; }
        }
    }
}