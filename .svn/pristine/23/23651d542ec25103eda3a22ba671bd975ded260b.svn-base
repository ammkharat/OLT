/****** Object:  Table [dbo].[FormGenericTemplateEmailApprover]    Script Date: 01/09/2020 03:33:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FormGenericTemplateEmailApprover') 
BEGIN

CREATE TABLE [dbo].[FormGenericTemplateEmailApprover](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FormTypeID] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SiteID] [bigint] NULL,
	[PlantID] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GenericTemplateEmailApprover] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



ALTER TABLE [dbo].[FormGenericTemplateEmailApprover] ADD  DEFAULT ((0)) FOR [IsDeleted]

END