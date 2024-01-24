IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN1ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN1ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN1ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN1 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN1ByIdAndSiteId] TO PUBLIC

go
