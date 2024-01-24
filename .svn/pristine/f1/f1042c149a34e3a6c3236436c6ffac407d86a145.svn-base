using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SapAutoImportConfigurationPresenter : BaseFormPresenter<ISapAutoImportConfigurationView>
    {
        private readonly Site site;
        private readonly ISiteConfigurationService siteConfigurationService;
        
        public SapAutoImportConfigurationPresenter(ISapAutoImportConfigurationView view, Site site) : base(view)
        {
            this.site = site;
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            view.Load += HandleViewLoad;
            view.Save += HandleSave;
        }

        private void HandleViewLoad(object sender, EventArgs eventArgs)
        {
            SapAutoImportConfiguration configuration = siteConfigurationService.QuerySapAutoImportConfiguration(site.IdValue);

            if (configuration.ImportTime == null)
            {
                view.ImportTime = new Time(17, 0);
            }
            else
            {
                view.ImportTime = configuration.ImportTime;    
            }
            
            view.IsEnabled = configuration.IsEnabled;
            view.TimePickerEnabled = configuration.IsEnabled;
        }

        private void HandleSave()
        {
            if (view.IsEnabled)
            {                
                siteConfigurationService.EnableOrUpdateSapAutoImportConfiguration(site.IdValue, view.ImportTime);
            }
            else
            {
                siteConfigurationService.DisableSapAutoImportConfiguration(site.IdValue);
            }

            view.Close();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return String.Format("SAP Auto Import Configuration - {0}", site.IdValue);
        }
    }
}
