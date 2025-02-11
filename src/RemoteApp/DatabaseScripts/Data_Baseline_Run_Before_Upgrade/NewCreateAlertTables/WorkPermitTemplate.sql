IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitTemplate]') AND type in (N'U'))

Begin



CREATE TABLE [dbo].[WorkPermitTemplate](
	[TemplateId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[PermitNumber] [varchar](50) NULL,
	[CreatedByUser] [varchar](100) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[TemplateName] [varchar](100) NULL,
	[IsTemplate] [bit] NULL,
	[Categories] [varchar](100) NULL,
	[Description] [varchar](400) NULL,
	[WorkPermitType] [varchar](100) NULL,
	[Global] [bit] NULL,
	[Individual] [bit] NULL,
	[LastModifiedByUserId] [bigint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_WorkPermitTemplate] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

END
GO


