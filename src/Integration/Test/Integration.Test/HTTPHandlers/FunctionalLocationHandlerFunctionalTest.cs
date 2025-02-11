using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Integration.Handlers;
using Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures;
using Com.Suncor.Olt.Integration.HTTPHandlers.Utilities;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.HTTPHandlers
{
    [TestFixture]
    [Category("Integration")]
    public class FunctionalLocationHandlerFunctionalTest
    {
        [Test][Ignore]
        public void AddFixedFloc()
        {
            var msg = FunctionalLocationSAPFixture.GetAddEquipment2Floc("TEST").CreateMessage();

            var sender = new MessageSender();
            var response = sender.SyncSubmit(msg, Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void AddFloc()
        {
            var equipment2 = FunctionalLocationSAPFixture.CreateNewFlocEquipment2();
            var msg = FunctionalLocationSAPFixture.GetAddEquipment2Floc(equipment2).CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void ChangeFlocDescription()
        {
            var equipment2 = FunctionalLocationSAPFixture.CreateNewFlocEquipment2();
            var msg = FunctionalLocationSAPFixture.GetAddEquipment2Floc(equipment2).CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);

            msg = FunctionalLocationSAPFixture.GetChangeFlocDescription(equipment2);
            response = sender.SyncSubmit(msg, Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void DeleteFloc()
        {
            var equipment2 = FunctionalLocationSAPFixture.CreateNewFlocEquipment2();
            var msg = FunctionalLocationSAPFixture.GetAddEquipment2Floc(equipment2).CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);

            msg = FunctionalLocationSAPFixture.GetDeleteFloc(equipment2);
            response = sender.SyncSubmit(msg, Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void ShouldAddFunctionalLocationWithMoreThanFiveLevels()
        {
            var data = new FunctionalLocationSAPData("1400", "04PJ-111X", "EX1-P004-COMS-SIC", "who cares", "Add");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(data.CreateMessage(), Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
            var count =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    "SELECT COUNT(*) FROM FunctionalLocation where FullHierarchy = 'EX1-P004-COMS-SIC-04PJ-111X'");
            Assert.That(count, Is.EqualTo(1));
        }

        [Test][Ignore]
        public void ShouldAddMontrealFlocWithNonAnsiCharactersInDescription()
        {
            var flocDescription = "BATIMENT DE CONTRÔLE-KN1 ÇĈâďèéàáŌ";
            var data = new FunctionalLocationSAPData("1000", "04PJ-111X", string.Empty,
                flocDescription, "Add");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(data.CreateMessage(), Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
            var count =
                TestDataAccessUtil.ExecuteScalarExpression<int>(
                    "SELECT COUNT(*) FROM FunctionalLocation where Description= '" + flocDescription + "'");
            Assert.That(count, Is.GreaterThan(0));
        }

        [Test][Ignore]
        public void UpdateExistingFloc()
        {
            var equipment2 = FunctionalLocationSAPFixture.CreateNewFlocEquipment2();
            var flocId = "LEVEL3-LEVEL4-" + equipment2;
            var superiorFlocId = "LEVEL1-LEVEL2";
            var fullHierachyExpected = superiorFlocId + "-" + flocId;

            var functionalLocationSAPData = new FunctionalLocationSAPData("1000", flocId,
                superiorFlocId, "DESCRIPTION A",
                "Add");
            var sender = new MessageSender();
            var response = sender.SyncSubmit(functionalLocationSAPData.CreateMessage(), Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
            var expectedCount = TestDataAccessUtil.ExecuteScalarExpression<int>(
                string.Format(
                    "SELECT COUNT(*) FROM FunctionalLocation WHERE FullHierarchy = '{0}'", fullHierachyExpected));

            Assert.That(expectedCount, Is.EqualTo(1));

            functionalLocationSAPData.Description = "DESCRIPTION B";
            sender.SyncSubmit(functionalLocationSAPData.CreateMessage(), Constants.FLOC_URL);
            Assert.AreEqual("<OK/>", response);
            expectedCount = TestDataAccessUtil.ExecuteScalarExpression<int>(
                string.Format(
                    "SELECT COUNT(*) FROM FunctionalLocation WHERE FullHierarchy = '{0}'", fullHierachyExpected));

            Assert.That(expectedCount, Is.EqualTo(1));
        }
    }
}