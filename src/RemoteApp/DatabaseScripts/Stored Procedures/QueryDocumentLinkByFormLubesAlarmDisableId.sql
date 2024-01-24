IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkByFormLubesAlarmDisableId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkByFormLubesAlarmDisableId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkByFormLubesAlarmDisableId(@FormLubesAlarmDisableId bigint)
AS
SELECT * FROM DocumentLink WHERE FormLubesAlarmDisableId = @FormLubesAlarmDisableId	and Deleted = 0	
and FormLubesAlarmDisableId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkByFormLubesAlarmDisableId] TO PUBLIC
GO
