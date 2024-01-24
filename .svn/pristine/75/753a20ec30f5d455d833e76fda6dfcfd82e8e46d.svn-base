IF NOT EXISTS(SELECT 1 FROM sys.Tables WHERE  Name = N'RoadAccessOnPermit' AND Type = N'U')
BEGIN
CREATE TABLE [dbo].[RoadAccessOnPermit](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[WorkCenter] [varchar](10) NULL,
	[SiteId] [bigint] NOT NULL,
	[Deleted] [bit] NOT NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF

ALTER TABLE [dbo].[RoadAccessOnPermit] ADD  CONSTRAINT [DF_RoadAccessOnPermit_Deleted]  DEFAULT ((0)) FOR [Deleted]
END
GO


IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestEdmonton]') 
         AND name = 'RoadAccessOnPermit1'
)
begin
ALTER TABLE [dbo].[PermitRequestEdmonton] ADD [RoadAccessOnPermit1] [bit] NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestEdmonton]') 
         AND name = 'RoadAccessOnPermitFormNumber1'
)
begin
ALTER TABLE [dbo].[PermitRequestEdmonton] ADD [RoadAccessOnPermitFormNumber1] [varchar](10) NULL;
end 

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestEdmonton]') 
         AND name = 'RoadAccessOnPermitType1'
)
begin
ALTER TABLE [dbo].[PermitRequestEdmonton] ADD [RoadAccessOnPermitType1] [varchar](50) NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestEdmontonHistory]') 
         AND name = 'RoadAccessOnPermit1'
)
begin
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] ADD [RoadAccessOnPermit1] [bit] NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestEdmontonHistory]') 
         AND name = 'RoadAccessOnPermitFormNumber1'
)
begin
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] ADD [RoadAccessOnPermitFormNumber1] [varchar](10) NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[PermitRequestEdmontonHistory]') 
         AND name = 'RoadAccessOnPermitType1'
)
begin
ALTER TABLE [dbo].[PermitRequestEdmontonHistory] ADD [RoadAccessOnPermitType1] [varchar](50) NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'RoadAccessOnPermit1'
)
begin
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] ADD [RoadAccessOnPermit1] [bit] NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'RoadAccessOnPermitFormNumber1'
)
begin
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] ADD [RoadAccessOnPermitFormNumber1] [varchar](10) NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonDetails]') 
         AND name = 'RoadAccessOnPermitType1'
)
begin
ALTER TABLE [dbo].[WorkPermitEdmontonDetails] ADD [RoadAccessOnPermitType1] [varchar](50) NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'RoadAccessOnPermit1'
)
begin
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] ADD [RoadAccessOnPermit1] [bit] NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'RoadAccessOnPermitFormNumber1'
)
begin
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] ADD [RoadAccessOnPermitFormNumber1] [varchar](10) NULL;
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmontonHistory]') 
         AND name = 'RoadAccessOnPermitType1'
)
begin
ALTER TABLE [dbo].[WorkPermitEdmontonHistory] ADD [RoadAccessOnPermitType1] [varchar](50) NULL;
end
go

/****** Object:  Table [dbo].[RoadAccessOnPermit]    Script Date: 10/27/2016 07:39:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn24]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formgn24] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn1]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN1] add [siteid] [bigint] NULL
end 

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[formgn59]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN59] add [siteid] [bigint] NULL
end 

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN6]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN6] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN7]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN7] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75A]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN75A] add [siteid] bigint NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormGN75B]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[FormGN75B] add [siteid] [bigint] NULL
end

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Formop14]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formop14] add [siteid] [bigint] NULL
end 

IF not EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[FormTemplate]') 
         AND name = 'siteid'
)
begin
alter table [dbo].[formtemplate] add [siteid] [bigint] NULL
end 



GO

