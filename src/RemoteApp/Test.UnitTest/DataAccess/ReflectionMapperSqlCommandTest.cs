using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    /// <summary>
    /// Summary description for ReflectionMapperSqlCommandTest
    /// </summary>
    // TODO: (Troy) A lot can be added to this test...but then should we just start using NHibernate?
    [TestFixture]
    [Category("Database")]
    public class ReflectionMapperSqlCommandTest
    {
        private string connectionString;
        
        [SetUp]
        public void SetUp()
        {
            const string SQL_SERVER_KEY = "SqlServer";
            connectionString = ConfigurationManager.ConnectionStrings[SQL_SERVER_KEY].ConnectionString;
        }
        
        [Ignore] [Test]
        public void ShouldBeAbleToSetParametersOnASqlCommand()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertTagInfo";

                    TagInfo tagInfo = new TagInfo(-1, 1, "ShouldBeAbleToSetParametersOnASqlCommand",
                                                  "ReflectionMapper Test Method", "Do Not Use.", false,1);


                    new ReflectionMapper()
//                        .IgnoreObjectProperty("Items")
//                        .Map("Name", "FooName")
//                        .Map("Date", "FooDate")
                        .SetCommandParameters(tagInfo, command);

                    Assert.IsTrue(command.Parameters.Contains("Description"));
                    Assert.IsTrue(command.Parameters.Contains("SiteId"));
                    Assert.IsTrue(command.Parameters.Contains("Units"));
                    Assert.IsTrue(command.Parameters.Contains("Name"));
                    
                    Assert.AreEqual(tagInfo.Name, command.Parameters["Name"].Value);
                    Assert.AreEqual(tagInfo.Description, command.Parameters["Description"].Value);
                    Assert.AreEqual(tagInfo.Units, command.Parameters["Units"].Value);
                    Assert.AreEqual(tagInfo.SiteId, command.Parameters["SiteId"].Value);
                }
            }
        }

        [Ignore] [Test]
        public void ShouldBeAbleToSetTimeParametersOnASqlCommand()
        {
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                conn.Open();
//                using (SqlCommand command = conn.CreateCommand())
//                {
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.CommandText = "InsertFoo";
//
//                    FooWithTime foo = new FooWithTime("Bob", new Time(15, 02, 00));
//
//                    new ReflectionMapper()
//                        .IgnoreObjectProperty("Items")
//                        .Map("Name", "FooName")
//                        .Map("Time", "FooDate")
//                        .SetCommandParameters(foo, command);
//
//                    Assert.IsTrue(command.Parameters.Contains("FooDate"));
//                    Assert.AreEqual(foo.Time, new Time((DateTime)command.Parameters["FooDate"].Value));
//
//                    command.ExecuteNonQuery();
//                }
//            }
        }
    }

}
