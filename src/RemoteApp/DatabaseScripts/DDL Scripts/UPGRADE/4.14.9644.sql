ALTER TABLE FunctionalLocation
  ADD Source tinyint NULL;
GO
  
UPDATE FunctionalLocation
  SET Source = 1;
GO

ALTER TABLE FunctionalLocation 
  ALTER COLUMN Source tinyint NOT NULL;
GO


GO

