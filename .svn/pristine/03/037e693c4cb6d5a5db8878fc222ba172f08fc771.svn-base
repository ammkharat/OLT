ALTER TABLE WorkAssignment ADD CopyTargetAlertResponseToLog bit NULL;
GO

update WorkAssignment set CopyTargetAlertResponseToLog = 1 where SiteId <> 3;
update WorkAssignment set CopyTargetAlertResponseToLog = 0 where SiteId = 3;
GO

ALTER TABLE WorkAssignment ALTER COLUMN CopyTargetAlertResponseToLog bit NOT NULL;
GO





GO

