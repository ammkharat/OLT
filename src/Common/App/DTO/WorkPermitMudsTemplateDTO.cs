﻿using System;
using System.Collections.Generic;
using System.Drawing.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class WorkPermitMudsTemplateDTO : DomainObject, IHasStatus<PermitRequestBasedWorkPermitStatus>, IHasDataSource
    {
        private readonly long createdByUserId;
        private readonly DateTime createdDateTime;
        private readonly DataSource dataSource;
        private readonly string description;
        private readonly string interrupteursFCO; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        private readonly bool fco; //Added By Vibhor : RITM0555766 - OLT improvement on work request
        
        private readonly DateTime endDateTime;
        private readonly List<string> functionalLocationNames = new List<string>();
        private readonly DateTime? issuedDateTime;
        private readonly String lastModifiedByFullNameWithUserName;
        private readonly long lastModifiedByUserId;
        private readonly DateTime lastModifiedDateTime;
        private readonly long? permitNumber;
        private readonly string requestedByGroup;
        private readonly DateTime startDateTime;
        private readonly string trade;
        private readonly string workOrderNumber;
        private readonly int workPermitStatusId;
        private readonly int workPermitTypeId;
        private readonly string templateName;
        private readonly string categories;
        private readonly string wp_TypeName;
        private readonly string desc;
        private readonly bool global;
        private readonly long templateId;
        
        
        

        //public WorkPermitMudsTemplateDTO(WorkPermitMuds domainObject)
        //{
        //    Id = domainObject.Id;
        //    dataSource = domainObject.DataSource;
        //    workPermitStatusId = (int) domainObject.WorkPermitStatus.IdValue;
        //    workPermitTypeId = (int) domainObject.WorkPermitType.IdValue;

        //    startDateTime = domainObject.StartDateTime;
        //    endDateTime = domainObject.EndDateTime;

        //    permitNumber = domainObject.PermitNumber;
        //    workOrderNumber = domainObject.WorkOrderNumber;

        //    functionalLocationNames = domainObject.FunctionalLocations.FullHierarchyList(false);
        //    trade = domainObject.Trade;
        //    requestedByGroup = domainObject.RequestedByGroup == null ? null : domainObject.RequestedByGroup.Name;
        //    description = domainObject.Description;
        //    createdDateTime = domainObject.CreatedDateTime;
        //    createdByUserId = domainObject.CreatedBy.IdValue;
        //    lastModifiedDateTime = domainObject.LastModifiedDateTime;
        //    lastModifiedByUserId = domainObject.LastModifiedBy.IdValue;
        //    lastModifiedByFullNameWithUserName = domainObject.LastModifiedBy == null
        //        ? null
        //        : domainObject.LastModifiedBy.FullNameWithUserName;
        //    issuedDateTime = domainObject.IssuedDateTime;
        //    interrupteursFCO = domainObject.InterrupteursEtVannesCadenasses.Text; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        //    fco = domainObject.InterrupteursEtVannesCadenasses.StateAsBool; //Added By Vibhor : RITM0555766 - OLT improvement on work request

        //}

        //public WorkPermitMudsTemplateDTO(
        //    long id,
        //    DataSource dataSource,
        //    int workPermitStatusId,
        //    int workPermitTypeId,
        //    DateTime startDateTime,
        //    DateTime endDateTime,
        //    long? permitNumber,
        //    string workOrderNumber,
        //    List<string> functionalLocationNames,
        //    string trade,
        //    string requestedByGroup,
        //    string description,
        //    string interrupteursFCO, // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        //    bool fco, //Added By Vibhor : RITM0555766 - OLT improvement on work request
        //    DateTime createdDateTime,
        //    long createdByUserId,
        //    DateTime lastModifiedDateTime,
        //    long lastModifiedByUserId,
        //    string lastModifiedByFullNameWithUserName,
        //    DateTime? issuedDateTime
        //    )
        //{
        //    this.id = id;
        //    this.dataSource = dataSource;
        //    this.workPermitStatusId = workPermitStatusId;
        //    this.workPermitTypeId = workPermitTypeId;
        //    this.startDateTime = startDateTime;
        //    this.endDateTime = endDateTime;
        //    this.permitNumber = permitNumber;
        //    this.workOrderNumber = workOrderNumber;
        //    this.functionalLocationNames = functionalLocationNames;
        //    this.trade = trade;
        //    this.requestedByGroup = requestedByGroup;
        //    this.description = description;
        //    this.interrupteursFCO = interrupteursFCO; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        //    this.fco = fco; //Added By Vibhor : RITM0555766 - OLT improvement on work request
        //    this.createdDateTime = createdDateTime;
        //    this.createdByUserId = createdByUserId;
        //    this.lastModifiedDateTime = lastModifiedDateTime;
        //    this.lastModifiedByUserId = lastModifiedByUserId;
        //    this.lastModifiedByFullNameWithUserName = lastModifiedByFullNameWithUserName;
        //    this.issuedDateTime = issuedDateTime;
        //}

        public WorkPermitMudsTemplateDTO(long id, long? permitNumber, string templateName, string categories, string wp_TypeName, string desc, bool global, long templateId/*, List<string> functionalLocationNames*/ )
        {
            Id = id;
            this.permitNumber = permitNumber;
            this.templateName = templateName;
            this.categories = categories;
            this.wp_TypeName = wp_TypeName;
            this.desc = desc;
            this.global = global;
            //this.functionalLocationNames = functionalLocationNames;
            this.templateId = templateId;
        }

        public int StatusId
        {
            get { return workPermitStatusId; }
        }

        public string WorkPermitTypeName
        {
            get { return WorkPermitType.Get(workPermitTypeId).Name; }
        }

        public WorkPermitMudsType WorkPermitMudsType
        {
            get { return WorkPermitMudsType.Get(workPermitTypeId); }
        }

        [IncludeInSearch]
        public DateTime StartDateTime
        {
            get { return startDateTime; }
        }

        public DateTime EndDateTime
        {
            get { return endDateTime; }
        }

        [IncludeInSearch]
        public long? PermitNumber
        {
            get { return permitNumber; }
            private set { }
        }

        [IncludeInSearch]
        public string WorkOrderNumber
        {
            get { return workOrderNumber; }
        }

        [IncludeInSearch]
        public string FunctionalLocationFullHierarchies
        {
            get { return functionalLocationNames.BuildCommaSeparatedList(); }
        }

        // I'm not sure why, but a story I did specifically said to not include this field in search.
        public string RequestedByGroup
        {
            get { return requestedByGroup; }
        }

        [IncludeInSearch]
        public string Trade
        {
            get { return trade; }
        }

        [IncludeInSearch]
        public string Description
        {
            get { return description; }
        }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        [IncludeInSearch]
        public string InterrupteursFCO
        {
            get { return interrupteursFCO; }
        }

//Added By Vibhor : RITM0555766 - OLT improvement on work request
        [IncludeInSearch]
        public bool FCO
        {
            get { return fco; }
        }

        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public long CreatedByUserId
        {
            get { return createdByUserId; }
        }

        public DateTime LastModifiedDateTime
        {
            get { return lastModifiedDateTime; }
        }

        public long LastModifiedByByUserId
        {
            get { return lastModifiedByUserId; }
        }

        [IncludeInSearch]
        public string LastModifiedByFullNameWithUserName
        {
            get { return lastModifiedByFullNameWithUserName; }
        }

        public bool HasBeenIssued
        {
            get { return issuedDateTime != null; }
        }

        [IncludeInSearch]
        public DataSource DataSource
        {
            get { return dataSource; }
        }

        [IncludeInSearch]
        public PermitRequestBasedWorkPermitStatus Status
        {
            get { return PermitRequestBasedWorkPermitStatus.Get(workPermitStatusId); }
        }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocationNames.AddAndSort(functionalLocationName);
        }
        [IncludeInSearch]
        public string TemplateName
        {
            get { return templateName; }
        }

        [IncludeInSearch]
        public string Categories
        {
            get { return categories; }
        }

        [IncludeInSearch]
        public string WP_Type
        {
            get { return wp_TypeName; }
        }

         [IncludeInSearch]
        public string Desc
        {
            get { return desc; }
        }
         [IncludeInSearch]
         public bool Global
         {
             get { return global; }
         }

         [IncludeInSearch]
         public long TemplateId
         {
             get { return templateId; }
         }

        
    }
}