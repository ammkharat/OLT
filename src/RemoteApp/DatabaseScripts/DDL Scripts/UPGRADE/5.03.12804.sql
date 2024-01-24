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


IF not EXISTS (
select * from GasTestElementInfo where  Name like 'Other (1)' and SiteId = 1 AND		Deleted = 0
)
Begin
Insert Into [GasTestElementInfo] ( [Name],[Standard],[SiteId],[DisplayOrder],[ColdMaxValue],[ColdMinValue],[HotMaxValue],[HotMinValue],[CSEMaxValue],[CSEMinValue],[InertCSEMaxValue],
[InertCSEMinValue],[OtherLimits],[GasLimitUnitId],[RangedLimit],[DecimalPlaceCount])  VALUES (    'Other (1)',    1,    1,    10,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    1,    1)

End








GO

