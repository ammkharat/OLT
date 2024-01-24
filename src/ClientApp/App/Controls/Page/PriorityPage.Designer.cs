namespace Com.Suncor.Olt.Client.Controls.Page
{
    partial class PriorityPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriorityPage));
            this.treeList = new Com.Suncor.Olt.Client.Controls.Page.PriorityPageTreeList();
            this.groupNameColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.statusColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemPictureEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.whenColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.whoWhatColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.secondaryWhoWhatColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.optionalTextColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.optionalStartEndColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.textColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemHyperLinkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.priorityColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.secondaryStatusColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.tableLayoutPanel = new Com.Suncor.Olt.Client.OltControls.OltTableLayoutPanel();
            this.siteCommunicationsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.messagesPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.siteCommunicationsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.groupNameColumn,
            this.statusColumn,
            this.whenColumn,
            this.whoWhatColumn,
            this.secondaryWhoWhatColumn,
            this.optionalTextColumn,
            this.optionalStartEndColumn,
            this.textColumn,
            this.priorityColumn,
            this.secondaryStatusColumn});
            this.treeList.CustomizationFormBounds = new System.Drawing.Rectangle(435, 420, 208, 170);
            this.treeList.DataSource = this.bindingSource;
            resources.ApplyResources(this.treeList, "treeList");
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit,
            this.repositoryItemPictureEdit});
            this.treeList.ToolTipController = this.toolTipController;
            this.treeList.TreeLevelWidth = 12;
            // 
            // groupNameColumn
            // 
            this.groupNameColumn.FieldName = "GroupName";
            resources.ApplyResources(this.groupNameColumn, "groupNameColumn");
            this.groupNameColumn.Name = "groupNameColumn";
            this.groupNameColumn.OptionsColumn.AllowEdit = false;
            this.groupNameColumn.OptionsColumn.AllowMove = false;
            this.groupNameColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.groupNameColumn.OptionsColumn.AllowSize = false;
            this.groupNameColumn.OptionsColumn.AllowSort = false;
            this.groupNameColumn.OptionsColumn.FixedWidth = true;
            this.groupNameColumn.OptionsColumn.ReadOnly = true;
            this.groupNameColumn.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // statusColumn
            // 
            this.statusColumn.ColumnEdit = this.repositoryItemPictureEdit;
            this.statusColumn.FieldName = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.OptionsColumn.AllowEdit = false;
            this.statusColumn.OptionsColumn.AllowMove = false;
            this.statusColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.statusColumn.OptionsColumn.AllowSize = false;
            this.statusColumn.OptionsColumn.AllowSort = false;
            this.statusColumn.OptionsColumn.FixedWidth = true;
            this.statusColumn.OptionsColumn.ReadOnly = true;
            this.statusColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.statusColumn, "statusColumn");
            // 
            // repositoryItemPictureEdit
            // 
            this.repositoryItemPictureEdit.Name = "repositoryItemPictureEdit";
            resources.ApplyResources(this.repositoryItemPictureEdit, "repositoryItemPictureEdit");
            this.repositoryItemPictureEdit.ReadOnly = true;
            this.repositoryItemPictureEdit.ShowMenu = false;
            // 
            // whenColumn
            // 
            this.whenColumn.FieldName = "When";
            this.whenColumn.Name = "whenColumn";
            this.whenColumn.OptionsColumn.AllowEdit = false;
            this.whenColumn.OptionsColumn.AllowMove = false;
            this.whenColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.whenColumn.OptionsColumn.AllowSize = false;
            this.whenColumn.OptionsColumn.AllowSort = false;
            this.whenColumn.OptionsColumn.FixedWidth = true;
            this.whenColumn.OptionsColumn.ReadOnly = true;
            this.whenColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.whenColumn, "whenColumn");
            // 
            // whoWhatColumn
            // 
            this.whoWhatColumn.FieldName = "WhoWhat";
            this.whoWhatColumn.Name = "whoWhatColumn";
            this.whoWhatColumn.OptionsColumn.AllowEdit = false;
            this.whoWhatColumn.OptionsColumn.AllowMove = false;
            this.whoWhatColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.whoWhatColumn.OptionsColumn.AllowSize = false;
            this.whoWhatColumn.OptionsColumn.AllowSort = false;
            this.whoWhatColumn.OptionsColumn.FixedWidth = true;
            this.whoWhatColumn.OptionsColumn.ReadOnly = true;
            this.whoWhatColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.whoWhatColumn, "whoWhatColumn");
            // 
            // secondaryWhoWhatColumn
            // 
            this.secondaryWhoWhatColumn.FieldName = "SecondaryWhoWhat";
            this.secondaryWhoWhatColumn.Name = "secondaryWhoWhatColumn";
            this.secondaryWhoWhatColumn.OptionsColumn.AllowEdit = false;
            this.secondaryWhoWhatColumn.OptionsColumn.AllowMove = false;
            this.secondaryWhoWhatColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.secondaryWhoWhatColumn.OptionsColumn.AllowSize = false;
            this.secondaryWhoWhatColumn.OptionsColumn.AllowSort = false;
            this.secondaryWhoWhatColumn.OptionsColumn.FixedWidth = true;
            this.secondaryWhoWhatColumn.OptionsColumn.ReadOnly = true;
            this.secondaryWhoWhatColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.secondaryWhoWhatColumn, "secondaryWhoWhatColumn");
            // 
            // optionalTextColumn
            // 
            this.optionalTextColumn.FieldName = "OptionalText";
            this.optionalTextColumn.Name = "optionalTextColumn";
            this.optionalTextColumn.OptionsColumn.AllowEdit = false;
            this.optionalTextColumn.OptionsColumn.AllowMove = false;
            this.optionalTextColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.optionalTextColumn.OptionsColumn.AllowSize = false;
            this.optionalTextColumn.OptionsColumn.AllowSort = false;
            this.optionalTextColumn.OptionsColumn.FixedWidth = true;
            this.optionalTextColumn.OptionsColumn.ReadOnly = true;
            this.optionalTextColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.optionalTextColumn, "optionalTextColumn");
            // 
            // optionalStartEndColumn
            // 
            resources.ApplyResources(this.optionalStartEndColumn, "optionalStartEndColumn");
            this.optionalStartEndColumn.FieldName = "StartEndText";
            this.optionalStartEndColumn.Name = "optionalStartEndColumn";
            this.optionalStartEndColumn.OptionsColumn.AllowEdit = false;
            this.optionalStartEndColumn.OptionsColumn.AllowMove = false;
            this.optionalStartEndColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.optionalStartEndColumn.OptionsColumn.AllowSize = false;
            this.optionalStartEndColumn.OptionsColumn.AllowSort = false;
            this.optionalStartEndColumn.OptionsColumn.FixedWidth = true;
            this.optionalStartEndColumn.OptionsColumn.ReadOnly = true;
            this.optionalStartEndColumn.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // textColumn
            // 
            this.textColumn.ColumnEdit = this.repositoryItemHyperLinkEdit;
            this.textColumn.FieldName = "Text";
            this.textColumn.Name = "textColumn";
            this.textColumn.OptionsColumn.AllowMove = false;
            this.textColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.textColumn.OptionsColumn.AllowSize = false;
            this.textColumn.OptionsColumn.AllowSort = false;
            this.textColumn.OptionsColumn.ReadOnly = true;
            this.textColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.textColumn, "textColumn");
            // 
            // repositoryItemHyperLinkEdit
            // 
            resources.ApplyResources(this.repositoryItemHyperLinkEdit, "repositoryItemHyperLinkEdit");
            this.repositoryItemHyperLinkEdit.Name = "repositoryItemHyperLinkEdit";
            this.repositoryItemHyperLinkEdit.SingleClick = true;
            // 
            // priorityColumn
            // 
            this.priorityColumn.ColumnEdit = this.repositoryItemPictureEdit;
            this.priorityColumn.FieldName = "Priority";
            this.priorityColumn.Name = "priorityColumn";
            this.priorityColumn.OptionsColumn.AllowEdit = false;
            this.priorityColumn.OptionsColumn.AllowMove = false;
            this.priorityColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.priorityColumn.OptionsColumn.AllowSize = false;
            this.priorityColumn.OptionsColumn.AllowSort = false;
            this.priorityColumn.OptionsColumn.FixedWidth = true;
            this.priorityColumn.OptionsColumn.ReadOnly = true;
            this.priorityColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.priorityColumn, "priorityColumn");
            // 
            // secondaryStatusColumn
            // 
            this.secondaryStatusColumn.ColumnEdit = this.repositoryItemPictureEdit;
            this.secondaryStatusColumn.FieldName = "SecondaryStatus";
            this.secondaryStatusColumn.Name = "secondaryStatusColumn";
            this.secondaryStatusColumn.OptionsColumn.AllowEdit = false;
            this.secondaryStatusColumn.OptionsColumn.AllowMove = false;
            this.secondaryStatusColumn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.secondaryStatusColumn.OptionsColumn.AllowSize = false;
            this.secondaryStatusColumn.OptionsColumn.AllowSort = false;
            this.secondaryStatusColumn.OptionsColumn.FixedWidth = true;
            this.secondaryStatusColumn.OptionsColumn.ReadOnly = true;
            this.secondaryStatusColumn.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.secondaryStatusColumn, "secondaryStatusColumn");
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.treeList, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.siteCommunicationsPanel, 0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // siteCommunicationsPanel
            // 
            this.siteCommunicationsPanel.BackColor = System.Drawing.Color.White;
            this.siteCommunicationsPanel.Controls.Add(this.panel1);
            this.siteCommunicationsPanel.Controls.Add(this.messagesPanel);
            resources.ApplyResources(this.siteCommunicationsPanel, "siteCommunicationsPanel");
            this.siteCommunicationsPanel.Name = "siteCommunicationsPanel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // messagesPanel
            // 
            resources.ApplyResources(this.messagesPanel, "messagesPanel");
            this.messagesPanel.BackColor = System.Drawing.Color.White;
            this.messagesPanel.Name = "messagesPanel";
            // 
            // PriorityPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "PriorityPage";
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.siteCommunicationsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Com.Suncor.Olt.Client.Controls.Page.PriorityPageTreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn statusColumn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn whenColumn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn textColumn;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn whoWhatColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn groupNameColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraTreeList.Columns.TreeListColumn optionalTextColumn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn priorityColumn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn secondaryStatusColumn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn optionalStartEndColumn;
        private OltControls.OltTableLayoutPanel tableLayoutPanel;
        private OltControls.OltPanel siteCommunicationsPanel;
        private OltControls.OltPanel messagesPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn secondaryWhoWhatColumn;
    }
}
