using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class LocationItemTreeView : OltTreeView
    {
        public LocationItemTreeView()
        {
            InitializeComponent();
        }

        private TreeNode CreateTreeNodeFrom(LocationItemTreeItem item)
        {
            TreeNode treeNode = new TreeNode(item.Name) { Name = item.Id.ToString(CultureInfo.InvariantCulture), Tag = item };
            return treeNode;
        }
        public void LoadItems(List<LocationItemTreeItem> value)
        {
            BeginUpdate();

            Nodes.Clear();
            LocationItemTreeItem rootItem = value.Find(item => item.IsFakeRoot);
            if (rootItem != null)
            {
                TreeNode rootTreeNode = CreateTreeNodeFrom(rootItem);
                rootTreeNode.ForeColor = Color.Gray;

                Nodes.Add(rootTreeNode);

                foreach (LocationItemTreeItem item in value)
                {
                    if (item.Id == rootItem.Id)
                    {
                        continue;
                    }
                    TreeNode[] nodes = Nodes.Find(item.ParentId.ToString(CultureInfo.InvariantCulture), true);
                    if (nodes.Length == 1)
                    {
                        TreeNode treeNode = CreateTreeNodeFrom(item);
                        if (!item.HasReasonCodes || item.FunctionalLocation == null)
                        {
                            treeNode.ForeColor = Color.Gray;
                        }
                        nodes[0].Nodes.Add(treeNode);
                    }
                }
            }
            EndUpdate();
        }

        public void RemoveSelectedNode()
        {
            TreeNode selectedNode = SelectedNode;
            if (selectedNode == null)
                return;

            BeginUpdate();
                
            int indexOfOldNode = selectedNode.Index;
            TreeNode parentNode = selectedNode.Parent;
            parentNode.Nodes.RemoveAt(indexOfOldNode);
            
            // change the selected Item to the parent.
            SelectedNode = parentNode;

            EndUpdate();
        }

        public void AddItemToSelectedNode(LocationItemTreeItem childItem)
        {
            TreeNode selectedNode = SelectedNode;
            if (selectedNode == null)
                return;

            BeginUpdate();
            
            TreeNode newTreeNode = CreateTreeNodeFrom(childItem);
            newTreeNode.ForeColor = Color.Gray;

            bool itemInserted = false;
            for (int index = 0; index <= selectedNode.Nodes.Count - 1; index++)
            {
                TreeNode childNode = selectedNode.Nodes[index];
                if (string.Compare(childNode.Text, newTreeNode.Text, StringComparison.CurrentCulture) > 0)
                {
                    selectedNode.Nodes.Insert(index, newTreeNode);
                    itemInserted = true;
                    break;
                }
            }
            // we add after the loop because we might actually want to add the new node at the end of the list in the case that the node should go at the end.
            if (!itemInserted)
            {
                selectedNode.Nodes.Add(newTreeNode);
            }

            EndUpdate();
        }

        public void ReplaceSelectedNode(LocationItemTreeItem newItem)
        {
            TreeNode oldItem = SelectedNode;
            if (oldItem == null)
                return;

            BeginUpdate();
            int indexOfOldNode = oldItem.Index;

            TreeNode[] childNodes = new TreeNode[oldItem.Nodes.Count];
            oldItem.Nodes.CopyTo(childNodes, 0);
            oldItem.Nodes.Clear();

            // Create the new node with the same color as the old one.
            TreeNode newTreeNode = CreateTreeNodeFrom(newItem);
            newTreeNode.ForeColor = oldItem.ForeColor;

            // copy the child nodes of the old one to the new one.
            newTreeNode.Nodes.AddRange(childNodes);

            TreeNode parentNode = oldItem.Parent;
            

            parentNode.Nodes.RemoveAt(indexOfOldNode);

            // get all the nodes at the same level
            TreeNode[] siblingNodes = new TreeNode[parentNode.Nodes.Count];
            parentNode.Nodes.CopyTo(siblingNodes, 0);
            
            List<TreeNode> treeNodes = siblingNodes.ToList();
            // add the new node to the list of it's siblings
            treeNodes.Add(newTreeNode);
            // sort the nodes alphabetically by the name.
            treeNodes.Sort((a,b) => string.Compare(a.Text, b.Text, StringComparison.CurrentCulture));
            parentNode.Nodes.Clear();
            // add the nodes back to the parent.
            treeNodes.ForEach(n => parentNode.Nodes.Add(n));

            EndUpdate();
        }

        public LocationItemTreeItem SelectedItem
        {
            get
            {
                TreeNode selectedItem = SelectedNode;
                if (selectedItem == null)
                    return null;

                return selectedItem.Tag as LocationItemTreeItem;
            }
            set
            {
                if (value == null)
                {
                    SelectedNode = null;
                }
                else
                {
                    TreeNode[] treeNodes = Nodes.Find(value.Id.ToString(CultureInfo.InvariantCulture), true);
                    if (treeNodes.Length == 1)
                    {
                        SelectedNode = treeNodes[0];
                    }
                }
            }
        }

        public LocationItemTreeItem SelectItemAndExpand
        {
            set
            {                
                SelectedItem = value;
                SelectedNode.Expand();
            }
        }

        public List<RestrictionLocationItem> GetFlatList()
        {           
            List<RestrictionLocationItem> allItems = new List<RestrictionLocationItem>();

            foreach (TreeNode treeNode in Nodes)
            {
                Traverse(treeNode, allItems);
            }

            return allItems;
        }

        private void Traverse(TreeNode treeNode, List<RestrictionLocationItem> output)
        {
            LocationItemTreeItem item = treeNode.Tag as LocationItemTreeItem;

            if (item != null)
            {
                output.Add(item.RestrictionLocationItem);
            }
            
            foreach (TreeNode node in treeNode.Nodes)
            {
                Traverse(node, output);
            }
        }
    }
}