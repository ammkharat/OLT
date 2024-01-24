CREATE TABLE [dbo].[Directive](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,	
	[Content] [varchar](max) NULL,
	[PlainTextContent] [nvarchar](max) NULL,
	[ActiveFromDateTime] [datetime] NOT NULL,
	[ActiveToDateTime] [datetime] NOT NULL,		
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Directive] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) 
 ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Directive]
ADD CONSTRAINT [FK_Directive_CreatedByUser] 
FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])

GO

ALTER TABLE [dbo].[Directive]
ADD CONSTRAINT [FK_Directive_LastModifiedByUser] 
FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])

GO

CREATE TABLE [dbo].[DirectiveWorkAssignment] (
[DirectiveId] bigint NOT NULL,
[WorkAssignmentId] bigint NOT NULL,
CONSTRAINT [PK_DirectiveWorkAssignment]
PRIMARY KEY CLUSTERED ([DirectiveId], [WorkAssignmentId]));

GO

ALTER TABLE [dbo].[DirectiveWorkAssignment]
ADD CONSTRAINT [FK_DirectiveWorkAssignment_Directive] 
FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])

GO

ALTER TABLE [dbo].[DirectiveWorkAssignment]
ADD CONSTRAINT [FK_DirectiveWorkAssignment_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])

GO

CREATE TABLE [dbo].[DirectiveFunctionalLocation] (
[DirectiveId] bigint NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
CONSTRAINT [PK_DirectiveFunctionalLocation]
PRIMARY KEY CLUSTERED ([DirectiveId], [FunctionalLocationId]));

GO

ALTER TABLE [dbo].[DirectiveFunctionalLocation]
ADD CONSTRAINT [FK_DirectiveFunctionalLocation_Directive] 
FOREIGN KEY([DirectiveId])
REFERENCES [dbo].[Directive] ([Id])

GO

ALTER TABLE [dbo].[DirectiveFunctionalLocation]
ADD CONSTRAINT [FK_DirectiveFunctionalLocation_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])



GO

