 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetTrackerLastBatchNumber')
	BEGIN
		DROP  Procedure  GetTrackerLastBatchNumber
	END

GO

CREATE Procedure [dbo].[GetTrackerLastBatchNumber]

AS

SELECT ISNULL(max(BatchNumber),0) from ActionItemResponseTracker
