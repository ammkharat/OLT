using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class UserGridLayoutDao : AbstractManagedDao, IUserGridLayoutDao
    {
        private const string SAVE_STORED_PROCEDURE = "InsertUserGridLayout";
        private const string QUERY_STORED_PROCEDURE = "QueryUserGridLayout";
        private const string DELETE_STORED_PROCEDURE = "DeleteUserGridLayout";
        private const string DELETE_ALL_FOR_USER_STORED_PROCEDURE = "DeleteAllUserGridLayoutsByUserId";

        public void SaveGridLayout(long userId, UserGridLayoutIdentifier identifier, string xml)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@UserId", userId);
            command.AddParameter("@GridId", identifier.IdValue);
            command.AddParameter("@GridLayoutXml", xml);

            command.Insert(SAVE_STORED_PROCEDURE);                                         
        }
        
        public string GetGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@GridId", userGridLayoutIdentifier.IdValue);
            GridLayoutInfo info = command.QueryForSingleResult<GridLayoutInfo>(PopulateInstance , QUERY_STORED_PROCEDURE);      
            return info != null ? info.Xml : null;
        }

        public void DeleteGridLayout(long userId, UserGridLayoutIdentifier userGridLayoutIdentifier)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@GridId", userGridLayoutIdentifier.IdValue);
            command.ExecuteNonQuery(DELETE_STORED_PROCEDURE);            
        }

        public void DeleteAllGridLayoutsForUser(long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);            
            command.ExecuteNonQuery(DELETE_ALL_FOR_USER_STORED_PROCEDURE);                        
        }

        private GridLayoutInfo PopulateInstance(SqlDataReader reader)
        {
            if(!reader.HasRows)
            {
                return null;
            }

            string xml = reader.Get<string>("GridLayoutXml");
            return new GridLayoutInfo(xml);
        }

        private class GridLayoutInfo
        {
            public GridLayoutInfo(string xml)
            {
                Xml = xml;
            }

            public string Xml { get; private set; }
        }
    }
}
