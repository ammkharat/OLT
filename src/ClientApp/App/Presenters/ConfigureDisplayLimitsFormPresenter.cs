using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureDisplayLimitsFormPresenter
    {
        private const string ZERO = "0";

        private readonly IRoleElementService roleElementService;
        private readonly ISiteConfigurationService service;
        private readonly UserContext userContext;
        private readonly ISiteConfigurationFormView view;
        private bool isSaving;

        public ConfigureDisplayLimitsFormPresenter(ISiteConfigurationFormView view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>(),
            ClientServiceRegistry.Instance.GetService<IRoleElementService>())
        {
        }

        public ConfigureDisplayLimitsFormPresenter(ISiteConfigurationFormView view, ISiteConfigurationService service,
            IRoleElementService roleElementService)
        {
            this.view = view;
            this.service = service;
            this.roleElementService = roleElementService;
            userContext = ClientSession.GetUserContext();
        }

        private int DaysToDisplayActionItems
        {
            get { return ConvertToNumber(view.DaysToDisplayActionItems); }
        }

        private int DaysToDisplayShiftHandovers
        {
            get { return ConvertToNumber(view.DaysToDisplayShiftHandovers); }
        }

        private int DaysToDisplayDeviationAlerts
        {
            get { return ConvertToNumber(view.DaysToDisplayDeviationAlerts); }
        }

        private int DaysToDisplayWorkPermitsBackwards
        {
            get { return ConvertToNumber(view.DaysToDisplayWorkPermitsBackwards); }
        }

        private int DaysToDisplayWorkPermitsForwards
        {
            get
            {
                var days = view.DaysToDisplayWorkPermitsForwards;
                if (string.IsNullOrEmpty(days))
                {
                    return 0;
                }
                if (string.IsNullOrEmpty(days.Trim()))
                {
                    return 0;
                }
                return ConvertToNumber(days);
            }
        }

        private int DaysToDisplayLabAlerts
        {
            get { return ConvertToNumber(view.DaysToDisplayLabAlerts); }
        }

        private int? DaysToDisplayEvents
        {
            get { return ConvertToNumber(view.DaysToDisplayEvents); }
        }

        private int DaysToDisplayCokerCards
        {
            get { return ConvertToNumber(view.DaysToDisplayCokerCards); }
        }

        private int DaysToDisplayShiftLogs
        {
            get { return ConvertToNumber(view.DaysToDisplayShiftLogs); }
        }

        private int DaysToDisplayPermitRequestsBackwards
        {
            get { return ConvertToNumber(view.DaysToDisplayPermitRequestsBackwards); }
        }

        private int DaysToDisplayPermitRequestsForwards
        {
            get { return ConvertToNumber(view.DaysToDisplayPermitRequestsForwards); }
        }

        private int DaysToDisplayElectronicFormsBackwards
        {
            get { return ConvertToNumber(view.DaysToDisplayElectronicFormsBackwards); }
        }

        private int? DaysToDisplayDocumentSuggestionFormsForwards
        {
            get
            {
                var value = view.DaysToDisplayDocumentSuggestionFormsForwards;

                if (value.IsNullOrEmptyOrWhitespace())
                {
                    return null;
                }

                return ConvertToNumber(value);
            }
        }

        private int DaysToDisplayDocumentSuggestionFormsBackwards
        {
            get { return ConvertToNumber(view.DaysToDisplayDocumentSuggestionFormsBackwards); }
        }

        private int? DaysToDisplayElectronicFormsForwards
        {
            get
            {
                var value = view.DaysToDisplayElectronicFormsForwards;

                if (value.IsNullOrEmptyOrWhitespace())
                {
                    return null;
                }

                return ConvertToNumber(value);
            }
        }

        private int DaysToDisplayDirectivesBackwards
        {
            get { return ConvertToNumber(view.DaysToDisplayDirectivesBackwards); }
        }

        private int? DaysToDisplayDirectivesForwards
        {
            get
            {
                var value = view.DaysToDisplayDirectivesForwards;

                if (value.IsNullOrEmptyOrWhitespace())
                {
                    return null;
                }

                return ConvertToNumber(value);
            }
        }

        private int DaysToDisplaySAPNotificationsBackwards
        {
            get { return ConvertToNumber(view.DaysToDisplaySAPNotificationsBackwards); }
        }

        private bool ActionItemDaysAreValid
        {
            get { return DaysToDisplayActionItems > 0; }
        }

        private bool ShiftLogDaysAreValid
        {
            get { return DaysToDisplayShiftLogs > 0; }
        }

        private bool ShiftHandoversDaysAreValid
        {
            get { return DaysToDisplayShiftHandovers > 0; }
        }

        private bool DeviationAlertDaysAreValid
        {
            get { return DaysToDisplayDeviationAlerts > 0; }
        }

        private bool LabAlertDaysAreValid
        {
            get { return DaysToDisplayLabAlerts > 0; }
        }

        private bool DaysToDisplayEventsAreValid
        {
            get { return DaysToDisplayEvents == null || DaysToDisplayEvents > 0; }
        }

        private bool CokerCardDaysAreValid
        {
            get { return DaysToDisplayCokerCards > 0; }
        }

        private bool AllDaysAreValid
        {
            get
            {
                return
                    ActionItemDaysAreValid &&
                    ShiftLogDaysAreValid &&
                    ShiftHandoversDaysAreValid &&
                    DeviationAlertDaysAreValid &&
                    LabAlertDaysAreValid &&
                    CokerCardDaysAreValid;
            }
        }

        public void LoadForm(object sender, EventArgs e)
        {
            view.SiteName = userContext.Site.Name;
            var siteConfiguration = service.QueryBySiteIdWithNoCaching(userContext.SiteId);
            view.DaysToDisplayActionItems = siteConfiguration.DaysToDisplayActionItems.ToString();
            view.DaysToDisplayShiftLogs = siteConfiguration.DaysToDisplayShiftLogs.ToString();
            view.DaysToDisplayShiftHandovers = siteConfiguration.DaysToDisplayShiftHandovers.ToString();
            view.DaysToDisplayDeviationAlerts = siteConfiguration.DaysToDisplayDeviationAlerts.ToString();
            view.DaysToDisplayWorkPermitsBackwards = siteConfiguration.DaysToDisplayWorkPermitsBackwards.ToString();
            if (siteConfiguration.DaysToDisplayWorkPermitsForwards > 0)
            {
                view.DaysToDisplayWorkPermitsForwards = siteConfiguration.DaysToDisplayWorkPermitsForwards.ToString();
            }
            else
            {
                view.DaysToDisplayWorkPermitsForwards = "";
            }
            view.DaysToDisplayLabAlerts = siteConfiguration.DaysToDisplayLabAlerts.ToString();
            view.DaysToDisplayCokerCards = siteConfiguration.DaysToDisplayCokerCards.ToString();
            view.DaysToDisplayPermitRequestsBackwards =
                siteConfiguration.DaysToDisplayPermitRequestsBackwards.ToString();
            view.DaysToDisplayPermitRequestsForwards = siteConfiguration.DaysToDisplayPermitRequestsForwards.ToString();
            view.DaysToDisplayDocumentSuggestionFormsBackwards = siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwards.ToString();
            view.DaysToDisplayDocumentSuggestionFormsForwards =
                siteConfiguration.DaysToDisplayDocumentSuggestionFormsForwards.ToString();
            view.DaysToDisplayElectronicFormsBackwards = siteConfiguration.DaysToDisplayFormsBackwards.ToString();
            view.DaysToDisplayElectronicFormsForwards = siteConfiguration.DaysToDisplayFormsForwards != null
                ? siteConfiguration.DaysToDisplayFormsForwards.ToString()
                : null;
            view.DaysToDisplaySAPNotificationsBackwards =
                siteConfiguration.DaysToDisplaySAPNotificationsBackwards.ToString();
            view.DaysToDisplayDirectivesBackwards = siteConfiguration.DaysToDisplayDirectivesBackwards.ToString();
            view.DaysToDisplayDirectivesForwards = siteConfiguration.DaysToDisplayDirectivesForwards != null
                ? siteConfiguration.DaysToDisplayDirectivesForwards.ToString()
                : null;
            view.DaysToDisplayEvents = siteConfiguration.DaysToDisplayEventsBackwards != null
                ? siteConfiguration.DaysToDisplayEventsBackwards.ToString()
                : null;

            var isSiteUsingRoleElement = roleElementService.IsSiteUsingRoleElement(userContext.Site,
                new List<RoleElement>
                {
                    RoleElement.VIEW_ACTIONITEM,
                    RoleElement.VIEW_COKER_CARD,
                    RoleElement.VIEW_RESTRICTION_REPORTING,
                    RoleElement.VIEW_LAB_ALERT_DEFINITIONS_AND_LAB_ALERTS,
                    RoleElement.VIEW_PERMIT,
                    RoleElement.VIEW_SHIFT_HANDOVER,
                    RoleElement.VIEW_LOG,
                    RoleElement.VIEW_LOG_BASED_DIRECTIVES,
                    RoleElement.VIEW_SUMMARY_LOG,
                    RoleElement.VIEW_FORM,
                    RoleElement.VIEW_DIRECTIVE_NAVIGATION,
                    RoleElement.VIEW_EVENTS_NAVIGATION,
                    RoleElement.VIEW_PRIORITIES_DOCUMENT_SUGGESTION_FORM
                });

            view.ActionItemConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_ACTIONITEM];
            view.CokerCardConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_COKER_CARD];
            view.DeviationConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_RESTRICTION_REPORTING];
            view.DocumentSuggestionConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_PRIORITIES_DOCUMENT_SUGGESTION_FORM];
            view.LabAlertConfigurationVisible =
                isSiteUsingRoleElement[RoleElement.VIEW_LAB_ALERT_DEFINITIONS_AND_LAB_ALERTS];
            view.PermitConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_PERMIT];
            view.ShiftHandoverConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_SHIFT_HANDOVER];
            view.LogConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_LOG] ||
                                           isSiteUsingRoleElement[RoleElement.VIEW_LOG_BASED_DIRECTIVES] ||
                                           isSiteUsingRoleElement[RoleElement.VIEW_SUMMARY_LOG];
            view.ElectronicFormsVisible = isSiteUsingRoleElement[RoleElement.VIEW_FORM];
            view.EventsConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_EVENTS_NAVIGATION];
            view.DirectiveConfigurationVisible = isSiteUsingRoleElement[RoleElement.VIEW_DIRECTIVE_NAVIGATION];
        }

        public void HandleSaveButtonClick(object sender, EventArgs e)
        {
            var siteId = userContext.SiteId;

            if (AllDaysAreValid)
            {
                isSaving = true;
                service.UpdateDisplayLimits(siteId,
                    DaysToDisplayActionItems,
                    DaysToDisplayShiftLogs,
                    DaysToDisplayShiftHandovers,
                    DaysToDisplayDeviationAlerts,
                    DaysToDisplayWorkPermitsBackwards,
                    DaysToDisplayWorkPermitsForwards,
                    DaysToDisplayLabAlerts,
                    DaysToDisplayCokerCards,
                    DaysToDisplayPermitRequestsBackwards,
                    DaysToDisplayPermitRequestsForwards,
                    DaysToDisplayElectronicFormsBackwards,
                    DaysToDisplayElectronicFormsForwards,
                    DaysToDisplaySAPNotificationsBackwards,
                    DaysToDisplayDirectivesBackwards,
                    DaysToDisplayDirectivesForwards,
                    DaysToDisplayEvents,
                    DaysToDisplayDocumentSuggestionFormsBackwards,
                    DaysToDisplayDocumentSuggestionFormsForwards);
                view.CloseForm();
            }
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            view.CloseForm();
        }

        public void HandleValidatingForDisplayLimits(object sender, CancelEventArgs e)
        {
            view.ClearErrors();

            if (!ActionItemDaysAreValid)
            {
                view.SetErrorForActionItems(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayActionItems = ZERO;
            }
            if (!ShiftLogDaysAreValid)
            {
                view.SetErrorForShiftLogs(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayShiftLogs = ZERO;
            }
            if (!ShiftHandoversDaysAreValid)
            {
                view.SetErrorForShiftHandovers(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayShiftHandovers = ZERO;
            }
            if (!DeviationAlertDaysAreValid)
            {
                view.SetErrorForDeviationAlerts(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayDeviationAlerts = ZERO;
            }
            if (!LabAlertDaysAreValid)
            {
                view.SetErrorForLabAlerts(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayLabAlerts = ZERO;
            }

            if (!DaysToDisplayEventsAreValid)
            {
                view.SetErrorForEvents(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayEvents = null;
            }
            if (!CokerCardDaysAreValid)
            {
                view.SetErrorForCokerCards(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayCokerCards = ZERO;
            }
        }

        public void FormClosing(object sender, CancelEventArgs e)
        {
            if (!isSaving)
                return;
        }

        private static int ConvertToNumber(string value)
        {
            int daysToDisplay;
            if (value.IsNullOrEmptyOrWhitespace())
                ZERO.TryParse(out daysToDisplay);
            else
            {
                value.TryParse(out daysToDisplay);
            }
            return daysToDisplay;
        }
    }
}