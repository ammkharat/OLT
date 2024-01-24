    
     
  
IF OBJECT_ID('GetNewSeqVal_WorkPermitFortHillsPermitNumberSequence', 'P') IS NOT NULL
DROP PROC GetNewSeqVal_WorkPermitFortHillsPermitNumberSequence
GO 



CREATE Procedure [dbo].GetNewSeqVal_WorkPermitFortHillsPermitNumberSequence    
AS    
    
begin    
    
 declare @NewSeqValue bigint    
    
 set NOCOUNT ON    
    
 insert into WorkPermitFortHillsPermitNumberSequence (SeqVal) values ('z')    
    
 set @NewSeqValue = scope_identity()         
    
 delete from WorkPermitFortHillsPermitNumberSequence WITH (READPAST)    
    
 return @NewSeqValue    
    
end

GRANT EXEC ON GetNewSeqVal_WorkPermitFortHillsPermitNumberSequence TO PUBLIC  