using System;
using System.Collections;
using System.Drawing;
using Com.Suncor.Olt.Client.OltControls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PriorityPageTreeList : OltTreeList
    {
        public event Action<TreeList, MergeCellEventArgs> MergeCell;

        protected override TreeListViewInfo CreateViewInfo()
        {
            var viewInfo = new OltTreeListViewInfo(this);
            viewInfo.MergeCell += ViewInfo_MergeCell;
            return viewInfo;
        }

        private void ViewInfo_MergeCell(MergeCellEventArgs eventArgs)
        {
            if (MergeCell != null)
            {
                MergeCell(this, eventArgs);
            }
        }

        public class HideCellEventArgs : EventArgs
        {
            public int IndexOfCellToHide;
            public bool ShouldHideCell;

            public HideCellEventArgs(TreeListNode node)
            {
                Node = node;
            }

            public TreeListNode Node { get; private set; }
        }

        public class MergeCellEventArgs : EventArgs
        {
            public int IndexOfCellToMergeBackOne;
            public bool ShouldMergeBackOneCell;
            public bool ShouldMergeIntoOneRow;

            public MergeCellEventArgs(TreeListNode node)
            {
                Node = node;
            }

            public TreeListNode Node { get; private set; }
        }

        private class OltTreeListViewInfo : TreeListViewInfo
        {
            private static readonly ILog logger = LogManager.GetLogger(typeof (OltTreeListViewInfo));

            public OltTreeListViewInfo(TreeList fTreeList) : base(fTreeList)
            {
            }

            public event Action<MergeCellEventArgs> MergeCell;
            public event Action<HideCellEventArgs> HideCell;

            protected override void CalcRowCellsInfo(RowInfo ri, ArrayList viewInfoList)
            {
                base.CalcRowCellsInfo(ri, viewInfoList);

                try
                {
                    if (ri.Node != null &&
                        ri.Cells.Count > 1 &&
                        MergeCell != null)
                    {
                        var eventArgs = new MergeCellEventArgs(ri.Node);
                        MergeCell(eventArgs);
                        if (eventArgs.ShouldMergeIntoOneRow)
                        {
                            var firstCell = (CellInfo) ri.Cells[0];
                            var lastCell = (CellInfo) ri.Cells[ri.Cells.Count - 1];
                            var bounds = new Rectangle(firstCell.Bounds.Location,
                                new Size(lastCell.Bounds.Right - firstCell.Bounds.Left, firstCell.Bounds.Height));
                            firstCell.CalcViewInfo(GInfo.Graphics, Point.Empty, bounds);
                            bounds.Inflate(0, -1);
                            firstCell.EditorViewInfo.Bounds = bounds;

                            ri.Cells.Clear();
                            ri.Cells.Add(firstCell);
                        }
                        else if (eventArgs.ShouldMergeBackOneCell &&
                                 eventArgs.IndexOfCellToMergeBackOne > 0 &&
                                 eventArgs.IndexOfCellToMergeBackOne < ri.Cells.Count)
                        {
                            var previousCell = (CellInfo) ri.Cells[eventArgs.IndexOfCellToMergeBackOne - 1];
                            var currentCell = (CellInfo) ri.Cells[eventArgs.IndexOfCellToMergeBackOne];
                            var bounds = new Rectangle(previousCell.Bounds.Location,
                                new Size(currentCell.Bounds.Right - previousCell.Bounds.Left, previousCell.Bounds.Height));
                            currentCell.CalcViewInfo(GInfo.Graphics, Point.Empty, bounds);
                            bounds.Inflate(0, -1);
                            currentCell.EditorViewInfo.Bounds = bounds;

                            var cellsToKeep = new ArrayList();
                            for (var i = 0; i < ri.Cells.Count; i++)
                            {
                                if (i != eventArgs.IndexOfCellToMergeBackOne - 1)
                                {
                                    cellsToKeep.Add(ri.Cells[i]);
                                }
                            }
                            ri.Cells.Clear();
                            ri.Cells.AddRange(cellsToKeep);
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Error calculating CalcRowCellsInfo for merged cells in PriorityPageTree.", e);
                }
            }

            protected override TreeNodeCellState CalcRowCellState(CellInfo cell)
            {
                var state = base.CalcRowCellState(cell);
                try
                {
                    if (cell.RowInfo != null &&
                        cell.RowInfo.Node != null &&
                        cell.RowInfo.Node == TreeList.FocusedNode &&
                        MergeCell != null)
                    {
                        var eventArgs = new MergeCellEventArgs(cell.RowInfo.Node);
                        MergeCell(eventArgs);
                        if (eventArgs.ShouldMergeIntoOneRow)
                        {
                            state |= TreeNodeCellState.FocusedCell;
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Error calculating CalcRowCellState for merged cells in PriorityPageTree.", e);
                }
                return state;
            }
        }
    }
}