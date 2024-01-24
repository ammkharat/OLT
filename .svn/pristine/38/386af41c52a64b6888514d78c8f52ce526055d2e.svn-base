using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class BusinessCategoryFLOCAssociationDao : AbstractManagedDao, IBusinessCategoryFLOCAssociationDao
    {
        private const string QUERY_BY_FLOC_ID_STORED_PROCEDURE = "QueryBusinessCategoryFLOCAssociationsByFLOCId";
        private const string INSERT_STORED_PROCEDURE = "InsertBusinessCategoryFLOCAssociation";        
        private const string DELETE_BY_FLOC_ID_STORED_PROCEDURE = "DeleteBusinessCategoryFLOCAssociationsByFLOCId";

        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IBusinessCategoryDao businessCategoryDao;

        public BusinessCategoryFLOCAssociationDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();
        }

        public List<BusinessCategoryFLOCAssociation> QueryByFLOCId(long? flocId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FunctionalLocationId", flocId);
            return command.QueryForListResult<BusinessCategoryFLOCAssociation>(PopulateInstance, QUERY_BY_FLOC_ID_STORED_PROCEDURE);
        }

        public BusinessCategoryFLOCAssociation Insert(BusinessCategoryFLOCAssociation association)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(association, AddInsertParameters, INSERT_STORED_PROCEDURE);
            association.Id = long.Parse(idParameter.Value.ToString());
            return association;
        }

        public void DeleteAllByFLOCId(long functionalLocationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FunctionalLocationId", functionalLocationId);
            command.ExecuteNonQuery(DELETE_BY_FLOC_ID_STORED_PROCEDURE); 
        }

        private BusinessCategoryFLOCAssociation PopulateInstance(SqlDataReader reader)
        {
            long newId = reader.Get<long>("Id");

            FunctionalLocation functionalLocation =
                functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));

            BusinessCategory businessCategory =
                businessCategoryDao.QueryById(reader.Get<long>("BusinessCategoryId"));
            
            User user = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            
            BusinessCategoryFLOCAssociation association = 
                new BusinessCategoryFLOCAssociation(functionalLocation, businessCategory, user, lastModifiedDate) {Id = newId};

            return association;
        }

        private static void AddInsertParameters(BusinessCategoryFLOCAssociation association, SqlCommand command)
        {
            command.AddParameter("@FunctionalLocationId", association.FunctionalLocation.Id);
            command.AddParameter("@BusinessCategoryId", association.BusinessCategory.Id);
            command.AddParameter("@LastModifiedUserId", association.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", association.LastModifiedDate);
        }
    }
}
