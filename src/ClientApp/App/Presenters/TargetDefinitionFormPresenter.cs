using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Constant = Com.Suncor.Olt.Common.Utility.Constants;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TargetDefinitionFormPresenter : AbstractFormPresenter<ITargetDefinitionFormView, TargetDefinition>
    {
        private static readonly ScheduleType[] ALLOWED_TARGET_SCHEDULES =
        {
            ScheduleType.Daily,
            ScheduleType.Weekly,
            ScheduleType.Hourly,
            ScheduleType.ByMinute,
            ScheduleType.MonthlyDayOfMonth,
            ScheduleType.MonthlyDayOfWeek,
            ScheduleType.RoundTheClock
        };

        private readonly Authorized authorized = new Authorized();
        private readonly IPlantHistorianService plantHistorianService;
        private readonly ITargetDefinitionService service;

        private readonly TagChangedState tagChangedState = new TagChangedState();
        private readonly IWorkAssignmentService workAssignmentService;

        private List<WorkAssignment> assignments;
        private TargetDefinition insertOrUpdateResult;

        public TargetDefinitionFormPresenter(ITargetDefinitionFormView view)
            : this(view, CreateDefaultTargetDefinition())
        {
        }

        public TargetDefinitionFormPresenter(ITargetDefinitionFormView view, TargetDefinition editTargetDefinition)
            : this(
                view,
                editTargetDefinition,
                ClientServiceRegistry.Instance.GetService<ITargetDefinitionService>(),
                ClientServiceRegistry.Instance.GetService<IPlantHistorianService>(),
                ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>())
        {
        }

        public TargetDefinitionFormPresenter(
            ITargetDefinitionFormView view,
            TargetDefinition editTargetDefinition,
            ITargetDefinitionService service,
            IPlantHistorianService plantHistorianService,
            IWorkAssignmentService workAssignmentService)
            : base(view, editTargetDefinition)
        {
            this.service = service;
            this.plantHistorianService = plantHistorianService;
            this.workAssignmentService = workAssignmentService;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            //LoadData(new List<Action> {QueryWorkAssignments});
            QueryWorkAssignments();

            view.WorkAssignments = assignments;
            view.OperationalModes = OperationalMode.AllList;
            view.TargetCategories = new List<TargetCategory>(TargetCategory.All);
            view.ScheduleTypes = new List<ScheduleType>(ALLOWED_TARGET_SCHEDULES);

            var userRoleElements = userContext.UserRoleElements;
            view.OperationalModeEnabled = userRoleElements.AuthorizedTo(RoleElement.SET_OPERATIONAL_MODES);            
            view.RequiresApprovalEnabled = authorized.ToToggleApprovalRequiredForTargetDefinition(userRoleElements);
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.TargetDefinitionForm_Title);
            view.ViewEditHistoryEnabled = IsEdit;
            view.Priorities = new List<Priority>(TargetDefinition.Priorities);

            if (IsEdit && authorized.ToAutoApproveTargetDefinition(userRoleElements) == false)
            {
                var siteConfig = userContext.SiteConfiguration;
                var targetDefConfig = siteConfig.TargetDefinitionAutoReApprovalConfiguration;
                view.NameChangeRequiresReApproval = targetDefConfig.NameChange;
                view.CategoryChangeRequiresReApproval = targetDefConfig.CategoryChange;
                view.OperationalModeChangeRequiresReApproval = targetDefConfig.OperationalModeChange;
                view.PriorityChangeRequiresReApproval = targetDefConfig.PriorityChange;
                view.DescriptionChangeRequiresReApproval = targetDefConfig.DescriptionChange;
                view.DocumentLinksChangeRequiresReApproval = targetDefConfig.DocumentLinksChange;
                view.FunctionalLocationChangeRequiresReApproval = targetDefConfig.FunctionalLocationChange;
                view.PHTagChangeRequiresReApproval = targetDefConfig.PHTagChange;
                view.TargetDependenciesChangeRequiresReApproval = targetDefConfig.TargetDependenciesChange;
                view.ScheduleChangeRequiresReApproval = targetDefConfig.ScheduleChange;
                view.GenerateActionItemChangeRequiresReApproval = targetDefConfig.GenerateActionItemChange;
                view.RequiresResponseWhenAlertedChangeRequiresReApproval =
                    targetDefConfig.RequiresResponseWhenAlertedChange;
                view.SuppressAlertChangeRequiresReApproval = targetDefConfig.SuppressAlertChange;
                view.MinValueChangeAlwaysRequiresReApproval = !editObject.PreApprovedMinValue.HasValue;
                view.MaxValueChangeAlwaysRequiresReApproval = !editObject.PreApprovedMaxValue.HasValue;
                view.NeverToExceedMinValueChangeAlwaysRequiresReApproval =
                    !editObject.PreApprovedNeverToExceedMinimum.HasValue;
                view.NeverToExceedMaxValueChangeAlwaysRequiresReApproval =
                    !editObject.PreApprovedNeverToExceedMaximum.HasValue;
            }

            UpdateViewFromEditObject();

            if (IsEdit)
            {
                SetTagValueOnView();
            }
        }

        private void QueryWorkAssignments()
        {
            assignments =
                workAssignmentService.QueryByFunctionalLocationsMatchExactlyOrByAncestorOrByDescendant(
                    userContext.RootFlocSet);

            if (IsEdit && editObject.Assignment != null && !assignments.ExistsById(editObject.Assignment))
            {
                assignments.Add(editObject.Assignment);
            }

            assignments.RemoveAll(
                assignment =>
                    !assignment.WriteWorkAssignmentVisibilityGroups.Exists(
                        wavg => userContext.ReadableVisibilityGroupIds.Contains(wavg.VisibilityGroupId)));
            assignments.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.CurrentCulture));
            assignments.Insert(0, WorkAssignment.NoneWorkAssignment);
        }

        public static TargetDefinition CreateDefaultTargetDefinition()
        {
            var ret = new TargetDefinition(string.Empty, string.Empty, TargetCategory.PROCESS,
                TargetDefinitionStatus.Pending,
                null, null, null, null, null, null, 1, 1, null, null, null, null, 1, 1,
                TargetValue.CreateEmptyTarget(),
                null, null, false, true, true,
                ClientSession.GetUserContext().SiteConfiguration.DefaultTargetDefinitionRequiresResponseWhenAlertedValue,
                new List<TargetDefinitionDTO>(),
                ClientSession.GetUserContext().User,
                Clock.Now, false, OperationalMode.Normal,
                TargetDefinitionReadWriteTagConfiguration.CreateDefault(),
                new List<DocumentLink>(),
                WorkAssignment.NoneWorkAssignment);
            ret.WaitForApproval();
            return ret;
        }

        private void PopulateView(User lastModifiedBy, DateTime lastModifiedDate, string name, string description,
            WorkAssignment assignment, decimal? maxValue, int maxValueFrequency,
            decimal? neverToExceedMaximum, int neverToExceedMaximumFrequency, decimal? minValue, int minValueFrequency,
            decimal? neverToExceedMinimum,
            int neverToExceedMinimumFrequency, TargetValue targetValue, decimal? gapUnitValue, TargetCategory category,
            Priority priority, TagInfo tagInfo, bool generateActionItem,
            bool requiresApproval, bool isActive, bool isAlertRequired, bool requiresResponseWhenAlerted,
            FunctionalLocation functionalLocation,
            List<TargetDefinitionDTO> associatedTargetDTOs, ISchedule schedule, OperationalMode operationalMode,
            List<DocumentLink> documentLinks, TargetDefinitionReadWriteTagConfiguration readWriteConfig)
        {
            view.Author = lastModifiedBy;
            view.CreateDateTime = lastModifiedDate;
            view.Name = name;
            view.Description = description;
            view.WorkAssignment = assignment;
            view.MaxValue = maxValue;
            view.MaxValueFrequency = maxValueFrequency;
            view.NeverToExceedMaximum = neverToExceedMaximum;
            view.NeverToExceedMaximumFrequency = neverToExceedMaximumFrequency;
            view.MinValue = minValue;
            view.MinValueFrequency = minValueFrequency;
            view.NeverToExceedMinimum = neverToExceedMinimum;
            view.NeverToExceedMinimumFrequency = neverToExceedMinimumFrequency;
            targetValue.Do(new SetTargetValueOnView(view));
            view.GapUnitValue = gapUnitValue;
            view.Category = category;
            view.Priority = priority;
            view.TagInfo = tagInfo;
            view.TagValueEnabled = tagInfo != null;
            view.ConfigurePreApprovedTargetRangesEnabled = tagInfo != null;
            view.GenerateActionItem = generateActionItem;
            view.RequiresApproval = requiresApproval;
            view.IsActive = isActive;
            view.IsAlertRequired = isAlertRequired;
            view.RequiresResponseWhenAlerted = requiresResponseWhenAlerted;
            view.FunctionalLocation = functionalLocation;
            view.DependentTargetDefinitions = associatedTargetDTOs;
            view.Schedule = schedule;
            view.OperationalMode = operationalMode;
            view.AssociatedDocumentLinks = documentLinks;

            PopulateViewForReadWriteConfigurations(readWriteConfig);
        }

        private void UpdateViewFromEditObject()
        {
            PopulateView
                (
                    editObject.LastModifiedBy,
                    editObject.LastModifiedDate,
                    editObject.Name,
                    editObject.Description,
                    editObject.Assignment,
                    editObject.MaxValue,
                    editObject.MaxValueFrequency.GetValueOrDefault(1),
                    editObject.NeverToExceedMaximum,
                    editObject.NeverToExceedMaxFrequency.GetValueOrDefault(1),
                    editObject.MinValue,
                    editObject.MinValueFrequency.GetValueOrDefault(1),
                    editObject.NeverToExceedMinimum,
                    editObject.NeverToExceedMinFrequency.GetValueOrDefault(1),
                    editObject.TargetValue,
                    editObject.GapUnitValue,
                    editObject.Category,
                    editObject.Priority,
                    editObject.TagInfo,
                    editObject.GenerateActionItem,
                    editObject.RequiresApproval,
                    editObject.IsActive,
                    editObject.IsAlertRequired,
                    editObject.RequiresResponseWhenAlerted,
                    editObject.FunctionalLocation,
                    editObject.AssociatedTargetDTOs,
                    editObject.Schedule,
                    editObject.OperationalMode,
                    editObject.DocumentLinks,
                    editObject.ReadWriteTagsConfiguration
                );

            SetPreApprovedTargetRangesWarning();
            EnableDisableIsActiveCheckBox(editObject.RequiresApproval);
        }

        private void SetPreApprovedTargetRangesWarning()
        {
            var anyPreApprovedTargetRangesAreEmpty = editObject.PreApprovedMinValue.HasValue ||
                                                     editObject.PreApprovedMaxValue.HasValue ||
                                                     editObject.PreApprovedNeverToExceedMinimum.HasValue ||
                                                     editObject.PreApprovedNeverToExceedMaximum.HasValue;
            view.PreApprovedTargetRangesWarningIsVisible = anyPreApprovedTargetRangesAreEmpty;

            var NTEMaxLabel = StringResources.TargetDefinitionFormPreapprovedWarningLabel_NeverToExceedMax.AppendSpace();
            var maxLabel = StringResources.TargetDefinitionFormPreapprovedWarningLabel_Max.AppendSpace();
            var minLabel = StringResources.TargetDefinitionFormPreapprovedWarningLabel_Min.AppendSpace();
            var NTEMinLabel = StringResources.TargetDefinitionFormPreapprovedWarningLabel_NeverToExceedMin.AppendSpace();

            var warning = new StringBuilder();
            warning.Append(editObject.PreApprovedNeverToExceedMaximum.HasValue
                ? NTEMaxLabel + editObject.PreApprovedNeverToExceedMaximum + Environment.NewLine
                : string.Empty);
            warning.Append(editObject.PreApprovedMaxValue.HasValue
                ? maxLabel + editObject.PreApprovedMaxValue + Environment.NewLine
                : string.Empty);
            warning.Append(editObject.PreApprovedMinValue.HasValue
                ? minLabel + editObject.PreApprovedMinValue + Environment.NewLine
                : string.Empty);
            warning.Append(editObject.PreApprovedNeverToExceedMinimum.HasValue
                ? NTEMinLabel + editObject.PreApprovedNeverToExceedMinimum + Environment.NewLine
                : string.Empty);
            view.PreApprovedTargetRangesWarning = warning.ToString().Trim();
        }

        public void SearchTagClickEvent(object sender, EventArgs eventArgs)
        {
            var dialogResultAndOutput = view.ShowTagSelector();
            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                var tagInfo = dialogResultAndOutput.Output;
                view.TagInfo = tagInfo;
                view.ConfigurePreApprovedTargetRangesEnabled = tagInfo != null;
                SetTagValueOnView();
            }
        }

        public void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            var result = view.ShowFunctionalLocationSelector();
            if (result == DialogResult.OK)
            {
                view.FunctionalLocation = view.UserSelectedFunctionalLocation;
            }
        }

        public void HandleDependentTargetButtonClick(object sender, EventArgs eventArgs)
        {
            var result = view.ShowTargetDefinitionSelector();
            if (result == DialogResult.OK)
            {
                view.DependentTargetDefinitions = view.UserSelectedDependentTargetDefinitions;
            }
        }

        public void HandleNameChanged(object sender, EventArgs e)
        {
            view.ReadWriteConfigurationEnabled = view.Name != string.Empty;
        }

        public void HandleConfigureReadWriteTagButtonClick(object sender, EventArgs e)
        {
            if (view.HasScheduleError)
            {
                return;
            }

            view.ClearScheduleErrors();

            PopulateTargetDefinitionFromView();
            var configForm = view.DisplayReadWriteConfigurationForm(editObject);
            if (DialogResult.OK == configForm.ShowDialog())
            {
                var config = configForm.ReadWriteTagsConfiguration;
                PopulateViewForReadWriteConfigurations(config);

                if (!Equals(editObject.ReadWriteTagsConfiguration, config))
                {
                    tagChangedState.ReadWriteTagConfigurationHasChanged = true;
                }

                editObject.ReadWriteTagsConfiguration = config;
            }
        }

        private void PopulateViewForReadWriteConfigurations(TargetDefinitionReadWriteTagConfiguration config)
        {
            PopulateMax(config);
            PopulateMin(config);
            PopulateTarget(config);
            PopulateGapUnitValue(config);
        }

        private void PopulateMax(TargetDefinitionReadWriteTagConfiguration config)
        {
            view.MaxReadWriteDirection = config.MaxValue.Direction;
            view.MaxValueEnabled = !  config.MaxValue.IsReadDirection();
            var value = GetTagValueFromPlantHistorian(config.MaxValue);
            if (value.HasValue) view.MaxValue = value;
        }

        private void PopulateMin(TargetDefinitionReadWriteTagConfiguration config)
        {
            view.MinReadWriteDirection = config.MinValue.Direction;
            view.MinValueEnabled = !config.MinValue.IsReadDirection();
            var value = GetTagValueFromPlantHistorian(config.MinValue);
            if (value.HasValue) view.MinValue = value;
        }

        private void PopulateTarget(TargetDefinitionReadWriteTagConfiguration config)
        {
            view.TargetReadWriteDirection = config.TargetValue.Direction;
            view.TargetValueEnabled = !config.TargetValue.IsReadDirection();
            var value = GetTagValueFromPlantHistorian(config.TargetValue);
            if (value.HasValue) view.TargetValue = value;
        }

        private void PopulateGapUnitValue(TargetDefinitionReadWriteTagConfiguration config)
        {
            view.GapUnitReadWriteDirection = config.GapUnitValue.Direction;
            view.GapUnitValueEnabled = !config.GapUnitValue.IsReadDirection();

            var value = GetTagValueFromPlantHistorian(config.GapUnitValue);
            if (value.HasValue) view.GapUnitValue = value;
        }

        private decimal? GetTagValueFromPlantHistorian(ReadWriteTagConfiguration config)
        {
            decimal? result = null;
            try
            {
                if (config.IsReadDirection())
                {
                    result =
                        plantHistorianService.ReadTagValues(
                            PlantHistorianOrigin.TargetDefinitionFormPresenter_GetTagValueFromPlantHistorian, config.Tag)
                            [0];
                }
            }
            catch (Exception)
            {
                // swallowing the exception because we will just not set the values.
            }
            return result;
        }

        public void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            var presenter = new EditTargetDefinitionHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        public override void Insert(SaveUpdateDomainObjectContainer<TargetDefinition> container)
        {
            insertOrUpdateResult =
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.TargetDefinitionCreate, service.Insert, container.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<TargetDefinition> container)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, editObject,
                tagChangedState);
            insertOrUpdateResult = editObject;
        }

        protected override SaveUpdateDomainObjectContainer<TargetDefinition> GetNewObjectToInsert()
        {
            PopulateTargetDefinitionFromView();
            return new SaveUpdateDomainObjectContainer<TargetDefinition>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<TargetDefinition> GetPopulatedEditObjectToUpdate()
        {
            PopulateTargetDefinitionFromView();
            return new SaveUpdateDomainObjectContainer<TargetDefinition>(editObject);
        }

        protected override void SaveOrUpdateComplete(bool saveOrUpdateSucceeded)
        {
            base.SaveOrUpdateComplete(saveOrUpdateSucceeded);

            if (saveOrUpdateSucceeded)
            {
                HandleAutoGenerateActionItemDefinition(insertOrUpdateResult);
            }
        }

        private void PopulateTargetDefinitionFromView()
        {
            var originalTagInfo = editObject.TagInfo;
            var tagInfoFromView = view.TagInfo;

            editObject.Name = view.Name;
            editObject.Description = view.Description;
            editObject.Category = view.Category;
            editObject.Assignment = view.WorkAssignment;

            editObject.TagInfo = tagInfoFromView;
            editObject.Schedule = view.Schedule;
            editObject.NeverToExceedMinimum = view.NeverToExceedMinimum;
            editObject.NeverToExceedMaximum = view.NeverToExceedMaximum;
            editObject.NeverToExceedMinFrequency = view.NeverToExceedMinimumFrequency;
            editObject.NeverToExceedMaxFrequency = view.NeverToExceedMaximumFrequency;
            editObject.MaxValue = view.MaxValue;
            editObject.MinValue = view.MinValue;
            editObject.MaxValueFrequency = view.MaxValueFrequency;
            editObject.MinValueFrequency = view.MinValueFrequency;
            editObject.TargetValue = CreateTargetValueFromView();
            editObject.GapUnitValue = view.GapUnitValue;
            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.GenerateActionItem = view.GenerateActionItem;
            editObject.IsAlertRequired = view.IsAlertRequired;
            var requiresApproval = view.RequiresApproval;
            editObject.RequiresApproval = requiresApproval;
            editObject.Status = TargetDefinitionStatus.GetStatusBasedOnRequiresApproval(requiresApproval);
            editObject.RequiresResponseWhenAlerted = view.RequiresResponseWhenAlerted;
            editObject.AssociatedTargetDTOs = view.DependentTargetDefinitions;
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDate = Clock.Now;
            editObject.IsActive = view.IsActive;
            editObject.OperationalMode = view.OperationalMode;
            editObject.DocumentLinks = view.AssociatedDocumentLinks;
            editObject.Priority = view.Priority;

            if (IsEdit)
            {
                if (!Equals(originalTagInfo, tagInfoFromView))
                {
                    tagChangedState.TagHasChanged = true;
                }

                var authorizedToReApprove = authorized.ToAutoApproveTargetDefinition(userContext.UserRoleElements);
                var siteConfiguration = userContext.SiteConfiguration;
                var autoReApprovalConfig = siteConfiguration.TargetDefinitionAutoReApprovalConfiguration;

                var beforeChanges = service.QueryById(editObject.IdValue);
                editObject.UpdateStatusAfterChange(authorizedToReApprove, beforeChanges, autoReApprovalConfig);
            }
        }

        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();
            var hasError = false;

            if (view.Description.IsNullOrEmptyOrWhitespace())
            {
                view.ShowDescriptionIsEmptyError();
                hasError = true;
            }
            if (view.Name.IsNullOrEmptyOrWhitespace())
            {
                view.ShowNameIsEmptyError();
                hasError = true;
            }
            if (view.FunctionalLocation == null)
            {
                view.ShowNoFunctionalLocationsSelectedError();
                hasError = true;
            }
            if (view.TagInfo == null)
            {
                view.ShowNoTagInfoSelectedError();
                hasError = true;
            }

            var site = userContext.Site;

            if (view.HasScheduleError)
            {
                hasError = true;
            }
            else
            {
                var schedule = view.Schedule;

                var nameError = service.IsValidName(view.Name, site, schedule, editObject);
                if (nameError.HasError)
                {
                    view.ShowNameError(nameError.Message);
                    hasError = true;
                }

                // The order of these calls is important because you can't access the view's schedule if it isn't valid. If it isn't
                // valid then it will throw an exception.
                var tagErrorMessage = new StringBuilder();
                var maxTagError = IsValidWriteTag(editObject.ReadWriteTagsConfiguration.MaxValue);
                var minTagError = IsValidWriteTag(editObject.ReadWriteTagsConfiguration.MinValue);
                var targetTagError = IsValidWriteTag(editObject.ReadWriteTagsConfiguration.TargetValue);
                var gapTagError = IsValidWriteTag(editObject.ReadWriteTagsConfiguration.GapUnitValue);

                if (maxTagError.HasError)
                {
                    tagErrorMessage.AppendLine(maxTagError.Message);
                    hasError = true;
                }

                if (minTagError.HasError)
                {
                    tagErrorMessage.AppendLine(minTagError.Message);
                    hasError = true;
                }

                if (targetTagError.HasError)
                {
                    tagErrorMessage.AppendLine(targetTagError.Message);
                    hasError = true;
                }

                if (gapTagError.HasError)
                {
                    tagErrorMessage.AppendLine(gapTagError.Message);
                    hasError = true;
                }

                if (tagErrorMessage.Length != 0)
                {
                    view.ShowWriteTagError(tagErrorMessage.ToString());
                }
            }

            if (view.MaxValue.HasNoValue() &&
                view.MinValue.HasNoValue() &&
                view.NeverToExceedMinimum.HasNoValue() &&
                view.NeverToExceedMaximum.HasNoValue())
            {
                view.ShowAllValuesAreEmptyError();
                hasError = true;
            }
            if (view.MaxValue.HasValue &&
                view.MinValue.HasValue &&
                view.MaxValue.Value < view.MinValue.Value)
            {
                view.ShowMaxValueShouldBeGreaterThanMinValueError();
                hasError = true;
            }
            if (view.NeverToExceedMaximum.HasValue &&
                view.NeverToExceedMinimum.HasValue &&
                view.NeverToExceedMaximum.Value < view.NeverToExceedMinimum.Value)
            {
                view.ShowNTEMaxValueShouldBeGreaterThanNTEMinValueError();
                hasError = true;
            }
            if (view.NeverToExceedMaximum.HasValue &&
                view.MaxValue.HasValue &&
                view.MaxValue.Value > view.NeverToExceedMaximum.Value)
            {
                view.ShowNTEMaxValueShouldBeGreaterThanMaxError();
                hasError = true;
            }
            if (view.NeverToExceedMinimum.HasValue &&
                view.MinValue.HasValue &&
                view.NeverToExceedMinimum.Value > view.MinValue.Value)
            {
                view.ShowMinValueShouldBeGreaterThanNTEMinError();
                hasError = true;
            }
            if (view.MaxValue.HasValue &&
                view.NeverToExceedMinimum.HasValue &&
                view.MaxValue.Value < view.NeverToExceedMinimum.Value)
            {
                view.ShowMaxValueShouldBeGreaterThanNTEMinValueError();
                hasError = true;
            }
            if (view.MinValue.HasValue &&
                view.NeverToExceedMaximum.HasValue &&
                view.MinValue.Value > view.NeverToExceedMaximum.Value)
            {
                view.ShowNTEMaxValueShouldBeGreaterThanMinError();
                hasError = true;
            }
            if (TargetValueIsOutsideOfThreshold())
            {
                view.ShowTargetValueIsOutsideOfThreshold();
                hasError = true;
            }
            return hasError;
        }

        private Error IsValidWriteTag(ReadWriteTagConfiguration tagConfiguration)
        {
            if (tagConfiguration.Tag.Equals(TagInfo.CreateEmpty()))
                return Error.HasNoError;

            return service.IsValidWriteTag(editObject.Id, view.Schedule, tagConfiguration.Tag);
        }

        private bool TargetValueIsOutsideOfThreshold()
        {
            return view.TargetValue < view.NeverToExceedMinimum ||
                   view.TargetValue < view.MinValue ||
                   view.TargetValue > view.MaxValue ||
                   view.TargetValue > view.NeverToExceedMaximum;
        }

        public void HandleRequiresApprovalCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            EnableDisableIsActiveCheckBox(view.RequiresApproval);
        }

        public void HandleRequiresResponseWhenAlertedCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            SetStateForSuppressAlertCheckbox();
        }

        public void HandleSuppressAlertCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            SetStateForRequiresResponseWhenAlertedCheckbox1();
        }

        public void HandleConfigurePreApprovedTargetRangesButtonClick(object sender, EventArgs e)
        {
            if (view.HasScheduleError)
            {
                return;
            }

            view.ClearScheduleErrors();

            PopulateTargetDefinitionFromView();
            editObject = view.ShowConfigurePreApprovedTargetRangesForm(editObject);
            UpdateViewFromEditObject();
        }

        private void SetStateForRequiresResponseWhenAlertedCheckbox1()
        {
            view.RequiresResponseWhenAlertedEnabled = view.IsAlertRequired;
            view.RequiresResponseWhenAlerted = false;
        }

        public void SetStateForSuppressAlertCheckbox()
        {
            view.SuppressAlertCheckBoxEnabled = view.RequiresResponseWhenAlerted;
            view.IsAlertRequired = true;
        }

        private void EnableDisableIsActiveCheckBox(bool requiresApproval)
        {
            if (requiresApproval)
            {
                view.IsActive = false;
                view.IsActiveCheckBoxEnabled = false;
            }
            else
            {
                view.IsActiveCheckBoxEnabled = true;
            }
        }

        private void HandleAutoGenerateActionItemDefinition(TargetDefinition targetDefinition)
        {
            if (!targetDefinition.AutoGenerateActionItemDefinitionRequired) return;

            var generator = new ActionItemDefinitionGenerator(service);
            var actionItemDefinition = generator.BuildActionItemDefinition(targetDefinition);
            view.ShowActionItemDefinitionForm(actionItemDefinition);
        }

        private TargetValue CreateTargetValueFromView()
        {
            if (view.TargetSetToMinimize)
            {
                return TargetValue.CreateMinimizeTarget();
            }
            if (view.TargetSetToMaximize)
            {
                return TargetValue.CreateMaximizeTarget();
            }
            var desiredTargetValue = view.TargetValue;
            return desiredTargetValue.HasValue
                ? TargetValue.CreateSpecifiedTarget(desiredTargetValue.Value)
                : TargetValue.CreateEmptyTarget();
        }

        private void SetTagValueOnView()
        {
            var tagValue = ReadSelectedTagInfoValue();
            view.TagValueEnabled = tagValue.HasValue;
            // Using CurrentCulture ensures that the numbers are formatted properly.
            view.TagValue = (tagValue.HasValue
                ? tagValue.Value.ToString(CultureInfo.CurrentCulture)
                : StringResources.Unavailable);
        }

        private decimal? ReadSelectedTagInfoValue()
        {
            try
            {
                var selectedTagInfo = view.TagInfo;
                if (selectedTagInfo != null && plantHistorianService.CanReadTagValue(selectedTagInfo))
                {
                    return
                        GetTagValueFromPlantHistorian(new ReadWriteTagConfiguration(TagDirection.Read, selectedTagInfo));
                }
                return null;
            }
                // Do not want the stop creation/edit of target definition if unable to communicate with Plant Historian.
            catch (Exception)
            {
                return null;
            }
        }

        public void HandleRefreshTagValueButtonClick(object sender, EventArgs e)
        {
            SetTagValueOnView();
        }

        private class SetTargetValueOnView : ITargetAction
        {
            private readonly ITargetDefinitionFormView view;

            public SetTargetValueOnView(ITargetDefinitionFormView view)
            {
                this.view = view;
            }

            public void DoForMinimize()
            {
                view.SetTargetToMinimize();
            }

            public void DoForMaximize()
            {
                view.SetTargetToMaximize();
            }

            public void DoForEmpty()
            {
                view.TargetValue = null;
            }

            public void DoWithSpecifiedValue(decimal specifiedValue)
            {
                view.TargetValue = specifiedValue;
            }
        }
    }
}