using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LogGuidelineForm : BaseForm
    {        
        private readonly string guidelines;

        public LogGuidelineForm(string guidelines)
        {          
            this.guidelines = guidelines;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);           
            guidelinesTextBox.Text = guidelines;
        }
    }
}
