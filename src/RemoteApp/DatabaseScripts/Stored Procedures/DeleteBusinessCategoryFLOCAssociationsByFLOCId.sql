  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteBusinessCategoryFLOCAssociationsByFLOCId')
	BEGIN
		DROP  Procedure  DeleteBusinessCategoryFLOCAssociationsByFLOCId
	END

GO

CREATE Procedure dbo.DeleteBusinessCategoryFLOCAssociationsByFLOCId
	(	
	@FunctionalLocationId bigint		
	)
AS
DELETE FROM BusinessCategoryFLOCAssociation WHERE FunctionalLocationId = @FunctionalLocationId

RETURN

GO   