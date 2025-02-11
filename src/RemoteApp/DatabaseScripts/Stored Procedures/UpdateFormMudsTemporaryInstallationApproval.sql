if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormMudsTemporaryInstallationApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormMudsTemporaryInstallationApproval]
GO

  
CREATE Procedure [dbo].[UpdateFormMudsTemporaryInstallationApproval]  
(  
 @Id bigint,  
   
 @ApprovedByUserId int,  
 @ApprovalDateTime datetime,  
   
 @ShouldBeEnabledBehaviourId int,  
 @Enabled bit  
)  
AS  
  
UPDATE FormMudsTemporaryInstallationApproval  
 SET   
  ApprovedByUserId = @ApprovedByUserId,  
  ApprovalDateTime = @ApprovalDateTime,  
  ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,  
  Enabled = @Enabled  
 WHERE  
  Id = @Id 
  
GRANT EXEC ON UpdateFormMudsTemporaryInstallationApproval TO PUBLIC
GO

 
  