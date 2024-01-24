using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms.VisualStyles;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;


namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN75B : ModifiableDomainObject, IFunctionalLocationRelevant, IEdmontonForm, IDocumentLinksObject
    {
        private FormStatus formStatus = FormStatus.Approved;
        private long siteId;        //ayman Sarnia eip DMND0008992
        private List<FormApproval> approvals = new List<FormApproval>();
        private EdmontonFormType formtype;            //ayman Sarnia eip DMND0008992



        public FormGN75B(long id, FormStatus formStatus, FunctionalLocation functionalLocation, string locationOfWork,
            List<IsolationItem> isolationItems, User createdBy, DateTime createdDateTime,
            User lastModifiedBy, DateTime lastModifiedDateTime, DateTime? closedDateTime, bool blindsRequired, bool deadleg, bool deadlegrisk,
            string equipmentType, string lockBoxNumber, string lockBoxLocation, long siteid, List<DevicePosition> devicePositions, long templateid, List<FormApproval> approvals,string flocdesc,string specialprecautions)   //ayman generic forms         ayman Sarnia eip DMND0008992
            : this(
                functionalLocation, locationOfWork, isolationItems, createdBy, createdDateTime, lastModifiedBy,
                lastModifiedDateTime, blindsRequired,deadleg, deadlegrisk, equipmentType, lockBoxNumber, lockBoxLocation, siteid, devicePositions, templateid, approvals,specialprecautions)   //ayman Sarnia eip DMND0008992
        {
            this.id = id;
            FormStatus = formStatus;
            ClosedDateTime = closedDateTime;
            SiteID = siteid; //ayman Sarnia eip DMND0008992
            Approvals = approvals;    //ayman Sarnia eip DMND0008992
        }

        public FormGN75B(FunctionalLocation functionalLocation, string locationOfWork,
            List<IsolationItem> isolationItems, User createdBy, DateTime createdDateTime, User lastModifiedBy,
            DateTime lastModifiedDateTime, bool blindsRequired, bool deadleg, bool deadlegrisk, string equipmentType, string lockBoxNumber,
            string lockBoxLocation, long siteid, List<DevicePosition> devicePositions, long templateid, List<FormApproval> approvals,string specialprecautions)     // ayman Sarnia eip DMND0008992
            : base(lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocation = functionalLocation;
            LocationOfWork = locationOfWork;
            IsolationItems = isolationItems;
            DevicePositions = devicePositions;      // ayman Sarnia eip DMND0008992
            TemplateID = templateid;                //ayman Sarnia eip DMND0008992
            SiteID = siteid;                        //ayman Sarnia eip DMND0008992
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            BlindsRequired = blindsRequired;
            DeadLeg = deadleg;                      //ayman Sarnia eip DMND0008992
            DeadLegRisk = deadlegrisk;             //ayman Sarnia eip - 2
            SpecialPrecautions = specialprecautions;      //ayman Sarnia eip DMND0008992
            EquipmentType = equipmentType;
            LockBoxNumber = lockBoxNumber;
            LockBoxLocation = lockBoxLocation;
            Approvals = approvals; // new List<FormApproval>();
            DocumentLinks = new List<DocumentLink>();

            if (SiteID == Site.SARNIA_ID)
            {

                Approvals = new List<FormApproval>
                {
                    new FormApproval(null, id, "Plan approved by", null, null, null, 1),
                };
            }

        }




        public DateTime CreatedDateTime { get; set; }
        public FunctionalLocation FunctionalLocation { get; set; }
        public string LocationOfWork { get; set; }
        public string PathToSchematic { get; private set; }
        public byte[] SchematicImage { get;  set; }

        public DateTime? ClosedDateTime { get; private set; }

        public bool BlindsRequired { get; set; }

        public bool DeadLegRisk { get; set; }        //ayman Sarnia eip - 2
        public bool DeadLeg { get; set; }         //ayman Sarnia eip DMND0008992

        public string SpecialPrecautions { get; set; }      //ayman Sarnia eip DMND0008992

        public string EquipmentType { get; set; }
        public string LockBoxNumber { get; set; }
        public string LockBoxLocation { get; set; }

        public string OperatorText { get; set; }  //RITM0468037EN50 : OLT:: Edmonton:: GN75B changes Aarti 

        ////ayman generic forms
        //public long SiteId { get; set; }

        public bool IsDeleted { get; set; }

        public List<IsolationItem> IsolationItems { get; set; }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> Approvals
        {
            get { return approvals; }
            set { approvals = value; }
        }

        //ayman Sarnia eip DMND0008992
        public virtual bool AllApprovalsAreIn()
        {
            return FormApproval.AllApprovalsAreIn(AllApprovals);
        }

        //ayman Sarnia eip DMND0008992
        public virtual List<FormApproval> AllApprovals
        {
            get { return Approvals; }
        }


        public List<DevicePosition> DevicePositions { get; set; }   // ayman Sarnia eip DMND0008992

        public long TemplateID { get; set; }                        //ayman Sarnia eip DMND0008992

        public List<DocumentLink> DocumentLinks { get; set; }
        public User CreatedBy { get; set; }

        public DateTime FromDateTime
        {
            get { return DateTime.MinValue; }
        }

        public DateTime ToDateTime
        {
            get { return DateTime.MaxValue; }
        }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> EnabledApprovals
        {

            get {

                if (Approvals == null) return null;

                return    Approvals.FindAll(a => a.Enabled);

            }
        }



        public FormStatus FormStatus
        {
            get { return formStatus; }

            set
            {
                formStatus = value;
                if (value == FormStatus.Approved)
                {
                    ClosedDateTime = null;
                }
            }
        }

        //ayman Sarnia eip DMND0008992
        public long SiteID
        {
            get { return siteId; }
            set { siteId = value; }
        }


        public EdmontonFormType FormType                       //ayman Sarnia eip DMND0008992
        {
            get
            {
                EdmontonFormType thetype = null;
                if (SiteID == 1)
                {
                    if (LockBoxNumber == null)
                    {
                        thetype = EdmontonFormType.GN75BTemplate;
                    }
                    else
                    {
                        thetype = EdmontonFormType.GN75BSarniaEIP;
                    }
                }
                else
                {
                    return EdmontonFormType.GN75B;
                }
                return thetype;
            }
            set { formtype = value; }
        }

        public long FormNumber
        {
            get { return IdValue; }
        }

        public void ConvertToClone(User user)
        {
            var now = Clock.Now;

            Id = null;
            CreatedBy = user;
            CreatedDateTime = now;
            LastModifiedBy = user;
            LastModifiedDateTime = now;

            FormStatus = FormStatus.Approved;

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());

            ClosedDateTime = null;


            //SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());

            FormStatus = FormStatus.WaitingForApproval;

             
            ClosedDateTime = null;

            if (AllApprovals != null)
            {
                AllApprovals.ForEach(approval => approval.Unapprove());          //ayman Sarnia eip - 2
                AllApprovals.ForEach(approval => approval.Approver = "Plan approved by"); // INC0433199 : Added by vibhor (Cloning an EIP issue carries the name of the approver into the newly cloned document)
            }
            
        }


        public void MarkAsClosed(DateTime dateTime, User user)
        {
            ClosedDateTime = dateTime;
            FormStatus = FormStatus.Closed;
            LastModifiedBy = user;
        }

        public IFormEdmontonDTO CreateDTO()
        {
            return new FormEdmontonGN75BDTO(this);
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies,
            List<string> workPermitEdmontonFullHierarchies, List<string> restrictionsFullHierarchies,
            SiteConfiguration siteConfiguration)
        {
            List<string> fullHierarchies;

            if (siteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
                !workPermitEdmontonFullHierarchies.IsEmpty())
            {
                fullHierarchies = workPermitEdmontonFullHierarchies;
            }
            else
            {
                fullHierarchies = clientFullHierarchies;
            }

            return CheckFlocRelevancy(siteIdOfClient, fullHierarchies);
        }

        private bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, new List<FunctionalLocation>() { FunctionalLocation });
        }

        private bool CheckFlocRelevancyForMultipleFlocs(long siteIdOfClient, List<string> fullHierarchies,
            List<FunctionalLocation> flocsForThisForm)
        {
            foreach (var floc in flocsForThisForm)
            {
                var isRelevant = CheckFlocRelevancyForASingleFloc(siteIdOfClient, fullHierarchies, floc);

                if (isRelevant)
                    return true;
            }

            return false;
        }

        private static bool CheckFlocRelevancyForASingleFloc(long siteIdOfClient, List<string> fullHierarchies,
            FunctionalLocation floc)
        {
            var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                             new WalkUpRelevance(floc).IsRelevantTo(siteIdOfClient, fullHierarchies) ||
                             new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, fullHierarchies);

            return isRelevant;
        }


        public void ClearSchematic()
        {
            AddSchematic(null, null);
        }

        public void AddSchematic(string uncPathToSchematic, byte[] image)
        {
            // could be setting them to none.
            if (string.IsNullOrEmpty(uncPathToSchematic))
            {
                PathToSchematic = null;
                SchematicImage = null;
            }
            else
            {
                PathToSchematic = uncPathToSchematic;
                SchematicImage = image;
            }
        }

        public bool IsDatesWithinFormDates(Range<DateTime> workPermitDateTimes)
        {
            return true;
        }

        public FormGN75BHistory TakeSnapshot()
        {
            var isolations =
                IsolationItems.ConvertAll(
                    isolation =>
                        String.Format("{0} ({1}, {2})", isolation.DisplayOrder, isolation.IsolationType,
                            isolation.LocationOfEnergyIsolation))
                    .BuildCommaSeparatedList();
            return new FormGN75BHistory(IdValue, FunctionalLocation.FullHierarchy, LocationOfWork, BlindsRequired,
                EquipmentType, LockBoxNumber, LockBoxLocation, isolations,
                DocumentLinks.AsString(link => link.TitleWithUrl), ClosedDateTime, FormStatus, SchematicImage,
                LastModifiedBy, LastModifiedDateTime);
        }


        ////ayman Sarnia eip DMND0008992
        //public bool WillNeedReapproval(User currentUser, bool noReapprovalRequiredForEndDateChange,
        //  FunctionalLocation originalFloc, DateTime originalFromDateTime, DateTime originalToDateTime,
        //  string originalPlainTextContent, long? originalGn75BAssociationId, List<DocumentLink> originalDocumentLinks)
        //{
        //    if (!ThereAreCurrentlyApprovalsByOtherPeople(currentUser))
        //    {
        //        return false;
        //    }

        //return SomethingRequiringReapprovalHasChanged(noReapprovalRequiredForEndDateChange, originalFloc,
        //    originalFromDateTime, originalToDateTime, originalPlainTextContent, originalGn75BAssociationId,
        //    originalDocumentLinks);
        //  }


        public bool ThereAreCurrentlyApprovalsByOtherPeople(User currentUser)
        {
            return FormApproval.ThereAreCurrentlyApprovalsByOtherPeople(AllApprovals, currentUser);
        }

        //ayman Sarnia eip DMND0008992
        public bool SomethingRequiringReapprovalHasChanged(User currentuser, long originalEipTemplateNumber, List<DocumentLink> originalDocumentLinks, FunctionalLocation originalFloc, string originalLocationOfWork,bool originalblindsrequired, bool originaldeadleg,string specialprecautions)
        {
            if (!ThereAreCurrentlyApprovalsByOtherPeople(currentuser))                    //ayman Sarnia eip - 2
            {
                return false;
            }

            var eipTemplateNumber = originalEipTemplateNumber != TemplateID;
            var flocChanged = originalFloc.IdValue != FunctionalLocation.IdValue;
            var locationofwork = originalLocationOfWork != LocationOfWork;
            var documentLinksChanged = !DocumentLinks.EqualsByElement(originalDocumentLinks);
            var blindsrequiredchanged = originalblindsrequired != BlindsRequired;
            var deadlegchanged = originaldeadleg != DeadLeg;
            var specialprecautionschanged = specialprecautions != SpecialPrecautions;             
            return eipTemplateNumber || flocChanged || locationofwork || documentLinksChanged || blindsrequiredchanged || deadlegchanged || specialprecautionschanged;
        }


    }
}