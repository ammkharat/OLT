IF @@SERVERNAME <> 'SQLPRDCGY130A' 
BEGIN
PRINT '*** FOLLOWING SCRIPTS ONLY FOR NON PROD DATABASES ***'
PRINT '*** Process to disable target definitions on local DB. ***'
PRINT '*** NOTE: These steps can also be followed on any DB which is updating Pi Targets in prod system in any unusual way.'
	IF DB_NAME() <> 'COLTPRD'
		
		PRINT '*** Step1:Update TargetDefinition Table ***'
		UPDATE dbo.TargetDefinition
		SET Deleted=1
		WHERE Deleted=0
		
		PRINT '*** Step2: Update  ScadaConnectionInfo Table ***'
				
		IF  EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'dbo.[ScadaConnectionInfo]') and OBJECTPROPERTY(id, N'IsTable') = 1)
			BEGIN
			    PRINT '*** ------------PI ------------ ***'
				UPDATE dbo.ScadaConnectionInfo
				SET PiUsername='OLT_disabled'
				WHERE Description='PI' AND PiUsername='OLT'
		
				UPDATE dbo.ScadaConnectionInfo
				SET PiUsername='PIOLTadmin_disabled'
				WHERE Description='PI' AND PiUsername='PIOLTadmin'

				UPDATE dbo.ScadaConnectionInfo
				SET PiUsername='OLTClient_disabled'
				WHERE Description='PI' AND PiUsername='OLTClient'

		
				PRINT '*** -------------PHD ------------ ***'

				update dbo.scadaconnectioninfo 
				set PhdUsername='NETWORK\OLTPHD_diasbled' 
				WHERE Description='PHD' AND PhdUsername='NETWORK\OLTPHD' 
		
				update dbo.scadaconnectioninfo 
				set PhdUsername='PHD_READONLY_disabled' 
				WHERE Description='PHD' AND PhdUsername='PHD_READONLY' 
		
				update dbo.scadaconnectioninfo 
				set PhdUsername='NETWORK\sarhwacc_disabled' 
				WHERE Description='PHD' AND PhdUsername='NETWORK\sarhwacc' 
		
			END
		
		RETURN
		
		PRINT '*** Cross check with below SQLs if above queries worked as per requirement:'
		PRINT '*** Select * from TargetDefinition with (NOLOCK)'
		PRINT '*** Select * from ScadaConnectionInfo with (NOLOCK)'
	    PRINT '*** Select * from scadaconnectioninfo a WHERE Description=PI ***'
		PRINT '*** Select * from scadaconnectioninfo a WHERE Description=PHD ***'
		PRINT '*** Select @@SERVERNAME, DB_NAME() ***'

		RETURN
End
Go


GO

