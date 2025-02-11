﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public abstract class BasePermitRequestDTO : DomainObject, IHasDataSource
    {
        private long id1;
        private string templateName;
        private string categories;
        private string wp_TypeName;
        private string desc;
        private  bool global;
        private  long templateId;

        public BasePermitRequestDTO(
            long? id,
            Date endDate,
            string description,
            DataSource dataSource,
            string lastImportedByFullnameWithUserName,
            DateTime? lastImportedDateTime,
            string lastSubmittedByFullnameWithUserName,
            DateTime? lastSubmittedDateTime,
            long createdByUserId,
            DateTime lastModifiedDateTime,
            string lastModifiedByFullnameWithUserName)
        {
            Id = id;
            EndDate = endDate;
            Description = description;

            DataSource = dataSource;
            LastImportedByFullnameWithUserName = lastImportedByFullnameWithUserName;
            LastImportedDateTime = lastImportedDateTime;
            LastSubmittedByFullnameWithUserName = lastSubmittedByFullnameWithUserName;
            LastSubmittedDateTime = lastSubmittedDateTime;

            CreatedByUserId = createdByUserId;
            LastModifiedDateTime = lastModifiedDateTime;
            LastModifiedByFullnameWithUserName = lastModifiedByFullnameWithUserName;
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public BasePermitRequestDTO(long id1, string templateName, string categories, string wp_TypeName, string desc, string functionalLocationName)
        {
            // TODO: Complete member initialization
            this.id1 = id1;
            this.templateName = templateName;
            this.categories = categories;
            this.wp_TypeName = wp_TypeName;
            this.desc = desc;
            FunctionalLocationNamesAsString = functionalLocationName;
        }

        public BasePermitRequestDTO(long id1, string templateName, string categories, string wp_TypeName, string desc, List<string> functionalLocationName)
        {
            // TODO: Complete member initialization
            this.id1 = id1;
            this.templateName = templateName;
            this.categories = categories;
            this.wp_TypeName = wp_TypeName;
            this.desc = desc;
            FunctionalLocationNames = functionalLocationName;
        }

        public BasePermitRequestDTO(long id1, string templateName, string categories, string wp_TypeName, string desc, bool global, long templateId)
        {
            // TODO: Complete member initialization
            this.id1 = id1;
            this.templateName = templateName;
            this.categories = categories;
            this.wp_TypeName = wp_TypeName;
            this.desc = desc;
            this.global = global;
            this.templateId = templateId;
            
        }
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        [IncludeInSearch]
        public string FunctionalLocationNamesAsString { get; private set; }
        public List<string> FunctionalLocationNames { get; private set; }

        [IncludeInSearch]
        public string WorkOrderNumber { get; set; }

        public abstract Date StartDate { get; }
        public Date EndDate { get; private set; }

        [IncludeInSearch]
        public virtual DateTime? StartDateAsDateTime
        {
            get { return StartDate != null ? (DateTime?) StartDate.CreateDateTime(new Time(0)) : null; }
        }

        [IncludeInSearch]
        public virtual DateTime? EndDateAsDateTime
        {
            get { return EndDate != null ? (DateTime?) EndDate.CreateDateTime(new Time(0)) : null; }
        }

        [IncludeInSearch]
        public string Description { get; private set; }

        [IncludeInSearch]
        public string LastImportedByFullnameWithUserName { get; private set; }

        [IncludeInSearch]
        public DateTime? LastImportedDateTime { get; private set; }

        [IncludeInSearch]
        public string LastSubmittedByFullnameWithUserName { get; private set; }

        [IncludeInSearch]
        public DateTime? LastSubmittedDateTime { get; private set; }

        public long CreatedByUserId { get; private set; }

        [IncludeInSearch]
        public DateTime LastModifiedDateTime { get; private set; }

        [IncludeInSearch]
        public string LastModifiedByFullnameWithUserName { get; private set; }

        [IncludeInSearch]
        public DataSource DataSource { get; private set; }
    }
}