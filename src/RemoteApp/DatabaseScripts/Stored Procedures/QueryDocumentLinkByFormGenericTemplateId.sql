if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDocumentLinkByFormGenericTemplateId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryDocumentLinkByFormGenericTemplateId]
GO


CREATE Procedure [dbo].[QueryDocumentLinkByFormGenericTemplateId](@FormGenericTemplateId bigint)  
AS  
SELECT * FROM DocumentLink WHERE FormGenericTemplateId = @FormGenericTemplateId and Deleted = 0   
and FormGenericTemplateId IS NOT NULL -- this is here to force the use of a Filtered index on the table  




GO

GRANT EXEC ON QueryDocumentLinkByFormGenericTemplateId TO PUBLIC
GO

