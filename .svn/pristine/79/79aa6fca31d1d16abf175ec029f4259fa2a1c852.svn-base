IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveSchedule')
	BEGIN
		DROP  Procedure  RemoveSchedule
	END

GO

CREATE Procedure [dbo].RemoveSchedule
	(
		@Id bigint
	)
AS

UPDATE [Schedule] SET Deleted = 1 WHERE Id=@Id
GO


GRANT EXEC ON RemoveSchedule TO PUBLIC

GO

