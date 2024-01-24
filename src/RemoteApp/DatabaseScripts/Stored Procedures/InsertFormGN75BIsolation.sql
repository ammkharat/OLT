if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN75BIsolation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN75BIsolation]
GO

CREATE Procedure [dbo].[InsertFormGN75BIsolation]
(
	@Id bigint Output,
	@FormGN75BId bigint,
	@DisplayOrder int,
	@IsolationType VARCHAR(100),
	@LocationOfEnergyIsolation VARCHAR(500),
	@DevicePosition varchar(20),
	@Siteid bigint
)
AS

INSERT INTO FormGN75BIsolationItem
(
	FormGN75BId,
	DisplayOrder,
	IsolationType,
	LocationOfEnergyIsolation,
	Deleted,
	DevicePosition,
	Siteid
)
VALUES
(
	@FormGN75BId,
	@DisplayOrder,
	@IsolationType,
	@LocationOfEnergyIsolation,
	0,
	@DevicePosition,
	@Siteid
);

SET @Id = scope_identity();

GO

GRANT EXEC ON InsertFormGN75BIsolation TO PUBLIC
GO