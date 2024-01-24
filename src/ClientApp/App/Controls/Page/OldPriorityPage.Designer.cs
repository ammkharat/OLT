using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    partial class OldPriorityPage
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
            this.topSplitContainer = new System.Windows.Forms.SplitContainer();
            this.firstInnerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.actionItemPanel = new OltPanel();
            this.targetAlertPanel = new OltPanel();
            this.secondInnerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.deviationAlertPanel = new OltPanel();
            this.workPermitPanel = new OltPanel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.shiftHandoverQuestionnairePanel = new OltPanel();
            this.actionItemContextMenuStrip = new Com.Suncor.Olt.Client.Controls.ActionItemContextMenuStrip(this.components);
            this.targetContextMenuStrip = new Com.Suncor.Olt.Client.Controls.TargetAlertContextMenuStrip(this.components);
            this.permitContextMenuStrip = new Com.Suncor.Olt.Client.Controls.WorkPermitContextMenuStrip(this.components);
            this.deviationAlertContextMenuStrip = new Com.Suncor.Olt.Client.Controls.DeviationAlertContextMenuStrip(this.components);
            this.labAlertContextMenuStrip = new Com.Suncor.Olt.Client.Controls.LabAlertContextMenuStrip(this.components);
            this.bottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.labAlertPanel = new OltPanel();
            this.topSplitContainer.Panel1.SuspendLayout();
            this.topSplitContainer.Panel2.SuspendLayout();
            this.topSplitContainer.SuspendLayout();
            this.firstInnerSplitContainer.Panel1.SuspendLayout();
            this.firstInnerSplitContainer.Panel2.SuspendLayout();
            this.firstInnerSplitContainer.SuspendLayout();
            this.secondInnerSplitContainer.Panel1.SuspendLayout();
            this.secondInnerSplitContainer.Panel2.SuspendLayout();
            this.secondInnerSplitContainer.SuspendLayout();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.bottomSplitContainer.Panel1.SuspendLayout();
            this.bottomSplitContainer.Panel2.SuspendLayout();
            this.bottomSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // topSplitContainer
            // 
            this.topSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.topSplitContainer.Name = "topSplitContainer";
            this.topSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // topSplitContainer.Panel1
            // 
            this.topSplitContainer.Panel1.Controls.Add(this.firstInnerSplitContainer);
            this.topSplitContainer.Panel1MinSize = 0;
            // 
            // topSplitContainer.Panel2
            // 
            this.topSplitContainer.Panel2.Controls.Add(this.secondInnerSplitContainer);
            this.topSplitContainer.Panel2MinSize = 0;
            this.topSplitContainer.Size = new System.Drawing.Size(375, 334);
            this.topSplitContainer.SplitterDistance = 166;
            this.topSplitContainer.TabIndex = 6;
            // 
            // firstInnerSplitContainer
            // 
            this.firstInnerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstInnerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.firstInnerSplitContainer.Name = "firstInnerSplitContainer";
            this.firstInnerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // firstInnerSplitContainer.Panel1
            // 
            this.firstInnerSplitContainer.Panel1.Controls.Add(this.actionItemPanel);
            this.firstInnerSplitContainer.Panel1MinSize = 0;
            // 
            // firstInnerSplitContainer.Panel2
            // 
            this.firstInnerSplitContainer.Panel2.Controls.Add(this.targetAlertPanel);
            this.firstInnerSplitContainer.Panel2MinSize = 0;
            this.firstInnerSplitContainer.Size = new System.Drawing.Size(375, 166);
            this.firstInnerSplitContainer.SplitterDistance = 80;
            this.firstInnerSplitContainer.TabIndex = 7;
            // 
            // actionItemPanel
            // 
            this.actionItemPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.actionItemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionItemPanel.Location = new System.Drawing.Point(0, 0);
            this.actionItemPanel.Name = "actionItemPanel";
            this.actionItemPanel.Size = new System.Drawing.Size(375, 80);
            this.actionItemPanel.TabIndex = 0;
            // 
            // targetAlertPanel
            // 
            this.targetAlertPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.targetAlertPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetAlertPanel.Location = new System.Drawing.Point(0, 0);
            this.targetAlertPanel.Name = "targetAlertPanel";
            this.targetAlertPanel.Size = new System.Drawing.Size(375, 82);
            this.targetAlertPanel.TabIndex = 2;
            // 
            // secondInnerSplitContainer
            // 
            this.secondInnerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondInnerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.secondInnerSplitContainer.Name = "secondInnerSplitContainer";
            this.secondInnerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // secondInnerSplitContainer.Panel1
            // 
            this.secondInnerSplitContainer.Panel1.Controls.Add(this.deviationAlertPanel);
            this.secondInnerSplitContainer.Panel1MinSize = 0;
            // 
            // secondInnerSplitContainer.Panel2
            // 
            this.secondInnerSplitContainer.Panel2.Controls.Add(this.workPermitPanel);
            this.secondInnerSplitContainer.Panel2MinSize = 0;
            this.secondInnerSplitContainer.Size = new System.Drawing.Size(375, 164);
            this.secondInnerSplitContainer.SplitterDistance = 82;
            this.secondInnerSplitContainer.TabIndex = 0;
            // 
            // deviationAlertPanel
            // 
            this.deviationAlertPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deviationAlertPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviationAlertPanel.Location = new System.Drawing.Point(0, 0);
            this.deviationAlertPanel.Name = "deviationAlertPanel";
            this.deviationAlertPanel.Size = new System.Drawing.Size(375, 82);
            this.deviationAlertPanel.TabIndex = 5;
            // 
            // workPermitPanel
            // 
            this.workPermitPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.workPermitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPermitPanel.Location = new System.Drawing.Point(0, 0);
            this.workPermitPanel.Name = "workPermitPanel";
            this.workPermitPanel.Size = new System.Drawing.Size(375, 78);
            this.workPermitPanel.TabIndex = 4;
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.topSplitContainer);
            this.mainSplitContainer.Panel1MinSize = 0;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mainSplitContainer.Panel2.Controls.Add(this.bottomSplitContainer);
            this.mainSplitContainer.Panel2MinSize = 0;
            this.mainSplitContainer.Size = new System.Drawing.Size(375, 515);
            this.mainSplitContainer.SplitterDistance = 334;
            this.mainSplitContainer.TabIndex = 7;
            // 
            // shiftHandoverQuestionnairePanel
            // 
            this.shiftHandoverQuestionnairePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.shiftHandoverQuestionnairePanel.BackColor = System.Drawing.SystemColors.Control;
            this.shiftHandoverQuestionnairePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shiftHandoverQuestionnairePanel.Location = new System.Drawing.Point(0, 0);
            this.shiftHandoverQuestionnairePanel.Name = "shiftHandoverQuestionnairePanel";
            this.shiftHandoverQuestionnairePanel.Size = new System.Drawing.Size(375, 85);
            this.shiftHandoverQuestionnairePanel.TabIndex = 0;
            // 
            // actionItemContextMenuStrip
            // 
            this.actionItemContextMenuStrip.Name = "actionItemContextMenuStrip";
            this.actionItemContextMenuStrip.Size = new System.Drawing.Size(128, 26);
            // 
            // targetContextMenuStrip
            // 
            this.targetContextMenuStrip.Name = "targetContextMenuStrip";
            this.targetContextMenuStrip.Size = new System.Drawing.Size(149, 48);
            // 
            // permitContextMenuStrip
            // 
            this.permitContextMenuStrip.Name = "permitContextMenuStrip";
            this.permitContextMenuStrip.Size = new System.Drawing.Size(131, 224);
            // 
            // deviationAlertContextMenuStrip
            // 
            this.deviationAlertContextMenuStrip.Name = "deviationAlertContextMenuStrip";
            this.deviationAlertContextMenuStrip.Size = new System.Drawing.Size(128, 26);
            // 
            // labAlertContextMenuStrip
            // 
            this.labAlertContextMenuStrip.Name = "labAlertContextMenuStrip";
            this.labAlertContextMenuStrip.Size = new System.Drawing.Size(128, 26);
            // 
            // bottomSplitContainer
            // 
            this.bottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.bottomSplitContainer.Name = "bottomSplitContainer";
            this.bottomSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // bottomSplitContainer.Panel1
            // 
            this.bottomSplitContainer.Panel1.Controls.Add(this.labAlertPanel);
            this.bottomSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // bottomSplitContainer.Panel2
            // 
            this.bottomSplitContainer.Panel2.Controls.Add(this.shiftHandoverQuestionnairePanel);
            this.bottomSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bottomSplitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bottomSplitContainer.Size = new System.Drawing.Size(375, 177);
            this.bottomSplitContainer.SplitterDistance = 88;
            this.bottomSplitContainer.TabIndex = 1;
            // 
            // labAlertPanel
            // 
            this.labAlertPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.labAlertPanel.BackColor = System.Drawing.SystemColors.Control;
            this.labAlertPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAlertPanel.Location = new System.Drawing.Point(0, 0);
            this.labAlertPanel.Name = "labAlertPanel";
            this.labAlertPanel.Size = new System.Drawing.Size(375, 88);
            this.labAlertPanel.TabIndex = 1;
            // 
            // PriorityPage
            // 
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "OldPriorityPage";
            this.Size = new System.Drawing.Size(375, 515);
            this.topSplitContainer.Panel1.ResumeLayout(false);
            this.topSplitContainer.Panel2.ResumeLayout(false);
            this.topSplitContainer.ResumeLayout(false);
            this.firstInnerSplitContainer.Panel1.ResumeLayout(false);
            this.firstInnerSplitContainer.Panel2.ResumeLayout(false);
            this.firstInnerSplitContainer.ResumeLayout(false);
            this.secondInnerSplitContainer.Panel1.ResumeLayout(false);
            this.secondInnerSplitContainer.Panel2.ResumeLayout(false);
            this.secondInnerSplitContainer.ResumeLayout(false);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.bottomSplitContainer.Panel1.ResumeLayout(false);
            this.bottomSplitContainer.Panel2.ResumeLayout(false);
            this.bottomSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OltPanel actionItemPanel;
        private OltPanel targetAlertPanel;
        private OltPanel workPermitPanel;
        private ActionItemContextMenuStrip actionItemContextMenuStrip;
        private TargetAlertContextMenuStrip targetContextMenuStrip;
        private WorkPermitContextMenuStrip permitContextMenuStrip;
        private OltPanel deviationAlertPanel;
        private SplitContainer topSplitContainer;
        private SplitContainer firstInnerSplitContainer;
        private SplitContainer secondInnerSplitContainer;
        private DeviationAlertContextMenuStrip deviationAlertContextMenuStrip;
        private LabAlertContextMenuStrip labAlertContextMenuStrip;
        private SplitContainer mainSplitContainer;
        private OltPanel shiftHandoverQuestionnairePanel;
        private SplitContainer bottomSplitContainer;
        private OltPanel labAlertPanel;
       
    }
}
