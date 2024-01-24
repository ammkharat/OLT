using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class CustomFieldType : SortableSimpleDomainObject
    {
        public static CustomFieldType GeneralText = new CustomFieldType(0, 1);
        public static CustomFieldType NumericValue = new CustomFieldType(1, 2);
        public static CustomFieldType DropDownList = new CustomFieldType(2, 3);
        public static CustomFieldType Heading = new CustomFieldType(3, 4);
        public static CustomFieldType BlankSpace = new CustomFieldType(4, 5);

        public static List<CustomFieldType> All = new List<CustomFieldType> {GeneralText, NumericValue, DropDownList,Heading,BlankSpace};

        public CustomFieldType(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.CustomFieldType_GeneralText;
            }
            if (IdValue == 1)
            {
                return StringResources.CustomFieldType_NumericValue;
            }
            if (IdValue == 2)
            {
                return StringResources.CustomFieldType_DropDownList;
            }
            if (IdValue == 3)
            {
                return StringResources.CustomFieldType_Heading;
            }
            if (IdValue == 4)
            {
                return StringResources.CustomFieldType_BlankSpace;
            }

            return null;
        }

        public static CustomFieldType FindById(int typeId)
        {
            return All.Find(type => type.Id == typeId);
        }
    }

    [Serializable]
    public enum CustomFieldPhdLinkType
    {
        Off = 0,
        Read = 1,
        Write = 2
    }
}