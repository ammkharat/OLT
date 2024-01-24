using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    // TODO: Move to Domain folder
    [Serializable]
    public class ComparableObject
    {
        /// <summary>
        ///     Override method to compare contents of the object
        /// </summary>
        /// <param name="objectToBeCompared"> object to be compared</param>
        /// <returns> result of comparison</returns>
        public override bool Equals(Object objectToBeCompared)
        {
            return this.ReflectionEquals(objectToBeCompared);
        }

        /// <summary>
        ///     Override method to get HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ReflectionGetHashCode();
        }
    }
}