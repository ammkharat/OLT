IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveAllWorkAssignmentReportConfiguration')
    BEGIN
        DROP  Procedure  [dbo].RemoveAllWorkAssignmentReportConfiguration
    END

GO

CREATE Procedure [dbo].RemoveAllWorkAssignmentReportConfiguration
    (
        @SiteId BIGINT
    )
AS

DELETE FROM WorkAssignmentReportConfiguration
WHERE SiteId = @SiteId

GO   
