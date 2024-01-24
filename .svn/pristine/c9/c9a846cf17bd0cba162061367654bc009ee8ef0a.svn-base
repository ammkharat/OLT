IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySAPNotificationDTOsByFLOCIDsAndDateRange')
	BEGIN
		DROP PROCEDURE [dbo].QuerySAPNotificationDTOsByFLOCIDsAndDateRange
	END
GO

CREATE Procedure [dbo].QuerySAPNotificationDTOsByFLOCIDsAndDateRange
	(
		@IDs varchar(MAX),
		@StartDateTime datetime,
		@EndDateTime datetime
	)
AS

SELECT
	SAPNotification.Id,
	FunctionalLocation.FullHierarchy,
	SAPNotification.Description,
	SAPNotification.NotificationType,
	SAPNotification.NotificationNumber, 
    SAPNotification.CreationDateTime,
    SAPNotification.Processed,
    SAPNotification.ShortText,
    SAPNotification.IncidentID
FROM
    SAPNotification
    INNER JOIN FunctionalLocation ON FunctionalLocation.Id = SAPNotification.FunctionalLocationId
WHERE
	SAPNotification.CreationDateTime >= @StartDateTime AND
	SAPNotification.CreationDateTime <= @EndDateTime AND
	EXISTS
	(
		-- Floc of notification matches one of the passed in flocs
		select ids.Id
		from IDSplitter(@IDs) ids
		where ids.Id = FunctionalLocation.Id
		
		UNION ALL
		
		-- Floc of notification is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ids.Id
		from FunctionalLocationAncestor a
		inner join IDSplitter(@IDs) ids on ids.Id = a.AncestorId
		where a.Id = FunctionalLocation.Id
	)
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC ON [QuerySAPNotificationDTOsByFLOCIDsAndDateRange] TO PUBLIC
GO