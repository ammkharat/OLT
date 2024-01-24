using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class OnPremiseContractor : DomainObject
    {
        public OnPremiseContractor(long? id, long? overtimeFormId, string personnelName, string primaryLocation,
            DateTime startDateTime, DateTime endDateTime, bool isDayShift,
            bool isNightShift, string phoneNumber, string radio, string description, string company,
            string workOrderNumber, decimal expectedHours)
        {
            this.id = id;
            OvertimeFormId = overtimeFormId;
            PersonnelName = personnelName;
            PrimaryLocation = primaryLocation;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            IsDayShift = isDayShift;
            IsNightShift = isNightShift;
            PhoneNumber = phoneNumber;
            Radio = radio;
            Description = description;
            Company = company;
            WorkOrderNumber = workOrderNumber;
            ExpectedHours = expectedHours;
        }

        public long? OvertimeFormId { get; set; }
        public string PersonnelName { get; set; }
        public string PrimaryLocation { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsDayShift { get; set; }
        public bool IsNightShift { get; set; }
        public string PhoneNumber { get; set; }
        public string Radio { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string WorkOrderNumber { get; set; }
        public decimal ExpectedHours { get; set; }

        public string Shifts
        {
            get
            {
                if (IsDayShift && IsNightShift)
                    return "Day/Night";
                return IsDayShift ? "Day" : "Night";
            }
        }

        public bool IsFromCardSystem
        {
            get { return PersonnelName.IsInFormatOfEdmontonCardSwipeSystem(); }
        }

        public bool DatesContainsRequestedShifts()
        {
            var dayShiftPattern = new ShiftPattern(-1, "Day", WorkPermitEdmonton.DayShiftStartTime,
                WorkPermitEdmonton.NightShiftStartTime, StartDateTime, null, TimeSpan.Zero,
                TimeSpan.Zero);
            var nightShiftPattern = new ShiftPattern(-1, "Night", WorkPermitEdmonton.NightShiftStartTime,
                WorkPermitEdmonton.DayShiftStartTime, StartDateTime, null, TimeSpan.Zero,
                TimeSpan.Zero);
            var shiftPatterns = new List<ShiftPattern> {dayShiftPattern, nightShiftPattern};

            var userShifts = new List<UserShift>();

            var currentShift = dayShiftPattern.IsTimeInShiftEndDateExclusive(StartDateTime.ToTime())
                ? new UserShift(dayShiftPattern, StartDateTime)
                : new UserShift(nightShiftPattern, StartDateTime);

            userShifts.Add(currentShift);

            currentShift = currentShift.ChooseNextShift(shiftPatterns);

            // the second part is for the case: EndDatetime 6/21 5pm and the current shift EndDateTime is 6/21 6:30pm.
            // We still want to include that shift.
            while (currentShift.EndDateTime <= EndDateTime ||
                   currentShift.IsInUserShiftIncludingPadding(-1, EndDateTime))
            {
                userShifts.Add(currentShift);
                currentShift = currentShift.ChooseNextShift(shiftPatterns);
            }

            if (IsDayShift && !userShifts.Exists(shift => shift.ShiftPatternName.Equals("Day")))
            {
                return false;
            }
            if (IsNightShift && !userShifts.Exists(shift => shift.ShiftPatternName.Equals("Night")))
            {
                return false;
            }
            return true;
        }

        public OnPremiseContractor CloneWithoutId()
        {
            var clone = Clone() as OnPremiseContractor;
            clone.Id = null;
            return clone;
        }
    }

    [Serializable]
    public class OnPremisePersonnel : DomainObject, ISiteRelevant
    {
        public OnPremisePersonnel(OvertimeForm overtimeForm, OnPremiseContractor onPremiseContractor,
            CardEntryStatus cardEntryStatus)
        {
            id = onPremiseContractor.Id;
            OvertimeForm = overtimeForm;
            OnPremiseContractor = onPremiseContractor;
            CardEntryStatus = cardEntryStatus;
        }

        public OvertimeForm OvertimeForm { get; private set; }
        public OnPremiseContractor OnPremiseContractor { get; private set; }
        public CardEntryStatus CardEntryStatus { get; private set; }

        public bool IsRelevantTo(long siteId)
        {
            return siteId == Site.EDMONTON_ID;
        }

        public bool Overlaps(Range<DateTime> dateRange)
        {
            return
                dateRange.IsRangeOverLapped(new Range<DateTime>(OnPremiseContractor.StartDateTime,
                    OnPremiseContractor.EndDateTime));
        }
    }
}