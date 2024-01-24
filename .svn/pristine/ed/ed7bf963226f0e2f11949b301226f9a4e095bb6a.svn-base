using System;
using System.Collections.Generic;
using DevExpress.Xpo.DB;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class TrainingBlock : DomainObject
    {
        private readonly List<FunctionalLocation> functionalLocations;
        private string code;
        private string name;

        //ayman training block adding siteid column
        private long siteid;

        public TrainingBlock(long? id, string name, string code,long siteid, List<FunctionalLocation> functionalLocations)   //ayman training block adding siteid column
        {
            this.id = id;
            this.name = name;
            this.code = code;
            this.siteid = siteid;            // ayman training block adding siteid column
            this.functionalLocations = functionalLocations;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        //ayman training block adding siteid column
        public long Siteid
        {
            get { return siteid; }
            set { siteid = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocations; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}