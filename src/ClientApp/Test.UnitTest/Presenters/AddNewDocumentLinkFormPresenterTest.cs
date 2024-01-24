using System;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Client.Forms;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class AddNewDocumentLinkFormPresenterTest
    {
        AddNewDocumentLinkFormPresenter presenter;
        IAddNewDocumentLinkFormView viewMock;
        private IDocumentLinkService mockService;

        readonly Mockery mock = new Mockery();

        [SetUp]
        public void SetUp()
        {
            viewMock = mock.NewMock<IAddNewDocumentLinkFormView>();
            mockService = mock.NewMock<IDocumentLinkService>();

            presenter = new AddNewDocumentLinkFormPresenter(viewMock, mockService);
        }

        [Test]
        public void OnAddClickedShouldCreateANewDocumentLink()
        {
            var documentLink = new DocumentLink("http://TestURL", "TestTitle");
            Expect.Once.On(viewMock).Method("ClearErrorProviders");
            Expect.Exactly(2).On(viewMock).GetProperty("DocumentLink").Will(Return.Value(documentLink.Url));
            Expect.Exactly(2).On(viewMock).GetProperty("Title").Will(Return.Value(documentLink.Title));
            Expect.Once.On(viewMock).SetProperty("NewDocumentLink").To(documentLink);
            Expect.Once.On(viewMock).Method("CloseForm");

            presenter.HandleAddClicked(this, new EventArgs());

            mock.VerifyAllExpectationsHaveBeenMet();

        }

        [Test]
        public void OnCancelClickedShouldSetANewDocumentLinkToNull()
        {

            Expect.Once.On(viewMock).SetProperty("NewDocumentLink");
            Expect.Once.On(viewMock).Method("CloseForm");

            presenter.HandleCancelClicked(this, new EventArgs());

            mock.VerifyAllExpectationsHaveBeenMet();

        }

        [Test]
        public void ValidateViewHasErrorShouldReturnFalseIfLinkIsBlank()
        {
            Expect.Once.On(viewMock).Method("ClearErrorProviders");            
            Expect.Once.On(viewMock).GetProperty("DocumentLink").Will(Return.Value(String.Empty));
            Expect.Once.On(viewMock).Method("ShowLinkDocumentIsEmptyError");
            Expect.Once.On(viewMock).GetProperty("Title").Will(Return.Value("test text"));                        

            bool returnValue = presenter.ValidateViewHasError();

            Assert.IsTrue(returnValue);

            mock.VerifyAllExpectationsHaveBeenMet();

        }

        [Test]
        public void ValidateViewHasErrorShouldReturnFalseIfTitleIsBlank()
        {
            Expect.Once.On(viewMock).Method("ClearErrorProviders");
            Expect.Once.On(viewMock).GetProperty("DocumentLink").Will(Return.Value("http://someurl"));
            Expect.Once.On(viewMock).GetProperty("Title").Will(Return.Value(String.Empty));
            Expect.Once.On(viewMock).Method("ShowTitleDocumentIsEmptyError");

            bool returnValue = presenter.ValidateViewHasError();

            Assert.IsTrue(returnValue);

            mock.VerifyAllExpectationsHaveBeenMet();

        }

    }
}
