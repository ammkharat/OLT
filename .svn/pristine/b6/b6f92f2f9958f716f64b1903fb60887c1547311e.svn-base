IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[OLTAdministrator]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[OLTAdministrator](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SiteName] [varchar](50) NULL,
	[Group] [varchar](100) NULL,
	[SiteRepresentative] [varchar](100) NULL,
	[SiteAdmin] [varchar](100) NULL,
	[BEA] [varchar](100) NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_OLTAdministrator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

ALTER TABLE [dbo].[OLTAdministrator] ADD  CONSTRAINT [DF_OLTAdministrator_Deleted]  DEFAULT ((0)) FOR [Deleted]


End



GO


IF not EXISTS (
select * from RoleElement where  Name like N'Configure OLT Community' and FunctionalArea = N'Admin - Site Configuration'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (329, N'Configure OLT Community', N'Admin - Site Configuration')
End





GO

