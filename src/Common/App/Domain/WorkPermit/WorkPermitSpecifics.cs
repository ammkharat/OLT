using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Represents the 'Location / Job Specifics / Scope' section of a work permit.
    /// </summary>
    [Serializable]
    public class WorkPermitSpecifics : ComparableObject
    {
        private readonly ISiteSpecificDateTimeHandler handler;
        private WorkPermitCommunication communication = new WorkPermitCommunication();
        private string contactName;
        private string contractorCompanyName;
        public ICraftOrTrade craftOrTrade;
        private FunctionalLocation functionalLocation;
        private string jobStepDescription;
        private WorkAssignment workAssignment;
        private string workOrderDescription;
        private string workOrderNumber;

        public WorkPermitSpecifics()
        {
        }

        internal WorkPermitSpecifics(ISiteSpecificDateTimeHandler handler)
        {
            this.handler = handler;
        }

        public WorkPermitSpecifics(ICraftOrTrade defaultCraftOrTrade, UserWorkPermitDefaultTimePreferences prefs,
            SiteConfiguration siteConfiguration, UserShift currentShift, ISiteSpecificDateTimeHandler handler,
            DateTime currentTimeAtSite)
        {
            this.handler = handler;
            InitializeDateTimes(prefs, currentShift, currentTimeAtSite);

            FunctionalLocation = null;
            CraftOrTrade = defaultCraftOrTrade;
            Communication.InitializeWithSensibleDefaults(siteConfiguration);

            SetOptionDefaults(siteConfiguration);
        }


        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]         //ayman USPipeline workpermit  // mangesh uspipeline to selc
        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
            set { functionalLocation = value; }
        }

        public string FunctionalLocationName
        {
            get { return (functionalLocation == null) ? string.Empty : functionalLocation.FullHierarchy; }
            set { functionalLocation.FullHierarchy = value; }
        }

        [SarniaWorkPermit]
        public WorkAssignment WorkAssignment
        {
            get { return workAssignment; }
            set { workAssignment = value; }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string WorkOrderNumber
        {
            get { return workOrderNumber; }
            set { workOrderNumber = value.EmptyToNull(); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public DateTime StartDateTime { get; set; }

        [DenverWorkPermit]
        [USPipelineWorkPermit]
        [SELCWorkPermit]
        public bool StartTimeNotApplicable { get; set; }

        public Date StartDate
        {
            get { return new Date(StartDateTime); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        ///     This is a weird property in that both Sarnia and Denver use it (despite it only having the Denver attribute)
        ///     but use it very differently.  In Denver it is tied to the 'N/A' checkbox on the form and only pertains to
        ///     the end time.  In Sarnia it is not bound to the form but instead is used to reset the start and end times
        ///     when editing a permit that came from SAP -- apparently the times coming in from SAP are often wrong.
        /// </summary>
        [DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool StartAndOrEndTimesFinalized { get; set; }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string WorkOrderDescription
        {
            get { return workOrderDescription; }
            set { workOrderDescription = value.EmptyToNull(); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string JobStepDescription
        {
            get { return jobStepDescription; }
            set { jobStepDescription = value.EmptyToNull(); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string ContactName
        {
            get { return contactName; }
            set { contactName = value.EmptyToNull(); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string ContractorCompanyName
        {
            get { return contractorCompanyName; }
            set { contractorCompanyName = value.EmptyToNull(); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public ICraftOrTrade CraftOrTrade
        {
            get { return craftOrTrade; }
            set { craftOrTrade = value; }
        }

        public string CraftOrTradeName
        {
            get { return (craftOrTrade == null) ? string.Empty : craftOrTrade.Name; }
            set { craftOrTrade.Name = value; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitCommunication Communication
        {
            get { return communication; }
            set { communication = value; }
        }

        public void InitializeDateTimes(UserWorkPermitDefaultTimePreferences prefs, UserShift shift, DateTime now)
        {
            handler.InitializeDateTimes(this, prefs, shift, now);
        }

        public void ReInitializeStartAndOrEndDateTimes(UserWorkPermitDefaultTimePreferences prefs, UserShift shift,
            DateTime now)
        {
            handler.ReinitializeStartAndOrEndDateTimes(this, prefs, shift, now);
        }

        private void SetOptionDefaults(SiteConfiguration siteConfiguration)
        {
            if (!siteConfiguration.WorkPermitOptionAutoSelected)
            {
                contractorCompanyName = null;
                communication.ByRadio = null;
            }
            else
            {
                contractorCompanyName = string.Empty;
            }
        }

        /// <summary>
        ///     Returns a deep copy of this entire section of the work permit.
        /// </summary>
        public WorkPermitSpecifics Copy(bool copyCommunicationMethod, DateTime startDateTime, DateTime? endDateTime)
        {
            var copy = new WorkPermitSpecifics(handler)
            {
                FunctionalLocation = FunctionalLocation,
                WorkOrderNumber = WorkOrderNumber,
                WorkOrderDescription = WorkOrderDescription,
                JobStepDescription = JobStepDescription,
                WorkAssignment = WorkAssignment,
                ContactName = ContactName,
                ContractorCompanyName = ContractorCompanyName,
                CraftOrTrade = CraftOrTrade.Copy(),
                // Do not copy the date time of the permit being cloned.
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            };

            if (copyCommunicationMethod)
            {
                copy.Communication = Communication.Copy();
            }

            return copy;
        }
    }
}