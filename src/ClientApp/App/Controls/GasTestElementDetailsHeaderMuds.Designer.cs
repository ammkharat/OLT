using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls
{
    partial class GasTestElementDetailsHeaderMuds
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
            this.limitLabel = new System.Windows.Forms.Label();
            this.confinedSpaceLabel = new System.Windows.Forms.Label();
            this.firstResultWarningProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Thirdlabel = new System.Windows.Forms.Label();
            this.FourthLabel = new System.Windows.Forms.Label();
            this.FourthResultLable = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.FourthRequiredLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.ThirdResultlable = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.ThirrequiredLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.confinedSpaceResultLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.confinedSpaceRequiredLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.immediateAreaResultLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.immediateAreaRequiredLabel = new Com.Suncor.Olt.Client.OltControls.OltLabelData();
            this.immediateAreaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.firstResultWarningProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.limitLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.limitLabel.Location = new System.Drawing.Point(221, 4);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(40, 13);
            this.limitLabel.TabIndex = 16;
            this.limitLabel.Text = " limite";
            this.limitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // confinedSpaceLabel
            // 
            this.confinedSpaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.confinedSpaceLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.confinedSpaceLabel.Location = new System.Drawing.Point(476, 3);
            this.confinedSpaceLabel.Name = "confinedSpaceLabel";
            this.confinedSpaceLabel.Size = new System.Drawing.Size(136, 13);
            this.confinedSpaceLabel.TabIndex = 18;
            this.confinedSpaceLabel.Text = "2e  résultat";
            this.confinedSpaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstResultWarningProvider
            // 
            this.firstResultWarningProvider.ContainerControl = this;
            // 
            // Thirdlabel
            // 
            this.Thirdlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Thirdlabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Thirdlabel.Location = new System.Drawing.Point(598, 0);
            this.Thirdlabel.Name = "Thirdlabel";
            this.Thirdlabel.Size = new System.Drawing.Size(151, 13);
            this.Thirdlabel.TabIndex = 21;
            this.Thirdlabel.Text = "3e  résultat";
            this.Thirdlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FourthLabel
            // 
            this.FourthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.FourthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FourthLabel.Location = new System.Drawing.Point(742, 3);
            this.FourthLabel.Name = "FourthLabel";
            this.FourthLabel.Size = new System.Drawing.Size(151, 13);
            this.FourthLabel.TabIndex = 24;
            this.FourthLabel.Text = "4e résultat";
            this.FourthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FourthResultLable
            // 
            this.FourthResultLable.BackColor = System.Drawing.SystemColors.Control;
            this.FourthResultLable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FourthResultLable.Location = new System.Drawing.Point(826, 17);
            this.FourthResultLable.Name = "FourthResultLable";
            this.FourthResultLable.Size = new System.Drawing.Size(67, 17);
            this.FourthResultLable.TabIndex = 23;
            this.FourthResultLable.Text = "résultat";
            this.FourthResultLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FourthResultLable.UseMnemonic = false;
            // 
            // FourthRequiredLabel
            // 
            this.FourthRequiredLabel.BackColor = System.Drawing.SystemColors.Control;
            this.FourthRequiredLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FourthRequiredLabel.Location = new System.Drawing.Point(755, 17);
            this.FourthRequiredLabel.Name = "FourthRequiredLabel";
            this.FourthRequiredLabel.Size = new System.Drawing.Size(51, 17);
            this.FourthRequiredLabel.TabIndex = 22;
            this.FourthRequiredLabel.Text = "Requis";
            this.FourthRequiredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FourthRequiredLabel.UseMnemonic = false;
            // 
            // ThirdResultlable
            // 
            this.ThirdResultlable.BackColor = System.Drawing.SystemColors.Control;
            this.ThirdResultlable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ThirdResultlable.Location = new System.Drawing.Point(668, 18);
            this.ThirdResultlable.Name = "ThirdResultlable";
            this.ThirdResultlable.Size = new System.Drawing.Size(67, 17);
            this.ThirdResultlable.TabIndex = 20;
            this.ThirdResultlable.Text = "résultat";
            this.ThirdResultlable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThirdResultlable.UseMnemonic = false;
            // 
            // ThirrequiredLabel
            // 
            this.ThirrequiredLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ThirrequiredLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ThirrequiredLabel.Location = new System.Drawing.Point(611, 18);
            this.ThirrequiredLabel.Name = "ThirrequiredLabel";
            this.ThirrequiredLabel.Size = new System.Drawing.Size(51, 17);
            this.ThirrequiredLabel.TabIndex = 19;
            this.ThirrequiredLabel.Text = "Requis";
            this.ThirrequiredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThirrequiredLabel.UseMnemonic = false;
            // 
            // confinedSpaceResultLabel
            // 
            this.confinedSpaceResultLabel.BackColor = System.Drawing.SystemColors.Control;
            this.confinedSpaceResultLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.confinedSpaceResultLabel.Location = new System.Drawing.Point(520, 21);
            this.confinedSpaceResultLabel.Name = "confinedSpaceResultLabel";
            this.confinedSpaceResultLabel.Size = new System.Drawing.Size(68, 17);
            this.confinedSpaceResultLabel.TabIndex = 15;
            this.confinedSpaceResultLabel.Text = "résultat";
            this.confinedSpaceResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.confinedSpaceResultLabel.UseMnemonic = false;
            // 
            // confinedSpaceRequiredLabel
            // 
            this.confinedSpaceRequiredLabel.BackColor = System.Drawing.SystemColors.Control;
            this.confinedSpaceRequiredLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.confinedSpaceRequiredLabel.Location = new System.Drawing.Point(462, 21);
            this.confinedSpaceRequiredLabel.Name = "confinedSpaceRequiredLabel";
            this.confinedSpaceRequiredLabel.Size = new System.Drawing.Size(50, 17);
            this.confinedSpaceRequiredLabel.TabIndex = 14;
            this.confinedSpaceRequiredLabel.Text = "Requis";
            this.confinedSpaceRequiredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.confinedSpaceRequiredLabel.UseMnemonic = false;
            // 
            // immediateAreaResultLabel
            // 
            this.immediateAreaResultLabel.BackColor = System.Drawing.SystemColors.Control;
            this.immediateAreaResultLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.immediateAreaResultLabel.Location = new System.Drawing.Point(366, 21);
            this.immediateAreaResultLabel.Name = "immediateAreaResultLabel";
            this.immediateAreaResultLabel.Size = new System.Drawing.Size(67, 17);
            this.immediateAreaResultLabel.TabIndex = 13;
            this.immediateAreaResultLabel.Text = "résultat";
            this.immediateAreaResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.immediateAreaResultLabel.UseMnemonic = false;
            // 
            // immediateAreaRequiredLabel
            // 
            this.immediateAreaRequiredLabel.BackColor = System.Drawing.SystemColors.Control;
            this.immediateAreaRequiredLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.immediateAreaRequiredLabel.Location = new System.Drawing.Point(309, 21);
            this.immediateAreaRequiredLabel.Name = "immediateAreaRequiredLabel";
            this.immediateAreaRequiredLabel.Size = new System.Drawing.Size(51, 17);
            this.immediateAreaRequiredLabel.TabIndex = 12;
            this.immediateAreaRequiredLabel.Text = "Requis";
            this.immediateAreaRequiredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.immediateAreaRequiredLabel.UseMnemonic = false;
            // 
            // immediateAreaLabel
            // 
            this.immediateAreaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.immediateAreaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.immediateAreaLabel.Location = new System.Drawing.Point(297, 4);
            this.immediateAreaLabel.Name = "immediateAreaLabel";
            this.immediateAreaLabel.Size = new System.Drawing.Size(136, 13);
            this.immediateAreaLabel.TabIndex = 25;
            this.immediateAreaLabel.Text = " 1er résultat";
            this.immediateAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GasTestElementDetailsHeaderMuds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.immediateAreaLabel);
            this.Controls.Add(this.FourthLabel);
            this.Controls.Add(this.FourthResultLable);
            this.Controls.Add(this.FourthRequiredLabel);
            this.Controls.Add(this.Thirdlabel);
            this.Controls.Add(this.ThirdResultlable);
            this.Controls.Add(this.ThirrequiredLabel);
            this.Controls.Add(this.confinedSpaceLabel);
            this.Controls.Add(this.limitLabel);
            this.Controls.Add(this.confinedSpaceResultLabel);
            this.Controls.Add(this.confinedSpaceRequiredLabel);
            this.Controls.Add(this.immediateAreaResultLabel);
            this.Controls.Add(this.immediateAreaRequiredLabel);
            this.Name = "GasTestElementDetailsHeaderMuds";
            this.Size = new System.Drawing.Size(929, 38);
            ((System.ComponentModel.ISupportInitialize)(this.firstResultWarningProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private ErrorProvider firstResultWarningProvider;
        private System.Windows.Forms.Label confinedSpaceLabel;
        private System.Windows.Forms.Label limitLabel;
        private OltLabelData confinedSpaceResultLabel;
        private OltLabelData confinedSpaceRequiredLabel;
        private OltLabelData immediateAreaResultLabel;
        private OltLabelData immediateAreaRequiredLabel;
        private Label FourthLabel;
        private OltLabelData FourthResultLable;
        private OltLabelData FourthRequiredLabel;
        private Label Thirdlabel;
        private OltLabelData ThirdResultlable;
        private OltLabelData ThirrequiredLabel;
        private Label immediateAreaLabel;
	}
}
