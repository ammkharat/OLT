IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertGasTestElementInfoConfigurationHistory')
	BEGIN
		DROP  Procedure  InsertGasTestElementInfoConfigurationHistory
	END

GO

CREATE Procedure dbo.InsertGasTestElementInfoConfigurationHistory
	(
		@Id bigint OUTPUT,
		@Name VARCHAR(50),
		@SiteId bigint,
		@ColdMaxValue FLOAT = NULL,
		@ColdMinValue FLOAT = NULL,
		@HotMaxValue FLOAT = NULL,
		@HotMinValue FLOAT = NULL,
		@CSEMaxValue FLOAT = NULL,
		@CSEMinValue FLOAT = NULL,
		@InertCSEMaxValue FLOAT = NULL,
		@InertCSEMinValue FLOAT = NULL,
		@DisplayOrder int = NULL,
		@GasLimitUnitId bigint = NULL,
		@RangedLimit BIT,
		@LastModifiedUserId bigint,
		@LastModifiedDateTime datetime,
		@DecimalPlaceCount int
	)

AS
INSERT INTO [GasTestElementInfoConfigurationHistory]
(
    [Name],
    [SiteId],
    [ColdMaxValue],
    [ColdMinValue],
    [HotMaxValue],
    [HotMinValue],
    [CSEMaxValue],
    [CSEMinValue],
    [InertCSEMaxValue],
    [InertCSEMinValue],
    [DisplayOrder],
    [GasLimitUnitId],
    [RangedLimit],
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [DecimalPlaceCount]
)
VALUES
(
    @Name,
    @SiteId,
    @ColdMaxValue,
    @ColdMinValue,
    @HotMaxValue,
    @HotMinValue,
    @CSEMaxValue,
    @CSEMinValue,
    @InertCSEMaxValue,
    @InertCSEMinValue,
    @DisplayOrder,
    @GasLimitUnitId,
    @RangedLimit,
    @LastModifiedUserId,
    @LastModifiedDateTime,
    @DecimalPlaceCount
)

SET @Id= SCOPE_IDENTITY() 

GO

GRANT EXEC ON [InsertGasTestElementInfoConfigurationHistory] TO PUBLIC

GO