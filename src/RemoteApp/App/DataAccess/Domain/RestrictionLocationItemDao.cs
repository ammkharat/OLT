using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    internal class RestrictionLocationItemDao : AbstractManagedDao, IRestrictionLocationItemDao
    {
        private readonly IFunctionalLocationDao flocDao;
        private readonly IRestrictionLocationItemReasonCodeAssociationDao itemReasonCodeAssociationDao;

        public RestrictionLocationItemDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            itemReasonCodeAssociationDao = DaoRegistry.GetDao<IRestrictionLocationItemReasonCodeAssociationDao>();
        }

        public void Insert(long restrictionLocationId, RestrictionLocationItem item)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RestrictionLocationId", restrictionLocationId);
            command.Insert(item, AddParameters, "InsertRestrictionLocationItem");

            InsertReasonCodeAssociations(item);
        }

        private void InsertReasonCodeAssociations(RestrictionLocationItem item)
        {
            if (item.ReasonCodes.IsEmpty())
                return;
            foreach (RestrictionLocationItemReasonCodeAssociation itemReasonCode in item.ReasonCodes)
            {
                itemReasonCodeAssociationDao.InsertReasonCodeAssociations(item.IdValue, itemReasonCode);
            }
        }

        private static void AddParameters(RestrictionLocationItem item, SqlCommand command)
        {
            command.AddParameter("@Id", item.IdValue);
            command.AddParameter("@Name", item.Name);
            if (item.ParentItemId.HasValue)
            {
                command.AddParameter("@ParentItemId", item.ParentItemId.Value);
            }
            if (item.FunctionalLocation != null)
            {
                command.AddParameter("@FunctionalLocationId", item.FunctionalLocation.IdValue);
            }
        }

        public List<RestrictionLocationItem> QueryByRestrictionLocation(long restrictionLocationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RestrictionLocationId", restrictionLocationId);
            return command.QueryForListResult<RestrictionLocationItem>(PopulateInstance, "QueryRestrictionItemByRestrictionLocationId");
        }

        public void Update(RestrictionLocationItem item)
        {
            SqlCommand command = ManagedCommand;
            command.Update(item, AddParameters, "UpdateRestrictionLocationItem");

            UpdateReasonCodeAssociations(item, command);
        }

        private void UpdateReasonCodeAssociations(RestrictionLocationItem item, SqlCommand command)
        {
            command.CommandText = "DeleteRestrictionLocationItemReasonCodesByItemId";
            command.Parameters.Clear();
            command.AddParameter("@RestrictionLocationItemId", item.IdValue);
            command.ExecuteNonQuery();

            InsertReasonCodeAssociations(item);
        }

        public RestrictionLocationItem QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<RestrictionLocationItem>(id, PopulateInstance, "QueryRestrictionLocationItemById");
        }

        public void Remove(long itemId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", itemId);
            command.ExecuteNonQuery("RemoveRestrictionLocationItem");
        }

        private RestrictionLocationItem PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            long? functionalLocationId = reader.Get<long?>("FunctionalLocationId");
            long? parentItemId = reader.Get<long?>("ParentItemId");

            FunctionalLocation functionalLocation = functionalLocationId.HasValue ? flocDao.QueryById(functionalLocationId.Value) : null;

            List<RestrictionLocationItemReasonCodeAssociation> reasonCodes = itemReasonCodeAssociationDao.QueryByRestrictionLocationItem(id);

            return new RestrictionLocationItem(id, name, functionalLocation, parentItemId, reasonCodes);
        }
    }
}