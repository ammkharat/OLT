IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertGasTestElementForSELC')
    BEGIN
        DROP  Procedure  InsertGasTestElementForSELC
    END

GO

CREATE Procedure [dbo].[InsertGasTestElementForSELC]
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
    WorkPermitGasTestElementInfoForSELC
WHERE
    WorkPermitGasTestElementInfoForSELC.WorkPermitId = @WorkPermitId AND
    WorkPermitGasTestElementInfoForSELC.GasTestElementInfoId = @GasTestElementInfoId

INSERT INTO [WorkPermitGasTestElementInfoForSELC]
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

GRANT EXEC ON [InsertGasTestElementForSELC] TO PUBLIC
GO