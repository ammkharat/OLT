﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormOP14 : BaseEdmontonForm, IDocumentLinksObject
    {
        private bool isMailSent;//Added by ppanigrahi
        public FormOP14(long? id,
            FormStatus formStatus,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            User createdBy,
            DateTime createdDateTime, long SiteId)    //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();

            IsTheCSDForAPressureSafetyValve = false;
            Department = FormOP14Department.Operations;
            IsSCADASupport = false;
            FunctionalLocations = new List<FunctionalLocation>();


            if (SiteId == Site.EDMONTON_ID)   //ayman generic forms
            {

                Approvals = new List<FormApproval>
                {
                    new FormApproval(null, id, "STL or Lead Pumpman", null, null, null, 1),
                    new FormApproval(null, id, "Manager Area Operations", null, null, null, 2),
                    new FormApproval(null,
                        id,
                        "Area Inspector (for all PSVs)",
                        null,
                        null,
                        null,
                        3,
                        ApprovalShouldBeEnabledBehaviour.OP14PressureSafetyValve,
                        false),
                    new FormApproval(null,
                        id,
                        "Manager Production Eng (for all PSVs)",
                        null,
                        null,
                        null,
                        4,
                        ApprovalShouldBeEnabledBehaviour.OP14PressureSafetyValve,
                        false),
                    new FormApproval(null,
                        id,
                        "Director Operations (> 10 Days)",
                        null,
                        null,
                        null,
                        5,
                        ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                        false),
                    new FormApproval(null,
                        id,
                        "Director Maintenance (> 10 Days)",
                        null,
                        null,
                        null,
                        6,
                        ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                        false)
                };
            }

            
if (SiteId == Site.SARNIA_ID)              
            {
                Approvals = new List<FormApproval>
                {
                    new FormApproval(null, id, "Shift Supervisor/Delegate", null, null, null, 1),
                    new FormApproval(null, id, "Operations Manager/Delegate", null, null, null, 2),
                    new FormApproval(null,
                        id,
                        "Operations Manager ( >= 10 Days)/Delegate",
                        null,
                        null,
                        null,
                        3,
                        ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                        false),
                    new FormApproval(null,
                        id,
                        "Operations Director (> 30 Days)/Delegate",
                        null,
                        null,
                        null,
                        4,
                        ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                        false),
                    new FormApproval(null,
                        id,
                        "Engineering Director (> 30 Days)/Delegate",
                        null,
                        null,
                        null,
                        5,
                        ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                        false),
                };
            }


if (SiteId == Site.SELC_ID)
{
    //DMND0010261-SELC CSD EdmontonPipeline
   
    Approvals = new List<FormApproval>
                {
                    new FormApproval(null, id, "Control Center Support Staff", null, null, null, 1),
                 //   new FormApproval(null, id, "SEUSA Asset Manager", null, null, null, 2),
                    //new FormApproval(null, id, "SELC Asset Manager", null, null, null, 3),
                  //  new FormApproval(null, id, "SCADA Support Staff", null, null, null, 4),

                     

                        new FormApproval(null,
                        id,
                         "SEUSA Asset Manager",
                        null,
                        null,
                        null,
                        2,
                      ShouldBeEnabledBehaviourSEUSA.ShouldBeEnabledBehaviourSEUSA,
                        false),

                      
                      new FormApproval(null,
                        id,
                         "SELC Asset Manager",
                        null,
                        null,
                        null,
                        3,
                      ShouldBeEnabledBehaviourSELC.ShouldBeEnabledBehaviourSELC,
                        false),


                         new FormApproval(null,
                        id,
                         "SCADA Support Staff",
                        null,
                        null,
                        null,
                        4,
                      ShouldBeEnabledBehaviourSCADA.ShouldBeEnabledBehaviourSCADA,
                        false),

                        new FormApproval(null,
                        id,
                        "Director of Operations",
                        null,
                        null,
                        null,
                        5,
                      ShouldBeEnabledBehaviour72Hours.ShouldBeEnabledBehaviour72Hours,
                        false),
                    //new FormApproval(null,
                    //    id,
                    //    "Operations Manager (10 Days)",
                    //    null,
                    //    null,
                    //    null,
                    //    3,
                    //    ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                    //    false),
                    //new FormApproval(null,
                    //    id,
                    //    "Operations Director (> 30 Days)",
                    //    null,
                    //    null,
                    //    null,
                    //    4,
                    //    ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                    //    false),
                    //new FormApproval(null,
                    //    id,
                    //    "Engineering Director (> 30 Days)",
                    //    null,
                    //    null,
                    //    null,
                    //    5,
                    //    ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                    //    false),

                    //new FormApproval(null, id, "Shift Supervisor", null, null, null, 1),
                    //new FormApproval(null, id, "Operations Manager", null, null, null, 2),
                    //new FormApproval(null,
                    //    id,
                    //    "Operations Manager (10 Days)",
                    //    null,
                    //    null,
                    //    null,
                    //    3,
                    //    ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                    //    false),
                    //new FormApproval(null,
                    //    id,
                    //    "Operations Director (> 30 Days)",
                    //    null,
                    //    null,
                    //    null,
                    //    4,
                    //    ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                    //    false),
                    //new FormApproval(null,
                    //    id,
                    //    "Engineering Director (> 30 Days)",
                    //    null,
                    //    null,
                    //    null,
                    //    5,
                    //    ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                    //    false),
                };
}


        }
        //Added by ppanigrahi
        public FormOP14(long? id,
            FormStatus formStatus,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            User createdBy,
            DateTime createdDateTime, long SiteId, bool isMailsent)    //ayman generic forms
            : base(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();

            EmailAddresses = new List<EmailAddress>();

            IsTheCSDForAPressureSafetyValve = false;
            Department = FormOP14Department.Operations;
            IsSCADASupport = false;
            FunctionalLocations = new List<FunctionalLocation>();


            isMailSent = isMailsent;

            if (SiteId == Site.SARNIA_ID)
            {
                Approvals = new List<FormApproval>
                {
                    new FormApproval(null, id, "Shift Supervisor", null, null, null, 1),
                    new FormApproval(null, id, "Operations Manager", null, null, null, 2),
                    new FormApproval(null,
                        id,
                        "Operations Manager ( >= 10 Days)",
                        null,
                        null,
                        null,
                        3,
                        ApprovalShouldBeEnabledBehaviour.TenDayValidity,
                        false),
                    new FormApproval(null,
                        id,
                        "Operations Director (> 30 Days)",
                        null,
                        null,
                        null,
                        4,
                        ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                        false),
                    new FormApproval(null,
                        id,
                        "Engineering Director (> 30 Days)",
                        null,
                        null,
                        null,
                        5,
                        ApprovalShouldBeEnabledBehaviour.ThirtyDayValidity,
                        false),
                };
            }

        }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public FormOP14Department Department { get; set; }

        public bool IsTheCSDForAPressureSafetyValve { get; set; }

        //ayman generic forms
        public long SiteId { get; set; }

        public string CriticalSystemDefeated { get; set; }
        //Added by ppanigrahi.
        public bool isMailsent
        {
            get { return isMailSent; }
            set { isMailSent = value; }
        }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.OP14; }
        }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }//Added by ppanigrahi
        
        
        public override IFormEdmontonDTO CreateDTO()
        {
            return new FormEdmontonOP14DTO(IdValue,
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
                RemainingApprovalsAsStringList(),SiteId);    //ayman sarnia 
        }

        public bool IsActiveAndRequiresApproval(DateTime now)
        {
            return FromDateTime < now && ToDateTime > now && (FormStatus == FormStatus.WaitingForApproval);   //Mukesh-:INC0250064 .
            //return FromDateTime < now && ToDateTime > now && (FormStatus == FormStatus.Draft || FormStatus == FormStatus.WaitingForApproval);   //ayman waiting for approval
        }

        public FormOP14History TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var approvals = GetApprovalsSnapshot();
            
       FormOP14History objFormOP14History=     new FormOP14History(IdValue,
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
       objFormOP14History.IsSCADASupport = IsSCADASupport;
       return objFormOP14History;
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
            var pressureSafetyValveAnswerChanged = originalCsdAnswer != IsTheCSDForAPressureSafetyValve;
            var departmentChanged = originalDepartment.Id != Department.Id;
            var criticalSystemDefeatedChanged = originalCriticalSystemDefeated != CriticalSystemDefeated;

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

        //DMND0010261-SELC CSD EdmontonPipeline
        public bool IsSCADASupport { get; set; }

    }
}