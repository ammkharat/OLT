-- unrelated rename
exec sp_RENAME 'LogHistory.CommentsAsPlainText', 'PlainTextComments', 'COLUMN'

-- definition comment history migration starts here
alter table [LogDefinitionHistory] add PlainTextComments varchar(max) null;

GO

-- Script to migrate Log History into the PlainTextComments column.
declare @LogHistoryId as bigint;

declare LogHistoryIdCursor cursor for select LogDefinitionHistoryId from LogDefinitionHistory; 

open LogHistoryIdCursor;

fetch next from LogHistoryIdCursor into @LogHistoryId;

while (@@FETCH_STATUS = 0)
begin
       
  declare @log_text as Varchar(max);  
  set @log_text = '';
  
  select @log_text = @log_text + Text + CHAR(13) + CHAR(10) 
	from LogDefinitionCommentHistory 
	where LogDefinitionHistoryId = @LogHistoryId and Text is not null and rtrim(ltrim(Text)) <> '';	

  update LogDefinitionHistory set PlainTextComments = @log_text where LogDefinitionHistoryId = @LogHistoryId;
  
  fetch next from LogHistoryIdCursor into @LogHistoryId;
END;

close LogHistoryIdCursor;
DEALLOCATE LogHistoryIdCursor;

alter table [LogDefinitionHistory] alter column PlainTextComments varchar(max) not null;
GO
