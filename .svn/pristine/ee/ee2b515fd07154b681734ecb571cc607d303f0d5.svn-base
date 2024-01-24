 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTargetDefinitionState')
	BEGIN
		DROP  Procedure  UpdateTargetDefinitionState
	END

GO

CREATE Procedure [dbo].UpdateTargetDefinitionState

	(
	     
		@TargetDefinitionId bigint,
		@ExceedingBoundaries bit, 
		@LastSuccessfulTagAccess datetime
	)
AS

UPDATE TargetDefinitionState
SET	
	[ExceedingBoundaries]=@ExceedingBoundaries, 
	[LastSuccessfulTagAccess]  = @LastSuccessfulTagAccess 
WHERE TargetDefinitionId = @TargetDefinitionId
GO
