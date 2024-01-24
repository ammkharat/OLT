if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormOilsandsTrainingHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormOilsandsTrainingHistory]
GO

CREATE Procedure [dbo].[InsertFormOilsandsTrainingHistory]
(
	@Id bigint,
	@FormStatusId int,
	
	@FunctionalLocations varchar(max),
	@Approvals varchar(max),
	@TrainingItems varchar(max),
	
	@TrainingDate date,
	@ShiftName varchar(50),
	@TotalHours decimal(8,2),
	@GeneralComments varchar(max),
	
	@ApprovedDateTime datetime = NULL,
	
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO FormOilsandsTrainingHistory
(
	Id,
	FormStatusId,
	
	FunctionalLocations,
	Approvals,
	TrainingItems,
	
	TrainingDate,
	ShiftName,
	TotalHours,
	GeneralComments,	
	
	ApprovedDateTime,
	
	LastModifiedByUserId,
	LastModifiedDateTime
)
VALUES
(
	@Id,
	@FormStatusId,
	
	@FunctionalLocations,
	@Approvals,
	@TrainingItems,
	
	@TrainingDate,
	@ShiftName,
	@TotalHours,
	@GeneralComments,
	
	@ApprovedDateTime,
	
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertFormOilsandsTrainingHistory TO PUBLIC
GO
