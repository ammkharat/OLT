IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND Name = 'UpdateActionItemDefinitionAutoReApprovalConfiguration')
BEGIN
     DROP PROCEDURE UpdateActionItemDefinitionAutoReApprovalConfiguration
END

GO

CREATE PROCEDURE [dbo].UpdateActionItemDefinitionAutoReApprovalConfiguration
(
    @SiteId BIGINT,
    @NameChange BIT,
    @CategoryChange BIT,
    @OperationalModeChange BIT,
    @PriorityChange BIT,
    @DescriptionChange BIT,
    @DocumentLinksChange BIT,
    @FunctionalLocationsChange BIT,
    @TargetDependenciesChange BIT,
    @ScheduleChange BIT,
    @RequiresResponseWhenTriggeredChange BIT,
	@AssignmentChange BIT,
	@ActionItemGenerationModeChange bit
)
AS
    UPDATE
        ActionItemDefinitionAutoReApprovalConfiguration
    SET
        NameChange = @NameChange,
        CategoryChange = @CategoryChange,
        OperationalModeChange = @OperationalModeChange,
        PriorityChange = @PriorityChange,
        DescriptionChange = @DescriptionChange,
        DocumentLinksChange = @DocumentLinksChange,
        FunctionalLocationsChange = @FunctionalLocationsChange,
        TargetDependenciesChange = @TargetDependenciesChange,
        ScheduleChange = @ScheduleChange,
        RequiresResponseWhenTriggeredChange = @RequiresResponseWhenTriggeredChange,
		AssignmentChange = @AssignmentChange,
		ActionItemGenerationModeChange = @ActionItemGenerationModeChange
    WHERE
        SiteId = @SiteId
GO

GRANT EXEC ON UpdateActionItemDefinitionAutoReApprovalConfiguration TO PUBLIC