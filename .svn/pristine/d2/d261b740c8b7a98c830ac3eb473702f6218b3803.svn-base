if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestEdmontonWorkOrderSource]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertPermitRequestEdmontonWorkOrderSource]
GO

CREATE Procedure [dbo].[InsertPermitRequestEdmontonWorkOrderSource]
    (
    @PermitRequestId bigint,
    @OperationNumber varchar(25) = NULL,
    @SubOperationNumber varchar(25) = NULL
    )
AS

INSERT INTO PermitRequestEdmontonWorkOrderSource
(
    PermitRequestEdmontonId,
	OperationNumber,
	SubOperationNumber
)
VALUES
(
    @PermitRequestId,
    @OperationNumber,
	@SubOperationNumber
)

GO 

GRANT EXEC ON InsertPermitRequestEdmontonWorkOrderSource TO PUBLIC
GO  