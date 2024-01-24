using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitTypeClassification : DomainObject
    {
        public static WorkPermitTypeClassification SPECIFIC = new WorkPermitTypeClassification(1,
            StringResources.WorkPermitTypeClassification_Specific);

        public static WorkPermitTypeClassification GENERAL = new WorkPermitTypeClassification(2,
            StringResources.WorkPermitTypeClassification_General);

        private static readonly WorkPermitTypeClassification[] all = {SPECIFIC, GENERAL};

        private string name;

        public WorkPermitTypeClassification(long id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public WorkPermitTypeClassification()
        {
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public static WorkPermitTypeClassification[] All
        {
            get { return all; }
        }


        public static WorkPermitTypeClassification Get(long index)
        {
            foreach (var workPermitClassificationType in all)
            {
                if (index == workPermitClassificationType.id.Value)
                    return workPermitClassificationType;
            }
            return null;
        }

        public override string ToString()
        {
            return name;
        }
    }
}