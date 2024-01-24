if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDeviationAlertResponseReasonCodeAssignment]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[InsertDeviationAlertResponseReasonCodeAssignment]
GO

CREATE PROCEDURE [dbo].[InsertDeviationAlertResponseReasonCodeAssignment]
(
    @Id bigint Output,  
	@RestrictionLocationItemId bigint = NULL,
	@ReasonCodeFunctionalLocationId bigint,
	@RestrictionReasonCodeId bigint,
	@PlantState VARCHAR(50),
	@AssignedAmount decimal(9,2),	
	@Comments varchar(max),
    @LastModifiedUserId bigint,
    @LastModifiedDateTime DATETIME,
    @CreatedDateTime DATETIME,
	@DeviationAlertResponseId bigint
)
AS

INSERT INTO [dbo].[DeviationAlertResponseReasonCodeAssignment]
(
	[RestrictionLocationItemId],
    [ReasonCodeFunctionalLocationId],
    [RestrictionReasonCodeId],
	[PlantState],
	[AssignedAmount],
	[Comments],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [CreatedDateTime],
	[DeviationAlertResponseId]
)
VALUES
(
	@RestrictionLocationItemId,
	@ReasonCodeFunctionalLocationId,
    @RestrictionReasonCodeId,
	@PlantState,
	@AssignedAmount,
	@Comments,
    @LastModifiedUserId,
    @LastModifiedDateTime,
    @CreatedDateTime,
	@DeviationAlertResponseId
)

SET @Id= SCOPE_IDENTITY()
GO