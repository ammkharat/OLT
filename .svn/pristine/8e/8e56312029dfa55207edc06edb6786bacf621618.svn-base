IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveActionItemFunctionalLocation')
	BEGIN
		DROP  Procedure  RemoveActionItemFunctionalLocation
	END

GO

CREATE Procedure [dbo].RemoveActionItemFunctionalLocation
	(
		@ActionItemId bigint
	)
AS

DELETE FROM ActionItemFunctionalLocation WHERE ActionItemId = @ActionItemId
GO


GRANT EXEC ON RemoveActionItemFunctionalLocation TO PUBLIC

GO

 