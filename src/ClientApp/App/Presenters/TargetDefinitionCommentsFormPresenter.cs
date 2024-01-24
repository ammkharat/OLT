using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TargetDefinitionCommentsFormPresenter : CommentsFormPresenter
    {
        public static readonly string FORM_TITLE = StringResources.TargetDefinitionCommentsFormTitle;

        private readonly TargetDefinition targetDefinition;
        private readonly ITargetDefinitionService service;
        private readonly TargetDefinitionSummaryPresenter summaryPresenter;
        private readonly TargetSummary summary;

        public TargetDefinitionCommentsFormPresenter(ICommentsFormView view, TargetDefinition targetDefinition) : this(
            view,
            targetDefinition,
            ClientServiceRegistry.Instance.GetService<ITargetDefinitionService>(),
            ClientServiceRegistry.Instance.GetService<ILogService>())
        {
        }

        public TargetDefinitionCommentsFormPresenter(
            ICommentsFormView view,
            TargetDefinition targetDefinition,
            ITargetDefinitionService service,
            ILogService logService)
            : base(view, targetDefinition, logService)
        {
            this.targetDefinition = targetDefinition;
            this.service = service;

            summary = new TargetSummary {Dock = DockStyle.Fill};
            summaryPresenter = new TargetDefinitionSummaryPresenter(summary, targetDefinition);
        }

        protected override string FormTitle
        {
            get { return FORM_TITLE; }
        }

        protected override Control CreateSummaryView()
        {
            return summary;
        }

        protected override List<FunctionalLocation> FindFunctionalLocations()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> {targetDefinition.FunctionalLocation};
            return flocs;
        }

        protected override DataSource DataSource
        {
            get { return DataSource.TARGET; }
        }

        protected override void Update()
        {
            // TODO v3: Troy: Why do we need to update the TargetDefinition via a comment about a Target Definition that isn't changed in this form.
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, targetDefinition, new TagChangedState());
        }

        protected override string SummaryDescription(string newComents)
        {
            return summaryPresenter.SummaryDescription(newComents);
        }
    }

}
