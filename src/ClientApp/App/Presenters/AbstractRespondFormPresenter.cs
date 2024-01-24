using System;
using Com.Suncor.Olt.Client.Forms;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class AbstractRespondFormPresenter : IRespondFormPresenter
    {
        protected IRespondFormView view;
        protected bool createLogs;
        protected bool shouldSkipConfirm;
        protected readonly UserContext userContext;

        protected AbstractRespondFormPresenter()
        {
            createLogs = true;
            userContext = ClientSession.GetUserContext();
        }

        public IRespondFormView View
        {
            get { return view; }
            set { view = value; }
        }

        public virtual void HandleFormLoad(object sender, EventArgs args)
        {
            //view.CreateLogChecked = true; //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            view.Author = userContext.User;
            view.CreateDateTime = Clock.Now;
            view.Shift = userContext.UserShift.ShiftPatternName;
        }

        public void HandleFormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (!ClientSession.GetInstance().ForceLogoff && !shouldSkipConfirm && !view.ConfirmCancelDialog())
            {
                eventArgs.Cancel = true;
            }
        }

        public virtual void HandleCreateLogCheckedChanged(object sender, EventArgs e)
        {
            createLogs = !createLogs;

            if (createLogs)
            {
                view.EnableLogCreatedWithComments();
            }
            else
            {
                view.DisableLogCreatedWithComments();
                
            }
        }

        /// <summary>
        /// Saves the response with a corresponding log entry, returning <code>true</code> if successful; 
        /// <code>false</code> otherwise.
        /// </summary>
        protected abstract bool SaveWithLog();

        /// <summary>
        /// Saves the response only, returning <code>true</code> if successful; 
        /// <code>false</code> otherwise.
        /// </summary>
        protected abstract bool SaveWithoutLog();

        public void HandleSubmitButtonClick(object sender, EventArgs e)
        {
            bool saveSucceeded = createLogs ? SaveWithLog() : SaveWithoutLog();

            shouldSkipConfirm = true;
            
            if (saveSucceeded)
            {
                view.SaveSucceededMessage();
                view.DialogResult = DialogResult.OK;
                view.Close();
            }
            
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            // relies on the form closing event to bring up the cancel dialog
            view.Close();
        }
    }
}
