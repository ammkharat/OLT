using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FormOilsandsTrainingReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly FormOilsandsTraining trainingForm;

        public FormOilsandsTrainingReportAdapter(FormOilsandsTraining trainingForm)
        {
            this.trainingForm = trainingForm;
            Label_Title = StringResources.DomainObjectName_OilsandsTrainingForm;
        }

        public string FormNumber
        {
            get
            {
                var id = trainingForm.IdValue;
                return PadFormNumber(id);
            }
        }

        public long FormId
        {
            get { return trainingForm.IdValue; }
        }

        public string TrainingDate
        {
            get { return trainingForm.TrainingDate.ToLongDate(); }
        }

        public string GeneralComments
        {
            get { return trainingForm.GeneralComments; }
        }

        public string Shift
        {
            get { return trainingForm.ShiftPattern.Name; }
        }

        public string CreatedByUser
        {
            get { return trainingForm.CreatedBy.FullName; }
        }

        public string LastModifiedUser
        {
            get { return trainingForm.LastModifiedBy.FullName; }
        }

        public string CreationDateTime
        {
            get { return trainingForm.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public string LastModifiedDateTime
        {
            get { return trainingForm.LastModifiedDateTime.ToLongDateAndTimeString(); }
        }

        public List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get
            {
                return
                    trainingForm.FunctionalLocations.ConvertAll(
                        floc => new FunctionalLocationReportAdapter(trainingForm.IdValue, floc));
            }
        }

        public List<TrainingBlockReportAdapter> TrainingBlockReportAdapters
        {
            get
            {
                return
                    trainingForm.TrainingItems.ConvertAll(
                        item => new TrainingBlockReportAdapter(trainingForm.IdValue, item));
            }
        }

        public List<ApprovalReportAdapter> ApprovalReportAdapters
        {
            get
            {
                return
                    trainingForm.Approvals.ConvertAll(
                        approval =>
                            new ApprovalReportAdapter(trainingForm.IdValue, approval.Approver, approval.ApprovedByUser,
                                approval.ApprovalDateTime, null));
            }
        }

        public string WatermarkText
        {
            get { return trainingForm.FormStatus.Name; }
        }
    }
}