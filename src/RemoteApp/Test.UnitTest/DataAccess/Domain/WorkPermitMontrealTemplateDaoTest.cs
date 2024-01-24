using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class WorkPermitMontrealTemplateDaoTest : AbstractDaoTest
    {
        private IWorkPermitMontrealTemplateDao dao;

        const string PERMIT_ONE_NAME = "MONTREAL TEMPLATE ONE";
        const string PERMIT_TWO_NAME = "MONTREAL TEMPLATE TWO";
        const string NEW_TEMPLATE_NAME = "This is a New Name";

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IWorkPermitMontrealTemplateDao>();  
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryAllNotDeleted()
        {
            WorkPermitMontrealTemplate templateDeleted = WorkPermitMontrealTemplate.NULL;
            templateDeleted.TemplateNumber = WorkPermitMontrealTemplate.NET_NEW_TEMPLATE;
            templateDeleted.Name = PERMIT_ONE_NAME;
            templateDeleted.WorkPermitType = WorkPermitMontrealType.COLD;
            templateDeleted.IsActive = true;
            templateDeleted.IsDeleted = true;

            WorkPermitMontrealTemplate templateNotDeleted = WorkPermitMontrealTemplate.NULL;
            templateNotDeleted.TemplateNumber = WorkPermitMontrealTemplate.NET_NEW_TEMPLATE;
            templateNotDeleted.Name = PERMIT_TWO_NAME;
            templateNotDeleted.WorkPermitType = WorkPermitMontrealType.VEHICLE_ENTRY;
            templateNotDeleted.IsActive = true;
            templateNotDeleted.IsDeleted = false;            
            
            dao.Insert(templateDeleted);
            dao.Insert(templateNotDeleted);

            List<WorkPermitMontrealTemplate> nonDeletedTemplatesFromDB = dao.QueryAllNotDeleted();
            
            Assert.That(nonDeletedTemplatesFromDB, Has.Some.With.Property("Name").EqualTo(PERMIT_TWO_NAME));
            WorkPermitMontrealTemplate insertedTemplate = nonDeletedTemplatesFromDB.Find(t => t.Name.Equals(PERMIT_TWO_NAME));

            Assert.AreEqual(WorkPermitMontrealType.VEHICLE_ENTRY, insertedTemplate.WorkPermitType);
            Assert.IsTrue(insertedTemplate.IsActive);
            Assert.IsFalse(insertedTemplate.IsDeleted);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToSetBoiteEnergieZero()
        {
            WorkPermitMontrealTemplate templateNotDeleted = WorkPermitMontrealTemplate.NULL;
            templateNotDeleted.TemplateNumber = WorkPermitMontrealTemplate.NET_NEW_TEMPLATE;
            templateNotDeleted.Name = "This is a permit";
            templateNotDeleted.WorkPermitType = WorkPermitMontrealType.VEHICLE_ENTRY;
            templateNotDeleted.IsActive = true;
            templateNotDeleted.IsDeleted = false;

            templateNotDeleted.BoiteEnergieZero = TemplateState.Checked;
            templateNotDeleted.BoiteEnergieZeroValue = "12345";
            
            WorkPermitMontrealTemplate templateFromInsert = dao.Insert(templateNotDeleted);

            WorkPermitMontrealTemplate templateFromQuery = dao.QueryById(templateFromInsert.IdValue);
            Assert.AreEqual(TemplateState.Checked, templateFromQuery.BoiteEnergieZero);
            Assert.AreEqual("12345", templateFromQuery.BoiteEnergieZeroValue);
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            WorkPermitMontrealTemplate templateNotDeleted = WorkPermitMontrealTemplate.NULL;
            templateNotDeleted.TemplateNumber = WorkPermitMontrealTemplate.NET_NEW_TEMPLATE;
            templateNotDeleted.Name = PERMIT_TWO_NAME;
            templateNotDeleted.WorkPermitType = WorkPermitMontrealType.VEHICLE_ENTRY;
            templateNotDeleted.IsActive = true;
            templateNotDeleted.IsDeleted = false;

            WorkPermitMontrealTemplate templateFromInsert = dao.Insert(templateNotDeleted);

            WorkPermitMontrealTemplate templateFromQuery = dao.QueryById(templateFromInsert.IdValue);
            Assert.IsNotNull(templateFromQuery);
            Assert.AreEqual(PERMIT_TWO_NAME, templateFromQuery.Name);
            Assert.AreEqual(WorkPermitMontrealType.VEHICLE_ENTRY, templateFromQuery.WorkPermitType);
            Assert.IsTrue(templateFromQuery.IsActive);
            Assert.IsFalse(templateFromQuery.IsDeleted);
        }

        [Ignore] [Test]
        public void ShouldMarkTemplateAsDeleted()
        {
            WorkPermitMontrealTemplate template = WorkPermitMontrealTemplate.NULL;
            template.TemplateNumber = WorkPermitMontrealTemplate.NET_NEW_TEMPLATE;
            template.Name = PERMIT_ONE_NAME;
            template.WorkPermitType = WorkPermitMontrealType.VEHICLE_ENTRY;
            template.IsActive = true;
            template.IsDeleted = false;

            dao.Insert(template);

            List<WorkPermitMontrealTemplate> nonDeletedTemplatesFromDB = dao.QueryAllNotDeleted();

            Assert.That(nonDeletedTemplatesFromDB, Has.Some.With.Property("Name").EqualTo(PERMIT_ONE_NAME));
            WorkPermitMontrealTemplate insertedTemplate = nonDeletedTemplatesFromDB.Find(t => t.Name.Equals(PERMIT_ONE_NAME));

            Assert.AreEqual(WorkPermitMontrealType.VEHICLE_ENTRY, insertedTemplate.WorkPermitType);
            Assert.IsTrue(insertedTemplate.IsActive);
            Assert.IsFalse(insertedTemplate.IsDeleted);

            // Delete the Template & check it has been marked as deleted
            dao.Delete(insertedTemplate);
            WorkPermitMontrealTemplate deleted = dao.QueryById(insertedTemplate.IdValue);
            Assert.IsNotNull(deleted);
            Assert.IsTrue(deleted.IsDeleted);

            // Make sure deleted template isn't returned in a query for all non-deleted ones
            nonDeletedTemplatesFromDB = dao.QueryAllNotDeleted();
            Assert.That(nonDeletedTemplatesFromDB.Exists(t => t.Name.Equals(PERMIT_ONE_NAME)), Is.False);
        }

        [Ignore] [Test]
        public void ShouldAssignTheNextTemplateNumberIfInsertedTemplateHasTemplateNumberOfZero()
        {
            // Current DB has 42 pre-created Montreal Work Permit Templates, with the last one having an id of 67, so get the newest one:
            List<WorkPermitMontrealTemplate> workPermitMontrealTemplates = dao.QueryAll();

            // get the largest Template Number
            int maxTemplateNumber = 0;
            workPermitMontrealTemplates.ForEach(t => maxTemplateNumber = Math.Max(maxTemplateNumber, t.TemplateNumber.GetValueOrDefault(0)));

            // Create and insert a net new template
            WorkPermitMontrealTemplate template = WorkPermitMontrealTemplate.NULL;
            template.TemplateNumber = WorkPermitMontrealTemplate.NET_NEW_TEMPLATE;
            template.Name = PERMIT_ONE_NAME;
            template.WorkPermitType = WorkPermitMontrealType.VEHICLE_ENTRY;
            template.IsActive = true;
            template.IsDeleted = false;

            WorkPermitMontrealTemplate newTemplate = dao.Insert(template);
            int? assignedTemplateNumber = newTemplate.TemplateNumber;
            
            Assert.AreEqual(maxTemplateNumber + 1, assignedTemplateNumber);
        }

        [Ignore] [Test]
        public void ShouldNotAssignNextTemplateNumberIfRecordBeingInsertedHasAnNonZeroTemplateNumber()
        {
            WorkPermitMontrealTemplate newestTemplateInDB = dao.QueryById(39);
            int? currentTemplateNumber = newestTemplateInDB.TemplateNumber;

            newestTemplateInDB.Name = NEW_TEMPLATE_NAME;

            WorkPermitMontrealTemplate updatedTemplate = dao.Insert(newestTemplateInDB);

            Assert.AreEqual(currentTemplateNumber, updatedTemplate.TemplateNumber);
            Assert.AreEqual(NEW_TEMPLATE_NAME, updatedTemplate.Name);
        }
    }
}
