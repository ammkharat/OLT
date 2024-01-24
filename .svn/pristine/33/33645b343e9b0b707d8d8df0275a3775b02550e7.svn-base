IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetScanConfiguration')
	BEGIN
		DROP PROCEDURE [dbo].GetScanConfiguration
	END
	
GO
CREATE  Procedure [dbo].[GetScanConfiguration]
(
 
 @UserLogin Varchar(50)=NULL,
 @SiteId Int=null
 
)
AS
Declare @Database varchar(50);
if(@Database='COLTPRD')
begin
SELECT * FROm ScanConfiguration WHERE Environment='PROD'
end
--NON-PROD
else
begin
SELECT * FROm ScanConfiguration WHERE Environment='NON-PROD'

end



GRANT EXEC ON GetScanConfiguration TO PUBLIC   
