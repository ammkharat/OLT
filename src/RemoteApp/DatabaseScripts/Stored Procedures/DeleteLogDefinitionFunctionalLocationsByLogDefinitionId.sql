if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteLogDefinitionFunctionalLocationsByLogDefinitionId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteLogDefinitionFunctionalLocationsByLogDefinitionId]
GO

CREATE Procedure [dbo].[DeleteLogDefinitionFunctionalLocationsByLogDefinitionId]
    (
	@LogDefinitionId bigint
    )
AS

delete
from LogDefinitionFunctionalLocation
where LogDefinitionId = @LogDefinitionId

GO 
GRANT EXEC ON DeleteLogDefinitionFunctionalLocationsByLogDefinitionId TO PUBLIC
GO   