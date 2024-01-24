IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestEdmontonByCompletenessAndGroupAndDateFallingInRequestedRange')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestEdmontonByCompletenessAndGroupAndDateFallingInRequestedRange
    END
GO



GO

