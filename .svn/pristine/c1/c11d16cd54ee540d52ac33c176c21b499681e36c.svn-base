using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO.PriorityPage
{
    [Serializable]
    public class LogPriorityPageDTO : DomainObject
    {
        public LogPriorityPageDTO(LogDTO dto, bool isReadByCurrentUser)
        {
            Id = dto.Id;
            CreatedByUserId = dto.CreatedByUserId;
            CreatedByFullName = dto.CreatedByFullName;
            LogDateTime = dto.LogDateTime;
            Comments = dto.Comments;
            IsReadByCurrentUser = isReadByCurrentUser;
        }

        public long CreatedByUserId { get; set; }
        public string CreatedByFullName { get; private set; }
        public DateTime LogDateTime { get; private set; }
        public string Comments { get; private set; }
        public bool IsReadByCurrentUser { get; private set; }
    }
}