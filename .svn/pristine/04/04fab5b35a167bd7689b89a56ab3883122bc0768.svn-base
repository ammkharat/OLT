using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SAPNotificationFormPresenter : AbstractFormPresenter<ISAPNotificationFormView, SAPNotification>
    {
        private readonly ISAPNotificationService sapNotificationService;
        private bool importSAPNotification = true;
        private bool importSAPNotificationAndCreateOperatingEngineerLog;

        public SAPNotificationFormPresenter(ISAPNotificationFormView view, SAPNotification sapNotification) : this(
            view,
            sapNotification, 
            ClientServiceRegistry.Instance.GetService<ISAPNotificationService>())
        {
        }

        public SAPNotificationFormPresenter(
            ISAPNotificationFormView view, 
            SAPNotification sapNotification, 
            ISAPNotificationService sapNotificationService)
            : base(view, sapNotification)
        {
            this.sapNotificationService = sapNotificationService;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            UpdateViewFromEditObject();            
        }

        private void UpdateViewFromEditObject()
        {
            SiteConfiguration siteConfig = userContext.SiteConfiguration;
            
            view.CreateDateTime = editObject.CreationDateTime;
            view.ShiftPatternName = userContext.UserShift.ShiftPatternName;
            view.Author = userContext.User;
            view.FunctionalLocationName = editObject.FunctionalLocation.FullHierarchy;
            view.NotificationNumber = editObject.NotificationNumber;
            view.NotificationType = editObject.NotificationType;
            view.IncidentId = editObject.IncidentId;
            view.PreviousDescription = BuildAndFormatPreviousDescription(editObject);
            
            if (!siteConfig.CreateOperatingEngineerLogs)
            {
                view.HideSaveAndImportAsOperatingEngineer();
            }
            
            // LOCALIZATION TODO: look at this when doing the designer side, because the button is barely big enough and should probably be made bigger.
            string saveAndImportText =
                string.Format(StringResources.SAPNotificationFormPresenter_SaveAndImportAsEngineer,
                              siteConfig.OperatingEngineerLogDisplayName);
            view.SaveAndImportAsOperatingEnginnerText = saveAndImportText; //"Save && Import as &" + siteConfig.OperatingEngineerLogDisplayName;
        }

        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            if (view.Comments.HasEmptyValue())
            {
                view.SetCommentsBlankError(true);
                return true;
            }
            return false;
        }

        private static string BuildAndFormatPreviousDescription(SAPNotification sapNotification)
        {
            return sapNotification.BuildAndFormatLogDescription();
        }

        public override bool IsEdit
        {
            get { return importSAPNotification; }
        }

        public override void Insert(SaveUpdateDomainObjectContainer<SAPNotification> container)
        {
            // This isn't doing an insert, its actually an UpdateAndImport but by overiding the IsEdit and using this it can still use the template method in the abstractFormPresenter             
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                sapNotificationService.ProcessNotificationAndCreateLog,
                editObject,
                userContext.User,
                userContext.UserShift.ShiftPattern,
                importSAPNotificationAndCreateOperatingEngineerLog,
                userContext.Role,
                userContext.Assignment);
        }

        public override void Update(SaveUpdateDomainObjectContainer<SAPNotification> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(sapNotificationService.UpdateByNotificationNumber, editObject);
        }

        protected override SaveUpdateDomainObjectContainer<SAPNotification> GetNewObjectToInsert()
        {
            // The user entered comments are prepended to the previous notification's comments
            editObject.PrependNewComments(view.Comments, view.CreateDateTime);
            return new SaveUpdateDomainObjectContainer<SAPNotification>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<SAPNotification> GetPopulatedEditObjectToUpdate()
        {
            // The user entered comments are prepended to the previous notification's comments
            editObject.PrependNewComments(view.Comments, view.CreateDateTime);
            return new SaveUpdateDomainObjectContainer<SAPNotification>(editObject);
        }
            
        public void UpdateAndImport(object sender, EventArgs e)
        {
            importSAPNotificationAndCreateOperatingEngineerLog = false;
            importSAPNotification = false;
            SaveOrUpdate(true);
        }

        public void UpdateAndImportAsOperatingEngineerLog(object sender, EventArgs e)
        {
            importSAPNotificationAndCreateOperatingEngineerLog = true;
            importSAPNotification = false;
            SaveOrUpdate(true);
        }
    }
}