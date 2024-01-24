using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDocumentSuggestionDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        DocumentSuggestion Insert(DocumentSuggestion form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        DocumentSuggestion QueryByIdAndSiteId(long id,long siteid);
        
        
        [CachedQueryById]
        DocumentSuggestion QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(DocumentSuggestion form);

        [CachedRemove(false, false)]
        void Remove(DocumentSuggestion form);
    }
}