if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGenericTemplateByIdAndSiteId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGenericTemplateByIdAndSiteId]
GO


CREATE Procedure [dbo].[QueryFormGenericTemplateByIdAndSiteId] (@Id bigint,@siteid bigint,@formtypeid bigint,@plantid bigint)
AS
select f.* from FormGenericTemplate f where f.Id = @Id and f.siteid = @siteid and f.FormTypeID = @formtypeid 
 and f.plantid = @plantid
Go

GRANT EXEC ON [QueryFormGenericTemplateByIdAndSiteId] TO PUBLIC
Go

