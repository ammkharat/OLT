using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class FormOilsandsTrainingReportDTO : DomainObject
    {
        public FormOilsandsTrainingReportDTO(long formId, long itemId, FormStatus formStatus,
            List<string> functionalLocations, string trainingDateString, string createdByAssignment,
            string createdByFullNameWithUserName, string badge, DateTime createdDateTime, string blockName,
            string trainingCode, string comments, decimal hours, bool blockCompleted, string approvalName,
            string approvedByName, DateTime? approvedDateTime, string generalComments)
        {
            id = itemId;
            FormId = formId;
            FormStatus = formStatus;
            FunctionalLocations = functionalLocations;
            TrainingDateString = trainingDateString;
            CreatedByAssignment = createdByAssignment;
            CreatedByFullNameWithUserName = createdByFullNameWithUserName;
            Badge = badge;
            CreatedDateTime = createdDateTime;
            BlockName = blockName;
            TrainingCode = trainingCode;
            Comments = comments;
            Hours = hours;
            BlockCompleted = blockCompleted;
            Approver = approvalName;
            ApprovedByName = approvedByName;
            ApprovedDateTime = approvedDateTime;
            GeneralComments = generalComments;
        }

        public long FormId { get; private set; }
        public FormStatus FormStatus { get; private set; }
        public List<string> FunctionalLocations { get; private set; }
        public string TrainingDateString { get; private set; }
        public string CreatedByAssignment { get; private set; }
        public string CreatedByFullNameWithUserName { get; private set; }
        public string Badge { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public string BlockName { get; private set; }
        public string TrainingCode { get; private set; }
        public string Comments { get; private set; }
        public decimal Hours { get; private set; }
        public bool BlockCompleted { get; private set; }
        public string Approver { get; private set; }
        public string ApprovedByName { get; private set; }
        public DateTime? ApprovedDateTime { get; private set; }
        public string GeneralComments { get; private set; }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            FunctionalLocations.AddAndSort(functionalLocationName);
        }
    }
}