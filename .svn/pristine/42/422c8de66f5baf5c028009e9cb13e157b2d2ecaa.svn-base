if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOpmToeDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOpmToeDefinition]
GO

CREATE Procedure [dbo].[UpdateOpmToeDefinition]
    (
			@Id bigint,
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

update OpmToeDefinition
set 
	ToeVersion = @ToeVersion,
	HistorianTag = @HistorianTag,
	ToeVersionPublishDate = @ToeVersionPublishDate,
	ToeName = @ToeName,
	FunctionalLocation = @FunctionalLocation,    
	FunctionalLocationId = @FunctionalLocationId,
	ToeType = @ToeType,
	LimitValue = @LimitValue,
	CausesDescription = @CausesDescription,
	ConsequencesDescription = @ConsequencesDescription,
	CorrectiveActionDescription = @CorrectiveActionDescription,
	ReferenceDocuments = @ReferenceDocuments,
	UnitOfMeasure = @UnitOfMeasure,
	OpmToeHistoryUrl = @OpmToeHistoryUrl
where Id = @Id
go

GRANT EXEC ON [UpdateOpmToeDefinition] TO PUBLIC
GO
