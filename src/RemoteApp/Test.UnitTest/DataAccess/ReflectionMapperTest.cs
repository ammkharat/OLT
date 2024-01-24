using System;
using System.Collections.Generic;
using System.Data;
using Com.Suncor.Olt.Common.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    [TestFixture]
    public class ReflectionMapperTest
    {
        Mockery mocks;
        IDataReader mockReader;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockReader = mocks.NewMock<IDataReader>();
            Stub.On(mockReader).Method("GetSchemaTable");
        }

        [Ignore] [Test]
        public void ReflectionMapperShouldPopulateADomainObjectFromMatchingDataReaderFields()
        {
            Expect.Once.On(mockReader).Get["Name"].Will(Return.Value("Foo"));
            Expect.Once.On(mockReader).Get["Id"].Will(Return.Value((long?)1));
            Expect.Once.On(mockReader).Get["Date"].Will(Return.Value(new DateTime(2000, 1, 1)));
            Expect.Once.On(mockReader).Get["Items"].Will(Return.Value(DBNull.Value));
            
            var foo = new Foo();
            new ReflectionMapper().Populate(mockReader, foo);

            Assert.AreEqual("Foo", foo.Name);
            Assert.AreEqual((long)1, foo.Id);
            Assert.AreEqual(new DateTime(2000, 1, 1), foo.Date);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ReflectionMapperShouldHandleDbNullToNullValueConversionsCorrectly()
        {
            Expect.Once.On(mockReader).Get["Name"].Will(Return.Value(DBNull.Value));
            Expect.Once.On(mockReader).Get["Id"].Will(Return.Value(DBNull.Value));
            Expect.Once.On(mockReader).Get["Date"].Will(Return.Value(DBNull.Value));
            Expect.Once.On(mockReader).Get["Items"].Will(Return.Value(DBNull.Value));
            
            var foo = new Foo();
            new ReflectionMapper().Populate(mockReader, foo);

            Assert.IsNull(foo.Name);
            Assert.IsNull(foo.Id);
            Assert.IsNull(foo.Date);
            Assert.IsNull(foo.Items);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldBeAbleToTellTheReflectionMapperToIgnoreCertainFieldNames()
        {
            Expect.Once.On(mockReader).Get["Id"].Will(Return.Value((long?)1));
            Expect.Once.On(mockReader).Get["Date"].Will(Return.Value(new DateTime(2000, 1, 1)));

            var foo = new Foo();
            new ReflectionMapper().IgnoreObjectProperty("Name").IgnoreObjectProperty("Items").Populate(mockReader, foo);

            mocks.VerifyAllExpectationsHaveBeenMet();

            Assert.IsNull(foo.Name);
            Assert.IsNull(foo.Items);
            Assert.AreEqual((long)1, foo.Id);
            Assert.AreEqual(new DateTime(2000, 1, 1), foo.Date);
        }
        
        [Ignore] [Test]
        public void ShouldBeAbleToMapObjectToDatabaseFieldNames()
        {
            Expect.Once.On(mockReader).Get["FullName"].Will(Return.Value("full name"));

            var foo = new Foo();
            new ReflectionMapper()
                .IgnoreObjectProperty("Id")
                .IgnoreObjectProperty("Date")
                .IgnoreObjectProperty("Items")
                .Map("Name", "FullName")
                .Populate(mockReader, foo);

            mocks.VerifyAllExpectationsHaveBeenMet();

            Assert.AreEqual("full name", foo.Name);
        }
        
        [Test, ExpectedException(typeof(ApplicationException))]
        public void ShouldThrowExceptionIfObjectPropertyDoesNotMapToADatabaseField()
        {
            Expect.Once.On(mockReader).Get["Name"].Will(Throw.Exception(new IndexOutOfRangeException()));
            Expect.Once.On(mockReader).Get["Id"].Will(Return.Value((long?)1));
            Expect.Once.On(mockReader).Get["Date"].Will(Return.Value(new DateTime(2000, 1, 1)));
            Expect.Once.On(mockReader).Get["Items"].Will(Return.Value(DBNull.Value));
            
            var foo = new Foo();
            new ReflectionMapper().Populate(mockReader, foo);
        }


        [Ignore] [Test]
        public void ShouldBeAbleToPopulateATimeField()
        {
            Expect.Once.On(mockReader).Get["StartTime"].Will(Return.Value(new Time(13, 45, 59).ToDateTime()));

            var foo = new FooWithTime();
            new ReflectionMapper().Populate(mockReader, foo);

            Assert.AreEqual(new Time(13, 45, 59), foo.StartTime);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldBeAbleToPopulateAutomaticProperties()
        {
            Expect.Once.On(mockReader).Get["FirstName"].Will(Return.Value("Troy"));
            var foo = new TestObject();
            new ReflectionMapper().Populate(mockReader, foo);
            Assert.AreEqual("Troy", foo.FirstName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        class TestObject
        {
            public string FirstName { get; set; }
        }
        class FooItem
        {
            public int Id { get; set; }

            public string Description { get; set; }
        }

        class Foo : DomainObject
        {
            public Foo()
            {
            }

            public Foo(long? id, string name, DateTime? date)
            {
                this.id = id;
                this.Name = name;
                this.Date = date;
            }

            public new long? Id
            {
                get { return id; }
                set { id = value; }
            }

            public string Name { get; set; }

            public DateTime? Date { get; set; }


            public IList<FooItem> Items { get; set; }
        }

        class FooWithTime
        {
            private Time startTime;

            public FooWithTime()
            {
            }

            public FooWithTime(Time startTime)
            {
                this.startTime = startTime;
            }

            public Time StartTime
            {
                get { return startTime; }
                set { startTime = value; }
            }
        }

    }
    
}