CREATE TABLE [dbo].[LogComment](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[LogId] bigint NOT NULL,
	[CommentCategoryName] varchar(50) NOT NULL,
	[Text] varchar(max) NULL
				
	CONSTRAINT [PK_LogComment] PRIMARY KEY ([Id] ASC)		
)

GO

ALTER TABLE [dbo].[LogComment]
ADD CONSTRAINT [FK_LogComment_Log] 
FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])

GO

insert into LogComment
select 
	l.Id,
	'General Comments',
	l.Comments
from [Log] l

GO

-- ------------------------------------------------------------------

DROP INDEX IDX_LogHistory
ON LogHistory

GO

CREATE INDEX [IDX_LogHistory] 
ON [dbo].[LogHistory] 
(
	[Id] ASC
)

GO

ALTER TABLE LogHistory
ADD [LogHistoryId] [bigint] IDENTITY(100,1) NOT NULL;

GO

ALTER TABLE [dbo].LogHistory
ADD CONSTRAINT [PK_LogHistory] 
PRIMARY KEY ([LogHistoryId] ASC)	

GO

-- ------------------------------------------------------------------


CREATE TABLE [dbo].[LogCommentHistory](
	[LogHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[CommentCategoryName] varchar(50) NOT NULL,
	[Text] varchar(max) NULL
)

ALTER TABLE [LogCommentHistory]
ADD CONSTRAINT [FK_LogCommentHistory_LogHistory] 
FOREIGN KEY([LogHistoryId])
REFERENCES [LogHistory] ([LogHistoryId])

go

insert into LogCommentHistory
select h.LogHistoryId, h.Id, 'General Comments', h.Comments
from LogHistory h

go

-- ------------------------------------------------------------------

alter table Log
drop column Comments;

GO

alter table LogHistory
drop column Comments;

GO

GO
