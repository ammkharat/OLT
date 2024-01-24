using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public abstract class AbstractMultiGridPage : BaseMultiGridPage, IItemSelectablePage
    {
        private IMultiGridContext currentContext;
        private readonly Dictionary<IMultiGridContextSelection, IMultiGridContext> contexts = new Dictionary<IMultiGridContextSelection, IMultiGridContext>();
                 
        public event EventHandler DetailsChanged;
        public event EventHandler ButtonsChanged;
        
        public bool ButtonsEnabled
        {
            get { return true; }
            set { ; }
        }
               
        public void ShowUnableToReturnTheAmountOfDataRequestedError(string message)
        {
            OltMessageBox.Show(Form.ActiveForm, message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
        public abstract PageKey PageKey { get; }
        public abstract string TabText { get; }
        public abstract Type PageDtoType { get; }
        public abstract bool CanSelectItemFromAnotherPage { get; }
        
        public abstract void SelectSingleItemById(long? id);
        public abstract void ClearSelectionsAndSelectItemsById(List<long> ids);
        public abstract void SelectSingleItemByIndex(int index);
        public abstract bool ContainsItemById(long? id);        
        
        public void LaunchLockDeniedMessage(string nameOfUserWithCurrentLock, LockType lockType)
        {
            PageHelper.LaunchLockDeniedMessage(Form.ActiveForm, nameOfUserWithCurrentLock, lockType);           
        }
        
        public DialogResultAndOutput<Range<Date>> DisplayDateRangeDialog()
        {
            return PageHelper.DisplayDateRangeDialog(ParentForm);
        }

        public IDomainSummaryGrid Grid
        {
            get { return currentContext.Grid; }           
        }

        public List<DomainObject> SelectedDTOs
        {
            get { return currentContext.SelectedItems; }           
        }

        public IMainForm MainParentForm
        {
            get { return (IMainForm) ParentForm; }
        }

        public void SetGridAndDetails(IDomainSummaryGrid grid, IDetails details)
        {
            SetComponents(grid, details);
        }

        public bool IsItemSelected()
        {
            if (currentContext == null)
            {
                return false;
            }

            return currentContext.IsItemSelected;
        }

        public void LoadContexts(List<IMultiGridContext> list)
        {
            foreach (IMultiGridContext item in list)
            {
                contexts.Add(item.Key, item);
            }
        }

        public IMultiGridContext GetContext(IMultiGridContextSelection selection)
        {
            return contexts[selection];
        }

        public IMultiGridContext CurrentGridContext
        {
            get { return currentContext; }
            set { currentContext = value; }
        }

        public IList<DomainObject> Items
        {
            get { return currentContext.Items; }
            set { currentContext.Items = value; }
        }

        public List<IMultiGridContext> AllContexts
        {
            get { return new List<IMultiGridContext>(contexts.Values); }
        }
       
        public void DeleteSuccessfulMessage()
        {
            PageHelper.DeleteSuccessfulMessage();
        }

        public bool ShowOKCancelDialog(string dialogText, string title)
        {
            return PageHelper.ShowOKCancelDialog(dialogText, title);
        }

        public void RegisterDetailsChanged()
        {
            if (DetailsChanged != null)
            {
                DetailsChanged(this, EventArgs.Empty);
            }
        }

        public void RegisterButtonsChanged()
        {
            if (ButtonsChanged != null)
            {
                ButtonsChanged(this, EventArgs.Empty);
            }    
        }

        public GridLayoutAction ShowGridLayoutConfirmationDialog()
        {
            return PageHelper.ShowGridLayoutConfirmationDialog(this);
        }

        public string GetGridLayoutXml()
        {
            return PageHelper.GetGridLayoutXml(Grid);
        }

        public void LoadGridLayout(string xml)
        {
            PageHelper.LoadGridLayout(xml, Grid);
        }      
    }
}
