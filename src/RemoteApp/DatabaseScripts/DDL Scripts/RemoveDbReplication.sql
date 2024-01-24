DECLARE @oltdb as sysname;
SET @oltdb = N'$(SqlDatabase)';

IF EXISTS (SELECT * FROM sys.databases where [name]=@oltdb and is_published = 1)
	BEGIN
    EXEC sp_removedbreplication @oltdb
  END
GO

