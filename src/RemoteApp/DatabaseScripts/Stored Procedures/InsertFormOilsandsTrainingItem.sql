if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormOilsandsTrainingItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormOilsandsTrainingItem]
GO

CREATE Procedure [dbo].[InsertFormOilsandsTrainingItem]
(
	@Id bigint Output,
	
	@FormOilsandsTrainingId bigint,
	
	@TrainingBlockId bigint,
	
	@Comments varchar(1000) = NULL,
	@Supervisor varchar(100) = NULL,
	@BlockCompleted bit,
	@Hours decimal(8,2)
)
AS

INSERT INTO FormOilsandsTrainingItem
(
	FormOilsandsTrainingId,
	
	TrainingBlockId,
	
	Comments,
	Supervisor,
	BlockCompleted,
	Hours,
	Deleted
)
VALUES
(
	@FormOilsandsTrainingId,
	
	@TrainingBlockId,
	
	@Comments,
	@Supervisor,
	@BlockCompleted,
	@Hours,
	0
);


SET @Id = scope_identity();

GO

GRANT EXEC ON InsertFormOilsandsTrainingItem TO PUBLIC
GO
