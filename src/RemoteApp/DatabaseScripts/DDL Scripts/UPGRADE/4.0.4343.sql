alter table [LogHistory] add CommentsAsPlainText varchar(max) null;

GO

-- Script to migrate Log History into the CommentsAsPlainText column.
declare @LogHistoryId as bigint;

declare LogHistoryIdCursor cursor for select LogHistoryId from LogHistory; 

open LogHistoryIdCursor;

fetch next from LogHistoryIdCursor into @LogHistoryId;

while (@@FETCH_STATUS <> -1)
begin
  if (@@FETCH_STATUS <> -2)
  begin
     
  declare @log_text as Varchar(max);  
  set @log_text = '';
  
  select @log_text = @log_text + Text + CHAR(13) + CHAR(10) 
	from LogCommentHistory 
	where LogHistoryId = @LogHistoryId and Text is not null and rtrim(ltrim(Text)) <> '';	

  update LogHistory set CommentsAsPlainText = @log_text where LogHistoryId = @LogHistoryId;
  
  end;
  fetch next from LogHistoryIdCursor into @LogHistoryId;
END;

close LogHistoryIdCursor;
DEALLOCATE LogHistoryIdCursor;


-- Summary Log Comments

alter table [SummaryLog] add RtfComments varchar(max) null;
alter table [SummaryLog] add PlainTextComments varchar(max) null;
alter table [SummaryLog] add DorComments varchar(max) null;

GO
-- CCTODO - uncomment this after data migration
-- alter table [Log] alter column Comments varchar(max) not null;
-- alter table [LogDefinition] alter column Comments varchar(max) not null;

GO

GO
