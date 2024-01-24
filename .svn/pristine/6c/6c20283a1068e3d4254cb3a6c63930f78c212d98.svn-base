
IF  OBJECT_ID('dbo.GenericTemplateEmailEFormHeader', 'U') IS  NULL 
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
END
GO
--// Insert Data 

IF not EXISTS (
select * from GenericTemplateEmailEFormHeader where  Name like 'Critical System Defeat' and FormTypeID = 3 and SiteID = 1 and PlantID = 0 AND isNeverEnd=0
)
Begin
INSERT [dbo].GenericTemplateEmailEFormHeader ([FormTypeID], [Name], [SiteID], [PlantID],[isNeverEnd]) VALUES (3, 'Critical System Defeat', 1, 0,0)
End
--------------------------
IF not EXISTS (
select * from GenericTemplateEmailEFormHeader where  Name like 'EIP Template' and FormTypeID = 17 and SiteID = 1 and PlantID = 0 and isNeverEnd=0
)
Begin
INSERT [dbo].GenericTemplateEmailEFormHeader ([FormTypeID], [Name], [SiteID], [PlantID],[isNeverEnd]) VALUES (17,'EIP Template',1,0,0)
End
---------------------------------
IF not EXISTS (
select * from GenericTemplateEmailEFormHeader where  Name like 'EIP Issue' and FormTypeID = 18 and SiteID = 1 and PlantID = 0 and isNeverEnd=0
)
Begin
INSERT [dbo].GenericTemplateEmailEFormHeader ([FormTypeID], [Name], [SiteID], [PlantID],[isNeverEnd]) VALUES (18,'EIP Issue',1,0,0)
End
-----------------------------------------------------

IF  OBJECT_ID('dbo.FormGenericTemplateEmailApprover', 'U') IS  NULL 
BEGIN
CREATE TABLE [dbo].[FormGenericTemplateEmailApprover](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FormTypeID] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SiteID] [bigint] NULL,
	[PlantID] [bigint] NULL,
	EmailList NVARCHAR(500),
	[IsDeleted] [bit] NOT NULL         
 CONSTRAINT [PK_GenericTemplateEmailApprover] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[FormGenericTemplateEmailApprover] ADD  DEFAULT ((0)) FOR [IsDeleted]

END 
GO

------------------------



