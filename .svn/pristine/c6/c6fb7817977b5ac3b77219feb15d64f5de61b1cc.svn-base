using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureActionItemsFormPresenter
    {
        private readonly IConfigureActionItemsForm view;
        private readonly ISiteConfigurationService service;
        private readonly UserContext userContext;
        
        public ConfigureActionItemsFormPresenter(IConfigureActionItemsForm view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>())
        {
            
        }

        public ConfigureActionItemsFormPresenter(
            IConfigureActionItemsForm view,
            ISiteConfigurationService service)
        {
            this.view = view;
            this.service = service;
            userContext = ClientSession.GetUserContext();
        }

        public void HandleFormLoad(object senter, EventArgs args)
        {
            SiteConfiguration configuration = service.QueryBySiteIdWithNoCaching(userContext.SiteId);

            view.SiteName = userContext.Site.Name;
            view.AutoApproveWorkOrderActionItemDefinition = configuration.AutoApproveWorkOrderActionItemDefinition;
            view.AutoApproveSAPAMActionItemDefinition = configuration.AutoApproveSAPAMActionItemDefinition;
            view.AutoApproveSAPMCActionItemDefinition = configuration.AutoApproveSAPMCActionItemDefinition;
            view.LogRequiredForActionItemResponse = configuration.RequireLogForActionItemResponse;
            view.RequiresApprovalDefaultValue = configuration.ActionItemRequiresApprovalDefaultValue;
            view.RequiresResponseDefaultValue = configuration.ActionItemRequiresResponseDefaultValue;
        }

        public void HandleSaveButtonClick(object sender, EventArgs args)
        {
            bool autoApproveWorkOrderAID = view.AutoApproveWorkOrderActionItemDefinition;
            bool autoApproveSAPAMAID = view.AutoApproveSAPAMActionItemDefinition;
            bool autoApproveSAPMCAID = view.AutoApproveSAPMCActionItemDefinition;
            bool logRequiredForActionItemResponse = view.LogRequiredForActionItemResponse;
            bool requiresApprovalDefaultValue = view.RequiresApprovalDefaultValue;
            bool requiresResponseDefaultValue = view.RequiresResponseDefaultValue;

            service.UpdateActionItemSettings(
                userContext.SiteId, autoApproveWorkOrderAID, autoApproveSAPAMAID, 
                    autoApproveSAPMCAID, logRequiredForActionItemResponse, 
                    requiresApprovalDefaultValue, requiresResponseDefaultValue);

            view.Close();
        }

        public void HandleCancelButtonClick(object sender, EventArgs args)
        {
            view.Close();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "Configure Auto Approve SAP Action Item Definition " + site.IdValue;
        }
    }
}
