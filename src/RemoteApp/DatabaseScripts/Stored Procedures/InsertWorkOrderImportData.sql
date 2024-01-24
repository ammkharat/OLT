if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkOrderImportData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertWorkOrderImportData]
GO

CREATE Procedure [dbo].[InsertWorkOrderImportData]
(	
	@BatchId bigint,
	@ImportDate datetime,
	@BatchItemCreatedDateTime datetime,
	@SubmittedByUserId bigint,
	@ProcessStatus varchar(50) = NULL,
	@WONumber varchar(100) = NULL,
	@ShortText varchar(500) = NULL,
	@FunctionalLocation varchar(100) = NULL,
	@EquipmentNumber varchar(50) = NULL,
	@PlantId varchar(25) = NULL,
	@LanguageCode varchar(10) = NULL,
	@Priority varchar(10) = NULL,
	@PlannerGroup varchar(50) = NULL,	
	@OperationKeyNo varchar(50) = NULL,
	@OperationNumber varchar(10) = NULL,
	@Suboperation varchar(50) = NULL,
	@EarliestStartDate varchar(50) = NULL,
	@EarliestStartTime varchar(50) = NULL,
	@EarliestFinishDate varchar(50) = NULL,
	@EarliestFinishTime varchar(50) = NULL,
	@LongText varchar(max) = NULL,
	@WorkPermitType varchar(50) = NULL,
	@WorkPermitAttrib varchar(500) = NULL,
	@WorkCenterID varchar(50) = NULL,
	@WorkCenterName varchar(50) = NULL,
	@WorkCenterText varchar(50)	 = NULL	
)
AS

INSERT INTO WorkOrderImportData
(
	BatchId,
	ImportDate,
	BatchItemCreatedDateTime,
	SubmittedByUserId,
	ProcessStatus,
	WONumber,
	ShortText,
	FunctionalLocation,
	EquipmentNumber,
	PlantId,
	LanguageCode,
	Priority,
	PlannerGroup,	
	OperationKeyNo,
	OperationNumber,
	Suboperation,
	EarliestStartDate,
	EarliestStartTime,
	EarliestFinishDate,
	EarliestFinishTime,
	LongText,
	WorkPermitType,
	WorkPermitAttrib,
	WorkCenterID,
	WorkCenterName,
	WorkCenterText 
)
VALUES
(
	@BatchId,
	@ImportDate,
	@BatchItemCreatedDateTime,
	@SubmittedByUserId,
	@ProcessStatus,
	@WONumber,
	@ShortText,
	@FunctionalLocation,
	@EquipmentNumber,
	@PlantId,
	@LanguageCode,
	@Priority,
	@PlannerGroup,	
	@OperationKeyNo,
	@OperationNumber,
	@Suboperation,
	@EarliestStartDate,
	@EarliestStartTime,
	@EarliestFinishDate,
	@EarliestFinishTime,
	@LongText,
	@WorkPermitType,
	@WorkPermitAttrib,
	@WorkCenterID,
	@WorkCenterName,
	@WorkCenterText 
);

