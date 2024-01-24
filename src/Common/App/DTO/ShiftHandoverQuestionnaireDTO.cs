using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ShiftHandoverQuestionnaireDTO : DomainObject, IHasReadByCurrentUserInfo
    {
        private readonly long? assignmentId;
        private readonly string assignmentName;
        private readonly DateTime createDateTime;

        private readonly string createUserFirstName;
        private readonly long createUserId;
        private readonly string createUserLastName;
        private readonly string createUserUserName;

        private readonly Date createdShiftEndDate;
        private readonly Date createdShiftStartDate;

        private readonly string functionalLocationNames;
        private readonly bool hasYesAnswer;
        private readonly string shiftHandoverConfigurationName;

        private readonly long shiftId;
        private readonly string shiftName;

        private readonly List<string> visibilityGroupNames;
        private bool? isReadByCurrentUser;
        /**/
        private readonly bool isFlexible;
        private readonly DateTime flexiShiftStartDate;
        private readonly DateTime flexiShiftEndDate;
        /**/

        

        public ShiftHandoverQuestionnaireDTO(ShiftHandoverQuestionnaire questionnaire) : this(
            questionnaire.IdValue,
            questionnaire.ShiftHandoverConfigurationName,
            questionnaire.FunctionalLocationsAsCommaSeparatedFullHierarchyList,
            questionnaire.Shift.IdValue,
            questionnaire.Shift.Name,
            questionnaire.Assignment != null ? questionnaire.Assignment.Id : null,
            questionnaire.Assignment != null ? questionnaire.Assignment.Name : null,
            questionnaire.CreateUser.FirstName,
            questionnaire.CreateUser.LastName,
            questionnaire.CreateUser.Username,
            questionnaire.CreateDateTime,
            questionnaire.CreatedShiftStartDate,
            questionnaire.CreatedShiftEndDate,
            questionnaire.CreateUser.IdValue,
            null,
            questionnaire.HasYesAnswer,
            questionnaire.WritableWorkAssignmentVisibilityGroups.ConvertAll(wavg => wavg.VisibilityGroupName), 
            questionnaire.IsFlexible,
            questionnaire.FlexiShiftStartDate,
            questionnaire.FlexiShiftEndDate
            )
        {
        }

        public ShiftHandoverQuestionnaireDTO(long id, string shiftHandoverConfigurationName, string functionalLocations,
            long shiftId, string shiftName, long? assignmentId, string assignmentName, string createUserFirstName,
            string createUserLastName, string createUserUserName, DateTime createDateTime, Date createdShiftStartDate,
            Date createdShiftEndDate, long createUserId, bool? isReadByCurrentUser, bool hasYesAnswer,
            List<string> visibilityGroupNames, bool isFlexible, DateTime flexiShiftStartDate, DateTime flexiShiftEndDate)
        {
            this.id = id;
            this.shiftHandoverConfigurationName = shiftHandoverConfigurationName;
            functionalLocationNames = functionalLocations;
            this.shiftId = shiftId;
            this.shiftName = shiftName;
            this.isReadByCurrentUser = isReadByCurrentUser;
            this.hasYesAnswer = hasYesAnswer;

            this.assignmentId = assignmentId;
            this.assignmentName = assignmentName ?? StringResources.NullWorkAssignment;

            this.createUserId = createUserId;
            this.createUserFirstName = createUserFirstName;
            this.createUserLastName = createUserLastName;
            this.createUserUserName = createUserUserName;

            this.createDateTime = createDateTime;
            this.createdShiftStartDate = createdShiftStartDate;
            this.createdShiftEndDate = createdShiftEndDate;

            this.visibilityGroupNames = visibilityGroupNames ?? new List<string>();
            this.visibilityGroupNames.Sort();
            this.isFlexible = isFlexible;
            this.flexiShiftStartDate = flexiShiftStartDate;
            this.flexiShiftEndDate = flexiShiftEndDate;
        }

        public ReadStatus ReadStatus
        {
            get
            {
                if (IsReadByCurrentUser == null)
                {
                    return ReadStatus.Unread;
                }

                return IsReadByCurrentUser.Value ? ReadStatus.Read : ReadStatus.Unread;
            }
        }

        public string ShiftHandoverConfigurationName
        {
            get { return shiftHandoverConfigurationName; }
        }

        [IncludeInSearch]
        public string FunctionalLocations
        {
            get { return functionalLocationNames; }
        }

        public long ShiftId
        {
            get { return shiftId; }
        }

        [IncludeInSearch]
        public string ShiftDisplayName
        {
            get { return isFlexible ? String.Format("{0}-{1}-F", flexiShiftStartDate.ToString("dd/MM/yy"), flexiShiftEndDate.ToString("dd/MM/yy")) : String.Format("{0} - {1}", createdShiftStartDate, shiftName); }
        }

        public long? AssignmentId
        {
            get { return assignmentId; }
        }

        [IncludeInSearch]
        public string AssignmentName
        {
            get { return assignmentName; }
        }

        public string CreateUserFullName
        {
            get { return User.ToFullName(createUserFirstName, createUserLastName); }
        }

        [IncludeInSearch]
        public string CreateUser
        {
            get { return User.ToFullNameWithUserName(createUserLastName, createUserFirstName, createUserUserName); }
        }

        public long CreateUserId
        {
            get { return createUserId; }
        }

        [IncludeInSearch]
        public DateTime CreateDateTime
        {
            get { return createDateTime; }
        }

        public Date CreatedShiftStartDate
        {
            get { return createdShiftStartDate; }
        }

        public Date CreatedShiftEndDate
        {
            get { return createdShiftEndDate; }
        }

        public bool HasYesAnswer
        {
            get { return hasYesAnswer; }
        }

        [IncludeInSearch]
        public string VisibilityGroupNames
        {
            get { return visibilityGroupNames.BuildCommaSeparatedList(); }
        }

        public bool? IsReadByCurrentUser
        {
            get { return isReadByCurrentUser; }
            set { isReadByCurrentUser = value; }
        }

        public bool IsCreatedBy(User user)
        {
            return user.Id.GetValueOrDefault(0) == createUserId;
        }

        public void AddVisibilityGroup(string visibilityGroupName)
        {
            visibilityGroupNames.AddAndSort(visibilityGroupName);
        }

        [IncludeInSearch]
        public bool IsFlexible
        {
            get { return isFlexible; }
        }
        [IncludeInSearch]
        public DateTime FlexiShiftStartDate
        {
            get { return flexiShiftStartDate; }
        }
        [IncludeInSearch]
        public DateTime FlexiShiftEndDate
        {
            get { return flexiShiftEndDate; }
        }
    }
}