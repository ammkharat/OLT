using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class RestrictionDefinitionDTO : DomainObject, IIsActive, IHasStatus<RestrictionDefinitionStatus>, IIsVisible
    {
        private readonly string productionTargetTagName;
        private readonly int? productionTargetValue;

        public RestrictionDefinitionDTO(RestrictionDefinition domainObject) : this(
            domainObject.Id,
            domainObject.Status.IdValue,
            domainObject.Status.Name,
            domainObject.IsActive,
            domainObject.IsOnlyVisibleOnReports,
            domainObject.FunctionalLocation.FullHierarchy,
            domainObject.Name,
            domainObject.MeasurementTagInfo.Name,
            domainObject.ProductionTargetValue,
            domainObject.ProductionTargetTagInfo != null ? domainObject.ProductionTargetTagInfo.Name : null,
            domainObject.Description,
            domainObject.LastModifiedBy.IdValue,
            domainObject.LastModifiedBy.FullNameWithUserName)
        {
        }

        public RestrictionDefinitionDTO(
            long? id,
            long statusId,
            string statusName,
            bool isActive,
            bool isOnlyVisibleOnReports,
            string functionalLocationName,
            string name,
            string measurementTagName,
            int? productionTargetValue,
            string productionTargetTagName,
            string description,
            long lastModifiedUserId,
            string lastModifiedFullNameWithUserName)
        {
            this.id = id;
            StatusId = statusId;
            StatusName = statusName;
            IsActive = isActive;
            IsVisible = isOnlyVisibleOnReports;
            FunctionalLocationName = functionalLocationName;
            Name = name;
            MeasurementTagName = measurementTagName;
            this.productionTargetValue = productionTargetValue;
            this.productionTargetTagName = productionTargetTagName;
            Description = description;
            LastModifiedUserId = lastModifiedUserId;
            LastModifiedFullNameWithUserName = lastModifiedFullNameWithUserName;
        }

        public long StatusId { get; private set; }

        [IncludeInSearch]
        public string StatusName { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationName { get; private set; }

        [IncludeInSearch]
        public string Name { get; private set; }

        [IncludeInSearch]
        public string MeasurementTagName { get; private set; }

        [IncludeInSearch]
        public string ProductionTarget
        {
            get { return productionTargetValue.HasValue ? productionTargetValue.Format() : productionTargetTagName; }
        }

        [IncludeInSearch]
        public string Description { get; private set; }

        public long LastModifiedUserId { get; private set; }

        [IncludeInSearch]
        public string LastModifiedFullNameWithUserName { get; private set; }

        public RestrictionDefinitionStatus Status
        {
            get { return RestrictionDefinitionStatus.Get(StatusId); }
        }

        public bool IsActive { get; private set; }

        public bool IsVisible { get; set; }
    }
}