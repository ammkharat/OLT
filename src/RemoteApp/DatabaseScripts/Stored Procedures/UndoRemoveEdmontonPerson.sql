IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UndoRemoveEdmontonPerson')
	BEGIN
		DROP  Procedure UndoRemoveEdmontonPerson
	END

GO

CREATE Procedure [dbo].UndoRemoveEdmontonPerson
	(
		@Id bigint
	)
AS

UPDATE
	[EdmontonPerson] 
SET 
	[Deleted] = 0
WHERE 
	Id=@Id
GO