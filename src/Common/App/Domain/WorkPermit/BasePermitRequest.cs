﻿using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public abstract class BasePermitRequest : DomainObject, IHistoricalDomainObject, IFunctionalLocationRelevant,
        IHasPermitKey, IDocumentLinksObject
    {
        protected BasePermitRequest(long? id, Date endDate, string description, string sapDescription, string company, 
            DataSource dataSource,
            User lastImportedByUser, DateTime? lastImportedDateTime, User lastSubmittedByUser,
            DateTime? lastSubmittedDateTime, User createdBy,
            DateTime createdDateTime, User lastModifiedBy, DateTime lastModifiedDateTime, string workOrderNumber,
            string operationNumber, string subOperationNumber, PermitRequestCompletionStatus completionStatus)
        {
            Id = id;

            EndDate = endDate;

            Description = description;
            SapDescription = sapDescription;

            Company = company;
            

            DataSource = dataSource;
            LastImportedByUser = lastImportedByUser;
            LastImportedDateTime = lastImportedDateTime;
            LastSubmittedByUser = lastSubmittedByUser;
            LastSubmittedDateTime = lastSubmittedDateTime;

            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;

            IsModified = false;

            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;
            // Mergetodo: should we remove this and push it to the subclasses? It isn't used in Lubes and Edmonton
            SubOperationNumber = subOperationNumber;
            // Mergetodo: should we remove this and push it to the subclasses? It isn't used in Lubes and Edmonton

            CompletionStatus = completionStatus;

            DocumentLinks = new List<DocumentLink>();
        }

// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        protected BasePermitRequest(long? id, Date endDate, string description, string sapDescription, string company, string company_1, string company_2,
            DataSource dataSource,
            User lastImportedByUser, DateTime? lastImportedDateTime, User lastSubmittedByUser,
            DateTime? lastSubmittedDateTime, User createdBy,
            DateTime createdDateTime, User lastModifiedBy, DateTime lastModifiedDateTime, string workOrderNumber,
            string operationNumber, string subOperationNumber, PermitRequestCompletionStatus completionStatus,
            DateTime startDateTime, DateTime endDateTime
            )
        {
            Id = id;

            EndDate = endDate;

            Description = description;
            SapDescription = sapDescription;

            Company = company;
            Company_1 = company_1;
            Company_2 = company_2;

            StartDateTime = startDateTime;
            EndDateTime = endDateTime;

            DataSource = dataSource;
            LastImportedByUser = lastImportedByUser;
            LastImportedDateTime = lastImportedDateTime;
            LastSubmittedByUser = lastSubmittedByUser;
            LastSubmittedDateTime = lastSubmittedDateTime;

            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;

            IsModified = false;

            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;
            // Mergetodo: should we remove this and push it to the subclasses? It isn't used in Lubes and Edmonton
            SubOperationNumber = subOperationNumber;
            // Mergetodo: should we remove this and push it to the subclasses? It isn't used in Lubes and Edmonton

            CompletionStatus = completionStatus;

            DocumentLinks = new List<DocumentLink>();
        }


//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        protected BasePermitRequest(string templatename, string categories)
        {
            _templateName = templatename;
            _categories = categories;
        }


        public string _templateName { get; set; }
        public string _categories { get; set; }

        public PermitRequestCompletionStatus CompletionStatus { get; set; }

        public Date EndDate { get; set; }

        public virtual string Description { get; set; }
        public string SapDescription { get; set; }

        public string Company { get; set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        public string Company_1 { get; set; }
        public string Company_2 { get; set; }

         

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public DataSource DataSource { get; protected set; }
        public User LastImportedByUser { get; set; }
        public DateTime? LastImportedDateTime { get; set; }
        public User LastSubmittedByUser { get; set; }
        public DateTime? LastSubmittedDateTime { get; set; }

        public User CreatedBy { get; protected set; }
        public DateTime CreatedDateTime { get; set; }
        public User LastModifiedBy { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        public bool IsModified { get; set; }

        public bool IsSubmitted
        {
            get { return LastSubmittedDateTime != null; }
        }

        public abstract string FunctionalLocationNamesAsString { get; }
        public List<DocumentLink> DocumentLinks { get; set; }

        public abstract bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies,
            List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,
            SiteConfiguration siteConfiguration);

        public string WorkOrderNumber { get; set; }
        public string OperationNumber { get; set; }
        public string SubOperationNumber { get; set; }

        public virtual bool MatchesByPermitKey(IHasPermitKey item)
        {
            return PermitKeyData.MatchesByPermitKey(this, item);
        }

        public abstract bool HasNoFunctionalLocation();
        public abstract bool HasAFunctionalLocationHigherThanLevel3();

        public abstract void UpdateFrom(BasePermitRequest permitRequest);

        public virtual void UpdateIfModifiedFrom(BasePermitRequest incomingPermitRequest)
        {
            EndDate = incomingPermitRequest.EndDate;
            SapDescription = incomingPermitRequest.SapDescription;
            LastModifiedDateTime = incomingPermitRequest.LastModifiedDateTime;
            LastModifiedBy = incomingPermitRequest.LastModifiedBy;
            LastImportedByUser = incomingPermitRequest.LastImportedByUser;
            LastImportedDateTime = incomingPermitRequest.LastImportedDateTime;
        }

        public abstract PermitRequestCompletionStatus Validate(DateTime currentDateTimeInSite);
    }
}