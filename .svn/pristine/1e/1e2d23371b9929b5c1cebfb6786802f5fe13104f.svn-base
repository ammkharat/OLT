using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOpmToeDefinitionDao : IDao
    {
        OpmToeDefinition QueryById(long id);

        OpmToeDefinition Insert(OpmToeDefinition opmToeDefinition);
        void Update(OpmToeDefinition opmToeDefinition);
        OpmToeDefinition QueryByTagAndVersion(string historianTag, long toeVersion);
    }
}