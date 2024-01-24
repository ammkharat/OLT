IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertWorkPermitDocument')
	BEGIN
		DROP PROCEDURE [dbo].InsertWorkPermitDocument
	END
	
GO
CREATE  Procedure [dbo].[InsertWorkPermitDocument]  
(  
   
 @WorkPermitId Varchar(100),  
 @DocumentPath Nvarchar(500),  
 @CreatedBy int,  
 @CreatedDate Datetime,  
 @SiteId Int,  
 @UploadedDocumentType varchar(50),  
 @Comment varchar(50),  
 @UserName Varchar(50)=NULL  
)  
AS  
  
Declare @lCreatedBy int

IF(@UserName IS NOT NULL)  
Begin  
SELECT @lCreatedBy=ISNULL(Id,@CreatedBy) FROM [User] WHERE USERNAME=@UserName  
End  


SELECT @lCreatedBy=ISNULL(@lCreatedBy,@CreatedBy) 
  
INSERT INTO WorkPermitDocument  
(  
 WorkPermitId,  
 DocumentPath,  
 CreatedBy,  
 CreatedDate,  
 SiteId,  
 UploadedDocumentType,  
 Comment  
)  
VALUES  
(  
 @WorkPermitId,  
 @DocumentPath,  
 @lCreatedBy,  
 @CreatedDate,  
 @SiteId,  
 @UploadedDocumentType,  
 @Comment 
);  
  
  
GRANT EXEC ON InsertWorkPermitDocument TO PUBLIC     
  

