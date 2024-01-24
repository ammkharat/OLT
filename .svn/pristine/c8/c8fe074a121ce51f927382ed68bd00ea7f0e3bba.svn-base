IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveFormOilsandsTrainingItemsNotInTheList')
	BEGIN
		DROP  Procedure  RemoveFormOilsandsTrainingItemsNotInTheList
	END

GO

CREATE Procedure [dbo].RemoveFormOilsandsTrainingItemsNotInTheList
	(
		@FormOilsandsTrainingId bigint,
		@CsvItemIds varchar(max)  -- we remove all items that are NOT in this list
	)
AS

UPDATE FormOilsandsTrainingItem
SET Deleted = 1
FROM FormOilsandsTrainingItem
LEFT OUTER JOIN IdSplitter(@CsvItemIds) ids on ids.Id = FormOilsandsTrainingItem.Id
WHERE FormOilsandsTrainingItem.FormOilsandsTrainingId = @FormOilsandsTrainingId AND
	  ids.Id is null

GRANT EXEC ON RemoveFormOilsandsTrainingItemsNotInTheList TO PUBLIC

GO