IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingDailyDirectives')
BEGIN
	DROP VIEW VReportingDailyDirectives
END
GO

CREATE VIEW dbo.[VReportingDailyDirectives]
AS
select * from VLog_Internal where LogType = 3
GO
