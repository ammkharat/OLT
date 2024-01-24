using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class FormGN24AlkylationClass : SortableSimpleDomainObject
    {
        public static FormGN24AlkylationClass ClassA = new FormGN24AlkylationClass(1, 1, "Class A");
        public static FormGN24AlkylationClass ClassB = new FormGN24AlkylationClass(2, 2, "Class B");
        public static FormGN24AlkylationClass ClassC = new FormGN24AlkylationClass(3, 3, "Class C");
        public static FormGN24AlkylationClass ClassD = new FormGN24AlkylationClass(4, 4, "Class D");

        private static readonly FormGN24AlkylationClass[] all = {ClassA, ClassB, ClassC, ClassD};
        private readonly string name;

        private FormGN24AlkylationClass(long id, int sortOrder, string name)
            : base(id, sortOrder)
        {
            this.name = name;
        }

        public static List<FormGN24AlkylationClass> All
        {
            get { return new List<FormGN24AlkylationClass>(all); }
        }

        public override string GetName()
        {
            return name;
        }

        public static FormGN24AlkylationClass GetById(long id)
        {
            return GetById(id, all);
        }
    }
}