CREATE TABLE [dbo].[SummaryLogComment](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[SummaryLogId] bigint NOT NULL,
	[CommentCategoryName] varchar(50) NOT NULL,
	[Text] varchar(max) NULL
				
	CONSTRAINT [PK_SummaryLogComment] PRIMARY KEY ([Id] ASC)		
)

GO

ALTER TABLE [dbo].[SummaryLogComment]
ADD CONSTRAINT [FK_SummaryLogComment_SummaryLog] 
FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])

GO


insert into SummaryLogComment
select 
	l.Id,
	'General Comments',
	l.Comments
from SummaryLog l

GO

CREATE TABLE [dbo].[SummaryLogCommentHistory](
	[SummaryLogHistoryId] [bigint] NOT NULL,
	[Id] [bigint] NOT NULL,
	[CommentCategoryName] varchar(50) NOT NULL,
	[Text] varchar(max) NULL
)

ALTER TABLE [SummaryLogCommentHistory]
ADD CONSTRAINT [FK_SummaryLogCommentHistory_SummaryLogHistory] 
FOREIGN KEY([SummaryLogHistoryId])
REFERENCES [SummaryLogHistory] ([SummaryLogHistoryId])

go

insert into SummaryLogCommentHistory
select h.SummaryLogHistoryId, h.Id, 'General Comments', h.Comments
from SummaryLogHistory h

go

alter table SummaryLog
drop column Comments;

alter table SummaryLogHistory
drop column Comments;

GO
GO
