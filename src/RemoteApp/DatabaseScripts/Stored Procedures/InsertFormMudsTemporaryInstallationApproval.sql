if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormMudsTemporaryInstallationApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormMudsTemporaryInstallationApproval]
GO

  
CREATE Procedure [dbo].[InsertFormMudsTemporaryInstallationApproval]  
 (  
 @Id bigint Output,  
 @FormMudsTemporaryInstallationId bigint,  
 @Approver varchar(100),  
 @ApprovedByUserId bigint = NULL,  
 @ApprovalDateTime datetime = NULL,  
 @DisplayOrder int,  
 @ShouldBeEnabledBehaviourId int,  
 @Enabled bit  
 )  
AS  
  
INSERT INTO FormMudsTemporaryInstallationApproval  
 (  
  FormMudsTemporaryInstallationId,  
  Approver,  
  ApprovedByUserId,  
  ApprovalDateTime,  
  DisplayOrder,  
  ShouldBeEnabledBehaviourId,  
  Enabled  
 )  
VALUES  
 (   
  @FormMudsTemporaryInstallationId,  
  @Approver,  
  @ApprovedByUserId,  
  @ApprovalDateTime,  
  @DisplayOrder,  
  @ShouldBeEnabledBehaviourId,  
  @Enabled  
 )  
   
SET @Id= SCOPE_IDENTITY()   
  

GRANT EXEC ON InsertFormMudsTemporaryInstallationApproval TO PUBLIC
GO

