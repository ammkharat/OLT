using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public class LogDetailsThreadHelper
    {
        public event EventHandler<TreeViewEventArgs> AfterSelect;

        private static readonly string THREAD_VIEW_LABEL_TEXT = StringResources.ViewLogThreadButtonText;
        private static readonly string THREAD_HIDE_LABEL_TEXT = StringResources.HideLogThreadButtonText;

        private readonly SplitContainer splitContainer;
        private readonly ToolStripButton viewThreadButton;
        private readonly LogDetailThreadTreeView logDetailThreadTreeView;

        private readonly Bitmap threadViewIcon;
        private readonly Bitmap threadHideIcon;

        public LogDetailsThreadHelper(SplitContainer splitContainer, LogDetailThreadTreeView logDetailThreadTreeView, ToolStripButton viewThreadButton)
        {
            threadViewIcon = Properties.Resources.viewThread_16;
            threadHideIcon = Properties.Resources.hideThread_16;

            this.splitContainer = splitContainer;
            this.viewThreadButton = viewThreadButton;
            this.logDetailThreadTreeView = logDetailThreadTreeView;

            logDetailThreadTreeView.AfterSelect += HandleTreeViewAfterSelect;
        }

        private void HandleTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (AfterSelect != null)
            {
                AfterSelect(sender, e);
            }
        }

        public void ShowTreePanel()
        {
            viewThreadButton.Text = THREAD_HIDE_LABEL_TEXT;
            viewThreadButton.Image = threadHideIcon;
            splitContainer.Panel1Collapsed = false;
        }

        public void HideTreePanel()
        {
            viewThreadButton.Text = THREAD_VIEW_LABEL_TEXT;
            viewThreadButton.Image = threadViewIcon;
            splitContainer.Panel1Collapsed = true;
        }

        public bool IsShowingTreePanel
        {
            get { return !splitContainer.Panel1Collapsed; }
        }

        public IThreadableDTO SelectedDTO
        {
            get { return logDetailThreadTreeView.SelectedLogDTO; }
            set { logDetailThreadTreeView.SelectedLogDTO = value; ; }
        }

        public void LoadThreadTree(IThreadableDTO rootDto, List<IThreadableDTO> childDtos)
        {            
            logDetailThreadTreeView.LoadLogDetailTree(rootDto, childDtos);
            logDetailThreadTreeView.ExpandAll();
        }

        public void InitializeSplitterDistance(int height)
        {
            splitContainer.SplitterDistance = height / 2;
        }
    }
}
