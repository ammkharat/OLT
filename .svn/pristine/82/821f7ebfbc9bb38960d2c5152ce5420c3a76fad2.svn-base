using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Infragistics.Win.UltraImageEditor;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// ----------------------------------------------------------------------------------------
    /// <summary>
    /// A tree view with tri-state check boxes
    /// </summary>
    /// <remarks>
    /// REVIEW: If we want to have icons in addition to the check boxes, we probably have to 
    /// set the icons for the check boxes in a different way. The windows tree view control
    /// can have a separate image list for states.
    /// </remarks>
    /// ----------------------------------------------------------------------------------------
    public class OltTriStateTreeView : OltTreeView
    {
        public event Action UserClickCausedCheckChange;

        private ImageList m_TriStateImages;
        private IContainer components;
        private bool checkParentIfAllSiblingsAreChecked = false;
        private bool readOnly;

        private readonly Dictionary<CheckState, CheckStateImage> stateToImageMap = new Dictionary<CheckState, CheckStateImage>();
        private readonly Dictionary<CheckStateImage, CheckState> imageToStateMap = new Dictionary<CheckStateImage, CheckState>(); 

        public enum CheckState
        {
            GreyChecked = 0,
            Unchecked = 1,
            Checked = 2
        }

        /// <remarks>The states corresponds to image index</remarks>
        private enum CheckStateImage
        {
            GreyChecked = 0,
            Unchecked = 1,
            Checked = 2,
            UncheckedDisabled = 3,
            GreyCheckedAsMainNode = 4
        }

        public bool CheckParentIfAllSiblingsAreChecked
        {
            set { checkParentIfAllSiblingsAreChecked = value; }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                stateToImageMap.Clear();

                if (readOnly)
                {
                    stateToImageMap.Add(CheckState.Checked, CheckStateImage.GreyCheckedAsMainNode);
                    stateToImageMap.Add(CheckState.Unchecked, CheckStateImage.UncheckedDisabled);
                    stateToImageMap.Add(CheckState.GreyChecked, CheckStateImage.GreyChecked);
                }
                else
                {
                    stateToImageMap.Add(CheckState.Checked, CheckStateImage.Checked);
                    stateToImageMap.Add(CheckState.Unchecked, CheckStateImage.Unchecked);
                    stateToImageMap.Add(CheckState.GreyChecked, CheckStateImage.GreyChecked);
                }

                imageToStateMap.Clear();
                foreach (KeyValuePair<CheckState, CheckStateImage> keyValuePair in stateToImageMap)
                {
                    imageToStateMap[keyValuePair.Value] = keyValuePair.Key;
                }

                SetDefaultImages();
            }
        }

        private void SetDefaultImages()
        {
            ImageIndex = (int) stateToImageMap[CheckState.Unchecked];
            SelectedImageIndex = (int) stateToImageMap[CheckState.Unchecked];
        }

        #region Redefined Win-API structs and methods

        /// <summary></summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TV_HITTESTINFO
        {
            /// <summary>Client coordinates of the point to test.</summary>
            public Point pt;

            /// <summary>Variable that receives information about the results of a hit test.</summary>
            public TVHit flags;

            /// <summary>Handle to the item that occupies the point.</summary>
            public IntPtr hItem;
        }

        /// <summary>Hit tests for tree view</summary>
        [Flags]
        public enum TVHit
        {
            /// <summary>In the client area, but below the last item.</summary>
            NoWhere = 0x0001,
            /// <summary>On the bitmap associated with an item.</summary>
            OnItemIcon = 0x0002,
            /// <summary>On the label (string) associated with an item.</summary>
            OnItemLabel = 0x0004,
            /// <summary>In the indentation associated with an item.</summary>
            OnItemIndent = 0x0008,
            /// <summary>On the button associated with an item.</summary>
            OnItemButton = 0x0010,
            /// <summary>In the area to the right of an item. </summary>
            OnItemRight = 0x0020,
            /// <summary>On the state icon for a tree-view item that is in a user-defined state.</summary>
            OnItemStateIcon = 0x0040,
            /// <summary>On the bitmap or label associated with an item. </summary>
            OnItem = (OnItemIcon | OnItemLabel | OnItemStateIcon),
            /// <summary>Above the client area. </summary>
            Above = 0x0100,
            /// <summary>Below the client area.</summary>
            Below = 0x0200,
            /// <summary>To the right of the client area.</summary>
            ToRight = 0x0400,
            /// <summary>To the left of the client area.</summary>
            ToLeft = 0x0800
        }

        /// <summary></summary>
        public enum TreeViewMessages
        {
            /// <summary></summary>
            TV_FIRST = 0x1100, // TreeView messages
            /// <summary></summary>
            TVM_HITTEST = (TV_FIRST + 17),
        }

        /// <summary></summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, TreeViewMessages msg, int wParam, ref TV_HITTESTINFO lParam);

        #endregion

        #region Constructor and destructor

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// ------------------------------------------------------------------------------------
        public OltTriStateTreeView()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // Notes: The order of the images matter. Also, I couldn't figure out how to add images to the existing list in the resource file which is why
            // I am adding some programmatically.
            ImageList = m_TriStateImages;
            AddToImageList(CheckBoxState.UncheckedDisabled);
            AddToImageList(CheckBoxState.CheckedDisabled);

            ReadOnly = false;
            SetDefaultImages();
        }


        /// -----------------------------------------------------------------------------------
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged 
        /// resources; <c>false</c> to release only unmanaged resources. 
        /// </param>
        /// -----------------------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Component Designer generated code

        /// -----------------------------------------------------------------------------------
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// -----------------------------------------------------------------------------------
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (OltTriStateTreeView));
            this.m_TriStateImages = new System.Windows.Forms.ImageList(this.components);
            // 
            // m_TriStateImages
            // 
            this.m_TriStateImages.ImageSize = new System.Drawing.Size(16, 16);
            this.m_TriStateImages.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("m_TriStateImages.ImageStream")));
            this.m_TriStateImages.TransparentColor = System.Drawing.Color.Magenta;
        }

        #endregion

        #region Hide no longer appropriate properties from Designer

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// get will always return true, not settable anymore
        /// </summary>
        /// ------------------------------------------------------------------------------------
        [Browsable(false)]
        public new bool CheckBoxes
        {
            get { return false; }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------
        [Browsable(false)]
        public new int ImageIndex
        {
            get { return base.ImageIndex; }
            set { base.ImageIndex = value; }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------
        [Browsable(false)]
        public new ImageList ImageList
        {
            get { return base.ImageList; }
            set { base.ImageList = value; }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// ------------------------------------------------------------------------------------
        [Browsable(false)]
        public new int SelectedImageIndex
        {
            get { return base.SelectedImageIndex; }
            set { base.SelectedImageIndex = value; }
        }

        #endregion

        #region Overrides

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Called when the user clicks on an item
        /// </summary>
        /// <param name="e"></param>
        /// ------------------------------------------------------------------------------------
        protected override void OnClick(EventArgs e)
        {
            if (ReadOnly)
            {
                return;
            }

            TV_HITTESTINFO hitTestInfo = new TV_HITTESTINFO();
            hitTestInfo.pt = PointToClient(MousePosition);

            SendMessage(Handle, TreeViewMessages.TVM_HITTEST,
                        0, ref hitTestInfo);
            if ((hitTestInfo.flags & TVHit.OnItemIcon) == TVHit.OnItemIcon)
            {
                TreeNode node = GetNodeAt(hitTestInfo.pt);
                if (node != null)
                {
                    ChangeNodeState(node);
                    if (UserClickCausedCheckChange != null)
                    {
                        UserClickCausedCheckChange();
                    }
                }
            }
            base.OnClick(e);
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Toggle item if user presses space bar
        /// </summary>
        /// <param name="e"></param>
        /// ------------------------------------------------------------------------------------
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !ReadOnly)
            {
                TreeNode treeNode = SelectedNode;
                if (treeNode != null)
                {
                    ChangeNodeState(treeNode);
                }
            }
            base.OnKeyDown(e);
        }

        #endregion

        #region Private methods

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Check node, checking all children as well. Will also check the parent node if all siblings are checked.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="state"></param>
        /// <param name="childCheckState"></param>
        /// ------------------------------------------------------------------------------------
        protected void CheckNode(TreeNode node, CheckState state, CheckState childCheckState)
        {
            InternalSetChecked(node, state);

            foreach (TreeNode child in node.Nodes)
            {
                CheckNode(child, childCheckState, childCheckState);
            }

            if (checkParentIfAllSiblingsAreChecked && node.Parent != null && GetChecked(node.Parent) == CheckState.Unchecked)
            {
                bool shouldCheckParent = true;
                foreach (TreeNode sibling in node.Parent.Nodes)
                {
                    if (GetChecked(sibling) == CheckState.Unchecked)
                    {
                        shouldCheckParent = false;
                    }
                }

                if (shouldCheckParent)
                {
                    CheckNode(node.Parent, CheckState.Checked, CheckState.GreyChecked);
                }
            }
        }

        protected void ChangeNodeState(TreeNode node)
        {
            ChangeNodeState(node, true);
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Handles changing the state of a node
        /// </summary>
        /// <param name="node"></param>
        /// ------------------------------------------------------------------------------------
        protected void ChangeNodeState(TreeNode node, bool doDisablingAndEnablingOfTreeView)
        {
            // Disable greyChecked node
            if (CheckState.GreyChecked != GetChecked(node))
            {
                // If you're changing the node state of a lot of nodes, it gives significantly better performance to wrap the whole set in a BeginUpdate/EndUpdate. This is why
                // we allow the caller to turn off doing the BeginUpdate/EndUpdate for each node.
                if (doDisablingAndEnablingOfTreeView)
                {
                    BeginUpdate();    
                }
                
                if (CheckState.Checked == GetChecked(node))
                {
                    CheckNode(node, CheckState.Unchecked, CheckState.Unchecked);
                }
                else
                {
                    CheckNode(node, CheckState.Checked, CheckState.GreyChecked);
                }

                if (doDisablingAndEnablingOfTreeView)
                {
                    EndUpdate();
                }
            }
        }

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Sets the checked state of a node, but doesn't deal with children or parents
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="state">The new checked state</param>
        /// <returns><c>true</c> if checked state was set to the requested state, otherwise
        /// <c>false</c>.</returns>
        /// ------------------------------------------------------------------------------------
        private void InternalSetChecked(TreeNode node, CheckState state)
        {
            TreeViewCancelEventArgs args =
                new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown);
            OnBeforeCheck(args);
            
            if (args.Cancel)
                return;

            node.ImageIndex = (int) stateToImageMap[state];
            node.SelectedImageIndex = (int) stateToImageMap[state];

            OnAfterCheck(new TreeViewEventArgs(node, TreeViewAction.Unknown));
        }

        private void AddToImageList(CheckBoxState state)
        {
            Bitmap image = new Bitmap(16, 16);
            Graphics grfx = Graphics.FromImage(image);
            CheckBoxRenderer.DrawCheckBox(grfx, new Point(0, 0), state);
            ImageList.Images.Add(image);
            grfx.Dispose();
        }

        #endregion

        #region Public methods

        /// ------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the checked state of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>The checked state</returns>
        /// ------------------------------------------------------------------------------------
        public CheckState GetChecked(TreeNode node)
        {
            if (node.ImageIndex < 0)
                return CheckState.Unchecked;
            
            CheckStateImage image = (CheckStateImage) node.ImageIndex;
            return imageToStateMap[image];
        }

        public bool IsChecked(TreeNode node)
        {
            return GetChecked(node) == CheckState.Checked;
        }

        public bool IsUnchecked(TreeNode node)
        {
            return GetChecked(node) == CheckState.Unchecked;
        }

        #endregion

        protected void SetToGreyChecked(TreeNode node)
        {
            CheckNode(node, CheckState.GreyChecked, CheckState.GreyChecked);
        }
    }
}