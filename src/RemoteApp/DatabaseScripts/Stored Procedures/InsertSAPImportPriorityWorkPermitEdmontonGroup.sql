IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertSAPImportPriorityWorkPermitEdmontonGroup')
	BEGIN
		DROP  Procedure  InsertSAPImportPriorityWorkPermitEdmontonGroup
	END

GO

CREATE Procedure [dbo].[InsertSAPImportPriorityWorkPermitEdmontonGroup]
	(
	@SAPImportPriority int,
	@WorkPermitEdmontonGroupId bigint	
	)
AS

INSERT INTO 
	[SAPImportPriorityWorkPermitEdmontonGroup]
	(
	  [SAPImportPriority],
	  [WorkPermitEdmontonGroupId]
	)
VALUES
	(
	  @SAPImportPriority,
	  @WorkPermitEdmontonGroupId	
	)
	

GRANT EXEC ON [InsertSAPImportPriorityWorkPermitEdmontonGroup] TO PUBLIC
GO