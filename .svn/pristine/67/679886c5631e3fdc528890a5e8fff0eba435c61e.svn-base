using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ActionItemStatus : SortableSimpleDomainObject
    {
        public static readonly ActionItemStatus Current = new ActionItemStatus(0, 2);
        public static readonly ActionItemStatus Complete = new ActionItemStatus(1, 1);
        public static readonly ActionItemStatus Incomplete = new ActionItemStatus(2, 3);
        public static readonly ActionItemStatus CannotComplete = new ActionItemStatus(3, 4);
        public static readonly ActionItemStatus Cleared = new ActionItemStatus(4, 5);
        public static readonly ActionItemStatus IefSubmitted = new ActionItemStatus(5, 6); //IEFSubmitted Changes

        public static readonly ActionItemStatus[] All = { Current, Complete, Incomplete, CannotComplete, Cleared, IefSubmitted };//IEFSubmitted Changes

        public static readonly ActionItemStatus[] AvailableForCurrentView =
        {
            Current, Complete, Incomplete,
            CannotComplete, IefSubmitted //IEFSubmitted Changes
        };

        public static readonly ActionItemStatus[] NotComplete = { Current, Incomplete, CannotComplete }; //IEFSubmitted Changes     //ayman took out this , IefSubmitted from here
        public static readonly ActionItemStatus[] AllForPriorityDisplay = {Current};

        private ActionItemStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.ActionItemStatus_Current;
            }
            if (IdValue == 1)
            {
                return StringResources.ActionItemStatus_Complete;
            }
            if (IdValue == 2)
            {
                return StringResources.ActionItemStatus_Incomplete;
            }
            if (IdValue == 3)
            {
                return StringResources.ActionItemStatus_CantComplete;
            }
            if (IdValue == 4)
            {
                return StringResources.ActionItemStatus_Cleared;
            }
            if (IdValue == 5)
            {
                return StringResources.ActionItemStatus_IEFSubmitted;
            }
            return null;
        }

        public static ActionItemStatus Get(long index)
        {
            return GetById(index, All);
        }
    }
}