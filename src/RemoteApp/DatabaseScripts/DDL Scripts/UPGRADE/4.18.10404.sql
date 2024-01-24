SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[OpmToeDefinition] ADD [FunctionalLocationId] bigint NOT NULL
GO
ALTER TABLE [dbo].[OpmExcursion] ADD [FunctionalLocationId] bigint NOT NULL
GO


GO

