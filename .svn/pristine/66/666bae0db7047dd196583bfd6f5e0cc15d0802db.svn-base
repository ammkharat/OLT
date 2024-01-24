if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75BTemplateByIdAndSiteId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75BTemplateByIdAndSiteId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[QueryFormGN75BTemplateByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select f.* from FormGN75BTemplate f where f.Id = @Id and f.siteid = @siteid
GRANT EXEC ON QueryFormGN75BTemplateByIdAndSiteId TO PUBLIC


