CREATE TABLE [dbo].[DirectiveHistory](
	[Id] [bigint] NOT NULL,		
	[WorkAssignments] varchar(max),
	[FunctionalLocations] varchar(max),
	[DocumentLinks] varchar(max) NULL,
	[PlainTextContent] varchar(max) NOT NULL,	
	[ActiveFromDate] [date] NOT NULL,
	[ActiveFromTime] time NULL,	
	[ActiveToDateTime] [datetime] NOT NULL,		
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_DirectiveHistory] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) 
 ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[DirectiveHistory]
ADD CONSTRAINT [FK_DirectiveHistory_LastModifiedByUser] 
FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])


GO

