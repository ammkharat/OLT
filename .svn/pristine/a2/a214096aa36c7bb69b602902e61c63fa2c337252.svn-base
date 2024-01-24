using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class WorkPermitEdmontonHazardDTO : DomainObject, IHasStatus<PermitRequestBasedWorkPermitStatus>,
        IHasDataSource
    {
        private readonly long dataSourceId;
        private readonly long workPermitStatusId;

        public WorkPermitEdmontonHazardDTO(long id, long dataSourceId, long workPermitStatusId,
            DateTime? issuedDateTime, string trade, string description, string hazards,
            string createdByFullNameWithUserName)
        {
            Id = id;
            this.dataSourceId = dataSourceId;
            this.workPermitStatusId = workPermitStatusId;
            IssuedDateTime = issuedDateTime;
            Occupation = trade;
            Description = description;
            Hazards = hazards;
            CreatedByFullnameWithUserName = createdByFullNameWithUserName;
        }

        public DateTime? IssuedDateTime { get; private set; }

        public string Occupation { get; private set; }

        public string Description { get; private set; }

        public string Hazards { get; private set; }

        public string CreatedByFullnameWithUserName { get; private set; }

        public DataSource DataSource
        {
            get { return DataSource.GetById(dataSourceId); }
        }

        public PermitRequestBasedWorkPermitStatus Status
        {
            get { return PermitRequestBasedWorkPermitStatus.Get(workPermitStatusId); }
        }
    }
}