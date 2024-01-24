if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN1]
GO

CREATE Procedure [dbo].[UpdateFormGN1]
(
	@Id bigint,	
	@FormStatusId int,
	@FunctionalLocationId bigint,
	@TradeChecklistNames VARCHAR(MAX) = NULL,
	@Location varchar(128),
	@CSELevel varchar(5),
	@JobDescription varchar(256),
	@FromDateTime datetime,
	@ToDateTime datetime,
	@PlanningWorksheetContent nvarchar(max) = NULL,
	@PlanningWorksheetPlainTextContent varchar(max) = NULL,	
	@RescuePlanContent nvarchar(max) = NULL,
	@RescuePlanPlainTextContent varchar(max) = NULL,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL,			
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime)
AS

UPDATE FormGN1
	SET 
		FormStatusId = @FormStatusId,
		FunctionalLocationId = @FunctionalLocationId,
		TradeChecklistNames = @TradeChecklistNames,
		Location = @Location,
		CSELevel = @CSELevel,
		JobDescription = @JobDescription,
		FromDateTime = @FromDateTime,
		ToDateTime = @ToDateTime,
		PlanningWorksheetContent = @PlanningWorksheetContent,
		PlanningWorksheetPlainTextContent = @PlanningWorksheetPlainTextContent,
		RescuePlanContent = @RescuePlanContent,
		RescuePlanPlainTextContent = @RescuePlanPlainTextContent,
		ApprovedDateTime = @ApprovedDateTime,
		ClosedDateTime = @ClosedDateTime,
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormGN1 TO PUBLIC
GO