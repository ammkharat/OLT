IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdatePriorityPageSectionConfiguration')
	BEGIN
		DROP  Procedure  UpdatePriorityPageSectionConfiguration
	END
GO

CREATE Procedure [dbo].[UpdatePriorityPageSectionConfiguration]
(
    @Id bigint,    
	@SectionExpandedByDefault bit,	
	@LastModifiedDateTime datetime		
)
AS

update PriorityPageSectionConfiguration set
SectionExpandedByDefault = @SectionExpandedByDefault,
LastModifiedDateTime = @LastModifiedDateTime
where Id = @Id;

GO
 