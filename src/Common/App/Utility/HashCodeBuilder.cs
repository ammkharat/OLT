using System.Collections;

namespace Com.Suncor.Olt.Common.Utility
{
    public class HashCodeBuilder
    {
        private const int Constant = 37;
        private int total = 17;

        public int HashCode
        {
            get { return total; }
        }

        public HashCodeBuilder Append(object obj)
        {
            if (obj == null)
            {
                total = total*Constant;
            }
            else if (obj is IEnumerable)
            {
                foreach (var item in (IEnumerable) obj)
                {
                    Append(item);
                }
            }
            else
            {
                total = total*Constant + obj.GetHashCode();
            }
            return this;
        }
    }
}