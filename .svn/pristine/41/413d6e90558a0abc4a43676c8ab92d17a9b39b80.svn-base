using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class FunctionalLocationSetType : SimpleDomainObject
    {
        public static readonly FunctionalLocationSetType LogIn = new FunctionalLocationSetType(0);
        public static readonly FunctionalLocationSetType WorkPermit = new FunctionalLocationSetType(1);

        private static readonly FunctionalLocationSetType[] all = {LogIn, WorkPermit};

        public FunctionalLocationSetType(long id) : base(id)
        {
        }

        public override string GetName()
        {
            return null;
        }

        public static FunctionalLocationSetType GetById(long id)
        {
            return GetById(id, all);
        }
    }
}