if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestMontrealHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertPermitRequestMontrealHistory]
GO

CREATE Procedure [dbo].[InsertPermitRequestMontrealHistory]
    (
    @Id bigint,
	@WorkPermitTypeId int,
    @FunctionalLocations varchar(max),
    @StartDate datetime,
	@EndDate datetime,
	@WorkOrderNumber varchar(12) = NULL,
	@OperationNumber varchar(4) = NULL,
	@Trade varchar(100) = NULL,
	@Description varchar(400),
	@SapDescription varchar(400) = NULL,
	@Company varchar(50) = NULL,
	@Supervisor varchar(100) = NULL,
	@ExcavationNumber varchar(50) = NULL,
	@Attributes varchar(max) = NULL,
	@LastImportedByUserId bigint = NULL,
	@LastImportedDateTime datetime = NULL,	
	@LastSubmittedByUserId bigint = NULL,
	@LastSubmittedDateTime datetime = NULL,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@DocumentLinks varchar(max) = NULL,
	@RequestedByGroup varchar(100) = NULL,
	@CompletionStatusId bigint,
	@SourceId int
    )
AS

INSERT INTO PermitRequestMontrealHistory
(
	Id,
	WorkPermitTypeId,
	FunctionalLocations,
    StartDate,
	EndDate,
	WorkOrderNumber,
	OperationNumber,
	Trade,
	Description,
	SapDescription,
	Company,
	Supervisor,
	ExcavationNumber,
	Attributes,
	LastImportedByUserId,
	LastImportedDateTime,	
	LastSubmittedByUserId,
	LastSubmittedDateTime,
	LastModifiedByUserId,
	LastModifiedDateTime,
	DocumentLinks,
	RequestedByGroup,
	CompletionStatusId,
	SourceId
)
VALUES
(	
	@Id,
	@WorkPermitTypeId,
	@FunctionalLocations,
    @StartDate,
	@EndDate,
	@WorkOrderNumber,
	@OperationNumber,
	@Trade,
	@Description,
	@SapDescription,
	@Company,
	@Supervisor,
	@ExcavationNumber,
	@Attributes,
	@LastImportedByUserId,
	@LastImportedDateTime,	
	@LastSubmittedByUserId,
	@LastSubmittedDateTime,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	@DocumentLinks,
	@RequestedByGroup,
	@CompletionStatusId,
	@SourceId
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertPermitRequestMontrealHistory] TO PUBLIC
GO
