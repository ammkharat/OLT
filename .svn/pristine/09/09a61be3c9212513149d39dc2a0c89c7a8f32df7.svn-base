
--- table structure changes for logs

CREATE TABLE [dbo].[LogCustomFieldGroup] (
	[LogId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogCustomFieldGroup] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC,
	[CustomFieldGroupId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogCustomFieldGroup_Log] FOREIGN KEY ([LogId])
REFERENCES [dbo].[Log] ([Id])
GO

ALTER TABLE [dbo].[LogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogCustomFieldGroup_CustomFieldGroup] FOREIGN KEY ([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
go

alter table LogCustomFieldEntry add CustomFieldId bigint null;
go


--- table structure changes for summary logs

CREATE TABLE [dbo].[SummaryLogCustomFieldGroup] (
	[SummaryLogId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_SummaryLogCustomFieldGroup_RealOne] PRIMARY KEY CLUSTERED
( 
	[SummaryLogId] ASC,
	[CustomFieldGroupId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SummaryLogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldGroup_SummaryLog] FOREIGN KEY ([SummaryLogId])
REFERENCES [dbo].[SummaryLog] ([Id])
GO

ALTER TABLE [dbo].[SummaryLogCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_SummaryLogCustomFieldGroup_CustomFieldGroup] FOREIGN KEY ([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
go

alter table SummaryLogCustomFieldEntry add CustomFieldId bigint null;
go

--- table structure changes for repeating logs

CREATE TABLE [dbo].[LogDefinitionCustomFieldGroup] (
	[LogDefinitionId] [bigint] NOT NULL,
	[CustomFieldGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_LogDefinitionCustomFieldGroup] PRIMARY KEY CLUSTERED
(
	[LogDefinitionId] ASC,
	[CustomFieldGroupId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LogDefinitionCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldGroup_LogDefinition] FOREIGN KEY ([LogDefinitionId])
REFERENCES [dbo].[LogDefinition] ([Id])
GO

ALTER TABLE [dbo].[LogDefinitionCustomFieldGroup]  WITH CHECK ADD  CONSTRAINT [FK_LogDefinitionCustomFieldGroup_CustomFieldGroup] FOREIGN KEY ([CustomFieldGroupId])
REFERENCES [dbo].[CustomFieldGroup] ([Id])
go

alter table LogDefinitionCustomFieldEntry add CustomFieldId bigint null;
go






GO


---- print 'a ' + CONVERT(VARCHAR, GETDATE(), 109)

--- Make the script much faster by temporarily disabling constraints.
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
go

CREATE Function [dbo].CustomFieldNameListSplitter (@NameList varchar(MAX), @SplittingDelimiter varchar(10))
Returns @FieldNames TABLE (Name varchar(max))  AS

BEGIN
    -- Append splitting delimiter
    SET @NameList =  @NameList + @SplittingDelimiter
    
    -- Indexes to keep the position of searching
    DECLARE @Pos1 bigInt
    DECLARE @Pos2 bigInt
 
    -- Start from first character 
    SET @Pos1 = 1
    SET @Pos2 = 1

    WHILE @Pos1 < Len(@NameList)
        BEGIN
            SET @Pos1 = CharIndex(@SplittingDelimiter, @NameList, @Pos1)

            INSERT @FieldNames SELECT Substring(@NameList,@Pos2,@Pos1-@Pos2)

            -- Go to next non-delimiter character
            SET @Pos2 = @Pos1 + Len(@SplittingDelimiter)

            -- Search from the next charcater
            SET @Pos1 = @Pos1 + Len(@SplittingDelimiter)
        END 
    RETURN
END
GO

/*
*   Declare some variables that we'll be using repeatedly.
*/

declare @SplittingDelimiter varchar(10);
select @SplittingDelimiter = '!-.%';       --- we can't use a comma or any other symbol that might appear naturally in a custom field name

declare @RandomNumber int;
declare @maxRandomValue int;
declare @minRandomValue int;
set @maxRandomValue = 9000000;
set @minRandomValue = 0;


/*
*   Declare the temporary tables that we'll be using.
*/
	declare @UniqueCustomFieldNamesListsPerWorkAssignment TABLE(
	  WorkAssignmentId bigint NOT NULL,
	  CustomFieldNamesList varchar(max) NOT NULL,
	  NumberOfLogsInGroup int NOT NULL  
    );

  declare @CustomFieldNames TABLE(
    Name varchar(max) NOT NULL
  );
  
  declare @CustomFieldNamesWithoutCustomFields TABLE(
    Name varchar(max) NOT NULL
  );
  
  declare @CustomFieldIds TABLE(
	Id bigint NOT NULL
  );
  
  declare @CustomFieldIdsTableFlattenedIntoOneRow TABLE(
    CustomFieldIdsList varchar(max) NOT NULL
  );
  
  declare @LogIds TABLE(
	Id bigint NOT NULL
  );
  
	declare @CustomFieldsForNewGroup TABLE(
		CustomFieldName varchar(max) NOT NULL,
		CustomFieldId bigint NULL,
		DisplayOrder int NULL
	);
	
  declare @CustomFieldsThatWouldBeOnALogCreatedToday_Draft TABLE(
	CustomFieldId bigint NOT NULL,
	CustomFieldName varchar(max) NOT NULL,
	CustomFieldGroupId bigint NOT NULL,
	DisplayOrder int NOT NULL
  );
  
  declare @CustomFieldsThatWouldBeOnALogCreatedToday TABLE(
	CustomFieldId bigint NOT NULL,
	CustomFieldName varchar(max) NOT NULL,
	CustomFieldGroupId bigint NOT NULL,
	DisplayOrder int NOT NULL
  );
  
  declare @TmpCustomFieldIds TABLE(
	Id bigint NOT NULL
  );
  
  declare @CustomFieldsThatWouldBeOnALogCreatedToday_FlattenedIntoOneRow TABLE(
    CustomFieldNamesList varchar(max) NULL
  );

/*
*    Create a table that describes all unique sets of custom fields per work assignment in the custom field entries table.
*    E.g. if 20 logs were created with work assignment id 1 and custom fields 'a', 'b', 'c', 'd', there would be one row in this table with work assignment 1 and string 'a/b/c/d' (with a more complicated splitting delimiter than slashes).
*/

delete from @UniqueCustomFieldNamesListsPerWorkAssignment;

insert @UniqueCustomFieldNamesListsPerWorkAssignment
select WorkAssignmentId, customFieldNamesList, count(*) c
from
(
select LogId, l.WorkAssignmentId, STUFF 
( 
  (SELECT @SplittingDelimiter + innerLcfe.CustomFieldName
    FROM LogCustomFieldEntry innerLcfe
    where innerLcfe.LogId = lcfe.LogId
    order by innerLcfe.CustomFieldName
    FOR XML PATH(''), root('MyString'), type
  ).value('/MyString[1]','varchar(max)') 
,1,len(@SplittingDelimiter),'') as customFieldNamesList
from LogCustomFieldEntry lcfe
inner join [Log] l on l.Id = LogId
where l.LogType = 1
group by LogId, l.WorkAssignmentId
) t
group by WorkAssignmentId, customFieldNamesList
order by c
  
/*
*   The main loop of this algorithm iterates over the unique custom field names list / work assignment combinations.
*/

declare @WorkAssignmentId as bigint;
declare @CustomFieldNamesList as varchar(max);
declare @NumberOfLogsInGroup as int;

declare LogGroupCursor cursor for select WorkAssignmentId, CustomFieldNamesList, NumberOfLogsInGroup from @UniqueCustomFieldNamesListsPerWorkAssignment order by NumberOfLogsInGroup desc;
open LogGroupCursor;

fetch next from LogGroupCursor into @WorkAssignmentId, @CustomFieldNamesList, @NumberOfLogsInGroup;

while (@@FETCH_STATUS = 0) 
begin
	print 'start ' + CONVERT(VARCHAR, GETDATE(), 109)
	
	/*
	*   First, get all the ids of logs having the work assignment and custom field entries of our current loop iteration.
	*/
	delete from @LogIds;
	insert @LogIds
	select LogId
	from
	(
	select LogId, l.WorkAssignmentId, STUFF 
	( 
	  (SELECT @SplittingDelimiter + innerLcfe.CustomFieldName
	    FROM LogCustomFieldEntry innerLcfe
	    where innerLcfe.LogId = lcfe.LogId
	    order by innerLcfe.CustomFieldName
	    FOR XML PATH(''), root('MyString'), type 
	  ).value('/MyString[1]','varchar(max)') 
	,1,len(@SplittingDelimiter),'') customFieldNamesList
	from LogCustomFieldEntry lcfe
	inner join [Log] l on l.Id = LogId
	where l.LogType = 1
	group by LogId, l.WorkAssignmentId
	) h
	where customFieldNamesList = @CustomFieldNamesList and WorkAssignmentId = @WorkAssignmentId  
    
	/*
	*   Convert the custom field names in @CustomFieldNamesList into a table for easier use.
	*/
  DELETE FROM @CustomFieldNames;
  INSERT @CustomFieldNames SELECT Name FROM CustomFieldNameListSplitter(@CustomFieldNamesList, @SplittingDelimiter)
  
	/*
	*   Populate the table @CustomFieldsThatWouldBeOnALogCreatedToday with the custom fields that would be shown on a newly created log. 
	*   This is a replication of the logic in CustomFieldService.QueryUniqueOrderedFieldsByWorkAssignment
	*/  
  delete from @CustomFieldsThatWouldBeOnALogCreatedToday_Draft;  
  delete from @CustomFieldsThatWouldBeOnALogCreatedToday;
  
  INSERT @CustomFieldsThatWouldBeOnALogCreatedToday_Draft
  SELECT 
	distinct cf.Id, cf.Name, cfg.Id, cfcfg.DisplayOrder
  FROM 
	CustomField cf
	inner join CustomFieldCustomFieldGroup cfcfg on cfcfg.CustomFieldId = cf.Id
	inner join CustomFieldGroup cfg on cfcfg.CustomFieldGroupId = cfg.Id
	inner join CustomFieldGroupWorkAssignment cfgwa on cfgwa.CustomFieldGroupId = cfg.Id
  where
	cfgwa.WorkAssignmentId = @WorkAssignmentId
	and cfg.AppliesToLogs = 1
  
  declare @DisplayOrder as int;
  set @DisplayOrder = 0;
  
  declare @FieldId as bigint;
  declare @FieldName as varchar(max);
  declare @GroupId as bigint;
  declare CustomFieldsThatWouldBeOnALogCreatedTodayCursor cursor for select CustomFieldId, CustomFieldName, CustomFieldGroupId from @CustomFieldsThatWouldBeOnALogCreatedToday_Draft order by CustomFieldId asc, DisplayOrder asc;
  open CustomFieldsThatWouldBeOnALogCreatedTodayCursor
  fetch next from CustomFieldsThatWouldBeOnALogCreatedTodayCursor into @FieldId, @FieldName, @GroupId;
  while (@@FETCH_STATUS = 0)
  begin

	declare @CountOfExisting as int;
	select @CountOfExisting = count(*) from @CustomFieldsThatWouldBeOnALogCreatedToday cf where cf.CustomFieldName = @FieldName
	
	if (@CountOfExisting = 0)
	begin
		insert into @CustomFieldsThatWouldBeOnALogCreatedToday values (@FieldId, @FieldName, @GroupId, @DisplayOrder);
		set @DisplayOrder = @DisplayOrder + 1;
	end  
	
	fetch next from CustomFieldsThatWouldBeOnALogCreatedTodayCursor into @FieldId, @FieldName, @GroupId;
  end
  close CustomFieldsThatWouldBeOnALogCreatedTodayCursor
  deallocate CustomFieldsThatWouldBeOnALogCreatedTodayCursor
  
  	/*
	*     Flatten the custom fields that would be on a log created today into a one row table.  Then see if it matches the current set of custom fields that we're iterating on.
	*/
  delete from @CustomFieldsThatWouldBeOnALogCreatedToday_FlattenedIntoOneRow;  
  insert @CustomFieldsThatWouldBeOnALogCreatedToday_FlattenedIntoOneRow
  select STUFF
  (
	  (
		SELECT @SplittingDelimiter + cft.CustomFieldName
		FROM @CustomFieldsThatWouldBeOnALogCreatedToday cft
		order by cft.CustomFieldName
		FOR XML PATH(''), root('MyString'), type 
	  ).value('/MyString[1]','varchar(max)')
  ,1,len(@SplittingDelimiter),'') customFieldNamesList
  
  declare @MatchCount as int;
  select @MatchCount = count(*) from @CustomFieldsThatWouldBeOnALogCreatedToday_FlattenedIntoOneRow where customFieldNamesList = @CustomFieldNamesList
  
  /*
  declare @tmpCustomFieldsThatWouldBeOnALogCreatedToday as varchar(max);
  set @tmpCustomFieldsThatWouldBeOnALogCreatedToday = '(unset)';
  select @tmpCustomFieldsThatWouldBeOnALogCreatedToday = customFieldNamesList from @CustomFieldsThatWouldBeOnALogCreatedToday_FlattenedIntoOneRow;
  
  declare @tmpLogCount as int;
  select @tmpLogCount = count(*) from @LogIds;
  
  declare @tmpGroupCount as int;
  select @tmpGroupCount = count(*) from (select distinct CustomFieldGroupId from @CustomFieldsThatWouldBeOnALogCreatedToday) a;
  
  print @WorkAssignmentId
  print @CustomFieldNamesList
  print @tmpCustomFieldsThatWouldBeOnALogCreatedToday
  print cast(@tmpLogCount as varchar(10)) + ' logs'
  print cast(@tmpGroupCount as varchar(10)) + ' groups used'
  */
  
    /*
	*   If the current list of custom fields that we're iterating on doesn't match what a log would be created with today, we create a new custom field group and soft delete it.  Some of the custom fields
	*   probably did match, so we attach those to the new group.  We create new custom fields for the ones that didn't match.
	*
	*   Then we just set all the current set of logs to be against our new group and set the custom field entries to have the appropriate custom field id.
	*/  
  if (@MatchCount = 0)
    begin
        print 'no match'
		
		--- create a new custom field group with a randomly generated name
		select @RandomNumber = Cast((((@maxRandomValue + 1) - @minRandomValue) * Rand() + @minRandomValue) As int);		
	    insert into CustomFieldGroup (Name, AppliesToLogs, AppliesToSummaryLogs, AppliesToDailyDirectives, Deleted)
		values ('Generated by OLT - ' + CAST(@RandomNumber as varchar(20)), 1, 1, 1, 1);
		
		declare @NewlyCreatedCustomFieldGroupId bigint;
		set @NewlyCreatedCustomFieldGroupId = SCOPE_IDENTITY();
		
		insert into CustomFieldGroupWorkAssignment (CustomFieldGroupId, WorkAssignmentId) values (@NewlyCreatedCustomFieldGroupId, @WorkAssignmentId);
		
		delete from @CustomFieldsForNewGroup;		
		insert @CustomFieldsForNewGroup (CustomFieldName, CustomFieldId, DisplayOrder)
		select cfn.Name, cftwboalct.CustomFieldId, cftwboalct.DisplayOrder
		from @CustomFieldNames cfn
		left outer join @CustomFieldsThatWouldBeOnALogCreatedToday cftwboalct on cftwboalct.CustomFieldName = cfn.Name
		
		--- First handle the custom fields that do exist 		
		delete from @TmpCustomFieldIds;
		
		declare @TmpCustomFieldId bigint;
		declare @TmpCustomFieldName varchar(max);
		declare CustomFieldsThatDoExist cursor for select CustomFieldId, CustomFieldName from @CustomFieldsForNewGroup where CustomFieldId is not null;
		open CustomFieldsThatDoExist
		fetch next from CustomFieldsThatDoExist into @TmpCustomFieldId, @TmpCustomFieldName;
		while (@@FETCH_STATUS = 0)
		begin
			select @DisplayOrder = lcfe.DisplayOrder
			from LogCustomFieldEntry lcfe
			inner join @LogIds li on li.Id = lcfe.LogId
			where lcfe.CustomFieldName = @TmpCustomFieldName
			
			insert into CustomFieldCustomFieldGroup (CustomFieldId, CustomFieldGroupId, DisplayOrder)
			values (@TmpCustomFieldId, @NewlyCreatedCustomFieldGroupId, @DisplayOrder)
			
			insert into @TmpCustomFieldIds (Id)
			values (@TmpCustomFieldId);
			
			fetch next from CustomFieldsThatDoExist into @TmpCustomFieldId, @TmpCustomFieldName;
		end
		close CustomFieldsThatDoExist
		deallocate CustomFieldsThatDoExist		
		
		--- Now handle the custom fields that we need to create
		declare CustomFieldsForNewGroupCursor cursor for select CustomFieldName from @CustomFieldsForNewGroup where CustomFieldId is null;
		open CustomFieldsForNewGroupCursor
		fetch next from CustomFieldsForNewGroupCursor into @TmpCustomFieldName;
		while (@@FETCH_STATUS = 0)
		begin
			insert into CustomField (Name, TagId, TypeId) values (@TmpCustomFieldName, null, 0);
			declare @CustomFieldId bigint;
			set @CustomFieldId = SCOPE_IDENTITY();
			
			select @DisplayOrder = lcfe.DisplayOrder
			from LogCustomFieldEntry lcfe
			inner join @LogIds li on li.Id = lcfe.LogId
			where lcfe.CustomFieldName = @TmpCustomFieldName
			
			insert into CustomFieldCustomFieldGroup (CustomFieldId, CustomFieldGroupId, DisplayOrder)
			values (@CustomFieldId, @NewlyCreatedCustomFieldGroupId, @DisplayOrder);
			
			insert into @TmpCustomFieldIds (Id) values (@CustomFieldId);
			
			fetch next from CustomFieldsForNewGroupCursor into @TmpCustomFieldName;
		end
		close CustomFieldsForNewGroupCursor
		deallocate CustomFieldsForNewGroupCursor		
		
		update LogCustomFieldEntry
		set CustomFieldId = cfids.Id
		from LogCustomFieldEntry lcfe
		inner join @LogIds li on li.Id = lcfe.LogId
		inner join CustomField cf on cf.Name = lcfe.CustomFieldName
		inner join @TmpCustomFieldIds cfids on cfids.Id = cf.Id
		
		insert into LogCustomFieldGroup (LogId, CustomFieldGroupId)
		select distinct li.Id, @NewlyCreatedCustomFieldGroupId
		from @LogIds li
	end
  else
    /*
	*   If the current list of custom fields that we're iterating on matches perfectly with what a log would be created with today, we don't create a new group and instead
	*   assign the current set of logs to be against the existing group(s), and assign the custom field entries to be attached to the existing custom fields.
	*/  
    begin
		print 'has match'
		
		--- since there is a match, update the logs with the correct groups and the log field entries with the correct field ids
		insert into LogCustomFieldGroup (LogId, CustomFieldGroupId)
		select li.Id, aa.CustomFieldGroupId
		from @LogIds li
		cross join (select distinct CustomFieldGroupId from @CustomFieldsThatWouldBeOnALogCreatedToday) aa
				
		update LogCustomFieldEntry
	    set CustomFieldId = cf.CustomFieldId
	    from LogCustomFieldEntry lcfe
	    inner join @LogIds li on li.Id = lcfe.LogId
		inner join @CustomFieldsThatWouldBeOnALogCreatedToday cf on cf.CustomFieldName = lcfe.CustomFieldName
	end
      
	  print 'end ' + CONVERT(VARCHAR, GETDATE(), 109)
  fetch next from LogGroupCursor into @WorkAssignmentId, @CustomFieldNamesList, @NumberOfLogsInGroup;
end

close LogGroupCursor;
DEALLOCATE LogGroupCursor;

DROP Function CustomFieldNameListSplitter;

--- turn constraints back on
exec sp_msforeachtable @command1="print '?'", @command2="ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
go




GO

