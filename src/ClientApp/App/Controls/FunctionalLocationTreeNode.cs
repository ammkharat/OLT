using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public class FunctionalLocationTreeNode : TreeNode
    {
        private readonly FunctionalLocation floc;        

        public FunctionalLocationTreeNode(FunctionalLocation floc)
        {
            this.floc = floc;
            Text = floc.FullHierarchyWithDescription;
        }

        public FunctionalLocationTreeNode(FunctionalLocation floc, bool addPlaceHolderNode) : this(floc)
        {
            if (addPlaceHolderNode)
            {
                FunctionalLocationTreeNode holderFor = CreateChildPlaceHolderFor(floc);
                Nodes.Add(holderFor);
            }
        }

        public new FunctionalLocation Tag
        {
            get { return floc; }
        }

        public IEnumerable<FunctionalLocation> GetChildrenDataInDepthFirst()
        {
            yield return floc;
            foreach (FunctionalLocationTreeNode child in Nodes)
            {
                if (!child.IsPlaceholder)
                {
                    foreach (FunctionalLocation childInDepthFirst in child.GetChildrenDataInDepthFirst())
                        yield return childInDepthFirst;                    
                }
            }
        }

        private static FunctionalLocationTreeNode CreateChildPlaceHolderFor(FunctionalLocation functionalLocation)
        {
            var placeHolderFloc = new FunctionalLocation(functionalLocation);
            placeHolderFloc.Id *= -1;
            placeHolderFloc.Description = string.Empty;

            placeHolderFloc.FullHierarchy = StringResources.FunctionalLocationExpandingPlaceholder;
            return new FunctionalLocationTreeNode(placeHolderFloc, false);
        }


        /// <summary>
        /// If this node has a child placeholder node, then return true. Otherwise, false.
        /// </summary>
        public bool HasPlaceholder
        {
            get
            {
                FunctionalLocationTreeNode holderFor =
                    CreateChildPlaceHolderFor(Tag);

                return Nodes.Count == 1 && ((FunctionalLocationTreeNode) Nodes[0]).Tag.Equals(holderFor.Tag);
            }
        }

        public bool IsPlaceholder
        {
            get
            {
                return Tag.FullHierarchy == StringResources.FunctionalLocationExpandingPlaceholder;
            }
        }

        public TreeNode ParentUnitNode
        {
            get 
            {
                return FindParentNodeOfSpecifiedFLOCType(this, FunctionalLocationType.Level3);
            }
        }

        public TreeNode ParentSectionNode
        {
            get 
            {
                return FindParentNodeOfSpecifiedFLOCType(this, FunctionalLocationType.Level2);
            }
        }

        public TreeNode ParentDivisionNode
        {
            get 
            {
                return FindParentNodeOfSpecifiedFLOCType(this, FunctionalLocationType.Level1);
            }
        }

        public TreeNode ParentEquipment1Node
        {
            get 
            {
                return FindParentNodeOfSpecifiedFLOCType(this, FunctionalLocationType.Level4);
            }
        }

        private static FunctionalLocationTreeNode FindParentNodeOfSpecifiedFLOCType(FunctionalLocationTreeNode treeNode, FunctionalLocationType flocType)
        {
            if (treeNode == null)
            {
                return null;
            }

            FunctionalLocationType myFLOCType = treeNode.floc.Type;
            return myFLOCType == flocType
                       ? treeNode
                       : FindParentNodeOfSpecifiedFLOCType(treeNode.Parent as FunctionalLocationTreeNode, flocType);
        }

        public static List<FunctionalLocationTreeNode> Convert(List<FunctionalLocationInfo> flocInfos, FunctionalLocationMode mode)
        {
            return flocInfos.ConvertAll(flocInfo =>
                                            {
                                                FunctionalLocationType childFlocType = flocInfo.Floc.Type + 1;
                                                bool shouldAddPlaceholder = flocInfo.HasChildren &&
                                                                            mode.IsAllowed(childFlocType);

                                                return new FunctionalLocationTreeNode(flocInfo.Floc, shouldAddPlaceholder);
                                            });
        }

        public FunctionalLocationTreeNode[] ChildFunctionalLocationTreeNodes
        {
            get
            {
                TreeNodeCollection nodes = Nodes;
                var children = new FunctionalLocationTreeNode[nodes.Count];
                nodes.CopyTo(children, 0);
                return children;
            }
        }

        public bool IsUserSelectable
        {
            get
            {
                return ForeColor != Color.DarkGray;
            }
            set {
                if (!value)
                    ForeColor = Color.DarkGray;
            }
        }

        public bool Equals(FunctionalLocationTreeNode obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.floc, floc);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (FunctionalLocationTreeNode)) return false;
            return Equals((FunctionalLocationTreeNode) obj);
        }

        public override int GetHashCode()
        {
            return (floc != null ? floc.GetHashCode() : 0);
        }

        public void SetUserSelectableBasedOnSource()
        {
            if (floc.Source == FunctionalLocationSource.SAP)
            {
                IsUserSelectable = false;
            }
        }
    }
}
