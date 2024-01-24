IF EXISTS (SELECT * FROM sysobjects WHERE type = 'TF' AND name = 'IDSplitter')
	BEGIN
		DROP  Function  [dbo].IDSplitter
	END
GO

CREATE Function [dbo].IDSplitter (@IDs varchar(MAX) )  
Returns @Tbl_IDs TABLE  (ID bigInt)  AS

BEGIN
    -- Append comma
    SET @IDs =  @IDs + ',' 
    
    -- Indexes to keep the position of searching
    DECLARE @Pos1 bigInt
    DECLARE @Pos2 bigInt
 
    -- Start from first character 
    SET @Pos1 = 1
    SET @Pos2 = 1

    WHILE @Pos1 < Len(@IDs)
        BEGIN
            SET @Pos1 = CharIndex(',', @IDs, @Pos1)

            INSERT @Tbl_IDs SELECT CAST ( Substring(@IDs,@Pos2,@Pos1-@Pos2) AS Int)

            -- Go to next non comma character
            SET @Pos2 = @Pos1 + 1

            -- Search from the next charcater
            SET @Pos1 = @Pos1 + 1
        END 
    RETURN
END