

alter table dbo.WorkPermitEdmonton alter column Occupation varchar(50) null;
alter table dbo.WorkPermitEdmontonHistory alter column Occupation varchar(50) null;

alter table dbo.WorkPermitEdmonton alter column GroupId bigint null;
alter table dbo.WorkPermitEdmontonHistory alter column [Group] varchar(50) null;







GO



alter table WorkPermitEdmontonDetails add ConfinedSpace bit NULL;
go

update WorkPermitEdmontonDetails set ConfinedSpace = 1 where [ConfinedSpaceClass] is not null or [ConfinedSpaceCardNumber] is not null;
update WorkPermitEdmontonDetails set ConfinedSpace = 0 where ConfinedSpaceClass is null and ConfinedSpaceCardNumber is null;
go

alter table WorkPermitEdmontonDetails alter column ConfinedSpace bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add ConfinedSpace bit NULL;
go

update WorkPermitEdmontonHistory set ConfinedSpace = 1 where [ConfinedSpaceClass] is not null or [ConfinedSpaceCardNumber] is not null;
update WorkPermitEdmontonHistory set ConfinedSpace = 0 where ConfinedSpaceClass is null and ConfinedSpaceCardNumber is null;
go

alter table WorkPermitEdmontonHistory alter column ConfinedSpace bit NOT NULL;
go

----

alter table WorkPermitEdmontonDetails add RescuePlan bit NULL;
go

update WorkPermitEdmontonDetails set RescuePlan = 1 where [RescuePlanFormNumber] is not null;
update WorkPermitEdmontonDetails set RescuePlan = 0 where [RescuePlanFormNumber] is null;
go

alter table WorkPermitEdmontonDetails alter column RescuePlan bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add RescuePlan bit NULL;
go

update WorkPermitEdmontonHistory set RescuePlan = 1 where [RescuePlanFormNumber] is not null;
update WorkPermitEdmontonHistory set RescuePlan = 0 where [RescuePlanFormNumber] is null;
go

alter table WorkPermitEdmontonHistory alter column RescuePlan bit NOT NULL;
go

----

alter table WorkPermitEdmontonDetails add SpecialWork bit NULL;
go

update WorkPermitEdmontonDetails set SpecialWork = 1 where [SpecialWorkFormNumber] is not null or [SpecialWorkType] is not null;
update WorkPermitEdmontonDetails set SpecialWork = 0 where [SpecialWorkFormNumber] is null and [SpecialWorkType] is null;
go

alter table WorkPermitEdmontonDetails alter column SpecialWork bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add SpecialWork bit NULL;
go

update WorkPermitEdmontonHistory set SpecialWork = 1 where [SpecialWorkFormNumber] is not null or [SpecialWorkType] is not null;
update WorkPermitEdmontonHistory set SpecialWork = 0 where [SpecialWorkFormNumber] is null and [SpecialWorkType] is null;
go

alter table WorkPermitEdmontonHistory alter column SpecialWork bit NOT NULL;
go

---

alter table WorkPermitEdmontonDetails add GN59 bit NULL;
go

update WorkPermitEdmontonDetails set GN59 = 1 where [FormGN59Id] is not null;
update WorkPermitEdmontonDetails set GN59 = 0 where FormGN59Id is null;
go

alter table WorkPermitEdmontonDetails alter column GN59 bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add GN59 bit NULL;
go

update WorkPermitEdmontonHistory set GN59 = 1 where [FormGN59Id] is not null;
update WorkPermitEdmontonHistory set GN59 = 0 where FormGN59Id is null;
go

alter table WorkPermitEdmontonHistory alter column GN59 bit NOT NULL;
go

---

alter table WorkPermitEdmontonDetails add GN7 bit NULL;
go

update WorkPermitEdmontonDetails set GN7 = 1 where [FormGN7Id] is not null;
update WorkPermitEdmontonDetails set GN7 = 0 where FormGN7Id is null;
go

alter table WorkPermitEdmontonDetails alter column GN7 bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add GN7 bit NULL;
go

update WorkPermitEdmontonHistory set GN7 = 1 where [FormGN7Id] is not null;
update WorkPermitEdmontonHistory set GN7 = 0 where FormGN7Id is null;
go

