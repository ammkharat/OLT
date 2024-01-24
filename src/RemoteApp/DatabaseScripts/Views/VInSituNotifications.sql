IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VInSituNotifications')
BEGIN
	DROP VIEW VInSituNotifications
END
GO

CREATE VIEW [dbo].[VInSituNotifications] WITH SCHEMABINDING
AS

select 
	s.id,
	s.CreationDateTime, 
	f.FullHierarchy, 
	s.NotificationNumber, 
	s.NotificationType, 
	s.IncidentID, 
	s.ShortText, 
	REPLACE(s.LongText,'*','') as LongText, 
	f.SiteId
from 
	[dbo].SAPNotification s
	INNER JOIN [dbo].functionallocation f ON functionallocationid = f.id 
where 
	(f.siteid = 5 or f.siteid = 7) AND s.IncidentID <> '' 
GO