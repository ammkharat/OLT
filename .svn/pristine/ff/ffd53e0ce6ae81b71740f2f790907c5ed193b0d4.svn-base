IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDoesPermitRequestEdmontonAssociationExist')
	BEGIN
		DROP  Procedure  QueryDoesPermitRequestEdmontonAssociationExist
	END

GO

CREATE Procedure [dbo].QueryDoesPermitRequestEdmontonAssociationExist
	(
		@WorkPermitStartDateTime datetime,
		@WorkPermitEndDateTime datetime,
		@PermitRequestIds VARCHAR(MAX)
	)
AS

SELECT 
	COUNT(wp.Id) as COUNT
FROM 
	[dbo].[WorkPermitEdmonton] wp
	INNER JOIN IDSplitter(@PermitRequestIds) ids ON ids.Id = wp.PermitRequestId
WHERE 
	wp.RequestedStartDateTime BETWEEN @WorkPermitStartDateTime and @WorkPermitEndDateTime
GO

GRANT EXEC ON QueryDoesPermitRequestEdmontonAssociationExist TO PUBLIC
GO