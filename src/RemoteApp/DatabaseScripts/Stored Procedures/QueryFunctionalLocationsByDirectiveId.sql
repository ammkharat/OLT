IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFunctionalLocationsByDirectiveId')
    BEGIN
        DROP Procedure [dbo].QueryFunctionalLocationsByDirectiveId
    END
GO

CREATE Procedure [dbo].QueryFunctionalLocationsByDirectiveId
(
    @DirectiveId bigint
)
AS

SELECT fl.* 
FROM DirectiveFunctionalLocation dfl	
INNER JOIN FunctionalLocation fl ON dfl.FunctionalLocationId = fl.Id
WHERE DirectiveId = @DirectiveId
GO

GRANT EXEC ON QueryFunctionalLocationsByDirectiveId TO PUBLIC
GO