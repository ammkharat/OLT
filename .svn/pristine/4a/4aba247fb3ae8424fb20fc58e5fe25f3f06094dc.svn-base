using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.DTO
{
    [TestFixture]
    public class LogDTOTest
    {
        [Test]
        public void ShouldInitializeCommonPropertiesFromLog()
        {
            Log log = LogFixture.CreateLogItemGoofySarnia();
            log.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            log.FunctionalLocations = new List<FunctionalLocation>
                                          {
                                              FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM(),
                                              FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()                                              
                                          };

            // Execute:
            var dto = new LogDTO(log);
            AssertCommonLogProperties(log, dto);
        }

        [Test]
        public void ShouldInitializeIsRecurringWithFalseWhenNoLogDefinition()
        {
            Log log = LogFixture.CreateLogItemGoofySarnia();
            log.LogDefinition = null;

            // Execute:
            var dto = new LogDTO(log);
            Assert.AreEqual(false, dto.IsRecurring);
        }

        [Test]
        public void ShouldInitializeCreatedByPositionWithLastModifiedUserPositionWhenNoLogDefinition()
        {
            Log log = LogFixture.CreateLogItemGoofySarnia(CreateUserWithPosition());
            log.LogDefinition = null;
            log.LastModifiedBy = CreateUserWithPosition();

            var dto = new LogDTO(log);
            Assert.AreEqual(null, dto.LogDefinitionId);
        }

        [Test]
        public void ShouldNotAllowDuplicateVisibilityGroupNames()
        {
            Log log = LogFixture.CreateLogItemGoofySarnia();
            var dto = new LogDTO(log);
            dto.GetVisibilityGroupNames().Clear();

            dto.AddVisibilityGroup("z");
            dto.AddVisibilityGroup("c");
            dto.AddVisibilityGroup("z");
            dto.AddVisibilityGroup("a");
            dto.AddVisibilityGroup("c");
            dto.AddVisibilityGroup("b");

            Assert.AreEqual(new List<string> { "a", "b", "c", "z" }, dto.GetVisibilityGroupNames());
        }

        private static void AssertCommonLogProperties(Log log, LogDTO dto)
        {
            Assert.AreEqual(log.RootLogId, dto.RootLogId);
            Assert.AreEqual(log.ReplyToLogId, dto.ReplyToLogId);
            Assert.AreEqual(log.FunctionalLocations.FullHierarchyListToString(true, false), dto.FunctionalLocationNames);
            Assert.AreEqual(log.InspectionFollowUp, dto.InspectionFollowUp);
            Assert.AreEqual(log.ProcessControlFollowUp, dto.ProcessControlFollowUp);
            Assert.AreEqual(log.OperationsFollowUp, dto.OperationsFollowUp);
            Assert.AreEqual(log.SupervisionFollowUp, dto.SupervisionFollowUp);
            Assert.AreEqual(log.EnvironmentalHealthSafetyFollowUp, dto.EnvironmentalHealthSafetyFollowUp);
            Assert.AreEqual(log.OtherFollowUp, dto.OtherFollowUp);            
            Assert.AreEqual(log.LogDateTime, dto.LogDateTime);
            Assert.AreEqual(log.CreationUser.FullNameWithUserName, dto.CreatedByFullnameWithUserName);
            Assert.AreEqual(log.LastModifiedBy.FullNameWithUserName, dto.LastModifiedFullNameWithUserName);
            Assert.AreEqual(log.CreatedShiftPattern.IdValue, dto.CreatedShiftPatternId);
            Assert.AreEqual(new Date(log.LogDateTime), dto.CreatedShiftStartDate);
            Assert.AreEqual(log.CreatedShiftPattern.StartTime, dto.CreatedShiftStartTime);
            Assert.AreEqual(log.CreatedShiftPattern.Name, dto.CreatedShiftName);
            Assert.AreEqual(log.IsPartOfThread, dto.IsPartOfThread);
            Assert.AreEqual(log.HasChildren, dto.HasChildren);
            Assert.AreEqual(log.Source.Id, dto.SourceId);
        }

        private static User CreateUserWithPosition()
        {
            return new User(-99, "ltest", "LogDTO", "Test", null, "42", null, null, null, DateTimeFixture.DateTimeNow);
        }
    }
}
