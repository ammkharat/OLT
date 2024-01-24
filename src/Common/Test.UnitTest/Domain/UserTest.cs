using System;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void FullNameEqualsLastNameCommaSpaceFirstName()
        {
            {
                string firstName = "Homer";
                string lastName = "Simpsons";
                string expectedFullName = lastName + ", " + firstName;

                User user = new User(null, firstName, lastName, null, "999", null, null, null, DateTimeFixture.DateTimeNow);
                Assert.AreEqual(expectedFullName, user.FullName);
            }

            {
                string firstName = null;
                string lastName = null;
                string expectedFullName = string.Empty;

                User user = new User(null, firstName, lastName, null, "999", null, null, null, DateTimeFixture.DateTimeNow);
                Assert.AreEqual(expectedFullName, user.FullName);
            }

            {
                string firstName = "Homer";
                string lastName = null;
                string expectedFullName = "Homer";

                User user = new User(null, firstName, lastName, null, "999", null, null, null, DateTimeFixture.DateTimeNow);
                Assert.AreEqual(expectedFullName, user.FullName);
            }

            {
                string firstName = null;
                string lastName = "Simpson";
                string expectedFullName = "Simpson";

                User user = new User(null, firstName, lastName, null, "999", null, null, null, DateTimeFixture.DateTimeNow);
                Assert.AreEqual(expectedFullName, user.FullName);
            }
        }

        [Test]
        public void ShouldNotHaveProblemsWithNullFirstOrLastName()
        {
            {
                User user = new User("UserName", null, null, null, "999", null, null, null, DateTimeFixture.DateTimeNow);

                Assert.AreEqual(string.Empty, user.FirstName);
                Assert.AreEqual(string.Empty, user.LastName);

                Assert.AreEqual("[UserName]", user.FullNameWithUserName);    
            }

            {
                User user = new User("UserName", "first", null, null, "999", null, null, null, DateTimeFixture.DateTimeNow);

                Assert.AreEqual("first", user.FirstName);
                Assert.AreEqual(string.Empty, user.LastName);

                Assert.AreEqual("first [UserName]", user.FullNameWithUserName);                
            }

            {
                User user = new User("UserName", null, "last", null, "999", null, null, null, DateTimeFixture.DateTimeNow);

                Assert.AreEqual(string.Empty, user.FirstName);
                Assert.AreEqual("last", user.LastName);

                Assert.AreEqual("last [UserName]", user.FullNameWithUserName);                
            }                       
        }

        [Test]
        public void ShouldGetFullNameRight()
        {
            User user = new User("UserName", "John", "Smith", null, "999", null, null, null, DateTimeFixture.DateTimeNow);

            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Smith", user.LastName);

            Assert.AreEqual("John Smith", User.ToFullName("John", "Smith", false));                
            Assert.AreEqual("Smith, John", User.ToFullName("John", "Smith", true));                
            Assert.AreEqual("Smith, John", User.ToFullName("John", "Smith"));                            
        }
    }
}
