namespace TestTool
{
    partial class PermitRequestControl
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
            this.requestTextBox = new System.Windows.Forms.TextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.requestGroupBox = new System.Windows.Forms.GroupBox();
            this.responseGroupBox = new System.Windows.Forms.GroupBox();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.serverURITextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.oltGroupBox1 = new Com.Suncor.Olt.Client.OltControls.OltGroupBox();
            this.localhostRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.ipAddressRadioButton = new Com.Suncor.Olt.Client.OltControls.OltRadioButton();
            this.requestGroupBox.SuspendLayout();
            this.responseGroupBox.SuspendLayout();
            this.oltGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // requestTextBox
            // 
            this.requestTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestTextBox.Location = new System.Drawing.Point(3, 16);
            this.requestTextBox.Multiline = true;
            this.requestTextBox.Name = "requestTextBox";
            this.requestTextBox.ReadOnly = true;
            this.requestTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.requestTextBox.Size = new System.Drawing.Size(670, 120);
            this.requestTextBox.TabIndex = 0;
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(3, 3);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(75, 23);
            this.listenButton.TabIndex = 1;
            this.listenButton.Text = "Listen";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // requestGroupBox
            // 
            this.requestGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestGroupBox.Controls.Add(this.requestTextBox);
            this.requestGroupBox.Location = new System.Drawing.Point(7, 61);
            this.requestGroupBox.Name = "requestGroupBox";
            this.requestGroupBox.Size = new System.Drawing.Size(676, 139);
            this.requestGroupBox.TabIndex = 3;
            this.requestGroupBox.TabStop = false;
            this.requestGroupBox.Text = "Request";
            // 
            // responseGroupBox
            // 
            this.responseGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseGroupBox.Controls.Add(this.responseTextBox);
            this.responseGroupBox.Location = new System.Drawing.Point(7, 206);
            this.responseGroupBox.Name = "responseGroupBox";
            this.responseGroupBox.Size = new System.Drawing.Size(676, 250);
            this.responseGroupBox.TabIndex = 4;
            this.responseGroupBox.TabStop = false;
            this.responseGroupBox.Text = "Response";
            // 
            // responseTextBox
            // 
            this.responseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseTextBox.Location = new System.Drawing.Point(3, 16);
            this.responseTextBox.MaxLength = 65534;
            this.responseTextBox.Multiline = true;
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseTextBox.Size = new System.Drawing.Size(670, 231);
            this.responseTextBox.TabIndex = 0;
            // 
            // serverURITextBox
            // 
            this.serverURITextBox.Location = new System.Drawing.Point(76, 32);
            this.serverURITextBox.Name = "serverURITextBox";
            this.serverURITextBox.Size = new System.Drawing.Size(174, 20);
            this.serverURITextBox.TabIndex = 5;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(7, 35);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(63, 13);
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "Server URI:";
            // 
            // oltGroupBox1
            // 
            this.oltGroupBox1.Controls.Add(this.ipAddressRadioButton);
            this.oltGroupBox1.Controls.Add(this.localhostRadioButton);
            this.oltGroupBox1.Location = new System.Drawing.Point(266, 15);
            this.oltGroupBox1.Name = "oltGroupBox1";
            this.oltGroupBox1.Size = new System.Drawing.Size(174, 40);
            this.oltGroupBox1.TabIndex = 1;
            this.oltGroupBox1.TabStop = false;
            this.oltGroupBox1.Text = "URL Type";
            // 
            // localhostRadioButton
            // 
            this.localhostRadioButton.AutoSize = true;
            this.localhostRadioButton.Location = new System.Drawing.Point(89, 18);
            this.localhostRadioButton.Name = "localhostRadioButton";
            this.localhostRadioButton.Size = new System.Drawing.Size(70, 17);
            this.localhostRadioButton.TabIndex = 0;
            this.localhostRadioButton.Text = "Localhost";
            this.localhostRadioButton.UseVisualStyleBackColor = true;
            // 
            // ipAddressRadioButton
            // 
            this.ipAddressRadioButton.AutoSize = true;
            this.ipAddressRadioButton.Checked = true;
            this.ipAddressRadioButton.Location = new System.Drawing.Point(6, 17);
            this.ipAddressRadioButton.Name = "ipAddressRadioButton";
            this.ipAddressRadioButton.Size = new System.Drawing.Size(77, 17);
            this.ipAddressRadioButton.TabIndex = 1;
            this.ipAddressRadioButton.TabStop = true;
            this.ipAddressRadioButton.Text = "IP Address";
            this.ipAddressRadioButton.UseVisualStyleBackColor = true;
            // 
            // PermitRequestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oltGroupBox1);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.serverURITextBox);
            this.Controls.Add(this.responseGroupBox);
            this.Controls.Add(this.requestGroupBox);
            this.Controls.Add(this.listenButton);
            this.Name = "PermitRequestControl";
            this.Size = new System.Drawing.Size(686, 464);
            this.requestGroupBox.ResumeLayout(false);
            this.requestGroupBox.PerformLayout();
            this.responseGroupBox.ResumeLayout(false);
            this.responseGroupBox.PerformLayout();
            this.oltGroupBox1.ResumeLayout(false);
            this.oltGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox requestTextBox;
        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.GroupBox requestGroupBox;
        private System.Windows.Forms.GroupBox responseGroupBox;
        private System.Windows.Forms.TextBox responseTextBox;
        private System.Windows.Forms.TextBox serverURITextBox;
        private System.Windows.Forms.Label portLabel;
        private Com.Suncor.Olt.Client.OltControls.OltGroupBox oltGroupBox1;
        private Com.Suncor.Olt.Client.OltControls.OltRadioButton ipAddressRadioButton;
        private Com.Suncor.Olt.Client.OltControls.OltRadioButton localhostRadioButton;
    }
}
