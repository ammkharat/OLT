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

update TargetDefinitionReadWriteTagConfiguration
set MaxDirectionId = 0,
MaxTagId = null
where MaxDirectionId = 2;

update TargetDefinitionReadWriteTagConfiguration
set MinDirectionId = 0,
MinTagId = null
where MinDirectionId = 2;

update TargetDefinitionReadWriteTagConfiguration
set TargetDirectionId = 0,
TargetTagId = null
where TargetDirectionId = 2;

update TargetDefinitionReadWriteTagConfiguration
set GapUnitValueDirectionId = 0,
GapUnitValueTagId = null
where GapUnitValueDirectionId = 2;
GO

update CustomField set PHDLinkTypeId = 1 where PHDLinkTypeId = 2
GO