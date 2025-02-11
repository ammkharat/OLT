if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormMudsTemporaryInstallation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormMudsTemporaryInstallation]
GO

CREATE Procedure [dbo].[InsertFormMudsTemporaryInstallation]  
(  
 @Id bigint Output,  
   
 @FormStatusId int,  
 @ValidFromDateTime datetime,  
 @ValidToDateTime datetime,  
   
 @Content varchar(max) = NULL,  
 @PlainTextContent nvarchar(max) = NULL,  
   
 @IsTheCSDForAPressureSafetyValve bit,  
 @CriticalSystemDefeated varchar(255) = NULL,  
 @HasBeenCommunicated bit,  
 @HasAttachments bit,  
 @CsdReason varchar(255),   
   
 @ApprovedDateTime datetime = NULL,  
 @HasBeenApproved bit,  
 @ClosedDateTime datetime = NULL,   
   
 @CreatedDateTime datetime,  
 @CreatedByUserId bigint,  
 @LastModifiedByUserId bigint,  
 @LastModifiedDateTime datetime  
)  
AS  
  
DECLARE @NewFormId bigint  
BEGIN  
 EXEC @NewFormId = GetNewMudsSeqVal_MudsFormIdSequence  
END  
  
INSERT INTO FormMudsTemporaryInstallation  
(  
 Id,  
 FormStatusId,  
 ValidFromDateTime,  
 ValidToDateTime,  
   
 Content,  
 PlainTextContent,  
   
 IsTheCSDForAPressureSafetyValve,  
 CriticalSystemDefeated,  
 HasBeenCommunicated,  
 HasAttachments,  
 CsdReason,   
   
 ApprovedDateTime,  
 HasBeenApproved,  
 ClosedDateTime,   
   
 CreatedDateTime,  
 CreatedByUserId,  
 LastModifiedByUserId,  
 LastModifiedDateTime,  
 Deleted  
)  
VALUES  
(  
 @NewFormId,  
 @FormStatusId,  
 @ValidFromDateTime,  
 @ValidToDateTime,  
   
 @Content,  
 @PlainTextContent,  
 @IsTheCSDForAPressureSafetyValve,  
 @CriticalSystemDefeated,  
 @HasBeenCommunicated,  
 @HasAttachments,  
 @CsdReason,   
   
 @ApprovedDateTime,  
 @HasBeenApproved,  
 @ClosedDateTime,  
   
 @CreatedDateTime,  
 @CreatedByUserId,  
 @LastModifiedByUserId,  
 @LastModifiedDateTime,  
 0  
);  
  
SET @Id=@NewFormId;


GRANT EXEC ON InsertFormMudsTemporaryInstallation TO PUBLIC
GO
