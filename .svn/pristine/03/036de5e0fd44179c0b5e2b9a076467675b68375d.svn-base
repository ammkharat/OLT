using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class MarkedAsReadReportShiftHandoverQuestionnaireDTO
    {
        private readonly List<ShiftHandoverAnswerDTO> answers = new List<ShiftHandoverAnswerDTO>();
        private readonly string assignmentDisplayName;
        private readonly DateTime createDateTime;
        private readonly string createUser;

        private readonly List<string> functionalLocations = new List<string>();
        private readonly List<ItemReadBy> readByUsers = new List<ItemReadBy>();
        private readonly string shiftDisplayName;
        private readonly string shiftHandoverConfigurationName;

        public MarkedAsReadReportShiftHandoverQuestionnaireDTO(
            string shiftHandoverConfigurationName,
            DateTime createDateTime,
            string shiftDisplayName,
            string createUser,
            string assignmentDisplayName,
            string functionalLocation,
            List<ItemReadBy> readByUsers)
        {
            this.shiftHandoverConfigurationName = shiftHandoverConfigurationName;
            this.createDateTime = createDateTime;
            this.shiftDisplayName = shiftDisplayName;
            this.createUser = createUser;
            this.assignmentDisplayName = assignmentDisplayName;

            AddFunctionalLocation(functionalLocation);
            this.readByUsers = readByUsers ?? new List<ItemReadBy>();
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

        public List<ItemReadBy> ReadByUsers
        {
            get { return readByUsers; }
        }

        public List<ShiftHandoverAnswerDTO> Answers
        {
            get { return answers; }
        }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocations.AddAndSort(functionalLocationName);
        }

        public void AddReadByUser(ItemReadBy readByUser)
        {
            if (!readByUsers.Contains(readByUser))
            {
                readByUsers.Add(readByUser);
            }
        }
    }
}