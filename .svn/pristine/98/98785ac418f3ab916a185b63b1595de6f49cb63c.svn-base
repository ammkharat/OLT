IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertGasTestElement')
    BEGIN
        DROP  Procedure  InsertGasTestElement
    END

GO

CREATE Procedure [dbo].[InsertGasTestElement]
(
    @Id bigint Output,
    @WorkPermitId bigint,
    @GasTestElementInfoId bigint,
    @RequiredTest bit,
    @FirstTestResult FLOAT = NULL,
    @ConfinedSpaceTestResult FLOAT = NULL,
    @ConfinedSpaceTestRequired bit,
    @SystemEntryTestResult FLOAT = NULL,
    @SystemEntryTestNotApplicable bit    
)
AS

DELETE 
FROM
    WorkPermitGasTestElementInfo
WHERE
    WorkPermitGasTestElementInfo.WorkPermitId = @WorkPermitId AND
    WorkPermitGasTestElementInfo.GasTestElementInfoId = @GasTestElementInfoId

INSERT INTO [WorkPermitGasTestElementInfo]
(
    [WorkPermitId],
    [GasTestElementInfoId],
    [RequiredTest],
    [FirstTestResult],
    [ConfinedSpaceTestResult],
    [ConfinedSpaceTestRequired],
    [SystemEntryTestResult],
    [SystemEntryTestNotApplicable]
)
VALUES
(
    @WorkPermitId,
    @GasTestElementInfoId,
    @RequiredTest,
    @FirstTestResult,
    @ConfinedSpaceTestResult,
    @ConfinedSpaceTestRequired,
    @SystemEntryTestResult,
    @SystemEntryTestNotApplicable
)

SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertGasTestElement] TO PUBLIC
GO