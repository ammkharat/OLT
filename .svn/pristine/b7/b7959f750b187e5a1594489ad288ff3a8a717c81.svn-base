using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     This is the Status class for Permits using the Pull model.  The old way, Sarnia and Denver, use the Work Permit
    ///     status class.
    /// </summary>
    [Serializable]
    public class PermitRequestBasedWorkPermitStatus : SortableSimpleDomainObject
    {
        public static PermitRequestBasedWorkPermitStatus Requested = new PermitRequestBasedWorkPermitStatus(1, 1);
        public static PermitRequestBasedWorkPermitStatus Pending = new PermitRequestBasedWorkPermitStatus(2, 2);
        public static PermitRequestBasedWorkPermitStatus Issued = new PermitRequestBasedWorkPermitStatus(3, 3);

        // Terminating states
        public static PermitRequestBasedWorkPermitStatus Complete = new PermitRequestBasedWorkPermitStatus(4, 4);
        public static PermitRequestBasedWorkPermitStatus Void = new PermitRequestBasedWorkPermitStatus(5, 5);
        public static PermitRequestBasedWorkPermitStatus Incomplete = new PermitRequestBasedWorkPermitStatus(6, 6);
        public static PermitRequestBasedWorkPermitStatus CompletionUnknown = new PermitRequestBasedWorkPermitStatus(7, 7);
        public static PermitRequestBasedWorkPermitStatus NoShow = new PermitRequestBasedWorkPermitStatus(8, 8);
        public static PermitRequestBasedWorkPermitStatus NotReturned = new PermitRequestBasedWorkPermitStatus(9, 9);
        public static PermitRequestBasedWorkPermitStatus Merged = new PermitRequestBasedWorkPermitStatus(10, 10);
        public static PermitRequestBasedWorkPermitStatus OnHold = new PermitRequestBasedWorkPermitStatus(11, 11);

        public static PermitRequestBasedWorkPermitStatus Signed = new PermitRequestBasedWorkPermitStatus(13, 13); // Added By Vibhor : RITM0556998 - Add new status signed

        public static PermitRequestBasedWorkPermitStatus MissingInformation = new PermitRequestBasedWorkPermitStatus(
            12, 12);

        private static readonly PermitRequestBasedWorkPermitStatus[] all =
        {
            Requested, Pending, Issued, Complete, Void,
            Incomplete, CompletionUnknown, NoShow, NotReturned, Merged, OnHold, MissingInformation, Signed
        };

        internal PermitRequestBasedWorkPermitStatus(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public static PermitRequestBasedWorkPermitStatus[] All
        {
            get { return all; }
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_Requested;
            }
            if (IdValue == 2)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_Pending;
            }
            if (IdValue == 3)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_Issued;
            }
            if (IdValue == 4)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_Complete;
            }
            if (IdValue == 5)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_Void;
            }
            if (IdValue == 6)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_Incomplete;
            }
            if (IdValue == 7)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_CompletionUnknown;
            }
            if (IdValue == 8)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_NoShow;
            }
            if (IdValue == 9)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_NotReturned;
            }
            if (IdValue == 10)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_Merged;
            }
            if (IdValue == 11)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_OnHold;
            }
            if (IdValue == 12)
            {
                return StringResources.PermitRequestBasedWorkPermitStatus_MissingInformation;
            }
            if (IdValue == 13) // Added By Vibhor : RITM0556998 - Add new status signed
            {
                return "Signed";
            }

            return null;
        }

        public static PermitRequestBasedWorkPermitStatus Get(long index)
        {
            return GetById(index, all);
        }

        /// <summary>
        ///     Can only really complete Requested, Pending, Issued states.  All the terminating states are greater than Requested,
        ///     Pending and Issued, but have equality to each other.
        /// </summary>
        /// <param name="statusA"></param>
        /// <param name="statusB"></param>
        /// <returns></returns>
        public static bool operator >(
            PermitRequestBasedWorkPermitStatus statusA, PermitRequestBasedWorkPermitStatus statusB)
        {
            if (statusA.IdValue <= 3)
            {
                return statusA.IdValue > statusB.IdValue;
            }
            if (statusB.IdValue <= 3)
            {
                return statusB.IdValue <= statusA.IdValue;
            }
            return false;
        }

        public static bool operator <(
            PermitRequestBasedWorkPermitStatus statusA, PermitRequestBasedWorkPermitStatus statusB)
        {
            if (statusA.IdValue <= 3)
            {
                return statusA.IdValue < statusB.IdValue;
            }
            if (statusB.IdValue <= 3)
            {
                return statusB.IdValue >= statusA.IdValue;
            }
            return false;
        }

        public static bool operator >=(
            PermitRequestBasedWorkPermitStatus statusA, PermitRequestBasedWorkPermitStatus statusB)
        {
            if (statusA.IdValue > 3 && statusB.IdValue > 3)
            {
                return true;
            }
            return statusA > statusB;
        }

        public static bool operator <=(
            PermitRequestBasedWorkPermitStatus statusA, PermitRequestBasedWorkPermitStatus statusB)
        {
            if (statusA.IdValue > 3 && statusB.IdValue > 3)
            {
                return true;
            }
            return statusA < statusB;
        }
    }
}