
CREATE TABLE [dbo].[LogFunctionalLocationList](
	[LogId] [bigint] NOT NULL,
	[FunctionalLocationList] varchar(max) NOT NULL,
 CONSTRAINT [PK_LogFunctionalLocationList] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LogFunctionalLocationList]  WITH NOCHECK ADD  CONSTRAINT [FK_LogFunctionalLocationList_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])

GO


insert into dbo.LogFunctionalLocationList (LogId, FunctionalLocationList)
SELECT l.Id 
, STUFF 
( 
  (SELECT ', ' + f.FullHierarchy
    FROM dbo.LogFunctionalLocation lfl 
    INNER JOIN FunctionalLocation f on f.Id = lfl.FunctionalLocationId 
    where l.Id = lfl.LogId 
    order by f.FullHierarchy 
    FOR XML PATH('') 
  ) 
,1,2,'') as subqueryAsStringList 
FROM [Log] l

GO



GO


CREATE TABLE [dbo].[LogTargetAlertAssociation](
	[LogId] [bigint] NOT NULL,
	[TargetAlertId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogTargetAlertAssociation] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LogTargetAlertAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogTargetAlertAssociation_Log] FOREIGN KEY([LogId])
REFERENCES [dbo].[Log] ([Id])
GO
ALTER TABLE [dbo].[LogTargetAlertAssociation]  WITH CHECK ADD  CONSTRAINT [FK_LogTargetAlertAssociation_TargetAlert] FOREIGN KEY([TargetAlertId])
REFERENCES [dbo].[TargetAlert] ([Id])


GO


CREATE TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocationList](
	[ShiftHandoverQuestionnaireId] [bigint] NOT NULL,
	[FunctionalLocationList] varchar(max) NOT NULL,
 CONSTRAINT [PK_ShiftHandoverQuestionnaireFunctionalLocationList] PRIMARY KEY CLUSTERED 
(
	[ShiftHandoverQuestionnaireId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaireFunctionalLocationList]  WITH NOCHECK ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaireFunctionalLocationList_ShiftHandoverQuestionnaire] FOREIGN KEY([ShiftHandoverQuestionnaireId])
REFERENCES [dbo].[ShiftHandoverQuestionnaire] ([Id])

GO


insert into dbo.ShiftHandoverQuestionnaireFunctionalLocationList (ShiftHandoverQuestionnaireId, FunctionalLocationList)
SELECT shq.Id
, STUFF 
( 
  (SELECT ', ' + f.FullHierarchy
    FROM dbo.ShiftHandoverQuestionnaireFunctionalLocation shqfl 
    INNER JOIN FunctionalLocation f on f.Id = shqfl.FunctionalLocationId 
    where shq.Id = shqfl.ShiftHandoverQuestionnaireId 
    order by f.FullHierarchy 
    FOR XML PATH('') 
  ) 
,1,2,'') as subqueryAsStringList 
FROM [ShiftHandoverQuestionnaire] shq

GO



GO


CREATE TABLE [dbo].[SummaryLogFunctionalLocationList](
	[SummaryLogId] [bigint] NOT NULL,
	[FunctionalLocationList] varchar(max) NOT NULL,
 CONSTRAINT [PK_SummaryLogFunctionalLocationList] PRIMARY KEY CLUSTERED 
(
	[SummaryLogId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SummaryLogFunctionalLocationList]  WITH NOCHECK ADD  CONSTRAINT [FK_SummaryLogFunctionalLocationList_SummaryLog] FOREIGN KEY([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])

GO


insert into dbo.SummaryLogFunctionalLocationList (SummaryLogId, FunctionalLocationList)
SELECT sl.Id
, STUFF 
( 
  (SELECT ', ' + f.FullHierarchy
    FROM dbo.SummaryLogFunctionalLocation slfl
    INNER JOIN FunctionalLocation f on f.Id = slfl.FunctionalLocationId 
    where sl.Id = slfl.SummaryLogId 
    order by f.FullHierarchy 
    FOR XML PATH('') 
  ) 
,1,2,'') as subqueryAsStringList 
FROM [SummaryLog] sl

GO



GO

