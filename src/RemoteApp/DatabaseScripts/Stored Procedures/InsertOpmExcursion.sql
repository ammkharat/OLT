if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOpmExcursion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOpmExcursion]
GO

CREATE Procedure [dbo].[InsertOpmExcursion]
    (
			@Id bigint Output,
			@OpmExcursionId bigint,
			@ToeVersion bigint,    
			@HistorianTag nvarchar(255),
			@FunctionalLocation nvarchar(255),
			@FunctionalLocationId bigint,
			@ToeName nvarchar(255),
			@ToeType int,
			@Status int,
			@StartDateTime datetime, 
			@EndDateTime datetime = NULL, 
			@UnitOfMeasure nvarchar(15),
			@Peak decimal(18,6),
			@Average decimal(18,6),
			@Duration int,
			@OpmTrendUrl nvarchar(400),
			@IlpNumber bigint= NULL,
			@EngineerComments nvarchar(4000)= NULL,
			@ReasonCode nvarchar(255)= NULL,
			@LastUpdatedDateTime datetime,
			@ToeLimitValue decimal(18,6)
    )
AS

INSERT INTO OpmExcursion
(
		OpmExcursionId,
		ToeVersion,  
		HistorianTag,
		FunctionalLocation,
		FunctionalLocationId,
		ToeName,
		ToeType,
		Status,
		StartDateTime,
		EndDateTime,
		UnitOfMeasure,
		Peak,
		Average,
		Duration,
		OpmTrendUrl,
		IlpNumber,
		EngineerComments,
		ReasonCode,
		LastUpdatedDateTime,
		ToeLimitValue
)
VALUES
(	
		@OpmExcursionId,
		@ToeVersion,    
		@HistorianTag,
		@FunctionalLocation,
		@FunctionalLocationId,
		@ToeName,
		@ToeType,
		@Status,
		@StartDateTime, 
		@EndDateTime, 
		@UnitOfMeasure,
		@Peak,
		@Average,
		@Duration,
		@OpmTrendUrl,
		@IlpNumber,
		@EngineerComments,
		@ReasonCode,
		@LastUpdatedDateTime,
		@ToeLimitValue
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertOpmExcursion] TO PUBLIC
GO
