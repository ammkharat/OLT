  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOP14History')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormOP14History
	END
GO
CREATE Procedure [dbo].[InsertFormOP14History]  
( 
 
 @Id bigint,  
 @FormStatusId int,  
   
 @FunctionalLocations varchar(max),  
 @Approvals varchar(max),  
   
 @ValidFromDateTime datetime,  
 @ValidToDateTime datetime,  
   
 @PlainTextContent nvarchar(max) = NULL,  
 @IsTheCSDForAPressureSafetyValve bit,  
 @CriticalSystemDefeated varchar(255) = NULL,  
 @DepartmentId int,  
 @DocumentLinks varchar(max) = NULL,   
 @ApprovedDateTime datetime = NULL,  
 @ClosedDateTime datetime = NULL,  
   
 @LastModifiedByUserId bigint,  
 @LastModifiedDateTime datetime  ,
 @IsSCADAsupportRequired bit=NULL 

)  
AS  
  
INSERT INTO FormOP14History  
(  
 Id,  
 FormStatusId,  
   
 FunctionalLocations,  
 Approvals,  
   
 ValidFromDateTime,  
 ValidToDateTime,  
   
 PlainTextContent,  
 IsTheCSDForAPressureSafetyValve,  
 CriticalSystemDefeated,  
 DepartmentId,  
 DocumentLinks,  
 ApprovedDateTime,  
 ClosedDateTime,  
 LastModifiedByUserId,  
 LastModifiedDateTime ,
 IsSCADAsupportRequired
)  
VALUES  
(  
 @Id,  
 @FormStatusId,  
   
 @FunctionalLocations,  
 @Approvals,  
   
 @ValidFromDateTime,  
 @ValidToDateTime,  
   
 @PlainTextContent,  
 @IsTheCSDForAPressureSafetyValve,  
 @CriticalSystemDefeated,  
 @DepartmentId,   
 @DocumentLinks,   
 @ApprovedDateTime,  
 @ClosedDateTime,  
   
 @LastModifiedByUserId,  
 @LastModifiedDateTime  ,
 @IsSCADAsupportRequired
);  
GRANT EXEC ON [InsertFormOP14History] TO PUBLIC    