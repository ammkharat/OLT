CREATE TABLE [dbo].[HoneywellPhdConnectionInfo] (
[SiteId] bigint NOT NULL,
[PhdUsername] VARCHAR(50) NOT NULL,
[PhdPassword] VARCHAR(50) NOT NULL,
[PhdServer] VARCHAR(200) NOT NULL,
[ApiVersion] VARCHAR(50) NOT NULL,
[UseWindowsAuthentication] bit NOT NULL,
[DatabaseType] VARCHAR(20) NOT NULL,
[DatabaseUsername] VARCHAR(200) NOT NULL,
[DatabasePassword] VARCHAR(200) NOT NULL,
[DatabaseServer] VARCHAR(200) NOT NULL,
[DatabaseInstance] VARCHAR(200) NOT NULL,
[StartTimeOffset] int NOT NULL,
[EndTimeOffset] int NOT NULL,
[SampleType] VARCHAR(50) NOT NULL,
[SampleFrequency] int NULL,
[DataReductionType] VARCHAR(50) NULL,
[DataReductionFrequency] int NULL,
[DataReductionOffset] VARCHAR(50) NULL,
[MinimumConfidence] int NOT NULL,
[AllowTagWrites] bit NOT NULL,
[MockTagWrites] bit NOT NULL,
[LastModifiedDateTime] DATETIME NOT NULL,
CONSTRAINT [PK_HoneywellPhdConnectionInfo] PRIMARY KEY CLUSTERED ([SiteId] )
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[HoneywellPhdConnectionInfo]
 ADD CONSTRAINT [FK_HoneywellPhdConnection_Site] FOREIGN KEY ([SiteId])
		REFERENCES [dbo].[Site] ([Id])

INSERT INTO HoneywellPhdConnectionInfo (
   SiteId
  ,PhdUsername
  ,PhdPassword
  ,PhdServer
  ,ApiVersion
  ,UseWindowsAuthentication
  ,DatabaseType
  ,DatabaseUsername
  ,DatabasePassword
  ,DatabaseServer
  ,DatabaseInstance
  ,StartTimeOffset
  ,EndTimeOffset
  ,SampleType
  ,SampleFrequency
  ,DataReductionType
  ,DataReductionFrequency
  ,DataReductionOffset
  ,MinimumConfidence
  ,AllowTagWrites
  ,MockTagWrites
  ,LastModifiedDateTime
) VALUES (
   1   -- SiteId - bigint
  ,'NETWORK\sarhwacc'  -- PhdUsername - varchar(50)
  ,'S@rni@01Hny'  -- PhdPassword - varchar(50)
  ,'PHDPRD201.NETWORK.LAN'  -- PhdServer - varchar(200)
  ,'RAPI200'  -- ApiVersion - varchar(50)
  ,1   -- UseWindowsAuthentication - bit
  ,'Oracle'   -- DatabaseType - VARCHAR(20)
  ,'PHD_READONLY'  -- DatabaseUsername - varchar(200)
  ,'PHD_READONLY'  -- DatabasePassword - varchar(200)
  ,'PDBPRDSAR.NETWORK.LAN'  -- DatabaseServer - varchar(200)
  ,'SARPDPRD'  -- DatabaseInstance - varchar(200)
  ,5   -- StartTimeOffset - int
  ,1   -- EndTimeOffset - int
  ,'Average'  -- SampleType - varchar(50)
  ,5 -- SampleFrequency - int
  ,'Last' -- DataReductionType - varchar(50)
  ,3600 -- DataReductionFrequency - int
  ,'Before' -- DataReductionOffset - varchar(50)
  ,0   -- MinimumConfidence - int
  ,1   -- AllowTagWrites - bit
  ,0   -- MockTagWrites - bit
  ,getdate()
)

INSERT INTO HoneywellPhdConnectionInfo (
   SiteId
  ,PhdUsername
  ,PhdPassword
  ,PhdServer
  ,ApiVersion
  ,UseWindowsAuthentication
  ,DatabaseType
  ,DatabaseUsername
  ,DatabasePassword
  ,DatabaseServer
  ,DatabaseInstance
  ,StartTimeOffset
  ,EndTimeOffset
  ,SampleType
  ,SampleFrequency
  ,DataReductionType
  ,DataReductionFrequency
  ,DataReductionOffset
  ,MinimumConfidence
  ,AllowTagWrites
  ,MockTagWrites
  ,LastModifiedDateTime
) VALUES (
   3   -- SiteId - bigint
  ,'NETWORK\OLTPHD'  -- PhdUsername - varchar(50)
  ,'Uyd2R171KaNqyOR'  -- PhdPassword - varchar(50)
  ,'PHDPRDFMM003V1.NETWORK.LAN'  -- PhdServer - varchar(200)
  ,'RAPI200'  -- ApiVersion - varchar(50)
  ,1   -- UseWindowsAuthentication - bit
  ,'SqlServer'   -- DatabaseType - VARCHAR(20)
  ,'Phdoilsandsread'  -- DatabaseUsername - varchar(200)
  ,'oilphds8nds'  -- DatabasePassword - varchar(200)
  ,'PHD310SQL.network.lan'  -- DatabaseServer - varchar(200)
  ,'PHDCFG'  -- DatabaseInstance - varchar(200)
  ,5   -- StartTimeOffset - int
  ,1   -- EndTimeOffset - int
  ,'Average'  -- SampleType - varchar(50)
  ,5 -- SampleFrequency - int
  ,'Last' -- DataReductionType - varchar(50)
  ,3600 -- DataReductionFrequency - int
  ,'Before' -- DataReductionOffset - varchar(50)
  ,0   -- MinimumConfidence - int
  ,0   -- AllowTagWrites - bit
  ,0   -- MockTagWrites - bit
  ,getdate()
)

INSERT INTO HoneywellPhdConnectionInfo (
   SiteId
  ,PhdUsername
  ,PhdPassword
  ,PhdServer
  ,ApiVersion
  ,UseWindowsAuthentication
  ,DatabaseType
  ,DatabaseUsername
  ,DatabasePassword
  ,DatabaseServer
  ,DatabaseInstance
  ,StartTimeOffset
  ,EndTimeOffset
  ,SampleType
  ,SampleFrequency
  ,DataReductionType
  ,DataReductionFrequency
  ,DataReductionOffset
  ,MinimumConfidence
  ,AllowTagWrites
  ,MockTagWrites
  ,LastModifiedDateTime
) VALUES (
   6   -- SiteId - bigint
  ,'NETWORK\OLTPHD'  -- PhdUsername - varchar(50)
  ,'Uyd2R171KaNqyOR'  -- PhdPassword - varchar(50)
  ,'PHDPRDFMM003V1.NETWORK.LAN'  -- PhdServer - varchar(200)
  ,'RAPI200'  -- ApiVersion - varchar(50)
  ,1   -- UseWindowsAuthentication - bit
  ,'SqlServer'   -- DatabaseType - VARCHAR(20)
  ,'Phdoilsandsread'  -- DatabaseUsername - varchar(200)
  ,'oilphds8nds'  -- DatabasePassword - varchar(200)
  ,'PHD310SQL.network.lan'  -- DatabaseServer - varchar(200)
  ,'PHDCFG'  -- DatabaseInstance - varchar(200)
  ,5   -- StartTimeOffset - int
  ,1   -- EndTimeOffset - int
  ,'Average'  -- SampleType - varchar(50)
  ,5 -- SampleFrequency - int
  ,'Last' -- DataReductionType - varchar(50)
  ,3600 -- DataReductionFrequency - int
  ,'Before' -- DataReductionOffset - varchar(50)
  ,0   -- MinimumConfidence - int
  ,0   -- AllowTagWrites - bit
  ,0   -- MockTagWrites - bit
  ,getdate()
)

INSERT INTO HoneywellPhdConnectionInfo (
   SiteId
  ,PhdUsername
  ,PhdPassword
  ,PhdServer
  ,ApiVersion
  ,UseWindowsAuthentication
  ,DatabaseType
  ,DatabaseUsername
  ,DatabasePassword
  ,DatabaseServer
  ,DatabaseInstance
  ,StartTimeOffset
  ,EndTimeOffset
  ,SampleType
  ,SampleFrequency
  ,DataReductionType
  ,DataReductionFrequency
  ,DataReductionOffset
  ,MinimumConfidence
  ,AllowTagWrites
  ,MockTagWrites
  ,LastModifiedDateTime
) VALUES (
   9   -- SiteId - bigint
  ,'PHD_READONLY'  -- PhdUsername - varchar(50)
  ,'PHD_READONLY'  -- PhdPassword - varchar(50)
  ,'PHDPRDMTL001.network.lan'  -- PhdServer - varchar(200)
  ,'DEFAULT'  -- ApiVersion - varchar(50)
  ,0   -- UseWindowsAuthentication - bit
  ,'Oracle'   -- DatabaseType - VARCHAR(20)
  ,'PHD_READONLY'  -- DatabaseUsername - varchar(200)
  ,'PHD_READONLY'  -- DatabasePassword - varchar(200)
  ,'BFLXPRDMTL001.network.lan'  -- DatabaseServer - varchar(200)
  ,'UNF'  -- DatabaseInstance - varchar(200)
  ,0   -- StartTimeOffset - int
  ,0   -- EndTimeOffset - int
  ,'Raw'  -- SampleType - varchar(50)
  ,null -- SampleFrequency - int
  ,null -- DataReductionType - varchar(50)
  ,null -- DataReductionFrequency - int
  ,null -- DataReductionOffset - varchar(50)
  ,100   -- MinimumConfidence - int
  ,0   -- AllowTagWrites - bit
  ,0   -- MockTagWrites - bit
  ,getdate()
)

INSERT INTO HoneywellPhdConnectionInfo (
   SiteId
  ,PhdUsername
  ,PhdPassword
  ,PhdServer
  ,ApiVersion
  ,UseWindowsAuthentication
  ,DatabaseType
  ,DatabaseUsername
  ,DatabasePassword
  ,DatabaseServer
  ,DatabaseInstance
  ,StartTimeOffset
  ,EndTimeOffset
  ,SampleType
  ,SampleFrequency
  ,DataReductionType
  ,DataReductionFrequency
  ,DataReductionOffset
  ,MinimumConfidence
  ,AllowTagWrites
  ,MockTagWrites
  ,LastModifiedDateTime
) VALUES (
   10   -- SiteId - bigint
  ,''  -- PhdUsername - varchar(50)
  ,''  -- PhdPassword - varchar(50)
  ,'MPNPHD.pcacorp.net'  -- PhdServer - varchar(200)
  ,'RAPI200'  -- ApiVersion - varchar(50)
  ,1   -- UseWindowsAuthentication - bit
  ,'Oracle'   -- DatabaseType - VARCHAR(20)
  ,'PHD_READONLY'  -- DatabaseUsername - varchar(200)
  ,'PHD_READONLY'  -- DatabasePassword - varchar(200)
  ,'MPNBFU.pcacorp.net'  -- DatabaseServer - varchar(200)
  ,'PRD'  -- DatabaseInstance - varchar(200)
  ,5   -- StartTimeOffset - int
  ,1   -- EndTimeOffset - int
  ,'Average'  -- SampleType - varchar(50)
  ,5 -- SampleFrequency - int
  ,'Last' -- DataReductionType - varchar(50)
  ,3600 -- DataReductionFrequency - int
  ,'Before' -- DataReductionOffset - varchar(50)
  ,0   -- MinimumConfidence - int
  ,0   -- AllowTagWrites - bit
  ,0   -- MockTagWrites - bit
  ,getdate()
)
GO


GO

