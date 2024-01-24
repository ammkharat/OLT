using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls
{
    public class FunctionalLocationMode
    {
     
        public static readonly FunctionalLocationMode LevelThreeAndAbove =
            CreateModeForRange(FunctionalLocationType.Level1, FunctionalLocationType.Level3);

        public static readonly FunctionalLocationMode LevelTwoAndAbove =
            CreateModeForRange(FunctionalLocationType.Level1, FunctionalLocationType.Level2);

        public static readonly FunctionalLocationMode LevelFiveAndAbove =
            CreateModeForRange(FunctionalLocationType.Level1, FunctionalLocationType.Level5);

        public static readonly FunctionalLocationMode LevelSevenAndAbove =
            CreateModeForRange(FunctionalLocationType.Level1, FunctionalLocationType.Level7);

        private readonly List<FunctionalLocationType> allowedTypes;

        private FunctionalLocationMode(List<FunctionalLocationType> allowedTypes)
        {
            this.allowedTypes = allowedTypes;
        }

        public bool IsAdmin { private set; get; }

        public IList<FunctionalLocationType> AllowedTypes
        {
            get { return allowedTypes; }
        }

        public static FunctionalLocationMode GetAll(SiteConfiguration siteConfiguration)
        {
            return CreateModeForRangeUsingSiteConfiguredLowestFloc(FunctionalLocationType.Level1, siteConfiguration);
        }

        public static FunctionalLocationMode GetAdmin(SiteConfiguration siteConfiguration)
        {
            var mode = CreateModeForRangeUsingSiteConfiguredLowestFloc(FunctionalLocationType.Level1, siteConfiguration);
            mode.IsAdmin = true;
            return mode;
        }

        public static FunctionalLocationMode GetLevelThreeAndBelow(SiteConfiguration siteConfiguration)
        {
            return CreateModeForRangeUsingSiteConfiguredLowestFloc(FunctionalLocationType.Level3, siteConfiguration);
        }

        public static FunctionalLocationMode GetLevelTwoAndBelow(SiteConfiguration siteConfiguration)
        {
            return CreateModeForRangeUsingSiteConfiguredLowestFloc(FunctionalLocationType.Level2, siteConfiguration);
        }

        public static FunctionalLocationMode GetSiteConfiguredMaxLevelAndBelow(FunctionalLocationType highestType,
            SiteConfiguration siteConfiguration)
        {
            return CreateModeForRangeUsingSiteConfiguredLowestFloc(highestType, siteConfiguration);
        }

        public bool IsAllowed(FunctionalLocationType flocType)
        {
            return allowedTypes.Contains(flocType);
        }

        /// <summary>
        ///     Instead of having if-else-if-else-if statements everywhere depending on the selection mode,
        ///     use this method to dispatch what to do. When we make changes to the selection modes,
        ///     we just have to find references to this method and make the appropriate adjustments.
        /// </summary>
        public void DispatchBasedOnMode(SiteConfiguration siteConfiguration, MethodInvoker showUnitAndAboveAction,
            MethodInvoker showUnitAndBelowAction,
            MethodInvoker showSectionAndBelowAction, MethodInvoker showSectionAndAboveAction,
            MethodInvoker showEquipment2AndAboveAction, MethodInvoker showLevel7AndAboveAction,
            MethodInvoker showAllAction)
        {

                if (Equals(LevelThreeAndAbove))
                {
                    showUnitAndAboveAction();
                }
                else if (Equals(GetLevelThreeAndBelow(siteConfiguration)))
                {
                    showUnitAndBelowAction();
                }
                else if (Equals(GetLevelTwoAndBelow(siteConfiguration)))
                {
                    showSectionAndBelowAction();
                }
                else if (Equals(LevelTwoAndAbove))
                {
                    showSectionAndAboveAction();
                }
                else if (Equals(LevelFiveAndAbove))
                {
                    showEquipment2AndAboveAction();
                }
                else if (Equals(LevelSevenAndAbove))
                {
                    showLevel7AndAboveAction();
                }
                else if (Equals(GetAll(siteConfiguration)))
                {
                    showAllAction();
                }
                else
                {
                    throw new ApplicationException("Cannot dispatch on unrecognized mode:<" + this + ">");
                }
        }

        private static FunctionalLocationMode CreateModeForRange(FunctionalLocationType highestType,
            FunctionalLocationType lowestType)
        {
            return new FunctionalLocationMode(FunctionalLocation.RangeOfTypes(highestType, lowestType));
        }


        ////ayman floc level from site configuration
        //private static FunctionalLocationMode CreateModeForRangeUsingSiteConfiguredLowestFlocForSummaryLog(
        //    FunctionalLocationType highestType,
        //    int ShiftLogLeveFromSiteConf)
        //{
        //    var itemFlocSelectionLevel = ShiftLogLeveFromSiteConf;

        //    return
        //        new FunctionalLocationMode(FunctionalLocation.RangeOfTypes(highestType,
        //            itemFlocSelectionLevel.ToEnum<FunctionalLocationType>()));
        //}

        private static FunctionalLocationMode CreateModeForRangeUsingSiteConfiguredLowestFloc(
            FunctionalLocationType highestType,
            SiteConfiguration siteConfiguration)
        {

            var itemFlocSelectionLevel = siteConfiguration.ItemFlocSelectionLevel;

            return
                new FunctionalLocationMode(FunctionalLocation.RangeOfTypes(highestType,
                    itemFlocSelectionLevel.ToEnum<FunctionalLocationType>()));
        }


        public bool Equals(FunctionalLocationMode other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return allowedTypes.ReflectionEquals(other.AllowedTypes);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (FunctionalLocationMode)) return false;
            return Equals((FunctionalLocationMode) obj);
        }

        public override int GetHashCode()
        {
            return (allowedTypes != null ? allowedTypes.GetHashCode() : 0);
        }
    }
}