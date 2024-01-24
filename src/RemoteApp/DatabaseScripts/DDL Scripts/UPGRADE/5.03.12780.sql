IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermit]') AND name = 'IsControlRoomContactedOrNot'
)
begin
ALTER TABLE WorkPermit ADD IsControlRoomContactedOrNot Bit
end
Go



IF NOT EXISTS (
  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitHistory]') AND name = 'IsControlRoomContactedOrNot'
)
begin
ALTER TABLE WorkPermitHistory ADD IsControlRoomContactedOrNot Bit 
end
Go





GO

