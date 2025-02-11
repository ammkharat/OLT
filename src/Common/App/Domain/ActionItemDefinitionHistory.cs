using System;
using System.Diagnostics;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ActionItemDefinitionHistory : DomainObjectHistorySnapshot
    {
        public ActionItemDefinitionHistory(
            long id,
            string name,
            BusinessCategory actionItemCategory,
            ActionItemDefinitionStatus actionItemDefinitionStatus,
            string schedule,
            string description,
            bool copyResponseToLog,  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            DataSource source,
            bool requiresApproval,
            bool active,
            bool responseRequired,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            string functionalLocations,
            string targetDefinitionDTOs,
            string documentLinks,
            OperationalMode operationalMode,
            Priority priority,
            string workAssignmentName,
            bool createAnActionItemForEachFunctionalLocation,
            long? associatedFormGn75B)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            Name = name;
            Category = actionItemCategory;
            Description = description;
            CopyResponseToLog = copyResponseToLog;  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            Status = actionItemDefinitionStatus;
            Schedule = schedule;
            Source = source;
            Active = active;
            ResponseRequired = responseRequired;
            RequiresApproval = requiresApproval;
            FunctionalLocations = functionalLocations;
            TargetDefinitions = targetDefinitionDTOs;
            DocumentLinks = documentLinks;
            OperationalMode = operationalMode;
            Priority = priority;
            WorkAssignment = workAssignmentName;
            CreateAnActionItemForEachFunctionalLocation = createAnActionItemForEachFunctionalLocation;
            AssociatedFormGn75B = associatedFormGn75B;

            Debug.Assert
                (
                    (
                        requiresApproval &&
                        false == active &&
                        ActionItemDefinitionStatus.Approved != actionItemDefinitionStatus
                        ) ||
                    (
                        false == requiresApproval &&
                        ActionItemDefinitionStatus.Approved == actionItemDefinitionStatus
                        )
                );
        }

        //mangesh- DMND0005327 Request 15
        public ActionItemDefinitionHistory(
            long id,
            string name,
            BusinessCategory actionItemCategory,
            ActionItemDefinitionStatus actionItemDefinitionStatus,
            string schedule,
            string description,
            bool copyResponseToLog,  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            DataSource source,
            bool requiresApproval,
            bool active,
            bool responseRequired,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            string functionalLocations,
            string targetDefinitionDTOs,
            string documentLinks,
            OperationalMode operationalMode,
            Priority priority,
            string workAssignmentName,
            bool createAnActionItemForEachFunctionalLocation,
            long? associatedFormGn75B,
            long? associatedFormGn75B1,
            long? associatedFormGn75B2)
            : base(id, lastModifiedBy, lastModifiedDate)
        {
            Name = name;
            Category = actionItemCategory;
            Description = description;
            CopyResponseToLog = copyResponseToLog;  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            Status = actionItemDefinitionStatus;
            Schedule = schedule;
            Source = source;
            Active = active;
            ResponseRequired = responseRequired;
            RequiresApproval = requiresApproval;
            FunctionalLocations = functionalLocations;
            TargetDefinitions = targetDefinitionDTOs;
            DocumentLinks = documentLinks;
            OperationalMode = operationalMode;
            Priority = priority;
            WorkAssignment = workAssignmentName;
            CreateAnActionItemForEachFunctionalLocation = createAnActionItemForEachFunctionalLocation;
            AssociatedFormGn75B = associatedFormGn75B;
            AssociatedFormGn75B1 = associatedFormGn75B1;
            AssociatedFormGn75B2 = associatedFormGn75B2;

            Debug.Assert
                (
                    (
                        requiresApproval &&
                        false == active &&
                        ActionItemDefinitionStatus.Approved != actionItemDefinitionStatus
                        ) ||
                    (
                        false == requiresApproval &&
                        ActionItemDefinitionStatus.Approved == actionItemDefinitionStatus
                        )
                );
        }

        public long? AssociatedFormGn75B { get; private set; }

        //mangesh - DMND0005327 - Request 15
        public long? AssociatedFormGn75B1 { get; private set; }
        public long? AssociatedFormGn75B2 { get; private set; }

        public OperationalMode OperationalMode { get; private set; }

        public string Name { get; private set; }

        public DataSource Source { get; private set; }

        [IgnoreDifference]
        public long? SapOperationId { get; set; }

        public bool RequiresApproval { get; private set; }

        public bool Active { get; private set; }

        public bool ResponseRequired { get; private set; }

        public string DocumentLinks { get; private set; }

        public string Schedule { get; private set; }

        public ActionItemDefinitionStatus Status { get; set; }

        public string Description { get; set; }

        public bool CopyResponseToLog { get; set; }  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades

        public string FunctionalLocations { get; private set; }

        public BusinessCategory Category { get; set; }

        public bool Deleted { get; set; }

        public string TargetDefinitions { get; private set; }

        public Priority Priority { get; private set; }

        public string WorkAssignment { get; private set; }

        public bool CreateAnActionItemForEachFunctionalLocation { get; private set; }
    }
}