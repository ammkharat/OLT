using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class LogServiceClientTest
    {
        private IFunctionalLocationService flocService;
        private Role roleInDB;
        private IRoleService roleService;
        private ILogService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<ILogService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();
            GenericServiceRegistry.Instance.GetService<IUserService>();
            var rolesBySite = roleService.QueryRolesBySite(SiteFixture.Oilsands());
            roleInDB = rolesBySite[0];
        }

        [Test][Ignore]
        public void AddNewShouldReturnTheLogWithNewID()
        {
            var log = CreateInsertableLog();

            log = (Log) service.Insert(log)[0].DomainObject;
            Assert.IsNotNull(log.Id);
        }

        [Test][Ignore]
        public void AddNewShouldReturnTheSameLog()
        {
            var toInsertLog = CreateInsertableLog();

            var completedLog = (Log) service.Insert(toInsertLog)[0].DomainObject;
            Assert.IsNotNull(completedLog.Id);

            var insertedLog = service.QueryById(completedLog.Id.Value);

            Assert.AreEqual(insertedLog.RtfComments, toInsertLog.RtfComments);
            Assert.AreEqual(insertedLog.PlainTextComments, toInsertLog.PlainTextComments);
            Assert.AreEqual(insertedLog.CreationUser.Id, toInsertLog.CreationUser.Id);
            Assert.AreEqual(insertedLog.EnvironmentalHealthSafetyFollowUp, toInsertLog.EnvironmentalHealthSafetyFollowUp);
            Assert.AreEqual(insertedLog.InspectionFollowUp, toInsertLog.InspectionFollowUp);
            Assert.AreEqual(insertedLog.LastModifiedBy.Id, toInsertLog.LastModifiedBy.Id);
            Assert.AreEqual(insertedLog.OperationsFollowUp, toInsertLog.OperationsFollowUp);
            Assert.AreEqual(insertedLog.ProcessControlFollowUp, toInsertLog.ProcessControlFollowUp);
            Assert.AreEqual(insertedLog.Id, completedLog.Id);
            Assert.AreEqual(insertedLog.ReplyToLogId, toInsertLog.ReplyToLogId);
            Assert.AreEqual(insertedLog.RootLogId, toInsertLog.RootLogId);
            Assert.AreEqual(insertedLog.SupervisionFollowUp, toInsertLog.SupervisionFollowUp);
        }

        [Test][Ignore]
        public void QueryForPriorityPageDTOs_FLOCTest()
        {
            var siteId = Site.OILSAND_ID;
            var rootFLOC_UP1 = flocService.QueryByFullHierarchy("UP1", siteId);
            var rootFLOC_UP2_FACL_TOOL = flocService.QueryByFullHierarchy("UP2-FACL-TOOL", siteId);

            var UP2 = flocService.QueryByFullHierarchy("UP2", siteId);
            var UP2_FACL = flocService.QueryByFullHierarchy("UP2-FACL", siteId);
            var UP2_P034 = flocService.QueryByFullHierarchy("UP2-P034", siteId);
            var UP2_P034_API1 = flocService.QueryByFullHierarchy("UP2-P034-API1", siteId);
            var UP2_P052_COMS = flocService.QueryByFullHierarchy("UP2-P052-COMS", siteId);

            var UP1 = flocService.QueryByFullHierarchy("UP1", siteId);
            var UP1_P005_FRC1 = flocService.QueryByFullHierarchy("UP1-P005-FRC1", siteId);
            var UP1_P005_FRC1_SIL_P0758 = flocService.QueryByFullHierarchy("UP1-P005-FRC1-SIL-P0758", siteId);

            var rootFLOCs = new List<FunctionalLocation> {rootFLOC_UP1, rootFLOC_UP2_FACL_TOOL};

            var directiveRoles = roleService.QueryAllAvailableInSiteWithAnyRoleElement(SiteFixture.Oilsands(),
                new List<RoleElement> {RoleElement.CREATE_LOG_BASED_DIRECTIVES});
            var roleThatCanCreateDirectives = directiveRoles[0];

            // UP2-FACL is a direct ancestor to UP2-FACL-TOOL. Should be found   
            AssertDirectiveIsFoundForFLOC(true, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP2_FACL});

            // UP2-FACL-TOOL is a direct hit. Should be found               
            AssertDirectiveIsFoundForFLOC(true, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {rootFLOC_UP2_FACL_TOOL});

            // UP2-P034 is a sibling to UP2-FACL. Should not be found               
            AssertDirectiveIsFoundForFLOC(false, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP2_P034});

            // UP2-P034-API1 is a nephew to UP2-FACL. Should not be found               
            AssertDirectiveIsFoundForFLOC(false, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP2_P034_API1});

            // UP2 is the granddaddy of them all. Should be found               
            AssertDirectiveIsFoundForFLOC(true, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP2});

            // All UP1 flocs should be found since UP1 is a user root.
            AssertDirectiveIsFoundForFLOC(true, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP1});
            AssertDirectiveIsFoundForFLOC(true, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP1_P005_FRC1});
            AssertDirectiveIsFoundForFLOC(true, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP1_P005_FRC1_SIL_P0758});

            // Some more checks
            AssertDirectiveIsFoundForFLOC(true, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {rootFLOC_UP2_FACL_TOOL, UP2_FACL, UP1});
            AssertDirectiveIsFoundForFLOC(false, roleThatCanCreateDirectives, rootFLOCs,
                new List<FunctionalLocation> {UP2_P034_API1, UP2_P052_COMS});
        }

        [Test][Ignore]
        public void ShouldBeAbleToUpdateKnownLog()
        {
            var log = CreateInsertableLog();

            //insert a Log
            log = (Log) service.Insert(log)[0].DomainObject;
            Assert.IsNotNull(log.Id);
            var idOfLogToUpdate = log.IdValue;

            var original = service.QueryById(idOfLogToUpdate);
            Assert.IsNotNull(original.Id);

            original.SetRTFAndPlainTextComments("New Comments");
            service.Update(original);

            Assert.AreEqual(original.RtfComments, "New Comments");
            Assert.AreEqual(original.PlainTextComments, "New Comments");

            var updated = service.QueryById(idOfLogToUpdate);
            Assert.IsNotNull(original.Id);

            Assert.AreEqual(original.RtfComments, updated.RtfComments);
            Assert.AreEqual(original.PlainTextComments, updated.RtfComments);
        }

        [Test][Ignore]
        public void ShouldReturnAPopulatedLog()
        {
            var log = CreateInsertableLog();

            //insert a Log
            log = (Log) service.Insert(log)[0].DomainObject;
            Assert.IsNotNull(log.Id);

            var actual = service.QueryById(log.IdValue);
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.CreationUser);
        }

        [Test][Ignore]
        public void UpdateShouldSaveUpdatedLog()
        {
            var toUpdateLog = CreateInsertableLog();

            //insert a Log
            toUpdateLog = (Log) service.Insert(toUpdateLog)[0].DomainObject;
            Assert.IsNotNull(toUpdateLog.Id);

            //grab it again
            toUpdateLog = service.QueryById(toUpdateLog.Id.Value);

            toUpdateLog.SetRTFAndPlainTextComments("Updated Comments");
            service.Update(toUpdateLog);

            Assert.AreEqual(toUpdateLog.RtfComments, "Updated Comments");
            Assert.AreEqual(toUpdateLog.PlainTextComments, "Updated Comments");

            var updatedLog = service.QueryById(toUpdateLog.IdValue);

            Assert.AreEqual(toUpdateLog.RtfComments, "Updated Comments");
            Assert.AreEqual(toUpdateLog.PlainTextComments, "Updated Comments");
        }

        private void AssertDirectiveIsFoundForFLOC(
            bool shouldBeFound, Role roleThatCanCreateDirectives,
            List<FunctionalLocation> rootFLOCs, List<FunctionalLocation> flocsForDirective)
        {
            var someUser = UserFixture.CreateUserWithGivenId(1);

            var date = new Date(2011, 3, 9);
            var range = new Range<Date>(date, date);

            var directive = CreateDirectiveToInsert(flocsForDirective, roleThatCanCreateDirectives, date, someUser);
            var insertedDirective = (Log) service.Insert(directive)[0].DomainObject;

            var directives = service.QueryDirectivesForPriorityPageDTOs(new RootFlocSet(rootFLOCs), range, someUser,
                null);

            var foundDTO = directives.Find(dto => dto.IdValue == insertedDirective.IdValue);

            if (shouldBeFound)
            {
                Assert.IsNotNull(foundDTO);
            }
            else
            {
                Assert.IsNull(foundDTO);
            }
        }

        private Log CreateDirectiveToInsert(List<FunctionalLocation> flocsForDirective, Role createdByRole,
            Date loggedDate, User user)
        {
            var loggedDateTime = loggedDate.CreateDateTime(new Time(11));

            var shiftPattern = ShiftPatternFixture.CreateOilsandsDayShift();

            var directive = LogFixture.CreateLog(
                loggedDateTime, flocsForDirective, null, shiftPattern, user,
                LogType.DailyDirective, createdByRole);

            directive.RtfComments = "Comments";
            directive.PlainTextComments = "Comments";

            return directive;
        }

        private Log CreateInsertableLog()
        {
            var log = LogFixture.CreateLogItemWithSpecificRole(roleInDB);

            log.ReplyToLogId = null;
            log.RootLogId = null;
            log.FunctionalLocations = new List<FunctionalLocation>
            {
                flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID)
            };
            log.LastModifiedDate = DateTimeFixture.DateTimeNow;
            log.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID

            return log;
        }
    }
}