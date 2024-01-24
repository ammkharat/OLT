IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveGn75BIsolationItemsNotInTheList')
	BEGIN
		DROP  Procedure  RemoveGn75BIsolationItemsNotInTheList
	END

GO

CREATE Procedure [dbo].RemoveGn75BIsolationItemsNotInTheList
	(
		@FormGN75BId bigint,
		@CsvItemIds varchar(max)  -- we remove all items that are NOT in this list
	)
AS

UPDATE FormGN75BIsolationItem
SET Deleted = 1
FROM FormGN75BIsolationItem
LEFT OUTER JOIN IdSplitter(@CsvItemIds) ids on ids.Id = FormGN75BIsolationItem.Id
WHERE FormGN75BIsolationItem.FormGN75BId = @FormGN75BId AND
	  ids.Id is null

GRANT EXEC ON RemoveGn75BIsolationItemsNotInTheList TO PUBLIC

GO