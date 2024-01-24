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
    public partial class MultiSelectFunctionalLocationControl : UserControl, IFunctionalLocationSearchView
    {
        public event Action UserClickCausedCheckChange;

        private readonly FunctionalLocationSearchPresenter searchPresenter;

        public MultiSelectFunctionalLocationControl()
        {
            InitializeComponent();

            treeView.UserClickCausedCheckChange += TreeView_UserClickCausedCheckChange;

            searchPresenter = new FunctionalLocationSearchPresenter(this);
            searchTextBox.TextChanged += searchPresenter.HandleSearchTextBox_TextChanged;
            searchButton.Click += searchPresenter.HandleFindNextButton_Click;

            searchTextBox.OltAcceptsReturn = true;
            searchTextBox.KeyPress += searchTextBox_KeyPress;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            treeView.Initialize(new FunctionalLocationLookup());
        }

        public bool TreeViewReadOnly
        {
            set
            {
                treeView.ReadOnly = value;
            }
        }

        private void TreeView_UserClickCausedCheckChange()
        {
            if (UserClickCausedCheckChange != null)
            {
                UserClickCausedCheckChange();
            }
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char) Keys.Enter)
            {
                if(searchTextBox != null && !string.IsNullOrEmpty(searchTextBox.Text))
                {
                    searchPresenter.HandleFindNextButton_Click(null, EventArgs.Empty);
                    e.Handled = true;    
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool ShowSearchPanel
        {
            set { searchPanel.Visible = value; }
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
        public IList<FunctionalLocation> UserCheckedFunctionalLocations
        {
            get { return treeView.UserCheckedFunctionalLocations; }
            set { treeView.UserCheckedFunctionalLocations = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<FunctionalLocation> AllCheckedFunctionalLocations
        {
            get { return treeView.AllCheckedFunctionalLocations; }
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
                if (treeView.CanSelectFunctionalLocation(floc))
                {
                    treeView.SelectedFunctionalLocationNode = floc;
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
            get { return treeView.SelectedFunctionalLocationNode; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IFunctionalLocationTreeNodeFilter NodeFilter
        {
            set { treeView.NodeFilter = value; }
        }

        public bool IsSelectedValid
        {
            get { return treeView.IsSelectedValid; }
        }

        public bool CheckParentIfAllSiblingsAreChecked
        {
            set { treeView.CheckParentIfAllSiblingsAreChecked = value; }
        }

        public bool CanCheckFunctionalLocation(FunctionalLocation floc)
        {
            return treeView.CanCheckFunctionalLocation(floc);
        }
    }
}
