using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOpmExcursionResponseDao : IDao
    {
        OpmExcursionResponse QueryById(long id);

        OpmExcursionResponse Insert(OpmExcursionResponse opmExcursionResponse);
        void Update(OpmExcursionResponse opmExcursionResponse);
        OpmExcursionResponse QueryByExcursionId(long excursionId);
    }
}