if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN1]
GO

CREATE Procedure [dbo].[InsertFormGN1]
(
	@Id bigint Output,	
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
	@CreatedDateTime datetime,
	@CreatedByUserId bigint,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint
)
AS

DECLARE @NewFormId bigint
BEGIN
	EXEC @NewFormId = GetNewSeqVal_FormIdSequence
END

INSERT INTO FormGN1
(
	Id,
	FormStatusId,
	FunctionalLocationId,
	TradeChecklistNames,
	Location,
	CSELevel,
	JobDescription,
	FromDateTime,
	ToDateTime,
	PlanningWorksheetContent,
	PlanningWorksheetPlainTextContent,
	RescuePlanContent,
	RescuePlanPlainTextContent,
	ApprovedDateTime,
	ClosedDateTime,
	CreatedDateTime,
	CreatedByUserId,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted

)
VALUES
(	
	@NewFormId,
	@FormStatusId,
	@FunctionalLocationId,
	@TradeChecklistNames,
	@Location,
	@CSELevel,
	@JobDescription,
	@FromDateTime,
	@ToDateTime,	
	@PlanningWorksheetContent,
	@PlanningWorksheetPlainTextContent,
	@RescuePlanContent,
	@RescuePlanPlainTextContent,
	@ApprovedDateTime,
	@ClosedDateTime,
	@CreatedDateTime,
	@CreatedByUserId,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0
	
);

SET @Id=@NewFormId; 

GO

GRANT EXEC ON InsertFormGN1 TO PUBLIC
GO
