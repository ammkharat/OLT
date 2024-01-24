using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ITargetDefinitionService
    {
        /// <summary>
        ///     Counts TargetDefinitions with the same name for a given site.
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="siteId"></param>
        /// <returns>a count of Target Definitions with the same name</returns>
        [OperationContract]
        int GetCount(string name, long siteId);

        /// <summary>
        ///     Get Target by Target Id
        /// </summary>
        /// <param name="targetId">Target ID</param>
        /// <returns></returns>
        [OperationContract]
        TargetDefinition QueryById(long targetId);

        /// <summary>
        ///     Gets IsActive Targets.
        /// </summary>
        /// <param name="siteId">Limit the search to this particular site.</param>
        /// <param name="name">Search string for use in finding Targets that match the name</param>
        /// <returns>List of TargetDefinitions with a name that matches the substring 'name'</returns>
        [OperationContract]
        List<TargetDefinition> QueryActiveByName(long siteId, string name);

        [OperationContract]
        List<NotifiedEvent> Remove(TargetDefinition target);

        [OperationContract]
        List<NotifiedEvent> Update(TargetDefinition target, TagChangedState changedState);

        [OperationContract]
        List<NotifiedEvent> Insert(TargetDefinition target);

        /// <summary>
        ///     Gets All Targets related to the following functional locations, but returns DTOs rather than domain objects
        /// </summary>
        /// <param name="functionalLocations">List of functional locations that you want to limit Targets by</param>
        /// <param name="dateRange">The date range</param>
        /// <returns></returns>
        [OperationContract]
        List<TargetDefinitionDTO> QueryDTOByFunctionalLocations(IFlocSet flocSet, Range<Date> dateRange);

        /// <summary>
        ///     Checks Target definition for Circular Dependencies.
        /// </summary>
        /// <param name="targetDefinition">Target Definition to check</param>
        [OperationContract]
        void CheckCircularDependencyCreated(TargetDefinition targetDefinition);

        /// <summary>
        ///     Return True if a target definition of the given id has at least one action item definition
        /// </summary>
        /// <param name="id">Target Definition Id</param>
        /// <returns></returns>
        [OperationContract]
        bool HasLinkedActionItemDefinition(long? id);

        [OperationContract]
        SchedulingList<TargetDefinition, OLTException> QueryAllAvailableForScheduling(List<long> siteIds);

        /// <summary>
        ///     Finds the schedule associated with the given schedule id
        /// </summary>
        /// <param name="scheduleId">Schedule id to query</param>
        /// <returns>Target definition associated to the schedule id</returns>
        [OperationContract]
        TargetDefinition QueryByScheduleId(long? scheduleId);

        [OperationContract]
        void UpdateBoundaryExceededByUnitId(List<FunctionalLocation> unitFunctionalLocations, bool isExceedingBoundry);

        [OperationContract]
        List<NotifiedEvent> Reject(TargetDefinition target, User rejector, DateTime rejectedDateTime);

        [OperationContract]
        List<NotifiedEvent> Approve(TargetDefinition targetDefinition, User approver, DateTime approvedDateTime);

        [OperationContract]
        Error IsValidName(string name, Site site, ISchedule schedule, TargetDefinition editObject);

        [OperationContract]
        Error IsValidWriteTag(long? targetDefinitionId, ISchedule schedule, TagInfo tagInfo);

        [OperationContract]
        List<TargetDefinitionHistory> GetHistory(long id);

        [OperationContract]
        void UpdateStatusForValidTag(TagInfo tag, Site site);

        [OperationContract]
        void UpdateStatusForInvalidTag(TagInfo tag, Site site);

        [OperationContract]
        TargetDefinitionState QueryState(long id);

        [OperationContract]
        List<TargetDefinition> QueryByScheduleIds(IList<long> schedules);
    }
}