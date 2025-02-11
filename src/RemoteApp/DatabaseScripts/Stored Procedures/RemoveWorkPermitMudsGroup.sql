
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveWorkPermitMudsGroup')
	BEGIN
		DROP Procedure [dbo].RemoveWorkPermitMudsGroup
	END
GO

CREATE Procedure [dbo].[RemoveWorkPermitMudsGroup](@id bigint)
AS

UPDATE 	WorkPermitMudsGroup SET Deleted = 1	WHERE Id = @Id
GO

GRANT EXEC ON RemoveWorkPermitMudsGroup TO PUBLIC
GO
