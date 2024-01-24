using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class DropdownValueServiceTest
    {
        private IDropdownValueDao mockDao;
        private DropdownValueService service;

        [SetUp]
        public void SetUp()
        {
            mockDao = MockRepository.GenerateMock<IDropdownValueDao>();
            DaoRegistry.RegisterDaoFor(mockDao);

            service = new DropdownValueService();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void UpdateValuesShouldDeleteAndInsertAndUpdateAsAppropriate()
        {
            string someKey = "some_nice_key";

            DropdownValue valueOne = new DropdownValue(1, Site.MONTREAL_ID, someKey, "First", 0);
            DropdownValue valueTwo = new DropdownValue(2, Site.MONTREAL_ID, someKey, "Second", 1);
            DropdownValue valueThree = new DropdownValue(3, Site.MONTREAL_ID, someKey, "Third", 2);

            // the real test
            {
                valueOne.Value = "First Modified";
                DropdownValue newValue = new DropdownValue(Site.MONTREAL_ID, someKey, "New", 3);

                List<DropdownValue> values = new List<DropdownValue> { valueOne, valueThree, newValue };
                List<DropdownValue> deletedValues = new List<DropdownValue> { valueTwo };

                mockDao.Expect(m => m.Insert(newValue));
                mockDao.Expect(m => m.Update(valueOne));
                mockDao.Expect(m => m.Remove(valueTwo));

                service.UpdateValues(values, deletedValues);
            }

        }

    }
}