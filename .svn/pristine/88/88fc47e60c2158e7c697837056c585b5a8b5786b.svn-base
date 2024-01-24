using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormOP14Department : SortableSimpleDomainObject
    {
        public static FormOP14Department Operations = new FormOP14Department(1, 1);
        public static FormOP14Department Maintenance = new FormOP14Department(2, 2);
        public static FormOP14Department Engineering = new FormOP14Department(3, 3);


        private static readonly FormOP14Department[] all = { Operations, Maintenance, Engineering };
       // private static readonly FormOP14Department[] allPipeline = { Operations, Maintenance, Engineering };

        private FormOP14Department(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return "Operations";
            }
            if (IdValue == 2)
            {
                return "Maintenance";
            }
            //DMND0010261-SELC CSD EdmontonPipeline
            if (IdValue == 3)
            {
                return "Engineering";
            }

            return null;
        }

        public static FormOP14Department GetById(long id)
        {
            return GetById(id, all);
        }
    }
}