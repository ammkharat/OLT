namespace Com.Suncor.Olt.Remote.Caching
{
    public interface ICache
    {
        void Remove(string cachingKey);
        void Update(string cachingKey, object objectToAddOrUpdate);
        object Get(string cachingKey);
        void AppendToExistingItem(string key, string cachingKeyItemUsingParent);
    }
}