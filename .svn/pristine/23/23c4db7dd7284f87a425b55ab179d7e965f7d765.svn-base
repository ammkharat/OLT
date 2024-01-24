using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class DeviationAlertReportDTO
    {
        public DeviationAlertReportDTO(
            long id,
            string name,
            string flocFullHierarchy,
            string measurementTag,
            int? measurementValue,
            string targetTag,
            int? targetValue,
            DateTime startDateTime,
            DateTime endDateTime,
            bool isHiddenDeviation,
            string reasonCode,
            int? assignedAmount,
            string plantState,
            string reasonCodeFlocFullHierarchy,
            string reasonCodeFlocDescription,
            string reasonCodeAssignmentComments)
        {
            Id = id;
            Name = name;
            FlocFullHierarchy = new FunctionalLocationHierarchy(flocFullHierarchy);
            MeasurementTag = measurementTag;
            MeasurementValue = measurementValue ?? 0;
            TargetTag = targetTag;
            TargetValue = targetValue ?? 0;
            DeviationValue = DeviationAlert.GetDeviationValue(measurementValue, targetValue);
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            IsHiddenDeviation = isHiddenDeviation;
            ReasonCode = reasonCode;
            AssignedAmount = assignedAmount;
            PlantState = plantState;
            ReasonCodeFlocFullHierarchy = reasonCodeFlocFullHierarchy == null
                ? null
                : new FunctionalLocationHierarchy(reasonCodeFlocFullHierarchy);
            ReasonCodeFlocDescription = reasonCodeFlocDescription;
            ReasonCodeAssignmentComments = reasonCodeAssignmentComments;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        private FunctionalLocationHierarchy FlocFullHierarchy { get; set; }
        public string MeasurementTag { get; private set; }
        public int MeasurementValue { get; private set; }
        public string TargetTag { get; private set; }
        public int TargetValue { get; private set; }
        public int DeviationValue { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public bool IsHiddenDeviation { get; private set; }

        public string PlantState { get; private set; }
        public string ReasonCode { get; private set; }
        public int? AssignedAmount { get; private set; }
        private FunctionalLocationHierarchy ReasonCodeFlocFullHierarchy { get; set; }
        public string ReasonCodeFlocDescription { get; private set; }
        public string ReasonCodeAssignmentComments { get; private set; }

        public string FlocDivision
        {
            get { return FlocFullHierarchy.Division; }
        }

        public string FlocSection
        {
            get { return FlocFullHierarchy.Section; }
        }

        public string FlocUnit
        {
            get { return FlocFullHierarchy.Unit; }
        }

        public string FlocEquipment1
        {
            get { return FlocFullHierarchy.Equipment1; }
        }

        public string FlocEquipment2
        {
            get { return FlocFullHierarchy.Equipment2; }
        }

        public string ReasonCodeFlocDivision
        {
            get { return ReasonCodeFlocFullHierarchy == null ? null : ReasonCodeFlocFullHierarchy.Division; }
        }

        public string ReasonCodeFlocSection
        {
            get { return ReasonCodeFlocFullHierarchy == null ? null : ReasonCodeFlocFullHierarchy.Section; }
        }

        public string ReasonCodeFlocUnit
        {
            get { return ReasonCodeFlocFullHierarchy == null ? null : ReasonCodeFlocFullHierarchy.Unit; }
        }

        public string ReasonCodeFlocEquipment1
        {
            get { return ReasonCodeFlocFullHierarchy == null ? null : ReasonCodeFlocFullHierarchy.Equipment1; }
        }

        public string ReasonCodeFlocEquipment2
        {
            get { return ReasonCodeFlocFullHierarchy == null ? null : ReasonCodeFlocFullHierarchy.Equipment2; }
        }
    }
}