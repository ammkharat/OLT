IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDoesPermitRequestLubesAssociationExist')
	BEGIN
		DROP  Procedure  QueryDoesPermitRequestLubesAssociationExist
	END

GO

CREATE Procedure [dbo].QueryDoesPermitRequestLubesAssociationExist
	(
		@WorkPermitStartDateTime datetime,
		@WorkPermitEndDateTime datetime,
		@PermitRequestIds VARCHAR(MAX)
	)
AS

SELECT
	COUNT(wp.Id) as COUNT
FROM 
	WorkPermitLubes wp
	INNER JOIN IDSplitter(@PermitRequestIds) ids ON ids.Id = wp.PermitRequestId
WHERE
	wp.StartDateTime BETWEEN @WorkPermitStartDateTime and @WorkPermitEndDateTime
GO

GRANT EXEC ON QueryDoesPermitRequestLubesAssociationExist TO PUBLIC
GO