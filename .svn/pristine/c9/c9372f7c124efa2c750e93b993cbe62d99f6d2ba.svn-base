-- SQL cmd doesn't always set QUOTED_IDENTIFIER ON and it needs to be one when we delete from the Target Definition table because of the view and indexes view.
SET QUOTED_IDENTIFIER ON 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[colt_admin].[FunctionalLocation_Backup]') AND type in (N'U'))
DROP TABLE [colt_admin].[FunctionalLocation_Backup]

/****** Object:  Table [colt_admin].[FunctionalLocation_Backup]    Script Date: 08/24/2010 14:01:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[colt_admin].[tag_backup2]') AND type in (N'U'))
DROP TABLE [colt_admin].[tag_backup2]

/****** Object:  Table [colt_admin].[FunctionalLocation_Backup]    Script Date: 08/24/2010 14:01:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[colt_admin].[contractor_backup]') AND type in (N'U'))
drop table dbo.contractor_backup

truncate table dbo.objectlock
truncate table dbo.eventsinks

-- Soft Delete all Target Definitions so schedulers aren't evaluating them, and target def grid doesn't show them.
update TargetDefinition 
  SET Deleted = 1;
  
-- set all Target Alerts to closed so they aren't displayed or queried.
update targetalert
  SET TargetAlertStatusID = 2;  
GO