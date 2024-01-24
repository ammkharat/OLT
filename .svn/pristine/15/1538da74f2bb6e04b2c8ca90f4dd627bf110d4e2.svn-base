IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[InsertFormGN75BSarniaApproval]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)  

DROP PROCEDURE dbo.InsertFormGN75BSarniaApproval

GO 

SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO

Create Procedure [dbo].[InsertFormGN75BSarniaApproval]
	(
	@Id bigint Output,
	@FormGN75BId bigint,
	@Approver varchar(100),
	@ApprovedByUserId bigint = NULL,
	@ApprovalDateTime datetime = NULL,
	@DisplayOrder int,
	@ShouldBeEnabledBehaviourId int,
	@Enabled bit
	)
AS

INSERT INTO FormGN75BSarniaApproval	
	(
		FormGN75BId,
		Approver,
		ApprovedByUserId,
		ApprovalDateTime,
		DisplayOrder,
		ShouldBeEnabledBehaviourId,
		Enabled
	)
VALUES
	(	
		@FormGN75BId,
		@Approver,
		@ApprovedByUserId,
		@ApprovalDateTime,
		@DisplayOrder,
		@ShouldBeEnabledBehaviourId,
		@Enabled
	)
	
SET @Id= SCOPE_IDENTITY() 

GRANT EXEC ON [InsertFormGN75BSarniaApproval] TO PUBLIC
