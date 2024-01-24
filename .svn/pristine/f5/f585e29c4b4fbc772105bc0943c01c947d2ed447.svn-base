IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VTOEOperatorComment')
BEGIN
	DROP VIEW VTOEOperatorComment
END
GO

CREATE VIEW dbo.VTOEOperatorComment WITH SCHEMABINDING
AS

select 
c.HistorianTag,
ch.ToeName,
td.ToeVersion,
u.UserName,
u.FirstName,
u.LastName,
ch.Comment,
ch.LastModifiedDateTime as LastModified
 from dbo.OpmToeDefinitionCommentHistory ch
 inner join dbo.[User] u on u.Id = ch.LastModifiedByUserId
 inner join dbo.[OpmToeDefinitionComment] c on c.Id = ch.Id
 inner join dbo.[OpmToeDefinition] td on td.Id = c.OltToeDefinitionId