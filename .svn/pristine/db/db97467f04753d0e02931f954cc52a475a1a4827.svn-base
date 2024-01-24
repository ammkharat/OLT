if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertPermitRequestTemplate]
GO


CREATE Procedure [dbo].[InsertPermitRequestTemplate]      
(      
    @Id bigint,        
 @TemplateName varchar(100),    
 @IsTemplate bit,     
 @CreatedByUser varchar(100) ,   
 @Categories varchar(100) ,   
 --@FunctionalLocationId bigint,    
 @Description varchar(400) ,    
 @WorkPermitType varchar(100) ,     
 @Global bit,    
 @Individual bit,    
 @SiteId bigint      
     
       
)    
 AS    
    
 INSERT INTO PermitRequestTemplate    
 (     
 Id,     
 TemplateName ,    
 IsTemplate ,     
 CreatedByUser ,     
 SiteId ,    
 Categories,    
 Description,    
 --FunctionalLocationId,    
 WorkPermitType,    
 Global ,    
 Individual ,    
 Deleted      
     
 )    
 VALUES    
    
 (    
 @Id,     
 @TemplateName ,    
 @IsTemplate ,     
 @CreatedByUser ,     
 @SiteId ,    
 @Categories,  
 @Description ,    
 --@FunctionalLocationId,    
 @WorkPermitType ,    
 @Global ,    
 @Individual ,    
 0    
 )    

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON InsertPermitRequestTemplate TO PUBLIC
GO



GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertWorkPermitTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertWorkPermitTemplate]
GO  
  
CREATE Procedure [dbo].[InsertWorkPermitTemplate]        
(        
    @Id bigint,      
    @PermitNumber varchar(50),      
 @TemplateName varchar(100),      
 @IsTemplate bit,       
 @CreatedByUser varchar(100) ,   
@Categories varchar(100) ,   
 @Description varchar(400) ,      
 @WorkPermitType varchar(100) ,      
 @Global bit,      
 @Individual bit,       
 @SiteId bigint        
       
         
)      
 AS      
      
 INSERT INTO WorkPermitTemplate      
 (       
 Id,      
 PermitNumber ,      
 TemplateName ,      
 IsTemplate ,       
 CreatedByUser ,       
 SiteId ,      
 Categories,      
 Description,      
 WorkPermitType,      
 Global ,      
 Individual ,      
 Deleted        
       
 )      
 VALUES      
      
 (      
 @Id,      
 @PermitNumber ,      
 @TemplateName ,      
 @IsTemplate ,       
 @CreatedByUser ,        
 @SiteId ,      
 @Categories,   
 @Description ,      
 @WorkPermitType ,      
 @Global ,      
 @Individual ,      
 0      
 )      
      
OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON InsertWorkPermitTemplate TO PUBLIC
GO

       
      
        
      


GO

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestTemplate]') AND type in (N'U'))

Begin


CREATE TABLE [dbo].[PermitRequestTemplate](
	[TemplateId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
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
	[FunctionalLocationId] [bigint] NULL,
 CONSTRAINT [PK_PermitRequestTemplate] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

END
GO





GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestTemplateCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestTemplateCategory]
GO


 CREATE Procedure QueryPermitRequestTemplateCategory    
 (        
@SiteId bigint    
    
       
 )      
AS      
      
Select  Categories  from PermitRequestTemplate    
where SiteId = @SiteId and Deleted = 0


OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryPermitRequestTemplateCategory TO PUBLIC
GO


GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestTemplateDto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestTemplateDto]
GO

     
CREATE  Procedure [dbo].[QueryPermitRequestTemplateDto]        
    (        
       
@SiteId bigint,      
@CreatedByUser varchar(100)         
    )        
AS        
        
SELECT     
distinct       
 wpt.Id ,                 
 wpt.TemplateName ,          
 wpt.Categories,          
 wpt.WorkPermitType,          
 wpt.Description        
      
FROM        
      
PermitRequestTemplate wpt       
   
WHERE       
wpt.IsTemplate != 0  and wpt.SiteId = @SiteId and wpt.CreatedByUser  = @CreatedByUser and wpt.Deleted = 0     
--and wpt.Global = 1 


OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryPermitRequestTemplateDto TO PUBLIC
GO



GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestTemplateNameandCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestTemplateNameandCategory]
GO



CREATE Procedure QueryPermitRequestTemplateNameandCategory
 (        
  @id bigint,      
  @TemplateName varchar(100),    
  @Categories varchar(100)        
       
 )      
AS      
   
Select wpt.TemplateName, wpt.Categories     
 from  PermitRequestTemplate wpt    
   
where     
wpt.Id = @id and TemplateName = @TemplateName and wpt.Categories = @Categories


OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryPermitRequestTemplateNameandCategory TO PUBLIC
GO


GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitTemplateCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitTemplateCategory]
GO




 CREATE Procedure QueryWorkPermitTemplateCategory    
 (        
@SiteId bigint    
    
       
 )      
AS      
      
Select  Categories  from workpermittemplate    
where SiteId = @SiteId and Deleted = 0

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryWorkPermitTemplateCategory TO PUBLIC
GO



GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitTemplateDTOs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitTemplateDTOs]
GO




CREATE Procedure [dbo].[QueryWorkPermitTemplateDTOs]    
    (       
  @SiteId bigint,    
  @CreatedByUser varchar(100)    
    )    
AS    
   
    
SELECT    
   wpt.Id,      
    wpt.PermitNumber ,      
 wpt.TemplateName ,      
 wpt.Categories,      
 wpt.WorkPermitType,      
 wpt.Description      
  
FROM    
  WorkPermitTemplate wpt       
       
  Where  wpt.IsTemplate != 0  and wpt.SiteId = @SiteId and wpt.CreatedByUser  = @CreatedByUser  
  --or wpt.Global = 1  
   and wpt.Deleted = 0  
    

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryWorkPermitTemplateDTOs TO PUBLIC
GO



GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitTemplateNameandCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitTemplateNameandCategory]
GO




CREATE Procedure QueryWorkPermitTemplateNameandCategory    
 (        
  @id bigint,      
  @TemplateName varchar(100),    
  @Categories varchar(100)         
 )      
AS      
      
Select wpt.TemplateName, wpt.Categories     
 from  WorkPermitTemplate wpt    
    
where     
wpt.Id = @id and TemplateName = @TemplateName and wpt.Categories = @Categories

OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryWorkPermitTemplateNameandCategory TO PUBLIC
GO



GO

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





GO

