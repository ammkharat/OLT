SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.df_rename
	(
		@oldname varchar(200),
		@newname varchar(200),
		@tablename varchar(200)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @constraintname VARCHAR(200)
	DECLARE @cmd VARCHAR(1000)
	
	SELECT TOP 1
		@constraintname = c.[name] 
	from 
		sys.objects c, sys.objects t
	where 
		c.parent_object_id = t.object_id and t.name = @tablename
		and c.type = 'D'
		and c.[name] like @oldname + '%'

	SET @cmd = 'EXECUTE sp_rename "dbo.' + @constraintname + '", "' + @newname + '", "Object"'
	EXEC (@cmd)

END
GO

-- get rid of InsertLogAssociation stored proc

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLogAssociation')
    BEGIN
        DROP Procedure InsertLogAssociation
    END
GO

-- create LogActionItemDefinitionAssociation table:

CREATE TABLE [dbo].[LogActionItemDefinitionAssociation](
	[LogId] [bigint] NOT NULL,
	[ActionItemDefinitionId] [bigint] NOT NULL
	
	CONSTRAINT [PK_LogActionItemDefinitionAssociation] PRIMARY KEY ([LogId] ASC)
)
GO

ALTER TABLE [dbo].[LogActionItemDefinitionAssociation]  WITH NOCHECK ADD CONSTRAINT [FK_LogActionItemDefinitionAssociation_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogActionItemDefinitionAssociation] CHECK CONSTRAINT [FK_LogActionItemDefinitionAssociation_Log]
GO

ALTER TABLE [dbo].[LogActionItemDefinitionAssociation]  WITH NOCHECK ADD CONSTRAINT [FK_LogActionItemDefinitionAssociation_ActionItemDefinition] FOREIGN KEY([ActionItemDefinitionId])
REFERENCES [dbo].[ActionItemDefinition] ([Id])
GO
ALTER TABLE [dbo].[LogActionItemDefinitionAssociation] CHECK CONSTRAINT [FK_LogActionItemDefinitionAssociation_ActionItemDefinition]
GO

-- Prod can't have any data to fill the new LogActionItemDefinitionAssociation table with because it has none right now
-- and there is no code in any deployed version to create this data, so we don't have to worry about it


-- drop unused columns from LogAssociation table:

alter table dbo.LogAssociation
drop constraint FK_LogAssociation_TargetDefinition;
go

alter table [dbo].[LogAssociation]
drop column TargetDefinitionId
go

alter table dbo.LogAssociation
drop constraint FK_LogAssociation_TargetAlert;
go

alter table [dbo].[LogAssociation]
drop column TargetAlertId
go

alter table dbo.LogAssociation
drop constraint FK_LogAssociation_ActionItemDefinition;
go

alter table [dbo].[LogAssociation]
drop column ActionItemDefinitionId
go

alter table dbo.LogAssociation
drop constraint FK_LogAssociation_User;
go

alter table [dbo].[LogAssociation]
drop column LastModifiedUserId
go

alter table [dbo].[LogAssociation]
drop column LastModifiedDateTime
go

EXEC df_rename 'DF__LogAssoci__Delet__', 'DF_LogAssociation_Deleted_As_False', 'LogAssociation'
GO

ALTER TABLE dbo.LogAssociation
DROP CONSTRAINT DF_LogAssociation_Deleted_As_False
GO

alter table [dbo].[LogAssociation]
drop column Deleted
go


-- rename LogAssociation table to LogActionItem

IF EXISTS(SELECT * FROM information_schema.tables WHERE table_name = 'LogAssociation')
BEGIN

	exec sp_rename 'dbo.LogAssociation.PK_LogAssociation', 'PK_LogActionItemAssociation', 'INDEX';	
	
	exec sp_rename 'dbo.LogAssociation', 'LogActionItemAssociation';

END


GO

GO
