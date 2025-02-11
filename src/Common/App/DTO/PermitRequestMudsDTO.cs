﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class PermitRequestMudsDTO : BasePermitRequestDTO, IHasStatus<PermitRequestCompletionStatus>
    {
        private readonly Date startDate;
        private readonly string templateName;
        private string categories;
        private string wp_TypeName;
        private string desc;
        private readonly bool global;
        //private readonly DateTime startDateTime;
        //private readonly DateTime endDateTime;

        private readonly long templateId;

        public PermitRequestMudsDTO(
            long? id,
            WorkPermitMudsType workPermitType,
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
            PermitRequestCompletionStatus completionStatus, string nbTravail, bool formationCheck, string noms, string noms_1, string noms_2, string noms_3, string surveilant, 
            DateTime startDateTime,DateTime endDateTime,
            bool analyse_Attribute_CheckBox, bool Cadenassage_multiple, bool Cadenassage_simple, bool Procédure_Attribute, bool Espace_clos_
            ) :
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
            Travailleur_Suncor = nbTravail;  //Added By Vibhor : RITM0555766 - OLT improvement on work request

            Start_DateTime = startDateTime;
            End_DateTime = endDateTime;

            Analyse = analyse_Attribute_CheckBox;
            Cadenassage = Cadenassage_multiple;
            Cadenassage_ = Cadenassage_simple;
            Procedure_ = Procédure_Attribute;
            Espace_ = Espace_clos_;

        }

        public PermitRequestMudsDTO(PermitRequestMuds request) : this(
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
            request.CompletionStatus,
            request.NbTravail,
            request.Formation,
            request.Noms,
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            request.Noms_1,
            request.Noms_2,
            request.Noms_3,
            request.Surveilant,
            request.StartDateTime,
            request.EndDateTime,
            request.Analyse_Attribute_CheckBox,
            request.Cadenassage_multiple_Attribute_CheckBox,
            request.Cadenassage_simple_Attribute_CheckBox,
            request.Procédure_Attribute_CheckBox,
            request.Espace_clos_Attribute_CheckBox
            )
        {
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        public PermitRequestMudsDTO(long id, string templateName, string categories, string wp_TypeName, string desc, bool global, long templateId
            /*List<string> functionalLocationNames */) :
            base(id, templateName, categories, wp_TypeName, desc, global, templateId /*functionalLocationNames */)
        {
            Id = id;
            //this.id = id;

            this.templateName = templateName;
            this.categories = categories;
            this.wp_TypeName = wp_TypeName;
            this.desc = desc;
            //FunctionalLocationNames = functionalLocationNames;
            this.global = global;
            this.templateId = templateId;
        }

        public override Date StartDate
        {
            get { return startDate; }
        }

        public WorkPermitMudsType WorkPermitType { get; private set; }
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
//Added By Vibhor : RITM0555766 - OLT improvement on work request
        public string Travailleur_Suncor { get; private set; }

         [IncludeInSearch]
        public string TravailleurSuncor
        {
            get { return Travailleur_Suncor; }
        }

         
         public DateTime Start_DateTime
         { get; private set; }
         
         public DateTime End_DateTime
         { get; private set; }

         [IncludeInSearch]
         public TimeSpan StartDateTime
         {
             get { return Start_DateTime.TimeOfDay; }
         }
        [IncludeInSearch]
         public TimeSpan EndDateTime
         {
             get { return End_DateTime.TimeOfDay; }
         }

        
        public bool Analyse { get; set; }
        
        public bool Cadenassage { get; set; }
        
        public bool Cadenassage_ { get; set; }
        
        public bool Espace_ { get; set; }
        
        public bool Procedure_ { get; set; }

        [IncludeInSearch]
        public bool AnalyseCritque { get { return Analyse; } }
        [IncludeInSearch]
        public bool Cadenassage_Multiple { get { return Cadenassage; } }
        [IncludeInSearch]
        public bool Cadenassage_Simple { get { return Cadenassage_; } }
        [IncludeInSearch]
        public bool Espace { get { return Espace_; } }
        [IncludeInSearch]
        public bool Procedure { get { return Procedure_; } }
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