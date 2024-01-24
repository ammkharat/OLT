IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryCustomFieldGroupById')
	BEGIN
		DROP PROCEDURE [dbo].QueryCustomFieldGroupById
	END
GO

CREATE Procedure dbo.QueryCustomFieldGroupById
	(
		@Id bigint
	)
AS

SELECT 
	g.* 
FROM 
	CustomFieldGroup g
WHERE
    g.Id = @Id
GO

GRANT EXEC ON [QueryCustomFieldGroupById] TO PUBLIC
GO