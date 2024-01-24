using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class GasTestElement : DomainObject
    {
        private bool confinedSpaceTestRequired;
        private double? confinedSpaceTestResult;
        private bool immediateAreaTestRequired;
        private double? immediateAreaTestResult;
        private bool systemEntryTestNotApplicable;

        private bool thirdRequired;
        private double? thirdTestResult;

        private bool fourthRequired;
        private double? fourthTestResult;

        public GasTestElement()
        {
            ElementInfo = null;
            immediateAreaTestRequired = false;
            immediateAreaTestResult = null;
            confinedSpaceTestResult = null;
            confinedSpaceTestRequired = false;
            systemEntryTestNotApplicable = true;
        }

        public GasTestElementInfo ElementInfo { get; set; }

        public double? ImmediateAreaTestResult
        {
            get { return immediateAreaTestResult; }
            set { immediateAreaTestResult = value; }
        }

        public double? ConfinedSpaceTestResult
        {
            get { return confinedSpaceTestResult; }
            set { confinedSpaceTestResult = value; }
        }

        public bool ImmediateAreaTestRequired
        {
            get { return immediateAreaTestRequired; }
            set { immediateAreaTestRequired = value; }
        }

        public bool ConfinedSpaceTestRequired
        {
            get { return confinedSpaceTestRequired; }
            set { confinedSpaceTestRequired = value; }
        }

        public double? SystemEntryTestResult { get; set; }

        public bool SystemEntryTestNotApplicable
        {
            get { return systemEntryTestNotApplicable; }
            set { systemEntryTestNotApplicable = value; }
        }

        public static GasTestElement CreateGasTestElement(GasTestElementInfo info)
        {
            var ret = new GasTestElement {ElementInfo = info};
            return ret;
        }


        public GasTestElement Copy()
        {
            var newCopy = new GasTestElement
            {
                ImmediateAreaTestResult = ImmediateAreaTestResult,
                ImmediateAreaTestRequired = ImmediateAreaTestRequired,
                ConfinedSpaceTestRequired = ConfinedSpaceTestRequired,
                ConfinedSpaceTestResult = ConfinedSpaceTestResult,
                SystemEntryTestNotApplicable = SystemEntryTestNotApplicable,
                SystemEntryTestResult = SystemEntryTestResult,
                ElementInfo = ElementInfo.Copy()
            };
            return newCopy;
        }

        /// <summary>
        ///     Tests if this part of the work permit has data (has been "filled out").
        /// </summary>
        public bool HasData()
        {
            if (immediateAreaTestRequired || immediateAreaTestResult.HasValue
                || confinedSpaceTestRequired || confinedSpaceTestResult.HasValue
                || !SystemEntryTestNotApplicable || SystemEntryTestResult.HasValue)
            {
                return true;
            }

            if (ElementInfo != null &&
                ElementInfo.IsStandard == false &&
                ElementInfo.HasData())
            {
                return true;
            }

            return false;
        }

        public string ToHistoryString()
        {
            var historyString = new StringBuilder();

            if (ElementInfo != null)
                historyString.AppendFormat("{0}: ", ElementInfo.Name);

            var immediateWorkAreaRequiredFormatString =
                StringResources.GasTestElementHistoryString_ImmediateWorkAreaRequiredFormatString;
                // "Immediate/Work Area Required: {0}";
            var firstImmediateWorkAreaResultFormatString =
                StringResources.GasTestElementHistoryString_FirstImmediateWorkAreaResultFormatString;
                //"First Immediate/WorkArea Result: {0}";
            var csRequiredFormatString = StringResources.GasTestElementHistoryString_CSRequiredFormatString;
                //"CS Required: {0}";
            var firstCSResultFormatString = StringResources.GasTestElementHistoryString_FirstCSResultFormatString;
                // "First CS Result: {0}";
            var seNAFormatString = StringResources.GasTestElementHistoryString_SENAFormatString; //"SE N/A: {0}";
            var firstSEResultFormatString = StringResources.GasTestElementHistoryString_FirstSEResultFormatString;
                // "First SE Result: {0}";

            var outputList = new List<string>();

            outputList.Add(string.Format(immediateWorkAreaRequiredFormatString, ImmediateAreaTestRequired));

            if (ImmediateAreaTestRequired)
            {
                outputList.Add(string.Format(firstImmediateWorkAreaResultFormatString, ImmediateAreaTestResult));
            }

            outputList.Add(string.Format(csRequiredFormatString, ConfinedSpaceTestRequired));

            if (ConfinedSpaceTestRequired)
            {
                outputList.Add(string.Format(firstCSResultFormatString, ConfinedSpaceTestResult));
            }

            outputList.Add(string.Format(seNAFormatString, SystemEntryTestNotApplicable));

            if (!SystemEntryTestNotApplicable)
            {
                outputList.Add(string.Format(firstSEResultFormatString, SystemEntryTestResult));
            }

            return outputList.BuildCommaSeparatedList();
        }


        //Added for muds
        public bool ThirdTestRequired
        {
            get { return thirdRequired; }
            set { thirdRequired = value; }
        }

        public bool FourthTestRequired
        {
            get { return fourthRequired; }
            set { fourthRequired = value; }
        }

        public double? ThirdTestResult
        {
            get { return thirdTestResult; }
            set { thirdTestResult = value; }
        }

        public double? FourthTestResult
        {
            get { return fourthTestResult; }
            set { fourthTestResult = value; }
        }

        public string ToHistoryStringForMuds()
        {
            var historyString = new StringBuilder();

            if (ElementInfo != null)
                historyString.AppendFormat("{0}: ", ElementInfo.Name);

            var immediateWorkAreaRequiredFormatString =
               "First Result Required:{0}";
            // "Immediate/Work Area Required: {0}";
            var firstImmediateWorkAreaResultFormatString =
                "First Result: {0}";
            //"First Immediate/WorkArea Result: {0}";
            var csRequiredFormatString =  "Second Result Required:{0}";
            //"CS Required: {0}";
            var firstCSResultFormatString = "Second Result: {0}"; ;
            // "First CS Result: {0}";
            var seNAFormatString = StringResources.GasTestElementHistoryString_SENAFormatString; //"SE N/A: {0}";
            var firstSEResultFormatString = StringResources.GasTestElementHistoryString_FirstSEResultFormatString;
            // "First SE Result: {0}";

            var outputList = new List<string>();

            outputList.Add(string.Format(immediateWorkAreaRequiredFormatString, ImmediateAreaTestRequired));

            if (ImmediateAreaTestRequired)
            {
                outputList.Add(string.Format(firstImmediateWorkAreaResultFormatString, ImmediateAreaTestResult));
            }

            outputList.Add(string.Format(csRequiredFormatString, ConfinedSpaceTestRequired));

            if (ConfinedSpaceTestRequired)
            {
                outputList.Add(string.Format(firstCSResultFormatString, ConfinedSpaceTestResult));
            }

            outputList.Add(string.Format("Second Result Required:{0}", ThirdTestRequired));

            if (thirdRequired)
            {
                outputList.Add(string.Format("Second Result: {0}", ThirdTestResult));
            }
            outputList.Add(string.Format("Third Result Required:{0}", FourthTestRequired));
            if (fourthRequired)
            {
                outputList.Add(string.Format("Third Result: {0}", FourthTestResult));
            }

            return outputList.BuildCommaSeparatedList();
        }
    }
}