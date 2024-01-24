using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class LubesAlarmDisableForm : BaseEdmontonForm, IDocumentLinksObject
    {
        public LubesAlarmDisableForm(long? id,
            FormStatus formStatus,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            User createdBy,
            DateTime createdDateTime)             //ayman generic forms disable siteid
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();

            Approvals = new List<FormApproval>
            {
                new FormApproval(null, id, "Lead Tech", null, null, null, 1),
                new FormApproval(null, id, "Supervisor", null, null, null, 2),
            };
        }

        public FunctionalLocation FunctionalLocation { get; set; }

        public string Location { get; set; }

        public string Criticality { get; set; }
        public string Alarm { get; set; }
        public string SapNotification { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.LubesAlarmDisable; }
        }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }
        public bool HasBeenApproved { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new LubesAlarmDisableFormDTO(IdValue,
                FunctionalLocation.FullHierarchy,
                Alarm,
                CreatedBy.IdValue,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                ApprovedDateTime,
                ClosedDateTime,
                RemainingApprovalsAsStringList(),
                HasBeenApproved,
                LastModifiedBy.FullNameWithUserName,
                Criticality,
                SapNotification);
        }

        public override void ConvertToClone(User createdByUser)
        {
            base.ConvertToClone(createdByUser);
            HasBeenApproved = false;
        }

        public bool IsActiveAndRequiresApproval(DateTime now)
        {
            return FromDateTime < now && ToDateTime > now && FormStatus == FormStatus.Draft;
        }

        public override void SetDefaultDatesBasedOnShift(bool isDayShift, Date currentDate, Time currentTime)
        {
            var userShift = WorkPermitLubes.UserShift(Clock.Now);

            FromDateTime = userShift.StartDateTime;
            ToDateTime = userShift.EndDateTime;
        }

        public LubesAlarmDisableFormHistory TakeSnapshot()
        {
            var approvals = GetApprovalsSnapshot();
            return new LubesAlarmDisableFormHistory(IdValue,
                FormStatus,
                FunctionalLocation.FullHierarchy,
                Location,
                PlainTextContent,
                FromDateTime,
                ToDateTime,
                approvals,
                LastModifiedBy,
                LastModifiedDateTime,
                ApprovedDateTime,
                ClosedDateTime,
                Alarm,
                Criticality,
                SapNotification,
                DocumentLinks.AsString(link => link.TitleWithUrl));
        }

        public override void MarkAsApproved(DateTime? approvedDateTime)
        {
            base.MarkAsApproved(approvedDateTime);
            HasBeenApproved = true;
        }

        public bool WillNeedReapproval(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            FunctionalLocation originalFloc,
            string originalLocationText,
            User user,
            bool userCanChangeValidToWithoutReApproval,
            string originalCriticality,
            string originalAlarm)
        {
            var thereAreCurrentlyApprovalsByOtherPeople = ThereAreCurrentlyApprovalsByOtherPeople(user);
            if (!thereAreCurrentlyApprovalsByOtherPeople)
            {
                return false;
            }

            return SomethingRequiringReapprovalHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFloc,
                originalLocationText,
                user,
                userCanChangeValidToWithoutReApproval,
                originalCriticality,
                originalAlarm);
        }

        public bool SomethingRequiringReapprovalHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            FunctionalLocation originalFloc,
            string originalLocationText,
            User user,
            bool userCanChangeValidToWithoutReApproval,
            string originalCriticality,
            string originalAlarm)
        {
            var aMainValueHasChanged = AMainValueHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFloc,
                originalLocationText,
                userCanChangeValidToWithoutReApproval);
            var criticalityChanged = originalCriticality != Criticality;
            var alarmChanged = originalAlarm != Alarm;

            return aMainValueHasChanged || criticalityChanged || alarmChanged;
        }

        private bool AMainValueHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            FunctionalLocation originalFloc,
            string originalLocationText,
            bool userCanChangeValidToWithoutReApproval)
        {
            var contentChanged = originalPlainTextContent != PlainTextContent;
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var validToChanged = originalValidToDateTime != ToDateTime;
            if (userCanChangeValidToWithoutReApproval)
            {
                validToChanged = false;
            }

            var flocChanged = originalFloc.FullHierarchyWithDescription !=
                              FunctionalLocation.FullHierarchyWithDescription;

            var locationTextChanged = originalLocationText != Location;

            return (contentChanged || validFromChanged || validToChanged || flocChanged || locationTextChanged);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForASingleFloc(siteIdOfClient, fullHierarchies, FunctionalLocation);
        }
    }
}