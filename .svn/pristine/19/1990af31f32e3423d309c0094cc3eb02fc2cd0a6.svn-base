IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'IDX_FunctionalLocation_ParentId')
	BEGIN
		CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_ParentId] ON [dbo].[FunctionalLocation] 
		(
			[ParentId] ASC
		)WITH FILLFACTOR = 90 ON [PRIMARY]
	END
GO

GO
