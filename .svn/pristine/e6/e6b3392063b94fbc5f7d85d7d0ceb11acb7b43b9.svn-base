if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN75BIsolation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN75BIsolation]
GO

Create Procedure [dbo].[UpdateFormGN75BIsolation]
(
	@Id bigint,
	@FormGN75BId bigint,
	@DisplayOrder int,
	@IsolationType VARCHAR(100),
	@LocationOfEnergyIsolation VARCHAR(500),
	@DevicePosition varchar(50),
	@siteid bigint
)
AS

UPDATE FormGN75BIsolationItem
SET
	FormGN75BId = @FormGN75BId,
	DisplayOrder = @DisplayOrder,
	IsolationType = @IsolationType,
	LocationOfEnergyIsolation = @LocationOfEnergyIsolation
WHERE
	Id = @Id
go

GRANT EXEC ON UpdateFormGN75BIsolation TO PUBLIC
GO