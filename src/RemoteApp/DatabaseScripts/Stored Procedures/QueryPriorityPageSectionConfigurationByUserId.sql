IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPriorityPageSectionConfigurationByUserId')
	BEGIN
		DROP  Procedure dbo.QueryPriorityPageSectionConfigurationByUserId
	END
GO

CREATE Procedure dbo.QueryPriorityPageSectionConfigurationByUserId(@UserId bigint)
AS

select * from PriorityPageSectionConfiguration where UserId = @UserId
GO

GRANT EXEC ON QueryPriorityPageSectionConfigurationByUserId TO PUBLIC
GO