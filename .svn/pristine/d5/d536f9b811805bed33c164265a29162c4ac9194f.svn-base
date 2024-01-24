
alter table WorkPermitEdmontonDetails add FlarePitEntry bit NULL;
go

update WorkPermitEdmontonDetails set FlarePitEntry = 1 where FlarePitEntryType is not null;
update WorkPermitEdmontonDetails set FlarePitEntry = 0 where FlarePitEntryType is null;
go

alter table WorkPermitEdmontonDetails alter column FlarePitEntry bit NOT NULL;
go

----

alter table WorkPermitEdmontonHistory add FlarePitEntry bit NULL;
go

update WorkPermitEdmontonHistory set FlarePitEntry = 1 where FlarePitEntryType is not null;
update WorkPermitEdmontonHistory set FlarePitEntry = 0 where FlarePitEntryType is null;
go

alter table WorkPermitEdmontonHistory alter column FlarePitEntry bit NOT NULL;
go

----------------------


alter table WorkPermitEdmontonDetails add AlkylationEntry bit NULL;
go

update WorkPermitEdmontonDetails set AlkylationEntry = 1 where AlkylationEntryClassOfClothing is not null;
update WorkPermitEdmontonDetails set AlkylationEntry = 0 where AlkylationEntryClassOfClothing is null;
go

alter table WorkPermitEdmontonDetails alter column AlkylationEntry bit NOT NULL;
go

---

alter table WorkPermitEdmontonHistory add AlkylationEntry bit NULL;
go

update WorkPermitEdmontonHistory set AlkylationEntry = 1 where AlkylationEntryClassOfClothing is not null;
update WorkPermitEdmontonHistory set AlkylationEntry = 0 where AlkylationEntryClassOfClothing is null;
go

alter table WorkPermitEdmontonHistory alter column AlkylationEntry bit NOT NULL;
go





GO

