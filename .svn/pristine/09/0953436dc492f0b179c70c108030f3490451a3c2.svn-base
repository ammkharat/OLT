using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public class RoleElementTemplateValuesContainer
    {
        private readonly Dictionary<Role, List<RoleElement>> roles = new Dictionary<Role, List<RoleElement>>();

        public void Add(RoleElementTemplateValue value)
        {
            var role = value.Role;
            if (!roles.ContainsKey(role))
            {
                roles.Add(role, new List<RoleElement>());
            }
            var roleElements = roles[role];
            roleElements.Add(value.RoleElement);
        }

        public void AddRange(List<RoleElementTemplateValue> values)
        {
            foreach (var roleElementTemplateValue in values)
            {
                Add(roleElementTemplateValue);
            }
        }

        public bool HasRoleElement(Role role, RoleElement roleElement)
        {
            if (!roles.ContainsKey(role))
            {
                return false;
            }
            return roles[role].Exists(re => Equals(re, roleElement));
        }

        public List<RoleElementTemplateValue> GetItemsInThisThatAreNotIn(RoleElementTemplateValuesContainer roleValues)
        {
            var @this = roles.ConvertEachKeyValue();
            var that = roleValues.roles.ConvertEachKeyValue();

            var notInSecondList = @this.FindAll(item => that.DoesNotHave(other => other.Equals(item)));

            return
                notInSecondList.ConvertAll(
                    keyValuePair => new RoleElementTemplateValue(keyValuePair.Key, keyValuePair.Value));
        }
    }
}