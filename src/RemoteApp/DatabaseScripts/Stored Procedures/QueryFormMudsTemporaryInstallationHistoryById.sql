if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryFormMudsTemporaryInstallationHistoryById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryFormMudsTemporaryInstallationHistoryById]
GO

  
CREATE Procedure [dbo].[QueryFormMudsTemporaryInstallationHistoryById] (@Id bigint) AS  
select f.* from FormMudsTemporaryInstallationHistory f where f.Id = @Id ORDER BY LastModifiedDateTime 

 
GRANT EXEC ON QueryFormMudsTemporaryInstallationHistoryById TO PUBLIC
GO