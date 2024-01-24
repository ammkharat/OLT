alter table LogHistory
drop column Summary

go

alter table LogDefinitionHistory
drop column Summary

go

-- -------------------------------------------------------------

alter table Log
add AllComments varchar(max)

go

update Log
set AllComments = ''
where 1=1

go

alter table Log
alter column AllComments varchar(max) not null

go

alter table LogDefinition
add AllComments varchar(max)

go

update LogDefinition
set AllComments = ''
where 1=1

go

alter table LogDefinition
alter column AllComments varchar(max) not null

go

-- -------------------------------------------------------------

BEGIN

	DECLARE @Id BIGINT
	DECLARE @Summary varchar(max)

	DECLARE SummaryCursor CURSOR FOR
		select Id, ltrim(rtrim(Summary))
		from Log
		where Summary is not null
		and ltrim(rtrim(Summary)) != ''

	OPEN SummaryCursor

	FETCH NEXT From SummaryCursor INTO @Id, @Summary

	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		update LogComment
		set Text = @Summary + CHAR(13) + CHAR(10) + Text
		where LogId = @Id
		and CommentCategoryId in (select CommentCategory.Id from CommentCategory where CommentCategory.IsDefaultCategory = 1)		
		and charindex(@Summary, Text) = 0

	    FETCH NEXT FROM SummaryCursor INTO @Id, @Summary
	END

	CLOSE SummaryCursor
	DEALLOCATE SummaryCursor
END

GO

-- -------------------------------------------------------------

BEGIN

	DECLARE @Id BIGINT
	DECLARE @Summary varchar(max)

	DECLARE SummaryCursor CURSOR FOR
		select Id, ltrim(rtrim(Summary))
		from LogDefinition
		where Summary is not null
		and ltrim(rtrim(Summary)) != ''

	OPEN SummaryCursor

	FETCH NEXT From SummaryCursor INTO @Id, @Summary

	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		update LogDefinitionComment
		set Text = @Summary + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) + Text
		where LogDefinitionId = @Id
		and CommentCategoryId in (select CommentCategory.Id from CommentCategory where CommentCategory.IsDefaultCategory = 1)		
		and charindex(@Summary, Text) = 0

	    FETCH NEXT FROM SummaryCursor INTO @Id, @Summary
	END

	CLOSE SummaryCursor
	DEALLOCATE SummaryCursor
END

GO

-- -------------------------------------------------------------

alter table Log
drop column Summary

go

alter table LogDefinition
drop column Summary

go

-- -------------------------------------------------------------

BEGIN

	DECLARE @Id BIGINT
	DECLARE @CommentText varchar(max)

	DECLARE CommentCursor CURSOR FOR
		select LogComment.LogId, ltrim(rtrim(LogComment.Text))
		from LogComment
		order by LogComment.LogId asc, LogComment.CommentCategoryName asc

	OPEN CommentCursor

	FETCH NEXT From CommentCursor INTO @Id, @CommentText

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		update Log
		set AllComments = AllComments + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10)
		where Id = @Id
		and AllComments is not null
		and AllComments != ''
		and @CommentText is not null
		and @CommentText != ''

		update Log
		set AllComments = AllComments + @CommentText
		where Id = @Id
		and @CommentText is not null
		and @CommentText != ''

	    FETCH NEXT FROM CommentCursor INTO @Id, @CommentText
	END

	CLOSE CommentCursor
	DEALLOCATE CommentCursor
END

GO

-- -------------------------------------------------------------

BEGIN

	DECLARE @Id BIGINT
	DECLARE @CommentText varchar(max)

	DECLARE CommentCursor CURSOR FOR
		select LogDefinitionComment.LogDefinitionId, ltrim(rtrim(LogDefinitionComment.Text))
		from LogDefinitionComment
		order by LogDefinitionComment.LogDefinitionId asc, LogDefinitionComment.CommentCategoryName asc

	OPEN CommentCursor

	FETCH NEXT From CommentCursor INTO @Id, @CommentText

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		update LogDefinition
		set AllComments = AllComments + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10)
		where Id = @Id
		and AllComments is not null
		and AllComments != ''
		and @CommentText is not null
		and @CommentText != ''

		update LogDefinition
		set AllComments = AllComments + @CommentText
		where Id = @Id
		and @CommentText is not null
		and @CommentText != ''

	    FETCH NEXT FROM CommentCursor INTO @Id, @CommentText
	END

	CLOSE CommentCursor
	DEALLOCATE CommentCursor
END

GO


GO
