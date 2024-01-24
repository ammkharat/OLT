using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviationApprovalType : SimpleDomainObject
    {
        public static readonly ProcedureDeviationApprovalType OperationsSME = new ProcedureDeviationApprovalType(1);
        public static readonly ProcedureDeviationApprovalType TechnicalSME = new ProcedureDeviationApprovalType(2);
        public static readonly ProcedureDeviationApprovalType DocumentOwnerApprover = new ProcedureDeviationApprovalType(3);
        public static readonly ProcedureDeviationApprovalType Other = new ProcedureDeviationApprovalType(4);

        private static readonly ProcedureDeviationApprovalType[] All =
        {
            OperationsSME, TechnicalSME, DocumentOwnerApprover, Other
        };

        private ProcedureDeviationApprovalType(long id)
            : base(id)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.OperationsSMEProcedureDeviationApprovalType;
            }
            if (IdValue == 2)
            {
                return StringResources.TechnicalSMEProcedureDeviationApprovalType;
            }
            if (IdValue == 3)
            {
                return StringResources.DocumentOwnerApproverProcedureDeviationApprovalType;
            }
            if (IdValue == 4)
            {
                return StringResources.OtherProcedureDeviationApprovalType;
            }

            return null;
        }

        public static ProcedureDeviationApprovalType GetById(int id)
        {
            return GetById(id, All);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ((ProcedureDeviationApprovalType)obj).id == id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(ProcedureDeviationApprovalType x, ProcedureDeviationApprovalType y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(ProcedureDeviationApprovalType x, ProcedureDeviationApprovalType y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}