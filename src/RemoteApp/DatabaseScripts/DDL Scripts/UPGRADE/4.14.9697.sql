create table [dbo].RestrictionLocationItemSequence 
(
      SeqID bigint identity(1,1) primary key,
      SeqVal varchar(1)
)
GO

declare @current_max bigint
select @current_max = max(id) + 1 from RestrictionLocationItem

DBCC CHECKIDENT(RestrictionLocationItemSequence, RESEED, @current_max)
GO


ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
DROP CONSTRAINT [FK_DeviationAlert_RestrictionLocationItem]
GO
ALTER TABLE [dbo].[RestrictionLocationItem]
DROP CONSTRAINT [FK_RestrictionLocationItem_Parent]
GO
ALTER TABLE [dbo].[RestrictionLocationItemReasonCode]
DROP CONSTRAINT [FK_RestrictionLocationItemReasonCode_Item]
GO
ALTER TABLE [dbo].[RestrictionLocationItem]
DROP CONSTRAINT [FK_RestrictionLocationItem_Floc]
GO
ALTER TABLE [dbo].[RestrictionLocationItem]
DROP CONSTRAINT [FK_RestrictionLocationItem_RestrictionLocation]
GO

EXECUTE [sp_rename]
	@objname  = N'[dbo].[PK_RestrictionLocationItem]',
	@newname  = N'tmp_PK_RestrictionLocationItem',
	@objtype  = 'OBJECT'
GO
EXECUTE [sp_rename]
	@objname  = N'[dbo].[RestrictionLocationItem]',
	@newname  = N'tmp_RestrictionLocationItem',
	@objtype  = 'OBJECT'
GO

CREATE TABLE [dbo].[RestrictionLocationItem] (
	[Id] bigint NOT NULL,
	[Name] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FunctionalLocationId] bigint NULL,
	[ParentItemId] bigint NULL,
	[RestrictionLocationId] bigint NOT NULL,
	CONSTRAINT [PK_RestrictionLocationItem] PRIMARY KEY([Id]) WITH (FILLFACTOR=100,
		DATA_COMPRESSION = NONE) ON [PRIMARY]
)
GO
CREATE INDEX [IDX_RestrictionLocationItem_RestrictionLocation]
 ON [dbo].[RestrictionLocationItem] ([RestrictionLocationId])
WITH (FILLFACTOR=100,
	DATA_COMPRESSION = NONE)
ON [PRIMARY]
GO

INSERT INTO [dbo].[RestrictionLocationItem] (
	[Id],
	[Name],
	[FunctionalLocationId],
	[ParentItemId],
	[RestrictionLocationId])
SELECT
	[Id],
	[Name],
	[FunctionalLocationId],
	[ParentItemId],
	[RestrictionLocationId]
FROM [dbo].[tmp_RestrictionLocationItem]

ALTER INDEX ALL
ON [dbo].[RestrictionLocationItem]
REBUILD

DROP TABLE [dbo].[tmp_RestrictionLocationItem]
GO

ALTER TABLE [dbo].[DeviationAlertResponseReasonCodeAssignment]
 ADD CONSTRAINT [FK_DeviationAlert_RestrictionLocationItem] FOREIGN KEY ([RestrictionLocationItemId])
		REFERENCES [dbo].[RestrictionLocationItem] ([Id])
	
GO
ALTER TABLE [dbo].[RestrictionLocationItem]
 ADD CONSTRAINT [FK_RestrictionLocationItem_Parent] FOREIGN KEY ([ParentItemId])
		REFERENCES [dbo].[RestrictionLocationItem] ([Id])
	
GO
ALTER TABLE [dbo].[RestrictionLocationItemReasonCode]
 ADD CONSTRAINT [FK_RestrictionLocationItemReasonCode_Item] FOREIGN KEY ([RestrictionLocationItemId])
		REFERENCES [dbo].[RestrictionLocationItem] ([Id])
	
GO
ALTER TABLE [dbo].[RestrictionLocationItem]
 ADD CONSTRAINT [FK_RestrictionLocationItem_Floc] FOREIGN KEY ([FunctionalLocationId])
		REFERENCES [dbo].[FunctionalLocation] ([Id])
	
GO
ALTER TABLE [dbo].[RestrictionLocationItem]
 ADD CONSTRAINT [FK_RestrictionLocationItem_RestrictionLocation] FOREIGN KEY ([RestrictionLocationId])
		REFERENCES [dbo].[RestrictionLocation] ([Id])
GO

ALTER TABLE RestrictionLocationItem
	ADD DELETED bit NULL;
GO
	
UPDATE RestrictionLocationItem SET DELETED = 0
GO

ALTER TABLE RestrictionLocationItem
	ALTER COLUMN DELETED bit NOT NULL;
GO


GO

