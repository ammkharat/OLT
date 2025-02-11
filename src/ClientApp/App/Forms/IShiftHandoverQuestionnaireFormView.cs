using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IShiftHandoverQuestionnaireFormView : IBaseForm, IShiftHandoverQuestionnaireValidationAction
    {
        string Shift { set; }
        User Author { set; }
        DateTime CreateDateTime { set; }

        FunctionalLocation SelectedFunctionalLocation { get; }
        List<FunctionalLocation> FunctionalLocations { set; get;  }

        DialogResultAndOutput<IList<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelection);

        void ShowNoConfigurationMessageBox();
        void SetReadOnlyConfiguration(string shiftHandoverConfiguratioName);
        List<ShiftHandoverConfiguration> Configurations { set; }
        ShiftHandoverConfiguration SelectedConfiguration { get; }
        bool ConfirmDeleteExistingAnswers();
        void RevertToLastSelectedConfiguration();

        List<ShiftHandoverAnswer> Answers { set; }

        bool ViewEditHistoryEnabled { set; }
        
        void SetHelpText(ShiftHandoverQuestion question);

        void SetYesNo(ShiftHandoverQuestion question);//Added by ppanigrahi

        void SetEmailList(ShiftHandoverQuestion question);//Added by ppanigrahi
        
        void MakeFunctionalLocationsReadOnly();

        void SetAndFormatComments(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> summaryLogComments, List<HasCommentsDTO> logComments);
        void AddCokerCardSummaries(List<CokerCardDrumEntryDTO> drumEntryDtos);

        bool ShowHandoverMarkedAsReadWarning();

        /**/

        DateTime FlexiShiftStartDate { set; get; }
        DateTime FlexiShiftEndDate { set; get; }
        bool IsFlexible { set; get; }
        bool ViewFlexiShiftStartDate { set; }
        bool ViewFlexiShiftEndDate { set; }
        void EnableDisableFlexShiftHandover(UserRoleElements userRoleElements);
        void EnableDisableVisiblityFlexShiftHandover(UserRoleElements userRoleElements);
        bool FlextShiftHandoverStatus(UserRoleElements userRoleElements);
        /**/

        //Operator Round tool Logbody
        string OpeartorRoundLogText { get; set; }
        bool enableSelectShiftLogMessages { set; }
        //Added by ppanigrahi
        bool ActiveCsdChecked { get; set; }
        bool ActiveCsdCheckBoxVisible { get; set; }
        void EnableActiveCsdCheckBox(UserRoleElements userRoleElements);
    }
}
