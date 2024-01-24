SET IDENTITY_INSERT ShiftHandoverConfiguration ON

insert into ShiftHandoverConfiguration (Id, Name, Deleted)
values (1, 'Daily Shift Handover', 0);

DECLARE @wa bigint
SET @wa = (select top 1 id from WorkAssignment where SiteId = 3 and deleted = 0)

insert into ShiftHandoverConfigurationWorkAssignment(ShiftHandoverConfigurationId, WorkAssignmentId)
values (1, @wa);

-- -------------

insert into ShiftHandoverConfiguration (Id, Name, Deleted)
values (2, '6 Day Shift Handover', 0);

insert into ShiftHandoverConfigurationWorkAssignment(ShiftHandoverConfigurationId, WorkAssignmentId)
values (2, @wa);

-- -------------

insert into ShiftHandoverConfiguration (Id, Name, Deleted)
values (3, 'AAAAA Shift Handover', 0);

insert into ShiftHandoverConfigurationWorkAssignment(ShiftHandoverConfigurationId, WorkAssignmentId)
values (3, @wa);

SET IDENTITY_INSERT ShiftHandoverConfiguration OFF

-- ---------------------------------------------------------------


SET IDENTITY_INSERT ShiftHandoverQuestion ON

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion)
values (1, 1, 1, 'Dogs make better pets than cats', 0, 1);

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion)
values (2, 1, 2, 'Kent is a metrosexual. True or False?', 0, 1);

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion)
values (3, 1, 3, 'What is the capital of Bhutan?', 0, 1);

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion)
values (4, 1, 4, 'Is the Pope Catholic?', 0, 1);

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion)
values (5, 2, 1, 'What is A?', 0, 1);

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion)
values (6, 2, 2, 'What is B?', 0, 1);

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion, HelpText)
values (7, 3, 1, 'CCCCCCCCCCCC?', 0, 1, 'help me please please please please');

insert into ShiftHandoverQuestion (Id, ShiftHandoverConfigurationId, DisplayOrder, Text, Deleted, IsCurrentQuestionVersion)
values (8, 3, 2, 'DDDDDDDDDDDD?', 0, 1);


SET IDENTITY_INSERT ShiftHandoverQuestion OFF



-- ---------------------------------------------------------------

SET IDENTITY_INSERT ShiftHandoverQuestionnaire ON

insert into ShiftHandoverQuestionnaire (Id, ShiftHandoverConfigurationName, ShiftId, WorkAssignmentId, CreatedByUserId, CreatedDateTime, LastModifiedDateTime, HasYesAnswer)
values (1, 'some config name', 1, 2, 1, {ts '2010-07-21 11:15:00'}, {ts '2010-07-25 11:15:00'}, 1);

SET IDENTITY_INSERT ShiftHandoverQuestionnaire OFF

DECLARE @EX1_OPLT BIGINT
SET @EX1_OPLT = (select top 1 id from functionallocation where FULLHIERARCHY = 'EX1-OPLT' and siteid = 3)

insert into ShiftHandoverQuestionnaireFunctionalLocation
(ShiftHandoverQuestionnaireId, FunctionalLocationId)
values
(1, @EX1_OPLT)

-- ---------------------------------------------------------------

SET IDENTITY_INSERT ShiftHandoverAnswer ON

insert into ShiftHandoverAnswer (Id, ShiftHandoverQuestionnaireId, Answer, Comments, QuestionDisplayOrder, ShiftHandoverQuestionId)
values (1, 1, 1, 'These are comments for an answer 1', 212, 1);

insert into ShiftHandoverAnswer (Id, ShiftHandoverQuestionnaireId, Answer, Comments, QuestionDisplayOrder, ShiftHandoverQuestionId)
values (2, 1, 1, 'These are comments for an answer 2', 456, 2);

SET IDENTITY_INSERT ShiftHandoverAnswer OFF

