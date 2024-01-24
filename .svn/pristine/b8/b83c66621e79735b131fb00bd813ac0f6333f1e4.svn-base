if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDocumentSuggestionById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryDocumentSuggestionById]
GO

CREATE Procedure [dbo].[QueryDocumentSuggestionById]
(
	@Id bigint
)
AS
select form.*
from FormDocumentSuggestion form
where form.Id = @Id