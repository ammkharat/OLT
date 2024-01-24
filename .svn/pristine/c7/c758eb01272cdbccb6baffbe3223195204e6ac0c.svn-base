alter table [SummaryLogHistory] add PlainTextComments varchar(max) null;
alter table [SummaryLogHistory] add DorComments varchar(max) null;

GO

declare @SummaryLogHistoryId as bigint;

declare SummaryLogHistoryIdCursor cursor for select SummaryLogHistoryId from SummaryLogHistory;

open SummaryLogHistoryIdCursor;

fetch next from SummaryLogHistoryIdCursor into @SummaryLogHistoryId;

while (@@FETCH_STATUS = 0) 
begin

  declare @GeneralCommentText as varchar(max);
  declare @DorGeneralCommentText as varchar(max);
    
  select @GeneralCommentText = ch.Text, @DorGeneralCommentText = ch.DorText
	from SummaryLogCommentHistory ch where ch.SummaryLogHistoryId = @SummaryLogHistoryId and ch.CommentCategoryName = 'General Comments';
                                                              
  -- starting section for loop for remaining comment categories

  declare @CommentCategoryName as varchar(50);
  declare @CommentText as varchar(max);
  declare @DorText as varchar(max);
     
  declare SummaryLogCommentHistoryCursor cursor for 
    select CommentCategoryName, Text, DorText 
      from SummaryLogCommentHistory   
      where SummaryLogHistoryId = @SummaryLogHistoryId and CommentCategoryName <> 'General Comments'
      order by CommentCategoryName; 
               
  open SummaryLogCommentHistoryCursor;   
  
  fetch next from SummaryLogCommentHistoryCursor into @CommentCategoryName, @CommentText, @DorText;
        
  declare @CommentTextResult as varchar(max);
  declare @DorTextResult as varchar(max);
  
  set @CommentTextResult = '';
  set @DorTextResult = '';
      
  while @@FETCH_STATUS = 0
  begin
                                   
    if(@CommentText is not null and @CommentText <> '') 
    begin     
      
      if(@CommentTextResult <> '')
      begin
        set @CommentTextResult = @CommentTextResult + CHAR(13) + CHAR(10);
      end
    
      set @CommentTextResult = @CommentTextResult + @CommentCategoryName + CHAR(13) + CHAR(10) + 
      '------------------------------' + CHAR(13) + CHAR(10) 
      + @CommentText + CHAR(13) + CHAR(10);
    end
    
    if(@DorText is not null and @DorText <> '') 
    begin
      if(@DorTextResult <> '')
      begin
        set @DorTextResult = @DorTextResult + CHAR(13) + CHAR(10);
      end
      
      set @DorTextResult = @DorTextResult + @CommentCategoryName + CHAR(13) + CHAR(10) + 
      '------------------------------' + CHAR(13) + CHAR(10) 
      + @DorText + CHAR(13) + CHAR(10);                  
    end
        
    fetch next from SummaryLogCommentHistoryCursor into @CommentCategoryName, @CommentText, @DorText;
  end
                      
  close SummaryLogCommentHistoryCursor;
  DEALLOCATE SummaryLogCommentHistoryCursor;
    
  -- ending section for loop for remaining comment categories
  
  -- starting section to add back in default category with header if needed 
  if(@CommentTextResult is null or @CommentTextResult = '') -- in this case, there's only general comments
  begin    
    set @CommentTextResult = @GeneralCommentText;    
  end
  else
  begin
    if(@GeneralCommentText is not null and @GeneralCommentText <> '')
    begin    
      set @GeneralCommentText = 'General Comments' + CHAR(13) + CHAR(10) + 
        '------------------------------' + CHAR(13) + CHAR(10) +
        @GeneralCommentText + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10);
        
      set @CommentTextResult = @GeneralCommentText + @CommentTextResult;
    end
  end  
  -- ending section to add back in default category with header if needed 

  -- starting section to add back in default DOR category with header if needed 
  if(@DorTextResult is null or @DorTextResult = '') -- in this case, there's only general comments
  begin
    set @DorTextResult = @DorGeneralCommentText;    
  end
  else
  begin
    if(@GeneralCommentText is not null and @GeneralCommentText <> '')
    begin    
      set @DorGeneralCommentText = 'General Comments' + CHAR(13) + CHAR(10) + 
        '------------------------------' + CHAR(13) + CHAR(10) +
        @DorGeneralCommentText + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10);
        
      set @DorTextResult = @DorGeneralCommentText + @DorTextResult;
    end
  end  
  -- ending section to add back in default DOR category with header if needed 
     
     
  update SummaryLogHistory set PlainTextComments = @CommentTextResult, DorComments = @DorTextResult 
	where SummaryLogHistoryId = @SummaryLogHistoryId;  

  fetch next from SummaryLogHistoryIdCursor into @SummaryLogHistoryId;
END;

close SummaryLogHistoryIdCursor;
DEALLOCATE SummaryLogHistoryIdCursor;

GO

alter table [SummaryLogHistory] alter column PlainTextComments varchar(max) not null;


GO
