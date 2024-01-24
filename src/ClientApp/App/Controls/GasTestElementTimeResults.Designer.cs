using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
	partial class GasTestElementTimeResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GasTestElementTimeResults));
            this.immediateAreaTimeLabel = new OltLabel();
            this.confinedSpaceTestTimeLabel = new OltLabel();
            this.firstResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.confinedSpaceTimePicker = new OltTimePicker();
            this.immediateAreaTimePicker = new OltTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.firstResultWarningProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // immediateAreaTimeLabel
            // 
            resources.ApplyResources(this.immediateAreaTimeLabel, "immediateAreaTimeLabel");
            this.immediateAreaTimeLabel.Name = "immediateAreaTimeLabel";
            // 
            // confinedSpaceTestTimeLabel
            // 
            resources.ApplyResources(this.confinedSpaceTestTimeLabel, "confinedSpaceTestTimeLabel");
            this.confinedSpaceTestTimeLabel.Name = "confinedSpaceTestTimeLabel";
            // 
            // firstResultWarningProvider
            // 
            this.firstResultWarningProvider.ContainerControl = this;
            // 
            // confinedSpaceTimePicker
            // 
            this.confinedSpaceTimePicker.Checked = true;
            resources.ApplyResources(this.confinedSpaceTimePicker, "confinedSpaceTimePicker");
            this.confinedSpaceTimePicker.Name = "confinedSpaceTimePicker";
            this.confinedSpaceTimePicker.ShowCheckBox = true;
            // 
            // immediateAreaTimePicker
            // 
            this.immediateAreaTimePicker.Checked = true;
            resources.ApplyResources(this.immediateAreaTimePicker, "immediateAreaTimePicker");
            this.immediateAreaTimePicker.Name = "immediateAreaTimePicker";
            this.immediateAreaTimePicker.ShowCheckBox = true;
            // 
            // GasTestElementTimeResults
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.immediateAreaTimePicker);
            this.Controls.Add(this.confinedSpaceTimePicker);
            this.Controls.Add(this.confinedSpaceTestTimeLabel);
            this.Controls.Add(this.immediateAreaTimeLabel);
            this.Name = "GasTestElementTimeResults";
            ((System.ComponentModel.ISupportInitialize)(this.firstResultWarningProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private OltLabel immediateAreaTimeLabel;
        private System.Windows.Forms.ErrorProvider firstResultWarningProvider;
        private OltLabel confinedSpaceTestTimeLabel;
        private OltTimePicker immediateAreaTimePicker;
        private OltTimePicker confinedSpaceTimePicker;	   	    
	}
}
