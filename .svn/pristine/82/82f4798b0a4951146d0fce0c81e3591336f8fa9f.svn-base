IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByPermitRequestLubesId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByPermitRequestLubesId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByPermitRequestLubesId
	(
		@PermitRequestLubesId bigint
	)

AS
SELECT * FROM DocumentLink WHERE PermitRequestLubesId = @PermitRequestLubesId
	and Deleted = 0
	and PermitRequestLubesId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByPermitRequestLubesId] TO PUBLIC
GO