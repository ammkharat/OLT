IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN7ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN7ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN7ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN7 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN7ByIdAndSiteId] TO PUBLIC

go
