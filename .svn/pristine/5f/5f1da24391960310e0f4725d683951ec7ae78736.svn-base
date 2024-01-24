using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormGenericTemplateDTO : FormEdmontonDTO, ICreatedByARole //FormGenericTemplateBaseDTO
    {
        public FormGenericTemplateDTO(long id, List<string> functionalLocations, string criticalSystemDefeated,
            long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime validFrom, DateTime validTo,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals, long formtypeid, long plantid)
            : base(
                id, functionalLocations, FormGenericTemplate.getEdmontonFormType(formtypeid), createdByUserId, createdByFullNameWithUserName, 
                createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            CriticalSystemDefeated = criticalSystemDefeated;
            CreatedByUserId = createdByUserId;
        }


        public FormGenericTemplateDTO(FormGenericTemplate form)
            : this(
                form.IdValue, form.FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),null,
                form.CreatedBy.IdValue, form.CreatedBy.FullNameWithUserName, form.CreatedDateTime, form.LastModifiedBy.IdValue
                ,Convert.ToDateTime(form.ApprovedDateTime), Convert.ToDateTime(form.CreatedDateTime),
                form.FormStatus,form.ApprovedDateTime,form.ClosedDateTime,null,form.FormTypeId,form.PlantId
                
                )
        {
        }

        public long CreatedByRoleId { get; private set; }

        public long CreatedByUserId { get; set; }


        public override FormStatus Status
        {
            get
            {
                if ((base.Status == FormStatus.Approved || base.Status == FormStatus.Draft || base.Status == FormStatus.WaitingForApproval) &&                //ayman waiting for approval fix
                    (Clock.Now > base.ValidTo))
                    return FormStatus.Expired;
                return base.Status;
            }
        }

        public string CriticalSystemDefeated { get; private set; }


        private static List<string> GetApprovers(FormGenericTemplate formOp14)
        {
            return formOp14.IsApproved()
                ? new List<string>()
                : new List<string>
                {
                    formOp14.AllApprovals.ConvertAll(input => input.Approver).First()
                };
        }
    }
}