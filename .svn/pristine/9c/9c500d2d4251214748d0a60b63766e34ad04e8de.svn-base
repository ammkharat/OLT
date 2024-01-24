IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGn75AByGn75BId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGn75AByGn75BId
	END
GO

CREATE Procedure dbo.QueryFormGn75AByGn75BId
	(
	@FormGN75BId bigint
	)
AS

SELECT 
	Id 
FROM
	FormGN75A
WHERE
  AssociatedFormGN75BId = @FormGN75BId
GO

GRANT EXEC ON QueryFormGn75AByGn75BId TO PUBLIC
GO