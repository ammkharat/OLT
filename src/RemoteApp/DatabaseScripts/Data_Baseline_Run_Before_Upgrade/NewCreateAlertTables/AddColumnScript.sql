
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[SiteConfiguration]') 
         AND name = 'AllowEditingOfOldLogs'
)
BEGIN
ALTER TABLE SiteConfiguration ADD AllowEditingOfOldLogs BIT NOT NULL DEFAULT '0'
END

--DMND0010303 by ppanigrahi

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestion]') 
         AND name = 'EmailList'
)
BEGIN
ALTER TABLE ShiftHandoverQuestion ADD EmailList varchar(500) 
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[ShiftHandoverQuestion]') 
         AND name = 'YesNo'
)
BEGIN

ALTER TABLE ShiftHandoverQuestion ADD YesNo varchar(50) 

--Update ShiftHandoverquestion set YesNo='Yes' where YesNo IS NULL

END

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontreal]') AND name = 'ClonedFormDetailMontreal'
)
begin
ALTER TABLE WorkPermitMontreal ADD ClonedFormDetailMontreal varchar(100)
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitEdmonton]') AND name = 'ClonedFormDetailEdmonton'
)
begin
ALTER TABLE WorkPermitEdmonton ADD ClonedFormDetailEdmonton varchar(100)
end
Go

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[Formop14]') AND name = 'isMailSent'
)
begin
ALTER TABLE FormOP14 ADD isMailSent Bit DEFAULT NULL
end
GO


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'RevalidationDateTime'
)
BEGIN
ALTER TABLE WorkPermit ADD RevalidationDateTime datetime DEFAULT NULL
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'ExtensionDateTime'
)
BEGIN
ALTER TABLE WorkPermit ADD ExtensionDateTime datetime DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'ExtensionRevalidationDateTime'
)
BEGIN
ALTER TABLE WorkPermit ADD ExtensionRevalidationDateTime datetime DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') 
         AND name = 'Revalidation'
)
BEGIN
ALTER TABLE WorkPermitHistory ADD Revalidation int DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'Revalidation'
)
BEGIN
ALTER TABLE WorkPermit ADD Revalidation int DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'ExtensionTimeIssuer'
)
BEGIN
ALTER TABLE WorkPermit ADD ExtensionTimeIssuer DateTime DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'ExtensionTimeNonIssuer'
)
BEGIN
ALTER TABLE WorkPermit ADD ExtensionTimeNonIssuer DateTime DEFAULT NULL
END

 

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'ISSUER_SOURCEXTENSION'
)
BEGIN
ALTER TABLE WorkPermit ADD ISSUER_SOURCEXTENSION varchar(50) DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'ExtensionEnable'
)
BEGIN
ALTER TABLE WorkPermit ADD ExtensionEnable bit DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'RevalidationEnable'
)
BEGIN
ALTER TABLE WorkPermit ADD RevalidationEnable bit DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'BeforeExtensionDateTime'
)
BEGIN
ALTER TABLE WorkPermit ADD BeforeExtensionDateTime datetime DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'Extension'
)
BEGIN
ALTER TABLE WorkPermit ADD Extension int DEFAULT NULL
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'MidExtensionvalueIssuer'
)
BEGIN
ALTER TABLE WorkPermit ADD  MidExtensionvalueIssuer datetime DEFAULT NULL
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') 
         AND name = 'MidExtensionvaluenonIssuer'
)
BEGIN
ALTER TABLE WorkPermit ADD  MidExtensionvaluenonIssuer datetime DEFAULT NULL
END

IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[FormOP14Approval]') AND name = 'isMailSent'
)
begin
ALTER TABLE FormOP14Approval ADD isMailSent Bit 
end





 






