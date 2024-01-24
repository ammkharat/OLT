IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryBusinessCategoryFLOCAssociationsByFLOCId')
    BEGIN
        DROP PROCEDURE [dbo].QueryBusinessCategoryFLOCAssociationsByFLOCId
    END
GO

CREATE Procedure [dbo].QueryBusinessCategoryFLOCAssociationsByFLOCId
(
    @functionalLocationId bigint
)
AS

SELECT
    *
FROM
    BusinessCategoryFLOCAssociation bcfa
	INNER JOIN BusinessCategory bc on bcfa.BusinessCategoryId = bc.Id
WHERE
    bcfa.FunctionalLocationId = @functionalLocationId
	and bc.Deleted = 0		
GO

GRANT EXEC ON QueryBusinessCategoryFLOCAssociationsByFLOCId TO PUBLIC
GO