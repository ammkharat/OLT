using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    /// <summary>
    ///     Immutable value object representing the normal/desired value for a target definition.
    ///     Someone could want to minimize the target, or maximize it, or have a specified value for the target.
    /// </summary>
    [Serializable]
    public abstract class TargetValue
    {
        /// <summary>
        ///     Returns a representative title for this target value.
        /// </summary>
        public abstract string Title { get; }

        public override string ToString()
        {
            return Title;
        }

        /// <summary>
        ///     Perform action corresponding to the type of target value this is.
        /// </summary>
        public abstract void Do(ITargetAction action);

        public static TargetValue CreateMinimizeTarget()
        {
            return new MinimizeTargetValue();
        }

        public static TargetValue CreateMaximizeTarget()
        {
            return new MaximizeTargetValue();
        }

        public static TargetValue CreateSpecifiedTarget(decimal specifiedValue)
        {
            return new SpecifiedTargetValue(specifiedValue);
        }

        public static TargetValue CreateEmptyTarget()
        {
            return new EmptyTargetValue();
        }

        [Serializable]
        private class EmptyTargetValue : TargetValue
        {
            public override string Title
            {
                get { return string.Empty; }
            }

            public override void Do(ITargetAction action)
            {
                action.DoForEmpty();
            }

            public override int GetHashCode()
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                if (this == obj) return true;
                var emptyTargetValue = obj as EmptyTargetValue;
                return emptyTargetValue != null;
            }
        }

        [Serializable]
        private class MaximizeTargetValue : TargetValue
        {
            public override string Title
            {
                get { return StringResources.MaximizeTargetValueTitle; }
            }

            public override void Do(ITargetAction action)
            {
                action.DoForMaximize();
            }

            public override int GetHashCode()
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                if (this == obj) return true;
                var maximizeTargetValue = obj as MaximizeTargetValue;
                if (maximizeTargetValue == null) return false;
                return true;
            }
        }

        [Serializable]
        private class MinimizeTargetValue : TargetValue
        {
            public override string Title
            {
                get { return StringResources.MinimizeTargetValueTitle; }
            }

            public override void Do(ITargetAction action)
            {
                action.DoForMinimize();
            }

            public override int GetHashCode()
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                if (this == obj) return true;
                var minimizeTargetValue = obj as MinimizeTargetValue;
                if (minimizeTargetValue == null) return false;
                return true;
            }
        }

        [Serializable]
        private class SpecifiedTargetValue : TargetValue
        {
            private readonly decimal specifiedValue;

            public SpecifiedTargetValue(decimal desiredValue)
            {
                specifiedValue = desiredValue;
            }
            //RITM0252906-Changed by Mukesh
            public override string Title
            {
                get { return Convert.ToString(specifiedValue)!="" ? specifiedValue.ToString("N3") : String.Empty; }
                //get { return specifiedValue.Format(); }
            }

            public override void Do(ITargetAction action)
            {
                action.DoWithSpecifiedValue(specifiedValue);
            }

            public override int GetHashCode()
            {
                return specifiedValue.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (this == obj) return true;
                var specifiedTargetValue = obj as SpecifiedTargetValue;
                if (specifiedTargetValue == null) return false;
                if (specifiedValue != specifiedTargetValue.specifiedValue) return false;
                return true;
            }
        }
    }
}