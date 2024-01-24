namespace Com.Suncor.Olt.Client
{
    public partial class WaitForm : DevExpress.XtraWaitForm.WaitForm
    {
        public WaitForm()
        {
            InitializeComponent();
            progressPanel.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel.Description = description;
        }
        #endregion

    }
}