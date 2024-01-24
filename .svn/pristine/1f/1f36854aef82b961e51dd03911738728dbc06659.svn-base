if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveGn75BTemplateIsolationItemsNotInTheList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveGn75BTemplateIsolationItemsNotInTheList]
GO



CREATE Procedure [dbo].[RemoveGn75BTemplateIsolationItemsNotInTheList]

	(

		@FormGN75BTemplateId bigint,

		@CsvItemIds varchar(max)  -- we remove all items that are NOT in this list

	)

AS

UPDATE FormGN75BTemplateIsolationItem

SET Deleted = 1

FROM FormGN75BTemplateIsolationItem

LEFT OUTER JOIN IdSplitter(@CsvItemIds) ids on ids.Id = FormGN75BTemplateIsolationItem.Id

WHERE FormGN75BTemplateIsolationItem.FormGN75BTemplateId = @FormGN75BTemplateId AND

	  ids.Id is null



GRANT EXEC ON RemoveGn75BTemplateIsolationItemsNotInTheList TO PUBLIC





