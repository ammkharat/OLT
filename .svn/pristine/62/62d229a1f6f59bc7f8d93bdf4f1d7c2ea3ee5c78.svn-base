using System;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetDefinitionState : DomainObject
    {
        public TargetDefinitionState(long? id, bool isExceedingBoundary, DateTime? lastSuccessfulTagAccess)
        {
            this.id = id;
            IsExceedingBoundary = isExceedingBoundary;
            LastSuccessfulTagAccess = lastSuccessfulTagAccess;
        }

        public DateTime? LastSuccessfulTagAccess { get; set; }
        public bool IsExceedingBoundary { get; set; }

        public void Update(TagChangedState changedState)
        {
            if (changedState.TagHasChanged)
            {
                IsExceedingBoundary = false;
            }

            if (changedState.HasChanged)
            {
                LastSuccessfulTagAccess = null;
            }
        }
    }
}