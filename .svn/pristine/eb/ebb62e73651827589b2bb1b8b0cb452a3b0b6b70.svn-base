using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class OpmToeDefinitionCommentHistoryPresenter : EditHistoryFormPresenter
    {
        private readonly OpmToeDefinition toeDefinition;

        public OpmToeDefinitionCommentHistoryPresenter(OpmToeDefinition toeDefinition)
            : base(toeDefinition)
        {
            this.toeDefinition = toeDefinition;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_OpmToeDefinitionComment; }
        }

        protected override string DomainObjectName
        {
            get { return toeDefinition.ToeName; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForOpmToeDefinitionComment(toeDefinition.ToeName);
        }
    }
}