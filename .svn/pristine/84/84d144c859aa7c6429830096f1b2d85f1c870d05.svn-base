IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitMontrealGroup')
	BEGIN
		DROP  Procedure  RemoveWorkPermitMontrealGroup
	END

GO

CREATE Procedure [dbo].RemoveWorkPermitMontrealGroup(@id bigint)
AS

UPDATE 	WorkPermitMontrealGroup SET Deleted = 1	WHERE Id = @Id
GO

GRANT EXEC ON RemoveWorkPermitMontrealGroup TO PUBLIC

GO