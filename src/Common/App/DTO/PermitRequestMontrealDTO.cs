﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class PermitRequestMontrealDTO : BasePermitRequestDTO, IHasStatus<PermitRequestCompletionStatus>
    {
        private readonly Date startDate;
        private readonly string templateName;
        private string categories;
        private string wp_TypeName;
        private string desc;
        private readonly bool global;
        private readonly long templateId;

        public PermitRequestMontrealDTO(
            long? id,
            WorkPermitMontrealType workPermitType,
            List<string> functionalLocationNames,
            Date startDate,
            Date endDate,
            string workOrderNumber,
            string operationNumber,
            string trade,
            string requestedByGroup,
            string description,
            DataSource dataSource,
            string lastImportedByFullnameWithUserName,
            DateTime? lastImportedDateTime,
            string lastSubmittedByFullnameWithUserName,
            DateTime? lastSubmittedDateTime,
            long createdByUserId,
            DateTime lastModifiedDateTime,
            string lastModifiedByFullnameWithUserName,
            PermitRequestCompletionStatus completionStatus) :
                base(
                id, endDate, description, dataSource, lastImportedByFullnameWithUserName, lastImportedDateTime,
                lastSubmittedByFullnameWithUserName, lastSubmittedDateTime,
                createdByUserId, lastModifiedDateTime, lastModifiedByFullnameWithUserName)
        {
            WorkPermitType = workPermitType;
            FunctionalLocationNames = functionalLocationNames;
            Trade = trade;
            RequestedByGroup = requestedByGroup;
            this.startDate = startDate;

            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;
            CompletionStatus = completionStatus;
        }

        public PermitRequestMontrealDTO(PermitRequestMontreal request) : this(
            request.Id,
            request.WorkPermitType,
            request.FunctionalLocations.FullHierarchyList(false),
            request.StartDate,
            request.EndDate,
            request.WorkOrderNumber,
            request.OperationNumber,
            request.Trade,
            request.RequestedByGroup == null ? null : request.RequestedByGroup.Name,
            request.Description,
            request.DataSource,
            request.LastImportedByUser == null ? null : request.LastImportedByUser.FullNameWithUserName,
            request.LastImportedDateTime,
            request.LastSubmittedByUser == null ? null : request.LastSubmittedByUser.FullNameWithUserName,
            request.LastSubmittedDateTime,
            request.CreatedBy.IdValue,
            request.LastModifiedDateTime,
            request.LastModifiedBy.FullNameWithUserName,
            request.CompletionStatus)
        {
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public PermitRequestMontrealDTO(long id, string templateName, string categories, string wp_TypeName, string desc, bool global, long templateId) :
            base(id, templateName, categories, wp_TypeName, desc, global, templateId)
        {
            Id = id;
            this.templateName = templateName;
            this.categories = categories;
            this.wp_TypeName = wp_TypeName;
            this.desc = desc;
            this.global = global;
            this.templateId = templateId;

            //FunctionalLocationNamesAsString = functionalLocationName;
        }

        public override Date StartDate
        {
            get { return startDate; }
        }

        public WorkPermitMontrealType WorkPermitType { get; private set; }
        public List<string> FunctionalLocationNames { get; private set; }

        [IncludeInSearch]
        public string OperationNumber { get; private set; }

        [IncludeInSearch]
        public string RequestedByGroup { get; private set; }

        [IncludeInSearch]
        public string Trade { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationNamesAsString
        {
            get { return FunctionalLocationNames.BuildCommaSeparatedList(); }
        }

        public PermitRequestCompletionStatus CompletionStatus { get; private set; }

        [IncludeInSearch]
        public PermitRequestCompletionStatus Status
        {
            get { return CompletionStatus; }
        }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            FunctionalLocationNames.AddAndSort(functionalLocationName);
        }
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
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