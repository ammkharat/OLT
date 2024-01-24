
namespace Com.Suncor.Olt.Client.Forms
{
    public interface IActionItemDefinitionAutoReApprovalConfigurationView
    {
        bool NameChange { set; get; }
        bool CategoryChange { set; get; }
        bool OperationalModeChange { set; get; }
        bool PriorityChange { set; get; }
        bool DescriptionChange { set; get; }
        bool DocumentLinksChange { set; get; }
        bool FunctionalLocationsChange { set; get; }
        bool TargetDependenciesChange { set; get; }
        bool ScheduleChange { set; get; }
        bool RequiresResponseWhenTriggeredChange { set; get; }
        bool AssignmentChange { set; get; }
        bool ActionItemGenerationModeChange { get; set; }
    }
}