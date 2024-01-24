using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class ValueFrequencyBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValueFrequencyBox));
            this.valueLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.valueNumericBox = new Com.Suncor.Olt.Client.OltControls.OltUltraNumericEditor(this.components);
            this.unitLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.frequencyLabel = new Com.Suncor.Olt.Client.OltControls.OltLabel();
            this.frequencyNumericUpDown = new Com.Suncor.Olt.Client.OltControls.OltNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // valueLabel
            // 
            resources.ApplyResources(this.valueLabel, "valueLabel");
            this.valueLabel.Name = "valueLabel";
            // 
            // valueNumericBox
            // 
            resources.ApplyResources(this.valueNumericBox, "valueNumericBox");
            this.valueNumericBox.FormatString = "";
            //Changed by Mukesh for RITM0252906
            this.valueNumericBox.MaskInput = "-nnnnnn.nnn";
            this.valueNumericBox.Name = "valueNumericBox";
            this.valueNumericBox.Nullable = true;
            this.valueNumericBox.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.valueNumericBox.PromptChar = ' ';
            // 
            // unitLabel
            // 
            resources.ApplyResources(this.unitLabel, "unitLabel");
            this.unitLabel.Name = "unitLabel";
            // 
            // frequencyLabel
            // 
            resources.ApplyResources(this.frequencyLabel, "frequencyLabel");
            this.frequencyLabel.Name = "frequencyLabel";
            // 
            // frequencyNumericUpDown
            // 
            resources.ApplyResources(this.frequencyNumericUpDown, "frequencyNumericUpDown");
            this.frequencyNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frequencyNumericUpDown.Name = "frequencyNumericUpDown";
            this.frequencyNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ValueFrequencyBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.valueNumericBox);
            this.Controls.Add(this.unitLabel);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.frequencyNumericUpDown);
            this.Name = "ValueFrequencyBox";
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OltNumericUpDown frequencyNumericUpDown;
        private OltLabel frequencyLabel;
        private OltLabel valueLabel;
        private OltLabel unitLabel;
        private OltUltraNumericEditor valueNumericBox;
    }
}
