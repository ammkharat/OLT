using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    public class TradeChecklistDaoTest : AbstractDaoTest
    {
        private IFormGN1Dao formGN1Dao;
        private ITradeChecklistDao tradeChecklistDao;

        protected override void TestInitialize()
        {
            tradeChecklistDao = DaoRegistry.GetDao<ITradeChecklistDao>();
            formGN1Dao = DaoRegistry.GetDao<IFormGN1Dao>();
        }

        protected override void Cleanup()
        {
            ;
        }

        [Ignore] [Test]          
        public void ShouldInsertAndQueryByFormGN1Id()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            form.TradeChecklists.Clear();
            formGN1Dao.Insert(form);

            DateTime now = Clock.Now;

            InsertThreeTradeChecklists(form, now);

            List<TradeChecklist> result = tradeChecklistDao.QueryByGN1Id(form.IdValue);

            Assert.AreEqual(3, result.Count);

            {
                TradeChecklist checklist1 = result.Find(tc => tc.Trade == "Buttercup collector");

                Assert.IsTrue(checklist1.ConstFieldMaintCoordApproval);
                Assert.IsTrue(checklist1.OpsCoordApproval);
                Assert.IsTrue(checklist1.AreaManagerApproval);

                Assert.AreEqual(form.Id, checklist1.ParentFormNumber);

                Assert.AreEqual(1, checklist1.ConstFieldMaintCoordApprover.IdValue);
                Assert.AreEqual(2, checklist1.OpsCoordApprover.IdValue);
                Assert.AreEqual(3, checklist1.AreaManagerApprover.IdValue);

                Assert.That(checklist1.ConstFieldMaintCoordApprovalDateTime, Is.EqualTo(now).Within(TimeSpan.FromSeconds(1)));
                Assert.That(checklist1.OpsCoordApprovalDateTime, Is.EqualTo(now.AddHours(1)).Within(TimeSpan.FromSeconds(1)));
                Assert.That(checklist1.AreaManagerApprovalDateTime, Is.EqualTo(now.AddHours(2)).Within(TimeSpan.FromSeconds(1)));

            }

            tradeChecklistDao.Remove(result[0]);
            result = tradeChecklistDao.QueryByGN1Id(form.IdValue);
            Assert.AreEqual(2, result.Count);
        }

        [Ignore] [Test]
        public void ShouldGetNextSequenceNumber()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            form.TradeChecklists.Clear();
            formGN1Dao.Insert(form);

            DateTime now = Clock.Now;

            InsertThreeTradeChecklists(form, now);

            int? maxValue = tradeChecklistDao.GetMaxSequenceNumber(form.IdValue);
            
            Assert.AreEqual(3, maxValue);            
        }

        [Ignore] [Test]          
        public void ShouldInsertNullApproverIds()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            form.TradeChecklists.Clear();
            formGN1Dao.Insert(form);

            DateTime now = Clock.Now;

            TradeChecklist forInsert = MakeATradeChecklistForInsert(form, now);
            forInsert.ClearConstFieldMaintCoordApproval();
            forInsert.ClearOpsCoordApproval();
            forInsert.ClearAreaManagerApproval();

            tradeChecklistDao.Insert(forInsert);

            List<TradeChecklist> result = tradeChecklistDao.QueryByGN1Id(form.IdValue);

            Assert.AreEqual(1, result.Count);

            Assert.IsNull(result[0].ConstFieldMaintCoordApprover);
            Assert.IsNull(result[0].OpsCoordApprover);
            Assert.IsNull(result[0].AreaManagerApprover);
        }

        [Ignore] [Test]
        public void ShouldDeleteByFormGN1Id()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            form.TradeChecklists.Clear();
            formGN1Dao.Insert(form);

            DateTime now = Clock.Now;

            InsertThreeTradeChecklists(form, now);
            
            List<TradeChecklist> result = tradeChecklistDao.QueryByGN1Id(form.IdValue);
            Assert.AreEqual(3, result.Count);
            
            tradeChecklistDao.DeleteByFormGN1Id(form.IdValue);

            result = tradeChecklistDao.QueryByGN1Id(form.IdValue);
            Assert.AreEqual(0, result.Count);
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            form.TradeChecklists.Clear();
            formGN1Dao.Insert(form);

            DateTime now = Clock.Now;

            InsertThreeTradeChecklists(form, now);

            List<TradeChecklist> result = tradeChecklistDao.QueryByGN1Id(form.IdValue);
            Assert.AreEqual(3, result.Count);

            TradeChecklist tcToRemove = result[0];
            tradeChecklistDao.Remove(tcToRemove);

            result = tradeChecklistDao.QueryByGN1Id(form.IdValue);
            Assert.AreEqual(2, result.Count);

            Assert.IsFalse(result.Exists(tc => tc.SequenceNumber == tcToRemove.SequenceNumber));
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            form.TradeChecklists.Clear();
            formGN1Dao.Insert(form);

            DateTime now = Clock.Now;            

            {
                TradeChecklist tradeChecklist = new TradeChecklist();
                tradeChecklist.SequenceNumber = 1;

                tradeChecklist.SetConstFieldMaintApproval(false, null, now);
                tradeChecklist.SetOpsCoordApproval(false, null, now);
                tradeChecklist.SetAreaManagerApproval(false, null, now);
               
                tradeChecklist.ParentFormNumber = form.IdValue;
                tradeChecklist.Content = "This is some content for the first item";
                tradeChecklist.PlainTextContent = "Plain text content for the first item";
                tradeChecklist.Trade = "Buttercup collector";
                tradeChecklist.LastModifiedDateTime = now;
                tradeChecklist.LastModifiedUser = UserFixture.CreateUserWithGivenId(1);
                tradeChecklistDao.Insert(tradeChecklist);
            }

            DateTime newLastModified = now.AddHours(1);

            {
                List<TradeChecklist> result = tradeChecklistDao.QueryByGN1Id(form.IdValue);
                TradeChecklist tcToUpdate = result[0];

                tcToUpdate.SetConstFieldMaintApproval(true, UserFixture.CreateUserWithGivenId(4), newLastModified);
                tcToUpdate.SetOpsCoordApproval(true, UserFixture.CreateUserWithGivenId(5), newLastModified);
                tcToUpdate.SetAreaManagerApproval(true, UserFixture.CreateUserWithGivenId(6), newLastModified);
               
                tcToUpdate.Content = "New content";
                tcToUpdate.PlainTextContent = "New plaintext content";
                tcToUpdate.Trade = "Space shuttle disaster myth debunker";
                tcToUpdate.LastModifiedDateTime = newLastModified;
                tcToUpdate.LastModifiedUser = UserFixture.CreateUserWithGivenId(2);

                tradeChecklistDao.Update(tcToUpdate);                
            }

            {
                TradeChecklist updatedTc = tradeChecklistDao.QueryByGN1Id(form.IdValue)[0];    

                Assert.IsTrue(updatedTc.ConstFieldMaintCoordApproval);
                Assert.IsTrue(updatedTc.OpsCoordApproval);
                Assert.IsTrue(updatedTc.AreaManagerApproval);

                Assert.AreEqual(4, updatedTc.ConstFieldMaintCoordApprover.IdValue);
                Assert.AreEqual(5, updatedTc.OpsCoordApprover.IdValue);
                Assert.AreEqual(6, updatedTc.AreaManagerApprover.IdValue);
                
                Assert.That(updatedTc.ConstFieldMaintCoordApprovalDateTime, Is.EqualTo(newLastModified).Within(TimeSpan.FromSeconds(1)));
                Assert.That(updatedTc.OpsCoordApprovalDateTime, Is.EqualTo(newLastModified).Within(TimeSpan.FromSeconds(1)));
                Assert.That(updatedTc.AreaManagerApprovalDateTime, Is.EqualTo(newLastModified).Within(TimeSpan.FromSeconds(1)));

                Assert.AreEqual("New content", updatedTc.Content);
                Assert.AreEqual("New plaintext content", updatedTc.PlainTextContent);
                Assert.AreEqual("Space shuttle disaster myth debunker", updatedTc.Trade);                
                Assert.That(updatedTc.LastModifiedDateTime, Is.EqualTo(newLastModified).Within(1).Seconds);
                Assert.AreEqual(2, updatedTc.LastModifiedUser.IdValue);
            }            
        }

        private void InsertThreeTradeChecklists(FormGN1 form, DateTime now)
        {
            {
                TradeChecklist tradeChecklist = MakeATradeChecklistForInsert(form, now);
                tradeChecklistDao.Insert(tradeChecklist);
            }

            {
                TradeChecklist tradeChecklist = new TradeChecklist();
                tradeChecklist.SequenceNumber = 2;

                tradeChecklist.SetConstFieldMaintApproval(false, UserFixture.CreateUserWithGivenId(1), now);
                tradeChecklist.SetOpsCoordApproval(true, UserFixture.CreateUserWithGivenId(2), now);
                tradeChecklist.SetAreaManagerApproval(true, UserFixture.CreateUserWithGivenId(3), now);

                tradeChecklist.ParentFormNumber = form.IdValue;
                tradeChecklist.Trade = "Honey Truck Operator";
                tradeChecklist.Content = "This is some content for the second item";
                tradeChecklist.PlainTextContent = "Plain text content for the second item";
                tradeChecklist.LastModifiedDateTime = now;
                tradeChecklist.LastModifiedUser = UserFixture.CreateUserWithGivenId(2);
                tradeChecklistDao.Insert(tradeChecklist);
            }

            {
                TradeChecklist tradeChecklist = new TradeChecklist();
                tradeChecklist.SequenceNumber = 3;

                tradeChecklist.SetConstFieldMaintApproval(false, UserFixture.CreateUserWithGivenId(1), now);
                tradeChecklist.SetOpsCoordApproval(false, UserFixture.CreateUserWithGivenId(2), now);
                tradeChecklist.SetAreaManagerApproval(false, UserFixture.CreateUserWithGivenId(3), now);

                tradeChecklist.ParentFormNumber = form.IdValue;
                tradeChecklist.Trade = "Geophone Placement Engineer";
                tradeChecklist.Content = "This is some content for the third item";
                tradeChecklist.PlainTextContent = "Plain text content for the third item";
                tradeChecklist.LastModifiedDateTime = now;
                tradeChecklist.LastModifiedUser = UserFixture.CreateUserWithGivenId(3);
                tradeChecklistDao.Insert(tradeChecklist);
            }
        }

        private static TradeChecklist MakeATradeChecklistForInsert(FormGN1 form, DateTime now)
        {
            TradeChecklist tradeChecklist = new TradeChecklist();
            tradeChecklist.SequenceNumber = 1;

            tradeChecklist.SetConstFieldMaintApproval(true, UserFixture.CreateUserWithGivenId(1), now);
            tradeChecklist.SetOpsCoordApproval(true, UserFixture.CreateUserWithGivenId(2), now.AddHours(1));
            tradeChecklist.SetAreaManagerApproval(true, UserFixture.CreateUserWithGivenId(3), now.AddHours(2));         

            tradeChecklist.ParentFormNumber = form.IdValue;
            tradeChecklist.Content = "This is some content for the first item";
            tradeChecklist.PlainTextContent = "Plain text content for the first item";
            tradeChecklist.Trade = "Buttercup collector";
            tradeChecklist.LastModifiedDateTime = now;
            tradeChecklist.LastModifiedUser = UserFixture.CreateUserWithGivenId(1);
            return tradeChecklist;
        }
    }
}
