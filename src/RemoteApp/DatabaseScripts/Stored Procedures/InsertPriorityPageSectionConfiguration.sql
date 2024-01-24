IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertPriorityPageSectionConfiguration')
	BEGIN
		DROP  Procedure  InsertPriorityPageSectionConfiguration
	END
GO

CREATE Procedure [dbo].[InsertPriorityPageSectionConfiguration]
(
    @Id bigint Output,
    @SectionKey int,
	@UserId bigint,
	@SectionExpandedByDefault bit,	
	@LastModifiedDateTime datetime		
)
AS

INSERT INTO PriorityPageSectionConfiguration (SectionKey, UserId, SectionExpandedByDefault, LastModifiedDateTime)
VALUES (@SectionKey, @UserId, @SectionExpandedByDefault, @LastModifiedDateTime)

SET @Id = SCOPE_IDENTITY() 

GO
 