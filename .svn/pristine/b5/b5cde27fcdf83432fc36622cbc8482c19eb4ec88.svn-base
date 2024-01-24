using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class DirectiveDaoTest : AbstractDaoTest
    {
        private IDirectiveDao dao;
        private IDirectiveDTODao dtoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IDirectiveDao>();
            dtoDao = DaoRegistry.GetDao<IDirectiveDTODao>();
        }

        protected override void Cleanup()
        {
        
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1, floc2 };

            DateTime now = Clock.Now;
            DateTime aBitLaterThanNow = now.AddHours(1);
            DateTime activeFromDateTime = Clock.Now.AddDays(1);            
            DateTime activeToDateTime = Clock.Now.AddDays(5);

            string content = "Content";
            string plainTextContent = "Plain Text Content";

            User createdBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            createdBy.Id = 1;
            DateTime createdDate = now;
            Role createdByRole = RoleFixture.GetRealRole(SiteFixture.Edmonton().IdValue, "Supervisor");

            User lastModifiedBy = UserFixture.CreateSupervisor(SiteFixture.Edmonton());
            lastModifiedBy.Id = 2;
            DateTime lastModifiedDateTime = aBitLaterThanNow;

            string migrationSource = "migration source";
            string extraInfoFromMigrationSource = "extra info";

            Directive newDirective = new Directive(activeFromDateTime, activeToDateTime, content, plainTextContent, lastModifiedBy, lastModifiedDateTime, createdBy, createdByRole, createdDate);    
            newDirective.FunctionalLocations = functionalLocations;
            newDirective.WorkAssignments = WorkAssignmentFixture.GetListOfEdmontonWorkAssigments();
            newDirective.CreatedByWorkAssignmentName = "Created by this wa name";
            newDirective.DocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            newDirective.MigrationSource = migrationSource;
            newDirective.ExtraInfoFromMigrationSource = extraInfoFromMigrationSource;

            dao.Insert(newDirective);

            Directive requeriedDirective = dao.QueryById(newDirective.IdValue);
            
            Assert.That(activeFromDateTime, Is.EqualTo(requeriedDirective.ActiveFromDateTime).Within(1).Seconds);
            Assert.That(activeToDateTime, Is.EqualTo(requeriedDirective.ActiveToDateTime).Within(1).Seconds);

            Assert.AreEqual(content, requeriedDirective.Content);
            Assert.AreEqual(plainTextContent, requeriedDirective.PlainTextContent);

            Assert.AreEqual(lastModifiedBy.IdValue, requeriedDirective.LastModifiedBy.IdValue);            
            Assert.That(lastModifiedDateTime, Is.EqualTo(requeriedDirective.LastModifiedDateTime).Within(1).Seconds);

            Assert.AreEqual(createdBy.IdValue, requeriedDirective.CreatedBy.IdValue);            
            Assert.That(createdDate, Is.EqualTo(requeriedDirective.CreatedDateTime).Within(1).Seconds);

            Assert.AreEqual(functionalLocations.Count, requeriedDirective.FunctionalLocations.Count);
            Assert.IsTrue(requeriedDirective.FunctionalLocations.Exists(floc => floc.IdValue == floc1.IdValue));
            Assert.IsTrue(requeriedDirective.FunctionalLocations.Exists(floc => floc.IdValue == floc2.IdValue));

            Assert.AreEqual(newDirective.DocumentLinks.Count, requeriedDirective.DocumentLinks.Count);
            Assert.AreEqual(newDirective.CreatedByWorkAssignmentName, requeriedDirective.CreatedByWorkAssignmentName);

            Assert.AreEqual(newDirective.MigrationSource, requeriedDirective.MigrationSource);
            Assert.AreEqual(newDirective.ExtraInfoFromMigrationSource, requeriedDirective.ExtraInfoFromMigrationSource);

            CheckWorkAssignments(requeriedDirective, newDirective.WorkAssignments);
        }

        private void CheckWorkAssignments(Directive directiveToCheck, List<WorkAssignment> expectedWorkAssignments)
        {
            Assert.AreEqual(directiveToCheck.WorkAssignments.Count, expectedWorkAssignments.Count);

            foreach (WorkAssignment expectedWorkAssignment in expectedWorkAssignments)
            {
                Assert.IsTrue(directiveToCheck.WorkAssignments.Exists(wa => wa.IdValue == expectedWorkAssignment.IdValue));
            }
        }

        [Ignore] [Test]        
        public void ShouldUpdate()
        {
            Directive directive = DirectiveFixture.CreateForInsert();
            dao.Insert(directive);

            Directive directiveToUpdate = dao.QueryById(directive.IdValue);

            Assert.AreNotEqual(2, directiveToUpdate.LastModifiedBy.IdValue);

            int workAssignmentCount = directiveToUpdate.WorkAssignments.Count;
            directiveToUpdate.WorkAssignments.RemoveAt(0);

            int documentLinkCount = directiveToUpdate.DocumentLinks.Count;
            directiveToUpdate.DocumentLinks.RemoveAt(0);

            DateTime newFromDateTime = new DateTime(2013, 2, 21, 15, 45, 0);
            DateTime newToDateTime = new DateTime(2013, 2, 26, 11, 59, 59);
            
            directiveToUpdate.ActiveFromDateTime = newFromDateTime;                       
            directiveToUpdate.ActiveToDateTime = newToDateTime;
            string newContent = "New content!";
            string newPlainTextContent = "New plain text content!";
            User lastModifiedUser = UserFixture.CreateUserWithGivenId(2);
            DateTime lastModifiedDateTime = new DateTime(2013, 1, 1);

            directiveToUpdate.Content = newContent;            
            directiveToUpdate.PlainTextContent = newPlainTextContent;            
            directiveToUpdate.LastModifiedBy = lastModifiedUser;            
            directiveToUpdate.LastModifiedDateTime = lastModifiedDateTime;

            dao.Update(directiveToUpdate);

            Directive updatedDirective = dao.QueryById(directiveToUpdate.IdValue);

            Assert.AreEqual(workAssignmentCount - 1, updatedDirective.WorkAssignments.Count);
            Assert.AreEqual(documentLinkCount -1, updatedDirective.DocumentLinks.Count);

            Assert.AreEqual(newFromDateTime, updatedDirective.ActiveFromDateTime);            
            Assert.That(newToDateTime, Is.EqualTo(updatedDirective.ActiveToDateTime).Within(1).Seconds);

            Assert.AreEqual(newContent, updatedDirective.Content);
            Assert.AreEqual(newPlainTextContent, updatedDirective.PlainTextContent);

            Assert.AreEqual(lastModifiedUser.IdValue, updatedDirective.LastModifiedBy.IdValue);            
            Assert.That(lastModifiedDateTime, Is.EqualTo(updatedDirective.LastModifiedDateTime).Within(1).Seconds);
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            Directive directive = DirectiveFixture.CreateForInsert();
            directive.ActiveFromDateTime = new DateTime(2013, 5, 20, 10, 30, 0);
            directive.ActiveToDateTime = new DateTime(2013, 5, 25, 23, 59, 59);
            directive.FunctionalLocations = new List<FunctionalLocation> { floc };
            dao.Insert(directive);

            {
                // Make sure it's coming back.
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(2013, 5, 20), new Date(2013, 5, 25)), new RootFlocSet(floc), null, null);
                Assert.IsTrue(results.Exists(d => d.IdValue == directive.IdValue));                
            }

            dao.Remove(directive);

            {
                // Make sure it's not coming back
                List<DirectiveDTO> results = dtoDao.QueryByDateRangeAndFlocs(new Range<Date>(new Date(2013, 5, 20), new Date(2013, 5, 25)), new RootFlocSet(floc), null, null);
                Assert.IsFalse(results.Exists(d => d.IdValue == directive.IdValue));                                
            }
        }
    }
}
