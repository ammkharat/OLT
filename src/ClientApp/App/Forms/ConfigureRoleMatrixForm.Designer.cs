namespace Com.Suncor.Olt.Client.Forms
{
    partial class ConfigureRoleMatrixForm
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            this.previewChangesButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.cancelButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.buttonPanel = new Com.Suncor.Olt.Client.OltControls.OltPanel();
            this.generateSqlButton = new Com.Suncor.Olt.Client.OltControls.OltButton();
            this.grid = new Com.Suncor.Olt.Client.OltControls.OltGrid();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // previewChangesButton
            // 
            this.previewChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewChangesButton.Location = new System.Drawing.Point(735, 13);
            this.previewChangesButton.Name = "previewChangesButton";
            this.previewChangesButton.Size = new System.Drawing.Size(122, 23);
            this.previewChangesButton.TabIndex = 0;
            this.previewChangesButton.Text = "Preview Changes";
            this.previewChangesButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(863, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.generateSqlButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.previewChangesButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 536);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(950, 48);
            this.buttonPanel.TabIndex = 4;
            // 
            // generateSqlButton
            // 
            this.generateSqlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.generateSqlButton.Location = new System.Drawing.Point(12, 13);
            this.generateSqlButton.Name = "generateSqlButton";
            this.generateSqlButton.Size = new System.Drawing.Size(127, 23);
            this.generateSqlButton.TabIndex = 2;
            this.generateSqlButton.Text = "Generate SQL";
            this.generateSqlButton.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid.DisplayLayout.Appearance = appearance2;
            this.grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.grid.DisplayLayout.GroupByBox.Appearance = appearance11;
            appearance13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance13;
            this.grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid.DisplayLayout.GroupByBox.Hidden = true;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.grid.DisplayLayout.MaxColScrollRegions = 1;
            this.grid.DisplayLayout.MaxRowScrollRegions = 1;
            this.grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            this.grid.DisplayLayout.Override.CardAreaAppearance = appearance21;
            appearance17.BorderColor = System.Drawing.Color.Silver;
            appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid.DisplayLayout.Override.CellAppearance = appearance17;
            this.grid.DisplayLayout.Override.CellPadding = 0;
            appearance15.BackColor = System.Drawing.SystemColors.Control;
            appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.BorderColor = System.Drawing.SystemColors.Window;
            this.grid.DisplayLayout.Override.GroupByRowAppearance = appearance15;
            appearance16.TextHAlignAsString = "Left";
            this.grid.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            this.grid.DisplayLayout.Override.RowAppearance = appearance19;
            this.grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
            this.grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(926, 507);
            this.grid.TabIndex = 5;
            this.grid.Text = "oltGrid1";
            this.grid.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.grid_MouseEnterElement);
            this.grid.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.grid_MouseLeaveElement);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Com.Suncor.Olt.Client.Domain.RoleMatrixDisplayAdapter);
            // 
            // ConfigureRoleMatrixForm
            // 
            this.AcceptButton = this.previewChangesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(950, 584);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.buttonPanel);
            this.MinimumSize = new System.Drawing.Size(611, 186);
            this.Name = "ConfigureRoleMatrixForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Role Matrix";
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OltControls.OltButton previewChangesButton;
        private OltControls.OltButton cancelButton;
        private OltControls.OltPanel buttonPanel;
        private OltControls.OltGrid grid;
        private System.Windows.Forms.BindingSource bindingSource;
        private OltControls.OltButton generateSqlButton;
    }
}