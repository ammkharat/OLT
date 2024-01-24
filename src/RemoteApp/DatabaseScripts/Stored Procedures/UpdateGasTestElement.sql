IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateGasTestElement')
BEGIN
    DROP  Procedure  UpdateGasTestElement
END

GO

CREATE Procedure [dbo].[UpdateGasTestElement]
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
    [WorkPermitGasTestElementInfo]
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


GRANT EXEC ON UpdateGasTestElement TO PUBLIC

GO


 