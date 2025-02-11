using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class UserSpecifiedCraftOrTrade : ICraftOrTrade
    {
        private string name;

        public UserSpecifiedCraftOrTrade(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ICraftOrTrade Copy()
        {
            return new UserSpecifiedCraftOrTrade(Name);
        }

        public void PerformAction(CraftOrTradeAction actionForSystem,
            CraftOrTradeAction actionForUserSpecified)
        {
            actionForUserSpecified();
        }

        public override string ToString()
        {
            return this.ReflectionToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is UserSpecifiedCraftOrTrade))
            {
                return false;
            }

            var that = (UserSpecifiedCraftOrTrade) obj;
            return Name.Equals(that.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}