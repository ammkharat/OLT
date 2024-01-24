 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId')
	BEGIN
		DROP  Procedure  QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId
	END

GO

CREATE Procedure [dbo].[QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId]
	(
	@EntryId bigint,
	@ActionItemId bigint
	)
AS

declare @batchnumber bigint
set @batchnumber = (select max(BatchNumber) from ActionItemResponseTracker where ActionItemId = @ActionItemId)

SELECT * from actionitemresponsetracker t  WHERE CustomFieldId = @EntryId and batchnumber = @batchnumber and ActionItemId = @ActionItemId

