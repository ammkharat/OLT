using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class AbstractMultithreadedAddEditFormPresenter<TView, TDomainObject> : IRunnablePresenter 
        where TView : IAddEditBaseFormView
        where TDomainObject : DomainObject
    {
        private int loadDataCount;
        protected readonly TView view;
        protected readonly TDomainObject editObject;

        private bool cancelClicked;

        protected abstract void OnFormLoad();
        
        protected AbstractMultithreadedAddEditFormPresenter(TView view, TDomainObject editObject)
        {
            this.view = view;

            cancelClicked = false;

            this.view.Load += HandleViewLoad;
            this.view.SaveButtonClicked += HandleSaveClicked;
            this.view.CancelButtonClicked += HandleCancelClicked;
            this.view.FormClosing += HandleFormClosing;

            this.editObject = editObject;
        }

        private void HandleViewLoad(object sender, EventArgs e)
        {
            OnFormLoad();
        }

        protected bool IsEdit
        {
            get { return editObject != null && editObject.Id.HasValue; }
        }

        protected void CloseButton_Clicked(object sender, EventArgs e)
        {
            CloseButton_Clicked();
        }

        protected void CloseButton_Clicked()
        {
            view.Close();
        }

        public virtual DialogResult Run(IWin32Window parent)
        {
            DialogResult dialogResult = view.ShowDialog(parent);
            view.Dispose();

            return dialogResult;
        }

        protected void LoadData(List<Action> loadDataDelegates)
        {
            view.SetFormVisibleState(false);
            view.ShowWaitScreenAndDisableForm();

            foreach (Action loadDataDelegate in loadDataDelegates)
            {
                lock (this)
                {
                    loadDataCount++;
                }

                BackgroundHelper<object, object> backgroundHelper = new BackgroundHelper<object, object>(new ClientBackgroundWorker(), new DataFetcher(DataLoadBackgroundWorkComplete, loadDataDelegate, HandleDataLoadError));
                backgroundHelper.Run(null);
            }
        }

        private void DataLoadBackgroundWorkComplete()
        {
            lock (this)
            {
                loadDataCount--;

                if (loadDataCount == 0)
                {
                    view.CloseWaitScreenAndEnableForm();
                    AfterDataLoad();
                    view.SetFormVisibleState(true);
                }
            }
        }

        protected virtual void AfterDataLoad() { }
        
        private void HandleDataLoadError(Exception e)
        {
            view.CloseWaitScreenAndEnableForm();
            throw new Exception("Error loading data", e);
        }

        private void HandleDataSaveError(Exception e)
        {
            view.CloseWaitScreenAndEnableForm();
            throw new Exception("Error loading data", e);
        }

        protected virtual bool DoPreSaveWork()
        {
            return true;
        }

        protected virtual void SaveData()
        {            
        }

        private void HandleSaveClicked(object sender, EventArgs e)
        {
            cancelClicked = false;

            bool continueWithSave = DoPreSaveWork();

            if (!continueWithSave)
            {
                return;
            }

            view.ShowWaitScreenAndDisableForm();
            BackgroundHelper<object, object> backgroundHelper = new BackgroundHelper<object, object>(new ClientBackgroundWorker(), new DataFetcher(DataSaveBackgroundWorkComplete, SaveData, HandleDataSaveError));
            backgroundHelper.Run(null);
        }

        private void HandleCancelClicked(object sender, EventArgs e)
        {
            cancelClicked = true;
            view.DialogResult = DialogResult.Cancel;
            view.Close();
        }

        private void DataSaveBackgroundWorkComplete()
        {
            view.CloseWaitScreenAndEnableForm();
            view.Close();
        }

        public abstract IForm View { get; }

        private void HandleFormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (cancelClicked && !ClientSession.GetInstance().ForceLogoff && !view.ConfirmCancelDialog())
            {
                eventArgs.Cancel = true;
            }
        }
    }
}
