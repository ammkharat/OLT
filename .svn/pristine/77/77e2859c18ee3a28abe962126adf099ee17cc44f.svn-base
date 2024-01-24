if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN1History]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN1History]
GO

CREATE Procedure [dbo].[InsertFormGN1History]
(
	@Id bigint,
	@FormStatusId int,	
	@FunctionalLocation varchar(max),
	@Location varchar(128),	
	@CSELevel varchar(5),	
	@JobDescription varchar(256),	
	@FromDateTime datetime,
	@ToDateTime datetime,	
	@PlanningWorksheetPlainTextContent nvarchar(max) = NULL,	
	@RescuePlanPlainTextContent nvarchar(max) = NULL,	
	@TradeChecklists varchar(max) = NULL,	
	@PlanningWorksheetApprovals varchar(max) = NULL,	
	@RescuePlanApprovals varchar(max) = NULL,
	@TradeChecklistApprovals varchar(max) = NULL,	
	@DocumentLinks varchar(max) = NULL,	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,	
	@ApprovedDateTime datetime = NULL,
	@ClosedDateTime datetime = NULL		
)
AS

INSERT INTO FormGN1History
(
	Id,
	FormStatusId,	
	FunctionalLocation,
	Location,	
	CSELevel,	
	JobDescription,	
	FromDateTime,
	ToDateTime,	
	PlanningWorksheetPlainTextContent,	
	RescuePlanPlainTextContent,	
	TradeChecklists,
	PlanningWorksheetApprovals,
	RescuePlanApprovals,
	TradeChecklistApprovals,
	DocumentLinks,	
	LastModifiedByUserId,
	LastModifiedDateTime,	
	ApprovedDateTime,
	ClosedDateTime
)
VALUES
(
	@Id,
	@FormStatusId,	
	@FunctionalLocation,
	@Location,	
	@CSELevel,	
	@JobDescription,	
	@FromDateTime,
	@ToDateTime,	
	@PlanningWorksheetPlainTextContent,	
	@RescuePlanPlainTextContent,		
	@TradeChecklists,	
	@PlanningWorksheetApprovals,
	@RescuePlanApprovals,
	@TradeChecklistApprovals,	
	@DocumentLinks,	
	@LastModifiedByUserId,
	@LastModifiedDateTime,	
	@ApprovedDateTime,
	@ClosedDateTime
);

GO

GRANT EXEC ON InsertFormGN1History TO PUBLIC
GO
