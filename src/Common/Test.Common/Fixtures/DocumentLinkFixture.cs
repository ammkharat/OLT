using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class DocumentLinkFixture
    {
        public static DocumentLink CreateNewDocumentLink()
        {
            return new DocumentLink("http:\\URL for Document", "Title for document");
        }

        public static DocumentLink CreateNewDocumentLink(long id)
        {
            DocumentLink documentLink = new DocumentLink("http:\\URL for Document", "Title for document");
            documentLink.Id = id;
            return documentLink;
        }

        public static DocumentLink CreateAnotherNewDocumentLink()
        {
            return
                new DocumentLink("http:\\Another URL for Document",
                                         "Another Title for document");
        }

        public static DocumentLink CreateAnotherNewDocumentLink(long id)
        {
            DocumentLink link = CreateAnotherNewDocumentLink();
            link.Id = id;
            return link;
        }

        public static DocumentLink CreateDocumentLinkWithID(long id)
        {
            DocumentLink documentLink =
                new DocumentLink("URL for Document", "Title document");
            documentLink.Id = id;

            return documentLink;
        }

        public static List<DocumentLink> CreateDocumentListOfTwo()
        {
            List<DocumentLink> documentLinks = new List<DocumentLink>
                                                           {
                                                               CreateNewDocumentLink(),
                                                               CreateAnotherNewDocumentLink()
                                                           };

            return documentLinks;
        }

        public static List<DocumentLink> CreateDocumentLinkListWithIds(long id)
        {
            List<DocumentLink> documentLinks = new List<DocumentLink> {CreateDocumentLinkWithID(id)};
            return documentLinks;
        }
    }
}