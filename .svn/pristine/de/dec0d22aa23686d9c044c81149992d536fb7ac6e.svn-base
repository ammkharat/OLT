using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO.PriorityPage
{
    [Serializable]
    public class ShiftHandoverQuestionnairePriorityPageDTO : DomainObject, IHasWorkAssignment
    {
        public ShiftHandoverQuestionnairePriorityPageDTO(ShiftHandoverQuestionnaireDTO dto, bool isReadByCurrentUser)
        {
            Id = dto.Id;
            CreateUserId = dto.CreateUserId;
            CreateUserFullName = dto.CreateUserFullName;
            WorkAssignmentId = dto.AssignmentId;
            WorkAssignmentName = dto.AssignmentName;
            ShiftId = dto.ShiftId;
            ShiftStartDate = dto.CreatedShiftStartDate;
            ShiftDisplayName = dto.ShiftDisplayName;
            HasYesAnswer = dto.HasYesAnswer;
            IsReadByCurrentUser = isReadByCurrentUser;
        }

        public long CreateUserId { get; private set; }
        public string CreateUserFullName { get; private set; }
        public string WorkAssignmentName { get; private set; }
        public long ShiftId { get; private set; }
        public Date ShiftStartDate { get; private set; }
        public string ShiftDisplayName { get; private set; }
        public bool IsReadByCurrentUser { get; private set; }
        public bool HasYesAnswer { get; private set; }
        public long? WorkAssignmentId { get; private set; }
    }
}