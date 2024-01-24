using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class QuestionnaireConfigurationDTO : DomainObject
    {
        public QuestionnaireConfigurationDTO(long id, string type, string name, int version)
        {
            Type = type;
            Name = name;
            Version = version;
            this.id = id;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
    }
}