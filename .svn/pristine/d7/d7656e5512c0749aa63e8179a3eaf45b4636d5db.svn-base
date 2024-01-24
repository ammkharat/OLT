CREATE TABLE [dbo].[CommentCategory](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LogGuidelines] varchar(max) null,
	[IsDefaultCategory] bit NOT NULL,
	[Deleted] bit NOT NULL
	
	CONSTRAINT [PK_CommentCategory] PRIMARY KEY ([Id] ASC)
)
GO


CREATE TABLE [dbo].[CommentCategoryFunctionalLocation](
	[CommentCategoryId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL
)
GO

CREATE NONCLUSTERED INDEX [IDX_CommentCategoryFunctionalLocation] ON [dbo].[CommentCategoryFunctionalLocation] 
(
	[CommentCategoryId] ASC
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[CommentCategoryFunctionalLocation]
ADD CONSTRAINT [FK_CommentCategoryFunctionalLocation_CommentCategory] 
FOREIGN KEY([CommentCategoryId])
REFERENCES [dbo].[CommentCategory] ([Id])
GO

ALTER TABLE [dbo].[CommentCategoryFunctionalLocation]
ADD CONSTRAINT [FK_CommentCategoryFunctionalLocation_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

/* In the following inserting of comment categories, site id is used for the id.  To make a future upgrade
   script more simple, I use this handy fact.  So if you change the following insert statement such that the
   ids change, please also update the script that inserts CommentCategoryId into the SummaryLogComment table. */

SET IDENTITY_INSERT CommentCategory ON

insert into CommentCategory
(Id, Name, LogGuidelines, IsDefaultCategory, Deleted)
select s.Id, 'General Comments', null, 1, 0
from Site s

SET IDENTITY_INSERT CommentCategory OFF

GO

insert into CommentCategoryFunctionalLocation
select f.SiteId, f.Id
from FunctionalLocation f
where f.Level = 1

GO

GO
