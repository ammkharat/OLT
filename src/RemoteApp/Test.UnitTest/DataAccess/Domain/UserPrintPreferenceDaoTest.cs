using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class UserPrintPreferenceDaoTest : AbstractDaoTest
    {
        private User user;
        private UserPrintPreference preferenceToInsert;
        private UserPrintPreference dataBasePreference;
        private IUserPrintPreferenceDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IUserPrintPreferenceDao>();
            user = DaoRegistry.GetDao<IUserDao>().Insert(UserFixture.CreateSupervisor(1, UserFixture.CreateRandomUserName()));
            preferenceToInsert = UserPrintPreferenceFixture.CreateWorkPermitPrintPreference(user);
        }

        protected override void Cleanup()
        {
            //do nothing
        }

        private void InsertPreferenceIntoDatabase()
        {
            dataBasePreference = dao.Insert(preferenceToInsert);
        }

        [Ignore] [Test]
        public void ShouldInsertUserPrintPreference()
        {
            InsertPreferenceIntoDatabase();
            Assert.IsNotNull(dataBasePreference);
            Assert.AreEqual(preferenceToInsert.UserId, dataBasePreference.UserId);
            Assert.AreEqual(preferenceToInsert.PrinterName, dataBasePreference.PrinterName);
            Assert.AreEqual(preferenceToInsert.NumberOfCopies, dataBasePreference.NumberOfCopies);
            Assert.AreEqual(preferenceToInsert.ShowPrintDialog, dataBasePreference.ShowPrintDialog);
        }

        [Ignore] [Test]
        public void ShouldUpdateUserPrintPreference()
        {
            const string printerName = "NewPrinter";
            const int numCopies = 1;
            const bool showDialog = true;
            InsertPreferenceIntoDatabase();
            dataBasePreference.PrinterName = printerName;
            dataBasePreference.NumberOfCopies = numCopies;
            dataBasePreference.ShowPrintDialog = showDialog;
            dao.Update(dataBasePreference);
            Assert.AreEqual(printerName, dataBasePreference.PrinterName);
            Assert.AreEqual(numCopies, dataBasePreference.NumberOfCopies);
            Assert.AreEqual(showDialog, dataBasePreference.ShowPrintDialog);
        }

        [Ignore] [Test]
        public void ShouldQueryByUserId()
        {
            InsertPreferenceIntoDatabase();
            UserPrintPreference found = dao.QueryByUserId(user.IdValue);
            Assert.IsNotNull(found);
            Assert.AreEqual(dataBasePreference.Id, found.Id);
            Assert.AreEqual(dataBasePreference.UserId, found.UserId);
            Assert.AreEqual(dataBasePreference.PrinterName, found.PrinterName);
            Assert.AreEqual(dataBasePreference.NumberOfCopies, found.NumberOfCopies);
            Assert.AreEqual(dataBasePreference.ShowPrintDialog, found.ShowPrintDialog);
        }

        [Ignore] [Test]
        public void ShouldRemoveUserPrintPreference()
        {
            InsertPreferenceIntoDatabase();
            dao.Remove(dataBasePreference);
            int count = TestDataAccessUtil.ExecuteScalarExpression<int>(
                    string.Format("select count(*) from [UserPrintPreference] where id = {0}", dataBasePreference.Id)
                    );
            Assert.IsTrue(count == 0);
        }
    }
}