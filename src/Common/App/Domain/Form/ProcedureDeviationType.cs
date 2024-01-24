using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviationType : SimpleDomainObject
    {
        public static ProcedureDeviationType Immediate = new ProcedureDeviationType(1);
        public static ProcedureDeviationType Temporary = new ProcedureDeviationType(2);

        private static readonly ProcedureDeviationType[] All =
        {
            Immediate, Temporary
        };

        private ProcedureDeviationType(long id)
            : base(id)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.ImmediateProcedureDeviationType;
            }
            if (IdValue == 2)
            {
                return StringResources.TemporaryProcedureDeviationType;
            }

            return null;
        }

        public static ProcedureDeviationType GetById(int id)
        {
            return GetById(id, All);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ((ProcedureDeviationType) obj).id == id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(ProcedureDeviationType x, ProcedureDeviationType y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(ProcedureDeviationType x, ProcedureDeviationType y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}