using System;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     A link to a Document
    /// </summary>
    [Serializable]
    public class DocumentLink : DomainObject
    {
        private string title;
        private string url;

        public DocumentLink(string url, string Title)
        {
            this.url = url;
            title = Title;
        }

        /// <summary>
        ///     URL of document
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        ///     Title of document to associate to URL
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string TitleWithUrl
        {
            get { return string.Format("{0} ({1})", title, url); }
        }

        public DocumentLink CloneWithoutId()
        {
            var clone = Clone() as DocumentLink;
            clone.Id = null;
            return clone;
        }
    }
}