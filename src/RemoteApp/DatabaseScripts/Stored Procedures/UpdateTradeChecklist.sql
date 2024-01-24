  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTradeChecklist')
	BEGIN
		DROP  Procedure  UpdateTradeChecklist
	END

GO

CREATE Procedure [dbo].[UpdateTradeChecklist]
(
	@Id bigint,		
	@Trade varchar(128),
	@Content varchar(max),
	@PlainTextContent varchar(max),
	
	@ConstFieldMaintCoordApproval bit,
	@OpsCoordApproval bit,
	@AreaManagerApproval bit,
	
	@ConstFieldMaintCoordApprovalLastModifiedId bigint = NULL,
	@OpsCoordApprovalLastModifiedId bigint = NULL,
	@AreaManagerApprovalLastModifiedId bigint = NULL,	
	
	@ConstFieldMaintCoordApprovalDateTime datetime = NULL,
	@OpsCoordApprovalDateTime datetime = NULL,
	@AreaManagerApprovalDateTime dateTime = NULL,
		
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime)
AS

UPDATE TradeChecklist
SET              
	Trade = @Trade,
	Content = @Content,
	PlainTextContent = @PlainTextContent,
	
	ConstFieldMaintCoordApproval = @ConstFieldMaintCoordApproval,
	OpsCoordApproval = @OpsCoordApproval,
	AreaManagerApproval = @AreaManagerApproval,
	
	ConstFieldMaintCoordApprovalLastModifiedId = @ConstFieldMaintCoordApprovalLastModifiedId,
	OpsCoordApprovalLastModifiedId = @OpsCoordApprovalLastModifiedId,
	AreaManagerApprovalLastModifiedId = @AreaManagerApprovalLastModifiedId,	

	ConstFieldMaintCoordApprovalDateTime = @ConstFieldMaintCoordApprovalDateTime,
	OpsCoordApprovalDateTime = @OpsCoordApprovalDateTime,
	AreaManagerApprovalDateTime = @AreaManagerApprovalDateTime,
	
	LastModifiedByUserId = @LastModifiedByUserId,
	LastModifiedDateTime = @LastModifiedDateTime
WHERE     (Id = @Id)
GO

GRANT EXEC ON UpdateTradeChecklist TO PUBLIC

GO
