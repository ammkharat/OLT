if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSarniaEipIssueApproverStoredProcedure]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[GetSarniaEipIssueApproverStoredProcedure]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetSarniaEipIssueApproverStoredProcedure]
	(
		@SiteId bigint,
		@RoleElementName varchar(100)
	)
AS

select r.name 
from role r 
inner join RoleElementTemplate ret on r.id = ret.RoleId 
inner join RoleElement re on ret.RoleElementId = re.Id 
where r.SiteId = 1 and re.name = 'Approve Sarnia Eip Issue'

OPTION (OPTIMIZE FOR UNKNOWN)  
