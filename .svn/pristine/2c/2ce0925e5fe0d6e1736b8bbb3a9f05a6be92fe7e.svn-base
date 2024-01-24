
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ScanConfiguration]') AND type in (N'U'))
BEGIN
Create table ScanConfiguration
(ID int identity(1,1),
LocalScanPath varchar(500),
ScanExeName varchar(500),
ScanExePath varchar(500),
SharedPath Varchar(500),
Environment varchar(10),
DELETED bit default(0)

)
END

IF NOT EXISTS(SELECT * FROM ScanConfiguration)
BEGIN
INSERT ScanConfiguration(LocalScanPath,ScanExeName,ScanExePath,SharedPath,Environment)
SELECT 'C:\Scanpermit\','OLTSCAN','\\oltqutcgy002\LogImages\Debug\','C:\Permit\','PROD' UNION
SELECT 'C:\Scanpermit\','OLTSCAN','\\oltqutcgy002\LogImages\Debug\','C:\Permit\','NON-PROD'
END





GO


IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitDocument]') AND type in (N'U'))
BEGIN
Create TABLE WorkPermitDocument
(
 ID bigint Identity(1,1),
 WorkPermitId Varchar(100),
 DocumentPath Nvarchar(500),
 Deleted bit default(0),
 UpdatedBy int,
 CreatedBy int,
 CreatedDate Datetime,
 UpdatedDate Datetime,
 SiteId Int,
 UploadedDocumentType varchar(50),
 Comment Varchar(500)
 
 )
END


GO

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitDocumentType]') AND type in (N'U'))
BEGIN

Create TABLE WorkPermitDocumentType
(
 ID bigint Identity(1,1) ,
 DocumentType Nvarchar(500),
 DocumentTypeAttribution varchar(1),
 UpdatedBy int,
 CreatedBy int,
 CreatedDate Date,
 UpdatedDate Date,
 SiteId Int,
 Deleted bit default(0)
  
 CONSTRAINT [PermitDocumentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY])


INSERT INTO WorkPermitDocumentType(DocumentType,DocumentTypeAttribution,SiteId)
Select 'ACCEPTOR','A',8 union
Select 'ISSUER','I',8 UNION
Select 'VALIDATOR','V',8 union
Select 'OTHER','O',8

END


GO

