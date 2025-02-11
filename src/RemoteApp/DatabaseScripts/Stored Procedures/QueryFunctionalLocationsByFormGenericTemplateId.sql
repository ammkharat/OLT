if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFunctionalLocationsByFormGenericTemplateId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFunctionalLocationsByFormGenericTemplateId]
GO


CREATE Procedure [dbo].[QueryFunctionalLocationsByFormGenericTemplateId]
(
    @FormGenericTemplateId bigint
)
AS

SELECT fl.* 
FROM 
	FormGenericTemplateFunctionalLocation ffl
	INNER JOIN FunctionalLocation fl ON ffl.FunctionalLocationId = fl.Id
WHERE FormGenericTemplateId = @FormGenericTemplateId

GO

GRANT EXEC ON QueryFunctionalLocationsByFormGenericTemplateId TO PUBLIC
GO