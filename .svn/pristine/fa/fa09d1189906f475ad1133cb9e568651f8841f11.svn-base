if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDirectiveHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryDirectiveHistoryById]
GO

CREATE Procedure [dbo].[QueryDirectiveHistoryById](@Id bigint)
AS
select * from DirectiveHistory where Id = @Id ORDER BY LastModifiedDateTime;
