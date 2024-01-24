using System;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class DocumentLinkDTO
    {
        private readonly string title;
        private readonly string url;

        public DocumentLinkDTO(string url, string title)
        {
            this.url = url;
            this.title = title;
        }

        public string Url
        {
            get { return url; }
        }

        public string Title
        {
            get { return title; }
        }
    }
}