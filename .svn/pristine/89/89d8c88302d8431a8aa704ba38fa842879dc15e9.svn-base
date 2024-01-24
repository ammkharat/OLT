if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormOilsandsTrainingItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormOilsandsTrainingItem]
GO

CREATE Procedure [dbo].[UpdateFormOilsandsTrainingItem]
(
	@Id bigint,
	
	@TrainingBlockId bigint,
	
	@Comments varchar(1000) = NULL,
	@Supervisor varchar(100) = NULL,
	@BlockCompleted bit,
	@Hours decimal(8,2)
)
AS

UPDATE FormOilsandsTrainingItem
SET 
	TrainingBlockId = @TrainingBlockId,
	
	Comments = @Comments,
	Supervisor = @Supervisor,
	BlockCompleted = @BlockCompleted,	
	Hours = @Hours
WHERE
	Id = @Id
GO

GRANT EXEC ON UpdateFormOilsandsTrainingItem TO PUBLIC
GO