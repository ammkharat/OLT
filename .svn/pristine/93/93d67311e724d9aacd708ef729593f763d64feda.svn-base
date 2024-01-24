if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormOilsandsTraining]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormOilsandsTraining]
GO

CREATE Procedure [dbo].[UpdateFormOilsandsTraining]
(
	@Id bigint,	
	@FormStatusId int,	
	@ApprovedDateTime datetime = NULL,	
	@TrainingDate date,
	@ShiftId bigint, 
	@TotalHours decimal(8,2),
	@GeneralComments varchar(max),
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime,
	@siteid bigint
)
AS

UPDATE FormOilsandsTraining
	SET 
		FormStatusId = @FormStatusId,		
		ApprovedDateTime = @ApprovedDateTime,		
		TrainingDate = @TrainingDate,
		ShiftId = @ShiftId,
		TotalHours = @TotalHours,
		GeneralComments = @GeneralComments,
		LastModifiedDateTime = @LastModifiedDateTime,
		LastModifiedByUserId = @LastModifiedByUserId
	WHERE
		Id = @Id and siteid = @siteid

GO

GRANT EXEC ON UpdateFormOilsandsTraining TO PUBLIC
GO