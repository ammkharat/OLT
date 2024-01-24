using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class QuestionnaireConfigurationType : SortableSimpleDomainObject
    {
        public static QuestionnaireConfigurationType SafeWorkPermit = new QuestionnaireConfigurationType(0, 1);

        public static List<QuestionnaireConfigurationType> All = new List<QuestionnaireConfigurationType>
        {
            SafeWorkPermit
        };

        public QuestionnaireConfigurationType(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.QuestionnaireConfigurationType_SafeWorkPermit;
            }

            return null;
        }

        public static QuestionnaireConfigurationType FindById(int typeId)
        {
            return All.Find(type => type.Id == typeId);
        }
    }
}