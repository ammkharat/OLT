using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class TradeChecklistTest
    {
        [Test]
        public void ShouldClone()
        {
            var tc = CreateFakeTradeChecklist();

            tc.ConvertToClone(UserFixture.CreateUserWithGivenId(1));

            Assert.IsNull(tc.Id);
            Assert.IsNotNull(tc.Trade);
            Assert.AreEqual(1, tc.LastModifiedUser.Id);
            Assert.IsFalse(tc.AreaManagerApproval);
            Assert.IsFalse(tc.OpsCoordApproval);
            Assert.IsFalse(tc.ConstFieldMaintCoordApproval);
        }

        [Test]
        public void ShouldCopyUsingCopyConstructor()
        {
            var tc = CreateFakeTradeChecklist();
            var newTc = new TradeChecklist(tc);

            Assert.AreEqual(tc.SequenceNumber, newTc.SequenceNumber);
            Assert.AreEqual(tc.ConstFieldMaintCoordApproval, newTc.ConstFieldMaintCoordApproval);
            Assert.AreEqual(tc.OpsCoordApproval, newTc.OpsCoordApproval);
            Assert.AreEqual(tc.AreaManagerApproval, newTc.AreaManagerApproval);
            Assert.AreEqual(tc.Content, newTc.Content);
            Assert.AreEqual(tc.PlainTextContent, newTc.PlainTextContent);
            Assert.AreEqual(tc.ParentFormNumber, newTc.ParentFormNumber);
            Assert.AreEqual(tc.Trade, newTc.Trade);
            Assert.AreEqual(tc.LastModifiedUser, newTc.LastModifiedUser);
            Assert.AreEqual(tc.LastModifiedDateTime, newTc.LastModifiedDateTime);
        }

        [Test]
        public void ShouldDetermineIfChangedForApprovals()
        {
            var tcOriginal = CreateFakeTradeChecklist();

            {
                var tcCopy = new TradeChecklist(tcOriginal);
                Assert.IsTrue(tcOriginal.AreSameForApprovals(tcCopy));
            }

            // I commented these out because approvals are different than regular data.
            //{
            //    TradeChecklist tcCopy = new TradeChecklist(tcOriginal);
            //    tcCopy.OpsCoordApproval = !tcCopy.OpsCoordApproval;
            //    Assert.IsFalse(tcOriginal.AreSameForApprovals(tcCopy));                
            //}

            //{
            //    TradeChecklist tcCopy = new TradeChecklist(tcOriginal);
            //    tcCopy.ConstFieldMaintCoordApproval = !tcCopy.ConstFieldMaintCoordApproval;
            //    Assert.IsFalse(tcOriginal.AreSameForApprovals(tcCopy));                
            //}

            //{
            //    TradeChecklist tcCopy = new TradeChecklist(tcOriginal);
            //    tcCopy.AreaManagerApproval = !tcCopy.AreaManagerApproval;
            //    Assert.IsFalse(tcOriginal.AreSameForApprovals(tcCopy));                
            //}

            {
                var tcCopy = new TradeChecklist(tcOriginal);
                tcCopy.PlainTextContent = "asdfasf";
                Assert.IsFalse(tcOriginal.AreSameForApprovals(tcCopy));
            }

            {
                var tcCopy = new TradeChecklist(tcOriginal);
                tcCopy.Trade = "123123123123abcabc";
                Assert.IsFalse(tcOriginal.AreSameForApprovals(tcCopy));
            }
        }

        [Test]
        public void ShouldDetermineNextSequenceNumber()
        {
            var checklist1 = new TradeChecklist {SequenceNumber = 1};
            var checklist2 = new TradeChecklist {SequenceNumber = 2};
            var checklist3 = new TradeChecklist {SequenceNumber = 3};
            var checklist5 = new TradeChecklist {SequenceNumber = 5};

            // Nothing in the list, so start with 1
            Assert.AreEqual(1, TradeChecklist.GetNextSequenceNumber(new List<TradeChecklist>()));

            // Highest one is 3, so next number should be 4
            Assert.AreEqual(4, TradeChecklist.GetNextSequenceNumber(new List<TradeChecklist> {checklist1, checklist2, checklist3}));

            // Test with missing values
            Assert.AreEqual(6, TradeChecklist.GetNextSequenceNumber(new List<TradeChecklist> {checklist1, checklist2, checklist5}));
        }

        [Test]
        public void ShouldGreatApprovalHistoryText()
        {
            var tc1 = CreateFakeTradeChecklist();
            tc1.SequenceNumber = 1;

            var tc2 = CreateFakeTradeChecklist();
            tc2.SequenceNumber = 2;

            var tc3 = CreateFakeTradeChecklist();
            tc3.SequenceNumber = 3;

            var tcList = new List<TradeChecklist> {tc1, tc2, tc3};

            var result = TradeChecklist.BuildApprovalsHistoryString(tcList);
        }

        private static TradeChecklist CreateFakeTradeChecklist()
        {
            var lastModifiedDateTime = new DateTime(2014, 3, 3, 1, 2, 3);

            var tc = new TradeChecklist();
            tc.SequenceNumber = 42;

            tc.SetConstFieldMaintApproval(true, UserFixture.CreateUserWithGivenId(1), lastModifiedDateTime);
            tc.SetConstFieldMaintApproval(false, UserFixture.CreateUserWithGivenId(2), lastModifiedDateTime);
            tc.SetConstFieldMaintApproval(true, UserFixture.CreateUserWithGivenId(3), lastModifiedDateTime);

            tc.Content = "this is content";
            tc.PlainTextContent = "This is plain text content";
            tc.ParentFormNumber = 123;
            tc.Trade = "This is the trade";
            tc.LastModifiedUser = UserFixture.CreateUserWithGivenId(456);
            tc.LastModifiedDateTime = lastModifiedDateTime;
            return tc;
        }
    }
}