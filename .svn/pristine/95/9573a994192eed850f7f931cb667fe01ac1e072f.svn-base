using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class SafeWorkPermitAuditQuestionnaireReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly PermitAssessment permitAssessment;

        public SafeWorkPermitAuditQuestionnaireReportAdapter(PermitAssessment permitAssessment)
        {
            this.permitAssessment = permitAssessment;
            Label_Title = StringResources.SafeWorkPermitAssessmentReportTitle;
        }

        public string FormNumber
        {
            get
            {
                var id = permitAssessment.IdValue;
                return PadFormNumber(id);
            }
        }

        public string StartDate
        {
            get { return permitAssessment.FromDateTime.ToLongDateAndTimeString(); }
        }

        public string EndDate
        {
            get { return permitAssessment.ToDateTime.ToLongDateAndTimeString(); }
        }

        public long FormId
        {
            get { return permitAssessment.IdValue; }
        }

        public string CreatedByUser
        {
            get { return permitAssessment.CreatedBy.FullName; }
        }

        public string Contractor
        {
            get
            {
                if (!IssueToContractor) return string.Empty;
                return permitAssessment.Contractor;
            }
        }

        public string LastModifiedUser
        {
            get { return permitAssessment.LastModifiedBy.FullName; }
        }

        public string CreationDateTime
        {
            get { return permitAssessment.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public string LastModifiedDateTime
        {
            get { return permitAssessment.LastModifiedDateTime.ToLongDateAndTimeString(); }
        }

        public List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    permitAssessment.FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(floc));
            }
        }

        public decimal TotalScore
        {
            get { return permitAssessment.TotalScoredPercentage; }
        }

        public string LocationEquipmentNumber
        {
            get { return permitAssessment.LocationEquipmentNumber; }
        }

        public string QuestionnaireVersion
        {
            get { return permitAssessment.QuestionnaireVersion.ToString(); }
        }

        public string PermitStartDateTime
        {
            get { return permitAssessment.FromDateTime.ToLongDateAndTimeString(); }
        }

        public string PermitExpiredDateTime
        {
            get { return permitAssessment.ToDateTime.ToLongDateAndTimeString(); }
        }

        public bool IsIlpRecommended
        {
            get { return permitAssessment.IsIlpRecommended != null && permitAssessment.IsIlpRecommended.Value; }
        }

        public bool IsIlpNotRecommended
        {
            get { return permitAssessment.IsIlpRecommended == null || !permitAssessment.IsIlpRecommended.Value; }
        }

        public string PermitNumber
        {
            get { return permitAssessment.PermitNumber; }
        }

        public bool BlanketHotPermitType
        {
            get { return permitAssessment.OilsandsWorkPermitType == OilsandsWorkPermitType.BlanketHot; }
        }

        public bool BlanketColdPermitType
        {
            get { return permitAssessment.OilsandsWorkPermitType == OilsandsWorkPermitType.BlanketCold; }
        }

        public bool SpecificHotPermitType
        {
            get { return permitAssessment.OilsandsWorkPermitType == OilsandsWorkPermitType.SpecificHot; }
        }

        public bool SpecificColdPermitType
        {
            get { return permitAssessment.OilsandsWorkPermitType == OilsandsWorkPermitType.SpecificCold; }
        }

        public bool IssueToContractor
        {
            get { return permitAssessment.IssuedToContractor; }
        }

        public bool IssueToSuncor
        {
            get { return permitAssessment.IssuedToSuncor; }
        }


        public string Trade
        {
            get { return permitAssessment.Trade; }
        }

        public string JobDescription
        {
            get { return permitAssessment.JobDescription; }
        }

        public string JobCoordinator
        {
            get { return permitAssessment.JobCoordinator; }
        }

        public string CrewSize
        {
            get { return permitAssessment.CrewSize.ToString(); }
        }

        public List<PermitAssessmentAnswerReportAdapter> PermitAssessmentAnswers
        {
            get
            {
                var unsortedAnswers = permitAssessment.Answers;

                var sortedAnswers =
                    unsortedAnswers.OrderBy(answer => answer.SectionDisplayOrder)
                        .ThenBy(answer => answer.DisplayOrder)
                        .ToList();

                return
                    sortedAnswers.ConvertAll(
                        item => new PermitAssessmentAnswerReportAdapter(permitAssessment.IdValue, item));
            }
        }

        public string OverallFeedback
        {
            get { return permitAssessment.OverallFeedback; }
        }

        public string WatermarkText
        {
            get
            {
                if (permitAssessment.FormStatus == FormStatus.Cancelled)
                {
                    return permitAssessment.FormStatus.Name;
                }
                return string.Empty;
            }
        }
    }
}