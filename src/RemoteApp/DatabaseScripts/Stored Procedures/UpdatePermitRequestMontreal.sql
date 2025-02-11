if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePermitRequestMontreal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdatePermitRequestMontreal]
GO

CREATE Procedure [dbo].[UpdatePermitRequestMontreal]
    (
    @Id bigint,
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
	@LastImportedByUserId bigint = NULL,
	@LastImportedDateTime datetime = NULL,	
	@LastSubmittedByUserId bigint = NULL,
	@LastSubmittedDateTime datetime = NULL,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@IsModified bit,
	@CompletionStatusId bigint
    )
AS

UPDATE PermitRequestMontreal
SET
	WorkPermitTypeId = @WorkPermitTypeId,
    StartDate = @StartDate,
	EndDate = @EndDate,
	RequestedByGroupId = @RequestedByGroupId,
	WorkOrderNumber = @WorkOrderNumber,
	OperationNumber = @OperationNumber,
	SubOperationNumber = @SubOperationNumber,
	Trade = @Trade,
	Description = @Description,
	SapDescription = @SapDescription,
	Company = @Company,
	Supervisor = @Supervisor,
	ExcavationNumber = @ExcavationNumber,
	LastImportedByUserId = @LastImportedByUserId,
	LastImportedDateTime = @LastImportedDateTime,
	LastSubmittedByUserId = @LastSubmittedByUserId,
	LastSubmittedDateTime = @LastSubmittedDateTime,
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime,
	IsModified = @IsModified,
	CompletionStatusId = @CompletionStatusId
WHERE Id = @Id

GO


GRANT EXEC ON [UpdatePermitRequestMontreal] TO PUBLIC
GO
