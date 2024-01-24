ALTER TABLE [dbo].[LogDefinitionHistory] ADD [Active] bit NULL;
GO

update LogDefinitionHistory set Active = 1;
GO

ALTER TABLE [dbo].[LogDefinitionHistory] ALTER COLUMN [Active] bit NOT NULL;





GO

