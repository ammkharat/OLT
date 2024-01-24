
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
 UpdatedDate Date,
 SiteId Int,
 UploadedDocumentType varchar(50),
 Comment Varchar(500)
 
 )
END