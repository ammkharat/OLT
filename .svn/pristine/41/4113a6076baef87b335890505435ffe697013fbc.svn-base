using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class BaseFormPresenter<T> : IRunnablePresenter where T : class, IBaseForm 
    {
        private int loadDataCount;
        protected readonly T view;
        protected bool DontShowCloseFormMessage = false;         //ayman Sarnia eip

        protected BaseFormPresenter(T view)
        {
            this.view = view;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //if (((System.Windows.Forms.ButtonBase)((System.Windows.Forms.ContainerControl)sender).ActiveControl).Text == "Exit")                 //ayman Sarnia eip
            if (((ButtonBase)(sender)).Text == "Exit" || ((ButtonBase)(sender)).Text == "Close")     //Added by Vibhor to fix the OLT Form Cancel button issue   
            {
                DontShowCloseFormMessage = true;
            }
            else
            {
                CancelButton_Click();
            }
        }


        protected void CancelButton_Click()
        {
            view.DialogResult = DialogResult.Cancel;
            view.Close();
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
