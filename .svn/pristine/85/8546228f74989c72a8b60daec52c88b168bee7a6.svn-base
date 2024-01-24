using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RestrictionLocationItemReasonCodeAssociationDao : AbstractManagedDao, IRestrictionLocationItemReasonCodeAssociationDao
    {
        private readonly IRestrictionReasonCodeDao restrictionReasonCodeDao;

        public RestrictionLocationItemReasonCodeAssociationDao()
        {
            restrictionReasonCodeDao = DaoRegistry.GetDao<IRestrictionReasonCodeDao>();
        }

        public List<RestrictionLocationItemReasonCodeAssociation> QueryByRestrictionLocationItem(long restrictionLocationItemId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RestrictionLocationItemId", restrictionLocationItemId);
            return command.QueryForListResult<RestrictionLocationItemReasonCodeAssociation>(PopulateInstance, "QueryRestrictionReasonCodeByRestrictionLocationItemId");
        }

        private RestrictionLocationItemReasonCodeAssociation PopulateInstance(SqlDataReader reader)
        {
            long reasonCodeId = reader.Get<long>("ReasonCodeId");
            RestrictionReasonCode restrictionReasonCode = restrictionReasonCodeDao.QueryById(reasonCodeId);
            
            int? limit = reader.Get<int?>("Limit");
            
            return new RestrictionLocationItemReasonCodeAssociation(restrictionReasonCode, limit);
        }

        public void InsertReasonCodeAssociations(long restrictionLocationItemId, RestrictionLocationItemReasonCodeAssociation itemReasonCodeAssociation)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@RestrictionLocationItemId", restrictionLocationItemId);
            command.AddParameter("@RestrictionReasonCodeId", itemReasonCodeAssociation.RestrictionReasonCodeId);
            command.AddParameter("@Limit", itemReasonCodeAssociation.Limit);
            command.Insert("InsertRestrictionLocationItemReasonCodeAssociation");
        }
    }
}