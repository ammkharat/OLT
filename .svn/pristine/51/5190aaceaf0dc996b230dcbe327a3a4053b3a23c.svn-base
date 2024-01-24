  
  
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryUserPrintPreferenceByUserId')
    BEGIN
        DROP PROCEDURE [dbo].QueryUserPrintPreferenceByUserId
    END
GO     

CREATE Procedure [dbo].[QueryUserPrintPreferenceByUserId]  
 (  
  @UserId bigint  
 )  
AS  
  
SELECT  
 Id,   
 UserId,   
 PrinterName,   
 NumberOfCopies,   
 NumberOfTurnaroundCopies,  
 ShowPrintDialog,  
 ShowShifthandoverAlertDialog, --RITM0387753-Shift Handover creation alert(Aarti)  
 ShowSoundAlertforActionItemDirectiveTargets  -- DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
FROM  
 UserPrintPreference  
WHERE  
 UserId = @UserId 

GRANT EXEC ON QueryUserPrintPreferenceByUserId TO PUBLIC 