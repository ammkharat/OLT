using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class GasTestElementDetailsDenver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GasTestElementDetailsDenver));
            this.immediateAreaResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.confinedSpaceResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.systemEntryTestResultNumericBox = new OltUltraNumericEditor(this.components);
            this.confinedSpaceTestResultNumericBox = new OltUltraNumericEditor(this.components);
            this.immediateAreaTestResultNumericBox = new OltUltraNumericEditor(this.components);
            this.elementNameTextBox = new OltTextBox();
            this.limitsTextBox = new OltTextBox();
            this.elementNameLabel = new OltLabelData();
            this.systemEntryResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaResultWarningProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceResultWarningProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemEntryTestResultNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceTestResultNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaTestResultNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemEntryResultWarningProvider)).BeginInit();
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
            // systemEntryTestResultNumericBox
            // 
            this.systemEntryTestResultNumericBox.FormatProvider = new System.Globalization.CultureInfo("");
            resources.ApplyResources(this.systemEntryTestResultNumericBox, "systemEntryTestResultNumericBox");
            this.systemEntryTestResultNumericBox.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.systemEntryTestResultNumericBox.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.systemEntryTestResultNumericBox.Name = "systemEntryTestResultNumericBox";
            this.systemEntryTestResultNumericBox.Nullable = true;
            this.systemEntryTestResultNumericBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            // 
            // confinedSpaceTestResultNumericBox
            // 
            this.confinedSpaceTestResultNumericBox.FormatProvider = new System.Globalization.CultureInfo("");
            resources.ApplyResources(this.confinedSpaceTestResultNumericBox, "confinedSpaceTestResultNumericBox");
            this.confinedSpaceTestResultNumericBox.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.confinedSpaceTestResultNumericBox.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.confinedSpaceTestResultNumericBox.Name = "confinedSpaceTestResultNumericBox";
            this.confinedSpaceTestResultNumericBox.Nullable = true;
            this.confinedSpaceTestResultNumericBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            // 
            // immediateAreaTestResultNumericBox
            // 
            this.immediateAreaTestResultNumericBox.FormatProvider = new System.Globalization.CultureInfo("");
            resources.ApplyResources(this.immediateAreaTestResultNumericBox, "immediateAreaTestResultNumericBox");
            this.immediateAreaTestResultNumericBox.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.immediateAreaTestResultNumericBox.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.immediateAreaTestResultNumericBox.Name = "immediateAreaTestResultNumericBox";
            this.immediateAreaTestResultNumericBox.Nullable = true;
            this.immediateAreaTestResultNumericBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            // 
            // elementNameTextBox
            // 
            this.elementNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.elementNameTextBox, "elementNameTextBox");
            this.elementNameTextBox.Name = "elementNameTextBox";
            this.elementNameTextBox.OltAcceptsReturn = true;
            this.elementNameTextBox.OltTrimWhitespace = true;
            // 
            // limitsTextBox
            // 
            resources.ApplyResources(this.limitsTextBox, "limitsTextBox");
            this.limitsTextBox.Name = "limitsTextBox";
            this.limitsTextBox.OltAcceptsReturn = true;
            this.limitsTextBox.OltTrimWhitespace = true;
            // 
            // elementNameLabel
            // 
            this.elementNameLabel.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.elementNameLabel, "elementNameLabel");
            this.elementNameLabel.Name = "elementNameLabel";
            this.elementNameLabel.UseMnemonic = false;
            // 
            // systemEntryResultWarningProvider
            // 
            this.systemEntryResultWarningProvider.ContainerControl = this;
            // 
            // GasTestElementDetailsDenver
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.systemEntryTestResultNumericBox);
            this.Controls.Add(this.confinedSpaceTestResultNumericBox);
            this.Controls.Add(this.immediateAreaTestResultNumericBox);
            this.Controls.Add(this.elementNameTextBox);
            this.Controls.Add(this.limitsTextBox);
            this.Controls.Add(this.elementNameLabel);
            this.Name = "GasTestElementDetailsDenver";
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaResultWarningProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceResultWarningProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemEntryTestResultNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confinedSpaceTestResultNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.immediateAreaTestResultNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemEntryResultWarningProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private OltLabelData elementNameLabel;
        private OltTextBox limitsTextBox;
        private OltTextBox elementNameTextBox;
        private OltUltraNumericEditor immediateAreaTestResultNumericBox;
        private ErrorProvider immediateAreaResultWarningProvider;
        private OltUltraNumericEditor confinedSpaceTestResultNumericBox;
        private ErrorProvider confinedSpaceResultWarningProvider;
        private OltUltraNumericEditor systemEntryTestResultNumericBox;
        private ErrorProvider systemEntryResultWarningProvider;
	}
}
