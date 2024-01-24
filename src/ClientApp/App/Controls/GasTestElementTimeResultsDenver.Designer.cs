using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class GasTestElementTimeResultsDenver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GasTestElementTimeResultsDenver));
            this.firstResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.confinedSpaceTimePicker = new OltTimePicker();
            this.immediateAreaTimePicker = new OltTimePicker();
            this.systemEntryTimePicker = new OltTimePicker();
            this.oltLabel1 = new OltLabel();
            this.oltLabel2 = new OltLabel();
            this.oltLabel3 = new OltLabel();
            ((System.ComponentModel.ISupportInitialize)(this.firstResultWarningProvider)).BeginInit();
            this.SuspendLayout();
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
            // systemEntryTimePicker
            // 
            this.systemEntryTimePicker.Checked = true;
            resources.ApplyResources(this.systemEntryTimePicker, "systemEntryTimePicker");
            this.systemEntryTimePicker.Name = "systemEntryTimePicker";
            this.systemEntryTimePicker.ShowCheckBox = true;
            // 
            // oltLabel1
            // 
            resources.ApplyResources(this.oltLabel1, "oltLabel1");
            this.oltLabel1.Name = "oltLabel1";
            // 
            // oltLabel2
            // 
            resources.ApplyResources(this.oltLabel2, "oltLabel2");
            this.oltLabel2.Name = "oltLabel2";
            // 
            // oltLabel3
            // 
            resources.ApplyResources(this.oltLabel3, "oltLabel3");
            this.oltLabel3.Name = "oltLabel3";
            // 
            // GasTestElementTimeResultsDenver
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltLabel3);
            this.Controls.Add(this.oltLabel2);
            this.Controls.Add(this.systemEntryTimePicker);
            this.Controls.Add(this.oltLabel1);
            this.Controls.Add(this.immediateAreaTimePicker);
            this.Controls.Add(this.confinedSpaceTimePicker);
            this.Name = "GasTestElementTimeResultsDenver";
            ((System.ComponentModel.ISupportInitialize)(this.firstResultWarningProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ErrorProvider firstResultWarningProvider;
        private OltTimePicker immediateAreaTimePicker;
        private OltTimePicker confinedSpaceTimePicker;
        private OltLabel oltLabel3;
        private OltLabel oltLabel2;
        private OltTimePicker systemEntryTimePicker;
        private OltLabel oltLabel1;	   	    
	}
}