IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertTradeChecklist')
	BEGIN
		DROP  Procedure  InsertTradeChecklist
	END

GO

CREATE Procedure [dbo].[InsertTradeChecklist]
	(
	@Id bigint Output,
	@SequenceNumber int,
	@FormGN1Id bigint,
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
	@LastModifiedDateTime datetime
	)
AS

INSERT INTO TradeChecklist	
	(		
		FormGN1Id,
		SequenceNumber,
		Trade,
		Content,
		PlainTextContent,
		
		ConstFieldMaintCoordApproval,
		OpsCoordApproval,
		AreaManagerApproval,
		
		ConstFieldMaintCoordApprovalLastModifiedId,
		OpsCoordApprovalLastModifiedId,
		AreaManagerApprovalLastModifiedId,	
		
		ConstFieldMaintCoordApprovalDateTime,
		OpsCoordApprovalDateTime,
		AreaManagerApprovalDateTime,
		
		LastModifiedByUserId,
		LastModifiedDateTime
	)
VALUES
	(			
		@FormGN1Id,
		@SequenceNumber,
		@Trade,
		@Content,
		@PlainTextContent,
		
		@ConstFieldMaintCoordApproval,
		@OpsCoordApproval,
		@AreaManagerApproval,
		
		@ConstFieldMaintCoordApprovalLastModifiedId,
		@OpsCoordApprovalLastModifiedId,
		@AreaManagerApprovalLastModifiedId,		
		
		@ConstFieldMaintCoordApprovalDateTime,
		@OpsCoordApprovalDateTime,
		@AreaManagerApprovalDateTime,
	
		@LastModifiedByUserId,
		@LastModifiedDateTime
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertTradeChecklist] TO PUBLIC
GO