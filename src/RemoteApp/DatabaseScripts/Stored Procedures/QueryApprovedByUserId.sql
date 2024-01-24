IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryApprovedByUserId')
	BEGIN
		DROP Procedure [dbo].QueryApprovedByUserId
	END
	GO
Create Procedure [dbo].[QueryApprovedByUserId]              
 (              
  @Id BIGINT                    
 )              
AS              
Select ApprovedByUserId from FormOP14Approval
where Id=@Id
  
GRANT EXEC ON QueryApprovedByUserId TO PUBLIC 
GO