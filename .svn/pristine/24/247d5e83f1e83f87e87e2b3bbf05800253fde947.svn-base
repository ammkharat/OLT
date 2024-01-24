using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class AbstractFormPresenter<TForm, TDomainObject> 
        where TForm : IBaseForm 
        where TDomainObject : DomainObject
    {
        protected TForm view;
        protected TDomainObject editObject;
        protected bool shouldSkipConfirm;
        private static readonly ILog logger = GenericLogManager.GetLogger<AbstractFormPresenter<TForm,TDomainObject>>();
        protected readonly UserContext userContext;
        private int loadDataCount;

        private readonly ClientBackgroundWorker saveOrUpdateBackgroundWorker = new ClientBackgroundWorker();

        protected AbstractFormPresenter(TForm view)
            : this(view, default(TDomainObject))
        {
        }

        protected AbstractFormPresenter(TForm view, TDomainObject editObject)
        {
            this.view = view;
            this.editObject = editObject;
            userContext = ClientSession.GetUserContext();

            saveOrUpdateBackgroundWorker.DoWork += HandleSaveOrUpdateBackgroundWorkerDoWork;
            saveOrUpdateBackgroundWorker.RunWorkerCompleted += HandleSaveOrUpdateBackgroundWorkerCompleted;
        }

        public abstract bool ValidateViewHasError();

        public abstract void Insert(SaveUpdateDomainObjectContainer<TDomainObject> container);
        public abstract void Update(SaveUpdateDomainObjectContainer<TDomainObject> container);   
       
        public virtual bool IsEdit
        {
            get { return editObject != null && editObject.Id.HasValue; }
        }
      
        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            view.Close();
        }
       
        public virtual void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {            
            SaveOrUpdate(true);
        }

        protected virtual void DoPreSaveOrUpdateWorkBeforeShowingWaitForm(SaveUpdateDomainObjectContainer<TDomainObject> objectToPersist)
        {            
        }

        public void HandleFormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (ShouldCancelOnFormClosing())
            {
                eventArgs.Cancel = true;
            }
            else if (!ClientSession.GetInstance().ForceLogoff && !shouldSkipConfirm && !view.ConfirmCancelDialog())
            {
                eventArgs.Cancel = true;
            }
        }

        protected virtual bool ShouldCancelOnFormClosing()
        {
            return false;
        }
        
        protected void SaveOrUpdate(bool shouldCloseForm)
        {            
            try
            {                
                if (!ValidateViewHasError())
                {
                    SaveUpdateDomainObjectContainer<TDomainObject> objectToPersist = GetPopulatedObjectToPersistFromView();
                    DoPreSaveOrUpdateWorkBeforeShowingWaitForm(objectToPersist);
                    view.ShowWaitScreenAndDisableForm();
                    saveOrUpdateBackgroundWorker.RunWorkerAsync(new SaveOrUpdateBackgroundWorkerArgs(objectToPersist, IsEdit, shouldCloseForm));                                       
                }
            }
            catch (Exception e)
            {                 
                 logger.Error(StringResources.ServerSaveUpdateError, e);
            }            
        }

        private SaveUpdateDomainObjectContainer<TDomainObject> GetPopulatedObjectToPersistFromView()
        {
            SaveUpdateDomainObjectContainer<TDomainObject> populatedObject = IsEdit ? GetPopulatedEditObjectToUpdate() : GetNewObjectToInsert();
            return populatedObject;
        }

        protected abstract SaveUpdateDomainObjectContainer<TDomainObject> GetNewObjectToInsert();      
        protected abstract SaveUpdateDomainObjectContainer<TDomainObject> GetPopulatedEditObjectToUpdate();     
        
        private void HandleSaveOrUpdateBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            SaveOrUpdateBackgroundWorkerArgs args = (SaveOrUpdateBackgroundWorkerArgs) e.Argument;
            bool isEdit = args.IsEdit;

            bool saveOrUpdateSuceeded = false;

            try
            {                
                if (isEdit)
                {                    
                    Update(args.ObjectToPersist);
                }
                else
                {
                    Insert(args.ObjectToPersist);
                }

                saveOrUpdateSuceeded = true;
            }
            catch (Exception exception)
            {
                logger.Error(StringResources.ServerSaveUpdateError, exception);
            }

            e.Result = new SaveOrUpdateBackgroundWorkerResult(saveOrUpdateSuceeded, args.ShouldCloseForm);
        }

        private void HandleSaveOrUpdateBackgroundWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SaveOrUpdateBackgroundWorkerResult result = (SaveOrUpdateBackgroundWorkerResult) e.Result;

            if (result.SaveOrUpdateSucceeded)
            {    
                if (result.ShouldCloseForm)
                {
                    shouldSkipConfirm = true;                    
                    view.Close();
                }
            }
            else
            {
                view.SaveFailedMessage();
                view.Close();
            }
                        
            view.CloseWaitScreenAndEnableForm();
            
            SaveOrUpdateComplete(result.SaveOrUpdateSucceeded);
        }

        protected virtual void SaveOrUpdateComplete(bool saveOrUpdateSucceeded)
        {
            
        }

        private class SaveOrUpdateBackgroundWorkerArgs
        {
            public SaveOrUpdateBackgroundWorkerArgs(SaveUpdateDomainObjectContainer<TDomainObject> objectToPersist, bool isEdit, bool shouldCloseForm)
            {
                ObjectToPersist = objectToPersist;
                IsEdit = isEdit;
                ShouldCloseForm = shouldCloseForm;
            }

            public SaveUpdateDomainObjectContainer<TDomainObject> ObjectToPersist { get; private set; }
            public bool IsEdit { get; private set; }
            public bool ShouldCloseForm { get; private set; }
        }
        
        private class SaveOrUpdateBackgroundWorkerResult
        {
            public SaveOrUpdateBackgroundWorkerResult(bool saveOrUpdateSucceeded, bool shouldCloseForm)
            {
                SaveOrUpdateSucceeded = saveOrUpdateSucceeded;
                ShouldCloseForm = shouldCloseForm;                
            }
            
            public bool SaveOrUpdateSucceeded { get; private set; }
            public bool ShouldCloseForm { get; private set; }            
        }

        protected virtual void LoadData(List<Action> loadDataDelegates)
        {
            view.SetFormVisibleState(false);
            view.ShowWaitScreenAndDisableForm();

            foreach (Action loadDataDelegate in loadDataDelegates)
            {
                lock (this)
                {
                    loadDataCount++;
                }

                BackgroundHelper<object, object> backgroundHelper = new BackgroundHelper<object, object>(new ClientBackgroundWorker(), new DataFetcher(CarryOnIfAllDataIsDoneLoading, loadDataDelegate, HandleDataLoadError));
                backgroundHelper.Run(null);
            }
        }

        private void CarryOnIfAllDataIsDoneLoading()
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
    }
}