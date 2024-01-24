if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEdmontonPerson]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertEdmontonPerson]
GO

CREATE Procedure [dbo].[InsertEdmontonPerson]
(
	@Id bigint Output,
	@LastName VARCHAR(50),
	@FirstName VARCHAR(50),
	@BadgeId VARCHAR(50),
	@LastScan DATETIME,
	@ScanStatus bit
)
AS

INSERT INTO EdmontonPerson
(
	LastName,
	FirstName,
	BadgeId,
	LastScan,
	ScanStatus,
	Deleted
)
VALUES
(
	@LastName,
	@FirstName,
	@BadgeId,
	@LastScan,
	@ScanStatus,
	0
);

SET @Id=SCOPE_IDENTITY(); 
GO