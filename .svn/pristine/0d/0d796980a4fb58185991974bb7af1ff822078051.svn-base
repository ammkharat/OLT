using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using DevExpress.XtraEditors.Controls;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SingleSelectFormGN75BTemplate : BaseForm, IFormGN75BTemplateSelectionForm
    {
        private readonly FormGN75BTemplateSelectionPresenter presenter;
        private FormGN75BTemplatePattern selectedForm;
        private DomainListView<FormGN75BTemplatePattern> listView;

        public SingleSelectFormGN75BTemplate(List<FormGN75BTemplatePattern> formlocLists)
        {
            Initialize();
            presenter = new FormGN75BTemplateSelectionPresenter(this, formlocLists);
            RegisterEventHandlersOnPresenter();       
        }

        private void Initialize()
        {
            InitializeComponent();
            AcceptButton = acceptButton;
            
            StartPosition = FormStartPosition.CenterParent;


            listView = new DomainListView<FormGN75BTemplatePattern>(new formSelectorListViewRenderer(), false);
            listView.Dock = DockStyle.Fill;
            shiftFlocPanel.Controls.Add(listView);
        }

        private void RegisterEventHandlersOnPresenter()
        {
            Load += presenter.HandleFormLoad;
            acceptButton.Click += presenter.HandleAcceptButtonClick;
            //listView.SelectedItemChanged += presenter.HandleSelectedItemChanged;
            //listView.DoubleClickSelected += presenter.HandleOnDoubleClick;            
        }


        public FormGN75BTemplatePattern SelectedFormGN75BTemplatePattern
        {
            set { selectedForm = value; }
            get { return selectedForm; }
        }

        public void CloseForm()
        {
            Close();
        }

        public DomainListView<FormGN75BTemplatePattern> SelectedFormGN75BTemplatelISTView
        {
            get { return listView; }
        }

        public void SelectItem(DomainObject selected)
        {
            foreach (DomainListViewItem<FormGN75BTemplatePattern> lvi in listView.Items)
            {
                if (lvi.Item.Equals(selected))
                {
                    lvi.Selected = true;
                    listView.Select();
                    break;
                }
            }
        }

        public int ListViewItemCount
        {
            get { return listView.Items.Count; }
        }

        public List<FormGN75BTemplatePattern> FormGN75BTemplatesToAddToListView
        {
            set { listView.ItemList = value; }
            get { return listView.ItemList; }
        }

        public bool formWasSelected()
        {
            return listView.SelectedItems != null;
        }

        //public bool SetNoShiftSelectedError
        //{
        //    set
        //    {
        //        noShiftSelectedErrorProvider.SetError(acceptButton,
        //                                              value ? StringResources.NoShiftSelectedError : string.Empty);
        //    }
        //}

        //public bool SetSelectedShiftWasOutsideOfAllowedTimeRangeError
        //{
        //    set
        //    {
        //        noShiftSelectedErrorProvider.SetError(
        //            acceptButton, value ? StringResources.AfterAllowedShiftSelectionWindowError : String.Empty);
        //    }
        //}

    }
}
