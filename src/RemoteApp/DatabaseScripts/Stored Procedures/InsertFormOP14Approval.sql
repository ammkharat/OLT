
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormOP14Approval')
	BEGIN
		DROP PROCEDURE [dbo].InsertFormOP14Approval
	END
GO
Create Procedure [dbo].[InsertFormOP14Approval]  
 (  
 @Id bigint Output,  
 @FormOP14Id bigint,  
 @Approver varchar(100),  
 @ApprovedByUserId bigint = NULL,  
 @ApprovalDateTime datetime = NULL,  
 @DisplayOrder int,  
 @ShouldBeEnabledBehaviourId int,  
 @Enabled bit,
 @isMailSent bit=false  
 )  
AS  
  
INSERT INTO FormOP14Approval  
 (  
  FormOP14Id,  
  Approver,  
  ApprovedByUserId,  
  ApprovalDateTime,  
  DisplayOrder,  
  ShouldBeEnabledBehaviourId,  
  Enabled,
  isMailSent  
 )  
VALUES  
 (   
  @FormOP14Id,  
  @Approver,  
  @ApprovedByUserId,  
  @ApprovalDateTime,  
  @DisplayOrder,  
  @ShouldBeEnabledBehaviourId,  
  @Enabled,
  @isMailSent  
 )  
   
SET @Id= SCOPE_IDENTITY()   
  
GRANT EXEC ON [InsertFormOP14Approval] TO PUBLIC  