using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Excursions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OpmToeDefinitionCommentDao : AbstractManagedDao, IOpmToeDefinitionCommentDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryOpmToeDefinitionCommentById";

        private const string QUERY_BY_OLT_TOE_DEFINITION_ID_STORED_PROCEDURE =
            "QueryOpmToeDefinitionCommentByOltToeDefinitionId";

        private const string INSERT_STORED_PROCEDURE = "InsertOpmToeDefinitionComment";
        private const string UPDATE_STORED_PROCEDURE = "UpdateOpmToeDefinitionComment";
        private readonly IUserDao userDao;


        public OpmToeDefinitionCommentDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public OpmToeDefinitionComment QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public OpmToeDefinitionComment Insert(OpmToeDefinitionComment opmToeDefinitionComment)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(opmToeDefinitionComment, AddInsertParameters, INSERT_STORED_PROCEDURE);
            opmToeDefinitionComment.Id = (long?) idParameter.Value;
            return opmToeDefinitionComment;
        }

        public void Update(OpmToeDefinitionComment opmToeDefinitionComment)
        {
            var command = ManagedCommand;
            command.Update(opmToeDefinitionComment, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        public OpmToeDefinitionComment QueryByOltToeDefinitionId(long oltToeDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@OltToeDefinitionId", oltToeDefinitionId);
            return command.QueryForSingleResult(PopulateInstance, QUERY_BY_OLT_TOE_DEFINITION_ID_STORED_PROCEDURE);
        }


        private OpmToeDefinitionComment PopulateInstance(SqlDataReader reader)
        {
            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));

            var excursion = new OpmToeDefinitionComment(
                reader.Get<long>("Id"),
                reader.Get<long>("ToeVersion"),
                reader.Get<string>("ToeName"),
                reader.Get<string>("HistorianTag"),
                lastModifiedBy,
                reader.Get<string>("Comment"),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.Get<long>("OltToeDefinitionId"));
            return excursion;
        }


        private static void AddInsertParameters(OpmToeDefinitionComment comment, SqlCommand command)
        {
            command.AddParameter("@ToeVersion", comment.ToeVersion);
            command.AddParameter("@HistorianTag", comment.HistorianTag);
            command.AddParameter("@ToeName", comment.ToeName);
            command.AddParameter("@OltToeDefinitionId", comment.OltToeDefinitionId);
            SetInsertUpdateAttributes(comment, command);
        }


        private static void AddUpdateParameters(OpmToeDefinitionComment excursion, SqlCommand command)
        {
            command.AddParameter("@Id", excursion.Id);
            SetInsertUpdateAttributes(excursion, command);
        }

        private static void SetInsertUpdateAttributes(OpmToeDefinitionComment excursion, SqlCommand command)
        {
            command.AddParameter("@LastModifiedByUserId", excursion.LastModifiedBy.IdValue);
            command.AddParameter("@Comment", excursion.Comment);
            command.AddParameter("@LastModifiedDateTime", excursion.LastModifiedDateTime);
        }
    }
}