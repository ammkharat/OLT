using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGenericTemplate : BaseEdmontonForm, IDocumentLinksObject
    {

        public FormGenericTemplate(long? id,
            FormStatus formStatus,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            User createdBy,
            DateTime createdDateTime, long siteId, EdmontonFormType formtype, Role createdByRole)    
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();

            IsTheCSDForAPressureSafetyValve = false;
            Department = FormOP14Department.Operations;

            FunctionalLocations = new List<FunctionalLocation>();
            SiteId = siteId;
            //FormType = formtype;
            CreatedByRole = createdByRole;
        }

        public List<FunctionalLocation> FunctionalLocations { get; set; }
        public FormOP14Department Department { get; set; }
        public bool IsTheCSDForAPressureSafetyValve { get; set; }
        public long SiteId { get; set; }
        public long FormTypeId { get; set; }
        public long PlantId { get; set; }
        public Role CreatedByRole { get; set; }
        public string CriticalSystemDefeated { get; set; }
        public override EdmontonFormType FormType
        {
            get { return getEdmontonFormType(FormTypeId); } 
        }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public static UserGridLayoutIdentifier getUserGridLayoutIdentifier(long formTypeID)
        {
            UserGridLayoutIdentifier formType = null;
            switch (formTypeID)
            {
                case 1001:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_OdourNoiseComplaint;
                    break;
                case 1002:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_Deviation;
                    break;
                case 1003:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_RoadClosure;
                    break;
                case 1004:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_GN11GroundDisturbance;
                    break;
                case 1005:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_GN27FreezePlug;
                    break;
                case 1006:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_HazardAssessment;
                    break;
                //RITM0341710 mangesh
                case 1007:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_OilSample;
                    break;
                case 1008:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_DailyInspection;
                    break;
                //TASK0593631 - mangesh
                case 1009:
                    formType = UserGridLayoutIdentifier.FormGenericTemplate_NonEmergencyWaterSystemApproval;
                    break;
            }
            return formType;
        }

        public static EdmontonFormType getEdmontonFormType(long formTypeID)
        {
            EdmontonFormType formType = null;
            switch (formTypeID)
            {
                case 1001:
                    formType = EdmontonFormType.OdourNoiseComplaint;
                    break;
                case 1002:
                    formType = EdmontonFormType.Deviation;
                    break;
                case 1003:
                    formType = EdmontonFormType.RoadClosure;
                    break;
                case 1004:
                    formType = EdmontonFormType.GN11GroundDisturbance;
                    break;
                case 1005:
                    formType = EdmontonFormType.GN27FreezePlug;
                    break;
                case 1006:
                    formType = EdmontonFormType.HazardAssessment;
                    break;
                //RITM0341710 - mangesh
                case 1007:
                    formType = EdmontonFormType.FortHillOilSample;
                    break;
                case 1008:
                    formType = EdmontonFormType.FortHillDailyInspection;
                    break;
                //TASK0593631 - mangesh
                case 1009:
                    formType = EdmontonFormType.NonEmergencyWaterSystemApproval;
                    break;
            }
            return formType;
        }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new FormGenericTemplateDTO(IdValue,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                CriticalSystemDefeated,
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
                FormTypeId,
                PlantId);
        }

        public bool IsActiveAndRequiresApproval(DateTime now)
        {
            return FromDateTime < now && ToDateTime > now && (FormStatus == FormStatus.Draft || FormStatus == FormStatus.WaitingForApproval);   //ayman waiting for approval
        }

        public FormGenericTemplateHistory TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var approvals = GetApprovalsSnapshot();
            return new FormGenericTemplateHistory(IdValue,
                FormStatus,
                flocListString,
                PlainTextContent,
                FromDateTime,
                ToDateTime,
                approvals,
                LastModifiedBy,
                LastModifiedDateTime,
                ApprovedDateTime,
                ClosedDateTime,
                Department,
                IsTheCSDForAPressureSafetyValve,
                CriticalSystemDefeated,
                DocumentLinks.AsString(link => link.TitleWithUrl));
        }

        public bool WillNeedReapproval(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs,
            User user,
            FormOP14Department originalDepartment,
            bool originalCsdAnswer,
            string originalCriticalSystemDefeated)
        {
            var thereAreCurrentlyApprovalsByOtherPeople = ThereAreCurrentlyApprovalsByOtherPeople(user);
            if (!thereAreCurrentlyApprovalsByOtherPeople)
            {
                return false;
            }

            return SomethingRequiringReapprovalHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFlocs,
                user,
                originalDepartment,
                originalCsdAnswer,
                originalCriticalSystemDefeated);
        }

        public bool SomethingRequiringReapprovalHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs,
            User user,
            FormOP14Department originalDepartment,
            bool originalCsdAnswer,
            string originalCriticalSystemDefeated)
        {
            var aMainValueHasChanged = AMainValueHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFlocs);
            
            //INC0280983 mangesh
            //below values/controls are never used on Forms: may be in future it will add, so assigning default as flase value.
            var pressureSafetyValveAnswerChanged = false; //originalCsdAnswer != IsTheCSDForAPressureSafetyValve;
            var departmentChanged = false; //originalDepartment.Id != Department.Id;
            var criticalSystemDefeatedChanged = false; //originalCriticalSystemDefeated != CriticalSystemDefeated;

            return aMainValueHasChanged || pressureSafetyValveAnswerChanged || departmentChanged ||
                   criticalSystemDefeatedChanged;
        }

        private bool AMainValueHasChanged(string originalPlainTextContent,
            DateTime originalValidFromDateTime,
            DateTime originalValidToDateTime,
            List<FunctionalLocation> originalFlocs)
        {
            var contentChanged = originalPlainTextContent != PlainTextContent;
            var validFromChanged = originalValidFromDateTime != FromDateTime;
            var validToChanged = originalValidToDateTime != ToDateTime;
            var flocsChanged = !originalFlocs.AreSameById(FunctionalLocations);

            return (contentChanged || validFromChanged || validToChanged || flocsChanged);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, FunctionalLocations);
        }
    }
}