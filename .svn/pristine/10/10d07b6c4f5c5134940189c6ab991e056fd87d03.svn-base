using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ScadaConnectionType : SimpleDomainObject
    {
        public static readonly ScadaConnectionType PhdConnection = new ScadaConnectionType(0);
        public static readonly ScadaConnectionType PiConnection = new ScadaConnectionType(1);

        private static readonly ScadaConnectionType[] all = {PhdConnection, PiConnection};

        public ScadaConnectionType(long id)
            : base(id)
        {
        }

        public override string GetName()
        {
            return null;
        }

        public static ScadaConnectionType GetById(int id)
        {
            return GetById(id, all);
        }
    }
}