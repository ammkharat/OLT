using System;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ActionItemDefinitionSummaryPresenter
    {
        private const string NEW_COMMENT_TEMPLATE = @"New Comments: {0}

Re: Action Item Definition Reference
{1}";

        private const string DESCRIPTION_TEMPLATE = @"Action Item Definition Name: {0}
Category: {1}
Status: {2}
Schedule: {3}
Flocs: {4}
Last Modified By: {5}";

        readonly IActionItemDefinitionSummary view;
        readonly ActionItemDefinition actionItemDefinition;

        public ActionItemDefinitionSummaryPresenter(IActionItemDefinitionSummary view, ActionItemDefinition actionItemDefinition)
        {
            this.view = view;
            this.actionItemDefinition = actionItemDefinition;
            this.view.Load += HandleFormLoad;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.Name = actionItemDefinition.Name;
            view.Category = actionItemDefinition.Category;
            view.Author = actionItemDefinition.LastModifiedBy.FullNameWithUserName;
            view.FunctionalLocations = actionItemDefinition.FunctionalLocations;
            view.Description = BuildDescription();
        }

        private string BuildDescription()
        {
            return string.Format(DESCRIPTION_TEMPLATE, 
                actionItemDefinition.Name,
                actionItemDefinition.Category != null ? actionItemDefinition.Category.Name : null,
                actionItemDefinition.Status.Name,
                actionItemDefinition.Schedule.RecurrencePatternString,
                actionItemDefinition.FunctionalLocations.FullHierarchyListToString(false, false),
                actionItemDefinition.LastModifiedBy.FullNameWithUserName);
        }

        public string SummaryDescription(string newComments)
        {
            return string.Format(NEW_COMMENT_TEMPLATE, newComments, BuildDescription());
        }
    }
}
