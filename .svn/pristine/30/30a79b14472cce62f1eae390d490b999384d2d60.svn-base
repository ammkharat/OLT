using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class CorrectiveActionFixDocumentDurationType : SimpleDomainObject
    {
        public static readonly CorrectiveActionFixDocumentDurationType DeviationDurationOnly =
            new CorrectiveActionFixDocumentDurationType(1);

        public static readonly CorrectiveActionFixDocumentDurationType DeviationDurationAndPermanentRevisionRequired =
            new CorrectiveActionFixDocumentDurationType(2);

        private static readonly CorrectiveActionFixDocumentDurationType[] All =
        {
            DeviationDurationOnly, DeviationDurationAndPermanentRevisionRequired
        };

        private CorrectiveActionFixDocumentDurationType(long id)
            : base(id)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.DeviationDurationOnlyCorrectiveActionFixDocumentDurationType;
            }
            if (IdValue == 2)
            {
                return
                    StringResources.DeviationDurationAndPermanentRevisionRequiredCorrectiveActionFixDocumentDurationType;
            }

            return null;
        }

        public static CorrectiveActionFixDocumentDurationType GetById(int id)
        {
            return GetById(id, All);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ((CorrectiveActionFixDocumentDurationType) obj).id == id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(
            CorrectiveActionFixDocumentDurationType x, CorrectiveActionFixDocumentDurationType y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(
            CorrectiveActionFixDocumentDurationType x, CorrectiveActionFixDocumentDurationType y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}