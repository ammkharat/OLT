IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryWorkPermitBySapWorkOrderOperationKeys')
	BEGIN
		DROP PROCEDURE [dbo].QueryWorkPermitBySapWorkOrderOperationKeys
	END
GO

CREATE Procedure [dbo].QueryWorkPermitBySapWorkOrderOperationKeys
	(
		@workOrderNumber char(12), 
		@operationNumber char(4),
		@subOperation char(4) = NULL,
		@SAPOperationType char(2)
	)
AS

IF (@subOperation IS NULL)
    BEGIN
        select 
        wp.*
        from 
        WorkPermit wp 
        INNER JOIN SapWorkOrderOperation sap ON wp.SapOperationId = sap.Id
        where 
        sap.WorkOrderNumber = @workOrderNumber and 
        sap.OperationNumber = @operationNumber and
        sap.OperationType = @SAPOperationType
        AND sap.SubOperation IS NULL
    END
ELSE
    BEGIN
        select 
        wp.*
        from 
        WorkPermit wp 
        INNER JOIN SapWorkOrderOperation sap ON wp.SapOperationId = sap.Id
        where 
        sap.WorkOrderNumber = @workOrderNumber and 
        sap.OperationNumber = @operationNumber and
        sap.OperationType = @SAPOperationType AND
        sap.SubOperation IS NOT NULL AND
        sap.SubOperation = @subOperation
    END
GO

GRANT EXEC ON QueryWorkPermitBySapWorkOrderOperationKeys TO PUBLIC
GO