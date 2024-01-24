if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitEdmontonById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitEdmontonById]
GO

CREATE Procedure [dbo].[QueryWorkPermitEdmontonById]
(
	@Id bigint
)
AS

select wpe.*, wped.*, sw.Id as SpecialWorkId, sw.CompanyName as SpecialWorkName from WorkPermitEdmonton wpe    
inner join WorkPermitEdmontonDetails wped on wpe.Id = wped.WorkPermitEdmontonId  
left outer join SpecialWork sw on wped.SpecialWorkType = sw.Id    
where wpe.Id = @Id 