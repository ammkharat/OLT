﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IShiftHandoverQuestionnaireAndLogFormView : IAddEditBaseFormView, IImportCustomFieldsView, ILogValidationAction, IShiftHandoverQuestionnaireValidationAction,
                                                                 ILogTemplateView
    {
        event Func<bool> HandoverTypeChanged;
        event Action FormLoad;
        event Action RemoveFunctionalLocation;
        event Action Cancel;
        event Action SelectInfoForSummary;
        event Action AddFunctionalLocation;
        event Action<CustomField> CustomFieldClicked;
        event Action Save;
        event Action<bool> Flexishifthandovercheck;

        string Shift { set; }
        string Author { set; }

        FunctionalLocation SelectedFunctionalLocation { get; }
        List<FunctionalLocation> FunctionalLocations { set; get;  }

        DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> functionalLocations, FunctionalLocationType flocSelectionLevel);

        void ShowNoConfigurationMessageBox();
        void SetReadOnlyConfiguration(string shiftHandoverConfigurationName);
        List<ShiftHandoverConfiguration> Configurations { set; }
        ShiftHandoverConfiguration SelectedConfiguration { get; }
        bool ConfirmDeleteExistingAnswers();
        void RevertToLastSelectedConfiguration();

        List<ShiftHandoverAnswer> Answers { set; }

        void SetHelpText(ShiftHandoverQuestion question);
        void MakeFunctionalLocationsReadOnly();

        void SetAndFormatComments(ShiftHandoverQuestionnaire shiftHandoverQuestionnaire, List<HasCommentsDTO> summaryLogComments, List<HasCommentsDTO> logComments);
        void AddCokerCardSummaries(List<CokerCardDrumEntryDTO> drumEntryDtos);

        bool ShowHandoverMarkedAsReadWarning();

        bool ExpandAdditionalDetails { set; }
        string OperatingEngineerLogDisplayName { set; }
        
        
        new DateTime LogDateTime { set; get; }
        string Comments { get; set; }
        string CommentsAsPlainText { get; }
        bool IsOperatingEngineerLog { get; set; }

        void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField);
        List<DocumentLink> DocumentLinks { get; set; }
        bool RecommendForShiftSummary { get; set; }

        void HideOperatingEngineerCheckBox();
        void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields);
        
        void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> customFieldEntries);
        DialogResultAndOutput<List<string>> ShowSelectInfoForSummaryForm();
        void AppendComments(List<string> comments);
        event Action LogGuidelineClick;
        void ShowGuidelines(List<LogGuideline> logGuidelines);
        
        event Action ActualLoggedTimeValueChanged;
        event Action ImportCustomFields;
        void HideOptionsSection();
        void SetTooltipOnExistingLogsSection(string caption);
        /**/
        bool IsFlexishifthandoverWithLog { get; set; }
        DateTime FlexiShiftStartDate { set; get; }
        DateTime FlexiShiftEndDate { set; get; }
        bool ViewFlexiShiftStartDate { set; }
        bool ViewFlexiShiftEndDate { set; }
        void EnableDisableFlexShiftHandoverbyrole(UserRoleElements userRoleElements);
        void EnableDisableFlexShiftHandover(bool enabledisable);
        void EnableDisableVisiblityFlexShiftHandover(UserRoleElements userRoleElements);
        bool FlextShiftHandoverStatus(UserRoleElements userRoleElements);
        /**/
        //Mukesh for Log Image
        List<LogImage> ImageLogdetails { set; get; }
        bool setLogImage
        {

            set;
        }

        //Operator Round tool Logbody
        string OpeartorRoundLogText { get; set; }
        bool enableSelectShiftLogMessages { set; }

        bool ActiveCsdChecked { get; set; }
        bool ActiveCsdCheckBoxVisible { get; set; }
        void EnableActiveCsdCheckBox(UserRoleElements userRoleElements);


    }
}