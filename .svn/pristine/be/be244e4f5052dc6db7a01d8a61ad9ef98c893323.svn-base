using Com.Suncor.Olt.Client.Presenters.Section;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IMainFormSecurityManager
    {
        CreateAction GetActionForSelectedSection(UserRoleElements userRoleElements, ISectionRegistry sectionRegistry);
        void ApplySecurityToMenuItems(UserRoleElements userRoleElements, SiteConfiguration siteConfiguration);
        void AddNavigationSections(SiteConfiguration siteConfiguration, UserRoleElements userRoleElements);
    }
}