using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IBusinessCategoryFLOCAssociationDao : IDao
    {
        List<BusinessCategoryFLOCAssociation> QueryByFLOCId(long? flocId);
        BusinessCategoryFLOCAssociation Insert(BusinessCategoryFLOCAssociation association);        
        void DeleteAllByFLOCId(long functionalLocationId);
    }
}
