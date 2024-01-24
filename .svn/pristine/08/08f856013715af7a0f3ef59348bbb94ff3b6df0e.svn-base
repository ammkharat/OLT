IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN75BByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN75BByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN75BByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN75B f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN75BByIdAndSiteId] TO PUBLIC


go
