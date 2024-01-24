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