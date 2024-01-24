if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN24HistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN24HistoryById]
GO

CREATE Procedure [dbo].[QueryFormGN24HistoryById]
(
	@Id bigint
)
AS
select f.*
from FormGN24History f
where f.Id = @Id
ORDER BY LastModifiedDateTime
