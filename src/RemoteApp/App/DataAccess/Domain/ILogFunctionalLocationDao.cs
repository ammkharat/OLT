using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogFunctionalLocationDao : IDao
    {
        void Insert(LogFunctionalLocation logFunctionalLocation);
    }
}
