IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN6ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN6ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN6ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN6 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN6ByIdAndSiteId] TO PUBLIC

go
