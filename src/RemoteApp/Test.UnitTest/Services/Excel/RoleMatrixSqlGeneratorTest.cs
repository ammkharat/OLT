using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Excel;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    [TestFixture]
    public class RoleMatrixSqlGeneratorTest
    {
        private IRoleService mockRoleService;
        private IRoleElementService mockRoleElementService;
        private ISiteService mockSiteService;


        [SetUp]
        public void Setup()
        {
            mockRoleService = MockRepository.GenerateStub<IRoleService>();
            mockRoleElementService = MockRepository.GenerateStub<IRoleElementService>();
            mockSiteService = MockRepository.GenerateStub<ISiteService>();
        }

        [Ignore] [Test]
        public void ShouldBeAbleToCreateStreamAndReadBackAgain()
        {
            Workbook workbook = CreateWorkbook();
            string tempFileName = Path.GetTempFileName();
            workbook.Save(tempFileName);

            workbook = Workbook.Load(tempFileName);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.Save(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                workbook = Workbook.Load(memoryStream);
            }

            WorksheetCollection worksheetCollection = workbook.Worksheets;

            
            Assert.That(worksheetCollection.Exists(ws => ws.Name.Equals("Role Matrix")));
        }

        [Ignore] [Test]
        public void ShouldGetRoleValuesFromWorkbook()
        {
            Workbook workbook = CreateWorkbook();

            RoleMatrixSqlGenerator roleMatrixSqlGenerator = new RoleMatrixSqlGenerator(workbook, mockRoleService, mockRoleElementService, mockSiteService);

            Site edmonton = SiteFixture.Edmonton();
            Role administratorRole = RoleFixture.CreateAdministratorRole();
            Role operatorRole = RoleFixture.CreateOperatorRole();
            Role supervisorRole = RoleFixture.CreateSupervisorRole();

            List<RoleElement> allRoleElements = new List<RoleElement> { RoleElement.VIEW_LOG, RoleElement.VIEW_ACTIONITEM, RoleElement.CREATE_LOG, RoleElement.CREATE_COKER_CARD };

            List<Role> roles = new List<Role>{administratorRole, operatorRole, supervisorRole};

            mockSiteService.Stub(m => m.GetAll()).Return(new List<Site> {SiteFixture.Edmonton()});
            mockRoleService.Stub(m => m.QueryRolesBySite(edmonton)).Return(roles);
            mockRoleElementService.Stub(m => m.QueryAll()).Return(allRoleElements);

            RoleElement elementNotInListAtAll = new RoleElement(-33, "someelementnotinthelistatall");

            RoleElementTemplateValuesContainer roleValues = roleMatrixSqlGenerator.ReadRolesAndRoleElementsFromMatrix(edmonton, workbook.Worksheets["Role Matrix"]);
            Assert.That(roleValues.HasRoleElement(administratorRole, RoleElement.VIEW_LOG), Is.True);
            Assert.That(roleValues.HasRoleElement(administratorRole, RoleElement.VIEW_ACTIONITEM), Is.True);
            Assert.That(roleValues.HasRoleElement(administratorRole, RoleElement.CREATE_LOG), Is.False);
            Assert.That(roleValues.HasRoleElement(administratorRole, RoleElement.CREATE_COKER_CARD), Is.False);
            Assert.That(roleValues.HasRoleElement(administratorRole, elementNotInListAtAll), Is.False);

            Assert.That(roleValues.HasRoleElement(operatorRole, RoleElement.VIEW_LOG), Is.True);
            Assert.That(roleValues.HasRoleElement(operatorRole, RoleElement.CREATE_LOG), Is.True);
            Assert.That(roleValues.HasRoleElement(operatorRole, RoleElement.VIEW_ACTIONITEM), Is.False);
            Assert.That(roleValues.HasRoleElement(operatorRole, RoleElement.CREATE_COKER_CARD), Is.False);

            Assert.That(roleValues.HasRoleElement(supervisorRole, RoleElement.VIEW_LOG), Is.True);
            Assert.That(roleValues.HasRoleElement(supervisorRole, RoleElement.CREATE_LOG), Is.False);
            Assert.That(roleValues.HasRoleElement(supervisorRole, RoleElement.VIEW_ACTIONITEM), Is.True);
            Assert.That(roleValues.HasRoleElement(supervisorRole, RoleElement.CREATE_COKER_CARD), Is.True);
        }

        private static Workbook CreateWorkbook()
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets.Add("Role Matrix");

            worksheet.GetCell("C3").Value = RoleElement.VIEW_LOG.Name;
            worksheet.GetCell("C4").Value = RoleElement.CREATE_LOG.Name;
            worksheet.GetCell("C5").Value = RoleElement.VIEW_ACTIONITEM.Name;
            worksheet.GetCell("C6").Value = RoleElement.CREATE_COKER_CARD.Name;

            worksheet.GetCell("D1").Value = "Edmonton";
            worksheet.MergedCellsRegions.Add(0, 3, 0, 5);

            worksheet.GetCell("D2").Value = "Administrator (admin)";
            worksheet.GetCell("D3").Value = "Y";
            worksheet.GetCell("D4").Value = string.Empty;
            worksheet.GetCell("D5").Value = "Y";

            worksheet.GetCell("E2").Value = "Operator (oper)";
            worksheet.GetCell("E3").Value = "Y";
            worksheet.GetCell("E4").Value = "Y";

            worksheet.GetCell("F2").Value = "Supervisor (super)";
            worksheet.GetCell("F3").Value = "Y";
            worksheet.GetCell("F4").Value = "N";
            worksheet.GetCell("F5").Value = "Y";
            worksheet.GetCell("F6").Value = "Y";
            return workbook;
        }

        [Ignore] [Test]
        public void ShouldGenerateSqlChanges()
        {
            Workbook workbook = CreateWorkbook();

            RoleMatrixSqlGenerator roleMatrixSqlGenerator = new RoleMatrixSqlGenerator(workbook, mockRoleService, mockRoleElementService, mockSiteService);

            Site edmonton = SiteFixture.Edmonton();
            Role administratorRole = RoleFixture.CreateAdministratorRole();
            Role operatorRole = RoleFixture.CreateOperatorRole();
            Role supervisorRole = RoleFixture.CreateSupervisorRole();

            List<RoleElement> allRoleElements = new List<RoleElement> { RoleElement.VIEW_LOG, RoleElement.VIEW_ACTIONITEM, RoleElement.CREATE_LOG, RoleElement.CREATE_COKER_CARD };

            List<Role> roles = new List<Role> { administratorRole, operatorRole, supervisorRole };

            mockSiteService.Stub(m => m.GetAll()).Return(new List<Site> { SiteFixture.Edmonton() });
            mockRoleService.Stub(m => m.QueryRolesBySite(edmonton)).Return(roles);
            mockRoleElementService.Stub(m => m.QueryAll()).Return(allRoleElements);

            List<RoleElement> adminRoleElements = new List<RoleElement> {
                                                    RoleElement.VIEW_LOG, // should stay the same
                                                    RoleElement.CREATE_LOG // should remove create for admin
                                                    }; // should add 'View Action Items' since it wasn't there before.  : 1 delete, 1 add

            mockRoleElementService.Stub(m => m.QueryTemplateForRole(administratorRole)).Return(adminRoleElements);

            List<RoleElement> operatorRoleElements = new List<RoleElement> {
                                                    RoleElement.VIEW_LOG, // should stay the same
                                                    RoleElement.CREATE_LOG // should stay the same       
                                                    }; // should do nothing with operator                               : 0 delete, 0 add

            
            mockRoleElementService.Stub(m => m.QueryTemplateForRole(operatorRole)).Return(operatorRoleElements);

            List<RoleElement> supervisorRoleElements = new List<RoleElement> {
                                                    RoleElement.VIEW_LOG, // should stay the same 
                                                    RoleElement.CREATE_LOG, // show add this
                                                    RoleElement.VIEW_COKER_CARD// should remove this
                                                    }; // should add coker card and action item ones                    : 2 delete, 2 add

            mockRoleElementService.Stub(m => m.QueryTemplateForRole(supervisorRole)).Return(supervisorRoleElements);

            List<RoleElementChange> changes = roleMatrixSqlGenerator.GenerateRoleMatrixSql();
            List<string> result = changes.ConvertAll(c => c.ConvertToSql());
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Has.Some.StringStarting("INSERT INTO RoleElementTemplate (RoleElementId, RoleId) select re.Id, r.Id from RoleElement re, Role r where r.SiteId = 8 and r.[Name] = 'Administrator' and re.[Name] = 'View Action Item';"));
            Assert.That(result, Has.Some.StringStarting("DELETE FROM RoleElementTemplate WHERE RoleId = (select r.Id from [Role] r where r.SiteId = 8 and r.[Name] = 'Administrator') and RoleElementId = (select re.Id from RoleElement re where re.[Name] in ('Create Log'));"));
        }

    }
}