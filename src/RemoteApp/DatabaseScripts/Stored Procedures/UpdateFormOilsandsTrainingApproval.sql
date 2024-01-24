if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormOilsandsTrainingApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormOilsandsTrainingApproval]
GO

CREATE Procedure [dbo].[UpdateFormOilsandsTrainingApproval]
(
	@Id bigint,
	
	@ApprovedByUserId int,
	@ApprovalDateTime datetime
)
AS

UPDATE FormOilsandsTrainingApproval
	SET 
		ApprovedByUserId = @ApprovedByUserId,
		ApprovalDateTime = @ApprovalDateTime
	WHERE
		Id = @Id

GO

GRANT EXEC ON UpdateFormOilsandsTrainingApproval TO PUBLIC
GO