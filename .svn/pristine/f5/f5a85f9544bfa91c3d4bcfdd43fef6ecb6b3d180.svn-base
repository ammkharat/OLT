CREATE TABLE [dbo].[LogDefinitionComment](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[LogDefinitionId] bigint NOT NULL,
	[CommentCategoryName] varchar(50) NOT NULL,
	[Text] varchar(max) NULL
				
	CONSTRAINT [PK_LogDefinitionComment] PRIMARY KEY ([Id] ASC)		
)

GO

ALTER TABLE [dbo].[LogDefinitionComment]
ADD CONSTRAINT [FK_LogDefinitionComment_Log] 
FOREIGN KEY([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])

GO

insert into LogDefinitionComment
select 
	l.Id,
	'General Comments',
	l.Comments
from [LogDefinition] l

GO

-- ------------------------------------------------------------------

DROP INDEX IDX_LogDefinitionHistory
ON LogDefinitionHistory

GO

CREATE INDEX [IDX_LogDefinitionHistory] 
ON [dbo].[LogDefinitionHistory] 
(
	[Id] ASC
)

GO

ALTER TABLE LogDefinitionHistory
ADD [LogDefinitionHistoryId] [bigint] IDENTITY(100,1) NOT NULL;

GO

ALTER TABLE [dbo].LogDefinitionHistory
ADD CONSTRAINT [PK_LogDefinitionHistory] 
PRIMARY KEY ([LogDefinitionHistoryId] ASC)	

GO

-- ------------------------------------------------------------------


CREATE TABLE [dbo].[LogDefinitionCommentHistory](
	[LogDefinitionHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[CommentCategoryName] varchar(50) NOT NULL,
	[Text] varchar(max) NULL
)

ALTER TABLE [LogDefinitionCommentHistory]
ADD CONSTRAINT [FK_LogDefinitionCommentHistory_LogDefinitionHistory] 
FOREIGN KEY([LogDefinitionHistoryId])
REFERENCES [LogDefinitionHistory] ([LogDefinitionHistoryId])

go

insert into LogDefinitionCommentHistory
select h.LogDefinitionHistoryId, h.Id, 'General Comments', h.Comments
from LogDefinitionHistory h

go

-- ------------------------------------------------------------------

alter table LogDefinition
drop column Comments;

GO

alter table LogDefinitionHistory
drop column Comments;

GO

GO

GO
