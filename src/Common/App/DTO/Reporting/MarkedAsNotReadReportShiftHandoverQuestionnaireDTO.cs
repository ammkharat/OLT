using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class MarkedAsNotReadReportShiftHandoverQuestionnaireDTO
    {
        private readonly List<ShiftHandoverAnswerDTO> answers = new List<ShiftHandoverAnswerDTO>();
        private readonly string assignmentDisplayName;
        private readonly DateTime createDateTime;
        private readonly string createUser;

        private readonly List<string> functionalLocations = new List<string>();
        private readonly List<ItemNotReadBy> notreadByUsers = new List<ItemNotReadBy>();
        private readonly string shiftDisplayName;
        private readonly string shiftHandoverConfigurationName;

        public MarkedAsNotReadReportShiftHandoverQuestionnaireDTO(string shiftHandoverConfigurationName,
            DateTime createDateTime,
            string shiftDisplayName,
            string createUser,
            string assignmentDisplayName,
            string functionalLocation,
            List<ItemNotReadBy> notreadByUsers)
            {

                this.shiftHandoverConfigurationName = shiftHandoverConfigurationName;
                this.createDateTime = createDateTime;
                this.shiftDisplayName = shiftDisplayName;
                this.createUser = createUser;
                this.assignmentDisplayName = assignmentDisplayName;

                AddFunctionalLocation(functionalLocation);
                this.notreadByUsers = notreadByUsers ?? new List<ItemNotReadBy>();
           }
       
        public MarkedAsNotReadReportShiftHandoverQuestionnaireDTO(List<ItemNotReadBy> notreadByUsers)
        {
            this.notreadByUsers = notreadByUsers ?? new List<ItemNotReadBy>();
        }
        public string ShiftHandoverConfigurationName
        {
            get { return shiftHandoverConfigurationName; }
        }

        public DateTime CreateDateTime
        {
            get { return createDateTime; }
        }

        public string ShiftDisplayName
        {
            get { return shiftDisplayName; }
        }

        public string CreateUser
        {
            get { return createUser; }
        }

        public string AssignmentDisplayName
        {
            get { return assignmentDisplayName; }
        }

        public string FunctionalLocations
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }
        public List<ItemNotReadBy> NotReadByUsers
        {
            get { return notreadByUsers; }
        }

        public List<ShiftHandoverAnswerDTO> Answers
        {
            get { return answers; }
        }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocations.AddAndSort(functionalLocationName);
        }

        public void AddReadByUser(ItemNotReadBy notreadByUser)
        {
            if (!notreadByUsers.Contains(notreadByUser))
            {
                notreadByUsers.Add(notreadByUser);
            }
        }
    }
}
