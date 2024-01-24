
  
IF OBJECT_ID('GetNewSeqVal_PermitRequestFortHillsBatchIdSequence', 'P') IS NOT NULL
DROP PROC GetNewSeqVal_PermitRequestFortHillsBatchIdSequence
GO 


    
CREATE Procedure [dbo].GetNewSeqVal_PermitRequestFortHillsBatchIdSequence    
(    
 @Id bigint Output    
)    
AS    
    
begin    
    
 set NOCOUNT ON    
     
 insert into PermitRequestFortHillsBatchIdSequence (SeqVal) values ('a')    
     
 set @Id = scope_identity()         
     
 delete from PermitRequestFortHillsBatchIdSequence WITH (READPAST)    
    
end 


GRANT EXEC ON GetNewSeqVal_PermitRequestFortHillsBatchIdSequence TO PUBLIC   