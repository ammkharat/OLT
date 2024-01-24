using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureWorkAssignmentNotSelectedWarningFormView
    {
        string SiteName { set; }
        IList<Role> Roles { get; set; }
        void Close();
    }
}
