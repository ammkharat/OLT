if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPermitRequestLubesWorkOrderSource]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertPermitRequestLubesWorkOrderSource]
GO

CREATE Procedure [dbo].[InsertPermitRequestLubesWorkOrderSource]
    (
    @PermitRequestId bigint,
    @OperationNumber varchar(25) = NULL,
    @SubOperationNumber varchar(25) = NULL
    )
AS

INSERT INTO PermitRequestLubesWorkOrderSource
(
    PermitRequestLubesId,
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

GRANT EXEC ON InsertPermitRequestLubesWorkOrderSource TO PUBLIC
GO  