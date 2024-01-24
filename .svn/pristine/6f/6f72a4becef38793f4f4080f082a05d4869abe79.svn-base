using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class TradeChecklist : DomainObject
    {
        private static readonly IEqualityComparer<TradeChecklist> TradeComparerInstance = new TradeEqualityComparer();

        public TradeChecklist()
        {
            ConstFieldMaintCoordApprover = null;
            OpsCoordApprover = null;
            AreaManagerApprover = null;
        }

        public TradeChecklist(TradeChecklist tradeChecklist) : this()
        {
            id = tradeChecklist.Id;

            SequenceNumber = tradeChecklist.SequenceNumber;

            ConstFieldMaintCoordApproval = tradeChecklist.ConstFieldMaintCoordApproval;
            OpsCoordApproval = tradeChecklist.OpsCoordApproval;
            AreaManagerApproval = tradeChecklist.AreaManagerApproval;

            ConstFieldMaintCoordApprover = tradeChecklist.ConstFieldMaintCoordApprover;
            OpsCoordApprover = tradeChecklist.OpsCoordApprover;
            AreaManagerApprover = tradeChecklist.AreaManagerApprover;

            ConstFieldMaintCoordApprovalDateTime = tradeChecklist.ConstFieldMaintCoordApprovalDateTime;
            OpsCoordApprovalDateTime = tradeChecklist.OpsCoordApprovalDateTime;
            AreaManagerApprovalDateTime = tradeChecklist.AreaManagerApprovalDateTime;

            Content = tradeChecklist.Content;
            PlainTextContent = tradeChecklist.PlainTextContent;

            ParentFormNumber = tradeChecklist.ParentFormNumber;

            Trade = tradeChecklist.Trade;

            LastModifiedUser = tradeChecklist.LastModifiedUser;
            LastModifiedDateTime = tradeChecklist.LastModifiedDateTime;
        }

        public static IEqualityComparer<TradeChecklist> TradeComparer
        {
            get { return TradeComparerInstance; }
        }

        public int SequenceNumber { get; set; }

        public bool ConstFieldMaintCoordApproval { get; set; }
        public User ConstFieldMaintCoordApprover { get; private set; }
        public DateTime? ConstFieldMaintCoordApprovalDateTime { get; private set; }

        public bool OpsCoordApproval { get; set; }
        public User OpsCoordApprover { get; private set; }
        public DateTime? OpsCoordApprovalDateTime { get; private set; }

        public bool AreaManagerApproval { get; set; }
        public User AreaManagerApprover { get; private set; }
        public DateTime? AreaManagerApprovalDateTime { get; private set; }

        public string Content { get; set; }
        public string PlainTextContent { get; set; }

        public long? ParentFormNumber { get; set; }

        public string Trade { get; set; }

        public User LastModifiedUser { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        public string TradeChecklistDisplayNumber
        {
            get { return string.Format("C{0}", SequenceNumber); }
        }

        public string TradeChecklistInformationDisplayText
        {
            get
            {
                if (ParentFormNumber != null)
                {
                    return string.Format("{0}-{1}", ParentFormNumber, TradeChecklistDisplayNumber);
                }

                return TradeChecklistDisplayNumber;
            }
        }

        public bool IsApproved
        {
            get { return ConstFieldMaintCoordApproval && OpsCoordApproval && AreaManagerApproval; }
        }

        public void SetConstFieldMaintApproval(bool approved, User approver, DateTime? approvalDateTime)
        {
            ConstFieldMaintCoordApproval = approved;
            ConstFieldMaintCoordApprover = approver;
            ConstFieldMaintCoordApprovalDateTime = approvalDateTime;
        }

        public void SetOpsCoordApproval(bool approved, User approver, DateTime? approvalDateTime)
        {
            OpsCoordApproval = approved;
            OpsCoordApprover = approver;
            OpsCoordApprovalDateTime = approvalDateTime;
        }

        public void SetAreaManagerApproval(bool approved, User approver, DateTime? approvalDateTime)
        {
            AreaManagerApproval = approved;
            AreaManagerApprover = approver;
            AreaManagerApprovalDateTime = approvalDateTime;
        }

        public static int GetNextSequenceNumber(List<TradeChecklist> tradeChecklists)
        {
            if (tradeChecklists.Count == 0)
            {
                return 1;
            }

            var temporaryList = new List<TradeChecklist>(tradeChecklists);
            temporaryList.Sort((x, y) => y.SequenceNumber.CompareTo(x.SequenceNumber));
            return temporaryList[0].SequenceNumber + 1;
        }

        public bool AreSameForApprovals(TradeChecklist otherTradeChecklist)
        {
            var plainTextContentSame = Equals(PlainTextContent, otherTradeChecklist.PlainTextContent);
            var tradeSame = Equals(Trade, otherTradeChecklist.Trade);

            return plainTextContentSame && tradeSame;
        }

        public bool HasApprovalByOtherPeople(User user)
        {
            var constApprovedBySomeoneElse = ConstFieldMaintCoordApprover != null &&
                                             (ConstFieldMaintCoordApprover.IdValue != user.IdValue);
            var opsCoordApprovedBySomeoneElse = OpsCoordApprover != null && (OpsCoordApprover.IdValue != user.IdValue);
            var areaManagerApprovedBySomeoneElse = AreaManagerApprover != null &&
                                                   (AreaManagerApprover.IdValue != user.IdValue);

            return constApprovedBySomeoneElse || opsCoordApprovedBySomeoneElse || areaManagerApprovedBySomeoneElse;
        }

        public bool HasAtLeastOneApproval()
        {
            return ConstFieldMaintCoordApproval || OpsCoordApproval || AreaManagerApproval;
        }

        public void UnapproveApprovalsNotByUser(User user)
        {
            if (ConstFieldMaintCoordApprover != null && ConstFieldMaintCoordApprover.IdValue != user.IdValue)
            {
                ClearConstFieldMaintCoordApproval();
            }

            if (OpsCoordApprover != null && OpsCoordApprover.IdValue != user.IdValue)
            {
                ClearOpsCoordApproval();
            }

            if (AreaManagerApprover != null && AreaManagerApprover.IdValue != user.IdValue)
            {
                ClearAreaManagerApproval();
            }
        }

        public void ClearConstFieldMaintCoordApproval()
        {
            ConstFieldMaintCoordApprover = null;
            ConstFieldMaintCoordApproval = false;
            ConstFieldMaintCoordApprovalDateTime = null;
        }

        public void ClearOpsCoordApproval()
        {
            OpsCoordApprover = null;
            OpsCoordApproval = false;
            OpsCoordApprovalDateTime = null;
        }

        public void ClearAreaManagerApproval()
        {
            AreaManagerApprover = null;
            AreaManagerApproval = false;
            AreaManagerApprovalDateTime = null;
        }

        public static string BuildHistoryString(List<TradeChecklist> tradeChecklists)
        {
            var items = new List<TradeChecklist>(tradeChecklists);
            items.Sort((x, y) => x.SequenceNumber.CompareTo(y.SequenceNumber));
            return items.AsString(tc => tc.TradeChecklistDisplayNumber);
        }

        public static string BuildApprovalsHistoryString(List<TradeChecklist> tradeChecklists)
        {
            var items = tradeChecklists.FindAll(tc => tc.HasAtLeastOneApproval());
            items.Sort((x, y) => x.SequenceNumber.CompareTo(y.SequenceNumber));

            return items.AsString(tc => tc.GetApprovalHistoryString());
        }

        private string GetApprovalHistoryString()
        {
            var textForOneApproval = new List<string>();

            if (ConstFieldMaintCoordApproval)
            {
                textForOneApproval.Add(GetApprovalString(FormGN1.ConstFieldMaintCoordApprovalName,
                    ConstFieldMaintCoordApprover));
            }

            if (OpsCoordApproval)
            {
                textForOneApproval.Add(GetApprovalString(FormGN1.OpsCoordApprovalName, OpsCoordApprover));
            }

            if (AreaManagerApproval)
            {
                textForOneApproval.Add(GetApprovalString(FormGN1.AreaManagerApprovalName, AreaManagerApprover));
            }

            return textForOneApproval.AsString(s => s);
        }

        private string GetApprovalString(string approverPosition, User approver)
        {
            return string.Format("{0} - {1} ({2})", TradeChecklistDisplayNumber, approverPosition, approver.Username);
        }

        public void ConvertToClone(User user)
        {
            Id = null;

            LastModifiedDateTime = Clock.Now;
            LastModifiedUser = user;
            ClearConstFieldMaintCoordApproval();
            ClearOpsCoordApproval();
            ClearAreaManagerApproval();
        }

        public TradeChecklistHistory TakeSnapshot()
        {
            return new TradeChecklistHistory(IdValue, Trade, PlainTextContent, LastModifiedUser, LastModifiedDateTime);
        }

        private sealed class TradeEqualityComparer : IEqualityComparer<TradeChecklist>
        {
            public bool Equals(TradeChecklist x, TradeChecklist y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Trade, y.Trade);
            }

            public int GetHashCode(TradeChecklist obj)
            {
                return (obj.Trade != null ? obj.Trade.GetHashCode() : 0);
            }
        }
    }
}