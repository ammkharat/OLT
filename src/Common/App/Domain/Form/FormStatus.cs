using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormStatus : SortableSimpleDomainObject
    {
        public static readonly FormStatus Draft = new FormStatus(1, 1);
        public static readonly FormStatus Approved = new FormStatus(2, 2);
        public static readonly FormStatus Closed = new FormStatus(3, 3);
        public static readonly FormStatus Cancelled = new FormStatus(4, 4);
        public static readonly FormStatus Expired = new FormStatus(5, 5);

        public static readonly FormStatus InitialReview = new FormStatus(6, 6);
        public static readonly FormStatus OwnerReview = new FormStatus(7, 7);
        public static readonly FormStatus RevisionInProgress = new FormStatus(8, 8);
        public static readonly FormStatus DocumentIssued = new FormStatus(9, 9);
        public static readonly FormStatus DocumentArchived = new FormStatus(10, 10);
        public static readonly FormStatus NotApproved = new FormStatus(11, 11);
        public static readonly FormStatus Late = new FormStatus(12, 12);
        public static readonly FormStatus ExtensionReview = new FormStatus(13, 13);
        public static readonly FormStatus Complete = new FormStatus(14, 14);

        public static readonly FormStatus WaitingForApproval = new FormStatus(15, 15); // Swapnil Patki For DMND0005325 Point Number 7

        private static readonly FormStatus[] all =
        {
            Draft, Approved, Closed, Cancelled, Expired, InitialReview,
            OwnerReview, RevisionInProgress, DocumentIssued, DocumentArchived, 
            NotApproved, Late, ExtensionReview, Complete,WaitingForApproval
        };

        private FormStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public static List<FormStatus> All
        {
            get { return new List<FormStatus>(all); }
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.FormStatus_Draft;
            }
            if (IdValue == 2)
            {
                return StringResources.FormStatus_Approved;
            }
            if (IdValue == 3)
            {
                return StringResources.FormStatus_Closed;
            }
            if (IdValue == 4)
            {
                return StringResources.FormStatus_Cancelled;
            }
            if (IdValue == 5)
            {
                return StringResources.FormStatus_Expired;
            }
            if (IdValue == 6)
            {
                return StringResources.FormStatus_InitialReview;
            }
            if (IdValue == 7)
            {
                return StringResources.FormStatus_OwnerReview;
            }
            if (IdValue == 8)
            {
                return StringResources.FormStatus_RevisionInProgress;
            }
            if (IdValue == 9)
            {
                return StringResources.FormStatus_DocumentIssued;
            }
            if (IdValue == 10)
            {
                return StringResources.FormStatus_DocumentArchived;
            }
            if (IdValue == 11)
            {
                return StringResources.FormStatus_NotApproved;
            }
            if (IdValue == 12)
            {
                return StringResources.FormStatus_Late;
            }
            if (IdValue == 13)
            {
                return StringResources.FormStatus_ExtensionReview;
            }
            if (IdValue == 14)
            {
                return StringResources.FormStatus_Complete;
            }
            if (IdValue == 15) // Swapnil Patki For DMND0005325 Point Number 7
            {
                return StringResources.FormStatus_WaitingForApproval;
            }

            return null;
        }

        public static FormStatus GetById(long id)
        {
            return GetById(id, all);
        }
    }
}