using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class CustomFieldServiceTest
    {
        private Mockery mocks;
        private ICustomFieldDao mockCustomFieldDao;
        private ICustomFieldService service;
        private ICustomFieldGroupDao mockCustomFieldGroupDao;

        [SetUp]
        public void Setup()
        {
            mocks = new Mockery();
            mockCustomFieldDao = mocks.NewMock<ICustomFieldDao>();
            mockCustomFieldGroupDao = mocks.NewMock<ICustomFieldGroupDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(mockCustomFieldDao);
            DaoRegistry.RegisterDaoFor(mockCustomFieldGroupDao);

            service = new CustomFieldService();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void QueryByAssignmentShouldReturnDuplicateFieldNames()
        {
            const string duplicateFieldName = "duplicate name";
            const string uniqueName = "unique name";
            
            List<CustomField> customFields = new List<CustomField>
                                              {
                                                  CustomFieldFixture.CreateCustomField(duplicateFieldName, 1),
                                                  CustomFieldFixture.CreateCustomField(duplicateFieldName, 2),
                                                  CustomFieldFixture.CreateCustomField(uniqueName, 3)
                                              };
            Expect.Once.On(mockCustomFieldDao).Method("QueryByWorkAssignmentForSummaryLogs").WithAnyArguments().Will(Return.Value(customFields));

            List<CustomField> returnedFields = service.QueryOrderedFieldsByWorkAssignmentForSummaryLogs(WorkAssignmentFixture.CreateUnitLeader());
            
            Assert.AreEqual(2, returnedFields.FindAll(field => field.Name == duplicateFieldName).Count);
            Assert.IsTrue(returnedFields.Exists(field => field.Name == uniqueName));
            Assert.AreEqual(3, returnedFields.Count);
        }

        [Ignore] [Test]
        public void ShouldCallCorrectDaoMethodDependingOnUsageArea()
        {
            Expect.Once.On(mockCustomFieldDao).Method("QueryByWorkAssignmentForSummaryLogs").WithAnyArguments().Will(Return.Value(new List<CustomField>()));            
            service.QueryOrderedFieldsByWorkAssignmentForSummaryLogs(WorkAssignmentFixture.CreateUnitLeader());            
            
            Expect.Once.On(mockCustomFieldDao).Method("QueryByWorkAssignmentForLogs").WithAnyArguments().Will(Return.Value(new List<CustomField>()));            
            service.QueryOrderedFieldsByWorkAssignmentForLogs(WorkAssignmentFixture.CreateUnitLeader());            
            
            Expect.Once.On(mockCustomFieldDao).Method("QueryByWorkAssignmentForDailyDirectives").WithAnyArguments().Will(Return.Value(new List<CustomField>()));            
            service.QueryOrderedFieldsByWorkAssignmentForDailyDirectives(WorkAssignmentFixture.CreateUnitLeader());            
        }

        [Ignore] [Test]
        public void QueryBySecondLevelFlocsShouldReturnListOrderedByGroupIdAndDisplayOrder()
        {
            const long groupOneId = 1;
            const long groupTwoId = 2;
            const string dupName = "f1";

            List<CustomField> customFields = new List<CustomField>
                                              {
                                                  // group one:
                                                  new CustomField(null, "z", 0, groupOneId, groupOneId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                                                  new CustomField(null, dupName, 1, groupOneId, groupOneId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                                                  new CustomField(null, "b", 2, groupOneId, groupOneId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                                                  // group two:
                                                  new CustomField(null, dupName, 0, groupTwoId, groupTwoId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                                                  new CustomField(null, "c", 1, groupTwoId, groupTwoId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null),
                                                  new CustomField(null, "a", 2, groupTwoId, groupTwoId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null)
                                              };
            customFields.Sort(field => field.Name, true);  // scramble the order
            Expect.Once.On(mockCustomFieldDao).Method("QueryByWorkAssignmentForSummaryLogs").WithAnyArguments().Will(Return.Value(customFields));

            List<CustomField> returnedFields = service.QueryOrderedFieldsByWorkAssignmentForSummaryLogs(WorkAssignmentFixture.CreateUnitLeader());

            List<string> namesInExpectedOrder = new List<string>
                                                    {
                                                        "z",
                                                        dupName,
                                                        "b",
                                                        dupName,
                                                        "c",
                                                        "a"
                                                    };

            Assert.AreEqual(6, returnedFields.Count);
            for (int i = 0; i < returnedFields.Count; i++)
            {
                Assert.AreEqual(i, returnedFields[i].DisplayOrder);
                Assert.AreEqual(namesInExpectedOrder[i], returnedFields[i].Name);
            }
        }
    }
}
