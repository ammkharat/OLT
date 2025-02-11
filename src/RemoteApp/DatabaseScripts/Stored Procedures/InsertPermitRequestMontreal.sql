if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestMontreal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertPermitRequestMontreal]
GO

CREATE Procedure [dbo].[InsertPermitRequestMontreal]
    (
    @Id bigint Output,
	@WorkPermitTypeId int,
    @StartDate datetime,
	@EndDate datetime,
	@RequestedByGroupId bigint = NULL,
	@WorkOrderNumber varchar(12) = NULL,
	@OperationNumber varchar(4) = NULL,
	@SubOperationNumber varchar(4) = NULL,
	@Trade varchar(100),
	@Description varchar(400),
	@SapDescription varchar(400) = NULL,
	@Company varchar(50) = NULL,
	@Supervisor varchar(100) = NULL,
	@ExcavationNumber varchar(50) = NULL,
	@SourceId int = NULL,
	@LastImportedByUserId bigint = NULL,
	@LastImportedDateTime datetime = NULL,	
	@LastSubmittedByUserId bigint = NULL,
	@LastSubmittedDateTime datetime = NULL,
	@CreatedByUserId bigint,
	@CreatedDateTime datetime,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@IsModified bit,
	@CompletionStatusId bigint
    )
AS

INSERT INTO PermitRequestMontreal
(
	WorkPermitTypeId,
    StartDate,
	EndDate,
	RequestedByGroupId,
	WorkOrderNumber,
	OperationNumber,
	SubOperationNumber,
	Trade,
	Description,
	SapDescription,
	Company,
	Supervisor,
	ExcavationNumber,
	SourceId,
	LastImportedByUserId,
	LastImportedDateTime,	
	LastSubmittedByUserId,
	LastSubmittedDateTime,
	CreatedByUserId,
	CreatedDateTime,
	LastModifiedByUserId,
	LastModifiedDateTime,
	IsModified,
	CompletionStatusId,
	Deleted
)
VALUES
(	
	@WorkPermitTypeId,
    @StartDate,
	@EndDate,
	@RequestedByGroupId,
	@WorkOrderNumber,
	@OperationNumber,
	@SubOperationNumber,
	@Trade,
	@Description,
	@SapDescription,
	@Company,
	@Supervisor,
	@ExcavationNumber,
	@SourceId,
	@LastImportedByUserId,
	@LastImportedDateTime,	
	@LastSubmittedByUserId,
	@LastSubmittedDateTime,
	@CreatedByUserId,
	@CreatedDateTime,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@IsModified,
	@CompletionStatusId,
	0
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertPermitRequestMontreal] TO PUBLIC
GO
