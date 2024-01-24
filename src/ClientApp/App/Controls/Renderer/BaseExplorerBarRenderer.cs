using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Infragistics.Win.UltraWinExplorerBar;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public abstract class BaseExplorerBarRenderer : IDisposable
    {
        protected OltExplorerBar explorerBar;
        protected readonly int defaultHeight;

        protected BaseExplorerBarRenderer(Form form, OltExplorerBar explorerBar, int defaultHeight, bool shouldResizeToFit)
        {
            this.explorerBar = explorerBar;
            this.defaultHeight = defaultHeight;

            form.Disposed += Form_Disposed;
            if (shouldResizeToFit)
            {
                explorerBar.Paint += explorerBar_Paint;
            }
        }

        private void Form_Disposed(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            form.FormClosed -= Form_Disposed;
            explorerBar = null;
            Dispose();
        }

        public abstract void Dispose();
        protected abstract object GetResizableGroupType();

        protected UltraExplorerBarGroup AddLine(string text, object groupType)
        {
            OltLabelLine line = new OltLabelLine();
            line.Dock = DockStyle.Fill;
            line.Label = text;

            UltraExplorerBarGroup group = AddBarGroup(line, groupType, 13, 600, 13);
            group.Settings.ItemAreaInnerMargins.Left = 5;
            group.Settings.ItemAreaInnerMargins.Right = 5;

            return group;
        }

        protected UltraExplorerBarGroup AddBarGroupFill(Control childControl, object groupType, int height)
        {
            const int startSize = 100;
            const int margin = 0;

            childControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            childControl.Left = margin;
            childControl.Top = margin;
            childControl.Width = startSize - margin;
            childControl.Height = startSize - margin;

            return AddBarGroup(childControl, groupType, height, startSize, startSize);            
        }

        protected void AddBarGroupFillForTitleControl(Control childControl, object groupType)
        {
            const int startSize = 100;
            const int margin = 0;

            childControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            childControl.Left = margin;
            childControl.Top = margin;
            childControl.Width = startSize - margin;
                                             
            AddBarGroup(childControl, groupType, 24, startSize, 24);
        }

        protected UltraExplorerBarGroup AddBarGroup(Control childControl, object groupType, int height, int containerWidth, int containerHeight)
        {
            UltraExplorerBarContainerControl container = new UltraExplorerBarContainerControl();
            container.Location = new System.Drawing.Point(0, 0);
            container.Name = "ultraExplorerBarContainerControl_" + groupType + "_" + explorerBar.Controls.Count;
            container.Size = new System.Drawing.Size(containerWidth, containerHeight);
            container.TabIndex = explorerBar.Controls.Count;

            container.Controls.Add(childControl);
            explorerBar.Controls.Add(container);

            UltraExplorerBarGroup barGroup = new UltraExplorerBarGroup();
            barGroup.Settings.ContainerHeight = height;
            barGroup.Settings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            barGroup.Expanded = true;
            barGroup.Tag = groupType;

            barGroup.Container = container;
            explorerBar.Groups.Add(barGroup);

            return barGroup;
        }

        protected void RemoveExistingBarGroup(object groupTypeToRemove)
        {
            List<UltraExplorerBarGroup> groupsToRemove = new List<UltraExplorerBarGroup>();
            foreach (UltraExplorerBarGroup group in explorerBar.Groups)
            {
                if (group.Tag != null &&
                    Equals(group.Tag, groupTypeToRemove))
                {
                    groupsToRemove.Add(group);
                }
            }
            foreach (UltraExplorerBarGroup groupToRemove in groupsToRemove)
            {
                UltraExplorerBarContainerControl container = groupToRemove.Container;
                if (container != null)
                {
                    container.Controls.Clear();
                    explorerBar.Controls.Remove(container);
                    container.Dispose();
                }

                explorerBar.Groups.Remove(groupToRemove);
                groupToRemove.Dispose();
            }
        }

        protected int GetNumberOfGroupsWithNoType()
        {
            int numberOfGroupsWithNoType = 0;
            foreach (UltraExplorerBarGroup group in explorerBar.Groups)
            {
                if (group.Tag == null)
                {
                    numberOfGroupsWithNoType++;
                }
            }
            return numberOfGroupsWithNoType;
        }

        protected List<UltraExplorerBarGroup> GetGroupsWithType(object groupType)
        {
            List<UltraExplorerBarGroup> groups = new List<UltraExplorerBarGroup>();

            foreach (UltraExplorerBarGroup group in explorerBar.Groups)
            {
                if (Equals(group.Tag, groupType))
                {
                    groups.Add(group);
                }
            }
            return groups;
        }

        private void explorerBar_Paint(object sender, PaintEventArgs e)
        {
            explorerBar.Paint -= explorerBar_Paint;
            ResizeContainer();
            explorerBar.Paint += explorerBar_Paint;
        }

        private void ResizeContainer()
        {
            List<UltraExplorerBarGroup> groupsToResize = GetResizableGroups();
            if (groupsToResize.Count > 0) 
            {
                int newHeight = (explorerBar.Height - 50 - GetHeightOfOtherGroups(groupsToResize)) / groupsToResize.Count;
                if (newHeight < defaultHeight)
                {
                    newHeight = defaultHeight;
                }

                foreach (UltraExplorerBarGroup group in groupsToResize)
                {
                    group.Settings.ContainerHeight = newHeight;
                }
            }
        }

        private int GetHeightOfOtherGroups(List<UltraExplorerBarGroup> excludedGroups)
        {
            int height = 0;
            foreach (UltraExplorerBarGroup group in explorerBar.Groups)
            {
                if (!excludedGroups.Contains(group) && group.Expanded)
                {
                    height += group.Settings.ContainerHeight;
                }
            }
            return height;
        }

        protected virtual List<UltraExplorerBarGroup> GetResizableGroups()
        {
            return GetGroupsWithType(GetResizableGroupType());
        }
    }
}
