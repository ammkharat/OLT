using System.ComponentModel;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Domain
{
    public class RoleElementChangeDisplayAdapter
    {
        private readonly RoleElementChange change;

        public RoleElementChangeDisplayAdapter(RoleElementChange change)
        {
            this.change = change;
            Selected = true;
        }

        public bool Selected { get; set; }

        public static string ChangeTypeGridKey = "ChangeType";
        public string ChangeType 
        { 
            get { return change.ChangeTypeName; }
        }

        public string Role
        {
            get { return change.Role; }
        }

        public string RoleElement
        {
            get { return change.RoleElement; }
        }

        [Browsable(false)]
        public RoleElementChange RoleElementChange
        {
            get { return change; }
        }
    }
}
