if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOvertimeFormContractor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateOvertimeFormContractor]
GO

CREATE Procedure [dbo].[UpdateOvertimeFormContractor]
(
	@Id bigint,
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

UPDATE OvertimeFormContractor
SET
	PersonnelName = @PersonnelName,
	PrimaryLocation = @PrimaryLocation,
	StartDateTime = @StartDateTime,
	EndDateTime = @EndDateTime,
	IsDayShift = @IsDayShift,
	IsNightShift = @IsNightShift,
	PhoneNumber = @PhoneNumber,
	Radio = @Radio,
	Description = @Description,
	Company = @Company,
	WorkOrderNumber = @WorkOrderNumber,
	ExpectedHours = @ExpectedHours
WHERE
	Id = @Id
GO

GRANT EXEC ON UpdateOvertimeFormContractor TO PUBLIC
GO