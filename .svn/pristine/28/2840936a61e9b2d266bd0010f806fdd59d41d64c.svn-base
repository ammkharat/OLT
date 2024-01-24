IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDocumentLinkBySummaryLogId')
	BEGIN
		DROP PROCEDURE [dbo].QueryDocumentLinkBySummaryLogId
	END
GO

CREATE Procedure [dbo].QueryDocumentLinkBySummaryLogId
	(
		@SummaryLogId BIGINT
	)

AS
SELECT  
	*
FROM
	[DocumentLink] 
WHERE
	SummaryLogId = @SummaryLogId 
	and Deleted = 0 
	and SummaryLogId IS NOT NULL -- this is here to force the use of a Filtered index on the table
GO

GRANT EXEC ON [QueryDocumentLinkBySummaryLogId] TO PUBLIC
GO