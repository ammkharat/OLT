using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class SarniaEipIssueReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        public SarniaEipIssueReportAdapter(FormGN75B form, List<long> gn75BFormNumbers)
        { 
            FormNumber = PadFormNumber(form.FormNumber);
            BlindsRequired = form.BlindsRequired.BooleanToYesNoString();
            ImplementingDeadLeg = form.DeadLeg.BooleanToYesNoString();
            DeadLegRisk = form.DeadLegRisk.BooleanToYesNoString();                   //ayman Sarnia eip - 2
            ClosedDateTime = form.ClosedDateTime.HasValue
                ? form.ClosedDateTime.Value.ToLongDateAndTimeString()
                : string.Empty;
            GeneralWorkToBePerformed = form.LocationOfWork;
            CreatedBy = form.CreatedBy.FullNameWithUserName;
            var approvedby = form.AllApprovals.ConvertAll(a => a.ApprovedByUserName);
            if (approvedby.Count > 0)
            {
                ApprovedBy = approvedby[0];
                var approvaldate = form.AllApprovals.ConvertAll(a => a.ApprovalDateTime);
                if (approvaldate[0] != null)
                    ApprovalDate = approvaldate[0].Value.ToDateString();
            }
            //if(form.Approvals[0].ApprovedByUser != null)
            // ApproverID = form.Approvals[0].ApprovedByUser.IdValue;
            SpecialPrecautions = form.SpecialPrecautions;
            CreationDateTime = form.CreatedDateTime.ToDateString();
            Status = form.FormStatus.GetName();
            FunctionalLocation = form.FunctionalLocation.FullHierarchyWithDescription;
            FlocDesc = form.FunctionalLocation.Description;

            for (int i = form.IsolationItems.Count + 1; i < 15; i++)                            //ayman Sarnia eip - 3
            {
                form.IsolationItems.Add(new IsolationItem(null, i, 0, null, null, null, 1));
            }


            IsolationReportAdapters = form.IsolationItems.ConvertAll(item => new IsolationForSarniaReportAdapter(item));
            LockBoxLocation = form.LockBoxLocation;
            LockBoxNumber = form.LockBoxNumber;
            LastModifiedBy = form.LastModifiedBy.FullNameWithUserName;
            LastModifiedDateTime = form.LastModifiedDateTime.ToLongDateAndTimeString();

            GN75BForms = gn75BFormNumbers == null ? string.Empty : gn75BFormNumbers.ToCommaSeparatedString();

            SchematicImage = form.SchematicImage;

            if (form.IsDeleted)
            {
                WatermarkText = StringResources.Deleted;
            }
            else if (form.FormStatus == FormStatus.Closed)
            {
                WatermarkText = form.FormStatus.Name;
            }
        }

        public string FormNumber { get; private set; }
        public string FunctionalLocation { get; private set; }
        public string GeneralWorkToBePerformed { get; private set; }

        public bool BlindsYes
        {
            get
            {
                if (BlindsRequired == "Yes")
                { return true; }
                else
                { return false; }
            }

            private set { }
        }

        public bool BlindsNo
        {
            get
            {
                if (BlindsRequired == "No")
                { return true; }
                else
                { return false; }
            }

            private set { }
        }

        public bool DeadLegYes
        {
            get
            {
                if (ImplementingDeadLeg == "Yes")
                { return true; }
                else
                { return false; }
            }

            private set { }
        }

        public bool DeadLegNo
        {
            get
            {
                if (ImplementingDeadLeg == "No")
                { return true; }
                else
                { return false; }
            }

            private set { }
        }

        public bool DeadLegRiskYes
        {
            get
            {
                if (DeadLegRisk == "Yes")
                { return true; }
                else
                { return false; }
            }

            private set { }
        }

        public bool DeadLegRiskNo
        {
            get
            {
                if (DeadLegRisk == "No")
                { return true; }
                else
                { return false; }
            }

            private set { }
        }


        public string CreatedBy { get; private set; }
        public string LastModifiedBy { get; private set; }
        public string CreationDateTime { get; private set; }
        public string LastModifiedDateTime { get; private set; }
        public string ClosedDateTime { get; private set; }

        public string ApprovedBy { get; private set; }                //ayman Sarnia eip - 3
        public string ApprovalDate { get; private set; }          //ayman Sarnia eip - 3

        public string SpecialPrecautions { get; private set; }
        public string BlindsRequired { get; private set; }

        public string ImplementingDeadLeg { get; private set; }
        public string DeadLegRisk { get; private set; }                  //ayman Sarnia eip - 2

        public string LockBoxNumber { get; private set; }
        public string LockBoxLocation { get; private set; }

        public string FlocDesc { get; private set; }
        public string Status { get; private set; }

        public byte[] SchematicImage { get; private set; }

        public List<IsolationForSarniaReportAdapter> IsolationReportAdapters { get; private set; }

        public string GN75BForms { get; private set; }

        public string WatermarkText { get; private set; }
    }

    //public class IsolationReportAdapter
    //{
    //    public IsolationReportAdapter(IsolationItem isolationItem)
    //    {
    //        DisplayOrder = isolationItem.DisplayOrder;
    //        IsolationType = isolationItem.IsolationType;
    //        LocationOfEnergyIsolation = isolationItem.LocationOfEnergyIsolation;
    //    }

    //    public string LocationOfEnergyIsolation { get; private set; }
    //    public string IsolationType { get; private set; }
    //    public int DisplayOrder { get; private set; }
    //}
}