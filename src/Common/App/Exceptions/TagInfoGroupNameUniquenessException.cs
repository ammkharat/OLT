using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class TagInfoGroupNameUniquenessException : OLTException
    {
        private const string ERROR_MESSAGE_TEMPLATE =
            "Tag info group name must be unique within a site. Name : {0}, Site : {1}";

        private readonly string siteName;
        private readonly string tagInfoGroupName;

        public TagInfoGroupNameUniquenessException(string tagInfoGroupName, string siteName)
            : base(string.Format(ERROR_MESSAGE_TEMPLATE, tagInfoGroupName, siteName))
        {
            this.tagInfoGroupName = tagInfoGroupName;
            this.siteName = siteName;
        }

        public TagInfoGroupNameUniquenessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            tagInfoGroupName = (string) info.GetValue("tagInfoGroupName", typeof (string));
            siteName = (string) info.GetValue("siteName", typeof (string));
        }

        public string TagInfoGroupName
        {
            get { return tagInfoGroupName; }
        }

        public string SiteName
        {
            get { return siteName; }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("tagInfoGroupName", tagInfoGroupName);
            info.AddValue("siteName", siteName);
            base.GetObjectData(info, context);
        }
    }
}