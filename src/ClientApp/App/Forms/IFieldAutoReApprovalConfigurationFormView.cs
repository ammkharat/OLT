namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFieldAutoReApprovalConfigurationFormView : IBaseForm
    {
        string SiteName { set; }
        ITargetDefinitionAutoReApprovalConfigurationView TargetDefAutoReApprovalConfigView { get;}
        IActionItemDefinitionAutoReApprovalConfigurationView AIDAutoReApprovalConfigView { get;}
    }
}
