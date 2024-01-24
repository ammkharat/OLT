using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class DocumentSuggestionHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly DocumentSuggestion form;

        public DocumentSuggestionHistoryFormPresenter(DocumentSuggestion form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_DocumentSuggestionForm; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_DocumentSuggestionForm; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForDocumentSuggestion(form.IdValue);
        }
    }
}