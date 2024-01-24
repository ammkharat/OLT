if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDirectiveById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryDirectiveById]
GO

CREATE Procedure [dbo].[QueryDirectiveById] (@Id bigint)
AS
select 'Directive' as [Type], d.* from Directive d where d.Id = @Id