using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public partial class PriorityPage : UserControl, IPriorityPage
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (PriorityPage));

        private readonly OltTableLayoutPanel messagesTableLayoutPanel;

        private readonly Dictionary<PriorityPageSectionKey, string> sectionDescriptions =
            new Dictionary<PriorityPageSectionKey, string>();

        private readonly Dictionary<PriorityPageSectionKey, Bitmap> sectionImages =
            new Dictionary<PriorityPageSectionKey, Bitmap>();

        // This is a list of the current positions of the section nodes so that when the images are clicked we know which image it is.
        private readonly Dictionary<long, SectionPreferencesInfo> sectionPreferencesInfoDictionary =
            new Dictionary<long, SectionPreferencesInfo>();

        private readonly SplashScreenManager splashScreenManager;

        public PriorityPage()
        {
            InitializeComponent();

            Resize += HandleResize;

            // these have to match with the property names in PriorityPageNode
            treeList.KeyFieldName = "NodeId";

            treeList.ParentFieldName = "ParentNodeId";

            treeList.OptionsView.ShowColumns = false;
            // we want to show columns in the designer to make it easier to configure, but hide it at run time            

            treeList.OptionsBehavior.AutoNodeHeight = false; // need to do this in order to use CalcNodeHeight
            treeList.CalcNodeHeight += TreeList_CalcNodeHeight;

            // expand an empty parent node if a child node got added to it so that users don't miss seeing new nodes
            treeList.NodeChanged += TreeList_NodeChanged;

            // override the font style in individual cells (i.e. bold or red for open excursions)
            treeList.NodeCellStyle += TreeList_NodeCellStyle;

            // need to set the sort order and mode of at least one column to trigger custom sorting (DevExpress bug)
            treeList.ClearSorting();
            whenColumn.SortMode = ColumnSortMode.Custom;
            whenColumn.SortOrder = SortOrder.Ascending;
            treeList.CompareNodeValues += TreeList_CompareNodeValues;

            treeList.MergeCell += TreeList_MergeCell;

            treeList.MouseDoubleClick += TreeList_MouseDoubleClick;

            treeList.MouseClick += HandleMouseClick;

            treeList.CustomDrawNodeCell += HandleCustomDrawNodeCell;

            toolTipController.GetActiveObjectInfo += ToolTipController_GetActiveObjectInfo;

            repositoryItemHyperLinkEdit.Appearance.ForeColor = UIConstants.HyperlinkColor;
            repositoryItemHyperLinkEdit.OpenLink += HyperLinkEdit_OpenClick;

            splashScreenManager = new SplashScreenManager(ParentForm, typeof (WaitForm), true, true);

            messagesTableLayoutPanel = new OltTableLayoutPanel
            {
                Dock = DockStyle.Fill,
                GrowStyle = TableLayoutPanelGrowStyle.AddRows
            };
            messagesPanel.Controls.Add(messagesTableLayoutPanel);
        }

        private float SiteCommunicationsSectionHeight
        {
            set
            {
                var row = tableLayoutPanel.GetRow(siteCommunicationsPanel);
                tableLayoutPanel.RowStyles[row].Height = value;
            }

            get
            {
                var row = tableLayoutPanel.GetRow(siteCommunicationsPanel);
                return tableLayoutPanel.RowStyles[row].Height;
            }
        }

        public event Action<PriorityPageDataNode> NodeClicked;
        public event Action PageLoad;
        public event Action<PriorityPageSectionKey> SectionConfigurationButtonClicked;

        public void CollapseConfiguredSectionNodes()
        {
            var treeListNodes = treeList.Nodes;

            foreach (TreeListNode treeListNode in treeListNodes)
            {
                if (treeListNode.Level == 0)
                {
                    var sectionNode = (PriorityPageSectionNode) treeList.GetDataRecordByNode(treeListNode);
                    treeListNode.Expanded = sectionNode.ExpandSectionByDefault;
                }
            }
        }

        public void MarkSectionAsHavingConfiguration(PriorityPageSectionKey sectionKey)
        {
            var nodePair = FindNodeDataByKey(sectionKey);
            treeList.RefreshNode(nodePair.FirstItem);
            nodePair.FirstItem.Expanded = nodePair.SecondItem.ExpandSectionByDefault;
        }

        public void ExpandSectionAndMarkAsNotHavingConfiguration(PriorityPageSectionKey sectionKey)
        {
            var nodePair = FindNodeDataByKey(sectionKey);
            treeList.RefreshNode(nodePair.FirstItem);
            nodePair.FirstItem.Expanded = true;
        }

        public PriorityPageSectionNode GetSectionConfigurationByKey(PriorityPageSectionKey key)
        {
            var treeListNodes = treeList.Nodes;

            foreach (TreeListNode treeListNode in treeListNodes)
            {
                if (treeListNode.Level == 0)
                {
                    var sectionNode = (PriorityPageSectionNode) treeList.GetDataRecordByNode(treeListNode);

                    if (sectionNode.SectionKey.Equals(key))
                    {
                        return sectionNode;
                    }
                }
            }

            return null;
        }

        public BindingList<PriorityPageNode> Data
        {
            set
            {
                bindingSource.DataSource = value;
                treeList.ExpandAll();
            }
        }

        public IMainForm MainParentForm
        {
            get { return (IMainForm) ParentForm; }
        }

        public bool ViewEnabled
        {
            set
            {
                treeList.Enabled = value;

                if (value)
                {
                    splashScreenManager.CloseWaitForm();
                    splashScreenManager.WaitForSplashFormClose();
                }
                else
                {
                    splashScreenManager.ShowWaitForm();
                }
            }
        }

        public void Refocus()
        {
            try
            {
                treeList.Focus();
            }
            catch (Exception e)
            {
                logger.Error("Error refocusing on tree.", e);
            }
        }

        public List<SiteCommunicationDTO> SiteCommunications
        {
            set
            {
                messagesTableLayoutPanel.RowCount = value.Count;

                var rowIndex = 0;

                value.ForEach(communication =>
                {
                    var label = new OltLabel
                    {
                        AutoSize = false,
                        ForeColor = Color.Black,
                        Width = messagesTableLayoutPanel.Width,
                        Height = 13,
                        Text = string.Format("\u2022   {0}", communication.Message)
                    };

                    messagesTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, label.Height));
                    messagesTableLayoutPanel.Controls.Add(label, 0, rowIndex);

                    rowIndex += 1;
                });
            }
        }

        public void UpdateSectionNodeDescription(PriorityPageSectionKey key, string description, Bitmap image)
        {
            sectionDescriptions[key] = description;
            sectionImages[key] = image;

            if (treeList.InvokeRequired)
            {
                treeList.BeginInvoke(new MethodInvoker(delegate
                {
                    treeList.BeginUpdate();
                    treeList.InvalidateNodes();
                    treeList.EndUpdate();
                }));
            }
            else
            {
                treeList.BeginUpdate();
                treeList.InvalidateNodes();
                treeList.EndUpdate();
            }
        }

        private Pair<TreeListNode, PriorityPageSectionNode> FindNodeDataByKey(PriorityPageSectionKey key)
        {
            var treeListNodes = treeList.Nodes;

            foreach (TreeListNode treeListNode in treeListNodes)
            {
                if (treeListNode.Level == 0)
                {
                    var sectionNode = (PriorityPageSectionNode) treeList.GetDataRecordByNode(treeListNode);

                    if (sectionNode.SectionKey.Equals(key))
                    {
                        return new Pair<TreeListNode, PriorityPageSectionNode>(treeListNode, sectionNode);
                    }
                }
            }

            return null;
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            foreach (var info in sectionPreferencesInfoDictionary.Values)
            {
                if (info.IconRectangle.Contains(e.Location))
                {
                    if (SectionConfigurationButtonClicked != null)
                    {
                        SectionConfigurationButtonClicked(info.PriorityPageSectionNode.SectionKey);
                    }
                    return;
                }
            }
        }

        private void HandleCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node == null || e.Node.Level != 0) return;

            e.Handled = true;

            DrawCustomSectionNameAndDescription(e);
            DrawCustomizationGearForSection(e);
        }

        private string GetSectionDescription(CustomDrawNodeCellEventArgs e, out Bitmap descriptionImage)
        {
            descriptionImage = null;

            if (e.CellText.Contains("Events"))
            {
                var description = sectionDescriptions[PriorityPageSectionKey.ExcursionEvent];
                descriptionImage = sectionImages[PriorityPageSectionKey.ExcursionEvent];
                return description;
            }

            return string.Empty;
        }

        private void DrawCustomSectionNameAndDescription(CustomDrawNodeCellEventArgs e)
        {
            var backBrush = new SolidBrush(Color.FromArgb(51, 102, 153));
            var foreBrush = new SolidBrush(Color.White);

            e.Graphics.FillRectangle(backBrush, e.Bounds);

            var font = new Font(e.Appearance.Font.Name, 9f, FontStyle.Bold, GraphicsUnit.Point, (0));
            var stringFormat = new StringFormat {LineAlignment = StringAlignment.Center};
            e.Graphics.DrawString(e.CellText, font, foreBrush, e.Bounds, stringFormat);

            Bitmap sectionImage;
            var sectionText = GetSectionDescription(e, out sectionImage);
            if (!sectionText.IsNullOrEmpty())
            {
                var smallerFont = new Font(e.Appearance.Font.Name, 7f, FontStyle.Regular, GraphicsUnit.Point, (0));
                var cellTextSize = TextRenderer.MeasureText(e.CellText, font, new Size(int.MaxValue, int.MaxValue),
                    TextFormatFlags.NoPadding);
                const int cellTextRightPadding = 15;
                var cellTextOffset = cellTextSize.Width + cellTextRightPadding;

                var imageOffset = sectionImage != null ? sectionImage.Width : 0;
                if (sectionImage != null)
                {
                    var leftX = e.Bounds.X + cellTextOffset;
                    var leftY = (e.Bounds.Top + (e.Bounds.Height - sectionImage.Height)/2);
                    var sectionImageLocation = new Point(leftX, leftY);
                    e.Graphics.DrawImage(sectionImage, sectionImageLocation);
                }

                var descriptionTextSize = TextRenderer.MeasureText(sectionText, smallerFont,
                    new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                var textOffset = cellTextOffset + imageOffset + 5;
                var descriptionRectange = new Rectangle(e.Bounds.X + textOffset, e.Bounds.Y,
                    descriptionTextSize.Width, e.Bounds.Height);
                e.Graphics.DrawString(sectionText, smallerFont, foreBrush, descriptionRectange, stringFormat);
            }
        }

        private void DrawCustomizationGearForSection(CustomDrawNodeCellEventArgs e)
        {
            var gearWhite = Properties.Resources.GearWhite_20;

            var treeHeaderCellHeight = e.Bounds.Height;
            var imageHeight = gearWhite.Height;

            const int adjustmentFromTheRightOfTheCell = 30;
            var rightX = e.Bounds.Right - adjustmentFromTheRightOfTheCell;
            var adjustmentFromTheTopOfTheCell = (treeHeaderCellHeight - imageHeight)/2;
            var rightY = e.Bounds.Top + adjustmentFromTheTopOfTheCell;

            var imageLocation = new Point(rightX, rightY);

            var imageRectangle = new Rectangle(imageLocation, gearWhite.Size);

            var sectionNode = (PriorityPageSectionNode) treeList.GetDataRecordByNode(e.Node);

            if (!sectionPreferencesInfoDictionary.ContainsKey(sectionNode.NodeId))
            {
                sectionPreferencesInfoDictionary.Add(sectionNode.NodeId,
                    new SectionPreferencesInfo(sectionNode, imageRectangle));
            }
            else
            {
                sectionPreferencesInfoDictionary[sectionNode.NodeId].IconRectangle = imageRectangle;
            }

            var gearImage = sectionNode.DoesConfigurationExistForSection ? Properties.Resources.GearBlue_20 : gearWhite;

            e.Graphics.DrawImage(gearImage, imageLocation);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (PageLoad != null)
            {
                PageLoad();
            }
        }

        private static void TreeList_CalcNodeHeight(object sender, CalcNodeHeightEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    e.NodeHeight = 28;
                }
            }
        }

        private static void TreeList_NodeChanged(object sender, NodeChangedEventArgs e)
        {
            try
            {
                // The add event is not precise.  It gets fired for when we add a node, but it also 
                // gets fired for some internal reason, for example, when we remove a node.
                if (e.ChangeType == NodeChangeTypeEnum.Add &&
                    e.Node != null &&
                    e.Node.Level == 2 &&
                    e.Node.ParentNode != null &&
                    e.Node.ParentNode.Nodes.Count == 1 &&
                    !e.Node.ParentNode.Expanded)
                {
                    e.Node.ParentNode.Expanded = true;
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error in expanding parent node in TreeList_NodeChanged.", exception);
            }
        }

        private void TreeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName != "OptionalText") return;

                var treeList = sender as TreeList;
                if (treeList != null && e.Node != null)
                {
                    var dataRecord = treeList.GetDataRecordByNode(e.Node) as PriorityPageNode;

                    if (dataRecord != null)
                    {
                        var shouldEmphasizeOptionalText = dataRecord.EmphasizeOptionalText;

                        if (shouldEmphasizeOptionalText)
                        {
                            e.Appearance.ForeColor = Color.Red;
                            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error customizing node cell style in priority page tree.", exception);
            }
        }

        private static void TreeList_CompareNodeValues(object sender, CompareNodeValuesEventArgs e)
        {
            try
            {
                var treeList = sender as TreeList;
                if (treeList != null && e.Node1 != null && e.Node2 != null)
                {
                    var dataRecord1 = treeList.GetDataRecordByNode(e.Node1) as PriorityPageNode;
                    var dataRecord2 = treeList.GetDataRecordByNode(e.Node2) as PriorityPageNode;

                    if (dataRecord1 != null && dataRecord2 != null)
                    {
                        e.Result = dataRecord1.CompareTo(dataRecord2);
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error sorting priority page tree.", exception);
            }
        }

        private void TreeList_MergeCell(TreeList sender, PriorityPageTreeList.MergeCellEventArgs e)
        {
            if (e.Node != null && e.Node.Level < 2)
            {
                e.ShouldMergeIntoOneRow = true;
            }
            else
            {
                var dataNode = sender.GetDataRecordByNode(e.Node) as PriorityPageDataNode;
                if (dataNode == null) return;

                if (!dataNode.NodeData.ShowOptionalText)
                {
                    e.ShouldMergeBackOneCell = true;
                    e.IndexOfCellToMergeBackOne = textColumn.VisibleIndex;
                }
                else if (!dataNode.NodeData.ShowStartEndText)
                {
                    e.ShouldMergeBackOneCell = true;
                    e.IndexOfCellToMergeBackOne = textColumn.VisibleIndex;
                }
            }
        }

        private void TreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var tree = sender as TreeList;
                if (tree != null)
                {
                    var hit = tree.CalcHitInfo(new Point(e.X, e.Y));
                    if (hit != null &&
                        hit.Node != null)
                    {
                        var dataNode = tree.GetDataRecordByNode(hit.Node) as PriorityPageDataNode;
                        if (dataNode != null && NodeClicked != null)
                        {
                            NodeClicked(dataNode);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error handling double click in priority page tree.", exception);
            }
        }

        private void ToolTipController_GetActiveObjectInfo(object sender,
            ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            try
            {
                if (e.SelectedControl is TreeList)
                {
                    var tree = (TreeList) e.SelectedControl;
                    var hit = tree.CalcHitInfo(e.ControlMousePosition);
                    if (hit.HitInfoType == HitInfoType.Cell &&
                        (hit.Column == statusColumn || hit.Column == priorityColumn ||
                         hit.Column == secondaryStatusColumn) &&
                        hit.Node != null &&
                        hit.Node.Level > 1)
                    {
                        var dataNode = tree.GetDataRecordByNode(hit.Node) as PriorityPageDataNode;
                        if (dataNode != null &&
                            dataNode.NodeData != null)
                        {
                            object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);

                            var toolTip = string.Empty;
                            if (hit.Column == priorityColumn)
                            {
                                toolTip = dataNode.NodeData.PriorityToolTip;
                            }
                            else if (hit.Column == statusColumn)
                            {
                                toolTip = dataNode.NodeData.StatusToolTip;
                            }
                            else if (hit.Column == secondaryStatusColumn)
                            {
                                toolTip = dataNode.NodeData.SecondaryStatusToolTip;
                            }
                            e.Info = new ToolTipControlInfo(cellInfo, toolTip);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error handling tooltip in priority page tree.", exception);
            }
        }

        private void HyperLinkEdit_OpenClick(object sender, EventArgs e)
        {
            try
            {
                var focusedNode = treeList.FocusedNode;
                if (focusedNode != null)
                {
                    var dataNode = treeList.GetDataRecordByNode(focusedNode) as PriorityPageDataNode;
                    if (dataNode != null && NodeClicked != null)
                    {
                        NodeClicked(dataNode);
                    }
                }
            }
            catch (Exception exception)
            {
                logger.Error("Error handling hyperlink click in priority page tree.", exception);
            }
        }

        private void HandleResize(object sender, EventArgs eventArgs)
        {
            if (messagesTableLayoutPanel.RowCount == 0)
            {
                SiteCommunicationsSectionHeight = 0;
            }
            else
            {
                SiteCommunicationsSectionHeight = 54; // initial height

                for (var i = 0; i < messagesTableLayoutPanel.RowCount; i++)
                {
                    var label = (OltLabel) messagesTableLayoutPanel.GetControlFromPosition(0, i);
                    label.Width = messagesTableLayoutPanel.Width;

                    var size = TextRenderer.MeasureText(label.Text, label.Font, new Size(label.Width, Int32.MaxValue),
                        TextFormatFlags.WordBreak);
                    messagesTableLayoutPanel.RowStyles[i].Height = size.Height;
                    SiteCommunicationsSectionHeight = SiteCommunicationsSectionHeight + size.Height;

                    label.Height = size.Height;
                }
            }
        }

        private class SectionPreferencesInfo
        {
            public SectionPreferencesInfo(PriorityPageSectionNode priorityPageSectionNode, Rectangle iconRectangle)
            {
                PriorityPageSectionNode = priorityPageSectionNode;
                IconRectangle = iconRectangle;
            }

            public PriorityPageSectionNode PriorityPageSectionNode { get; set; }
            public Rectangle IconRectangle { get; set; }
        }

        public void BeginUpdateTreeList()
        {
            if (treeList.InvokeRequired)
            {
                treeList.Invoke(new Action(() => treeList.BeginUpdate()));
            }
            else
            {
                treeList.BeginUpdate();               
            }
        }

        public void EndUpdateTreeList()
        {
            if (treeList.InvokeRequired)
            {
                treeList.Invoke(new Action(() => treeList.EndUpdate()));
            }
            else
            {
                treeList.EndUpdate();
            }
        }
    }
}