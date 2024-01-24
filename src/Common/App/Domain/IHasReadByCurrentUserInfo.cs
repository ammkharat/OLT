namespace Com.Suncor.Olt.Common.Domain
{
    public interface IHasReadByCurrentUserInfo
    {
        bool? IsReadByCurrentUser { get; }
    }
}