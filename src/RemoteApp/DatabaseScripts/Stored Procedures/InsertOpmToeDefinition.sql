if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOpmToeDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOpmToeDefinition]
GO

CREATE Procedure [dbo].[InsertOpmToeDefinition]
    (
			@Id bigint Output,
			@ToeVersion bigint,    
			@HistorianTag nvarchar(255),
			@ToeVersionPublishDate datetime,
			@ToeName nvarchar(255),
			@FunctionalLocation nvarchar(255),
			@FunctionalLocationId bigint,
			@ToeType int,
			@LimitValue nvarchar(2000), 
			@CausesDescription nvarchar(2000), 
			@ConsequencesDescription nvarchar(2000), 
			@CorrectiveActionDescription nvarchar(2000), 
			@ReferenceDocuments nvarchar(400), 
			@UnitOfMeasure nvarchar(15),
			@OpmToeHistoryUrl nvarchar(400)
    )
AS

INSERT INTO OpmToeDefinition
(
	ToeVersion,
	HistorianTag,
	ToeVersionPublishDate,
	ToeName,
	FunctionalLocation,    
	FunctionalLocationId,
	ToeType,
	LimitValue,
	CausesDescription,
	ConsequencesDescription,
	CorrectiveActionDescription,
	ReferenceDocuments,
	UnitOfMeasure,
	OpmToeHistoryUrl
	
)
VALUES
(	
	@ToeVersion,
	@HistorianTag,
	@ToeVersionPublishDate,
	@ToeName,
	@FunctionalLocation,    
	@FunctionalLocationId,
	@ToeType,
	@LimitValue,
	@CausesDescription,
	@ConsequencesDescription,
	@CorrectiveActionDescription,
	@ReferenceDocuments,
	@UnitOfMeasure,
	@OpmToeHistoryUrl
)
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertOpmToeDefinition] TO PUBLIC
GO
