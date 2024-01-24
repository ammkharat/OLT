if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryExcursionResponseHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryExcursionResponseHistoryById]
GO

CREATE Procedure [dbo].[QueryExcursionResponseHistoryById](@Id bigint)
AS
select * from ExcursionResponseHistory where Id = @Id ORDER BY LastModifiedDateTime;
