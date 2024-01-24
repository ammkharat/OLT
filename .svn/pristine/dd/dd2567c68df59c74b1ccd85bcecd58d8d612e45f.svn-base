using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FunctionalLocationDTO : DomainObject
    {
        private readonly string division;
        private readonly string equipment1;
        private readonly string equipment2;
        private readonly string fullHierarcy;
        private readonly string section;
        private readonly FunctionalLocationType type;
        private readonly string unit;

        public FunctionalLocationDTO(
            long id,
            string fullHierarcy)
        {
            this.id = id;
            this.fullHierarcy = fullHierarcy;
            var functionalLocationHierarchy = new FunctionalLocationHierarchy(fullHierarcy);

            division = functionalLocationHierarchy.Division;
            section = functionalLocationHierarchy.Section;
            unit = functionalLocationHierarchy.Unit;
            equipment1 = functionalLocationHierarchy.Equipment1;
            equipment2 = functionalLocationHierarchy.Equipment2;
            type = functionalLocationHierarchy.Type;
        }

        public string Division
        {
            get { return division; }
        }

        public string Section
        {
            get { return section; }
        }

        public string Unit
        {
            get { return unit; }
        }

        public string Equipment1
        {
            get { return equipment1; }
        }

        public string Equipment2
        {
            get { return equipment2; }
        }

        public string FullHierarcy
        {
            get { return fullHierarcy; }
        }

        public FunctionalLocationType Type
        {
            get { return type; }
        }

        public int CompareByHierararchy(FunctionalLocation y)
        {
            var x = this;

            {
                var compareResult = string.CompareOrdinal(x.Division, y.Division);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = string.CompareOrdinal(x.Section, y.Section);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = string.CompareOrdinal(x.Unit, y.Unit);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = string.CompareOrdinal(x.Equipment1, y.Equipment1);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = string.CompareOrdinal(x.Equipment2, y.Equipment2);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return 0;
        }
    }
}