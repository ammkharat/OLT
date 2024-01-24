if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFormGN75BTemplateIsolation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertFormGN75BTemplateIsolation]
GO


create Procedure [dbo].[InsertFormGN75BTemplateIsolation]
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

INSERT INTO FormGN75BTemplateIsolationItem
(
	FormGN75BTemplateId,
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

