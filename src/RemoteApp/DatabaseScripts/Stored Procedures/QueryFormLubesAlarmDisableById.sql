if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormLubesAlarmDisableById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormLubesAlarmDisableById]
GO

CREATE Procedure [dbo].[QueryFormLubesAlarmDisableById]
(
	@Id bigint
)
AS
select form.*
from FormLubesAlarmDisable form
where form.Id = @Id