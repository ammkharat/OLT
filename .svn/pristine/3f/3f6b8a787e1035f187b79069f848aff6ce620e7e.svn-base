using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureDefaultTabsFormPresenter
    {
        private readonly Dictionary<SectionKey, List<PageKey>> sectionToPageMap = new Dictionary<SectionKey, List<PageKey>>();

        private readonly IConfigureDefaultTabsFormView view;
        private readonly IRoleService roleService;
        private readonly IRoleDisplayConfigurationService roleDisplayConfigurationService;        

        public ConfigureDefaultTabsFormPresenter(IConfigureDefaultTabsFormView view)
        {
            this.view = view;
            roleService = ClientServiceRegistry.Instance.GetService<IRoleService>();
            roleDisplayConfigurationService = ClientServiceRegistry.Instance.GetService<IRoleDisplayConfigurationService>();            
            PopulateSectionToPageMap();
        }

        private void PopulateSectionToPageMap()
        {
            foreach (PageKey pageKey in PageKey.All)
            {
                SectionKey key = pageKey.SectionKey;
                if (!sectionToPageMap.ContainsKey(key))
                {
                    sectionToPageMap.Add(key, new List<PageKey>());
                }
                sectionToPageMap[key].Add(pageKey);
            }
            foreach (List<PageKey> pageKeys in sectionToPageMap.Values)
            {
                pageKeys.Sort((x,y) => x.TabText.CompareTo(y.TabText));
            }
        }

        public void LoadForm(object sender, EventArgs e)
        {
            view.SiteName = ClientSession.GetUserContext().Site.Name;
            view.SectionToPageMap = sectionToPageMap;
            view.Configurations = GetConfigurations();
        }

        private List<RoleDisplayConfiguration> GetConfigurations()
        {
            List<RoleDisplayConfiguration> allConfigurations = new List<RoleDisplayConfiguration>();

            Site site = ClientSession.GetUserContext().Site;
            List<RoleDisplayConfiguration> existingConfigurations = roleDisplayConfigurationService.QueryBySite(site);
            List<Role> allRolesForSite = roleService.QueryRolesBySite(site);

            List<SectionKey> sectionsWithMoreThanOnePage = SectionKey.All.FindAll(HasMoreThanOnePage);

            foreach (Role role in allRolesForSite)
            {
                foreach (SectionKey sectionKey in sectionsWithMoreThanOnePage)
                {
                    RoleDisplayConfiguration existing = existingConfigurations.Find(
                        obj => obj.Role.Id == role.Id && obj.SectionKey.Id == sectionKey.Id);

                    if (existing != null)
                    {
                        allConfigurations.Add(existing);
                    }
                    else
                    {
                        allConfigurations.Add(new RoleDisplayConfiguration(null, role, sectionKey, null, null));
                    }
                }                
            }

            return allConfigurations;
        }

        private bool HasMoreThanOnePage(SectionKey sectionKey)
        {
            if (sectionToPageMap.ContainsKey(sectionKey) &&
                sectionToPageMap[sectionKey].Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void HandleSaveButtonClick(object sender, EventArgs e)
        {
            List<RoleDisplayConfiguration> configurations = new List<RoleDisplayConfiguration>(view.Configurations);
            configurations.RemoveAll(obj => obj.PrimaryPageKey == null && obj.SecondaryPageKey == null);
            foreach (RoleDisplayConfiguration configuration in configurations)
            {
                if (configuration.PrimaryPageKey == null && configuration.SecondaryPageKey != null)
                {
                    configuration.PrimaryPageKey = configuration.SecondaryPageKey;
                    configuration.SecondaryPageKey = null;
                }
            }
            roleDisplayConfigurationService.DeleteAllAndInsertNew(
                ClientSession.GetUserContext().Site,
                configurations);
            view.Close();
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}
