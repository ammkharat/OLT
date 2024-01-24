using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILogReplyFormView : IBaseForm
    {
        bool EHSFollowUp { get; set; }
        bool InspectionFollowUp { get; set; }
        bool OperationsFollowUp { get; set; }
        bool ProcessControlFollowUp { get; set; }
        bool SupervisionFollowUp { get; set; }
        bool OtherFollowUp { get; set; }

        string ParentEntryLineLabel { set; }

        bool IsOperatingEngineer { get; set; }
        string OperatingEngineerDisplayText { set; }
        bool RecommendForShiftSummary { get; set; }
        DateTime LogDateTime { set;}
        string Shift { set; }
        string Author { set; }       

        string Comments { set; get; }
        string CommentsAsPlainText { get; }
        bool IsCommentEmpty { get; }

        List<FunctionalLocation> FunctionalLocations { set; }

        DateTime ParentLogDateTime { set; }
        string ParentShift { set; }
        string ParentAuthor { set; }
        string ParentComments { set; }        

        void ClearErrorProviders();
        void SetCommentsBlankError();
        void DisableOperatingEngineerLogs();
        void HideOperatingEngineerCheckBox();
        void HideFollowupFlags();
        void HideOptions();
        void ShowGuidelines(List<LogGuideline> logGuidelines);
        string EntryReplyDetailsLabelLine { set; }
        string CommentLabelLine { set; }
        string ParentLogTimeGroupBoxText { set; }
        string LogTimeGroupBoxText { set; }
        List<DocumentLink> DocumentLinks { get; set; }
    }
}
