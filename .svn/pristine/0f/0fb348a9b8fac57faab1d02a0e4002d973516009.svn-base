if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitEdmontonHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitEdmontonHistoryById]
GO

CREATE Procedure [dbo].[QueryWorkPermitEdmontonHistoryById]
(
	@Id bigint
)
AS

select * from WorkPermitEdmontonHistory h where h.Id = @Id
ORDER BY h.LastModifiedDateTime

GO

GRANT EXEC ON QueryWorkPermitEdmontonHistoryById TO PUBLIC
GO