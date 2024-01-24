using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class UserPreferences : DomainObject
    {
        private readonly long userId;
        private long? _actionItemDefinitionLastUsedWorkAssignmentId;

        public UserPreferences(long userId) : this(null, userId, null)
        {
        }

        public UserPreferences(long? id, long userId, long? actionItemDefinitionLastUsedWorkAssignmentId)
        {
            this.id = id;
            this.userId = userId;
            ActionItemDefinitionLastUsedWorkAssignmentId = actionItemDefinitionLastUsedWorkAssignmentId;
        }

        public long? ActionItemDefinitionLastUsedWorkAssignmentId
        {
            get { return _actionItemDefinitionLastUsedWorkAssignmentId; }
            set { _actionItemDefinitionLastUsedWorkAssignmentId = value; }
        }

        public long UserId
        {
            get { return userId; }
        }
    }
}