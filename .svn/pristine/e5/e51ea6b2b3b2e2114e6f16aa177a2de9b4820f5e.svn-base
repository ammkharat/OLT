if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN75BSarniaApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN75BSarniaApprovalApproval]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateFormGN75BSarniaApproval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime,
	@Approver varchar(100),
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
)
AS

UPDATE FormGN75BSarniaApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime,
		Approver = @Approver,
		ShouldBeEnabledBehaviourId = @ShouldBeEnabledBehaviourId,
		Enabled = @Enabled
	WHERE
		Id = @Id

