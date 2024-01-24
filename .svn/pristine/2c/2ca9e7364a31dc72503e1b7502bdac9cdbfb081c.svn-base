  
    
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertUserPrintPreference')
    BEGIN
        DROP PROCEDURE [dbo].InsertUserPrintPreference
    END
GO   

CREATE Procedure [dbo].[InsertUserPrintPreference]  
(  
 @Id bigint output,  
 @UserId bigint,  
 @PrinterName varchar(125) = null,  
 @NumberOfCopies int,  
 @NumberOfTurnaroundCopies int,  
 @ShowPrintDialog bit,  
 @ShowShiftHandoverAlertDialog bit, --RITM0387753-Shift Handover creation alert(Aarti)  
 @ShowSoundAlertforActionItemDirectiveTargets bit -- // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
)  
AS  
  
INSERT INTO UserPrintPreference  
 (  
  UserId,  
  PrinterName,  
  NumberOfCopies,  
  NumberOfTurnaroundCopies,  
  ShowPrintDialog,  
  ShowShiftHandoverAlertDialog, --RITM0387753-Shift Handover creation alert(Aarti)  
  ShowSoundAlertforActionItemDirectiveTargets -- // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
 )  
VALUES   
 (  
  @UserId,    
  @PrinterName,  
  @NumberOfCopies,   
  @NumberOfTurnaroundCopies,   
  @ShowPrintDialog,  
  @ShowShiftHandoverAlertDialog, --RITM0387753-Shift Handover creation alert(Aarti) 
  @ShowSoundAlertforActionItemDirectiveTargets  -- // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
 )  
  
SET @Id= SCOPE_IDENTITY()   


GRANT EXEC ON InsertUserPrintPreference TO PUBLIC 