
/****** Object:  Table [dbo].[GenericTemplateEmailEFormHeader]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GenericTemplateEmailEFormHeader') 
BEGIN



CREATE TABLE [dbo].[GenericTemplateEmailEFormHeader](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FormTypeID] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SiteID] [bigint] NULL,
	[PlantID] [bigint] NULL,
	[isNeverEnd] [bit] NOT NULL,
 CONSTRAINT [PK_GenericTemplateEmailEFormHeader] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[GenericTemplateEmailEFormHeader] ADD  DEFAULT ((0)) FOR [isNeverEnd]

Insert Into GenericTemplateEmailEFormHeader Values(3,'Critical System Defeat',1,0,0)
Insert Into GenericTemplateEmailEFormHeader Values(17,'EIP Template',1,0,0)
Insert Into GenericTemplateEmailEFormHeader Values(18,'EIP Issue',1,0,0)


END



