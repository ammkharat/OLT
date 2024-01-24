if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryAdminMemberList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryAdminMemberList]
GO
       
CREATE Procedure dbo.QueryAdminMemberList     
     
AS      
SELECT * FROM  OLTAdministrator   
Where Deleted = 0
GO

GRANT EXEC ON QueryAdminMemberList TO PUBLIC
GO 