using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class TagInfoGroupServiceTest
    {
        private Mockery mocks;
        private ITagGroupDao mockTagGroupDao;
        private ITagInfoGroupService service;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockTagGroupDao = mocks.NewMock<ITagGroupDao>();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockTagGroupDao);

            service = new TagInfoGroupService();
        }

        [Ignore] [Test]
        public void ShouldDelegateToDaoOnCallingIsNameUniqueToSite()
        {
            const string name = "Some Name";
            Site site = SiteFixture.Sarnia();
            Expect.Once.On(mockTagGroupDao).Method("IsNameUniqueToSite").With(name, site).Will(Return.Value(true));
            service.IsNameUniqueToSite(name, site);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        #region Insert Tests

        private void ShouldDelegateInsertToDaoTest(bool isNameUniqueToSite)
        {
            TagInfoGroup tagInfoGroup = TagInfoGroupFixture.CreateNewSarniaTagInfoGroup();
            Expect.Once.On(mockTagGroupDao).Method("IsNameUniqueToSite")
                .With(tagInfoGroup.Name, tagInfoGroup.Site)
                .Will(Return.Value(isNameUniqueToSite));

            if ( isNameUniqueToSite )
                Expect.Once.On(mockTagGroupDao).Method("Insert").With(tagInfoGroup).Will(Return.Value(tagInfoGroup));

            service.Insert(tagInfoGroup);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertTagInfoGroupWithUniqueName()
        {
            const bool isNameUniqueToSite = true;
            ShouldDelegateInsertToDaoTest(isNameUniqueToSite);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(TagInfoGroupNameUniquenessException))]
        public void ShouldThrowExceptionWhenTryingToInsertTagInfoGroupWithExistingName()
        {
            const bool isNameUniqueToSite = false;
            ShouldDelegateInsertToDaoTest(isNameUniqueToSite);
        }

        #endregion

        #region Update Tests

        private void ShouldUpdateOnlyIfNameIsUnique(bool hasNameChanged, bool? isNewNameUnique)
        {
            TagInfoGroup groupBeforeUpdate = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            var groupToBeUpdated = new TagInfoGroup(groupBeforeUpdate.Id, groupBeforeUpdate.Name, groupBeforeUpdate.Site)
                                       {
                                           Name =
                                               (hasNameChanged == false
                                                    ? groupBeforeUpdate.Name
                                                    : groupBeforeUpdate.Name + "new")
                                       };

            Expect.Once.On(mockTagGroupDao).Method("QueryById")
                .With(groupToBeUpdated.Id.Value).Will(Return.Value(groupBeforeUpdate));

            if ( hasNameChanged )
                Expect.Once.On(mockTagGroupDao).Method("IsNameUniqueToSite").With(groupToBeUpdated.Name, groupToBeUpdated.Site).Will(Return.Value(isNewNameUnique.Value));

            if ( hasNameChanged == false || isNewNameUnique.Value)
                Expect.Once.On(mockTagGroupDao).Method("Update").With(groupToBeUpdated);

            service.Update(groupToBeUpdated);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateIfNameHasChangedAndNewNameIsUnique()
        {
            const bool hasNameChanged = true;
            bool? isNewNameUnique = true;
            ShouldUpdateOnlyIfNameIsUnique(hasNameChanged, isNewNameUnique);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(TagInfoGroupNameUniquenessException))]
        public void ShouldNotUpdateIfNameHasChangedAndNewNameIsNotUnique()
        {
            const bool hasNameChanged = true;
            bool? isNewNameUnique = false;
            ShouldUpdateOnlyIfNameIsUnique(hasNameChanged, isNewNameUnique);
        }

        [Ignore] [Test]
        public void ShouldNotCheckForNameUniquenessIfNameHasNotChanged()
        {
            const bool hasNameChanged = false;
            bool? isNewNameUnique = null;
            ShouldUpdateOnlyIfNameIsUnique(hasNameChanged, isNewNameUnique);
        }

        [Ignore] [Test]
        [ExpectedException(typeof(InconsistentTagInfoGroupDataException))]
        public void ShouldThrowExceptionWhenTagInfoAndTagInfoGroupHaveDifferentSite()
        {
            TagInfoGroup invalidGroup = TagInfoGroupFixture.CreateInvalidTagInfoGroup();
            service.Update(invalidGroup);
        }
        
        #endregion
    }
}
