if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryWorkPermitEdmontonLatestExpirationDateByPermitRequestId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryWorkPermitEdmontonLatestExpirationDateByPermitRequestId]
GO

CREATE Procedure [dbo].[QueryWorkPermitEdmontonLatestExpirationDateByPermitRequestId]
(
	@PermitRequestId bigint
)
AS
select MAX(ExpiredDateTime) as LatestExpiryDateTime from WorkPermitEdmonton where PermitRequestId = @PermitRequestId
