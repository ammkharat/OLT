using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ActionItemDTO : DomainObject, IHasSchedule, IHasPriority, IHasDataSource, IHasStatus<ActionItemStatus>,
        IHasWorkAssignment
    {
        private readonly List<string> functionalLocations = new List<string>();
        private readonly List<string> functionalLocationsWithDescriptions = new List<string>();
        private readonly bool responseRequired;
        private readonly List<string> visibilityGroupNames = new List<string>();
        private string visGroupsStartingWith = String.Empty;   //ayman visibility group
        private long definitionid = 0;              //ayman action item definition
        private bool reading = false;
        private long customfieldentryid = 0;          //ayman action item reading
        public ActionItemDTO(ActionItem actionItem)
            :
                this
                (
                actionItem.Id.GetValueOrDefault(),
                actionItem.StartDateTime,
                actionItem.StartDateTime,
                actionItem.EndDateTime.GetValueOrDefault(),
                actionItem.EndDateTime.GetValueOrDefault(),
                actionItem.Status.IdValue,
                actionItem.Priority,
                actionItem.CategoryName,
                actionItem.Source.IdValue,
                actionItem.Description,
                actionItem.CreatedByScheduleType.Name,
                actionItem.FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                actionItem.FunctionalLocations.ConvertAll(floc => floc.FullHierarchyWithDescription),
                actionItem.ResponseRequired,
                actionItem.LastModifiedBy.Id,
                actionItem.Name,
                actionItem.Assignment != null ? actionItem.Assignment.Name : null,
                actionItem.Assignment != null ? actionItem.Assignment.Id : null,
                actionItem.WritableWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupName),
                actionItem.VisGroupsStartingWith,                        //ayman visibility group
                actionItem.DefinitionId,                          //ayman action item defintion
                actionItem.Reading     //ayman action item reading
                            )
            
        {
        }

        public ActionItemDTO(long id, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime,
            long statusId, Priority priority, string categoryName, long sourceId,
            string description, string scheduleTypeName, List<string> functionalLocationNames,
            List<string> functionalLocationNamesWithDescription,
            bool responseRequired, long? lastModifiedUserId, string name, string workAssignmentName,
            long? workAssignmentId, List<string> visibilityGroupNames,string visGroupsStartingWith,long definitionid,bool reading )                 //ayman visibility group
        {
            this.id = id;

            //Added new varible as a column name in ActionItemGridRender : Mingle story : 3399
            //_StartDate = DateTimeExtensions.ToDateString(startTime);
            _StartDate = startDate.ToString("D");
            _StartTime = DateTimeExtensions.ToTimeString(startTime);
            _EndTime = DateTimeExtensions.ToTimeString(endTime);
            
            StartDate = startDate;
            StartTime = startTime;
            EndDate = endDate;
            EndTime = endTime;
            StatusId = statusId;
            Priority = priority;
            CategoryName = categoryName;
            SourceId = sourceId;
            Description = description;
            ScheduleTypeName = scheduleTypeName;

            foreach (var functionalLocationName in functionalLocationNames)
            {
                AddFunctionalLocation(functionalLocationName);
            }

            foreach (var functionalLocationNameWithDescription in functionalLocationNamesWithDescription)
            {
                AddFunctionalLocationWithDescription(functionalLocationNameWithDescription);
            }

            this.responseRequired = responseRequired;
            LastModifiedUserId = lastModifiedUserId;
            Name = name;
            WorkAssignmentName = workAssignmentName;
            WorkAssignmentId = workAssignmentId;

            this.visibilityGroupNames = visibilityGroupNames ?? new List<string>();

            //ayman visibility group
            this.visGroupsStartingWith = visGroupsStartingWith;
            this.definitionid = definitionid;           //ayman action item definition
            this.reading = reading;                     //ayman action item reading
            
            this.visibilityGroupNames.Sort();
            
        }

        [IncludeInSearch]
        public string Name { get; set; }

        public string ResponseRequired
        {
            get
            {
                var result = string.Empty;
                if (responseRequired)
                {
                    return StringResources.Yes;
                }
                return result;
            }
        }

        [IncludeInSearch]
        public string _StartDate { get; private set; }

        [IncludeInSearch]
        public string _StartTime { get; private set; }

        [IncludeInSearch]
        public string _EndTime { get; private set; }

        [IncludeInSearch]
        public DateTime StartDate { get; private set; }

        [IncludeInSearch]
        public DateTime StartTime { get; private set; }

        public DateTime StartDateTime
        {
            get
            {
                return
                    new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute,
                        StartTime.Second);
            }
        }

        public DateTime EndDate { get; private set; }

        [IncludeInSearch]
        public DateTime EndTime { get; private set; }

        public DateTime EndDateTime
        {
            get
            {
                return
                    new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndTime.Hour, EndTime.Minute, EndTime.Second);
            }
        }

        public long StatusId { get; private set; }

        [IncludeInSearch]
        public string StatusName
        {
            get { return ActionItemStatus.Get(StatusId).Name; }
        }

        [IncludeInSearch]
        public string SourceName
        {
            get { return DataSource.GetById(SourceId).Name; }
        }

        public long SourceId { get; private set; }

        [IncludeInSearch]
        public string CategoryName { get; private set; }

        [IncludeInSearch]
        public string Description { get; private set; }

        public string ScheduleTypeName { get; private set; }

        [IncludeInSearch]
        public string WorkAssignmentName { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationNames
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        public string FunctionalLocationNamesWithDescription
        {
            get { return functionalLocationsWithDescriptions.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public string VisibilityGroupNames
        {
            get { return visibilityGroupNames.BuildCommaSeparatedList(); }
        }

        //ayman visibility group
        [IncludeInSearch]
        public string VisGroupStartingWith
        {
            get { return visGroupsStartingWith; }
        }



        public long? LastModifiedUserId { get; private set; }

        public DataSource DataSource
        {
            get { return DataSource.GetById(SourceId); }
        }

        [IncludeInSearch]
        public Priority Priority { get; private set; }

        public bool IsRecurring
        {
            get { return ScheduleTypeName != ScheduleType.Single.Name; }
        }

        public ActionItemStatus Status
        {
            get { return ActionItemStatus.Get(StatusId); }
        }

        public long? WorkAssignmentId { get; private set; }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocations.AddAndSort(functionalLocationName);
        }

        public void AddFunctionalLocationWithDescription(string functionalLocationNameWithDescription)
        {
            functionalLocationsWithDescriptions.AddAndSort(functionalLocationNameWithDescription);
        }

        /// <summary>
        ///     Returns true if the current time is after the actionitem end
        /// </summary>
        public bool IsLate(DateTime currentTimeAtSite)
        {
            return (EndTime != DateTime.MaxValue) && (currentTimeAtSite > EndDateTime);
        }

        //ayman action item definition
        public long DefinitionId()
        {
            return definitionid;
        }

        //ayman action item reading
        public bool Reading()
        {
            return reading;
        }

        public long CustomFieldentryID()
        {
            return customfieldentryid;
        }

        public bool HasEndDate()
        {
            return (EndTime != DateTime.MaxValue);
        }

        /// <summary>
        ///     returns true if the current time is before the actionitem start
        /// </summary>
        /// <returns></returns>
        public bool IsEarly(DateTime currentTimeAtSite)
        {
            return (currentTimeAtSite < StartDateTime);
        }

        public bool IsCurrent(DateTime currentTimeAtSite)
        {
            return !IsEarly(currentTimeAtSite) && !IsLate(currentTimeAtSite);
        }

        public void AddVisibilityGroupName(string visibilityGroupName)
        {
            visibilityGroupNames.AddAndSort(visibilityGroupName);
        }

        //ayman visibility group
        public void AddVisibilityGroupStartingWith(string visibilityGroupStartingWith)
        {
            visGroupsStartingWith = visibilityGroupStartingWith;
        }
    }
}