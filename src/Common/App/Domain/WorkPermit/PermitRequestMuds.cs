﻿using System;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using Com.Suncor.Olt.Common.Domain.Validation.Muds;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestMuds : BasePermitRequest
    {
        private static string NameOfDayShift = "J";

        private readonly List<PermitAttribute> attributes = new List<PermitAttribute>();

        public PermitRequestMuds(long? id, WorkPermitMudsType workPermitType,
            List<FunctionalLocation> functionalLocations, Date startDate, Date endDate, string workOrderNumber,
            string operationNumber,
            string subOperationNumber, string trade, string description, string sapDescription, string company, string company_1, string company_2,
            string supervisor, string excavationNumber, DataSource dataSource, User lastImportedByUser,
            DateTime? lastImportedDateTime, User lastSubmittedByUser, DateTime? lastSubmittedDateTime, User createdBy,
            DateTime createdDateTime, User lastModifiedBy, DateTime lastModifiedDateTime,
            WorkPermitMudsGroup requestedByGroup, PermitRequestCompletionStatus completionStatus, string requestedByGroupText,
            string nbTravail, bool formation, string noms, string noms_1, string noms_2, string noms_3, string surveilant, DateTime startDateTime, DateTime endDateTime,
            bool analyse_Attribute_CheckBox, bool Cadenassage_multiple , bool Cadenassage_simple, bool Procédure_Attribute, bool Espace_clos_
            
            ) // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            : base(
                id, endDate, description, sapDescription, company, company_1, company_2, dataSource, lastImportedByUser, lastImportedDateTime,
                lastSubmittedByUser, lastSubmittedDateTime,
                createdBy, createdDateTime, lastModifiedBy, lastModifiedDateTime, workOrderNumber, operationNumber,
                subOperationNumber, completionStatus, startDateTime, endDateTime)
                //nbTravail, formation, noms)
        {
            WorkPermitType = workPermitType;
            RequestedByGroup = requestedByGroup;
            ExcavationNumber = excavationNumber;
            FunctionalLocations = functionalLocations ?? new List<FunctionalLocation>();
            Supervisor = supervisor;
            StartDate = startDate;
            Trade = trade;
            CompletionStatus = completionStatus;
            RequestedByGroupText = requestedByGroupText;

            NbTravail = nbTravail;
            Formation = formation;
            Noms = noms;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            Noms_1 = noms_1;
            Noms_2 = noms_2;
            Noms_3 = noms_3;
            Surveilant = surveilant;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;

            Analyse_Attribute_CheckBox = analyse_Attribute_CheckBox;
            Cadenassage_multiple_Attribute_CheckBox = Cadenassage_multiple;
            Cadenassage_simple_Attribute_CheckBox = Cadenassage_simple;
            Procédure_Attribute_CheckBox = Procédure_Attribute;
            Espace_clos_Attribute_CheckBox = Espace_clos_;

        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public PermitRequestMuds(string templatename, string categories) :
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
        public WorkPermitMudsType WorkPermitType { get; set; }
        public string ExcavationNumber { get; set; }
        public List<FunctionalLocation> FunctionalLocations { get; private set; }
        public string Supervisor { get; set; }
        public string Trade { get; set; }

        public string NbTravail { get; set; }
        public bool Formation { get; set; }
        public string Noms { get; set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string Noms_1 { get; set; }
        public string Noms_2 { get; set; }
        public string Noms_3 { get; set; }

        public string Surveilant { get; set; }

        //public string RequestedByGroupText { get; set; }

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

        public WorkPermitMudsGroup RequestedByGroup { get; set; }
        public string RequestedByGroupText { get; set; }

        public PermitRequestMudsHistory TakeSnapshot()
        {
            var attributeNames = Attributes.ConvertAll(obj => obj.Name);
            attributeNames.Sort();

            return new PermitRequestMudsHistory(
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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                Company_1,
                Company_2,
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
                //RequestedByGroup == null ? null : RequestedByGroup.Name,
                RequestedByGroupText,
                CompletionStatus,
                StartDateTime,
                EndDateTime
                
                );
        }

        public override void UpdateFrom(BasePermitRequest request)
        {
            var incomingPermitRequest = (PermitRequestMuds) request;

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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            Company_1 = incomingPermitRequest.Company_1;
            Company_2 = incomingPermitRequest.Company_2;
            Supervisor = incomingPermitRequest.Supervisor;
            ExcavationNumber = incomingPermitRequest.ExcavationNumber;

            StartDateTime = incomingPermitRequest.StartDateTime;
            EndDateTime = incomingPermitRequest.EndDateTime;

            NbTravail = incomingPermitRequest.NbTravail;
            Formation= incomingPermitRequest.Formation;
            Noms = incomingPermitRequest.Noms;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            Noms_1 = incomingPermitRequest.Noms_1;
            Noms_2 = incomingPermitRequest.Noms_2;
            Noms_3 = incomingPermitRequest.Noms_3;

            Surveilant = incomingPermitRequest.Surveilant;
            
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

            var incomingPermitRequestMontreal = (PermitRequestMuds) incomingPermitRequest;
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
            var validator = new PermitRequestMudsValidator(new PermitRequestMudsValidationDomainAdapter(this));
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

        public DateTime StartDateTime { get;  set; }
        public DateTime EndDateTime { get;  set; }

        public bool Analyse_Attribute_CheckBox { get; set; }
        public bool Cadenassage_multiple_Attribute_CheckBox { get; set; }
        public bool Cadenassage_simple_Attribute_CheckBox { get; set; }
        public bool Procédure_Attribute_CheckBox { get; set; }
        public bool Espace_clos_Attribute_CheckBox { get; set; }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public string TemplateCreatedBy { get; set; }
        public string Categories { get; set; }
        public bool Global { get; set; }
        public bool Individual { get; set; }

        public string _templateName { get; set; }
        public string _categories { get; set; }

        public long TemplateId { get; set; } //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

    }
}