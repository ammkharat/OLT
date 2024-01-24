using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class TemporaryInstallationsMUDSHistoryPresenter : EditHistoryFormPresenter
    {
        private readonly TemporaryInstallationsMUDS form;

        public TemporaryInstallationsMUDSHistoryPresenter(TemporaryInstallationsMUDS form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormMudsTemporaryInstallations; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_FormMudsTemporaryInstallations;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormTemporaryInstallations(form.IdValue);
        }
    }
}
