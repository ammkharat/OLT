using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class OvertimeForm : BaseEdmontonForm, IDocumentLinksObject
    {
        private List<OnPremiseContractor> contractors;

        public OvertimeForm(long? id,
            FormStatus formStatus,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            User createdBy,
            DateTime createdDateTime,
            List<OnPremiseContractor> onPremiseContractors,
            FunctionalLocation functionalLocation,
            string trade,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime? cancelledDateTime,long siteid)              //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)
        {
            OnPremiseContractors = onPremiseContractors;
            FunctionalLocation = functionalLocation;
            Trade = trade;
            CancelledDateTime = cancelledDateTime;
            Approvals = new List<FormApproval>
            {
                new FormApproval(null,
                    id,
                    "Suncor Designate (Maint/Const/Field Coordinator, Maint/Facilities/Shift Supervisor, Planning Mgr)",
                    null,
                    null,
                    null,
                    1)
            };

            DocumentLinks = new List<DocumentLink>();

            // these 
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        public string Trade { get; set; }
        public DateTime? CancelledDateTime { get; private set; }

        public FunctionalLocation FunctionalLocation { get; private set; }

        public List<OnPremiseContractor> OnPremiseContractors
        {
            get { return contractors; }
            set
            {
                contractors = value;
                if (contractors.IsEmpty())
                    return;

                // set the valid from/to according to the list of contractors
                FromDateTime = contractors.Min(c => c.StartDateTime);
                ToDateTime = contractors.Max(c => c.EndDateTime);
            }
        }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.Overtime; }
        }

        public List<DocumentLink> DocumentLinks { get; set; }

        public override void MarkAsClosed(DateTime closedDateTime, User user)
        {
            CancelledDateTime = closedDateTime;
            FormStatus = FormStatus.Cancelled;
            LastModifiedBy = user;
        }

        public override void ConvertToClone(User createdByUser)
        {
            base.ConvertToClone(createdByUser);
            DocumentLinks = DocumentLinks.ConvertAll(input => input.CloneWithoutId());
            OnPremiseContractors = OnPremiseContractors.ConvertAll(input => input.CloneWithoutId());
        }

        public override IFormEdmontonDTO CreateDTO()
        {
            var approvedByUser = string.Empty;

            if (Approvals.Count > 0 && Approvals[0].ApprovedByUser != null)
            {
                approvedByUser = Approvals[0].ApprovedByUser.FullNameWithUserName;
            }

            var dto = new EdmontonOvertimeFormDTO(IdValue,
                new List<string> {FunctionalLocation.FullHierarchy},
                FormType,
                CreatedBy.IdValue,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                ApprovedDateTime,
                CancelledDateTime,
                Trade,
                OnPremiseContractors.Sum(c => c.ExpectedHours),
                LastModifiedBy.FullNameWithUserName,
                approvedByUser);

            if (Approvals.Count > 0)
            {
                var remainingApproval = Approvals[0].Approver;
                dto.AddRemainingApproval(remainingApproval);
            }

            return dto;
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return siteIdOfClient == Site.EDMONTON_ID;
        }

        public bool WillNeedReapproval(OvertimeForm originalOvertimeForm)
        {
            // something may or may not have changed, but it doesn't matter because it was changed by the approver.
            if (!ThereAreCurrentlyApprovalsByOtherPeople(LastModifiedBy))
            {
                return false;
            }
            if (!Trade.Equals(originalOvertimeForm.Trade))
            {
                return true;
            }

            var newContractors = OnPremiseContractors;

            // there is a new Contractor added.
            if (newContractors.Exists(a => !a.Id.HasValue))
            {
                return true;
            }

            var originalContractors = originalOvertimeForm.OnPremiseContractors;

            // a contractor was removed
            foreach (var old in originalContractors)
            {
                if (!newContractors.ExistsById(old))
                {
                    return true;
                }
            }

            // all the same contractors, but one of the required fields has changed on one them. 
            foreach (var old in originalContractors)
            {
                var @new = newContractors.FindById(old);
                if (!string.Equals(@new.PersonnelName, old.PersonnelName) ||
                    !string.Equals(@new.PrimaryLocation, old.PrimaryLocation) ||
                    !DateTime.Equals(@new.StartDateTime, old.StartDateTime) ||
                    !DateTime.Equals(@new.EndDateTime, old.EndDateTime) || @new.IsDayShift != old.IsDayShift ||
                    @new.IsNightShift != old.IsNightShift ||
                    !string.Equals(@new.Description, old.Description) || !string.Equals(@new.Company, old.Company) ||
                    @new.ExpectedHours != @old.ExpectedHours)
                    return true;
            }
            return false;
        }

        public FormOvertimeFormHistory TakeSnapshot()
        {
            return new FormOvertimeFormHistory(IdValue,
                FormStatus,
                FromDateTime,
                ToDateTime,
                LastModifiedBy,
                LastModifiedDateTime,
                FunctionalLocation.FullHierarchy,
                GetOnPremiseContractorsSnapshot(),
                Trade,
                GetApprovalsSnapshot(),
                DocumentLinks.AsString(link => link.TitleWithUrl),
                ApprovedDateTime,
                CancelledDateTime);
        }

        public string GetOnPremiseContractorsSnapshot()
        {
            return
                OnPremiseContractors.ConvertAll(
                    item =>
                        String.Format(StringResources.OvertimeForm_OnPremiseContractorsHistorySnapshot,
                            item.PersonnelName,
                            item.PrimaryLocation,
                            item.StartDateTime.ToLongDateAndTimeString(),
                            item.EndDateTime.ToLongDateAndTimeString(),
                            item.Shifts,
                            item.PhoneNumber,
                            item.Radio,
                            item.Description,
                            item.Company,
                            item.WorkOrderNumber,
                            item.ExpectedHours.Format()))
                    .BuildCommaSeparatedList();
        }
    }
}