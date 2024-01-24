IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[GenericTemplateEFormHeader]') AND type in (N'U'))

Begin

CREATE TABLE [dbo].[GenericTemplateEFormHeader](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FormTypeID] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SiteID] [bigint] NULL,
	[PlantID] [bigint] NULL
) ON [PRIMARY]

End

--// Insert Data 

IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'Odour - Noise complaint' and FormTypeID = 1001 and SiteID = 8 and PlantID = 702
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1001, N'Odour - Noise complaint', 8, 702)
End
--------------------------
IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'Deviation' and FormTypeID = 1002 and SiteID = 8 and PlantID = 702
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1002, N'Deviation', 8, 702)
End
--------------------------
IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'Road Closure' and FormTypeID = 1003 and SiteID = 8 and PlantID = 702
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1003, N'Road Closure', 8, 702)
End
----------------------------
IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'GN11 Ground Disturbance'and FormTypeID = 1004  and SiteID = 8 and PlantID = 702
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1004, N'GN11 Ground Disturbance', 8, 702)
End
----------------------------
IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'GN27 Freeze Plug' and FormTypeID = 1005  and SiteID = 8 and PlantID = 702
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1005, N'GN27 Freeze Plug', 8, 702)
End
----------------------------
IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'Hazard assessment' and FormTypeID = 1006 and SiteID = 8 and PlantID = 702
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1006, N'Hazard assessment', 8, 702)
End















GO

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





GO

