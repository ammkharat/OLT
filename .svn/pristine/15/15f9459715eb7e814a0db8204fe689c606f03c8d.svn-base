using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Utility
{
    public enum RoleElementChangeType
    {
        Add,
        Delete
    }

    [Serializable]
    public class RoleElementChange
    {
        private const string Delete =
            "DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = {0} and r.[Name] = '{1}') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('{2}'));";

        private const string Insert =
            "INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = {0} and r.[Name] = '{1}' and re.[Name] = '{2}';";

        private readonly RoleElementChangeType changeType;
        private readonly string role;
        private readonly string roleElement;

        public RoleElementChange(string role, string roleElement, RoleElementChangeType changeType, Site site)
        {
            Site = site;
            this.role = role;
            this.changeType = changeType;
            this.roleElement = roleElement;
        }

        public Site Site { get; private set; }

        public bool IsAdd
        {
            get { return changeType == RoleElementChangeType.Add; }
        }

        public bool IsDelete
        {
            get { return changeType == RoleElementChangeType.Delete; }
        }

        public string ChangeTypeName
        {
            get { return changeType.ToString(); }
        }

        public string Role
        {
            get { return role; }
        }

        public string RoleElement
        {
            get { return roleElement; }
        }

        public string ConvertToSql()
        {
            return
                string.Format(
                    IsAdd
                        ? Insert
                        : Delete, Site.IdValue, role, roleElement);
        }
    }
}