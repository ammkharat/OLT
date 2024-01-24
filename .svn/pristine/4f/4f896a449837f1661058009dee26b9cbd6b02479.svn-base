using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class FormGN75BDaoTest : AbstractDaoTest
    {
        private IFormGN75BDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN75BDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertWithImage()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form = new FormGN75B(functionalLocation, functionalLocation.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                                     Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8,new List<DevicePosition>(0),0,null,null);  //ayman Sarnia eip DMND0008992

            const string path = @"Untitled.png";
            byte[] image = File.ReadAllBytes(path);
            form.AddSchematic(path, image);
            dao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));
            Assert.That(form.FormNumber, Is.GreaterThan(0));

            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void ShouldInsertWithoutImage()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form = new FormGN75B(functionalLocation, functionalLocation.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                                     Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8,new List<DevicePosition>(0),0,null,null);   //ayman Sarnia eip DMND0008992

            dao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));
            Assert.That(form.FormNumber, Is.GreaterThan(0));

            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void ShouldRemoveAndMarkAsDeleted()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form = new FormGN75B(functionalLocation, functionalLocation.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                                     Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8,new List<DevicePosition>(0),0,null,null);   //ayman Sarnia eip DMND0008992

            dao.Insert(form);
            
            FormGN75B requeriedForm = dao.QueryById(form.IdValue);
            Assert.IsFalse(requeriedForm.IsDeleted);                
            
            dao.Remove(form);

            FormGN75B removedForm = dao.QueryById(form.IdValue);
            Assert.IsTrue(removedForm.IsDeleted);            
        }

        [Ignore] [Test]
        public void ShouldInsertWithIsolationItems()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            List<IsolationItem> IsolationItems = new List<IsolationItem>
                {
                    new IsolationItem(null, null, 1, "who cares", "all over the place","",0),            //ayman Sarnia eip DMND0008992
                    new IsolationItem(null, null, 2, "who cares", "some other place","",0)               //ayman Sarnia eip DMND0008992
                };

            FormGN75B form = new FormGN75B(functionalLocation, "", null, null, Clock.Now,UserFixture.CreateUserWithGivenId(1),Clock.Now,false,false,false, string.Empty,string.Empty,string.Empty,8, null, 0,null,null);  //ayman Sarnia eip DMND0008992

            dao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));
            Assert.That(form.FormNumber, Is.GreaterThan(0));

            RequeryAndAssertFieldsAreEqual(form);
            
        }

        [Ignore] [Test]
        public void ShouldUpdateFormGn75B()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            List<IsolationItem> IsolationItems = new List<IsolationItem>
                {
                    new IsolationItem(null, null, 1, "who cares", "all over the place","",0),              //ayman Sarnia eip DMND0008992
                    new IsolationItem(null, null, 2, "who cares", "some other place","",0)                 //ayman Sarnia eip DMND0008992
                };

            FormGN75B form = new FormGN75B(functionalLocation, "", null, null, Clock.Now, UserFixture.CreateUserWithGivenId(1), Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty, 8, null, 0,null,null);   //ayman Sarnia eip DMND0008992

            dao.Insert(form);
            form.LockBoxLocation = "lockboxlocation";
            form.LockBoxNumber = "12345";
            form.MarkAsClosed(Clock.Now, UserFixture.CreateUserWithGivenId(1));

            dao.Update(form);
            form = RequeryAndAssertFieldsAreEqual(form);

            form.IsolationItems.Add(new IsolationItem(null, form.Id, 3, "isolation type 3", "location 3","",0));               //ayman Sarnia eip DMND0008992
            dao.Update(form);
            form = RequeryAndAssertFieldsAreEqual(form);

            IsolationItem isolationItem = form.IsolationItems[0];
            isolationItem.IsolationType = "type 4";
            isolationItem.LocationOfEnergyIsolation = "location 4";
            dao.Update(form);
            form = RequeryAndAssertFieldsAreEqual(form);

            form.IsolationItems.Clear();
            dao.Update(form);
            form = RequeryAndAssertFieldsAreEqual(form);
            CollectionAssert.IsEmpty(form.IsolationItems);
        }

        private FormGN75B RequeryAndAssertFieldsAreEqual(FormGN75B form)
        {
            FormGN75B requeried = dao.QueryById(form.IdValue);

            Assert.IsNotNull(requeried);

            Assert.AreEqual(form.BlindsRequired, requeried.BlindsRequired);
            Assert.That(form.ClosedDateTime, Is.EqualTo(requeried.ClosedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(form.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            Assert.That(form.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(1)));
            
            Assert.AreEqual(form.FormStatus, requeried.FormStatus);
            Assert.AreEqual(form.FormNumber, requeried.FormNumber);

            Assert.AreEqual(form.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.That(form.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.FunctionalLocation, requeried.FunctionalLocation);
            CollectionAssert.AreEquivalent(form.DocumentLinks, requeried.DocumentLinks);

            Assert.AreEqual(form.SchematicImage, requeried.SchematicImage);
            Assert.AreEqual(form.PathToSchematic, requeried.PathToSchematic);
            CollectionAssert.AreEqual(form.IsolationItems, requeried.IsolationItems, new IsolationComparer());
            Assert.AreEqual(form.LockBoxLocation, requeried.LockBoxLocation);
            Assert.AreEqual(form.LockBoxNumber, requeried.LockBoxNumber);
            return requeried;
        }

        private class IsolationComparer : IComparer<IsolationItem>, IComparer
        {
            // in this case we only care if they are equal or not.
            public int Compare(IsolationItem x, IsolationItem y)
            {
                int compareTo;
                if (x.Id.HasValue && y.Id.HasValue && (compareTo = Nullable.Compare(x.Id, y.Id)) != 0)
                {
                    return compareTo;
                }

                if (x.FormGn75BId.HasValue && y.FormGn75BId.HasValue && (compareTo = Nullable.Compare(x.FormGn75BId, y.FormGn75BId)) != 0)
                {
                    return compareTo;
                }
                if ((compareTo = x.DisplayOrder.CompareTo(y.DisplayOrder)) != 0)
                    return compareTo;

                if ((compareTo = string.Compare(x.IsolationType, y.IsolationType, StringComparison.Ordinal)) != 0)
                    return compareTo;
                
                return string.Compare(x.LocationOfEnergyIsolation, y.LocationOfEnergyIsolation, StringComparison.Ordinal);
            }

            public int Compare(object x, object y)
            {
                if (x is IsolationItem && y is IsolationItem)
                {
                    IsolationItem xItem = (IsolationItem) x;
                    IsolationItem yItem = (IsolationItem) y;
                    return Compare(xItem, yItem);
                }
                    
                throw new Exception("some item is not of type IsolationType");
            }
        }

        [Ignore] [Test]
        public void ShouldInsertGN75UserReadDocumentLinkAssociation()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form = new FormGN75B(functionalLocation, "", null, null, Clock.Now, UserFixture.CreateUserWithGivenId(1), Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty, 8, null, 0,null,null);    //ayman Sarnia eip DMND0008992

            dao.Insert(form);

            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
           
            dao.Insert(form);
            Assert.IsFalse(dao.HasUserReadAtLeastOneDocumentLink(user.IdValue, form.IdValue));
            dao.InsertUserReadDocumentLinkAssociation(user.IdValue, form.IdValue);
            Assert.IsTrue(dao.HasUserReadAtLeastOneDocumentLink(user.IdValue, form.IdValue));
        }

    }
}