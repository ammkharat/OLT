using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public abstract class AbstractLogDefinitionPagePresenter
        : AbstractDeletableDomainPagePresenter<LogDefinitionDTO, LogDefinition, ILogDefinitionDetails, ILogDefinitionPage>
    {
        protected readonly ILogDefinitionService service;

        protected AbstractLogDefinitionPagePresenter(ILogDefinitionPage page) : base(
            page,
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            service = ClientServiceRegistry.Instance.GetService<ILogDefinitionService>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            page.Details.CustomFieldEntryClicked += CustomFieldEntryClicked;
        }

        private void CustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            LogDefinition log = QueryForFirstSelectedItem();
            
            IRunnablePresenter presenter = CustomFieldPresenterMaker.Create(service, customFieldEntry, log.WorkAssignment);
            presenter.Run(page.MainParentForm);
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.CustomFieldEntryClicked -= CustomFieldEntryClicked;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(LogDefinition item)
        {
            return new EditLogDefinitionHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(LogDefinition item)
        {
            return new LogDefinitionForm(item, item.LogType.Equals(LogType.Standard));
        }

        protected abstract bool IsAuthorizedToEdit(LogDefinitionDTO logDefinitionDto);
        protected abstract bool IsAuthorizedToCancel(List<LogDefinitionDTO> logDefinitionDtos);
        
        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            if (userRoleElements != null)
            {
                List<LogDefinitionDTO> selectedItems = page.SelectedItems;
                bool hasSingleItemSelected = selectedItems.Count == 1;
                bool hasItemsSelected = selectedItems.Count > 0;
                
                ILogDefinitionDetails details = page.Details;
                details.EditEnabled = hasSingleItemSelected && IsAuthorizedToEdit(page.FirstSelectedItem);
                details.DeleteEnabled = hasItemsSelected && IsAuthorizedToCancel(selectedItems);
                details.ViewEditHistoryEnabled = hasSingleItemSelected;
            }
        }

        // Overriding because Delete actually does a cancel in the case of a LogDefinition.
        public override void DeleteButton_Clicked()
        {
            bool confirmed = page.ShowOKCancelDialog(
                string.Format(StringResources.CancelItemDialogText, DomainObjectName),
                string.Format(StringResources.CancelItemDialogTitle, DomainObjectName));
            if (confirmed)
            {
                LockMultipleDomainObjects(Delete, () => page.CancelSuccessfulMessage());
            }
        }

        protected override void Delete(LogDefinition item)
        {
            item.LastModifiedBy = ClientSession.GetUserContext().User;
            item.LastModifiedDate = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Cancel, item, Clock.Now);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLogDefinitionCreated += repeater_Created;
            remoteEventRepeater.ServerLogDefinitionUpdated += repeater_Updated;
            remoteEventRepeater.ServerLogDefinitionRemoved += repeater_Removed;
            remoteEventRepeater.ServerLogCancelledRecurringDefinition += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLogDefinitionCreated -= repeater_Created;
            remoteEventRepeater.ServerLogDefinitionUpdated -= repeater_Updated;
            remoteEventRepeater.ServerLogDefinitionRemoved -= repeater_Removed;
            remoteEventRepeater.ServerLogCancelledRecurringDefinition -= repeater_Removed;
        }

        protected override LogDefinition QueryByDto(LogDefinitionDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override void SetDetailData(ILogDefinitionDetails details, LogDefinition value)
        {
            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            details.CreationDateTime = value.CreatedDateTime.ToLongDateAndTimeString();
            details.Comments = value.RtfComments;
            details.FunctionalLocations = value.FunctionalLocations;
            details.CreateALogForEachFunctionalLocation = value.CreateALogForEachFunctionalLocation;
            details.WorkAssignment = value.WorkAssignment == null ? WorkAssignment.NoneWorkAssignment.DisplayName : value.WorkAssignment.DisplayName;

            List<CustomField> customFields = value.CustomFields;

            if (customFields.Count > 0)
            {
                details.CustomFieldsPanelVisible = true;
                details.SetCustomFieldEntries(value.CustomFieldEntries, customFields);
            }
            else
            {
                details.CustomFieldsPanelVisible = false;
            }

            if (siteConfiguration.ShowFollowupOnLogForm || value.LogType == LogType.DailyDirective)
            {
                details.FollowupPanelVisible = true;
                details.ProcessControl = value.ProcessControlFollowUp;
                details.Operations = value.OperationsFollowUp;
                details.Inspection = value.InspectionFollowUp;
                details.Supervision = value.SupervisionFollowUp;
                details.EnvironmentalHealthAndSafety = value.EnvironmentalHealthSafetyFollowUp;
                details.OtherFollowUp = value.OtherFollowUp;
            }
            else
            {
                details.FollowupPanelVisible = false;
            }

            if (siteConfiguration.AllowCreateALogForEachSelectedFlocOnLogForm || value.LogType == LogType.DailyDirective)
            {
                details.MultipleFlocOptionsVisible = true;
            }
            else
            {
                details.MultipleFlocOptionsVisible = false;                
            }

            if (value.LogType == LogType.Standard)
            {
                if (siteConfiguration.CreateOperatingEngineerLogs)
                {
                    details.OptionsVisible = true;
                    details.OperatingEngineerLogDisplayText = siteConfiguration.OperatingEngineerLogDisplayName;
                    details.IsOperatingEngineerLog = value.IsOperatingEngineerLog;
                }
                else
                {
                    details.OptionsVisible = false;
                }
            }
            else
            {
                details.OptionsVisible = false;
            }

            details.DocumentLinks = value.DocumentLinks;
            details.RecurrenceStartDate =
                value.Schedule.StartDate == null ? null : value.Schedule.StartDate.ToString();

            details.RecurrenceEndDate =
                value.Schedule.EndDate == null ? null : value.Schedule.EndDate.ToString();

            details.RaiseStartTime = value.Schedule.StartTime == null ? null : value.Schedule.StartTime.ToString();

            details.RecurrencePattern = value.Schedule.RecurrencePatternString;
        }

        protected override LogDefinitionDTO CreateDTOFromDomainObject(LogDefinition item)
        {
            return new LogDefinitionDTO(item);
        }
    }
}