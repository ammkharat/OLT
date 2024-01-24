IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormTemplate')
	BEGIN
		DROP  Procedure  RemoveFormTemplate
	END
GO

CREATE Procedure [dbo].RemoveFormTemplate
	(
		@Id bigint
	)
AS

UPDATE FormTemplate
SET 
	Deleted = 1
WHERE Id = @Id
GO


GRANT EXEC ON RemoveFormTemplate TO PUBLIC

GO