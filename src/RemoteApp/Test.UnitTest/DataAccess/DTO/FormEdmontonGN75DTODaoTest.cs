using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class FormEdmontonGN75DTODaoTest : AbstractDaoTest
    {
        private IFormGN75BDao dao;
        private IFormEdmontonGN75BDTODao dtoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN75BDao>();
            dtoDao = DaoRegistry.GetDao<IFormEdmontonGN75BDTODao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldGetItemsWithMatchingStatus()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form1 = new FormGN75B(floc, floc.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                         Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8, new List<DevicePosition>(0),0,null,null);  //ayman Sarnia eip DMND0008992

            FormGN75B form2 = new FormGN75B(floc, floc.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                         Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8,new List<DevicePosition>(0),0,null,null);   //ayman Sarnia eip DMND0008992

            dao.Insert(form1);
            dao.Insert(form2);

            AssertQueryByDateRange(true, form1);
            AssertQueryByDateRange(true, form2);
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form1 = new FormGN75B(floc, floc.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                         Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8,new List<DevicePosition>(0),0,null,null);  //ayman Sarnia eip DMND0008992

            dao.Insert(form1);

            FormEdmontonGN75BDTO resultingDTO = dtoDao.QueryById(form1.IdValue);

            Assert.IsNotNull(resultingDTO);

            Assert.IsFalse(resultingDTO.Deleted);

            dao.Remove(form1);

            FormEdmontonGN75BDTO deletedDTO = dtoDao.QueryById(form1.IdValue);
            Assert.IsTrue(deletedDTO.Deleted);
        }

        private void AssertQueryByDateRange(bool exists, FormGN75B form)
        {
            FunctionalLocation functionalLocation = form.FunctionalLocation;
            List<FormEdmontonGN75BDTO> results = dtoDao.QueryDTOs(new RootFlocSet(functionalLocation), FormStatus.All,8);
            Assert.AreEqual(exists, results.Exists(obj => obj.Id == form.Id));
        }

    }
}