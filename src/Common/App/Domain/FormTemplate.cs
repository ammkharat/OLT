using System;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class FormTemplate : DomainObject
    {
        private readonly EdmontonFormType formType;
        private readonly string key;
        private readonly string name;
        private long siteId;
        private string template;

        public FormTemplate(long? id, EdmontonFormType formType, string template, string name, string key, long siteId)
        {
            this.id = id;
            this.formType = formType;
            this.template = template;
            this.name = name;
            this.siteId = siteId;
            this.key = key;
        }

        public EdmontonFormType FormType
        {
            get { return formType; }
        }

        public string Template
        {
            get { return template; }
            set { template = value; }
        }

        public string Name
        {
            get { return name; }
        }

        public string DisplayName
        {
            get
            {
                if (Name == null)
                {
                    return FormType.Name;
                }
                return string.Format("{0}: {1}", FormType.Name, Name);
            }
        }

        public string Key
        {
            get { return key; }
        }

        public long SiteId
        {
            get { return siteId; }
        }
    }
}