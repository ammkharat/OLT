if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN7HistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN7HistoryById]
GO

CREATE Procedure [dbo].[QueryFormGN7HistoryById]
(
	@Id bigint
)
AS
select f.*
from FormGN7History f
where f.Id = @Id
ORDER BY LastModifiedDateTime