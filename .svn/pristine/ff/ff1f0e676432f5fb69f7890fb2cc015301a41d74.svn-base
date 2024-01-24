IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveOvertimeOnPremiseContractorsNotInTheList')
	BEGIN
		DROP  Procedure  RemoveOvertimeOnPremiseContractorsNotInTheList
	END

GO

CREATE Procedure [dbo].RemoveOvertimeOnPremiseContractorsNotInTheList
	(
		@OverTimeFormId bigint,
		@CsvItemIds varchar(max)  -- we remove all items that are NOT in this list
	)
AS

UPDATE OvertimeFormContractor
SET Deleted = 1
FROM OvertimeFormContractor
LEFT OUTER JOIN IdSplitter(@CsvItemIds) ids on ids.Id = OvertimeFormContractor.Id
WHERE OvertimeFormContractor.OverTimeFormId = @OverTimeFormId AND
	  ids.Id is null

GRANT EXEC ON RemoveOvertimeOnPremiseContractorsNotInTheList TO PUBLIC

GO