namespace Com.Suncor.Olt.Common.Utility.Cache
{
    public interface IExpiringCache
    {
        object this[object key] { get; set; }
    }
}