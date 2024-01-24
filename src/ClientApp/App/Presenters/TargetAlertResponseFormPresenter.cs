using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TargetAlertResponseFormPresenter
    {
        private const string NEW_RESPONSE_TEMPLATE = @"{0}

{1}
{2}";
        public static readonly string FORM_TITLE = StringResources.TargetAlertResponseFormTitleNew;

        private static readonly string DESCRIPTION_TEMPLATE = StringResources.TargetAlertResponseDescriptionTemplate;

        private readonly ISingleSelectFunctionalLocationSelectionForm flocSelectionView;
        private readonly ITargetAlertService targetAlertService;
        private readonly List<TargetAlert> targetAlerts;

        private readonly UserContext userContext;
        private readonly ITargetAlertResponseFormView view;
        private FunctionalLocation responsibleFunctionalLocation;

        public TargetAlertResponseFormPresenter(ITargetAlertResponseFormView view,
            ISingleSelectFunctionalLocationSelectionForm flocSelectionView,
            List<TargetAlert> targetAlerts
            ) : this(view,
                flocSelectionView,
                targetAlerts,
                ClientServiceRegistry.Instance.GetService<ITargetAlertService>()
                )
        {
        }

        public TargetAlertResponseFormPresenter
            (
            ITargetAlertResponseFormView view,
            ISingleSelectFunctionalLocationSelectionForm flocSelectionView,
            List<TargetAlert> targetAlerts,
            ITargetAlertService targetAlertService
            )
        {
            this.view = view;
            this.flocSelectionView = flocSelectionView;
            this.targetAlerts = targetAlerts;
            this.targetAlertService = targetAlertService;
            userContext = ClientSession.GetUserContext();
            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.LoadView += LoadView;
            view.SearchFunctionalLocation += SearchFunctionalLocation;
            view.CreateResponse += CreateResponse;
            view.CancelResponse += CancelResponse;
            view.ClearFunctionalLocation += ClearFunctionalLocation;
            view.OnCreateLogCheckChanged += CreateLogCheckChanged;
        }

        private void CreateLogCheckChanged(object sender, EventArgs e)
        {
            view.EnableMakingAnOperatingEngineerLog(userContext.SiteConfiguration.CreateOperatingEngineerLogs);
        }

        public void LoadView(object sender, EventArgs e)
        {
            view.Title = FORM_TITLE;
            view.TargetNameLabel = StringResources.TargetAlertResponseFormTargetLabel;
            view.TargetSummaryLabel = StringResources.TargetAlertResponseFormTargetSummaryLabel;


            view.GapReasonChoices = TargetGapReason.AllWithEmpty;
            view.Comment = string.Empty;
            view.CreateLogChecked = userContext.Assignment != null &&
                                    userContext.Assignment.CopyTargetAlertResponseToLog;

            // Contextual information about what target alert we're responding to:
            view.CreateDateTime = Clock.Now;
            view.ShiftPatternName = userContext.UserShift.ShiftPatternName;
            view.Author = ClientSession.GetUserContext().User;

            if (targetAlerts.Count == 1)
            {
                SetTargetInView(targetAlerts[0]);
            }
            else
            {
                view.HideDetails();
            }
            view.EnableMakingAnOperatingEngineerLog(userContext.SiteConfiguration.CreateOperatingEngineerLogs);
            view.OperatingEngineerLogDisplayText = userContext.SiteConfiguration.OperatingEngineerLogDisplayName;

            view.IsLogAnOperatingEngineeringLog = false;
        }

        private void SetTargetInView(TargetAlert targetAlert)
        {
            view.TargetName = targetAlert.TargetName;
            view.CategoryName = targetAlert.Category.Name;
            view.TargetDefinitionAuthor = targetAlert.TargetDefinition.LastModifiedBy.FullNameWithUserName;
            view.FunctionalLocationName = targetAlert.FunctionalLocation.FullHierarchy;
            view.FunctionalLocationDescription = targetAlert.FunctionalLocation.Description;
            view.MeasurementTagName = targetAlert.Tag.Name;
            view.Description = BuildDescriptionString(targetAlert);

            // Threshold values:
            view.MeasurementTagUnit = targetAlert.Tag.Units;
            view.NeverToExceedMaximum = targetAlert.NeverToExceedMaximum;
            view.MaxValue = targetAlert.MaxValue;
            view.MinValue = targetAlert.MinValue;
            view.NeverToExceedMinimum = targetAlert.NeverToExceedMinimum;
            view.TargetValue = targetAlert.TargetValue.Title;
        }

        private static string BuildDescriptionString(TargetAlert targetAlert)
        {
            return string.Format
                (
                    DESCRIPTION_TEMPLATE,
                    targetAlert.TargetName,
                    targetAlert.Category.Name,
                    (targetAlert.LastModifiedBy == null) ? "(null)" : targetAlert.LastModifiedBy.FullNameWithUserName,
                    targetAlert.FunctionalLocation.FullHierarchy,
                    targetAlert.Tag.Name,
                    targetAlert.MaxValue,
                    targetAlert.MinValue,
                    targetAlert.NeverToExceedMaximum,
                    targetAlert.NeverToExceedMinimum,
                    targetAlert.TargetValue.Title,
                    targetAlert.ActualValue + " " + targetAlert.Tag.Units,
                    targetAlert.GapUnitValue,
                    targetAlert.Description
                );
        }

        private void SearchFunctionalLocation(object sender, EventArgs e)
        {
            if (flocSelectionView.ShowDialog(view as Form) == DialogResult.OK)
            {
                responsibleFunctionalLocation = flocSelectionView.SelectedFunctionalLocation;
                view.ResponsibleFunctionalLocationText = responsibleFunctionalLocation.FullHierarchy;
            }
        }

        private void ClearFunctionalLocation(object sender, EventArgs e)
        {
            responsibleFunctionalLocation = null;
            view.ResponsibleFunctionalLocationText = string.Empty;
        }

        private void CreateResponse(object sender, EventArgs e)
        {
            var responseIsValid = ValidateResponseAndDisplayErrors();

            if (responseIsValid)
            {
                foreach (var targetAlert in targetAlerts)
                {
                    SetTargetInView(targetAlert);
                    var response = AssembleTargetAlertResponseFromView(targetAlert);
                    targetAlert.Acknowledge(ClientSession.GetUserContext().User, Clock.Now);
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                        targetAlertService.CreateTargetAlertResponse,
                        response,
                        view.CreateLogChecked,
                        view.IsLogAnOperatingEngineeringLog,
                        userContext.User,
                        userContext.UserShift.ShiftPattern,
                        userContext.Role,
                        userContext.Assignment);
                }

                view.Close();
            }
        }

        public void CancelResponse(object sender, EventArgs e)
        {
            if (view.ShowConfirmationDialog())
            {
                view.Close();
            }
        }

        private bool ValidateResponseAndDisplayErrors()
        {
            view.ClearErrorProviders();

            var responseIsValid = true;

            if (targetAlerts.Any(alert => alert.RequiresResponse))
            {
                if (view.GapReason == null || view.GapReason == TargetGapReason.Null)
                {
                    view.ShowGapReasonRequiredError();
                    responseIsValid = false;
                }
            }

            return responseIsValid;
        }

        private TargetAlertResponse AssembleTargetAlertResponseFromView(TargetAlert targetAlert)
        {
            var responseText = string.Format(NEW_RESPONSE_TEMPLATE, view.Comment,
                StringResources.TargetAlertResponseTemplateLabel, view.Description);

            var currentShiftPattern = userContext.UserShift.ShiftPattern;

            var response = targetAlert.CreateResponse(ClientSession.GetUserContext().User,
                responseText, view.CreateDateTime, currentShiftPattern);
            response.GapReason = view.GapReason;
            response.ResponsibleForGap = responsibleFunctionalLocation;
            return response;
        }
    }
}