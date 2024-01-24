IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN59ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN59ByIdAndSiteId
	END
GO
CREATE Procedure [dbo].[QueryFormGN59ByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN59 f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON [QueryFormGN59ByIdAndSiteId] TO PUBLIC

go
