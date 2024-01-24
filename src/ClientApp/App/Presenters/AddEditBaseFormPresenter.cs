using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class AddEditBaseFormPresenter<TView, TDomainObject> : BaseFormPresenter<TView>
        where TView : class, IAddEditBaseFormView 
        where TDomainObject : DomainObject
    {
        protected bool shouldSkipConfirm;
        private static readonly ILog logger = LogManager.GetLogger(typeof(AddEditBaseFormPresenter<TView, TDomainObject>));

        protected readonly UserContext userContext;
        protected TDomainObject editObject;

        protected AddEditBaseFormPresenter(TView view, TDomainObject editObject):base(view)
        {
            this.editObject = editObject;
            userContext = ClientSession.GetUserContext();
           
            view.FormClosing += HandleFormClosing;
            view.SaveButtonClicked += HandleSaveAndCloseButtonClicked;
            view.CancelButtonClicked += CancelButton_Click;
        }

        protected abstract bool ValidateViewHasError();
        protected abstract void Insert();
        protected abstract void Update();

        public IForm View
        {
            get { return view; }
        }

        protected virtual void HandleFormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if ((DontShowCloseFormMessage) || ((System.Windows.Forms.Form)sender).Text == "View Eip Template") return;                 //ayman Sarnia eip

            if (!ClientSession.GetInstance().ForceLogoff && !shouldSkipConfirm && !view.ConfirmCancelDialog())
            {
                eventArgs.Cancel = true;
            }
        }

        protected virtual bool IsClone
        {
            get { return editObject != null && editObject.Id.HasNoValue(); }
        }

        protected bool IsEdit
        {
            get { return editObject != null && editObject.Id.HasValue; }
        }

        protected bool IsExtension
        {
            get { return editObject != null && editObject.Id.HasValue; }
        }
        protected bool IsRevalidation
        {
            get { return editObject != null && editObject.Id.HasValue; }
        }

        protected bool IsNew
        {
            get { return editObject == null; }    
        }

        protected virtual void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            ValidateThenSaveOrUpdate(true);
        }

        //ayman Sarnia eip DMND0008992
        protected virtual void HandleWaitingApprovalClicked(object sender, EventArgs eventArgs)
        {

        }

        private void ValidateThenSaveOrUpdate(bool shouldCloseForm)
        {            
            try
            {
                if (!Validate())
                {
                    SaveOrUpdate(shouldCloseForm);                    
                }
            }
           catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
            }           
        }

        protected void HandleSaveOrUpdateException(Exception e)
        {
            view.SaveFailedMessage();
            logger.Error(StringResources.ServerSaveUpdateError, e);            
        }

        protected virtual void SaveOrUpdate(bool shouldCloseForm)
        {
            if (IsEdit)
            {
                Update();
            }
            else
            {
                Insert();
            }
                        
            if (shouldCloseForm)
            {
                shouldSkipConfirm = true;
                view.Close();
            }
        }

        protected bool Validate()
        {
            view.ClearErrorProviders();
            return ValidateViewHasError();
        }
    }
}