if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryOpmToeDefinitionCommentHistoryByToeName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryOpmToeDefinitionCommentHistoryByToeName]
GO

CREATE Procedure [dbo].[QueryOpmToeDefinitionCommentHistoryByToeName](@ToeName varchar(510))
AS
select * from OpmToeDefinitionCommentHistory where ToeName = @ToeName ORDER BY LastModifiedDateTime;
