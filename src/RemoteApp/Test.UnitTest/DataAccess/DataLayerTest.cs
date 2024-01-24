using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    [TestFixture]
    [Category("Database")]
    // TODO: (Troy) keep this, but use an existing object instead.
    public class DataLayerTest
    {
//        IFooDao dao;
//        
//        [TestFixtureSetUp]
//        public void SetUpFixture()
//        {
//            const string SQL_SERVER_KEY = "SqlServer";
//            string connectionString = ConfigurationManager.ConnectionStrings[SQL_SERVER_KEY].ConnectionString;
//            DaoRegistry.Clear();
//            DaoRegistry.RegisterDaoFor(typeof(Foo), new FooDao(connectionString));
//        }
//
//        [SetUp]
//        public void SetUp()
//        {
//            dao = DaoRegistry.GetDao<IFooDao>(typeof(Foo));
//        }
//
//        [Ignore] [Test]
//        public void QueryAllFoosFromDatabase()
//        {            
//            IList<Foo> fooList = dao.QueryAllFoo();
//            Assert.IsTrue(fooList.Count > 0);
//        }
//        
//        [Ignore] [Test]
//        public void QueryFooByIdShouldReturnAFoo()
//        {
//            Foo expectedFoo = new Foo(1, "Foo One", new DateTime(2005, 9, 20));
//            Foo foo = dao.QueryById(1);
//            Assert.AreEqual(expectedFoo.Id, foo.Id);
//            Assert.AreEqual(expectedFoo.Name, foo.Name);
//            Assert.AreEqual(expectedFoo.Date, foo.Date);
//            
//        }
//        
//        [Ignore] [Test]
//        public void InsertFooShouldSetTheIdToReflectAutoincrementedPrimaryKey()
//        {
//            Foo foo = new Foo();
//            foo.Name = "Yosh Schmenge";
//            foo.Date = Clock.Now;
//            Assert.IsNull(foo.Id);
//            dao.Insert(foo);
//            Assert.IsNotNull(foo.Id);
//        }
//        
//        [Ignore] [Test]
//        public void InsertFooWithValuesPopulatedShouldCorrectlyInsertFooIntoTheDatabase()
//        {
//            Foo foo = new Foo();
//            foo.Name = "Yosh Schmenge";
//            foo.Date = new DateTime(2005, 09, 20, 17, 55, 25);
//            dao.Insert(foo);
//            
//            Foo loadedFoo = dao.QueryById(foo.Id);
//            Assert.AreEqual(foo.Id,  loadedFoo.Id);
//            Assert.AreEqual(foo.Name, loadedFoo.Name);
//            Assert.AreEqual(foo.Date, loadedFoo.Date);
//        }
//        
//        [Ignore] [Test]
//        public void InsertFooWithNullValuesShouldSetValuesOfRecordFieldsToNull()
//        {
//            Foo foo = new Foo();
//            foo.Name = null;
//            foo.Date = null;
//            dao.Insert(foo);
//            
//            Foo loadedFoo = dao.QueryById(foo.Id);
//            Assert.IsNull(loadedFoo.Name);
//            Assert.IsNull(loadedFoo.Date);
//        }
    }
}
