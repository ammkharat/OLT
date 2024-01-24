IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertFormLubesAlarmDisableApproval')
	BEGIN
		DROP  Procedure  InsertFormLubesAlarmDisableApproval
	END

GO

CREATE Procedure [dbo].[InsertFormLubesAlarmDisableApproval]
	(
	@Id bigint Output,
	@FormLubesAlarmDisableId bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormLubesAlarmDisableApproval
	(
		FormLubesAlarmDisableId,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormLubesAlarmDisableId,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormLubesAlarmDisableApproval] TO PUBLIC
GO