IF EXISTS ( SELECT * FROM sysobjects WHERE type = 'P' AND Name = 'UpdateTargetDefinitionAutoReApprovalConfiguration')
BEGIN
    DROP PROCEDURE UpdateTargetDefinitionAutoReApprovalConfiguration
END
GO

CREATE PROCEDURE [dbo].UpdateTargetDefinitionAutoReApprovalConfiguration
(
    @SiteId BIGINT,
    @NameChange BIT,
    @CategoryChange BIT,
    @OperationalModeChange BIT,
    @PriorityChange BIT,
    @DescriptionChange BIT,
    @DocumentLinksChange BIT,
    @FunctionalLocationChange BIT,
    @PHTagChange BIT,
    @TargetDependenciesChange BIT,
    @ScheduleChange BIT,
    @GenerateActionItemChange BIT,
    @RequiresResponseWhenAlertedChange BIT,
    @SuppressAlertChange BIT
)
AS
    UPDATE
        TargetDefinitionAutoReApprovalConfiguration
    SET
        NameChange = @NameChange,
        CategoryChange = @CategoryChange,
        OperationalModeChange = @OperationalModeChange,
        PriorityChange = @PriorityChange,
        DescriptionChange = @DescriptionChange,
        DocumentLinksChange = @DocumentLinksChange,
        FunctionalLocationChange = @FunctionalLocationChange,
        PHTagChange = @PHTagChange,
        TargetDependenciesChange = @TargetDependenciesChange,
        ScheduleChange = @ScheduleChange,
        GenerateActionItemChange = @GenerateActionItemChange,
        RequiresResponseWhenAlertedChange = @RequiresResponseWhenAlertedChange,
        SuppressAlertChange = @SuppressAlertChange
    WHERE
        SiteId = @SiteId
GO
