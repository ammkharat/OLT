using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ActionItemDefinitionCommentsFormPresenter : CommentsFormPresenter
    {
        private readonly ActionItemDefinition actionItemDefinition;
        private readonly IActionItemDefinitionService service;
        private readonly ActionItemDefinitionSummaryPresenter summaryPresenter;
        private readonly ActionItemDefinitionSummary summary;

        public ActionItemDefinitionCommentsFormPresenter(ICommentsFormView view, ActionItemDefinition actionItemDefinition) : this(
            view, 
            actionItemDefinition,
            ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>(), 
            ClientServiceRegistry.Instance.GetService<ILogService>())
        {
        }

        public ActionItemDefinitionCommentsFormPresenter(
            ICommentsFormView view,
            ActionItemDefinition actionItemDefinition,
            IActionItemDefinitionService service,
            ILogService logService)
            : base(
            view, 
            actionItemDefinition,
            logService)
        {
            this.actionItemDefinition = actionItemDefinition;
            this.service = service;

            summary = new ActionItemDefinitionSummary();
            summaryPresenter = new ActionItemDefinitionSummaryPresenter(summary, actionItemDefinition);
        }

        protected override string FormTitle
        {
            get { return StringResources.ActionItemDefinitionCommentsFormTitle; }
        }

        protected override Control CreateSummaryView()
        {
            return summary;
        }

        protected override List<FunctionalLocation> FindFunctionalLocations()
        {
            return actionItemDefinition.FunctionalLocations;
        }

        protected override DataSource DataSource
        {
            get { return DataSource.ACTION_ITEM; }
        }

        protected override void Update()
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, actionItemDefinition);
        }

        protected override string SummaryDescription(string newComents)
        {
            return summaryPresenter.SummaryDescription(newComents);   
        }

        protected override void InsertLog(Log log)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(logService.InsertActionItemDefinition, log, actionItemDefinition);
        }
    }
}
