if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormMudsTemporaryInstallationById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormMudsTemporaryInstallationById]
GO

  
CREATE Procedure [dbo].[QueryFormMudsTemporaryInstallationById]  
(  
 @Id bigint  
)  
AS  
select form.*  
from FormMudsTemporaryInstallation form  
where form.Id = @Id  



GRANT EXEC ON QueryFormMudsTemporaryInstallationById TO PUBLIC
GO


