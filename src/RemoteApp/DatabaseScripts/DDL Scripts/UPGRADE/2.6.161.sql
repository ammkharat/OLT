set nocount on
declare @constname sysname,
	@colname sysname,
        @tablename sysname,
        @cmd varchar(1024)

declare curs_constraints cursor for
	SELECT const.[name] constraint_name, col.[name] column_name, t.[name] table_name
	FROM 
		sys.default_constraints const,
		sys.all_columns col,
		sys.all_objects t
	WHERE 
		[const].[name] LIKE 'DF__WorkP%'
		AND const.parent_object_id = t.OBJECT_ID
		AND col.OBJECT_ID = t.OBJECT_ID
		AND col.column_id = const.parent_column_id
	
open curs_constraints

fetch next from curs_constraints into @constname, @colname, @tablename
while (@@fetch_status = 0)
		begin
			select @cmd = 'sys.sp_rename ' + @constname + ', DF_' + @tablename + '_' + @colname
			exec(@cmd)
			fetch next from curs_constraints into @constname, @colname, @tablename
		end
		fetch next from curs_constraints into @constname, @colname, @tablename
close curs_constraints
deallocate curs_constraints
GO

IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'AdditionalRadiationApproval')
BEGIN
ALTER TABLE [dbo].[WorkPermit] 
	ADD AdditionalRadiationApproval bit NOT NULL CONSTRAINT DF_WorkPermit_AdditionalRadiationApproval DEFAULT(0) ,
	AdditionalOnlineLeakRepairForm bit NOT NULL CONSTRAINT DF_WorkPermit_AdditionalOnlineLeakRepairForm DEFAULT(0)


ALTER TABLE [dbo].[WorkPermitHistory] 
	ADD AdditionalRadiationApproval bit NOT NULL CONSTRAINT DF_WorkPermitHistory_AdditionalRadiationApproval DEFAULT(0) ,
	AdditionalOnlineLeakRepairForm bit NOT NULL CONSTRAINT DF_WorkPermitHistory_AdditionalOnlineLeakRepairForm DEFAULT(0)
END
GO

IF EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'WorkPermit' AND Column_name = 'AdditionalRescuePlan')
BEGIN

ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalRescuePlan]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalVehicleEntry]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalFreezePlugOrExpansionPlug]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalHazop]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalLeakSeal]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalTemporaryFacilityPlacementOrSiting]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalHazardousServiceTag]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalFireProtectionSystems]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalEnvironmental]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalSafeWorkProcedure]
ALTER TABLE [dbo].[WorkPermit] DROP CONSTRAINT [DF_WorkPermit_AdditionalRadiography]

ALTER TABLE [dbo].[WorkPermit] 
	DROP COLUMN AdditionalRescuePlan, AdditionalVehicleEntry, AdditionalFreezePlugOrExpansionPlug, AdditionalHazop,  AdditionalLeakSeal,
			AdditionalTemporaryFacilityPlacementOrSiting, AdditionalHazardousServiceTag, AdditionalFireProtectionSystems,
			AdditionalEnvironmental, AdditionalSafeWorkProcedure, AdditionalRadiography

ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalRescuePlan]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalVehicleEntry]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalFreezePlugOrExpansionPlug]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalHazop]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalLeakSeal]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalTemporaryFacilityPlacementOrSiting]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalHazardousServiceTag]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalFireProtectionSystems]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalEnvironmental]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalSafeWorkProcedure]
ALTER TABLE [dbo].[WorkPermitHistory] DROP CONSTRAINT [DF_WorkPermitHistory_AdditionalRadiography]

ALTER TABLE [dbo].[WorkPermitHistory] 
	DROP COLUMN AdditionalRescuePlan, AdditionalVehicleEntry, AdditionalFreezePlugOrExpansionPlug, AdditionalHazop,  AdditionalLeakSeal,
			AdditionalTemporaryFacilityPlacementOrSiting, AdditionalHazardousServiceTag, AdditionalFireProtectionSystems,
			AdditionalEnvironmental, AdditionalSafeWorkProcedure, AdditionalRadiography
END
GO