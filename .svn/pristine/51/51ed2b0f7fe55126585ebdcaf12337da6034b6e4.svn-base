IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormGN24ByIdAndSiteId')
	BEGIN
		DROP PROCEDURE [dbo].QueryFormGN24ByIdAndSiteId
	END
GO

CREATE Procedure [dbo].[QueryFormGN24ByIdAndSiteId]
(
	@Id bigint,
	@siteid bigint
)
AS
select form.*
from FormGN24 form
where form.Id = @Id and siteid = @siteid

go
