using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IUserGridLayoutDao : IDao
    {
        void SaveGridLayout(long userId, UserGridLayoutIdentifier identifier, string xml);
        string GetGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier);
        void DeleteGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier);
        void DeleteAllGridLayoutsForUser(long userId);
    }
}
