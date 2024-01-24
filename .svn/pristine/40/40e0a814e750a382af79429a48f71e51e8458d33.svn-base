if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFormGN75BTemplateIsolation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UpdateFormGN75BTemplateIsolation]
GO
CREATE Procedure [dbo].[UpdateFormGN75BTemplateIsolation]
(
	@Id bigint,
	@FormGN75BId bigint,
	@DisplayOrder int,
	@IsolationType VARCHAR(100),
	@LocationOfEnergyIsolation VARCHAR(500),
	@DevicePosition varchar(50),
	@Siteid bigint
)
AS

UPDATE FormGN75BTemplateIsolationItem
SET
	FormGN75BTemplateId = @FormGN75BId,
	DisplayOrder = @DisplayOrder,
	IsolationType = @IsolationType,
	LocationOfEnergyIsolation = @LocationOfEnergyIsolation,
	DevicePosition = @DevicePosition,
	Siteid = @Siteid
WHERE
	Id = @Id
GO

GRANT EXEC ON UpdateFormGN75BTemplateIsolation TO PUBLIC
GO