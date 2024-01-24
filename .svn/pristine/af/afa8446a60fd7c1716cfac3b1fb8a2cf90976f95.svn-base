using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    /// <summary>
    ///     Represents the users' answers to a set of questions
    /// </summary>
    [Serializable]
    public class ShiftHandoverQuestionnaire : DomainObject, IHistoricalDomainObject, IReadable,
        IFunctionalLocationRelevant, IVisibilityGroupRelevant
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ShiftHandoverQuestionnaire>();

        public ShiftHandoverQuestionnaire(
            long? id,
            string shiftHandoverConfigurationName,
            ShiftPattern shift,
            WorkAssignment assignment,
            User createUser,
            DateTime createDateTime,
            IEnumerable<FunctionalLocation> functionalLocations,
            IEnumerable<ShiftHandoverAnswer> answers,
            List<long> relevantCokerCardConfigurations,
            DateTime flexiShiftStartDate,
            DateTime flexiShiftEndDate,
            bool isFlexible
            )
        {
            Answers = new List<ShiftHandoverAnswer>();
            FunctionalLocations = new List<FunctionalLocation>();
            RelevantCokerCardConfigurations = new List<long>();
            this.id = id;
            ShiftHandoverConfigurationName = shiftHandoverConfigurationName;
            Shift = shift;
            Assignment = assignment;
            CreateUser = createUser;
            CreateDateTime = createDateTime;

            LastModifiedDate = createDateTime;

            FunctionalLocations.Clear();
            if (functionalLocations != null)
            {
                FunctionalLocations.AddRange(functionalLocations);
            }

            Answers.Clear();
            if (answers != null)
            {
                Answers.AddRange(answers);
            }

            RelevantCokerCardConfigurations.Clear();
            if (relevantCokerCardConfigurations != null)
            {
                RelevantCokerCardConfigurations.AddRange(relevantCokerCardConfigurations);
            }
            IsFlexible = isFlexible;
            FlexiShiftStartDate = flexiShiftStartDate;
            FlexiShiftEndDate = flexiShiftEndDate;
        }

        public User CreateUser { get; private set; }

        public DateTime CreateDateTime { get; private set; }

        public List<FunctionalLocation> FunctionalLocations { get; private set; }

        public string FunctionalLocationsAsCommaSeparatedFullHierarchyList
        {
            get { return FunctionalLocations.FullHierarchyListToString(true, false); }
        }

        public List<ShiftHandoverAnswer> Answers { get; private set; }

        public List<ShiftHandoverAnswer> SortedAnswers
        {
            get
            {
                Answers.Sort(a => a.QuestionDisplayOrder);
                return Answers;
            }
        }

        public bool HasYesAnswer
        { 
            get
            {
//Added By Vibhor - RITM0553278 : Shift Handover enhancement

                return Answers.Exists(answer => answer.CommentsAdded);
                //return Answers.Exists(answer => answer.Answer);
            }
        }

        public string ShiftHandoverConfigurationName { get; set; }

        public ShiftPattern Shift { get; private set; }

        [CachedRelationship]
        public WorkAssignment Assignment { get; private set; }

        public List<WorkAssignmentVisibilityGroup> WritableWorkAssignmentVisibilityGroups
        {
            get
            {
                return Assignment == null
                    ? new List<WorkAssignmentVisibilityGroup>()
                    : new List<WorkAssignmentVisibilityGroup>(Assignment.WriteWorkAssignmentVisibilityGroups);
            }
        }

        public DateTime LastModifiedDate { get; set; }

        /**/

        public bool IsFlexible { get;  set; }
        public DateTime FlexiShiftStartDate { get; set; }
        public DateTime FlexiShiftEndDate { get; set; }

        /**/

        public Date CreatedShiftStartDate
        {
            get { return new UserShift(Shift, LastModifiedDate).StartDate; }
        }

        public Date CreatedShiftEndDate
        {
            get { return new UserShift(Shift, LastModifiedDate).EndDate; }
        }
       
        public DateTime CreatedShiftStartDateWithPadding
        {
            get { return new UserShift(Shift, LastModifiedDate).StartDateTimeWithPadding; }
        }

        public DateTime CreatedShiftEndDateWithPadding
        {
            get { return new UserShift(Shift, LastModifiedDate).EndDateTimeWithPadding; }
        }

        public string ShiftDisplayName
        {
            get
            {
                try
                {
                    var userShift = new UserShift(Shift, CreateDateTime);
                    if (IsFlexible)
                    {
                        return String.Format("{0}-{1}-F", FlexiShiftStartDate.ToString("dd/MM/yy"), FlexiShiftEndDate.ToString("dd/MM/yy"));
                    }
                   
                        return String.Format("{0} - {1}", userShift.StartDate, Shift.Name);  
                    
                }
                catch (Exception e)
                {
                    // This is to capture the unlikely scenario that the create date of the shift handover
                    // is outside the shift boundaries.
                    logger.Error("Error creating shift display name.", e);
                }

                return StringResources.Unavailable;
            }
        }

        public List<long> RelevantCokerCardConfigurations { get; private set; }

        public long? LogId { get; set; }
        public long? SummaryLogId { get; set; }

        public bool HasAssociatedLogOrSummaryLog
        {
            get { return LogId != null || SummaryLogId != null; }
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
        {
            foreach (var floc in FunctionalLocations)
            {
                var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkUpRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
                if (isRelevant)
                    return true;
            }
            return false;
        }

        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            return new StandardVisibilityGroupRelevance(Assignment).IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        public ShiftHandoverQuestionnaireHistory TakeSnapshot()
        {
            return new ShiftHandoverQuestionnaireHistory(
                IdValue,
                FunctionalLocationsAsCommaSeparatedFullHierarchyList,
                Answers.ConvertAll(answer => answer.TakeSnapshot()),
                CreateUser,
                LastModifiedDate);
        }

        public bool IsAPriority(User user, WorkAssignment workAssignment, UserShift userShift, DateTime now)
        {
            var threeDaysAgo = now.SubtractDays(3);
            var createdWithinPastThreeDays = (CreateDateTime > threeDaysAgo);

            var createdInShift = new UserShift(Shift, CreateDateTime);
            var weAreInCreatedInShiftRightNow = userShift.ShiftPattern.Equals(Shift) &&
                                                createdInShift.DateTimeRangeWithPadding.ContainsInclusive(now);

            var assignmentsAreEqual = (Assignment == null && workAssignment == null) ||
                                      (Assignment != null && Assignment.Equals(workAssignment)) ||
                                      (workAssignment != null && workAssignment.Equals(Assignment));

            if (!CreateUser.Equals(user) &&
                assignmentsAreEqual &&
                createdWithinPastThreeDays &&
                !weAreInCreatedInShiftRightNow)
            {
                return true;
            }
            return false;
        }

        public bool MatchesLogByUserAssignmentAndShift(
            User logCreateUser,
            WorkAssignment logWorkAssignment,
            DateTime logCreateDateTime,
            ShiftPattern logShift)
        {
            var logUserShift = new UserShift(logShift, logCreateDateTime);
            var isOnSameShift = logShift.Id == Shift.Id && logUserShift.StartDate == CreatedShiftStartDate;

            var isSameCreateUserAndNullAssignment = logWorkAssignment == null && Assignment == null &&
                                                    logCreateUser != null && CreateUser != null &&
                                                    logCreateUser.Id == CreateUser.Id;
            var isSameWorkAssignment = logWorkAssignment != null && Assignment != null &&
                                       logWorkAssignment.Id == Assignment.Id;

            return isOnSameShift && (isSameCreateUserAndNullAssignment || isSameWorkAssignment);
        }

        public static int CompareByShiftThenWorkAssignmentThenCreateUser(ShiftHandoverQuestionnaire x,
            ShiftHandoverQuestionnaire y)
        {
            {
                var xUserShift = new UserShift(x.Shift, x.CreateDateTime);
                var yUserShift = new UserShift(y.Shift, y.CreateDateTime);
                var compareResult = xUserShift.StartDateTime.CompareTo(yUserShift.StartDateTime);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = 0;
                if (x.Assignment == null && y.Assignment == null)
                {
                    compareResult = 0;
                }
                else if (x.Assignment == null && y.Assignment != null)
                {
                    compareResult = -1;
                }
                else if (x.Assignment != null && y.Assignment == null)
                {
                    compareResult = 1;
                }
                else
                {
                    compareResult = string.Compare(x.Assignment.Name, y.Assignment.Name, StringComparison.CurrentCulture);
                }
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = string.Compare(x.CreateUser.LastName, y.CreateUser.LastName,
                    StringComparison.CurrentCulture);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return x.CreateDateTime.CompareTo(y.CreateDateTime);
        }

        public static bool AreDifferentBasedOnIdOrAnswers(ShiftHandoverQuestionnaire x, ShiftHandoverQuestionnaire y)
        {
            if (AreDifferentBasedOnId(x, y))
            {
                return true;
            }

            return AreDifferent(x.Answers, y.Answers);
        }

        private static bool AreDifferent(List<ShiftHandoverAnswer> xAnswers, List<ShiftHandoverAnswer> yAnswers)
        {
            if (xAnswers.Count != yAnswers.Count)
            {
                return true;
            }

            var xSorted = new List<ShiftHandoverAnswer>(xAnswers);
            xSorted.Sort();

            var ySorted = new List<ShiftHandoverAnswer>(yAnswers);
            ySorted.Sort();

            for (var i = 0; i < xSorted.Count; i++)
            {
                var x = xSorted[i];
                var y = ySorted[i];

                if (x.ShiftHandoverQuestionId != y.ShiftHandoverQuestionId)
                {
                    return true;
                }
                if (x.Answer != y.Answer)
                {
                    return true;
                }
                if (x.Comments != y.Comments)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsSameUser(List<HasCommentsDTO> hasCommentsList)
        {
            return hasCommentsList.TrueForAll(l => l.CreationUserId == CreateUser.Id);
        }


    }
}