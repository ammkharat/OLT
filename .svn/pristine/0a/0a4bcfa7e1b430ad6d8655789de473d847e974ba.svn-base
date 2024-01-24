using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PriorityCriteriaFormPresenter : BaseFormPresenter<IPriorityPageCriteriaView>
    {
        private const string ZERO = "0";

        private readonly ISiteConfigurationService service;
        private readonly UserContext userContext;

        public PriorityCriteriaFormPresenter() : base(new PriorityPageCriteriaForm())
        {
            service = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            userContext = ClientSession.GetUserContext();

            view.FormLoad += HandleFormLoad;
            view.SaveButtonClick += HandleSaveButtonClick;
        }

        private int DaysToDisplayDirectives
        {
            get { return ConvertToNumber(view.DaysToDisplayDirectives); }
        }

        private int DaysToDisplayShiftHandovers
        {
            get { return ConvertToNumber(view.DaysToDisplayShiftHandovers); }
        }

        private int DaysToDisplayForms
        {
            get { return ConvertToNumber(view.DaysToDisplayForms); }
        }

        private int DaysToDisplayDocumentSuggestions
        {
            get { return ConvertToNumber(view.DaysToDisplayDocumentSuggestions); }
        }

        private int MaximumAllowableExcursionEventDurationMins
        {
            get { return ConvertToNumber(view.MaximumAllowableExcursionEventDurationMins); }
        }

        private int MaximumAllowableExcursionEventTimeframeMins
        {
            get { return ConvertToNumber(view.MaximumAllowableExcursionEventTimeframeMins); }
        }

        private int? DaysToDisplayIncompleteActionItems
        {
            get
            {
                if (view.DisplayIncompleteActionItemsFromPreviousShift)
                {
                    return null;
                }
                return ConvertToNumber(view.DaysToDisplayIncompleteActionItems);
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Priorities Page Criteria: Site {0}", site.IdValue);
        }

        public void HandleFormLoad()
        {
            view.SiteName = userContext.Site.Name;
            var siteConfiguration = service.QueryBySiteIdWithNoCaching(userContext.SiteId);

            view.ShowActionItemsByWorkAssignment = siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage;
            view.ShowShiftHandoversByWorkAssignment = siteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage;
            view.DaysToDisplayDirectives = siteConfiguration.DaysToDisplayDirectivesOnPriorityPage.ToString();
            view.DaysToDisplayShiftHandovers = siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage.ToString();
            view.DisplayActionItemWorkAssignment = siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage;
            view.DaysToDisplayForms = siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage.ToString();
            view.DaysToDisplayDocumentSuggestions =
                siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage.ToString();
            view.MaximumAllowableExcursionEventDurationMins = siteConfiguration.MaximumAllowableExcursionEventDurationMins.ToString();
            view.MaximumAllowableExcursionEventTimeframeMins = siteConfiguration.MaximumAllowableExcursionEventTimeframeMins.ToString();

            if (siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage == null)
            {
                view.DisplayIncompleteActionItemsFromPreviousShift = true;
            }
            else
            {
                view.DaysToDisplayIncompleteActionItems =
                    siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage.ToString();
            }

            if (!(userContext.IsEdmontonSite || userContext.IsLubesSite || userContext.IsMontrealSite))
            {
                view.HideElectronicFormsGroupBox();
            }

            if (
                !(userContext.IsWoodBuffaloRegionSite &&
                  userContext.UserRoleElements.AuthorizedTo(RoleElement.VIEW_PRIORITIES_DOCUMENT_SUGGESTION_FORM)))
            {
                view.HideDocumentSuggestionFormsGroupBox();                
            }

            if (!userContext.SiteConfiguration.UseLogBasedDirectives)
            {
                view.HideDirectiveLogsGroupBox();
            }

            if (!userContext.UserRoleElements.AuthorizedTo(RoleElement.VIEW_EVENTS_NAVIGATION))
            {
                view.HideExcursionEventsGroupBox();                
            }
        }

        public void HandleSaveButtonClick()
        {
            var hasErrors = Validate();

            if (hasErrors)
            {
                return;
            }

            var showActionItemsByWorkAssignment = view.ShowActionItemsByWorkAssignment;
            var showShiftHandoversByWorkAssignment = view.ShowShiftHandoversByWorkAssignment;

            var siteConfiguration = service.QueryBySiteIdWithNoCaching(userContext.SiteId);
            siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage = showActionItemsByWorkAssignment;
            siteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage = showShiftHandoversByWorkAssignment;

            siteConfiguration.DaysToDisplayDirectivesOnPriorityPage = DaysToDisplayDirectives;
            siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage = DaysToDisplayShiftHandovers;
            siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage = view.DisplayActionItemWorkAssignment;

            siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage = DaysToDisplayForms;
            siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage =
                DaysToDisplayDocumentSuggestions;

            siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage =
                DaysToDisplayIncompleteActionItems;

            siteConfiguration.MaximumAllowableExcursionEventDurationMins = MaximumAllowableExcursionEventDurationMins;
            siteConfiguration.MaximumAllowableExcursionEventTimeframeMins = MaximumAllowableExcursionEventTimeframeMins;

            service.UpdateSiteConfigurationPriorityPageConfiguration(siteConfiguration);

            view.Close();
        }

        private bool Validate()
        {
            var hasErrors = false;

            view.ClearErrors();

            if (DaysToDisplayDirectives <= 0)
            {
                view.SetErrorForDirectives(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayDirectives = ZERO;
                hasErrors = true;
            }

            if (DaysToDisplayShiftHandovers <= 0)
            {
                view.SetErrorForShiftHandovers(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayShiftHandovers = ZERO;
                hasErrors = true;
            }

            if (DaysToDisplayForms <= 0)
            {
                view.SetErrorForForms(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayForms = ZERO;
                hasErrors = true;
            }

            if (DaysToDisplayDocumentSuggestions <= 0)
            {
                view.SetErrorForDocumentSuggestions(StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayDocumentSuggestions = ZERO;
                hasErrors = true;
            }

            if (DaysToDisplayIncompleteActionItems != null && DaysToDisplayIncompleteActionItems <= 0)
            {
                view.SetErrorForDaysToDisplayIncompleteActionItems(
                    StringResources.DisplayLimitsValueMustBeGreaterThanZeroError);
                view.DaysToDisplayIncompleteActionItems = ZERO;
                hasErrors = true;
            }

            if (MaximumAllowableExcursionEventDurationMins < 0)
            {
                view.SetErrorForMaximumAllowableExcursionEventDurationMins(
                    StringResources.DisplayLimitsValueMustBeGreaterThanOrEqualToZeroError);
                view.MaximumAllowableExcursionEventDurationMins = ZERO;
                hasErrors = true;
            }

            if (MaximumAllowableExcursionEventTimeframeMins < 0)
            {
                view.SetErrorForMaximumAllowableExcursionEventTimeframeMins(
                    StringResources.DisplayLimitsValueMustBeGreaterThanOrEqualToZeroError);
                view.MaximumAllowableExcursionEventTimeframeMins = ZERO;
                hasErrors = true;
            }

            return hasErrors;
        }

        private static int ConvertToNumber(string value)
        {
            int daysToDisplay;
            if (value.IsNullOrEmptyOrWhitespace())
            {
                ZERO.TryParse(out daysToDisplay);
            }
            else
            {
                value.TryParse(out daysToDisplay);
            }
            return daysToDisplay;
        }
    }
}