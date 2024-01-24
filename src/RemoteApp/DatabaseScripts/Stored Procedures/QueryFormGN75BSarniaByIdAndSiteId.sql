if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormGN75BSarniaByIdAndSiteId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormGN75BSarniaByIdAndSiteId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[QueryFormGN75BSarniaByIdAndSiteId] (@Id bigint,@siteid bigint)
AS
select 
f.id,
f.FormStatusId
,f.FunctionalLocationId
,f.CreatedByUserId
,f.CreatedDateTime
,f.LastModifiedByUserId
,f.LastModifiedDateTime
,f.ClosedDateTime
,f.Deleted
,f.templateid
,t.[Location]
,f.BlindsRequired
,f.DeadLeg
,f.DeadLegRisk
,f.SpecialPrecautions
,t.EquipmentType
,f.siteid
,t.SchematicImage
,t.PathToSchematic
,fl.[Description] as [FlocDesc]
from FormGN75BSarnia f 
inner join FormGN75BTemplate t on f.templateid = t.Id 
inner join FunctionalLocation fl on f.FunctionalLocationId = fl.Id
where f.Id = @Id and f.siteid = @siteid

go
GRANT EXEC ON [QueryFormGN75BSarniaByIdAndSiteId] TO PUBLIC
go



