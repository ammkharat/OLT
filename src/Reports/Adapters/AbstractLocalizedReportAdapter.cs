using System.Globalization;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class AbstractLocalizedReportAdapter
    {
        public bool ShowEnglishLogo
        {
            get { return Culture.IsDefault; }
        }

        public bool ShowFrenchLogo
        {
            get { return Culture.IsFrench; }
        }

        public virtual string Label_Title { get; protected set; }

        public string Label_CreatedBy
        {
            get { return StringResources.ReportLabel_CreatedBy; }
        }

        public string Label_EditedBy
        {
            get { return StringResources.ReportLabel_EditedBy; }
        }

        public string Label_LastModifiedBy
        {
            get { return StringResources.ReportLabel_LastModifiedBy; }
        }

        public string Label_LastEditor_Caps
        {
            get { return StringResources.ReportLabel_LASTEDITOR; }
        }

        public string Label_CreationDateTime
        {
            get { return StringResources.ReportLabel_CreationDateTime; }
        }

        public string Label_LastModifiedDateTime
        {
            get { return StringResources.ReportLabel_LastModifiedDateTime; }
        }

        public string Label_LogDateTime
        {
            get { return StringResources.ReportLabel_LogDateTime; }
        }

        public string Label_FunctionalLocations
        {
            get { return StringResources.ReportLabel_FunctionalLocations; }
        }

        public string Label_FunctionalLocationUnit_Caps
        {
            get { return StringResources.ReportLabel_UNITLEVELFUNCTIONALLOCATION; }
        }

        public string Label_FunctionalLocation_Caps
        {
            get { return StringResources.ReportLabel_FUNCTIONALLOCATION; }
        }

        public string Label_Shift
        {
            get { return StringResources.ReportLabel_Shift; }
        }

        public string Label_ShiftDate_Caps
        {
            get { return StringResources.ReportLabel_SHIFTDATE; }
        }

        public string Label_Assignment
        {
            get { return StringResources.ReportLabel_Assignment; }
        }

        public virtual string Label_WorkAssignments
        {
            get { return StringResources.ReportLabel_WorkAssignments; }
        }

        public string Label_Options
        {
            get { return StringResources.ReportLabel_Options; }
        }

        public string Label_RecommendedForSummary
        {
            get { return StringResources.ReportLabel_RecommendedForSummary; }
        }

        public string Label_Followup
        {
            get { return StringResources.ReportLabel_Followup; }
        }

        public string Label_EHS
        {
            get { return StringResources.ReportLabel_EHS; }
        }

        public string Label_ProcessControl
        {
            get { return StringResources.ReportLabel_ProcessControl; }
        }

        public string Label_Operations
        {
            get { return StringResources.ReportLabel_Operations; }
        }

        public string Label_Inspection
        {
            get { return StringResources.ReportLabel_Inspection; }
        }

        public string Label_Supervision
        {
            get { return StringResources.ReportLabel_Supervision; }
        }

        public string Label_OtherSeeComments
        {
            get { return StringResources.ReportLabel_OtherSeeComments; }
        }

        public string Label_Yes
        {
            get { return StringResources.ReportLabel_Yes; }
        }

        public string Label_No
        {
            get { return StringResources.ReportLabel_No; }
        }

        public string Label_ShiftHandoverActionItemWarning
        {
            get { return StringResources.ReportLabel_ShiftHandoverActionItemWarning; }
        }

        public string Label_Category
        {
            get { return StringResources.ReportLabel_Category; }
        }

        public string Label_Priority
        {
            get { return StringResources.ReportLabel_Priority; }
        }

        public string Label_Source
        {
            get { return StringResources.ReportLabel_Source; }
        }

        public string Label_ResponseRequired
        {
            get { return StringResources.ReportLabel_ResponseRequired; }
        }

        public string Label_Description
        {
            get { return StringResources.ReportLabel_Description; }
        }

        public string Label_Drum
        {
            get { return StringResources.ReportLabel_Drum; }
        }

        public string Label_LastCycleStep
        {
            get { return StringResources.ReportLabel_LastCycleStep; }
        }

        public string Label_HoursIn
        {
            get { return StringResources.ReportLabel_HoursIn; }
        }

        public string Label_ProcessInformation_Caps
        {
            get { return StringResources.ReportLabel_PROCESSINFORMATION; }
        }

        public string Label_Description_Caps
        {
            get { return StringResources.ReportLabel_DESCRIPTION_CAPS; }
        }

        public string Label_Name
        {
            get { return StringResources.ReportLabel_Name; }
        }

        public string Label_Name_Caps
        {
            get { return StringResources.ReportLabel_NAME_CAPS; }
        }

        public string Label_Values_Caps
        {
            get { return StringResources.ReportLabel_VALUE; }
        }

        public string Label_Unit_Caps
        {
            get { return StringResources.ReportLabel_UNIT; }
        }

        public string Label_CustomFields
        {
            get { return StringResources.ReportLabel_CustomFields; }
            set { Label_CustomFields = value; }
        }

        public string Label_Comments
        {
            get { return StringResources.ReportLabel_Comments; }
        }

        public string Label_DORComments
        {
            get { return StringResources.ReportLabel_DORComments; }
        }

        public string Label_DocumentLinks
        {
            get { return StringResources.ReportLabel_DocumentLinks; }
        }

        public string Label_Last5Modifications
        {
            get { return StringResources.ReportLabel_Last5Modifications; }
        }

        public string Label_MarkedAsReadBy
        {
            get { return StringResources.ReportLabel_MarkedAsReadBy; }
        }

        public string Label_ReferencedLogs
        {
            get { return StringResources.ReportLabel_ReferencedLogs; }
        }

        public string Label_LogComments
        {
            get { return StringResources.ReportLabel_LogComments; }
        }

        public string Label_CokerCards
        {
            get { return StringResources.ReportLabel_CokerCards; }
        }

        public string Label_Questions
        {
            get { return StringResources.ReportLabel_Questions; }
        }

        public string Label_ActionItems
        {
            get { return StringResources.ReportLabel_ActionItems; }
        }

        public string Label_CSDs
        {
            get { return StringResources.ReportLabel_Csds; }
        }

        public string Label_EventExcursions
        {
            get { return StringResources.ReportLabel_EventExcursions; }
        }

        public string Label_PrintedOn
        {
            get { return StringResources.ReportLabel_PrintedOn; }
        }

        public string Label_Page
        {
            get { return StringResources.ReportLabel_Page; }
        }

        public string Label_PageOf
        {
            get { return StringResources.ReportLabel_PageOf; }
        }

        public string Label_Status
        {
            get { return StringResources.ReportLabel_Status; }
        }

        public string Label_StartDate
        {
            get { return StringResources.ReportLabel_StartDate; }
        }

        public string Label_StartBy
        {
            get { return StringResources.ReportLabel_StartBy; }
        }

        public string Label_EndBy
        {
            get { return StringResources.ReportLabel_EndBy; }
        }

        public string Label_LastResponse
        {
            get { return StringResources.ReportLabel_LastResponse; }
        }

        public string Label_ResponseBy
        {
            get { return StringResources.ReportLabel_ResponseBy; }
        }

        public string Label_ResponseDateTime
        {
            get { return StringResources.ReportLabel_ResponseDateTime; }
        }

        public string Label_PreviousStatus
        {
            get { return StringResources.ReportLabel_PreviousStatus; }
        }

        protected static string PadFormNumber(long formNumber)
        {
            return formNumber.ToString(CultureInfo.InvariantCulture).PadLeft(6, '0');
        }
    }
}