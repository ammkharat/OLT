using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public abstract class BaseEdmontonFormReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        protected readonly BaseEdmontonForm edmontonForm;

        protected BaseEdmontonFormReportAdapter(BaseEdmontonForm baseForm)
        {
            FormNumber = PadFormNumber(baseForm.FormNumber);
            CreatedBy = baseForm.CreatedBy.FullNameWithUserName;
            LastModifiedBy = baseForm.LastModifiedBy.FullNameWithUserName;

            CreationDateTime = baseForm.CreatedDateTime.ToLongDateAndTimeString();
            LastModifiedDateTime = baseForm.LastModifiedDateTime.ToLongDateAndTimeString();

            Status = baseForm.FormStatus.GetName();

            ValidFrom = baseForm.FromDateTime.ToLongDateAndTimeString();
            ValidTo = baseForm.ToDateTime.ToLongDateAndTimeString();

            ApprovalsReportAdapters = baseForm.EnabledApprovals.ConvertAll(a => new ApprovalReportAdapter(a));

            IsDeleted = baseForm.IsDeleted;

            edmontonForm = baseForm;
        }

        public string FormNumber { get; private set; }
        public string CreatedBy { get; private set; }
        public string LastModifiedBy { get; private set; }
        public string CreationDateTime { get; private set; }
        public string LastModifiedDateTime { get; private set; }

        public virtual string Status { get; private set; }
        public bool IsDeleted { get; private set; }

        public string ValidFrom { get; private set; }
        public string ValidTo { get; private set; }

        public List<ApprovalReportAdapter> ApprovalsReportAdapters { get; set; }

        public override string Label_Title
        {
            get { return edmontonForm.FormType.GetName(); }
            protected set
            {
                throw new NotImplementedException(
                    "Setting the report title is intentionally not implemented for Edmonton forms");
            }
        }

        public abstract List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters { get; }

        public virtual string ValidFromLabel
        {
            get { return "Valid From:"; }
        }

        public virtual string ValidToLabel
        {
            get { return "Valid To:"; }
        }
    }
}