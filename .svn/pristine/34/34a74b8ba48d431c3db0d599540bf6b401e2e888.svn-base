if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryTemplateByIDToShowApprovedByHowManyeipforms]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryTemplateByIDToShowApprovedByHowManyeipforms]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Procedure [dbo].[QueryTemplateByIDToShowApprovedByHowManyeipforms]
	(
		@id bigint,
		@siteid bigint
	)

	as

	select f.* from FormGN75BTemplate ft inner join formgn75b f on ft.id = f.templateid
	where ft.FormStatusId = 2 and ft.Id = @id and ft.siteid = @siteid

