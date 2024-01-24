IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocationAncestor]') AND name = N'IDX_FunctionalLocationAncestorId')
	BEGIN
		ALTER INDEX [IDX_FunctionalLocationAncestorId] ON [dbo].[FunctionalLocationAncestor] DISABLE;
	END
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocationAncestor]') AND name = N'IDX_FunctionalLocationAncestor')
	BEGIN
		DROP INDEX [IDX_FunctionalLocationAncestor] ON [dbo].[FunctionalLocationAncestor];
	END
GO

ALTER TABLE [dbo].[FunctionalLocationAncestor] ADD CONSTRAINT [PK_FunctionalLocationAncestor] PRIMARY KEY CLUSTERED
([AncestorId] ASC, [Id] ASC)
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalLocationAncestor]') AND name = N'IDX_FunctionalLocationAncestorId')
	BEGIN
		ALTER INDEX [IDX_FunctionalLocationAncestorId] ON [dbo].[FunctionalLocationAncestor] REBUILD;
	END
GO