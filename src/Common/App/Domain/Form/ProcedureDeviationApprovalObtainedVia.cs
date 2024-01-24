using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviationApprovalObtainedVia : SimpleDomainObject
    {
        public static readonly ProcedureDeviationApprovalObtainedVia Email = new ProcedureDeviationApprovalObtainedVia(1);
        public static readonly ProcedureDeviationApprovalObtainedVia Radio = new ProcedureDeviationApprovalObtainedVia(2);
        public static readonly ProcedureDeviationApprovalObtainedVia Phone = new ProcedureDeviationApprovalObtainedVia(3);

        public static readonly ProcedureDeviationApprovalObtainedVia InPerson =
            new ProcedureDeviationApprovalObtainedVia(4);

        private static List<string> allAsStringNames;

        public static readonly ProcedureDeviationApprovalObtainedVia[] All =
        {
            Email, Radio, Phone, InPerson
        };

        private ProcedureDeviationApprovalObtainedVia(long id)
            : base(id)
        {
        }

        public static List<string> AllAsStringNames()
        {
            return allAsStringNames ?? (allAsStringNames = new List<string>
            {
                Email.GetName(),
                Radio.GetName(),
                Phone.GetName(),
                InPerson.GetName()
            });
        }

        public static ProcedureDeviationApprovalObtainedVia GetByName(string name)
        {
            if (name.IsNullOrEmpty()) return null;

            switch (name.ToLower())
            {
                case "email":
                    return Email;

                case "radio":
                    return Radio;

                case "phone":
                    return Phone;

                case "in person":
                    return InPerson;

                default:
                    return null;
            }
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.EmailProcedureDeviationApprovalObtainedVia;
            }
            if (IdValue == 2)
            {
                return StringResources.RadioProcedureDeviationApprovalObtainedVia;
            }
            if (IdValue == 3)
            {
                return StringResources.PhoneProcedureDeviationApprovalObtainedVia;
            }
            if (IdValue == 4)
            {
                return StringResources.InPersonProcedureDeviationApprovalObtainedVia;
            }

            return null;
        }

        public static ProcedureDeviationApprovalObtainedVia GetById(int id)
        {
            return GetById(id, All);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ProcedureDeviationApprovalObtainedVia) obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(ProcedureDeviationApprovalObtainedVia x, ProcedureDeviationApprovalObtainedVia y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(ProcedureDeviationApprovalObtainedVia x, ProcedureDeviationApprovalObtainedVia y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}