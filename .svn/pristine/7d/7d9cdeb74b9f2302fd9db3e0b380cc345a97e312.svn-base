namespace Com.Suncor.Olt.Reports.Adapters
{
    public class DocumentLinkReportAdapter
    {
        private readonly string parentId = string.Empty;
        private readonly string title;
        private readonly string url;

        public DocumentLinkReportAdapter(string url, string title) : this(string.Empty, url, title)
        {
        }

        public DocumentLinkReportAdapter(string parentId, string url, string title)
        {
            this.parentId = parentId;
            this.url = url;
            this.title = title;
        }

        public string ParentId
        {
            get { return parentId; }
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