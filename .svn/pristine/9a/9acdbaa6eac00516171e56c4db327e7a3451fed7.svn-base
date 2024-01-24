if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertSapWorkOrderOperation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertSapWorkOrderOperation]
GO

CREATE Procedure [dbo].[InsertSapWorkOrderOperation]
	(
	@Id bigint Output,
	@WorkOrderNumber char(16),
	@OperationNumber char(4),
	@SubOperation char(4),
	@OperationType char(2)	
	)
AS

INSERT INTO [SapWorkOrderOperation] (
					[WorkOrderNumber], 
                    [OperationNumber], 
                    [SubOperation],
                    [OperationType]
                  )
VALUES     
				(
					@WorkOrderNumber,
					@OperationNumber,
					@SubOperation,
					@OperationType
				)
SET @Id= SCOPE_IDENTITY() 

GO

GRANT EXEC ON [InsertSapWorkOrderOperation] TO PUBLIC
GO