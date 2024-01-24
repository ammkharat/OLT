
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VExcursionResponseForthHills')
BEGIN
	DROP VIEW VExcursionResponseForthHills
END
GO

CREATE VIEW dbo.[VExcursionResponseForthHills] WITH SCHEMABINDING
AS


--Select * from VExcursionResponse

select 
er.OpmExcursionId as ExcursionId,
er.ToeVersion as TOEVersionId,
er.HistorianTag,
u.UserName,
u.FirstName,
u.LastName,
erh.Response,
erh.LastModifiedDateTime as LastModified
--er.Asset,
--er.Code
 from dbo.ExcursionResponseHistory erh
 inner join dbo.[User] u on u.Id = erh.LastModifiedByUserId
 inner join dbo.[OpmExcursionResponse] er on er.OltExcursionId = erh.Id


 Go


