using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    public class UserDTODaoTest : AbstractDaoTest
    {
        private IUserDTODao userDTODao;
        private IFormOilsandsTrainingDao oilsandsTrainingDao;
        private ITrainingBlockDao trainingBlockDao;

        protected override void TestInitialize()
        {
            userDTODao = DaoRegistry.GetDao<IUserDTODao>();
            oilsandsTrainingDao = DaoRegistry.GetDao<IFormOilsandsTrainingDao>();
            trainingBlockDao = DaoRegistry.GetDao<ITrainingBlockDao>();
        }

        protected override void Cleanup()
        {        
        }

        [Ignore] [Test]
        public void ShouldReturnUsersWhoCreatedOilsandsTrainingForms()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_UP1() };

            TrainingBlock trainingBlock = trainingBlockDao.QueryById(TrainingBlockFixture.IdOfTrainingBlockInDatabase);
            User createUser = UserFixture.CreateUserWithGivenId(1);
            FormOilsandsTraining form = FormOilsandsTrainingFixture.CreateForInsert(functionalLocations, FormStatus.Draft, trainingBlock, createUser);            
            oilsandsTrainingDao.Insert(form);

            List<UserDTO> users = userDTODao.QueryUsersWhoHaveCreatedOilsandsTrainingForms();

            Assert.IsNotEmpty(users);
            Assert.IsTrue(users.Exists(u => u.IdValue == createUser.IdValue));
        }
    }
}
