using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Integration;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class EdmontonSwipeCardServiceTest
    {
        private IEdmontonSwipeCardReader mockCardReader;
        private IEdmontonPersonDao mockPersonDao;

        [SetUp]
        public void SetUp()
        {
            mockCardReader = MockRepository.GenerateMock<IEdmontonSwipeCardReader>();
            mockPersonDao = MockRepository.GenerateStrictMock<IEdmontonPersonDao>();

            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void ShouldSyncData()
        {
            EdmontonPerson swipePerson1 = new EdmontonPerson(null, "New", "GuyToInsert", "7890", Clock.Now.AddHours(-10), BadgeScanStatus.Out);
            EdmontonPerson swipePerson2 = new EdmontonPerson(null, "Old", "Guy", "1001", Clock.Now.AddHours(-1), BadgeScanStatus.Out);
            EdmontonPerson swipePerson3 = new EdmontonPerson(null, "Old", "GuyToUnDelete", "1002", Clock.Now.AddHours(-3), BadgeScanStatus.In);

            List<EdmontonPerson> swipeCards = new List<EdmontonPerson>
            {
                swipePerson1,
                swipePerson2, // only update his status
                swipePerson3
            };

            EdmontonPerson oltPerson1 = new EdmontonPerson(2, "Old", "Guy", "1001", Clock.Now.AddHours(-50), BadgeScanStatus.Out);
            EdmontonPerson oltPerson2 = new EdmontonPerson(3, "Old", "GuyToDelete", "1002", Clock.Now.AddHours(-3), BadgeScanStatus.In);

            List<EdmontonPerson> oltPersons = new List<EdmontonPerson>
            {
                oltPerson1,
                oltPerson2,
            };

            EdmontonPerson oltDeletedPerson = new EdmontonPerson(1, "Old", "GuyToUnDelete", "1002", Clock.Now.AddHours(-200), BadgeScanStatus.In);

            List<EdmontonPerson> oltDeletedPersons = new List<EdmontonPerson>
            {
                oltDeletedPerson
            };

            mockCardReader.Expect(m => m.GetCardsFromSwipeCardSystem(180)).IgnoreArguments().Return(swipeCards);
            mockPersonDao.Expect(m => m.QueryAll()).Return(oltPersons);
            mockPersonDao.Expect(m => m.QueryAllDeleted()).Return(oltDeletedPersons);

            mockPersonDao.Expect(m => m.Insert(swipePerson1));
            mockPersonDao.Expect(m => m.UndoRemove(oltDeletedPerson));
            
            EdmontonPerson updatePerson1 = oltPerson1.DeepClone();
            updatePerson1.UpdateScanData(swipePerson2.LastScan, swipePerson2.ScanStatus);
            mockPersonDao.Expect(m => m.Update(updatePerson1));

            EdmontonPerson updatePerson2 = oltDeletedPerson.DeepClone();
            updatePerson2.UpdateScanData(swipePerson3.LastScan, swipePerson3.ScanStatus);
            mockPersonDao.Expect(m => m.Update(updatePerson2));

            mockPersonDao.Expect(m => m.Remove(oltPerson2));

            EdmontonSwipeCardService service = new EdmontonSwipeCardService(mockCardReader, mockPersonDao);
            service.SyncOltWithCardSwipeSystem();

            mockPersonDao.VerifyAllExpectations();
        }
    }
}