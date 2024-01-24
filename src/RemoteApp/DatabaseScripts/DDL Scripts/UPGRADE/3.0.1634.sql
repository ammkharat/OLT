alter table businesscategoryflocassociation drop column logguideline

GO


alter table LogComment add CommentCategoryId bigint null

GO

update LogComment set CommentCategoryId = thingy.Id
 from (select cc.Id as Id, lc2.Id as CommentId from LogComment lc2
	inner join Log l on l.Id = lc2.LogId
	inner join FunctionalLocation fl on fl.Id = l.FunctionalLocationId
	inner join FunctionalLocation fl2 on fl2.Level = 1 and CHARINDEX(fl2.FullHierarchy, fl.FullHierarchy) = 1
	inner join CommentCategoryFunctionalLocation ccfl on ccfl.FunctionalLocationId = fl2.Id
	inner join CommentCategory cc on cc.Id = ccfl.CommentCategoryId
	where cc.Name = 'General Comments') thingy
where thingy.CommentId = LogComment.Id

GO

alter table LogComment alter column CommentCategoryId bigint not null

go

