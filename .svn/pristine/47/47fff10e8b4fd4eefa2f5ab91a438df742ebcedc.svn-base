

alter table SummaryLogComment add CommentCategoryId bigint null

GO

/* This next update relies on the fact that CommentCategory was created in this release
   and is initially populated with one row per site, and that the category id is equal
   to the site id. */

update SummaryLogComment 
set CommentCategoryId = thingy.CommentCategoryId
from (
	select distinct slc.Id as SummaryLogCommentId, cc.Id as CommentCategoryId
	from SummaryLogComment slc
	inner join SummaryLogFunctionalLocation slfl on slfl.SummaryLogId = slc.SummaryLogId
	inner join FunctionalLocation fl on fl.Id = slfl.FunctionalLocationId
	inner join CommentCategory cc on cc.Id = fl.SiteId
	where cc.Name = 'General Comments'	
) thingy
where thingy.SummaryLogCommentId = SummaryLogComment.Id

GO

alter table SummaryLogComment
alter column CommentCategoryId bigint not null

GO

alter table LogDefinitionComment add CommentCategoryId bigint null

GO

update LogDefinitionComment set CommentCategoryId = thingy.CommentCategoryId
 from (select cc.Id as CommentCategoryId, ldc.Id as CommentId from LogDefinitionComment ldc
	inner join LogDefinition ld on ld.Id = ldc.LogDefinitionId
	inner join FunctionalLocation fl on fl.Id = ld.FunctionalLocationId
	inner join FunctionalLocation fl2 on fl2.Level = 1 and CHARINDEX(fl2.FullHierarchy, fl.FullHierarchy) = 1
	inner join CommentCategoryFunctionalLocation ccfl on ccfl.FunctionalLocationId = fl2.Id
	inner join CommentCategory cc on cc.Id = ccfl.CommentCategoryId
	where cc.Name = 'General Comments') thingy
where thingy.CommentId = LogDefinitionComment.Id

GO

alter table LogDefinitionComment
alter column CommentCategoryId bigint not null

GO

/* add foreign key constraints to the various comment tables... */

ALTER TABLE [dbo].[LogComment]
ADD CONSTRAINT [FK_LogComment_CommentCategory]
FOREIGN KEY([CommentCategoryId])
REFERENCES [dbo].[CommentCategory] ([Id])

ALTER TABLE [dbo].[LogDefinitionComment]
ADD CONSTRAINT [FK_LogDefinitionComment_CommentCategory] 
FOREIGN KEY([CommentCategoryId])
REFERENCES [dbo].[CommentCategory] ([Id])

ALTER TABLE [dbo].[SummaryLogComment]
ADD CONSTRAINT [FK_SummaryLogComment_CommentCategory] 
FOREIGN KEY([CommentCategoryId])
REFERENCES [dbo].[CommentCategory] ([Id])

GO

GO
