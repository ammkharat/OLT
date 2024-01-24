using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddNewDocumentLinkFormView
    {

        DocumentLink NewDocumentLink { set;}
        string DocumentLink { get; }
        string Title { get;}

        void ShowLinkDocumentIsEmptyError();
        void ShowTitleDocumentIsEmptyError();
        void ShowLinkDocumentIsNotValidURLError();
        void ClearErrorProviders();

        void CloseForm();
        void DisableFileBrowser();

        void SelectFile(DocumentRootUncPath uncPath);
        DocumentRootUncPath DisplayRootSelector();
    }
}
