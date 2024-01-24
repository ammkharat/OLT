SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OpmExcursionImportStatus](
  [LastSuccessfulExcursionImportDateTime] [datetime] NULL,
  [LastExcursionImportDateTime] [datetime] NULL,
  [LastExcursionImportStatus] [int] NULL
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

INSERT INTO OpmExcursionImportStatus VALUES (NULL, NULL, NULL)
GO



GO

