IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateHoneywellPhdConnectionInfo')
	BEGIN
		DROP  Procedure  UpdateHoneywellPhdConnectionInfo
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateScadaConnectionInfo')
	BEGIN
		DROP  Procedure  UpdateScadaConnectionInfo
	END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateScadaConnectionInfo')
	BEGIN
		DROP  Procedure  UpdateScadaConnectionInfo
	END

GO

CREATE Procedure [dbo].[UpdateScadaConnectionInfo]
	(
		@Id bigint,
		@PhdUsername VARCHAR(50),
		@PhdPassword VARCHAR(50),
		@PhdServer VARCHAR(200),
		@ApiVersion VARCHAR(50),
		@UseWindowsAuthentication bit,
		@DatabaseType VARCHAR(20),
		@DatabaseUsername VARCHAR(200),
		@DatabasePassword VARCHAR(200),
		@DatabaseServer VARCHAR(200),
		@PiUsername VARCHAR(200),
		@PiPassword VARCHAR(200),
		@PiServer VARCHAR(200),
		@DatabaseInstance VARCHAR(200),
		@StartTimeOffset int,
		@EndTimeOffset int,
		@SampleType VARCHAR(50),
		@SampleFrequency int,
		@DataReductionType VARCHAR(50),
		@DataReductionFrequency int,
		@DataReductionOffset VARCHAR(50),
		@MinimumConfidence int
	)
AS

UPDATE 
	ScadaConnectionInfo 
SET
  PhdUsername = @PhdUserName
  ,PhdPassword = @PhdPassword
  ,PhdServer = @PhdServer 
  ,ApiVersion = @ApiVersion 
  ,UseWindowsAuthentication = @UseWindowsAuthentication 
  ,DatabaseType = @DatabaseType 
  ,DatabaseUsername = @DatabaseUsername 
  ,DatabasePassword = @DatabasePassword 
  ,DatabaseServer = @DatabaseServer 
  ,PiUsername = @PiUsername 
  ,PiPassword = @PiPassword 
  ,PiServer = @PiServer 
  ,DatabaseInstance = @DatabaseInstance 
  ,StartTimeOffset = @StartTimeOffset 
  ,EndTimeOffset = @EndTimeOffset 
  ,SampleType = @SampleType
  ,SampleFrequency = @SampleFrequency 
  ,DataReductionType = @DataReductionType
  ,DataReductionFrequency = @DataReductionFrequency 
  ,DataReductionOffset = @DataReductionOffset 
  ,MinimumConfidence = @MinimumConfidence 
  ,LastModifiedDateTime = getdate() 
WHERE 
	Id = @Id
GO

GRANT EXEC ON UpdateScadaConnectionInfo TO PUBLIC
GO