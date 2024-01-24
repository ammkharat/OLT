
  
    
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateUserPrintPreference')
    BEGIN
        DROP PROCEDURE [dbo].UpdateUserPrintPreference
    END
GO  
  
CREATE Procedure [dbo].[UpdateUserPrintPreference]  
(  
 @Id bigint,  
 @UserId bigint,  
 @PrinterName varchar(125) = null,  
 @NumberOfCopies int,  
 @NumberOfTurnaroundCopies int,  
 @ShowPrintDialog bit,  
 @ShowShifthandoverAlertDialog bit, --RITM0387753-Shift Handover creation alert(Aarti)  
 @ShowSoundAlertforActionItemDirectiveTargets bit -- // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
 
)  
AS  
  
UPDATE    UserPrintPreference  
SET                
 UserId = @UserId,  
 PrinterName = @PrinterName,  
 NumberOfCopies = @NumberOfCopies,  
 NumberOfTurnaroundCopies = @NumberOfTurnaroundCopies,   
 ShowPrintDialog = @ShowPrintDialog,  
 ShowShifthandoverAlertDialog= @ShowShifthandoverAlertDialog, --RITM0387753-Shift Handover creation alert(Aarti)  
 ShowSoundAlertforActionItemDirectiveTargets  = @ShowSoundAlertforActionItemDirectiveTargets  -- // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
WHERE     (Id = @Id) 


GRANT EXEC ON UpdateUserPrintPreference TO PUBLIC  