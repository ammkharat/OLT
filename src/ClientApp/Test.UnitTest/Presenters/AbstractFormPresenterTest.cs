using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]     
    public class AbstractFormPresenterTest
    {                        
        [SetUp]
        public void SetUp()
        {        
        }

        [Test]        
        public void ShouldSave()
        {
            FakeForm fakeForm = new FakeForm();
            FakeFormPresenter presenter = new FakeFormPresenter(false, fakeForm);

            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();

            Assert.IsTrue(fakeForm.CloseWasCalled);
            Assert.IsTrue(fakeForm.CloseWaitScreenAndEnableFormWasCalled);
            Assert.IsFalse(fakeForm.SaveSucceededMessageWasCalled);
            Assert.IsFalse(fakeForm.SaveFailedMessageWasCalled);

            Assert.IsTrue(presenter.CalledInsert);
            Assert.IsFalse(presenter.CalledUpdate);
        }

        [Test]        
        public void ShouldUpdate()
        {
            FakeForm fakeForm = new FakeForm();
            FakeFormPresenter presenter = new FakeFormPresenter(true, fakeForm);

            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();

            Assert.IsTrue(fakeForm.CloseWasCalled);
            Assert.IsTrue(fakeForm.CloseWaitScreenAndEnableFormWasCalled);
            Assert.IsFalse(fakeForm.SaveSucceededMessageWasCalled);
            Assert.IsFalse(fakeForm.SaveFailedMessageWasCalled);

            Assert.IsFalse(presenter.CalledInsert);
            Assert.IsTrue(presenter.CalledUpdate);
        }

        [Test]        
        public void ShouldDisplaySaveFailedMessage()
        {
            FakeForm fakeView = new FakeForm();
            FakeFormPresenter presenter = new FakeFormPresenter(false, fakeView, () => { throw new Exception(); });

            presenter.HandleSaveAndCloseButtonClick(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();

            Assert.IsTrue(fakeView.CloseWasCalled);
            Assert.IsTrue(fakeView.CloseWaitScreenAndEnableFormWasCalled);
            Assert.IsTrue(fakeView.SaveFailedMessageWasCalled);
            Assert.IsFalse(fakeView.SaveSucceededMessageWasCalled);

            Assert.IsTrue(presenter.CalledInsert);
            Assert.IsFalse(presenter.CalledUpdate);
        }

        private string thisIsSetToKittyInTheThread;

        [Test]
        public void ThisWillWork()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += HandleDoWork;
            worker.RunWorkerCompleted += HandleRunWorkerCompleted;

            worker.RunWorkerAsync();         
            TestUtil.WaitAndDoEvents();

            Assert.AreEqual("Kitty", thisIsSetToKittyInTheThread);
        }

        private void HandleDoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = "Kitty";
        }

        private void HandleRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            thisIsSetToKittyInTheThread = (string) e.Result;
        }

        private class FakeFormPresenter : AbstractFormPresenter<IBaseForm, DomainObject>
        {
            public bool CalledInsert;
            public bool CalledUpdate;

            private readonly bool isEdit;
            private bool success;
            private readonly Action actionOnInsert;

            public FakeFormPresenter(bool isEdit, IBaseForm view) : this(isEdit, view, null)
            {
                this.isEdit = isEdit;
            }

            public FakeFormPresenter(bool isEdit, IBaseForm view, Action actionOnInsert) : base(view)
            {
                this.isEdit = isEdit;
                this.actionOnInsert = actionOnInsert;
            }

            protected override void SaveOrUpdateComplete(bool saveOrUpdateSucceeded)
            {
                success = saveOrUpdateSucceeded;
            }

            public override bool IsEdit
            {
                get { return isEdit; }
            }

            public void SomeoneClickedSave()
            {
                SaveOrUpdate(true);
            }

            protected void UpdateViewFromEditObject()
            {
                
            }

            protected void UpdateViewWithDefaults()
            {
                
            }

            public override bool ValidateViewHasError()
            {
                return false;   
            }

            public override void Insert(SaveUpdateDomainObjectContainer<DomainObject> container)
            {                
                CalledInsert = true;

                if (actionOnInsert != null)
                {
                    actionOnInsert();
                }
            }

            public override void Update(SaveUpdateDomainObjectContainer<DomainObject> container)
            {
                CalledUpdate = true;
            }

            protected override SaveUpdateDomainObjectContainer<DomainObject> GetNewObjectToInsert()
            {
                return new SaveUpdateDomainObjectContainer<DomainObject>(editObject);
            }

            protected override SaveUpdateDomainObjectContainer<DomainObject> GetPopulatedEditObjectToUpdate()
            {
                return new SaveUpdateDomainObjectContainer<DomainObject>(editObject);
            }          
        }

        private class FakeForm : IBaseForm
        {
            public bool CloseWasCalled { get; private set; }
            public bool CloseWaitScreenAndEnableFormWasCalled { get; private set; }
            public bool SaveFailedMessageWasCalled { get; private set; }
            public bool SaveSucceededMessageWasCalled { get; private set; }

            public IntPtr Handle { get { return IntPtr.Zero; } }

            public event EventHandler Load;
            public event EventHandler Disposed;
            public event FormClosingEventHandler FormClosing;

            public int Height
            {
                get { return 0; }
                set { }
            }

            public int Width
            {
                get { return 0; }
                set { }
            }

            public Point Location
            {
                get { return Point.Empty; }
                set { }
            }

            public DialogResult DialogResult
            {
                get { return DialogResult.OK; }
                set { }
            }            

            public DialogResult ShowDialog(IWin32Window form)
            {
                return DialogResult.OK;
            }

            public void Dispose() { }

            public void Close() { CloseWasCalled = true; }

            public void ShowWaitScreenAndDisableForm() { }

            public void CloseWaitScreenAndEnableForm() { CloseWaitScreenAndEnableFormWasCalled = true; }

            public void SetFormVisibleState(bool visible)
            {                
            }

            public bool ConfirmCancelDialog() { return true; }

            public void SaveFailedMessage() { SaveFailedMessageWasCalled = true; }

            public void SaveSucceededMessage() { SaveSucceededMessageWasCalled = true; }

            public void ShowMessageBox(string title, string error) { }

            public void UpdateTitleAsCreateOrEdit(bool isEdit, string titleText) { }
        }
    }
}
