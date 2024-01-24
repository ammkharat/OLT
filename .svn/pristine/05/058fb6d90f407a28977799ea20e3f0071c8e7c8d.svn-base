if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDocumentSuggestionByIdAndSiteId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryDocumentSuggestionByIdAndSiteId]
GO

CREATE Procedure [dbo].[QueryDocumentSuggestionByIdAndSiteId]
(
	@Id bigint, @siteid bigint
)
AS
select form.*
from FormDocumentSuggestion form
where form.Id = @Id and form.SiteId = @siteid