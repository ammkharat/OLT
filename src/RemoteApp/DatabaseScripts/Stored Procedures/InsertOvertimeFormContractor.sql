if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOvertimeFormContractor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertOvertimeFormContractor]
GO

CREATE Procedure [dbo].[InsertOvertimeFormContractor]
(
	@Id bigint Output,

	@OvertimeFormId bigint,
	@PersonnelName varchar(50),
	@PrimaryLocation varchar(50),
	@StartDateTime datetime,
	@EndDateTime datetime,
	@IsDayShift bit,
	@IsNightShift bit,
	@PhoneNumber varchar(30) = NULL,
	@Radio varchar(15) = NULL,
	@Description varchar(100),
	@Company varchar(50),
	@WorkOrderNumber varchar(25) = NULL,
	@ExpectedHours decimal(8, 2)
)
AS

INSERT INTO OvertimeFormContractor
(
	OvertimeFormId,
	PersonnelName,
	PrimaryLocation,
	StartDateTime,
	EndDateTime,
	IsDayShift,
	IsNightShift,
	PhoneNumber,
	Radio,
	Description,
	Company,
	WorkOrderNumber,
	ExpectedHours,
	Deleted
)
VALUES
(
	@OvertimeFormId,
	@PersonnelName,
	@PrimaryLocation,
	@StartDateTime,
	@EndDateTime,
	@IsDayShift,
	@IsNightShift,
	@PhoneNumber,
	@Radio,
	@Description,
	@Company,
	@WorkOrderNumber,
	@ExpectedHours,
	0
);

SET @Id = scope_identity();

GO

GRANT EXEC ON InsertOvertimeFormContractor TO PUBLIC
GO
