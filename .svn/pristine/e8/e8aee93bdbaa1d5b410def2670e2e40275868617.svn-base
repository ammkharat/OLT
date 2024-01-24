using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITargetDefinitionFormView : IBaseForm
    {
        string Name { get; set; }
        string Description { get; set; }
        ISchedule Schedule { get; set; }
        decimal? NeverToExceedMinimum { get; set; }
        decimal? NeverToExceedMaximum { get; set; }
        int NeverToExceedMinimumFrequency { get; set; }
        int NeverToExceedMaximumFrequency { get; set; }
        decimal? MaxValue { get; set; }
        decimal? MinValue { get; set; }
        int MaxValueFrequency { get; set; }
        int MinValueFrequency { get; set; }

        bool TargetSetToMinimize { get; }
        bool TargetSetToMaximize { get; }
        decimal? TargetValue { get; set; }

        decimal? GapUnitValue { get; set; }
        TargetCategory Category { get; set; }
        WorkAssignment WorkAssignment { get; set; }
        Priority Priority { get; set; }
        TagInfo TagInfo { get; set; }

        bool IsActive { get; set; }
        bool IsActiveCheckBoxEnabled { set; }

        bool RequiresApproval { get; set; }

        bool GenerateActionItem { get; set; }

        bool IsAlertRequired { get; set; }
        bool SuppressAlertCheckBoxEnabled { set; }

        bool RequiresResponseWhenAlerted { get; set; }
        bool RequiresResponseWhenAlertedEnabled { set; }

        bool RequiresApprovalEnabled { set; }

        FunctionalLocation FunctionalLocation { set; get; }
        List<TargetCategory> TargetCategories { set; }
        List<WorkAssignment> WorkAssignments { set; }
        List<ScheduleType> ScheduleTypes { set; }
        List<TargetDefinitionDTO> DependentTargetDefinitions { get; set; }
        List<Priority> Priorities { set; }

        FunctionalLocation UserSelectedFunctionalLocation { get; }
        List<TargetDefinitionDTO> UserSelectedDependentTargetDefinitions { get; }

        bool HasScheduleError { get; }

        User Author { set; }
        DateTime CreateDateTime { set; }

        OperationalMode OperationalMode { get; set; }
        IList<OperationalMode> OperationalModes { set; }

        bool ReadWriteConfigurationEnabled { set; }
        TagDirection MaxReadWriteDirection { set; }
        TagDirection MinReadWriteDirection { set; }
        TagDirection TargetReadWriteDirection { set; }
        TagDirection GapUnitReadWriteDirection { set; }
        bool ConfigurePreApprovedTargetRangesEnabled { set; }

        bool MaxValueEnabled { set; }
        bool MinValueEnabled { set; }
        bool TargetValueEnabled { set; }
        bool GapUnitValueEnabled { set; }
        bool ViewEditHistoryEnabled { set; }

        List<DocumentLink> AssociatedDocumentLinks { get; set; }

        bool PreApprovedTargetRangesWarningIsVisible { set; }
        string PreApprovedTargetRangesWarning { set; }

        bool NameChangeRequiresReApproval { set; }
        bool CategoryChangeRequiresReApproval { set; }
        bool OperationalModeChangeRequiresReApproval { set; }
        bool PriorityChangeRequiresReApproval { set; }
        bool DescriptionChangeRequiresReApproval { set; }
        bool DocumentLinksChangeRequiresReApproval { set; }
        bool FunctionalLocationChangeRequiresReApproval { set; }
        bool PHTagChangeRequiresReApproval { set; }
        bool TargetDependenciesChangeRequiresReApproval { set; }
        bool ScheduleChangeRequiresReApproval { set; }
        bool GenerateActionItemChangeRequiresReApproval { set; }
        bool RequiresResponseWhenAlertedChangeRequiresReApproval { set; }
        bool SuppressAlertChangeRequiresReApproval { set; }

        bool MinValueChangeAlwaysRequiresReApproval { set; }
        bool MaxValueChangeAlwaysRequiresReApproval { set; }
        bool NeverToExceedMinValueChangeAlwaysRequiresReApproval { set; }
        bool NeverToExceedMaxValueChangeAlwaysRequiresReApproval { set; }
        string TagValue { set; }
        bool TagValueEnabled { set; }
        bool OperationalModeEnabled { set; }
        void SetTargetToMinimize();
        void SetTargetToMaximize();
        void ClearErrorProviders();
        DialogResult ShowFunctionalLocationSelector();
        DialogResultAndOutput<TagInfo> ShowTagSelector();
        DialogResult ShowTargetDefinitionSelector();
        void ShowActionItemDefinitionForm(ActionItemDefinition actionItemDefinition);
        void ShowDescriptionIsEmptyError();
        void ShowNameIsEmptyError();
        void ShowNoFunctionalLocationsSelectedError();
        void ShowNoTagInfoSelectedError();
        void ShowMaxValueShouldBeGreaterThanMinValueError();
        void ShowMaxValueShouldBeGreaterThanNTEMinValueError();
        void ShowNTEMaxValueShouldBeGreaterThanNTEMinValueError();
        void ShowNTEMaxValueShouldBeGreaterThanMaxError();
        void ShowNTEMaxValueShouldBeGreaterThanMinError();
        void ShowMinValueShouldBeGreaterThanNTEMinError();
        void ShowAllValuesAreEmptyError();
        void ShowWriteTagError(string message);

        ITargetDefinitionReadWriteTagConfigurationView DisplayReadWriteConfigurationForm(
            TargetDefinition targetDefinition);

        TargetDefinition ShowConfigurePreApprovedTargetRangesForm(TargetDefinition targetDefinition);
        void ShowTargetValueIsOutsideOfThreshold();
        void ShowNameError(string message);
        void ClearScheduleErrors();
    }
}