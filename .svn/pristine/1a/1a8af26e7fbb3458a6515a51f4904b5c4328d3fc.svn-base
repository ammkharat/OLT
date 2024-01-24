using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ActionItemMainReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly ActionItem actionItem;
        private readonly List<CustomFieldEntry> customFields;       //ayman action item email

        public ActionItemMainReportAdapter(ActionItem actionItem)
        {
            customFields = actionItem.CustomFieldEntries;           //ayman action item email
            this.actionItem = actionItem;
            this.customFields = customFields ?? new List<CustomFieldEntry>();          //ayman action item email

            Label_Title = StringResources.DomainObjectName_ActionItem;
        }

        public string Name
        {
            get { return actionItem.Name; }
        }

        //ayman action item email
        public string Comment
        {
            get { return actionItem.Comment; }
        }

        public string Priority
        {
            get { return actionItem.Priority.GetName(); }
        }

        public string Description
        {
            get { return actionItem.Description; }
        }

        public string LastResponseBy
        {
            get
            {
                return actionItem.StatusModification == null
                    ? null
                    : actionItem.StatusModification.ModifiedUser.FullNameWithUserName;
            }
        }

        public string LastResponseDateTime
        {
            get
            {
                return actionItem.StatusModification == null
                    ? null
                    : actionItem.StatusModification.ModifiedDateTime.ToLongDateAndTimeString();
            }
        }

        public string LastResponseStatus
        {
            get
            {
                return actionItem.StatusModification == null
                    ? null
                    : actionItem.StatusModification.PreviousStatus.GetName();
            }
        }

        public string Category
        {
            get { return actionItem.CategoryName; }
        }

        public string WorkAssignment
        {
            get { return actionItem.Assignment != null ? actionItem.Assignment.DisplayName : null; }
        }

        public string Status
        {
            get { return actionItem.Status.GetName(); }
        }

        public string StartDate
        {
            get { return actionItem.StartDateTime.ToDateString(); }
        }

        public string StartTime
        {
            get { return actionItem.StartDateTime.ToTimeString(); }
        }

        public string EndTime
        {
            get { return actionItem.EndDateTime.ToTimeString(); }
        }

        public List<FunctionalLocationReportAdapter> GetFunctionalLocationsAdapters()
        {
            return actionItem.FunctionalLocations.ConvertAll(floc => new FunctionalLocationReportAdapter(floc));
        }

        //ayman action item email
        public IList<CustomFieldsReportAdapter> GetCustomFieldAdapters()
        {
            return CustomFieldsReportAdapter.GetCustomFields(actionItem.IdValue, customFields);
        }

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        public List<ImageUploader> Images
        {
            get;
            set;
        }
    }
}