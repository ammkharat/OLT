if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOpmExcursion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOpmExcursion]
GO

CREATE Procedure [dbo].[UpdateOpmExcursion]
    (
    @Id bigint,
	@Status int,
	@EndDateTime datetime = null,
	@Peak decimal(18,6),
	@Average decimal(18,6),
	@Duration int,
	@IlpNumber bigint = null,
	@EngineerComments nvarchar(4000) = null,
	@ReasonCode nvarchar(255) = null,
	@OpmTrendUrl nvarchar(400),
	@LastUpdatedDateTime datetime
    )
AS

update OpmExcursion
set 
	Status = @Status,
	EndDateTime = @EndDateTime,
	Peak = @Peak,
	Average = @Average,
	Duration = @Duration,
	IlpNumber = @IlpNumber,
	EngineerComments = @EngineerComments,
	ReasonCode = @ReasonCode,
	OpmTrendUrl = @OpmTrendUrl,
	LastUpdatedDateTime = @LastUpdatedDateTime
where Id = @Id
go

GRANT EXEC ON [UpdateOpmExcursion] TO PUBLIC
GO
