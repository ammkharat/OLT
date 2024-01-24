----
---- ***
---- Important: The ids for these forms are hardcoded into the fixtures.  So don't change the order of the insert statements without changing the id values in the code.
---- ***
----


CREATE Procedure [dbo].ForTestData_GetNewSeqVal_FormIdSequence
AS

begin
	declare @NewSeqValue int
	set NOCOUNT ON
	insert into FormIdSequence (SeqVal) values ('a')
	set @NewSeqValue = scope_identity()     	
	delete from FormIdSequence WITH (READPAST)
	return @NewSeqValue
end

GO




DECLARE @UnitLevelFloc1 AS BIGINT;
select @UnitLevelFloc1 = id from functionallocation where fullhierarchy = 'ED1-A002-U001';

DECLARE @NewFormId bigint

--- add a FormGN7 for all to enjoy

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN7 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted)
values (@NewFormId, 1, 'This is content', 'This is content', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0)

insert into FormGN7FunctionalLocation (FormGN7Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

--- add a FormGN59 for all to enjoy

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN59 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted)
values (@NewFormId, 1, 'This is content', 'This is content', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0)

insert into FormGN59FunctionalLocation (FormGN59Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

-- another Form GN7

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN7 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted)
values (@NewFormId, 1, 'Another gn7', 'Another gn7', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0)

insert into FormGN7FunctionalLocation (FormGN7Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

--- another Form GN59

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN59 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted)
values (@NewFormId, 1, 'Another gn59', 'Another gn59', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0)

insert into FormGN59FunctionalLocation (FormGN59Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)


--- add a FormOP14 for all to enjoy

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormOP14 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted, IsTheCSDForAPressureSafetyValve, DepartmentId)
values (@NewFormId, 1, 'This is content', 'This is content', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0, 0, 1)

insert into FormOP14FunctionalLocation (FormOP14Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

--- another Form OP14

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormOP14 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted, IsTheCSDForAPressureSafetyValve, DepartmentId)
values (@NewFormId, 1, 'Another op14', 'Another op14', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0, 0, 2)

insert into FormOP14FunctionalLocation (FormOP14Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

--- add a FormGN24 for all to enjoy

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN24 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted, IsTheSafeWorkPlanForPSVRemovalOrInstallation, IsTheSafeWorkPlanForWorkInTheAlkylationUnit, AlkylationClass)
values (@NewFormId, 1, 'This is content', 'This is content', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0, 0, 0, null)

insert into FormGN24FunctionalLocation (FormGN24Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

-- another Form GN24

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN24 (Id, FormStatusId, Content, PlainTextContent, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted, IsTheSafeWorkPlanForPSVRemovalOrInstallation, IsTheSafeWorkPlanForWorkInTheAlkylationUnit, AlkylationClass)
values (@NewFormId, 1, 'Another gn24', 'Another gn24', '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0, 0, 0, null)

insert into FormGN24FunctionalLocation (FormGN24Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

DECLARE @ResponsibiltiesTemplateId AS BIGINT;
select @ResponsibiltiesTemplateId = Id From FormTemplate WHERE FormTypeId = 5 and Deleted = 0 and TemplateKey = 'responsibilities'


--- add a FormGN6 for all to enjoy

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN6 (Id, FormStatusId, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted, JobDescription, ReasonForCriticalLift, Section1Content, Section1PlainTextContent, Section1NotApplicableToJob, Section2Content, Section2PlainTextContent, Section2NotApplicableToJob, Section3Content, Section3PlainTextContent, Section3NotApplicableToJob, Section4Content, Section4PlainTextContent, Section4NotApplicableToJob, Section5Content, Section5PlainTextContent, Section5NotApplicableToJob, Section6Content, Section6PlainTextContent, Section6NotApplicableToJob, WorkerResponsiblitiesTemplateId)
values (@NewFormId, 1, '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0, 'jobd', 'reason', 'sec1', 'sec1', 0, 'sec2', 'sec2', 0, 'sec3', 'sec3', 0, 'sec4', 'sec4', 0, 'sec5', 'sec5', 0, 'sec6', 'sec6', 0, @ResponsibiltiesTemplateId)

insert into FormGN6FunctionalLocation (FormGN6Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

-- another Form GN6

BEGIN
	EXEC @NewFormId = ForTestData_GetNewSeqVal_FormIdSequence
END

insert into FormGN6 (Id, FormStatusId, ValidFromDateTime, ValidToDateTime, ApprovedDateTime, ClosedDateTime, CreatedByUserId, CreatedDateTime, LastModifiedByUserId, LastModifiedDateTime, Deleted, JobDescription, ReasonForCriticalLift, Section1Content, Section1PlainTextContent, Section1NotApplicableToJob, Section2Content, Section2PlainTextContent, Section2NotApplicableToJob, Section3Content, Section3PlainTextContent, Section3NotApplicableToJob, Section4Content, Section4PlainTextContent, Section4NotApplicableToJob, Section5Content, Section5PlainTextContent, Section5NotApplicableToJob, Section6Content, Section6PlainTextContent, Section6NotApplicableToJob, WorkerResponsiblitiesTemplateId)
values (@NewFormId, 1, '2012-10-5 13:00', '2012-10-6 13:00', null, null, 1, '2012-10-5 11:00', 1, '2012-10-5 11:00', 0, 'jobd', 'reason', 'sec1', 'sec1', 0, 'sec2', 'sec2', 0, 'sec3', 'sec3', 0, 'sec4', 'sec4', 0, 'sec5', 'sec5', 0, 'sec6', 'sec6', 0, @ResponsibiltiesTemplateId)

insert into FormGN6FunctionalLocation (FormGN6Id, FunctionalLocationId)
values (@NewFormId, @UnitLevelFloc1)

