IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN75AByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN75AByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN75AByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN75A f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN75AByIdAndSiteId] TO PUBLIC

go
