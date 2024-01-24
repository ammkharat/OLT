IF EXISTS (SELECT * FROM sysobjects WHERE type = 'TF' AND name = 'VarcharSplitter')
	BEGIN
		DROP  Function  [dbo].VarcharSplitter
	END
GO

CREATE Function [dbo].VarcharSplitter (@Strings varchar(MAX))
Returns @Tbl_Strings TABLE  (String varchar(1000))  AS

BEGIN
    -- Append comma
    SET @Strings =  @Strings + ',' 
    
    -- Indexes to keep the position of searching
    DECLARE @Pos1 bigInt
    DECLARE @Pos2 bigInt
 
    -- Start from first character 
    SET @Pos1 = 1
    SET @Pos2 = 1

    WHILE @Pos1 < Len(@Strings)
        BEGIN
            SET @Pos1 = CharIndex(',', @Strings, @Pos1)
            
            INSERT @Tbl_Strings SELECT CAST ( Substring(@Strings,@Pos2,@Pos1-@Pos2) AS varchar(1000))

            -- Go to next non comma character
            SET @Pos2 = @Pos1 + 1
            
            -- Search from the next charcater
            SET @Pos1 = @Pos1 + 1
        END 
    RETURN
END