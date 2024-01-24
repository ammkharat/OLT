using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditDirectiveHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly Directive directive;

        public EditDirectiveHistoryFormPresenter(Directive directive) : base(directive)
        {
            this.directive = directive;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_Directive; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.NotApplicable; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForDirective(directive.IdValue);
        }
    }
}
