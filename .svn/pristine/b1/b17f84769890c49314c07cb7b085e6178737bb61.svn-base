 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryByFormOP14ApprovalID')
	BEGIN
		DROP PROCEDURE [dbo].QueryByFormOP14ApprovalID
	END
GO

CREATE Procedure [dbo].[QueryByFormOP14ApprovalID]    
(    
 @FormOP14Id bigint,    
 @Approver varchar(100)    
)    
AS    
Select Id from FormOP14Approval    
Where FormOP14Id=@FormOP14Id AND Approver=@Approver    
    
GRANT EXEC ON [QueryByFormOP14ApprovalID] TO PUBLIC    
    
    
    