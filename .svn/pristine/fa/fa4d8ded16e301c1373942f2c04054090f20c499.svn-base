using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class RestrictionReasonCodeServiceClientTest
    {
        private IRestrictionReasonCodeService reasonCodeService;

        [SetUp]
        public void SetUp()
        {
            reasonCodeService = GenericServiceRegistry.Instance.GetService<IRestrictionReasonCodeService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldQueryAll_AddListOfReasons_UpdateList_DeleteList()
        {
            var code1 = new RestrictionReasonCode("&&&$$$ 555 Fake Code 1", null, DateTimeFixture.DateTimeNow, 0);  //ayman restriction reason codes
            var code2 = new RestrictionReasonCode("&&&$$$ 555 Fake Code 2", null, DateTimeFixture.DateTimeNow, 0);   //ayman restriction reason codes
            var code3 = new RestrictionReasonCode("&&&$$$ 555 Fake Code 3", null, DateTimeFixture.DateTimeNow, 0);   //ayman restriction reason codes

            var reasonList = new List<RestrictionReasonCode> {code1, code2, code3};

            var restrictionReasonCodes = reasonCodeService.QueryAll(ClientSession.GetUserContext().SiteId);   //ayman restriction reason codes
            var totalCodeCount = restrictionReasonCodes.Count;

            reasonCodeService.AddReasonCodeList(reasonList, UserFixture.CreateUserWithGivenId(1),
                DateTimeFixture.DateTimeNow,0);

            restrictionReasonCodes = reasonCodeService.QueryAll(ClientSession.GetUserContext().SiteId);    //ayman restriction reason codes
            Assert.AreEqual(totalCodeCount + 3, restrictionReasonCodes.Count);

            // Update all 3
            var codeToUpdate1 = restrictionReasonCodes.Find(code => code.Name == "&&&$$$ 555 Fake Code 1");
            var newName1 = Guid.NewGuid().ToString();
            codeToUpdate1.Name = newName1;

            var codeToUpdate2 = restrictionReasonCodes.Find(code => code.Name == "&&&$$$ 555 Fake Code 2");
            var newName2 = Guid.NewGuid().ToString();
            codeToUpdate2.Name = newName2;

            var codeToUpdate3 = restrictionReasonCodes.Find(code => code.Name == "&&&$$$ 555 Fake Code 3");
            var newName3 = Guid.NewGuid().ToString();
            codeToUpdate3.Name = newName3;

            reasonList = new List<RestrictionReasonCode> {codeToUpdate1, codeToUpdate2, codeToUpdate3};

            reasonCodeService.UpdateReasonCodeList(reasonList, UserFixture.CreateUserWithGivenId(1),
                DateTimeFixture.DateTimeNow,0);

            restrictionReasonCodes = reasonCodeService.QueryAll(ClientSession.GetUserContext().SiteId);    //ayman restriction reason codes
            var newTotalCodeCount = restrictionReasonCodes.Count;
            Assert.AreEqual(totalCodeCount + 3, newTotalCodeCount);

            var updatedCode1 = restrictionReasonCodes.FindById(codeToUpdate1);
            Assert.AreEqual(newName1, updatedCode1.Name);
            var updatedCode2 = restrictionReasonCodes.FindById(codeToUpdate2);
            Assert.AreEqual(newName2, updatedCode2.Name);
            var updatedCode3 = restrictionReasonCodes.FindById(codeToUpdate3);
            Assert.AreEqual(newName3, updatedCode3.Name);
        }
    }
}