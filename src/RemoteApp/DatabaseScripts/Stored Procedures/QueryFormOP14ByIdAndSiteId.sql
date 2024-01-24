IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOP14ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormOP14ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormOP14ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormOP14 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormOP14ByIdAndSiteId] TO PUBLIC

go
