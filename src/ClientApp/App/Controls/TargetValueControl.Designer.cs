using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class TargetValueControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetValueControl));
            this.targetValueNumericBox = new OltUltraNumericEditor(this.components);
            this.targetRadioButton = new System.Windows.Forms.RadioButton();
            this.minimizeRadioButton = new System.Windows.Forms.RadioButton();
            this.maximizeRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.targetValueNumericBox)).BeginInit();
            this.SuspendLayout();
            // 
            // targetValueNumericBox
            // 
            this.targetValueNumericBox.FormatString = "";
            resources.ApplyResources(this.targetValueNumericBox, "targetValueNumericBox");
            //Changed by Mukesh for RITM0252906
            this.targetValueNumericBox.MaskInput = "-nnnnnn.nnn";
            this.targetValueNumericBox.Name = "targetValueNumericBox";
            this.targetValueNumericBox.Nullable = true;
            this.targetValueNumericBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.targetValueNumericBox.PromptChar = ' ';
            // 
            // targetRadioButton
            // 
            resources.ApplyResources(this.targetRadioButton, "targetRadioButton");
            this.targetRadioButton.Checked = true;
            this.targetRadioButton.Name = "targetRadioButton";
            this.targetRadioButton.TabStop = true;
            this.targetRadioButton.UseVisualStyleBackColor = true;
            this.targetRadioButton.CheckedChanged += new System.EventHandler(this.HandleTypeChange);
            // 
            // minimizeRadioButton
            // 
            resources.ApplyResources(this.minimizeRadioButton, "minimizeRadioButton");
            this.minimizeRadioButton.Name = "minimizeRadioButton";
            this.minimizeRadioButton.TabStop = true;
            this.minimizeRadioButton.UseVisualStyleBackColor = true;
            this.minimizeRadioButton.CheckedChanged += new System.EventHandler(this.HandleTypeChange);
            // 
            // maximizeRadioButton
            // 
            resources.ApplyResources(this.maximizeRadioButton, "maximizeRadioButton");
            this.maximizeRadioButton.Name = "maximizeRadioButton";
            this.maximizeRadioButton.TabStop = true;
            this.maximizeRadioButton.UseVisualStyleBackColor = true;
            this.maximizeRadioButton.CheckedChanged += new System.EventHandler(this.HandleTypeChange);
            // 
            // TargetValueControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.targetValueNumericBox);
            this.Controls.Add(this.maximizeRadioButton);
            this.Controls.Add(this.minimizeRadioButton);
            this.Controls.Add(this.targetRadioButton);
            this.Name = "TargetValueControl";
            ((System.ComponentModel.ISupportInitialize)(this.targetValueNumericBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltUltraNumericEditor targetValueNumericBox;
        private System.Windows.Forms.RadioButton targetRadioButton;
        private System.Windows.Forms.RadioButton minimizeRadioButton;
        private System.Windows.Forms.RadioButton maximizeRadioButton;

    }
}
