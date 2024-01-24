alter table PermitRequestLubesSAPImportData drop constraint FK_PermitRequestLubesSAPImportData_SubmittedByUserId;
GO

alter table PermitRequestLubesSAPImportData drop constraint FK_PermitRequestLubesSAPImportData_FunctionalLocationId
GO

alter table PermitRequestLubesSAPImportData drop constraint FK_PermitRequestLubesSAPImportData_WorkPermitLubesGroup
GO

drop table PermitRequestLubesSAPImportData
GO


CREATE TABLE [dbo].[WorkOrderImportData](

	BatchId bigint NOT NULL,
	BatchItemCreatedDateTime datetime NOT NULL,
	SubmittedByUserId bigint NOT NULL,
	
	WONumber varchar(100),
	ShortText varchar(500),
	FunctionalLocation varchar(100),
	EquipmentNumber varchar(50),
	PlantId varchar(25),
	LanguageCode varchar(10),
	Priority varchar(10),
	PlannerGroup varchar(50),	
	OperationKeyNo varchar(50),
	OperationNumber varchar(10),
	Suboperation varchar(50),
	EarliestStartDate varchar(50),
	EarliestStartTime varchar(50),
	EarliestFinishDate varchar(50),
	EarliestFinishTime varchar(50),
	LongText varchar(max),
	WorkPermitType varchar(50),
	WorkPermitAttrib varchar(50),
	WorkCenterID varchar(50),
	WorkCenterName varchar(50),
	WorkCenterText varchar(50)	 
) ON [PRIMARY]	
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestLubesSAPImportData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertPermitRequestLubesSAPImportData]
GO





GO

