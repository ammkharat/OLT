using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Forms
{
    partial class MultiSelectFunctionalLocationSelectionForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiSelectFunctionalLocationSelectionForm));
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.acceptButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.clearButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.flocSelectionControl = new Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl();
            this.functionalLocationGroupBox = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.flocTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.loadPreviousFlocsPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.selectActiveFlocsButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.changeAssignmentButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.gridPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.flocTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.acceptCancelPanel = new System.Windows.Forms.Panel();
            this.functionalLocationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.functionalLocationGroupBox.SuspendLayout();
            this.flocTableLayoutPanel2.SuspendLayout();
            this.loadPreviousFlocsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flocTableLayoutPanel.SuspendLayout();
            this.acceptCancelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.functionalLocationErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.functionalLocationErrorProvider.SetError(this.cancelButton, resources.GetString("cancelButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cancelButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.cancelButton, ((int)(resources.GetObject("cancelButton.IconPadding"))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            resources.ApplyResources(this.acceptButton, "acceptButton");
            this.functionalLocationErrorProvider.SetError(this.acceptButton, resources.GetString("acceptButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.acceptButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("acceptButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.acceptButton, ((int)(resources.GetObject("acceptButton.IconPadding"))));
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.functionalLocationErrorProvider.SetError(this.clearButton, resources.GetString("clearButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.clearButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("clearButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.clearButton, ((int)(resources.GetObject("clearButton.IconPadding"))));
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // flocSelectionControl
            // 
            resources.ApplyResources(this.flocSelectionControl, "flocSelectionControl");
            this.functionalLocationErrorProvider.SetError(this.flocSelectionControl, resources.GetString("flocSelectionControl.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.flocSelectionControl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flocSelectionControl.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.flocSelectionControl, ((int)(resources.GetObject("flocSelectionControl.IconPadding"))));
            this.flocSelectionControl.Name = "flocSelectionControl";
            // 
            // functionalLocationGroupBox
            // 
            resources.ApplyResources(this.functionalLocationGroupBox, "functionalLocationGroupBox");
            this.functionalLocationGroupBox.Controls.Add(this.flocTableLayoutPanel2);
            this.functionalLocationErrorProvider.SetError(this.functionalLocationGroupBox, resources.GetString("functionalLocationGroupBox.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.functionalLocationGroupBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("functionalLocationGroupBox.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.functionalLocationGroupBox, ((int)(resources.GetObject("functionalLocationGroupBox.IconPadding"))));
            this.functionalLocationGroupBox.Name = "functionalLocationGroupBox";
            this.functionalLocationGroupBox.TabStop = false;
            // 
            // flocTableLayoutPanel2
            // 
            resources.ApplyResources(this.flocTableLayoutPanel2, "flocTableLayoutPanel2");
            this.flocTableLayoutPanel2.Controls.Add(this.flocSelectionControl, 0, 0);
            this.flocTableLayoutPanel2.Controls.Add(this.loadPreviousFlocsPanel, 0, 1);
            this.functionalLocationErrorProvider.SetError(this.flocTableLayoutPanel2, resources.GetString("flocTableLayoutPanel2.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.flocTableLayoutPanel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flocTableLayoutPanel2.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.flocTableLayoutPanel2, ((int)(resources.GetObject("flocTableLayoutPanel2.IconPadding"))));
            this.flocTableLayoutPanel2.Name = "flocTableLayoutPanel2";
            // 
            // loadPreviousFlocsPanel
            // 
            resources.ApplyResources(this.loadPreviousFlocsPanel, "loadPreviousFlocsPanel");
            this.loadPreviousFlocsPanel.Controls.Add(this.selectActiveFlocsButton);
            this.loadPreviousFlocsPanel.Controls.Add(this.clearButton);
            this.functionalLocationErrorProvider.SetError(this.loadPreviousFlocsPanel, resources.GetString("loadPreviousFlocsPanel.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.loadPreviousFlocsPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("loadPreviousFlocsPanel.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.loadPreviousFlocsPanel, ((int)(resources.GetObject("loadPreviousFlocsPanel.IconPadding"))));
            this.loadPreviousFlocsPanel.Name = "loadPreviousFlocsPanel";
            // 
            // selectActiveFlocsButton
            // 
            resources.ApplyResources(this.selectActiveFlocsButton, "selectActiveFlocsButton");
            this.functionalLocationErrorProvider.SetError(this.selectActiveFlocsButton, resources.GetString("selectActiveFlocsButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.selectActiveFlocsButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("selectActiveFlocsButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.selectActiveFlocsButton, ((int)(resources.GetObject("selectActiveFlocsButton.IconPadding"))));
            this.selectActiveFlocsButton.Name = "selectActiveFlocsButton";
            this.selectActiveFlocsButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.changeAssignmentButton, 0, 1);
            this.functionalLocationErrorProvider.SetError(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.tableLayoutPanel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tableLayoutPanel1.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.tableLayoutPanel1, ((int)(resources.GetObject("tableLayoutPanel1.IconPadding"))));
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // changeAssignmentButton
            // 
            resources.ApplyResources(this.changeAssignmentButton, "changeAssignmentButton");
            this.functionalLocationErrorProvider.SetError(this.changeAssignmentButton, resources.GetString("changeAssignmentButton.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.changeAssignmentButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("changeAssignmentButton.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.changeAssignmentButton, ((int)(resources.GetObject("changeAssignmentButton.IconPadding"))));
            this.changeAssignmentButton.Name = "changeAssignmentButton";
            this.changeAssignmentButton.UseVisualStyleBackColor = true;
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.functionalLocationErrorProvider.SetError(this.gridPanel, resources.GetString("gridPanel.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.gridPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("gridPanel.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.gridPanel, ((int)(resources.GetObject("gridPanel.IconPadding"))));
            this.gridPanel.Name = "gridPanel";
            // 
            // flocTableLayoutPanel
            // 
            resources.ApplyResources(this.flocTableLayoutPanel, "flocTableLayoutPanel");
            this.flocTableLayoutPanel.Controls.Add(this.functionalLocationGroupBox, 0, 0);
            this.functionalLocationErrorProvider.SetError(this.flocTableLayoutPanel, resources.GetString("flocTableLayoutPanel.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.flocTableLayoutPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flocTableLayoutPanel.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.flocTableLayoutPanel, ((int)(resources.GetObject("flocTableLayoutPanel.IconPadding"))));
            this.flocTableLayoutPanel.Name = "flocTableLayoutPanel";
            // 
            // acceptCancelPanel
            // 
            resources.ApplyResources(this.acceptCancelPanel, "acceptCancelPanel");
            this.acceptCancelPanel.Controls.Add(this.cancelButton);
            this.acceptCancelPanel.Controls.Add(this.acceptButton);
            this.functionalLocationErrorProvider.SetError(this.acceptCancelPanel, resources.GetString("acceptCancelPanel.Error"));
            this.functionalLocationErrorProvider.SetIconAlignment(this.acceptCancelPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("acceptCancelPanel.IconAlignment"))));
            this.functionalLocationErrorProvider.SetIconPadding(this.acceptCancelPanel, ((int)(resources.GetObject("acceptCancelPanel.IconPadding"))));
            this.acceptCancelPanel.Name = "acceptCancelPanel";
            // 
            // functionalLocationErrorProvider
            // 
            this.functionalLocationErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.functionalLocationErrorProvider, "functionalLocationErrorProvider");
            // 
            // MultiSelectFunctionalLocationSelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.acceptCancelPanel);
            this.Controls.Add(this.flocTableLayoutPanel);
            this.MaximizeBox = false;
            this.Name = "MultiSelectFunctionalLocationSelectionForm";
            this.functionalLocationGroupBox.ResumeLayout(false);
            this.flocTableLayoutPanel2.ResumeLayout(false);
            this.loadPreviousFlocsPanel.ResumeLayout(false);
            this.loadPreviousFlocsPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flocTableLayoutPanel.ResumeLayout(false);
            this.acceptCancelPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.functionalLocationErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Com.Suncor.Olt.Client.Controls.MultiSelectFunctionalLocationControl flocSelectionControl;
        private OltButton acceptButton;
        private OltButton cancelButton;
        private OltButton clearButton;
        private OltGroupBox functionalLocationGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OltPanel gridPanel;
        private OltButton changeAssignmentButton;
        private System.Windows.Forms.Panel acceptCancelPanel;
        private System.Windows.Forms.TableLayoutPanel flocTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel flocTableLayoutPanel2;
        private OltPanel loadPreviousFlocsPanel;
        private ErrorProvider functionalLocationErrorProvider;
        private OltButton selectActiveFlocsButton;
    }
}
