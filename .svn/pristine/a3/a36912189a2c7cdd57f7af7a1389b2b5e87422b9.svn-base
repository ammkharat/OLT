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
select * from GasTestElementInfo where  Name like '%Test 1' and SiteId = 1
)
Begin
Insert Into [GasTestElementInfo] ( [Name],[Standard],[SiteId],[DisplayOrder],[ColdMaxValue],[ColdMinValue],[HotMaxValue],[HotMinValue],[CSEMaxValue],[CSEMinValue],[InertCSEMaxValue],
[InertCSEMinValue],[OtherLimits],[GasLimitUnitId],[RangedLimit],[DecimalPlaceCount])  VALUES (    'Test 1',    1,    1,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    1,    1)

End


IF not EXISTS (
select * from GasTestElementInfo where  Name like '%Test 2' and SiteId = 1
)
Begin
Insert Into [GasTestElementInfo] ( [Name],[Standard],[SiteId],[DisplayOrder],[ColdMaxValue],[ColdMinValue],[HotMaxValue],[HotMinValue],[CSEMaxValue],[CSEMinValue],[InertCSEMaxValue],
[InertCSEMinValue],[OtherLimits],[GasLimitUnitId],[RangedLimit],[DecimalPlaceCount]) VALUES  (    'Test 2',    1,    1,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    NULL,    1,    1)

End








GO

