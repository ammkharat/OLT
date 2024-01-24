if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN6HistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN6HistoryById]
GO

CREATE Procedure [dbo].[QueryFormGN6HistoryById]
(
	@Id bigint
)
AS
select f.*
from FormGN6History f
where f.Id = @Id
ORDER BY LastModifiedDateTime
