using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITargetDefinitionAutoReApprovalConfigurationView
    {
        event EventHandler SelectAllButtonClick;
        event EventHandler ClearAllButtonClick;

        bool NameChange { set; get; }
        bool CategoryChange { set; get; }
        bool OperationalModeChange { set; get; }
        bool PriorityChange { set; get; }
        bool DescriptionChange { set; get; }
        bool DocumentLinksChange { set; get; }
        bool FunctionalLocationChange { set; get; }
        bool PHTagChange { set; get; }
        bool TargetDependenciesChange { set; get; }
        bool ScheduleChange { set; get; }
        bool GenerateActionItemChange { set; get; }
        bool RequiresResponseWhenAlertedChange { set; get; }
        bool SuppressAlertChange { set; get; }
    }
}