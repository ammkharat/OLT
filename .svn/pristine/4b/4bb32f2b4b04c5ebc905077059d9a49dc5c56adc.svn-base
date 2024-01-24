-- The purpose of this script is to grab all the comments and put them into a single file such that:
-- 1. There is a comment category header over each comment
-- 2. If there are only general comments, there is no header
-- 3. Categories are alphabetized, but with 'General Comments' first

declare @SummaryLogId as bigint;

declare SummaryLogIdCursor cursor for select Id from SummaryLog; 

open SummaryLogIdCursor;

fetch next from SummaryLogIdCursor into @SummaryLogId;

while (@@FETCH_STATUS = 0) 
begin

  declare @GeneralCommentText as varchar(max);
  declare @DorGeneralCommentText as varchar(max);
  
  declare @DefaultCommentCategoryName as varchar(50);
  declare @DefaultDorCommentCategoryName as varchar(50);
  
  select @GeneralCommentText = slc.Text, @DefaultCommentCategoryName = cc.[Name] from SummaryLogComment slc
    inner join CommentCategory cc on slc.CommentCategoryId = cc.Id
    where slc.SummaryLogId = @SummaryLogId and cc.IsDefaultCategory = 1;
            
  select @DorGeneralCommentText = slc.DorText, @DefaultDorCommentCategoryName = cc.[Name] from SummaryLogComment slc
    inner join CommentCategory cc on slc.CommentCategoryId = cc.Id
    where slc.SummaryLogId = @SummaryLogId and cc.IsDefaultCategory = 1;
    
  -- starting section for loop for remaining comment categories

  declare @CommentCategoryName as varchar(50);
  declare @CommentText as varchar(max);
  declare @DorText as varchar(max);
     
  declare SummaryLogCommentCursor cursor for 
    select CommentCategoryName, Text, DorText 
      from SummaryLogComment slc
      inner join CommentCategory cc on slc.CommentCategoryId = cc.Id
      where slc.SummaryLogId = @SummaryLogId and cc.IsDefaultCategory <> 1
      order by CommentCategoryName; 
               
  open SummaryLogCommentCursor;   
  
  fetch next from SummaryLogCommentCursor into @CommentCategoryName, @CommentText, @DorText;
        
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
        
    fetch next from SummaryLogCommentCursor into @CommentCategoryName, @CommentText, @DorText;
  end
                      
  close SummaryLogCommentCursor;
  DEALLOCATE SummaryLogCommentCursor;
  
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
      set @GeneralCommentText = @DefaultCommentCategoryName + CHAR(13) + CHAR(10) + 
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
      set @DorGeneralCommentText = @DefaultDorCommentCategoryName + CHAR(13) + CHAR(10) + 
        '------------------------------' + CHAR(13) + CHAR(10) +
        @DorGeneralCommentText + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10);
        
      set @DorTextResult = @DorGeneralCommentText + @DorTextResult;
    end
  end  
  -- ending section to add back in default DOR category with header if needed 
     
     
  update SummaryLog set RtfComments = @CommentTextResult, PlainTextComments = @CommentTextResult, DorComments = @DorTextResult 
	where Id = @SummaryLogId;  

  fetch next from SummaryLogIdCursor into @SummaryLogId;
END;

close SummaryLogIdCursor;
DEALLOCATE SummaryLogIdCursor;
GO
