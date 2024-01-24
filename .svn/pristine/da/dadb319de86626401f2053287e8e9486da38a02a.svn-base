IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPriorityPageSectionConfigurationBySectionKeyAndUserId')
	BEGIN
		DROP  Procedure dbo.QueryPriorityPageSectionConfigurationBySectionKeyAndUserId
	END
GO

CREATE Procedure dbo.QueryPriorityPageSectionConfigurationBySectionKeyAndUserId(@SectionKey int, @UserId bigint)
AS

select * from PriorityPageSectionConfiguration where UserId = @UserId and SectionKey = @SectionKey
GO

GRANT EXEC ON QueryPriorityPageSectionConfigurationBySectionKeyAndUserId TO PUBLIC
GO