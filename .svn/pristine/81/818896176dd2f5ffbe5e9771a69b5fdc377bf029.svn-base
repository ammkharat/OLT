IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingLogs')
BEGIN
	DROP VIEW VReportingLogs
END
GO

CREATE VIEW dbo.[VReportingLogs]
AS
select * from VLog_Internal where LogType = 1
GO
