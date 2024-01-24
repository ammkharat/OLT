IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateGasTestElementForSELC')
BEGIN
    DROP  Procedure  UpdateGasTestElementForSELC
END

GO

CREATE Procedure [dbo].[UpdateGasTestElementForSELC]
(
    @Id bigint,
    @RequiredTest bit,
    @FirstTestResult FLOAT = NULL,
    @ConfinedSpaceTestResult FLOAT = NULL,
    @ConfinedSpaceTestRequired bit,
    @SystemEntryTestResult FLOAT = NULL,
    @SystemEntryTestNotApplicable bit
)
AS

UPDATE
    [WorkPermitGasTestElementInfoForSELC]
SET
    RequiredTest = @RequiredTest,
    FirstTestResult = @FirstTestResult,
    ConfinedSpaceTestResult = @ConfinedSpaceTestResult,
    ConfinedSpaceTestRequired = @ConfinedSpaceTestRequired,
    SystemEntryTestResult = @SystemEntryTestResult,
    SystemEntryTestNotApplicable = @SystemEntryTestNotApplicable 
WHERE
    (Id = @Id)
GO


GRANT EXEC ON UpdateGasTestElementForSELC TO PUBLIC

GO


 