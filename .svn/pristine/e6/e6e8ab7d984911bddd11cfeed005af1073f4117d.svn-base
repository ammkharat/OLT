IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertBusinessCategoryFLOCAssociation')
	BEGIN
		DROP  Procedure  InsertBusinessCategoryFLOCAssociation
	END

GO

CREATE Procedure [dbo].[InsertBusinessCategoryFLOCAssociation]
	(
	@Id bigint Output,
	@FunctionalLocationId bigint,
	@BusinessCategoryId bigint,		
	@LastModifiedUserId bigint,
	@LastModifiedDateTime datetime	
	)
AS
							
INSERT INTO 
	[BusinessCategoryFLOCAssociation]
	(	
	[FunctionalLocationId],
	[BusinessCategoryId],		
	[LastModifiedUserId],
	[LastModifiedDateTime]	
	)
VALUES
	(	
	@FunctionalLocationId,
	@BusinessCategoryId,	
	@LastModifiedUserId,
	@LastModifiedDateTime
	)
	
SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertBusinessCategoryFLOCAssociation] TO PUBLIC
GO