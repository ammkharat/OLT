using System;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Provides a typesafe way to describe which OLT construct a SAP workorder belongs to. Used in SapWorkOrderOperation.
    /// </summary>
    [Serializable]
    public class SapOperationType
    {
        public static readonly SapOperationType ActionItemDefinition = new SapOperationType("AI");
        public static readonly SapOperationType WorkPermit = new SapOperationType("WP");

        private readonly string name;

        private SapOperationType(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public static SapOperationType GetByName(string nameToFindFor)
        {
            if (nameToFindFor == ActionItemDefinition.Name)
            {
                return ActionItemDefinition;
            }
            if (nameToFindFor == WorkPermit.Name)
            {
                return WorkPermit;
            }
            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}