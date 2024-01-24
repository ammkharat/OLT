
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ScanConfiguration]') AND type in (N'U'))
BEGIN
Create table ScanConfiguration
(ID int identity(1,1),
LocalScanPath varchar(500),
ScanExeName varchar(500),
ScanExePath varchar(500),
SharedPath Varchar(500),
Environment varchar(10),
DELETED bit default(0)

)
END

IF NOT EXISTS(SELECT * FROM ScanConfiguration)
BEGIN
INSERT ScanConfiguration(LocalScanPath,ScanExeName,ScanExePath,SharedPath,Environment)
SELECT 'C:\Scanpermit\','OLTSCAN','\\oltqutcgy002\LogImages\Debug\','C:\Permit\','PROD' UNION
SELECT 'C:\Scanpermit\','OLTSCAN','\\oltqutcgy002\LogImages\Debug\','C:\Permit\','NON-PROD'
END


