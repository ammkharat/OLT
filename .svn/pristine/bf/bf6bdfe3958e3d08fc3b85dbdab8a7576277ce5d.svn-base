IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryByFormOP14EmailCSDApprovalID')
	BEGIN
		DROP PROCEDURE [dbo].QueryByFormOP14EmailCSDApprovalID
	END
GO
Create Procedure QueryByFormOP14EmailCSDApprovalID
(
@FormOP14Id bigint,
@Approver varchar(100)
)
AS
Select * from FormOP14Approval
where FormOP14Id=@FormOP14Id and Approver like @Approver

GRANT EXEC ON [QueryByFormOP14EmailCSDApprovalID] TO PUBLIC  