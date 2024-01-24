using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TargetDefinitionSummaryPresenter
    {        
        private const string NEW_COMMENT_TEMPLATE = @"New Comments: {0}

Re: Target Definition Reference
{1}";

        private static readonly string DESCRIPTION_TEMPLATE = StringResources.TargetDefinitionSummaryDescriptionTemplate;

        private readonly ITargetSummaryView view;
        private readonly TargetDefinition targetDefinition;

        public TargetDefinitionSummaryPresenter(ITargetSummaryView view, TargetDefinition targetDefinition)
        {
            this.view = view;
            this.targetDefinition = targetDefinition;
            this.view.LoadView += LoadView;            
        }

        private void LoadView(object sender, EventArgs e)
        {
            view.SummaryLabel = StringResources.TargetDefinitionSummaryForm_SummaryLabel;
            view.NameLabel = StringResources.TargetDefinitionSummaryForm_NameLabel;
            view.TargetName = targetDefinition.Name;
            view.CategoryName = targetDefinition.Category.Name;
            view.Author = targetDefinition.LastModifiedBy.FullNameWithUserName;
            view.FunctionalLocationName = targetDefinition.FunctionalLocation.FullHierarchy;
            view.FunctionalLocationDescription = targetDefinition.FunctionalLocation.Description;
            view.Description = BuildDescription();

            view.MeasurementTagName = targetDefinition.TagInfo.Name;
            view.MeasurementTagUnits = targetDefinition.TagInfo.Units;

            view.NeverToExceedMaximum = targetDefinition.NeverToExceedMaximum;
            view.NeverToExceedMinimum = targetDefinition.NeverToExceedMinimum;
            view.MaxValue = targetDefinition.MaxValue;
            view.MinValue = targetDefinition.MinValue;
            view.TargetValue = targetDefinition.TargetValue.Title;
        }

        private string BuildDescription()
        {
            return string.Format(DESCRIPTION_TEMPLATE,
                targetDefinition.Name,
                targetDefinition.Category.Name,
                targetDefinition.LastModifiedBy.FullNameWithUserName,
                targetDefinition.FunctionalLocation.FullHierarchy,
                targetDefinition.TagInfo.Name,
                targetDefinition.NeverToExceedMaximum == null ? String.Empty : targetDefinition.NeverToExceedMaximum.Value.ToString(),
                targetDefinition.MaxValue == null ? String.Empty : targetDefinition.MaxValue.Value.ToString(),
                targetDefinition.MinValue == null ? String.Empty : targetDefinition.MinValue.Value.ToString(),
                targetDefinition.NeverToExceedMinimum == null ? String.Empty : targetDefinition.NeverToExceedMinimum.Value.ToString(),
                targetDefinition.TargetValue.Title,
                targetDefinition.GapUnitValue == null ? String.Empty : targetDefinition.GapUnitValue.ToString());
        }

        public string SummaryDescription(string newComments)
        {
            return string.Format(NEW_COMMENT_TEMPLATE, newComments, BuildDescription());
        }
    }
}
