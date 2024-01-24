IF NOT EXISTS(SELECT * FROM information_schema.columns WHERE table_name = 'FunctionalLocation' AND Column_name = 'Level')
BEGIN
	ALTER TABLE [dbo].[FunctionalLocation]
		ADD [Level] TINYINT NULL
END
GO

UPDATE [FunctionalLocation] SET [level]	= 1 
WHERE 
	[Division] IS NOT NULL 
	AND 
	[Section] IS NULL
GO

UPDATE [FunctionalLocation] SET [Level] = 2
WHERE 
	[Division] IS NOT NULL 
	AND 
	[Section] IS NOT NULL 
	AND 
	[Unit] IS NULL
GO	

UPDATE [FunctionalLocation] SET [Level] = 3
WHERE 
	[Division] IS NOT NULL 
	AND 
	[Section] IS NOT NULL 
	AND 
	[Unit] IS NOT NULL 
	AND 
	[Equipment1] IS NULL
GO	

UPDATE [FunctionalLocation] SET [Level] = 4
WHERE 
	[Division] IS NOT NULL 
	AND 
	[Section] IS NOT NULL 
	AND 
	[Unit] IS NOT NULL 
	AND 
	[Equipment1] IS NOT NULL
	AND
	[Equipment2] IS NULL
GO	
	
UPDATE [FunctionalLocation] SET [Level] = 5
WHERE 
	[Division] IS NOT NULL 
	AND 
	[Section] IS NOT NULL 
	AND 
	[Unit] IS NOT NULL 
	AND 
	[Equipment1] IS NOT NULL
	AND
	[Equipment2] IS NOT NULL
GO	
	
ALTER TABLE [dbo].[FunctionalLocation]
	ALTER COLUMN [Level] TINYINT NOT NULL;
GO	
