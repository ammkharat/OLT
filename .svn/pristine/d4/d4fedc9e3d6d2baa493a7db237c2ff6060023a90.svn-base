using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ImageUploader : DomainObject
    {
        public enum Type
        {
            Image = 1
        }
        public enum RecordTypes
        {
            ActionItemDef = 0,
            Directive = 1
        }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public Type Types { get; set; }
        public RecordTypes RecordType { get; set; }

    }
}
