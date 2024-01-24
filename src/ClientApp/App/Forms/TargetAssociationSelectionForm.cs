using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class TargetAssociationSelectionForm : BaseForm, ITargetAssociationSelectionView
    {
        private readonly TargetAssociationFormPresenter presenter;
        private DomainListView<TargetDefinitionDTO> listView;
        private DomainListView<TargetDefinitionDTO> associatedListView;

        public TargetAssociationSelectionForm()
            :
                this(null)
        {
        }

        public TargetAssociationSelectionForm(TargetDefinition parentTagetDefinition)
        {
            presenter =
                new TargetAssociationFormPresenter(this, ClientServiceRegistry.Instance.GetService<ITargetDefinitionService>(),
                                                   parentTagetDefinition);
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();

            SearchButton.Click += presenter.SearchButtonClickEvent;
            addTargetBtn.Click += presenter.AddTargetAssociations;
            removeTargetBtn.Click += presenter.RemoveTargetAssociations;
            cancelButton.Click += presenter.CancelAssociations;
            saveButton.Click += presenter.SaveAssociations;

            listView = new DomainListView<TargetDefinitionDTO>(new AssociateTargetListViewRenderer(), true)
                           {Dock = DockStyle.Fill};
            searchResultGroupBox.Controls.Add(listView);
//            listPanel.Controls.Add(listView);

            associatedListView = new DomainListView<TargetDefinitionDTO>(new AssociateTargetListViewRenderer(), false)
                                     {Dock = DockStyle.Fill};
            AssociatedGroupBox.Controls.Add(associatedListView);
//            associatedPanel.Controls.Add(associatedListView);
            associatedListView.SelectedItemChanged += presenter.AssociatedListSelectedItemChanged;
            listView.SelectedItemChanged += presenter.ListViewSelectedItemChanged;
        }

        public List<TargetDefinitionDTO> SelectedAssociatedTargets
        {
            get { return GetSelectedItems(associatedListView); }
        }

        private static List<TargetDefinitionDTO> GetSelectedItems(DomainListView<TargetDefinitionDTO> domainListView)
        {
            List<TargetDefinitionDTO> result = null;
            if (domainListView.SelectedItems.Count > 0)
            {
                result = new List<TargetDefinitionDTO>();

                for (int i = 0; i < domainListView.SelectedItems.Count; i++)
                {
                    int selectedItemIndex = domainListView.SelectedItems[i].Index;
                    result.Add(domainListView.ItemList[selectedItemIndex]);
                }
            }

            return result;
        }

        public List<TargetDefinitionDTO> SelectedTargets
        {
            get { return GetSelectedItems(listView); }
        }


        public List<TargetDefinitionDTO> AssociatedTargets
        {
            get
            {
                return
                    associatedListView.ItemList ?? new List<TargetDefinitionDTO>();
            }
            set { associatedListView.ItemList = value; }
        }

        public List<TargetDefinitionDTO> Targets
        {
            set
            {
                listView.ItemList = value;
                if (value.Count > 0)
                    SelectFirstItemInList(value);
            }
        }

        private void SelectFirstItemInList(IList<TargetDefinitionDTO> definitions)
        {
            listView.SetSelectedItems(new List<TargetDefinitionDTO>{definitions[0]});
        }

        public string SearchText
        {
            get { return TargetNameTextBox.Text; }
        }

        public void CloseForm()
        {
            Close();
        }

        public void SetError(string errorMessage)
        {
            associationErrorProvider.SetError(saveButton, errorMessage);
        }

        public bool RemoveButtonEnabled
        {
            set { removeTargetBtn.Enabled = value; }
        }

        public bool AddButtonEnabled
        {
            set { addTargetBtn.Enabled = value; }
        }
    }
}