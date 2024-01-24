using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class ShiftGapReasonReportDTO : DomainObject
    {
        private readonly string actualValue;
        private readonly DateTime actualValueReadDateTime; //Does not exist yet
        private readonly string limitValue;
        private readonly string phdTagName;
        private readonly string responseBy;
        private readonly DateTime responseByDateTime;
        private readonly string shiftName;
        private readonly DateTime shiftStartDate;

        private readonly string targetAlertFunctionalLocation;
        private readonly string targetAlertFunctionalLocationDescription;

        private readonly string targetAlertName;
        private readonly string targetAlertUnit;
        private readonly string targetAlertUnitDescription;
        private readonly string targetGapReason;
        private readonly string targetGapReasonComment;

        public ShiftGapReasonReportDTO(string shiftName,
            DateTime shiftStartDate,
            string targetAlertUnit,
            string targetAlertUnitDescription,
            string targetAlertFunctionalLocation,
            string targetAlertFunctionalLocationDescription,
            string targetAlertName,
            string phdTagName,
            string limitValue,
            string actualValue,
            DateTime actualValueReadDateTime,
            string responseBy,
            DateTime responseByDateTime,
            string targetGapReason,
            string targetGapReasonComment)
        {
            this.shiftName = shiftName;
            this.shiftStartDate = shiftStartDate;
            this.targetAlertUnit = targetAlertUnit;
            this.targetAlertUnitDescription = targetAlertUnitDescription;
            this.targetAlertFunctionalLocation = targetAlertFunctionalLocation;
            this.targetAlertFunctionalLocationDescription = targetAlertFunctionalLocationDescription;
            this.targetAlertName = targetAlertName;
            this.phdTagName = phdTagName;
            this.limitValue = limitValue;
            this.actualValue = actualValue;
            this.actualValueReadDateTime = actualValueReadDateTime;
            this.responseBy = responseBy;
            this.responseByDateTime = responseByDateTime;
            this.targetGapReason = targetGapReason;
            this.targetGapReasonComment = targetGapReasonComment;
        }

        public string ShiftName
        {
            get { return shiftName; }
        }

        public DateTime ShiftStartDate
        {
            get { return shiftStartDate; }
        }

        public string TargetAlertUnit
        {
            get { return targetAlertUnit; }
        }

        public string TargetAlertUnitDescription
        {
            get { return targetAlertUnitDescription; }
        }

        public string TargetAlertFunctionalLocation
        {
            get { return targetAlertFunctionalLocation; }
        }

        public string TargetAlertFunctionalLocationDescription
        {
            get { return targetAlertFunctionalLocationDescription; }
        }

        public string TargetAlertName
        {
            get { return targetAlertName; }
        }

        public string PhdTagName
        {
            get { return phdTagName; }
        }

        public string LimitValue
        {
            get { return limitValue; }
        }

        public string ActualValue
        {
            get { return actualValue; }
        }

        public DateTime ActualValueReadDateTime
        {
            get { return actualValueReadDateTime; }
        }

        public string ResponseBy
        {
            get { return responseBy; }
        }

        public DateTime ResponseByDateTime
        {
            get { return responseByDateTime; }
        }

        public string TargetGapReason
        {
            get { return targetGapReason; }
        }

        public string TargetGapReasonComment
        {
            get { return targetGapReasonComment; }
        }
    }
}