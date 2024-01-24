IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[FormGenericTemplateApprover]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[FormGenericTemplateApprover](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FormTypeID] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SiteID] [bigint] NULL,
	[PlantID] [bigint] NULL,
 CONSTRAINT [PK_GenericTemplateApprover] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

End


