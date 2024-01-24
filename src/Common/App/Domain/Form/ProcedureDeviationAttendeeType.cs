using System;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviationAttendeeType : SimpleDomainObject
    {
        public static readonly ProcedureDeviationAttendeeType OperationsSME = new ProcedureDeviationAttendeeType(1);
        public static readonly ProcedureDeviationAttendeeType TechnicalSME = new ProcedureDeviationAttendeeType(2);
        public static readonly ProcedureDeviationAttendeeType ShiftSupervisor = new ProcedureDeviationAttendeeType(3);
        public static readonly ProcedureDeviationAttendeeType Other = new ProcedureDeviationAttendeeType(4);

        private static readonly ProcedureDeviationAttendeeType[] All =
        {
            OperationsSME, TechnicalSME, ShiftSupervisor, Other
        };

        private ProcedureDeviationAttendeeType(long id)
            : base(id)
        {
        }

        public static ProcedureDeviationAttendeeType GetByName(string name)
        {
            if (name.IsNullOrEmpty()) return null;

            switch (name.ToLower())
            {
                case "operations sme":
                    return OperationsSME;

                case "technical sme":
                    return TechnicalSME;

                case "shift supervisor":
                    return ShiftSupervisor;

                case "other":
                    return Other;

                default:
                    return null;
            }
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.OperationsSMEProcedureDeviationAttendeeType;
            }
            if (IdValue == 2)
            {
                return StringResources.TechnicalSMEProcedureDeviationAttendeeType;
            }
            if (IdValue == 3)
            {
                return StringResources.ShiftSupervisorProcedureDeviationAttendeeType;
            }
            if (IdValue == 4)
            {
                return StringResources.OtherProcedureDeviationAttendeeType;
            }

            return null;
        }

        public static ProcedureDeviationAttendeeType GetById(int id)
        {
            return GetById(id, All);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ((ProcedureDeviationAttendeeType) obj).id == id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(ProcedureDeviationAttendeeType x, ProcedureDeviationAttendeeType y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(ProcedureDeviationAttendeeType x, ProcedureDeviationAttendeeType y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}