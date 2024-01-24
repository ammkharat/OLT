IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[SpecialWork]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[SpecialWork](
	[Id] [bigint] IDENTITY(0,1) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[WorkPermitID] [bigint] NULL,
	[PermitRequestID] [bigint] NULL,
 CONSTRAINT [PK_SpecialWork] PRIMARY KEY CLUSTERED 

(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_PADDING OFF

SET IDENTITY_INSERT [dbo].[SpecialWork] ON

INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (0, N'Radiography Inspections', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (1, N'Diving Operations', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (2, N'Excavation', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (3, N'High Voltage Electrical Work', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (4, N'Hot Tapping', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (5, N'On-Stream Leak Sealing', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (6, N'TransAlta Utility Work', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (7, N'Freeze Plug', 8, NULL, NULL)
INSERT [dbo].[SpecialWork] ([Id], [CompanyName], [SiteId], [WorkPermitID], [PermitRequestID]) VALUES (8, N'Powder Actuated Tool Use in Operating Unit', 8, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SpecialWork] OFF
/****** Object:  Default [DF_SpecialWork_WorkPermitID]    Script Date: 11/30/2016 09:11:38 ******/
ALTER TABLE [dbo].[SpecialWork] ADD  CONSTRAINT [DF_SpecialWork_WorkPermitID]  DEFAULT (NULL) FOR [WorkPermitID]

/****** Object:  Default [DF_SpecialWork_PermitRequestID]    Script Date: 11/30/2016 09:11:38 ******/
ALTER TABLE [dbo].[SpecialWork] ADD  CONSTRAINT [DF_SpecialWork_PermitRequestID]  DEFAULT (NULL) FOR [PermitRequestID]
end




GO

