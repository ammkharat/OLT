using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Integration.Handlers.Validators
{
    [TestFixture]
    public class FlocValidatorTest
    {
        public const string VALID_ACTION = "Add";

        private ILog logger;
        private FLOCValidator validator;

        [SetUp]
        public void SetUp()
        {
            logger = MockRepository.GenerateStub<ILog>();
            validator = new FLOCValidator(logger);
        }

        [Test]
        public void ShouldAllowMaxLengthFlocWithSuperiorFlocId()
        {
            var fullHierarchy = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH);
            var superiorFloc = fullHierarchy.Substring(0, 10);
            var flocId = fullHierarchy.Substring(9 + 1);
                //add one for the - that gets added between superiorfloc and floc

            var floc = new FunctionalLocationDetails
            {
                Action = VALID_ACTION,
                PlantId = CreateString(Constants.PLANT_ID_MAX_LENGTH),
                FullHierarchy = flocId,
                SuperiorFullHierarchy = superiorFloc,
                OldFLOC = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH),
            };

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldAllowSevenLevelsWithNoSuperiorFloc()
        {
            var floc = new FunctionalLocationDetails
            {
                Action = VALID_ACTION,
                PlantId = CreateString(Constants.PLANT_ID_MAX_LENGTH),
                FullHierarchy = "LEVEL1-LEVEL2-LEVEL3-LEVEL4-LEVEL5-LEVEL6-LEVEL7",
                SuperiorFullHierarchy = string.Empty,
                OldFLOC = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH),
            };

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldAllowSevenLevelsWithSuperiorFloc()
        {
            var floc = new FunctionalLocationDetails
            {
                Action = VALID_ACTION,
                PlantId = CreateString(Constants.PLANT_ID_MAX_LENGTH),
                FullHierarchy = "LEVEL4-LEVEL5-LEVEL6-LEVEL7",
                SuperiorFullHierarchy = "LEVEL1-LEVEL2-LEVEL3",
                OldFLOC = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH),
            };

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldNotAllowOverMaxLengthFlocWithSuperiorFlocId()
        {
            var fullHierarchy = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH);
            var superiorFloc = fullHierarchy.Substring(0, 20);
            var flocId = fullHierarchy.Substring(9);

            var floc = new FunctionalLocationDetails
            {
                Action = VALID_ACTION,
                PlantId = CreateString(Constants.PLANT_ID_MAX_LENGTH),
                FullHierarchy = flocId,
                SuperiorFullHierarchy = superiorFloc,
                OldFLOC = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH),
            };

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldParseFLOCDetailsFromXML()
        {
            const string testXml = @"<FLOCOLTData>
                  <FLOCRecord>
                      <FLOCDetails>
                          <PlantID>pid</PlantID>
                          <FLOCID>flocid</FLOCID>
                          <SuperiorFLOCID></SuperiorFLOCID>
                          <Description>some description</Description>
                          <Action>action</Action>
                          <OldFLOC>old floc</OldFLOC>
                      </FLOCDetails>
                  </FLOCRecord>
              </FLOCOLTData>";

            using (var memoryStream = testXml.CreateMemoryStream())
            {
                var functionalLocationXmlMessage = validator.Parse(memoryStream);
                var functionalLocationDetails =
                    functionalLocationXmlMessage.FunctionalLocationXmlRecord.FunctionalLocationDetails;

                Assert.AreEqual(1, functionalLocationDetails.Length);
                Assert.AreEqual("pid", functionalLocationDetails[0].PlantId);
                Assert.AreEqual("flocid", functionalLocationDetails[0].FullHierarchy);
                Assert.AreEqual("some description", functionalLocationDetails[0].Description);
                Assert.AreEqual("action", functionalLocationDetails[0].Action);
                Assert.AreEqual("old floc", functionalLocationDetails[0].OldFLOC);
            }
        }

        [Test]
        public void ShouldReturnFalseWithInvalidAction()
        {
            var floc = new FunctionalLocationDetails {Action = String.Empty};

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.Action = null;
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.Action = "WALK";
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.Action = "TALK";
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidFlocId()
        {
            var floc = new FunctionalLocationDetails
            {
                Action = VALID_ACTION,
                PlantId = CreateString(Constants.PLANT_ID_MAX_LENGTH),
                FullHierarchy = String.Empty
            };

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.FullHierarchy = null;
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.FullHierarchy = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH + 1);
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidOldFloc()
        {
            var floc = new FunctionalLocationDetails
            {
                Action = VALID_ACTION,
                PlantId = CreateString(Constants.PLANT_ID_MAX_LENGTH),
                FullHierarchy = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH + 1),
                OldFLOC = String.Empty
            };

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.OldFLOC = null;
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.OldFLOC = CreateString(Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH + 1);
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidPlantId()
        {
            var floc = new FunctionalLocationDetails {Action = VALID_ACTION, PlantId = String.Empty};

            var result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.PlantId = null;
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);

            floc.PlantId = CreateString(Constants.PLANT_ID_MAX_LENGTH + 1);
            result = validator.DoesPassRequirementsCheck(floc);
            Assert.IsFalse(result);
        }

        private static string CreateString(int length)
        {
            return length.CreateStringOfConsecutiveDigits();
        }
    }
}