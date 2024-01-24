IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VExcursionResponse')
BEGIN
	DROP VIEW VExcursionResponse
END
GO

CREATE VIEW dbo.[VExcursionResponse] WITH SCHEMABINDING
AS

select 
er.OpmExcursionId as ExcursionId,
er.ToeVersion as TOEVersionId,
er.HistorianTag,
u.UserName,
u.FirstName,
u.LastName,
erh.Response,
erh.LastModifiedDateTime as LastModified
 from dbo.ExcursionResponseHistory erh
 inner join dbo.[User] u on u.Id = erh.LastModifiedByUserId
 inner join dbo.[OpmExcursionResponse] er on er.OltExcursionId = erh.Id
