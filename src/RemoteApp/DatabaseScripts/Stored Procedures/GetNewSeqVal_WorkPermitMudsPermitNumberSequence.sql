
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_WorkPermitMudsPermitNumberSequence')
	BEGIN
		DROP Procedure [dbo].GetNewSeqVal_WorkPermitMudsPermitNumberSequence
	END
GO

CREATE Procedure [dbo].[GetNewSeqVal_WorkPermitMudsPermitNumberSequence]  
AS  
  
begin  
  
 declare @NewSeqValue int  
  
 set NOCOUNT ON  
  
 insert into WorkPermitMudsPermitNumberSequence (SeqVal) values ('a')  
  
 set @NewSeqValue = scope_identity()       
  
 delete from WorkPermitMudsPermitNumberSequence WITH (READPAST)  
  
 return @NewSeqValue  
  
end
GO


GRANT EXEC ON GetNewSeqVal_WorkPermitMudsPermitNumberSequence TO PUBLIC
GO

