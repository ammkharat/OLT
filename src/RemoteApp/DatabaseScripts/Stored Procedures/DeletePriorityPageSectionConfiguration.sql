IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeletePriorityPageSectionConfiguration')
	BEGIN
		DROP  Procedure  DeletePriorityPageSectionConfiguration
	END
GO

CREATE Procedure [dbo].[DeletePriorityPageSectionConfiguration]
(
    @ConfigurationId bigint
)
AS

delete from PriorityPageSectionConfiguration where Id = @ConfigurationId;

GO
 