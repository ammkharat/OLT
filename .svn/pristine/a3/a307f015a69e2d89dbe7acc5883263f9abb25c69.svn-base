using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class SingleSelectFunctionalLocationControl : UserControl, IFunctionalLocationSearchView
    {
        public TreeViewEventHandler AfterSelect;

        private readonly FunctionalLocationSearchPresenter searchPresenter;
        private IFunctionalLocationLookup flocLookup;

        public SingleSelectFunctionalLocationControl()
        {
            InitializeComponent();

            searchPresenter = new FunctionalLocationSearchPresenter(this);
            searchTextBox.TextChanged += searchPresenter.HandleSearchTextBox_TextChanged;
            searchTextBox.KeyPress += searchTextBox_KeyPress;
            searchButton.Click += searchPresenter.HandleFindNextButton_Click;

            treeView.AfterSelect += HandleTreeView_AfterSelect;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            treeView.LoadRootFunctionalLocations(flocLookup);
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (searchTextBox != null && !string.IsNullOrEmpty(searchTextBox.Text))
                {
                    searchPresenter.HandleFindNextButton_Click(null, EventArgs.Empty);
                    e.Handled = true;
                }
            }
        }

        private void HandleTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (AfterSelect != null)
            {
                AfterSelect(sender, e);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public FunctionalLocationMode Mode
        {
            set
            {
                searchPresenter.Mode = value;
                treeView.FunctionalLocationTreeViewMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IFunctionalLocationTreeNodeFilter NodeFilter
        {
            set { treeView.NodeFilter = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IFunctionalLocationLookup FunctionalLocationLookup
        {
            set { flocLookup = value; }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return treeView.SelectedFunctionalLocation; } 
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<FunctionalLocation> SiblingsOfSelectedFunctionalLocation
        {
            get { return treeView.SiblingsOfSelectedFunctionalLocation; }
        }

        public List<FunctionalLocation> ChildrenOfSelectedFunctionalLocation
        {
            get { return treeView.ChildrenOfSelectedFunctionalLocation; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string SearchText
        {
            get { return searchTextBox.Text; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool FindNextButtonEnabled
        {
            set { searchButton.Enabled = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IList<FunctionalLocation> RootFunctionalLocations
        {
            get
            {
                List<FunctionalLocation> rootFlocs = new List<FunctionalLocation>();
                foreach (FunctionalLocationTreeNode node in treeView.RootNodeCollection)
                {
                    rootFlocs.Add(node.Tag);
                }
                return rootFlocs;
            }
        }

        public Form GetActiveForm()
        {
            return ParentForm;
        }

        public bool SelectResult(FunctionalLocation floc)
        {
            if (floc != null)
            {
                treeView.AddMissingFunctionalLocations(floc);
                if (treeView.CanSelectFunctionalLocation(floc))
                {
                    treeView.SelectedFunctionalLocation = floc;
                    return true;
                }
                return false;
            }
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public FunctionalLocation HighlightedFunctionalLocation
        {
            get { return SelectedFunctionalLocation; }
        }

        public bool IsSelectedValid
        {
            get { return treeView.IsSelectedValid; }
        }

        public FunctionalLocation ParentOfSelectedFunctionalLocation
        {
            get { return treeView.ParentOfSelectedFunctionalLocation; }
        }

        public void RemoveSelectedFunctionalLocation()
        {
            treeView.RemoveSelectedItem();
        }

        public void UpdateSelectedItem(FunctionalLocation functionalLocation)
        {
            treeView.UpdateSelectedItem(functionalLocation);
        }

        public void AddNewFunctionalLocation(FunctionalLocation insertedFunctionalLocation)
        {
            treeView.AddNewFunctionalLocation(insertedFunctionalLocation);
        }
    }
}