alter table WorkPermitEdmontonHistory alter column GN7 bit NOT NULL;
go

---

alter table WorkPermitEdmontonDetails add OtherAreasAndOrUnitsAffected bit NULL;
go

update WorkPermitEdmontonDetails set OtherAreasAndOrUnitsAffected = 1 where [OtherAreasAndOrUnitsAffectedArea] is not null or [OtherAreasAndOrUnitsAffectedPersonNotified] is not null;
update WorkPermitEdmontonDetails set OtherAreasAndOrUnitsAffected = 0 where [OtherAreasAndOrUnitsAffectedArea] is null and [OtherAreasAndOrUnitsAffectedPersonNotified] is null;
go

alter table WorkPermitEdmontonDetails alter column OtherAreasAndOrUnitsAffected bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add OtherAreasAndOrUnitsAffected bit NULL;
go

update WorkPermitEdmontonHistory set OtherAreasAndOrUnitsAffected = 1 where [OtherAreasAndOrUnitsAffectedArea] is not null or [OtherAreasAndOrUnitsAffectedPersonNotified] is not null;
update WorkPermitEdmontonHistory set OtherAreasAndOrUnitsAffected = 0 where [OtherAreasAndOrUnitsAffectedArea] is null and [OtherAreasAndOrUnitsAffectedPersonNotified] is null;
go

alter table WorkPermitEdmontonHistory alter column OtherAreasAndOrUnitsAffected bit NOT NULL;
go

---

alter table WorkPermitEdmontonDetails add Other1Checked bit NULL;
go

update WorkPermitEdmontonDetails set Other1Checked = 1 where Other1 is not null;
update WorkPermitEdmontonDetails set Other1Checked = 0 where Other1 is null;
go

alter table WorkPermitEdmontonDetails alter column Other1Checked bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add Other1Checked bit NULL;
go

update WorkPermitEdmontonHistory set Other1Checked = 1 where Other1 is not null;
update WorkPermitEdmontonHistory set Other1Checked = 0 where Other1 is null;
go

alter table WorkPermitEdmontonHistory alter column Other1Checked bit NOT NULL;
go

---

alter table WorkPermitEdmontonDetails add Other2Checked bit NULL;
go

update WorkPermitEdmontonDetails set Other2Checked = 1 where Other2 is not null;
update WorkPermitEdmontonDetails set Other2Checked = 0 where Other2 is null;
go

alter table WorkPermitEdmontonDetails alter column Other2Checked bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add Other2Checked bit NULL;
go

update WorkPermitEdmontonHistory set Other2Checked = 1 where Other2 is not null;
update WorkPermitEdmontonHistory set Other2Checked = 0 where Other2 is null;
go

alter table WorkPermitEdmontonHistory alter column Other2Checked bit NOT NULL;
go

---

alter table WorkPermitEdmontonDetails add Other3Checked bit NULL;
go

update WorkPermitEdmontonDetails set Other3Checked = 1 where Other3 is not null;
update WorkPermitEdmontonDetails set Other3Checked = 0 where Other3 is null;
go

alter table WorkPermitEdmontonDetails alter column Other3Checked bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add Other3Checked bit NULL;
go

update WorkPermitEdmontonHistory set Other3Checked = 1 where Other3 is not null;
update WorkPermitEdmontonHistory set Other3Checked = 0 where Other3 is null;
go

alter table WorkPermitEdmontonHistory alter column Other3Checked bit NOT NULL;
go

---

alter table WorkPermitEdmontonDetails add Other4Checked bit NULL;
go

update WorkPermitEdmontonDetails set Other4Checked = 1 where Other4 is not null;
update WorkPermitEdmontonDetails set Other4Checked = 0 where Other4 is null;
go

alter table WorkPermitEdmontonDetails alter column Other4Checked bit NOT NULL;
go

alter table WorkPermitEdmontonHistory add Other4Checked bit NULL;
go

update WorkPermitEdmontonHistory set Other4Checked = 1 where Other4 is not null;
update WorkPermitEdmontonHistory set Other4Checked = 0 where Other4 is null;
go

alter table WorkPermitEdmontonHistory alter column Other4Checked bit NOT NULL;
go




GO

