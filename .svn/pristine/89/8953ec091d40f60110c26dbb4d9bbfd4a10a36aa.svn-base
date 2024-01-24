insert into ScadaConnectionInfo (
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
  ,MockTagWrites
  ,LastModifiedDateTime
  ,ScadaConnectionTypeId
  ,[Description]
  ,PiUsername
  ,PiPassword
  ,PiServer
  ,Id
) SELECT 
   13   AS SiteId                  -- SiteId - bigint
  ,PhdUsername AS PhdUsername            -- PhdUsername - varchar(50)
  ,PhdPassword AS PhdPassword            -- PhdPassword - varchar(50)
  ,PhdServer AS PhdServer              -- PhdServer - varchar(200)
  ,ApiVersion AS ApiVersion             -- ApiVersion - varchar(50)
  ,UseWindowsAuthentication AS UseWindowsAuthentication -- UseWindowsAuthentication - bit
  ,DatabaseType AS DatabaseType           -- DatabaseType - varchar(20)
  ,DatabaseUsername AS DatabaseUsername       -- DatabaseUsername - varchar(200)
  ,DatabasePassword AS DatabasePassword       -- DatabasePassword - varchar(200)
  ,DatabaseServer AS DatabaseServer         -- DatabaseServer - varchar(200)
  ,DatabaseInstance AS DatabaseInstance       -- DatabaseInstance - varchar(200)
  ,StartTimeOffset AS StartTimeOffset        -- StartTimeOffset - int
  ,EndTimeOffset AS EndTimeOffset          -- EndTimeOffset - int
  ,SampleType AS SampleType             -- SampleType - varchar(50)
  ,SampleFrequency AS SampleFrequency        -- SampleFrequency - int
  ,DataReductionType AS DataReductionType      -- DataReductionType - varchar(50)
  ,DataReductionFrequency AS DataReductionFrequency -- DataReductionFrequency - int
  ,DataReductionOffset AS DataReductionOffset    -- DataReductionOffset - varchar(50)
  ,MinimumConfidence AS MinimumConfidence      -- MinimumConfidence - int
  ,MockTagWrites AS MockTagWrites          -- MockTagWrites - bit
  ,getdate() AS LastModifiedDateTime -- LastModifiedDateTime - datetime
  ,0   AS ScadaConnectionTypeId   -- ScadaConnectionTypeId - tinyint
  ,'PHD'  AS [Description]           -- Description - varchar(150)
  ,PiUsername AS PiUsername             -- PiUsername - varchar(50)
  ,PiPassword AS PiPassword             -- PiPassword - varchar(50)
  ,PiServer AS PiServer               -- PiServer - varchar(250)
  ,10              -- Id - bigint
FROM
ScadaConnectionInfo where SiteId = 3 and ScadaConnectionTypeId = 0	


GO

