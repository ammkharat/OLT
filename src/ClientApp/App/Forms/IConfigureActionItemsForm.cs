namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureActionItemsForm : IBaseForm
    {
        string SiteName { set; }

        bool AutoApproveWorkOrderActionItemDefinition { set; get; }
        bool AutoApproveSAPAMActionItemDefinition { set; get; }
        bool AutoApproveSAPMCActionItemDefinition { set; get; }
        bool LogRequiredForActionItemResponse { get; set; }
        bool RequiresApprovalDefaultValue { get; set; }
        bool RequiresResponseDefaultValue { get; set; }
    }
}
