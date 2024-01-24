using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PermitAssessmentFormPresenter :
        AbstractFormEdmontonFormPresenter<PermitAssessment, IPermitAssessmentFormView>
    {
        private readonly IContractorService contractorService;
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IQuestionnaireConfigurationService questionnaireConfigurationService;
        private readonly IFormEdmontonService service;
        private List<Contractor> contractors;
        private List<CraftOrTrade> craftOrTrades;
        private List<QuestionnaireConfigurationDTO> questionnaireConfigurations;

        public PermitAssessmentFormPresenter()
            : this(CreateDefaultForm())
        {
        }

        public PermitAssessmentFormPresenter(PermitAssessment form)
            : base(new PermitAssessmentForm(), form)
        {
            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            craftOrTradeService = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>();
            contractorService = ClientServiceRegistry.Instance.GetService<IContractorService>();
            questionnaireConfigurationService =
                ClientServiceRegistry.Instance.GetService<IQuestionnaireConfigurationService>();

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationButtonClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationButtonClicked;
            view.FormLoad += HandleViewLoad;
            view.HistoryClicked += HandleHistoryClicked;
        }

        private void HandleHistoryClicked()
        {
            EditHistoryFormPresenter presenter = new PermitAssessmentHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private static PermitAssessment CreateDefaultForm()
        {
            var now = Clock.Now;
            var context = ClientSession.GetUserContext();
            var currentUser = context.User;

            var startDateTime = context.UserShift.StartDateTime;
            var endDateTime = context.UserShift.EndDateTime;

            var form = new PermitAssessment(null, startDateTime, endDateTime, FormStatus.Approved, currentUser, now,
                context.UserShift.ShiftPatternId, currentUser, now)
            {
                SiteId = context.SiteId,
                IsIlpRecommended = false
            };
            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.FromDateTime = view.ValidFrom;
            editObject.IsIlpRecommended = view.IsIlpRecommended;
            editObject.ToDateTime = view.ValidTo;
            editObject.DocumentLinks = view.DocumentLinks;
            editObject.LocationEquipmentNumber = view.LocationEquipmentNumber;
            editObject.PermitNumber = view.PermitNumber;
            editObject.OilsandsWorkPermitType = view.PermitType;
            editObject.CrewSize = view.CrewSize;
            editObject.JobDescription = view.JobDescription;
            editObject.IssuedToSuncor = view.IssuedToSuncor;
            editObject.IssuedToContractor = view.IssuedToContractor;
            editObject.Contractor = view.Contractor;
            editObject.Trade = view.Trade;
            editObject.JobCoordinator = view.JobCoordinator;
        }

        protected override void ShowEmail()
        {
            // not implemented
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return false;
        }

        private void UpdateViewFromEditObject()
        {
            view.FunctionalLocations = editObject.FunctionalLocations;
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;
            view.DocumentLinks = editObject.DocumentLinks;
            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;
            view.IsIlpRecommended = editObject.IsIlpRecommended;
            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            view.LocationEquipmentNumber = editObject.LocationEquipmentNumber;
            view.PermitNumber = editObject.PermitNumber;
            view.PermitType = editObject.OilsandsWorkPermitType;
            view.CrewSize = editObject.CrewSize;
            view.JobDescription = editObject.JobDescription;
            view.IssuedToSuncor = editObject.IssuedToSuncor;
            view.IssuedToContractor = editObject.IssuedToContractor;
            view.Contractor = editObject.Contractor;
            view.Trade = editObject.Trade;
            view.JobCoordinator = editObject.JobCoordinator;

            var selectedQuestionnaireConfiguration = GetCurrentQuesionnaireConfigurationDTO();
            view.SelectedQuestionnaireConfiguration = selectedQuestionnaireConfiguration;
            view.EnableQuestionnaireSelection = !editObject.Id.HasValue && selectedQuestionnaireConfiguration == null;

            view.PermitAssessment = editObject;
        }

        private QuestionnaireConfigurationDTO GetCurrentQuesionnaireConfigurationDTO()
        {
            var questionnaireConfiguration =
                questionnaireConfigurationService.QueryQuestionnaireConfigurationById(editObject.QuestionnaireId);

            return (questionnaireConfiguration != null) ? questionnaireConfiguration.CreateDTO() : null;
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    service.InsertOilsandsPermitAssessmentForm, editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                service.UpdateOilsandsPermitAssessmentForm, editObject);
        }

        private void HandleQuestionnaireConfigurationSelectionChanged()
        {
            var questionnaireConfigurationDto = view.SelectedQuestionnaireConfiguration;

            if (questionnaireConfigurationDto == null || questionnaireConfigurationDto.Name.IsNullOrEmptyOrWhitespace())
                return;

            var questionnaireConfiguration =
                questionnaireConfigurationService.QueryQuestionnaireConfigurationById(
                    questionnaireConfigurationDto.IdValue);

            var permitCreatedDateTime = editObject.CreatedDateTime;
            var permitStartDateTime = view.ValidFrom;
            var permitExpiredDateTime = view.ValidTo;

            var assessment = PermitAssessmentBuilder.Build(questionnaireConfiguration, userContext.User, userContext.UserShift.ShiftPatternId,
                permitStartDateTime, permitExpiredDateTime, permitCreatedDateTime);

            // re-bind all the fields from the form to the newly-created assessment object
            assessment.FormStatus = FormStatus.Approved;
            assessment.Id = editObject.Id;
            assessment.FunctionalLocations = editObject.FunctionalLocations;
            assessment.DocumentLinks = editObject.DocumentLinks;
            assessment.LastModifiedBy = editObject.LastModifiedBy;
            assessment.LastModifiedDateTime = editObject.LastModifiedDateTime;
            assessment.LocationEquipmentNumber = editObject.LocationEquipmentNumber;
            assessment.PermitNumber = editObject.PermitNumber;
            assessment.OilsandsWorkPermitType = editObject.OilsandsWorkPermitType;
            assessment.CrewSize = editObject.CrewSize;
            assessment.IsIlpRecommended = editObject.IsIlpRecommended;
            assessment.JobDescription = editObject.JobDescription;
            assessment.IssuedToSuncor = editObject.IssuedToSuncor;
            assessment.IssuedToContractor = editObject.IssuedToContractor;
            assessment.Trade = editObject.Trade;
            assessment.JobCoordinator = editObject.JobCoordinator;

            // set the base edit object as the newly created assessment
            editObject = assessment;

            // refresh the audit control with the new assessment and blank answers
            view.PermitAssessment = editObject;
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            Save();
        }

        private void Save()
        {
            if (Validate())
            {
                return;
            }
            UpdateEditObjectFromView();
            SaveOrUpdate(true);
        }

        protected override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            var hasError = base.ValidateViewHasError();

            if (view.LocationEquipmentNumber.IsNullOrEmpty())
            {
                view.SetLocationEquipmentNumberNotSetError();
                hasError = true;
            }

            if (view.PermitNumber.IsNullOrEmpty())
            {
                view.SetPermitNumberNotSelectedError();
                hasError = true;
            }

            if (view.PermitType == null)
            {
                view.SetPermitTypeNotSelectedError();
                hasError = true;
            }

            if (view.CrewSize == 0)
            {
                view.SetCrewSizeNotSetError();
                hasError = true;
            }

            if (view.JobDescription.IsNullOrEmpty())
            {
                view.SetJobDescriptionNotSetError();
                hasError = true;
            }

            if (view.IssuedToSuncor == false && view.IssuedToContractor == false)
            {
                view.SetIssuedToNotSetError();
                hasError = true;
            }

            if (view.IssuedToContractor && view.Contractor.IsNullOrEmpty())
            {
                view.SetContractorNotSelectedError();
                hasError = true;
            }

            if (view.Trade.IsNullOrEmpty())
            {
                view.SetTradeNotSelectedError();
                hasError = true;
            }

            if (view.JobCoordinator.IsNullOrEmpty())
            {
                view.SetJobCoordinatorNotSetError();
                hasError = true;
            }

            if (view.SelectedQuestionnaireConfiguration == null ||
                view.SelectedQuestionnaireConfiguration.Name.IsNullOrEmptyOrWhitespace())
            {
                view.SetQuestionnaireConfigurationNotSelectedError();
                hasError = true;
            }

            return hasError;
        }

        private void QueryCraftOrTrades()
        {
            craftOrTrades = craftOrTradeService.QueryBySite(userContext.Site);
            craftOrTrades.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
        }

        private void QueryContractors()
        {
            contractors = contractorService.QueryBySite(userContext.Site);
            contractors.Sort((x, y) => string.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal));
            contractors.Insert(0, Contractor.EMPTY);
        }

        private void QueryQuestionnaireConfigurations()
        {
            var allActiveConfigurations =
                questionnaireConfigurationService.QueryQuestionnaireConfigurationDtosBySiteId(userContext.Site.IdValue);

            // Make sure any deleted (i.e. non-active) configuration is in the list so it can be displayed
            var currentConfiguration = GetCurrentQuesionnaireConfigurationDTO();
            if (currentConfiguration != null && !allActiveConfigurations.Contains(currentConfiguration))
            {
                allActiveConfigurations.Add(currentConfiguration);                
            }

            var sortedConfigurations = allActiveConfigurations.OrderBy(dto => dto.Name).ToList();

            sortedConfigurations.Insert(0, new QuestionnaireConfigurationDTO(-1, String.Empty, string.Empty, 0));

            questionnaireConfigurations = sortedConfigurations;
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> {QueryCraftOrTrades, QueryContractors, QueryQuestionnaireConfigurations});
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormPermitAssessmentFormTitle);
            view.OilsandsWorkPermitTypes = new List<OilsandsWorkPermitType>(OilsandsWorkPermitType.All);
            view.Contractors = contractors;
            view.Trades = craftOrTrades;
            view.QuestionnaireConfigurations = questionnaireConfigurations;

            UpdateViewFromEditObject();

            view.QuestionnaireConfigurationChanged += HandleQuestionnaireConfigurationSelectionChanged;

            if (editObject.Id.HasValue == false)
            {
                if (questionnaireConfigurations != null && questionnaireConfigurations.Count == 2)
                {
                    view.SelectedQuestionnaireConfiguration = questionnaireConfigurations[1];
                }
            }
        }
    }
}