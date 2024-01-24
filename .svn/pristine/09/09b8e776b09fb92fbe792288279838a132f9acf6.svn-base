if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateEdmontonPerson]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateEdmontonPerson]
GO

CREATE Procedure [dbo].[UpdateEdmontonPerson]
(
	@Id bigint,
	@BadgeId VARCHAR(50),
	@LastScan DATETIME,
	@ScanStatus bit
)
AS

UPDATE EdmontonPerson
	SET 
		BadgeId = @BadgeId,
		LastScan = @LastScan,
		ScanStatus = @ScanStatus
	WHERE
		Id = @Id
GO