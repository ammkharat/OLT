using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Analytics
{
    [Serializable]
    public class PropertyType : SimpleDomainObject
    {
        public static PropertyType Text = new PropertyType(0, "Text");
        public static PropertyType Number = new PropertyType(1, "Number");
        public static PropertyType DateTime = new PropertyType(2, "DateTime");

        public static List<PropertyType> All = new List<PropertyType> {Text, Number, DateTime};
        private readonly string name;

        private PropertyType(long id, string name)
            : base(id)
        {
            this.name = name;
        }

        public override string GetName()
        {
            return name;
        }

        public static PropertyType FindById(int typeId)
        {
            return All.Find(type => type.Id == typeId);
        }
    }
}