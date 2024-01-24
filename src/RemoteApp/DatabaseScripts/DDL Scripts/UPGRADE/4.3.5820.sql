ALTER TABLE [dbo].[LogDefinition] ADD [Active] bit NULL;
GO

update LogDefinition set Active = 1;
GO

ALTER TABLE [dbo].[LogDefinition] ALTER COLUMN [Active] bit NOT NULL;





GO

