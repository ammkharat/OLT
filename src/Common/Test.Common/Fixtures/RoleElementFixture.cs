using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class RoleElementFixture
    {
        public static RoleElement CreateRole()
        {
            return new RoleElement("A fake RoleElement");
        }

        public static RoleElement CreateApproveActionRole()
        {
            return RoleElement.APPROVE_ACTIONITEMDEFINITION;
        }

        public static RoleElement CreateCreateActionRole()
        {
            return RoleElement.CREATE_ACTIONITEMDEFINITION;
        }

        public static RoleElement CreateUpdateActionRole()
        {
            return RoleElement.EDIT_ACTIONITEMDEFINITION;
        }

        public static RoleElement CreateViewActionRole()
        {
            return RoleElement.VIEW_ACTIONITEMDEFINITION;
        }

        public static List<RoleElement> CreateListOfRoles()
        {
            List<RoleElement> roles = new List<RoleElement>
                                                    {
                                                        CreateCreateActionRole(),
                                                        CreateApproveActionRole(),
                                                        CreateUpdateActionRole(),
                                                        CreateViewActionRole()
                                                    };
            return roles;
        }

    }
}