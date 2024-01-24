using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class OilsandsFormType : SortableSimpleDomainObject, IMultiGridContextSelection
    {
        public static OilsandsFormType Training = new OilsandsFormType(0, StringResources.Multigrid_Category_Forms, 0);

        private static readonly OilsandsFormType[] all = {Training};

        public OilsandsFormType(long id, string category, int sortOrder) : base(id, sortOrder)
        {
            Category = category;
        }

        public static List<IMultiGridContextSelection> AllAsMultiGridContexts
        {
            get { return new List<IMultiGridContextSelection> {Training}; }
        }

        public string Category { get; private set; }

        public static OilsandsFormType GetById(long id)
        {
            return GetById(id, all);
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.FormType_Training;
            }

            return null;
        }
    }
}