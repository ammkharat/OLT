using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class DirectiveReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private readonly Directive directive;
        
       

        public DirectiveReportAdapter(Directive directive)
        {
           
            this.directive = directive;
            
        }
       
        public string ActiveFrom
        {
            get { return directive.ActiveFromDateTime.ToLongDateAndTimeString(); }
        }

        public string ActiveTo
        {
            get { return directive.ActiveToDateTime.ToLongDateAndTimeString(); }
        }

        public string Content
        {
            get { return directive.Content; }
        }

        public string CreatedBy
        {
            get { return directive.CreatedBy.FullNameWithUserName; }
        }

        public string LastModifiedBy
        {
            get { return directive.LastModifiedBy.FullNameWithUserName; }
        }

        public string CreationDateTime
        {
            get { return directive.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public string LastModifiedDateTime
        {
            get { return directive.CreatedDateTime.ToLongDateAndTimeString(); }
        }

        public override string Label_Title
        {
            get { return StringResources.ReportLabel_Title_Directive; }
            protected set { ; }
        }

        public override string Label_WorkAssignments
        {
            get { return StringResources.ReportLabel_SpecifiedWorkAssignments; }
        }

        public string Label_ActiveFrom
        {
            get { return StringResources.ReportLabel_ActiveFrom; }
        }

        public string Label_ActiveTo
        {
            get { return StringResources.ReportLabel_ActiveTo; }
        }

        public string Label_Details
        {
            get { return StringResources.ReportLabel_Details; }
        }

        public List<FunctionalLocationReportAdapter> FunctionalLocationReportAdapters
        {
            get { return directive.FunctionalLocations.ConvertAll(floc => new FunctionalLocationReportAdapter(floc)); }
        }

        public List<WorkAssignmentReportAdapter> WorkAssignmentReportAdapters
        {
            get
            {
                if (directive.WorkAssignments.Count == 0)
                {
                    return new List<WorkAssignmentReportAdapter>
                    {
                        new WorkAssignmentReportAdapter(WorkAssignment.NoneWorkAssignment)
                    };
                }

                return directive.WorkAssignments.ConvertAll(wa => new WorkAssignmentReportAdapter(wa));
            }
        }

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        public List<ImageUploader> Images
        {
            get;
            set;
        }
        public List<ItemReadBy> itemReadBy { get{return directive.itemReadBy;} }
    }
}