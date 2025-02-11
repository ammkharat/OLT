IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_RestrictionLocationItemIdSequence')
	BEGIN
		DROP PROCEDURE [dbo].[GetNewSeqVal_RestrictionLocationItemIdSequence]
	END
GO   

Create Procedure [dbo].GetNewSeqVal_RestrictionLocationItemIdSequence  
(  
 @Id bigint Output  
)  
AS  
  
begin  
  
 set NOCOUNT ON  
  
 insert into RestrictionLocationItemSequence (SeqVal) values ('a')  
  
 set @Id = scope_identity()       
   
 delete from RestrictionLocationItemSequence WITH (READPAST) 
 
 --Changed to fix the incident INC0374179 Added to set identity with Max value if aadedd item from Backend script
 WHILE  exists(SELECT * from RestrictionLocationItem where ID=@Id )
BEGIN
 insert into RestrictionLocationItemSequence (SeqVal) values ('a')  
 
 set @Id = scope_identity()
 delete from RestrictionLocationItemSequence WITH (READPAST) 
 
END 
--Changed to fix the incident INC0374179

end  
  
GRANT EXEC ON GetNewSeqVal_RestrictionLocationItemIdSequence TO PUBLIC 
 