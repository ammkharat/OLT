﻿using System;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using Com.Suncor.Olt.Common.Domain.Validation.Montreal;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestMontreal : BasePermitRequest
    {
        private static string NameOfDayShift = "J";

        private readonly List<PermitAttribute> attributes = new List<PermitAttribute>();

        public PermitRequestMontreal(long? id, WorkPermitMontrealType workPermitType,
            List<FunctionalLocation> functionalLocations, Date startDate, Date endDate, string workOrderNumber,
            string operationNumber,
            string subOperationNumber, string trade, string description, string sapDescription, string company,
            string supervisor, string excavationNumber, DataSource dataSource, User lastImportedByUser,
            DateTime? lastImportedDateTime, User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User createdBy,
            DateTime createdDateTime, User lastModifiedBy, DateTime lastModifiedDateTime,
            WorkPermitMontrealGroup requestedByGroup, PermitRequestCompletionStatus completionStatus)
            : base(
                id, endDate, description, sapDescription, company, dataSource, lastImportedByUser, lastImportedDateTime,
                lastSubmittedByUser, lastSubmittedDateTime,
                createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime, workOrderNumber, operationNumber,
                subOperationNumber, completionStatus)
        {
            WorkPermitType = workPermitType;
            RequestedByGroup = requestedByGroup;
            ExcavationNumber = excavationNumber;
            FunctionalLocations = functionalLocations ?? new List<FunctionalLocation>();
            Supervisor = supervisor;
            StartDate = startDate;
            Trade = trade;
            CompletionStatus = completionStatus;
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public PermitRequestMontreal(string templatename, string categories) :
            base(templatename, categories)
        {
            _templateName = templatename;
            _categories = categories;
        }

        public static Time StartOfDefaultDayShift
        {
            get { return new Time(6, 00, 0); }
        }

        public static Time StartOfDefaultNightShift
        {
            get { return new Time(18, 00, 0); }
        }

        public Date StartDate { get; set; }
        public WorkPermitMontrealType WorkPermitType { get; set; }
        public string ExcavationNumber { get; set; }
        public List<FunctionalLocation> FunctionalLocations { get; private set; }
        public string Supervisor { get; set; }
        public string Trade { get; set; }

        public List<PermitAttribute> Attributes
        {
            get { return attributes; }
        }

        public override string FunctionalLocationNamesAsString
        {
            get { return FunctionalLocations.FullHierarchyListToString(false, false); }
        }

        public string FunctionalLocationsAsCommaSeparatedFullHierarchyList
        {
            get { return FunctionalLocations.FullHierarchyListToString(true, false); }
        }

        public string OperationNumberAndSubOperationNumberForDisplay
        {
            get
            {
                if (OperationNumber == null)
                {
                    return null;
                }

                if (SubOperationNumber == null)
                {
                    return OperationNumber;
                }

                return string.Format("{0}-{1}", OperationNumber, SubOperationNumber);
            }
        }

        public WorkPermitMontrealGroup RequestedByGroup { get; set; }

        public PermitRequestMontrealHistory TakeSnapshot()
        {
            var attributeNames = Attributes.ConvertAll(obj => obj.Name);
            attributeNames.Sort();

            return new PermitRequestMontrealHistory(
                IdValue,
                WorkPermitType,
                DataSource,
                FunctionalLocationsAsCommaSeparatedFullHierarchyList,
                StartDate,
                EndDate,
                WorkOrderNumber,
                OperationNumber,
                Trade,
                Description,
                SapDescription,
                Company,
                Supervisor,
                ExcavationNumber,
                attributeNames.BuildCommaSeparatedList(),
                LastImportedByUser,
                LastImportedDateTime,
                LastSubmittedByUser,
                LastSubmittedDateTime,
                LastModifiedBy,
                LastModifiedDateTime,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                RequestedByGroup == null ? null : RequestedByGroup.Name,
                CompletionStatus);
        }

        public override void UpdateFrom(BasePermitRequest request)
        {
            var incomingPermitRequest = (PermitRequestMontreal) request;

            WorkPermitType = incomingPermitRequest.WorkPermitType;
            FunctionalLocations = incomingPermitRequest.FunctionalLocations;
            StartDate = incomingPermitRequest.StartDate;
            EndDate = incomingPermitRequest.EndDate;
            WorkOrderNumber = incomingPermitRequest.WorkOrderNumber;
            OperationNumber = incomingPermitRequest.OperationNumber;
            SubOperationNumber = incomingPermitRequest.SubOperationNumber;
            Trade = incomingPermitRequest.Trade;
            Description = incomingPermitRequest.Description;
            SapDescription = incomingPermitRequest.SapDescription;

            Company = incomingPermitRequest.Company;
            Supervisor = incomingPermitRequest.Supervisor;
            ExcavationNumber = incomingPermitRequest.ExcavationNumber;

            DataSource = incomingPermitRequest.DataSource;
            LastImportedByUser = incomingPermitRequest.LastImportedByUser;
            LastImportedDateTime = incomingPermitRequest.LastImportedDateTime;

            CreatedBy = incomingPermitRequest.CreatedBy;
            CreatedDateTime = incomingPermitRequest.CreatedDateTime;
            LastModifiedBy = incomingPermitRequest.LastModifiedBy;
            LastModifiedDateTime = incomingPermitRequest.LastModifiedDateTime;

            Attributes.Clear();
            Attributes.AddRange(incomingPermitRequest.Attributes);
        }

        private static ShiftPattern CreateDayShiftPattern(int preShiftPaddingInMinutes, int postShiftPaddingInMinutes)
        {
            var preShiftPaddingTimeSpan = new TimeSpan(0, preShiftPaddingInMinutes, 0);
            var postShiftPaddingTimeSpan = new TimeSpan(0, postShiftPaddingInMinutes, 0);

            return new ShiftPattern(0, NameOfDayShift, StartOfDefaultDayShift, StartOfDefaultNightShift,
                new DateTime(2000, 1, 1), null, preShiftPaddingTimeSpan, postShiftPaddingTimeSpan);
        }

        private static ShiftPattern CreateNightShiftPattern(int preShiftPaddingInMinutes, int postShiftPaddingInMinutes)
        {
            var preShiftPaddingTimeSpan = new TimeSpan(0, preShiftPaddingInMinutes, 0);
            var postShiftPaddingTimeSpan = new TimeSpan(0, postShiftPaddingInMinutes, 0);

            return new ShiftPattern(0, "N", StartOfDefaultNightShift, StartOfDefaultDayShift, new DateTime(2000, 1, 1),
                null, preShiftPaddingTimeSpan, postShiftPaddingTimeSpan);
        }

        public static bool IsDayShift(Time time)
        {
            return (time >= StartOfDefaultDayShift && time < StartOfDefaultNightShift);
        }

        public static UserShift UserShift(DateTime dateTime, int preShiftPaddingInMinutes, int postShiftPaddingInMinutes)
        {
            var currentTime = dateTime.ToTime();
            var currentDate = dateTime.ToDate();

            var shiftPattern = IsDayShift(currentTime)
                ? CreateDayShiftPattern(preShiftPaddingInMinutes, postShiftPaddingInMinutes)
                : CreateNightShiftPattern(preShiftPaddingInMinutes, postShiftPaddingInMinutes);

            if (currentTime < StartOfDefaultDayShift)
            {
                currentDate = currentDate.SubtractDays(1);
            }

            var userShift = new UserShift(shiftPattern, currentDate);
            return userShift;
        }

        public static UserShift UserShift(DateTime dateTime)
        {
            return UserShift(dateTime, 0, 0);
        }

        public void ConvertToClone(User user)
        {
            DataSource = DataSource.CLONE;

            UserShift userShift = UserShift(Clock.Now);
            var endOfShift = userShift.EndDateTime;

            Id = null;
            CompletionStatus = null;

            LastSubmittedByUser = null;
            LastSubmittedDateTime = null;
            LastImportedByUser = null;
            LastImportedDateTime = null;

            LastModifiedBy = user; 
            LastModifiedDateTime = Clock.Now;

            CreatedBy = user; 
            CreatedDateTime = Clock.Now;

            StartDate = Clock.Now.ToDate();
            EndDate = endOfShift.ToDate();

            DocumentLinks = DocumentLinks.ConvertAll(link => link.CloneWithoutId());
        }

        public override void UpdateIfModifiedFrom(BasePermitRequest incomingPermitRequest)
        {
            base.UpdateIfModifiedFrom(incomingPermitRequest);

            var incomingPermitRequestMontreal = (PermitRequestMontreal) incomingPermitRequest;
            StartDate = incomingPermitRequestMontreal.StartDate;
        }

        public override bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
        {
            foreach (var floc in FunctionalLocations)
            {
                var isRelevant = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
                if (isRelevant)
                {
                    return true;
                }
            }
            return false;
        }

        public override PermitRequestCompletionStatus Validate(DateTime currentDateTimeInSite)
        {
            var validator = new PermitRequestMontrealValidator(new PermitRequestMontrealValidationDomainAdapter(this));
            validator.Validate(currentDateTimeInSite.ToDate());
            return validator.CompletionStatus;
        }

        public override bool HasNoFunctionalLocation()
        {
            return FunctionalLocations == null || FunctionalLocations.IsEmpty();
        }

        public override bool HasAFunctionalLocationHigherThanLevel3()
        {
            return FunctionalLocations != null &&
                   FunctionalLocations.Exists(floc => floc.Type < FunctionalLocationType.Level3);
        }
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public string TemplateCreatedBy { get; set; }
        public string Categories
        { get; set; }

        public bool Global { get; set; }
        public bool Individual { get; set; }
        public string _templateName { get; set; }
        public string _categories { get; set; }
//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public long TemplateId { get; set; }
    }
}