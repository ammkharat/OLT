if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryPermitRequestLubesById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryPermitRequestLubesById]
GO

CREATE Procedure [dbo].[QueryPermitRequestLubesById]
(
	@Id bigint
)
AS
select * from PermitRequestLubes where Id = @Id