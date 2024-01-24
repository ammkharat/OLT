using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class EmailAddressTest
    {
        [Test]
        public void ShouldValidateEmail()
        {
            string email1 = "dustin@diet-coke.com";
            string email2 = "troy@chocolatemilk.co.uk";
            string email3 = "tommy@rum.and.coke.com";

            string badEmail1 = "jeremy++++++.ca123";
            string badEmail2 = "kent@@babyland";

            Assert.IsTrue(EmailAddress.IsValid(email1));
            Assert.IsTrue(EmailAddress.IsValid(email2));
            Assert.IsTrue(EmailAddress.IsValid(email3));

            Assert.IsFalse(EmailAddress.IsValid(badEmail1));
            Assert.IsFalse(EmailAddress.IsValid(badEmail2));            
        }

        [Test]
        public void ShouldValidateDelimitedList()
        {
            string email1 = "dustin@diet-coke.com";
            string email2 = "troy@chocolatemilk.co.uk";
            string email3 = "tommy@rum.and.coke.com";

            string badEmail1 = "jeremy++++++.ca123";
            string badEmail2 = "kent@@babyland";

            List<string> niceList = new List<string> { email1, email2, email3 };
            List<string> naughtyList = new List<string> { badEmail1, badEmail2 };

            string niceDelimitedString = niceList.ToDelimitedString(';');
            string naughtyDelimitedString = naughtyList.ToDelimitedString(';');

            Assert.IsTrue(EmailAddress.IsValid(niceDelimitedString));
            Assert.IsFalse(EmailAddress.IsValid(naughtyDelimitedString));
        }

        [Test]
        public void ShouldConvertDelimitedStringIntoEmailAddresses()
        {            
            string delimitedList = "spot@puppydog.ca;whiskers@kittycat.org;jaws@killershark.co.uk";
            List<EmailAddress> result = EmailAddress.ConvertDelimitedListToEmailAddresses(delimitedList);
            AssertResultContainsAddresses(result);                       
        }

        [Test]
        public void ShouldConvertListToDelimitedString()
        {
            Assert.AreEqual("spot@puppydog.ca;whiskers@kittycat.org;jaws@killershark.co.uk", EmailAddress.ConvertToDelimitedString(new List<EmailAddress> { new EmailAddress("spot@puppydog.ca"), new EmailAddress("whiskers@kittycat.org"), new EmailAddress("jaws@killershark.co.uk") }));            
        }

        [Test]
        public void ShouldRemoveWhitespaceFromEmailAddresses()
        {
            EmailAddress a1 = new EmailAddress("   dustin@diet-coke.com    ");
            EmailAddress a2 = new EmailAddress("troy@chocolatemilk.co.uk");
            EmailAddress a3 = new EmailAddress("    tommy@rum.and.coke.com");
            EmailAddress a4 = new EmailAddress("kent@proteinpowdermix.ca   ");

            Assert.AreEqual("dustin@diet-coke.com", a1.ToString());
            Assert.AreEqual("troy@chocolatemilk.co.uk", a2.ToString());
            Assert.AreEqual("tommy@rum.and.coke.com", a3.ToString());
            Assert.AreEqual("kent@proteinpowdermix.ca", a4.ToString());            
        }

        private void AssertResultContainsAddresses(List<EmailAddress> resultList)
        {
            Assert.IsTrue(resultList.Exists(e => "spot@puppydog.ca".Equals(e.ToString())));
            Assert.IsTrue(resultList.Exists(e => "whiskers@kittycat.org".Equals(e.ToString())));
            Assert.IsTrue(resultList.Exists(e => "jaws@killershark.co.uk".Equals(e.ToString())));
            Assert.IsTrue(resultList.Count == 3);
        }      
    }
}
