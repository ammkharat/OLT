using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class GasTestElementDetailsMuds
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
            this.immediateAreaResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.confinedSpaceResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.confinedSpaceResultAlertProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.immediateAreaResulAlertProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.thirdResultAlertProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fourthResultAlertProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.FourthResultNumericTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.FourthResultCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.ThirdResultNumericTextBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.ThirdResultCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.confinedSpaceTestResultNumericBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.confinedSpaceRequiredCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.immediateAreaTestResultNumericBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.elementNameTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.limitsTextBox = new Com.Suncor.Olt.Client.OltControls.OltTextBox();
            this.requiredCheckBox = new Com.Suncor.Olt.Client.OltControls.OltCheckBox();
            this.elementNameLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaResultWarningProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceResultWarningProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceResultAlertProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaResulAlertProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdResultAlertProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthResultAlertProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourthResultNumericTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdResultNumericTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceTestResultNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaTestResultNumericBox)).BeginInit();
            this.SuspendLayout();
            // 
            // immediateAreaResultWarningProvider
            // 
            this.immediateAreaResultWarningProvider.ContainerControl = this;
            // 
            // confinedSpaceResultWarningProvider
            // 
            this.confinedSpaceResultWarningProvider.ContainerControl = this;
            // 
            // confinedSpaceResultAlertProvider
            // 
            this.confinedSpaceResultAlertProvider.ContainerControl = this;
            // 
            // immediateAreaResulAlertProvider
            // 
            this.immediateAreaResulAlertProvider.ContainerControl = this;
            // 
            // thirdResultAlertProvider
            // 
            this.thirdResultAlertProvider.ContainerControl = this;
            // 
            // fourthResultAlertProvider
            // 
            this.fourthResultAlertProvider.ContainerControl = this;
            // 
            // FourthResultNumericTextBox
            // 
            this.FourthResultNumericTextBox.FormatProvider = new System.Globalization.CultureInfo("fr-CA");
            this.FourthResultNumericTextBox.Location = new System.Drawing.Point(812, 3);
            this.FourthResultNumericTextBox.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.FourthResultNumericTextBox.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.FourthResultNumericTextBox.Name = "FourthResultNumericTextBox";
            this.FourthResultNumericTextBox.Nullable = true;
            this.FourthResultNumericTextBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.FourthResultNumericTextBox.Size = new System.Drawing.Size(95, 21);
            this.FourthResultNumericTextBox.TabIndex = 11;
            // 
            // FourthResultCheckBox
            // 
            this.FourthResultCheckBox.AutoSize = true;
            this.FourthResultCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FourthResultCheckBox.Location = new System.Drawing.Point(784, 5);
            this.FourthResultCheckBox.Name = "FourthResultCheckBox";
            this.FourthResultCheckBox.Size = new System.Drawing.Size(15, 14);
            this.FourthResultCheckBox.TabIndex = 12;
            this.FourthResultCheckBox.UseVisualStyleBackColor = true;
            this.FourthResultCheckBox.Value = null;
            // 
            // ThirdResultNumericTextBox
            // 
            this.ThirdResultNumericTextBox.FormatProvider = new System.Globalization.CultureInfo("fr-CA");
            this.ThirdResultNumericTextBox.Location = new System.Drawing.Point(654, 0);
            this.ThirdResultNumericTextBox.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.ThirdResultNumericTextBox.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.ThirdResultNumericTextBox.Name = "ThirdResultNumericTextBox";
            this.ThirdResultNumericTextBox.Nullable = true;
            this.ThirdResultNumericTextBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.ThirdResultNumericTextBox.Size = new System.Drawing.Size(95, 21);
            this.ThirdResultNumericTextBox.TabIndex = 10;
            // 
            // ThirdResultCheckBox
            // 
            this.ThirdResultCheckBox.AutoSize = true;
            this.ThirdResultCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ThirdResultCheckBox.Location = new System.Drawing.Point(626, 2);
            this.ThirdResultCheckBox.Name = "ThirdResultCheckBox";
            this.ThirdResultCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ThirdResultCheckBox.TabIndex = 9;
            this.ThirdResultCheckBox.UseVisualStyleBackColor = true;
            this.ThirdResultCheckBox.Value = null;
            // 
            // confinedSpaceTestResultNumericBox
            // 
            this.confinedSpaceTestResultNumericBox.FormatProvider = new System.Globalization.CultureInfo("fr-CA");
            this.confinedSpaceTestResultNumericBox.Location = new System.Drawing.Point(497, 0);
            this.confinedSpaceTestResultNumericBox.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.confinedSpaceTestResultNumericBox.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.confinedSpaceTestResultNumericBox.Name = "confinedSpaceTestResultNumericBox";
            this.confinedSpaceTestResultNumericBox.Nullable = true;
            this.confinedSpaceTestResultNumericBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.confinedSpaceTestResultNumericBox.Size = new System.Drawing.Size(95, 21);
            this.confinedSpaceTestResultNumericBox.TabIndex = 3;
            // 
            // confinedSpaceRequiredCheckBox
            // 
            this.confinedSpaceRequiredCheckBox.AutoSize = true;
            this.confinedSpaceRequiredCheckBox.Location = new System.Drawing.Point(469, 2);
            this.confinedSpaceRequiredCheckBox.Name = "confinedSpaceRequiredCheckBox";
            this.confinedSpaceRequiredCheckBox.Size = new System.Drawing.Size(15, 14);
            this.confinedSpaceRequiredCheckBox.TabIndex = 8;
            this.confinedSpaceRequiredCheckBox.UseVisualStyleBackColor = true;
            this.confinedSpaceRequiredCheckBox.Value = null;
            // 
            // immediateAreaTestResultNumericBox
            // 
            this.immediateAreaTestResultNumericBox.FormatProvider = new System.Globalization.CultureInfo("fr-CA");
            this.immediateAreaTestResultNumericBox.Location = new System.Drawing.Point(348, 0);
            this.immediateAreaTestResultNumericBox.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.immediateAreaTestResultNumericBox.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.immediateAreaTestResultNumericBox.Name = "immediateAreaTestResultNumericBox";
            this.immediateAreaTestResultNumericBox.Nullable = true;
            this.immediateAreaTestResultNumericBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.immediateAreaTestResultNumericBox.Size = new System.Drawing.Size(95, 21);
            this.immediateAreaTestResultNumericBox.TabIndex = 2;
            // 
            // elementNameTextBox
            // 
            this.elementNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.elementNameTextBox.Location = new System.Drawing.Point(60, 0);
            this.elementNameTextBox.MaxLength = 50;
            this.elementNameTextBox.Name = "elementNameTextBox";
            this.elementNameTextBox.OltAcceptsReturn = true;
            this.elementNameTextBox.OltTrimWhitespace = true;
            this.elementNameTextBox.Size = new System.Drawing.Size(103, 20);
            this.elementNameTextBox.TabIndex = 0;
            this.elementNameTextBox.Visible = false;
            // 
            // limitsTextBox
            // 
            this.limitsTextBox.Enabled = false;
            this.limitsTextBox.Location = new System.Drawing.Point(186, 0);
            this.limitsTextBox.MaxLength = 50;
            this.limitsTextBox.Name = "limitsTextBox";
            this.limitsTextBox.OltAcceptsReturn = true;
            this.limitsTextBox.OltTrimWhitespace = true;
            this.limitsTextBox.Size = new System.Drawing.Size(103, 20);
            this.limitsTextBox.TabIndex = 1;
            this.limitsTextBox.Text = "Limits";
            this.limitsTextBox.TextChanged += new System.EventHandler(this.limitsTextBox_TextChanged);
            // 
            // requiredCheckBox
            // 
            this.requiredCheckBox.AutoSize = true;
            this.requiredCheckBox.Location = new System.Drawing.Point(320, 2);
            this.requiredCheckBox.Name = "requiredCheckBox";
            this.requiredCheckBox.Size = new System.Drawing.Size(15, 14);
            this.requiredCheckBox.TabIndex = 1;
            this.requiredCheckBox.UseVisualStyleBackColor = true;
            this.requiredCheckBox.Value = null;
            // 
            // elementNameLabel
            // 
            this.elementNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.elementNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.elementNameLabel.Location = new System.Drawing.Point(0, 0);
            this.elementNameLabel.Name = "elementNameLabel";
            this.elementNameLabel.Size = new System.Drawing.Size(175, 27);
            this.elementNameLabel.TabIndex = 0;
            this.elementNameLabel.Text = "Element Name";
            this.elementNameLabel.UseMnemonic = false;
            // 
            // GasTestElementDetailsMuds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.FourthResultNumericTextBox);
            this.Controls.Add(this.FourthResultCheckBox);
            this.Controls.Add(this.ThirdResultNumericTextBox);
            this.Controls.Add(this.ThirdResultCheckBox);
            this.Controls.Add(this.confinedSpaceTestResultNumericBox);
            this.Controls.Add(this.confinedSpaceRequiredCheckBox);
            this.Controls.Add(this.immediateAreaTestResultNumericBox);
            this.Controls.Add(this.elementNameTextBox);
            this.Controls.Add(this.limitsTextBox);
            this.Controls.Add(this.requiredCheckBox);
            this.Controls.Add(this.elementNameLabel);
            this.Name = "GasTestElementDetailsMuds";
            this.Size = new System.Drawing.Size(910, 27);
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaResultWarningProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceResultWarningProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceResultAlertProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaResulAlertProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdResultAlertProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthResultAlertProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourthResultNumericTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdResultNumericTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceTestResultNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaTestResultNumericBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private OltLabelData elementNameLabel;
        private OltCheckBox requiredCheckBox;
        private OltTextBox limitsTextBox;
        private OltTextBox elementNameTextBox;
        private OltUltraNumericEditor immediateAreaTestResultNumericBox;
        private ErrorProvider immediateAreaResultWarningProvider;
        private OltUltraNumericEditor confinedSpaceTestResultNumericBox;
        private OltCheckBox confinedSpaceRequiredCheckBox;
        private ErrorProvider confinedSpaceResultWarningProvider;
        private ErrorProvider confinedSpaceResultAlertProvider; //vibhor
        private ErrorProvider immediateAreaResulAlertProvider;
        private OltUltraNumericEditor FourthResultNumericTextBox;
        private OltCheckBox FourthResultCheckBox;
        private OltUltraNumericEditor ThirdResultNumericTextBox;
        private OltCheckBox ThirdResultCheckBox;
        private ErrorProvider thirdResultAlertProvider;
        private ErrorProvider fourthResultAlertProvider; //vibhor
        
        
	}
}
