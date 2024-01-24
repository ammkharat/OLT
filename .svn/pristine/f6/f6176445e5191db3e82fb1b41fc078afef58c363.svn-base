using System.Windows.Forms;

namespace Com.Suncor.Olt.Client
{
    public static class TreeUtils
    {
        public static void ExpandTreeToNode(TreeNode flocNode)
        {
            if (flocNode != null)
            {
                if (flocNode.Parent != null)
                {
                    ExpandTreeToNode(flocNode.Parent);
                    flocNode.Parent.Expand();
                }
            }
        }
    }
}