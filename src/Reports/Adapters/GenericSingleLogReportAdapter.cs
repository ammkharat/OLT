using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class GenericSingleLogReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly List<DomainObjectChangeSet> changeSets;
        private readonly List<CustomFieldEntry> customFields;
        private readonly List<DocumentLink> documentLinks;
        private readonly DomainObject domainObject;
        private readonly List<FunctionalLocation> functionalLocations;
        private readonly List<ItemReadBy> itemReadBys;

        public GenericSingleLogReportAdapter(DomainObject domainObject, List<FunctionalLocation> functionalLocations,
            List<CustomFieldEntry> customFields, List<DocumentLink> documentLinks,
            List<DomainObjectChangeSet> changeSets, List<ItemReadBy> itemReadBys, string title, User lastModifiedByUser,
            DateTime logDateTime, string shift, WorkAssignment workAssignment, bool recommendForSummary,
            string commentsAsRtfText, string dorComments, bool environmentalHealthSafetyFollowUp,
            bool processControlFollowUp, bool operationsFollowUp, bool inspectionFollowUp, bool supervisionFollowUp,
            bool otherFollowUp, bool showRecommendedForSummary)
        {
            this.domainObject = domainObject;
            this.functionalLocations = functionalLocations ?? new List<FunctionalLocation>();
            this.customFields = customFields ?? new List<CustomFieldEntry>();
            this.documentLinks = documentLinks ?? new List<DocumentLink>();
            this.changeSets = changeSets ?? new List<DomainObjectChangeSet>();
            this.itemReadBys = itemReadBys ?? new List<ItemReadBy>();

            Label_Title = title;

            LastModifiedByName = lastModifiedByUser.FullNameWithUserName;
            LogDateTime = logDateTime.ToLongDateAndTimeString();
            Shift = shift;
            WorkAssignment = workAssignment != null
                ? workAssignment.Name
                : Common.Domain.WorkAssignment.NoneWorkAssignment.Name;
            RecommendForSummary = recommendForSummary;
            CommentsAsRtfText = commentsAsRtfText;
            DorComments = dorComments;
            EnvironmentalHealthSafetyFollowUp = environmentalHealthSafetyFollowUp;
            ProcessControlFollowUp = processControlFollowUp;
            OperationsFollowUp = operationsFollowUp;
            InspectionFollowUp = inspectionFollowUp;
            SupervisionFollowUp = supervisionFollowUp;
            OtherFollowUp = otherFollowUp;
            ShowRecommendedForSummary = showRecommendedForSummary;
            if (commentsAsRtfText.Split('\r').First().ToLower().Contains("action item"))
            {
                ActionItemResponseDetail = commentsAsRtfText.Split('\r').First() + " / Response Time : " + "" + LogDateTime;
            }
            else
            {
                ActionItemResponseDetail = "";
            }
            
            

        }

        public string LastModifiedByName { get; private set; }
        public string ActionItemResponseDetail { get; private set; }
        public string LogDateTime { get; private set; }
        public string Shift { get; private set; }
        public string WorkAssignment { get; private set; }
        public bool RecommendForSummary { get; private set; }
        public string CommentsAsRtfText { get; private set; }
        public string DorComments { get; private set; }
        public bool EnvironmentalHealthSafetyFollowUp { get; private set; }
        public bool ProcessControlFollowUp { get; private set; }
        public bool OperationsFollowUp { get; private set; }
        public bool InspectionFollowUp { get; private set; }
        public bool SupervisionFollowUp { get; private set; }
        public bool OtherFollowUp { get; private set; }
        

        public bool ShowRecommendedForSummary { get; private set; }

        public bool ShowDorComments
        {
            get { return !string.IsNullOrEmpty(DorComments); }
        }

        public bool ShowFollowup
        {
            get
            {
                return EnvironmentalHealthSafetyFollowUp ||
                       ProcessControlFollowUp ||
                       OperationsFollowUp ||
                       InspectionFollowUp ||
                       SupervisionFollowUp ||
                       OtherFollowUp;
            }
        }

        public bool ShowDocumentLinks
        {
            get { return documentLinks.Count > 0; }
        }

        public bool ShowCustomFields
        {
            get
            {
                return customFields != null &&
                       customFields.Count > 0 &&
                       customFields.Exists(obj => !string.IsNullOrEmpty(obj.FieldEntryForDisplay));
            }
        }

        public bool ShowMarkedAsReadBy
        {
            get { return itemReadBys.Count > 0; }
        }

        public IList<FunctionalLocationReportAdapter> GetFunctionalLocationsAdapters()
        {
            return functionalLocations.ConvertAll(
                floc => new FunctionalLocationReportAdapter(floc));
        }

        public IList<DocumentLinkReportAdapter> GetDocumentLinkAdapters()
        {
            return documentLinks.ConvertAll(
                link => new DocumentLinkReportAdapter(link.Url, link.Title));
        }

        public IList<CustomFieldsReportAdapter> GetCustomFieldAdapters()
        {
            return CustomFieldsReportAdapter.GetCustomFields(domainObject.IdValue, customFields);
        }

        public IList<DateTimeAndUserReportAdapter> GetLastModifiedByAdapters()
        {
            return changeSets.ConvertAll(
                changeSet => new DateTimeAndUserReportAdapter(changeSet.ChangeDateTime, changeSet.UserName));
        }

        public IList<DateTimeAndUserReportAdapter> GetMarkedAsReadByAdapters()
        {
            return itemReadBys.ConvertAll(
                itemReadBy => new DateTimeAndUserReportAdapter(itemReadBy.DateTime, itemReadBy.UserFullNameWithUserName));
        }

        //Mukesh for Log Image
        public List<LogImage> Images
        {
            get;
            set;
           
        }
        //RITM0455787:EN50 : OLT - Rename the header in Construction Mgmt site  for Reports
        public Site getSite
        { get; set; }

       
    }
}