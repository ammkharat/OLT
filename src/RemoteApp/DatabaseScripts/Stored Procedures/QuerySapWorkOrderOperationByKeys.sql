IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySapWorkOrderOperationByKeys')
	BEGIN
		DROP PROCEDURE [dbo].QuerySapWorkOrderOperationByKeys
	END
GO

CREATE Procedure dbo.QuerySapWorkOrderOperationByKeys
	(
		@WorkOrderNumber char(16),
		@OperationNumber char(4),
		@OperationType char(2),
		@SubOperation char(4) = NULL
	)
AS
-- ORDER BY DESC CAUSES THE LATEST ONE TO BE RETREIVED
SELECT TOP 1 * 
FROM SapWorkOrderOperation 
WHERE 
	WorkOrderNumber = @WorkOrderNumber
	AND OperationNumber = @OperationNumber
	AND OperationType = @OperationType
	AND((@SubOperation IS NULL AND SubOperation IS NULL)
    OR (@SubOperation IS NOT NULL AND SubOperation = @SubOperation))    
ORDER BY [id] DESC 		
GO

GRANT EXEC ON [QuerySapWorkOrderOperationByKeys] TO PUBLIC
GO