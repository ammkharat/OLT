-- ------------------------------------------------------
-- missing fk

-- old MN1-P053 plant 1000 floc
delete from ShiftFunctionalLocation
where FunctionalLocationId = 126648
and not exists (select Id from FunctionalLocation where Id = 126648)
;


alter table ShiftFunctionalLocation with check
add constraint FK_ShiftFunctionalLocation_Shift
foreign key (ShiftId)
references Shift(Id);

alter table ShiftFunctionalLocation with check
add constraint FK_ShiftFunctionalLocation_FunctionalLocation
foreign key (FunctionalLocationId)
references FunctionalLocation(Id);

go

-- ------------------------------------------------------
-- clear out event sinks, which may have floc ids in them
delete from EventSinks;
go


-- ------------------------------------------------------
-- delete a duplicate that has one marked as Deleted and one not
-- to delete -> 42023	2	DN1	3003	0013	SIL	13F22	13F22, MEROX MIXING TO D140	DN1-3003-0013-SIL-13F22	0	41947	1	41977	5	7000
--              98439	2	DN1	3003	0013	SIL	13F22	13F22, W1 FILMER INJECTION SYSTEM	DN1-3003-0013-SIL-13F22	0	41947	0	41977	5	7000

-- 4 rows
delete from FunctionalLocationAncestor
where Id = (select f.Id from FunctionalLocation f where f.SiteId = 2 and f.FullHierarchy = 'DN1-3003-0013-SIL-13F22' and f.Deleted = 1)
;

-- 0 rows
delete from FunctionalLocationAncestor
where AncestorId = (select f.Id from FunctionalLocation f where f.SiteId = 2 and f.FullHierarchy = 'DN1-3003-0013-SIL-13F22' and f.Deleted = 1)
;

-- 1 row
delete from FunctionalLocation
where Id = (select f.Id from FunctionalLocation f where f.SiteId = 2 and f.FullHierarchy = 'DN1-3003-0013-SIL-13F22' and f.Deleted = 1)
;

go


-- ------------------------------------------------------
-- create a temp table to help with updating dependencies
create table [dbo].z_DuplicateFloc
(
	[ToDeleteId] bigint not null,
	[ToKeepId] bigint not null
);

go

-- create a stored proc to help with deletes
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'z_DeleteDuplicateFloc')
    BEGIN
        DROP  Procedure  z_DeleteDuplicateFloc
    END

GO

CREATE Procedure [dbo].z_DeleteDuplicateFloc
    (
        @ToDeleteId BIGINT,
		@ToKeepId BIGINT,
		@FullHierarchy varchar(100),
		@DeleteDependencies bit
    )

AS

begin

	if (exists(select f.Id from FunctionalLocation f where f.Id = @ToDeleteId and f.FullHierarchy = @FullHierarchy) and
		exists(select f.Id from FunctionalLocation f where f.Id = @ToKeepId and f.FullHierarchy = @FullHierarchy))
	begin

		if (@ToDeleteId > @ToKeepId)
		begin
			update FunctionalLocation
			set Description = (select Description from FunctionalLocation where Id = @ToDeleteId)
			where Id = @ToKeepId;
		end		

		insert into z_DuplicateFloc
		values (@ToDeleteId, @ToKeepId)

	end
end

GO


-- ------------------------------------------------------
-- deal with level = 3 duplicates explicitly
-- the one chosen to be delete does not have any children attached to it
--
-- to delete -> 23388	1	SR1	PLT2	VACU	NULL	NULL	VACUUM UNIT	SR1-PLT2-VACU	0	113563	0	17495	3	4000	2
--              113563	1	SR1	PLT2	VACU	NULL	NULL	VACUUM UNIT	SR1-PLT2-VACU	0	113563	0	17495	3	4000	2

delete FunctionalLocationAncestor
where AncestorId = (select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 113563 and f.FullHierarchy = 'SR1-PLT2-VACU');

delete from FunctionalLocationOperationalMode 
where UnitId = (select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 113563 and f.FullHierarchy = 'SR1-PLT2-VACU');

delete from FunctionalLocationOperationalModeHistory 
where UnitId = (select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 113563 and f.FullHierarchy = 'SR1-PLT2-VACU');

update WorkAssignmentFunctionalLocation
set FunctionalLocationId = (select f.Id from FunctionalLocation f where f.Id = 113563 and f.FullHierarchy = 'SR1-PLT2-VACU')
where FunctionalLocationId = (select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU')
and exists(select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 113563 and f.FullHierarchy = 'SR1-PLT2-VACU');

delete from UserLoginHistoryFunctionalLocation
where UserLoginHistoryId in 
(
	select hfl.UserLoginHistoryId 
	from UserLoginHistoryFunctionalLocation hfl 
	where hfl.FunctionalLocationId = (select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU')
)
and exists(select f.Id from FunctionalLocation f where f.Id = 23388 and f.FullHierarchy = 'SR1-PLT2-VACU') 
and exists(select f.Id from FunctionalLocation f where f.Id = 113563 and f.FullHierarchy = 'SR1-PLT2-VACU');

exec z_DeleteDuplicateFloc 23388, 113563, 'SR1-PLT2-VACU', 1
go

-- ------------------------------------------------------
-- deal with level = 3 duplicates explicitly
-- the one chosen to be delete does not have any children attached to it
--
-- to delete -> 52643	2	DN1	3003	0036	NULL	NULL	ELECTRICAL DISTRIBUTION, WEST PLANT	DN1-3003-0036	0	111087	0	35481	3	7000	2
--              111087	2	DN1	3003	0036	NULL	NULL	ELECTRICAL DISTRIBUTION, DENVER REFINERY	DN1-3003-0036	0	111087	0	35481	3	7000	2

delete FunctionalLocationAncestor
where AncestorId = (select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036')
and exists(select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036') 
and exists(select f.Id from FunctionalLocation f where f.Id = 111087 and f.FullHierarchy = 'DN1-3003-0036');

delete from FunctionalLocationOperationalMode 
where UnitId = (select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036')
and exists(select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036') 
and exists(select f.Id from FunctionalLocation f where f.Id = 111087 and f.FullHierarchy = 'DN1-3003-0036');

delete from FunctionalLocationOperationalModeHistory 
where UnitId = (select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036')
and exists(select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036') 
and exists(select f.Id from FunctionalLocation f where f.Id = 111087 and f.FullHierarchy = 'DN1-3003-0036');

update WorkAssignmentFunctionalLocation
set FunctionalLocationId = (select f.Id from FunctionalLocation f where f.Id = 111087 and f.FullHierarchy = 'DN1-3003-0036')
where FunctionalLocationId = (select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036')
and exists(select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036') 
and exists(select f.Id from FunctionalLocation f where f.Id = 111087 and f.FullHierarchy = 'DN1-3003-0036');

delete from UserLoginHistoryFunctionalLocation
where UserLoginHistoryId in 
(
	select hfl.UserLoginHistoryId 
	from UserLoginHistoryFunctionalLocation hfl 
	where hfl.FunctionalLocationId = (select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036')
)
and exists(select f.Id from FunctionalLocation f where f.Id = 52643 and f.FullHierarchy = 'DN1-3003-0036') 
and exists(select f.Id from FunctionalLocation f where f.Id = 111087 and f.FullHierarchy = 'DN1-3003-0036');

exec z_DeleteDuplicateFloc 52643, 111087, 'DN1-3003-0036', 1
go


-- ------------------------------------------------------
-- deal with triplicates
--           34105	1	SR1	PLT1	REF1	SIL	A171202	17-H-107 SOUTH STACK 02 & CO A	SR1-PLT1-REF1-SIL-A171202	0	15513	0	15529	5	4000	3
-- delete -> 111802	1	SR1	PLT1	REF1	SIL	A171202	17-H-107 SOUTH STACK 02	SR1-PLT1-REF1-SIL-A171202	0	15513	0	15529	5	4000	3
-- delete -> 147717	1	SR1	PLT1	REF1	SIL	A171202	17-H-107 & H-114 STACK O2	SR1-PLT1-REF1-SIL-A171202	0	15513	0	15529	5	4000	3
--
--           49401	2	DN1	3003	0019	SPH	X210	X210, EXCHANGER, KERO DSL VS CRUDE	DN1-3003-0019-SPH-X210	0	48133	0	49381	5	7000	3
-- delete -> 147650	2	DN1	3003	0019	SPH	X210	X210, EXCHANGER, W82 DISTILLATE VS CRUDE	DN1-3003-0019-SPH-X210	0	48133	0	49381	5	7000	3
-- delete -> 111103	2	DN1	3003	0019	SPH	X210	X210, EXCHANGER, W82 DISTILLITE VS CRUDE	DN1-3003-0019-SPH-X210	0	48133	0	49381	5	7000	3

exec z_DeleteDuplicateFloc 111802, 34105, 'SR1-PLT1-REF1-SIL-A171202', 1
exec z_DeleteDuplicateFloc 147717, 34105, 'SR1-PLT1-REF1-SIL-A171202', 1
go

exec z_DeleteDuplicateFloc 111103, 49401, 'DN1-3003-0019-SPH-X210', 1
exec z_DeleteDuplicateFloc 147650, 49401, 'DN1-3003-0019-SPH-X210', 1
go

-- ------------------------------------------------------
-- level 5 duplicates

exec z_DeleteDuplicateFloc 98436, 113497 , 'SR1-OFFS-BDOF-SIL-A02001', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112807, 113466 , 'SR1-OFFS-BDTF-SIC-A02013', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113490, 1706 , 'SR1-OFFS-TKFM-SIC-C03001', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113416, 1903 , 'SR1-OFFS-TKFM-SIC-F031457', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112603, 2447 , 'SR1-OFFS-TKFM-SIC-P03030', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112604, 2481 , 'SR1-OFFS-TKFM-SIC-P031003', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 2609, 113489 , 'SR1-OFFS-TKFM-SIC-T03005', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110419, 2829 , 'SR1-OFFS-TKFM-SIL-A03004', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72747, 97480 , 'SR1-OFFS-TKFM-SLE-03RV018', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111016, 3675 , 'SR1-OFFS-TKFM-SLP-31117', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 33287, 98715 , 'SR1-OFFS-UTOF-SEG-06BA100M', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 98714, 33288 , 'SR1-OFFS-UTOF-SEG-06BA100S', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111012, 5873 , 'SR1-OFFS-UTOF-SIC-F04028', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110421, 6559 , 'SR1-OFFS-UTOF-SMP-06P007A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 6560, 110422 , 'SR1-OFFS-UTOF-SMP-06P007B', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 6561, 110423 , 'SR1-OFFS-UTOF-SMP-06P007C', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147523, 6662 , 'SR1-OFFS-WWTU-SIC-F05032', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147715, 6744 , 'SR1-OFFS-WWTU-SIC-H05160', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147524, 6758 , 'SR1-OFFS-WWTU-SIC-L05038', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113012, 6796 , 'SR1-OFFS-WWTU-SIC-P05031', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 111110, 6847 , 'SR1-OFFS-WWTU-SIL-A05002', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70498, 110667 , 'SR1-OFFS-WWTU-SIL-A05006', 0; -- min: 0 max: 1
exec z_DeleteDuplicateFloc 113415, 6853 , 'SR1-OFFS-WWTU-SIL-A05038', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113414, 6854 , 'SR1-OFFS-WWTU-SIL-A05039', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110669, 6862 , 'SR1-OFFS-WWTU-SIL-A05070', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110668, 6863 , 'SR1-OFFS-WWTU-SIL-A05071', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98742, 7827 , 'SR1-PLT1-ALKU-SIL-A19029', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113086, 8360 , 'SR1-PLT1-ALKU-SMP-19P012', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147632, 11713 , 'SR1-PLT1-GDSU-SIC-F12470', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113460, 11714 , 'SR1-PLT1-GDSU-SIC-F12471', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 11870, 113461 , 'SR1-PLT1-GDSU-SIC-P12473', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110611, 12903 , 'SR1-PLT1-GDSU-SPH-12E017B', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 13009, 110420 , 'SR1-PLT1-GEN1-SIL-A10004', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 98719, 14239 , 'SR1-PLT1-HCCU-SIC-L12501', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98720, 14240 , 'SR1-PLT1-HCCU-SIC-L12502', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98729, 33782 , 'SR1-PLT1-MOLU-SIC-L18120', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98730, 33783 , 'SR1-PLT1-MOLU-SIC-L18121', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98731, 33784 , 'SR1-PLT1-MOLU-SIC-L18122', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98732, 33785 , 'SR1-PLT1-MOLU-SIC-L18123', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 34215, 113488 , 'SR1-PLT1-SSP1-SIC-P04923', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 113089, 16920 , 'SR1-PLT1-UTP1-SIC-K04042', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113090, 16921 , 'SR1-PLT1-UTP1-SIC-K04043', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113091, 16922 , 'SR1-PLT1-UTP1-SIC-K04044', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113092, 16924 , 'SR1-PLT1-UTP1-SIC-K04046', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 16925, 113093 , 'SR1-PLT1-UTP1-SIC-K04047', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113094, 16926 , 'SR1-PLT1-UTP1-SIC-K04048', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113095, 16927 , 'SR1-PLT1-UTP1-SIC-K04049', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113096, 16928 , 'SR1-PLT1-UTP1-SIC-K04050', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113097, 16929 , 'SR1-PLT1-UTP1-SIC-K04051', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113098, 16930 , 'SR1-PLT1-UTP1-SIC-K04052', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110584, 17087 , 'SR1-PLT1-UTP1-SLE-04RV077', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110583, 17088 , 'SR1-PLT1-UTP1-SLE-04RV078', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113055, 34658 , 'SR1-PLT1-UTP1-SPH-12E002A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113056, 34659 , 'SR1-PLT1-UTP1-SPH-12E002B', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97538, 17570 , 'SR1-PLT2-BENU-SIL-A24008', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113038, 17651 , 'SR1-PLT2-BTXE-SIC-F24084', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 17825, 112816 , 'SR1-PLT2-BTXE-SIC-L24101', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 18249, 97539 , 'SR1-PLT2-BTXE-SIL-A24012', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 18252, 97540 , 'SR1-PLT2-BTXE-SIL-A24015', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 19328, 112778 , 'SR1-PLT2-BTXE-SMP-24P004A', 1; -- min: 1 max: 1
go
exec z_DeleteDuplicateFloc 19329, 112779 , 'SR1-PLT2-BTXE-SMP-24P004B', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 112780, 19346 , 'SR1-PLT2-BTXE-SMP-24P013A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 19740, 97541 , 'SR1-PLT2-CRU2-SIL-A21005', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97542, 19741 , 'SR1-PLT2-CRU2-SIL-A21006', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97543, 19744 , 'SR1-PLT2-CRU2-SIL-A21009', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97544, 19748 , 'SR1-PLT2-CRU2-SIL-A21013', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 20492, 112781 , 'SR1-PLT2-CRU2-SMP-21P001B', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 20522, 112776 , 'SR1-PLT2-CRU2-SMP-21P022A', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 20523, 112777 , 'SR1-PLT2-CRU2-SMP-21P022B', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 70492, 97549 , 'SR1-PLT2-ORTU-SIL-A24003', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 97545, 21485 , 'SR1-PLT2-PRE2-SIL-A22001', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97546, 21486 , 'SR1-PLT2-PRE2-SIL-A22002', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112612, 22516 , 'SR1-PLT2-REF2-SLE-23RV039', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110678, 23112 , 'SR1-PLT2-SOLU-SPH-24E060', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98744, 23144 , 'SR1-PLT2-SWP2-SPH-21E018A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98745, 23145 , 'SR1-PLT2-SWP2-SPH-21E018B', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112782, 23184 , 'SR1-PLT2-TOLU-SMP-24P034A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 23262, 113037 , 'SR1-PLT2-UTP2-SIL-A04018', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 97547, 23677 , 'SR1-PLT2-VACU-SIL-A25021', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97548, 23678 , 'SR1-PLT2-VACU-SIL-A25022', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 113165, 23727 , 'SR1-PLT2-VACU-SLE-25RV035', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113164, 23728 , 'SR1-PLT2-VACU-SLE-25RV036', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111109, 24784 , 'SR1-PLT3-ELP3-SES-06SW003', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113452, 24878 , 'SR1-PLT3-FRAU-SIC-F32140', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 27411, 110151 , 'SR1-PLT3-GEN3-SLP-59960', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 27796, 110424 , 'SR1-PLT3-HYDU-SIC-T33263', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 29281, 110425 , 'SR1-PLT3-REAU-SIC-T31317', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 29291, 111021 , 'SR1-PLT3-REAU-SIC-T31339', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112111, 29339 , 'SR1-PLT3-REAU-SIC-T31573', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97580, 71171 , 'SR1-PLT3-REAU-SIL-L31151', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110703, 71244 , 'SR1-PLT3-REAU-SIL-P31144', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113279, 71252 , 'SR1-PLT3-REAU-SIL-P31162', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110160, 29506 , 'SR1-PLT3-REAU-SLE-31RV052', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110426, 35378 , 'SR1-PLT3-REAU-SPT-31FS015A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 35379, 110427 , 'SR1-PLT3-REAU-SPT-31FS015B', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 30807, 112935 , 'SR1-PLT3-REAU-SPT-31PD007', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 30808, 112934 , 'SR1-PLT3-REAU-SPT-31PD008', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 30809, 112933 , 'SR1-PLT3-REAU-SPT-31PD009', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 30810, 112932 , 'SR1-PLT3-REAU-SPT-31PD010', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112524, 113419 , 'SR1-PLT3-SAP3-SIL-L34073', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 112525, 113420 , 'SR1-PLT3-SAP3-SIL-L34074', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112523, 113418 , 'SR1-PLT3-SAP3-SIL-L34076', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112522, 113417 , 'SR1-PLT3-SAP3-SIL-P34031', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112526, 113421 , 'SR1-PLT3-SAP3-SIL-P34032', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111022, 31346 , 'SR1-PLT3-SAP3-SLE-34RV001', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 32529, 147572 , 'SR1-PLT3-UTP3-SIC-H04034', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 32530, 147571 , 'SR1-PLT3-UTP3-SIC-H04035', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 98717, 70694 , 'SR1-PLT4-ELP4-SEG-40BA001A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70695, 98718 , 'SR1-PLT4-ELP4-SEG-40BA001B', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112534, 113424 , 'SR1-PLT4-SAP4-SIL-L44316', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112533, 113423 , 'SR1-PLT4-SAP4-SIL-L44317', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112531, 113422 , 'SR1-PLT4-SAP4-SIL-L44319', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112535, 113425 , 'SR1-PLT4-SAP4-SIL-P44302', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111082, 66440 , 'SR1-PLT4-SAP4-SIL-T44213', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111083, 66445 , 'SR1-PLT4-SAP4-SIL-T44218', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110680, 70332 , 'SR1-PLT4-SAP4-SLE-44RV202', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 32929, 110418 , 'SR1-PLT4-SAP4-SMP-44P006A', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 110417, 32930 , 'SR1-PLT4-SAP4-SMP-44P006B', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 109994, 72198 , 'DN1-3003-0001-SIC-01PLC55', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113505, 35815 , 'DN1-3003-0001-SIL-01L323', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 97460, 36139 , 'DN1-3003-0001-SMP-01P123A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 109993, 72199 , 'DN1-3003-0002-SIC-02PLC56', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112936, 70946 , 'DN1-3003-0002-SIL-02X204', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 66694, 112511 , 'DN1-3003-0002-SLE-02EXJ001', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 66692, 112512 , 'DN1-3003-0002-SLE-02EXJ002', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 66691, 112513 , 'DN1-3003-0002-SLE-02EXJ003', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147557, 36767 , 'DN1-3003-0002-SMF-02C205', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147671, 36783 , 'DN1-3003-0002-SMP-02P216A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147672, 36784 , 'DN1-3003-0002-SMP-02P216B', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70780, 112425 , 'DN1-3003-0002-SPT-02D222', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 112426, 70782 , 'DN1-3003-0002-SPT-02D224', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112783, 37061 , 'DN1-3003-0003-SMP-03P315', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112784, 37062 , 'DN1-3003-0003-SMP-03P316', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147556, 37074 , 'DN1-3003-0003-SPH-03E302', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 109992, 72200 , 'DN1-3003-0004-SIC-04PLC57', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72674, 109991 , 'DN1-3003-0004-SIL-04P544', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72675, 109990 , 'DN1-3003-0004-SIL-04P545', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72676, 109989 , 'DN1-3003-0004-SIL-04P546', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 98716, 37265 , 'DN1-3003-0004-SIL-04T406', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113438, 37526 , 'DN1-3003-0004-SPH-04E406', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 113437, 37536 , 'DN1-3003-0004-SPH-04E421', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113436, 37573 , 'DN1-3003-0004-SPT-04R402', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113435, 37575 , 'DN1-3003-0004-SPT-04R404', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113440, 37581 , 'DN1-3003-0004-SPT-04V402', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113439, 37587 , 'DN1-3003-0004-SPT-04V408', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70389, 110163 , 'DN1-3003-0007-SLP-PC0002', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70390, 110162 , 'DN1-3003-0007-SLP-PC0003', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70392, 110161 , 'DN1-3003-0007-SLP-PC0005', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 38305, 113173 , 'DN1-3003-0007-SMP-07P701A', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 38306, 113172 , 'DN1-3003-0007-SMP-07P701B', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113462, 38476 , 'DN1-3003-0008-SIL-08F2001', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 38564, 111108 , 'DN1-3003-0008-SIL-08H102', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39214, 112556 , 'DN1-3003-0008-SLP-PC0163', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39221, 112557 , 'DN1-3003-0008-SLP-PC0172', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39261, 112558 , 'DN1-3003-0008-SLP-PC0333', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39295, 112569 , 'DN1-3003-0008-SLP-PC0367', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39302, 112952 , 'DN1-3003-0008-SLP-PC0374', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39306, 97461 , 'DN1-3003-0008-SLP-PC0378', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112951, 39421 , 'DN1-3003-0008-SLP-PC0514', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 39422, 112950 , 'DN1-3003-0008-SLP-PC0515', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 39507, 112568 , 'DN1-3003-0008-SLP-PC0601', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39509, 112567 , 'DN1-3003-0008-SLP-PC0604', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39510, 112566 , 'DN1-3003-0008-SLP-PC0605', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112565, 39511 , 'DN1-3003-0008-SLP-PC0606', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 39567, 112949 , 'DN1-3003-0008-SLP-PC0727', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39568, 112948 , 'DN1-3003-0008-SLP-PC0728', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39569, 112947 , 'DN1-3003-0008-SLP-PC0729', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39570, 112946 , 'DN1-3003-0008-SLP-PC0730', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39605, 112564 , 'DN1-3003-0008-SLP-PC0766', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112563, 39609 , 'DN1-3003-0008-SLP-PC0770', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 39766, 112945 , 'DN1-3003-0008-SLP-PC0931', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39922, 112562 , 'DN1-3003-0008-SLP-PC1092', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 39927, 112561 , 'DN1-3003-0008-SLP-PC1097', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112944, 39935 , 'DN1-3003-0008-SLP-PC1108', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112943, 39936 , 'DN1-3003-0008-SLP-PC1109', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 39972, 112942 , 'DN1-3003-0008-SLP-PC1146', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40019, 112560 , 'DN1-3003-0008-SLP-PC1193', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40021, 110634 , 'DN1-3003-0008-SLP-PC1195', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40091, 112577 , 'DN1-3003-0008-SLP-PC1274', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112576, 40117 , 'DN1-3003-0008-SLP-PC1338', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 72952, 110610 , 'DN1-3003-0008-SLP-PC1575', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72953, 110609 , 'DN1-3003-0008-SLP-PC1576', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70556, 110608 , 'DN1-3003-0008-SLP-PC1745', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70557, 110607 , 'DN1-3003-0008-SLP-PC1746', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70558, 110606 , 'DN1-3003-0008-SLP-PC1747', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70559, 110605 , 'DN1-3003-0008-SLP-PC1748', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147525, 40251 , 'DN1-3003-0008-SMP-GW36', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113530, 40253 , 'DN1-3003-0008-SMP-J143', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40264, 113531 , 'DN1-3003-0008-SMP-J3111', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40265, 113532 , 'DN1-3003-0008-SMP-J3141', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113533, 40270 , 'DN1-3003-0008-SMP-J8031', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113534, 40271 , 'DN1-3003-0008-SMP-J807', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40272, 113535 , 'DN1-3003-0008-SMP-J809', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40273, 113536 , 'DN1-3003-0008-SMP-J810', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40274, 113537 , 'DN1-3003-0008-SMP-J811', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40275, 113538 , 'DN1-3003-0008-SMP-J812', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40279, 113539 , 'DN1-3003-0008-SMP-J822', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 111051, 40297 , 'DN1-3003-0008-SMP-P231', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111050, 40298 , 'DN1-3003-0008-SMP-P232', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112101, 40301 , 'DN1-3003-0008-SMP-P261', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 40302, 111049 , 'DN1-3003-0008-SMP-P262', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 111048, 40303 , 'DN1-3003-0008-SMP-P281', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111047, 40304 , 'DN1-3003-0008-SMP-P287', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111046, 40309 , 'DN1-3003-0008-SMP-P314', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40327, 111045 , 'DN1-3003-0008-SMP-P599', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40331, 111044 , 'DN1-3003-0008-SMP-P634', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 111043, 40333 , 'DN1-3003-0008-SMP-P664', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40334, 111042 , 'DN1-3003-0008-SMP-P665', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111041, 40335 , 'DN1-3003-0008-SMP-P666', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111040, 40336 , 'DN1-3003-0008-SMP-P667', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112575, 40366 , 'DN1-3003-0008-SPT-D189', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40384, 113514 , 'DN1-3003-0008-SPT-D391', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113513, 40387 , 'DN1-3003-0008-SPT-D801', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112574, 40393 , 'DN1-3003-0008-SPT-D815', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40394, 112573 , 'DN1-3003-0008-SPT-D816', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40395, 112572 , 'DN1-3003-0008-SPT-D817', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40396, 112571 , 'DN1-3003-0008-SPT-D818', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113519, 40403 , 'DN1-3003-0008-SPT-T2', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113520, 40413 , 'DN1-3003-0008-SPT-T52', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113521, 40414 , 'DN1-3003-0008-SPT-T55', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 40416, 113522 , 'DN1-3003-0008-SPT-T58', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113523, 40419 , 'DN1-3003-0008-SPT-T64', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113524, 40420 , 'DN1-3003-0008-SPT-T65', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113525, 40421 , 'DN1-3003-0008-SPT-T66', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113526, 40427 , 'DN1-3003-0008-SPT-T72', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113527, 40429 , 'DN1-3003-0008-SPT-T75', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113528, 40431 , 'DN1-3003-0008-SPT-T77', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40432, 113529 , 'DN1-3003-0008-SPT-T774', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 40434, 113540 , 'DN1-3003-0008-SPT-T776', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 40435, 113541 , 'DN1-3003-0008-SPT-T777', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 40437, 113542 , 'DN1-3003-0008-SPT-T78', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 40441, 113543 , 'DN1-3003-0008-SPT-T802', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40444, 113544 , 'DN1-3003-0008-SPT-T810', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 112570, 40445 , 'DN1-3003-0008-SPT-T82', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113545, 40453 , 'DN1-3003-0008-SPT-T96', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113546, 40454 , 'DN1-3003-0008-SPT-T97', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110632, 40667 , 'DN1-3003-0009-SIL-09T442', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110621, 40879 , 'DN1-3003-0010-SIL-10F514', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 40888, 110622 , 'DN1-3003-0010-SIL-10H349', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 40912, 110623 , 'DN1-3003-0010-SIL-10L387', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 41246, 110438 , 'DN1-3003-0010-SLP-PC0151', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72062, 110489 , 'DN1-3003-0010-SLP-PC0221', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 41546, 113515 , 'DN1-3003-0012-SLE-ARM11', 0; -- min: 0 max: 1
exec z_DeleteDuplicateFloc 113516, 41547 , 'DN1-3003-0012-SLE-ARM12', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113517, 41548 , 'DN1-3003-0012-SLE-ARM13', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113518, 41549 , 'DN1-3003-0012-SLE-ARM14', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113511, 41570 , 'DN1-3003-0012-SLE-ARM36', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113512, 41580 , 'DN1-3003-0012-SLE-ARM52', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 41886, 113510 , 'DN1-3003-0012-SMP-P159', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 41992, 111916 , 'DN1-3003-0013-SIL-13C9', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 43005, 97550 , 'DN1-3003-0013-SLP-PC0525', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111017, 43060 , 'DN1-3003-0013-SMF-F10', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111018, 43147 , 'DN1-3003-0013-SPH-X33', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 43284, 110657 , 'DN1-3003-0015-SIL-15F103', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 43673, 112962 , 'DN1-3003-0015-SLE-S16', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 112963, 43674 , 'DN1-3003-0015-SLE-S17', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112964, 44091 , 'DN1-3003-0015-SMF-F151', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112965, 44095 , 'DN1-3003-0015-SMF-F50', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 44102, 112966 , 'DN1-3003-0015-SMP-J123', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112967, 44104 , 'DN1-3003-0015-SMP-J1501', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 44105, 112968 , 'DN1-3003-0015-SMP-J291', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 44106, 112969 , 'DN1-3003-0015-SMP-J292', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112970, 44110 , 'DN1-3003-0015-SMP-J654', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112971, 44146 , 'DN1-3003-0015-SPH-X176', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112972, 44159 , 'DN1-3003-0015-SPH-X364', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112973, 44167 , 'DN1-3003-0015-SPH-XF215', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112974, 44169 , 'DN1-3003-0015-SPH-XF218', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112975, 44178 , 'DN1-3003-0015-SPT-D280', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 44195, 112976 , 'DN1-3003-0015-SPT-T2016', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 44982, 113504 , 'DN1-3003-0016-SIL-16V233', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 44983, 113503 , 'DN1-3003-0016-SIL-16V234', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 44992, 113502 , 'DN1-3003-0016-SIL-16V344', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 44993, 113501 , 'DN1-3003-0016-SIL-16V345', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 45212, 111052 , 'DN1-3003-0016-SLP-PC0085', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 45213, 111053 , 'DN1-3003-0016-SLP-PC0086', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 45216, 111054 , 'DN1-3003-0016-SLP-PC0089', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112454, 45835 , 'DN1-3003-0016-SMP-P775', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147610, 47982 , 'DN1-3003-0017-SPH-H1713', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 47983, 147609 , 'DN1-3003-0017-SPH-H1714', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 47984, 147608 , 'DN1-3003-0017-SPH-H17141', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 147607, 47986 , 'DN1-3003-0017-SPH-H17151', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 47990, 147606 , 'DN1-3003-0017-SPH-H1719', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 47991, 147605 , 'DN1-3003-0017-SPH-H1720', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 47993, 147604 , 'DN1-3003-0017-SPH-H1795', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147603, 47994 , 'DN1-3003-0017-SPH-H1796', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 48713, 147630 , 'DN1-3003-0019-SLE-EJ1', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 48714, 147629 , 'DN1-3003-0019-SLE-EJ1902', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 48715, 147628 , 'DN1-3003-0019-SLE-EJ1903', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 48716, 147627 , 'DN1-3003-0019-SLE-EJ1904', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 48717, 147626 , 'DN1-3003-0019-SLE-EJ2', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 48718, 147625 , 'DN1-3003-0019-SLE-EJ3', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70456, 97454 , 'DN1-3003-0019-SLE-PC0680', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70457, 97455 , 'DN1-3003-0019-SLE-PC0681', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70458, 97456 , 'DN1-3003-0019-SLE-PC0682', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70459, 97457 , 'DN1-3003-0019-SLE-PC0683', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70460, 97458 , 'DN1-3003-0019-SLE-PC0684', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70461, 97459 , 'DN1-3003-0019-SLE-PC0685', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72738, 112447 , 'DN1-3003-0019-SLP-PC0053', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 49276, 110158 , 'DN1-3003-0019-SLP-PC0722', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 49277, 110157 , 'DN1-3003-0019-SLP-PC0723', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 49279, 110156 , 'DN1-3003-0019-SLP-PC0725', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 49280, 110155 , 'DN1-3003-0019-SLP-PC0726', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147631, 49346 , 'DN1-3003-0019-SMP-P226', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112930, 49350 , 'DN1-3003-0019-SMP-P348', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147622, 49352 , 'DN1-3003-0019-SMP-P495', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 49364, 147623 , 'DN1-3003-0019-SMP-P672', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147624, 49369 , 'DN1-3003-0019-SMP-P796', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 49382, 147659 , 'DN1-3003-0019-SPH-H13', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 147658, 49383 , 'DN1-3003-0019-SPH-H17', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147657, 49384 , 'DN1-3003-0019-SPH-H33', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147656, 49385 , 'DN1-3003-0019-SPH-H37', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147655, 49387 , 'DN1-3003-0019-SPH-X1902', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147654, 49388 , 'DN1-3003-0019-SPH-X1903', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147653, 49393 , 'DN1-3003-0019-SPH-X1913', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147652, 49394 , 'DN1-3003-0019-SPH-X1914', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147651, 49398 , 'DN1-3003-0019-SPH-X1960', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147649, 49402 , 'DN1-3003-0019-SPH-X211', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147648, 49403 , 'DN1-3003-0019-SPH-X212', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147647, 49404 , 'DN1-3003-0019-SPH-X213', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147646, 49408 , 'DN1-3003-0019-SPH-X346', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 147645, 49409 , 'DN1-3003-0019-SPH-X347', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147644, 49414 , 'DN1-3003-0019-SPH-X378', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147643, 49423 , 'DN1-3003-0019-SPH-X433', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147642, 49424 , 'DN1-3003-0019-SPH-X434', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147641, 49427 , 'DN1-3003-0019-SPH-X437', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147640, 49428 , 'DN1-3003-0019-SPH-X438', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147639, 49429 , 'DN1-3003-0019-SPH-X441', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147638, 49430 , 'DN1-3003-0019-SPH-X442', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147637, 49435 , 'DN1-3003-0019-SPH-XF352', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 49437, 147636 , 'DN1-3003-0019-SPH-XF502', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 49440, 147635 , 'DN1-3003-0019-SPT-D1902', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 49441, 147634 , 'DN1-3003-0019-SPT-D1903', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 147633, 49447 , 'DN1-3003-0019-SPT-D89', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111791, 49508 , 'DN1-3003-0021-SIL-21A146', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 49566, 111792 , 'DN1-3003-0021-SIL-21H314', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 49641, 111793 , 'DN1-3003-0021-SIL-21P2109', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111019, 50217 , 'DN1-3003-0021-SMP-P2111', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111020, 50218 , 'DN1-3003-0021-SMP-P2112', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147694, 50443 , 'DN1-3003-0032-SLE-ARM191', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147695, 50444 , 'DN1-3003-0032-SLE-ARM192', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 147696, 50445 , 'DN1-3003-0032-SLE-ARM193', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147697, 50457 , 'DN1-3003-0032-SLE-S3203', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147698, 50458 , 'DN1-3003-0032-SLE-S3205', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147699, 50459 , 'DN1-3003-0032-SLE-S3207', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147700, 50460 , 'DN1-3003-0032-SLE-S3209', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147701, 50749 , 'DN1-3003-0032-SMA-A34', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147702, 50756 , 'DN1-3003-0032-SMF-F3203', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147703, 50757 , 'DN1-3003-0032-SMF-F3205', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147704, 50758 , 'DN1-3003-0032-SMF-F3207', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147705, 50759 , 'DN1-3003-0032-SMF-F3209', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113088, 50773 , 'DN1-3003-0032-SMP-J223', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147706, 50791 , 'DN1-3003-0032-SMP-P252', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147707, 50792 , 'DN1-3003-0032-SMP-P253', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147708, 50800 , 'DN1-3003-0032-SMP-P902', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147709, 50808 , 'DN1-3003-0032-SPH-X225', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147710, 50814 , 'DN1-3003-0032-SPT-D162', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147711, 50815 , 'DN1-3003-0032-SPT-D163', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147712, 50828 , 'DN1-3003-0032-SPT-T140', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147713, 50829 , 'DN1-3003-0032-SPT-T141', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110432, 51168 , 'DN1-3003-0035-SIL-35L76', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 110431, 51371 , 'DN1-3003-0035-SIL-35T148', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112799, 51619 , 'DN1-3003-0035-SLE-EJ3510', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112798, 51620 , 'DN1-3003-0035-SLE-EJ3511', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 51643, 112797 , 'DN1-3003-0035-SLE-S3501', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 51644, 112796 , 'DN1-3003-0035-SLE-S3502', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112795, 51646 , 'DN1-3003-0035-SLE-S556', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112794, 51647 , 'DN1-3003-0035-SLE-S557', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112793, 52477 , 'DN1-3003-0035-SMP-P524', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112792, 52488 , 'DN1-3003-0035-SMP-P567', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 52491, 112791 , 'DN1-3003-0035-SMP-P587', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 112790, 52499 , 'DN1-3003-0035-SMP-P730', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112789, 52510 , 'DN1-3003-0035-SPH-X236', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 52521, 112788 , 'DN1-3003-0035-SPH-X3556', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 52522, 112787 , 'DN1-3003-0035-SPH-X3557', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 52525, 112786 , 'DN1-3003-0035-SPH-X598', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112785, 52549 , 'DN1-3003-0035-SPT-D313', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110564, 52658 , 'DN1-3003-0036-SEG-SUB1', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110565, 52659 , 'DN1-3003-0036-SEG-SUB10', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110566, 52660 , 'DN1-3003-0036-SEG-SUB100', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110567, 52661 , 'DN1-3003-0036-SEG-SUB11', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 110568, 52662 , 'DN1-3003-0036-SEG-SUB12', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110569, 52663 , 'DN1-3003-0036-SEG-SUB14', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110570, 52664 , 'DN1-3003-0036-SEG-SUB15', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110571, 52665 , 'DN1-3003-0036-SEG-SUB16', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 52666, 110572 , 'DN1-3003-0036-SEG-SUB17', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 52667, 110573 , 'DN1-3003-0036-SEG-SUB2', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 110574, 52668 , 'DN1-3003-0036-SEG-SUB20', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110575, 52669 , 'DN1-3003-0036-SEG-SUB21', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 52670, 110576 , 'DN1-3003-0036-SEG-SUB3', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 111092, 52671 , 'DN1-3003-0036-SEG-SUB33', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 52672, 110577 , 'DN1-3003-0036-SEG-SUB4', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 110578, 52673 , 'DN1-3003-0036-SEG-SUB5', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110579, 52674 , 'DN1-3003-0036-SEG-SUB50', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110580, 52675 , 'DN1-3003-0036-SEG-SUB51', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110581, 52676 , 'DN1-3003-0036-SEG-SUB6', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 52678, 110582 , 'DN1-3003-0036-SEG-SUB8', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 52693, 110090 , 'DN1-3003-0036-SIL-36J0050', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 52694, 110091 , 'DN1-3003-0036-SIL-36J0051', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 52695, 110092 , 'DN1-3003-0036-SIL-36J0052', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 52696, 110093 , 'DN1-3003-0036-SIL-36J0053', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 111039, 52749 , 'DN1-3003-0037-SIL-37A864', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72938, 111686 , 'DN1-3003-0037-SIL-37F913', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 52922, 111678 , 'DN1-3003-0037-SIL-37L221', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111677, 52923 , 'DN1-3003-0037-SIL-37L222', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 52927, 111676 , 'DN1-3003-0037-SIL-37L901', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 52966, 111675 , 'DN1-3003-0037-SIL-37P213', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111674, 52967 , 'DN1-3003-0037-SIL-37P230', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111673, 52968 , 'DN1-3003-0037-SIL-37P231', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 53015, 111685 , 'DN1-3003-0037-SIL-37P938', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 53016, 111684 , 'DN1-3003-0037-SIL-37P939', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 53032, 111683 , 'DN1-3003-0037-SIL-37P962', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 53033, 111682 , 'DN1-3003-0037-SIL-37P963', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111681, 53057 , 'DN1-3003-0037-SIL-37S0904', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 53058, 111680 , 'DN1-3003-0037-SIL-37S0910', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 53217, 111679 , 'DN1-3003-0037-SIL-37Z905', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112941, 53401 , 'DN1-3003-0037-SLP-PC0149', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 53410, 112940 , 'DN1-3003-0037-SLP-PC0158', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97473, 53596 , 'DN1-3003-0037-SLP-PC0417', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97478, 53899 , 'DN1-3003-0037-SMP-P3744', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 53911, 147602 , 'DN1-3003-0037-SPH-H3701', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 53912, 147601 , 'DN1-3003-0037-SPH-H3702', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 54004, 110629 , 'DN1-3003-0038-SAB-BD3801', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 54020, 111854 , 'DN1-3003-0038-SIL-38A692', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147678, 54026 , 'DN1-3003-0038-SIL-38CAS301', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147600, 54431 , 'DN1-3003-0038-SPH-H3802', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98711, 54452 , 'DN1-3003-0038-SPT-D3804', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112818, 54654 , 'DN1-3003-0039-SIL-39P10', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55062, 147599 , 'DN1-3003-0039-SPH-H3911', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55063, 147598 , 'DN1-3003-0039-SPH-H3912', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111853, 55153 , 'DN1-3003-0040-SIL-40A100', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55154, 111848 , 'DN1-3003-0040-SIL-40A101', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111847, 55155 , 'DN1-3003-0040-SIL-40A102', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111846, 55158 , 'DN1-3003-0040-SIL-40A205', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55159, 111845 , 'DN1-3003-0040-SIL-40E722', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55160, 111844 , 'DN1-3003-0040-SIL-40E726', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111808, 55164 , 'DN1-3003-0040-SIL-40F228', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111809, 55165 , 'DN1-3003-0040-SIL-40F229', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111810, 55166 , 'DN1-3003-0040-SIL-40F230', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55167, 111811 , 'DN1-3003-0040-SIL-40F232', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55168, 111812 , 'DN1-3003-0040-SIL-40F267', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 55169, 111843 , 'DN1-3003-0040-SIL-40F672', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55170, 111842 , 'DN1-3003-0040-SIL-40F723', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55171, 111841 , 'DN1-3003-0040-SIL-40F724', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55172, 111840 , 'DN1-3003-0040-SIL-40F733', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55173, 111839 , 'DN1-3003-0040-SIL-40F751', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55174, 111838 , 'DN1-3003-0040-SIL-40F923', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111837, 55175 , 'DN1-3003-0040-SIL-40F942', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111836, 55176 , 'DN1-3003-0040-SIL-40F946', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111813, 55177 , 'DN1-3003-0040-SIL-40F947', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55180, 111814 , 'DN1-3003-0040-SIL-40H263', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55183, 111815 , 'DN1-3003-0040-SIL-40H348', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55185, 111835 , 'DN1-3003-0040-SIL-40H75', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55186, 111834 , 'DN1-3003-0040-SIL-40H76', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111833, 55187 , 'DN1-3003-0040-SIL-40L230', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111832, 55188 , 'DN1-3003-0040-SIL-40L436', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111831, 55189 , 'DN1-3003-0040-SIL-40L720', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55190, 111830 , 'DN1-3003-0040-SIL-40L730', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111829, 55191 , 'DN1-3003-0040-SIL-40L940', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55192, 111828 , 'DN1-3003-0040-SIL-40L943', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111827, 55193 , 'DN1-3003-0040-SIL-40P1', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 111826, 55195 , 'DN1-3003-0040-SIL-40P230', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55196, 111825 , 'DN1-3003-0040-SIL-40P670', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55197, 111824 , 'DN1-3003-0040-SIL-40P76', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111823, 55199 , 'DN1-3003-0040-SIL-40P940', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111822, 55200 , 'DN1-3003-0040-SIL-40P943', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55201, 111852 , 'DN1-3003-0040-SIL-40P946', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55202, 111851 , 'DN1-3003-0040-SIL-40S942', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111850, 55203 , 'DN1-3003-0040-SIL-40T100', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55207, 111849 , 'DN1-3003-0040-SIL-40T230', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55208, 111821 , 'DN1-3003-0040-SIL-40T734', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55209, 111820 , 'DN1-3003-0040-SIL-40T99', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111819, 55210 , 'DN1-3003-0040-SIL-40V230', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111818, 55211 , 'DN1-3003-0040-SIL-40V231', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55212, 111817 , 'DN1-3003-0040-SIL-40V45', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55213, 111816 , 'DN1-3003-0040-SIL-40V46', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55214, 111855 , 'DN1-3003-0040-SIL-40V725', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55215, 111856 , 'DN1-3003-0040-SIL-40V727', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55219, 111873 , 'DN1-3003-0040-SIL-40X103', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55220, 111872 , 'DN1-3003-0040-SIL-40X104', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55223, 111871 , 'DN1-3003-0040-SIL-40X230', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 55224, 111870 , 'DN1-3003-0040-SIL-40X231', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55225, 111869 , 'DN1-3003-0040-SIL-40X263', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55226, 111868 , 'DN1-3003-0040-SIL-40X30', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55227, 111867 , 'DN1-3003-0040-SIL-40X31', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55228, 111866 , 'DN1-3003-0040-SIL-40X34', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55229, 111884 , 'DN1-3003-0040-SIL-40X4', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55230, 111883 , 'DN1-3003-0040-SIL-40X419', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55231, 111882 , 'DN1-3003-0040-SIL-40X43', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55232, 111881 , 'DN1-3003-0040-SIL-40X44', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55233, 111865 , 'DN1-3003-0040-SIL-40X472', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55234, 111864 , 'DN1-3003-0040-SIL-40X5', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55235, 111863 , 'DN1-3003-0040-SIL-40X6', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55236, 111862 , 'DN1-3003-0040-SIL-40X626', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55237, 111861 , 'DN1-3003-0040-SIL-40X627', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55238, 111860 , 'DN1-3003-0040-SIL-40X7', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55239, 111859 , 'DN1-3003-0040-SIL-40X75', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55240, 111858 , 'DN1-3003-0040-SIL-40X76', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 55241, 111857 , 'DN1-3003-0040-SIL-40Y348', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111878, 55424 , 'DN1-3003-0041-SIL-41A176', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111875, 55425 , 'DN1-3003-0041-SIL-41A177', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 112997, 55426 , 'DN1-3003-0041-SIL-41A513', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111874, 55431 , 'DN1-3003-0041-SIL-41A553', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55432, 111877 , 'DN1-3003-0041-SIL-41A554', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111880, 55451 , 'DN1-3003-0041-SIL-41A574', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111879, 55455 , 'DN1-3003-0041-SIL-41A593', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 55464, 111876 , 'DN1-3003-0041-SIL-41C143', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 109995, 72181 , 'DN1-3003-0041-SIL-41P403', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56161, 113564 , 'DN1-3003-0041-SLP-PC0065', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56220, 97472 , 'DN1-3003-0041-SLP-PC0128', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56340, 110474 , 'DN1-3003-0041-SLP-PC0393', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56353, 110475 , 'DN1-3003-0041-SLP-PC0413', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110478, 56424 , 'DN1-3003-0041-SLP-PC0504', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56425, 110477 , 'DN1-3003-0041-SLP-PC0505', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56441, 110488 , 'DN1-3003-0041-SLP-PC0523', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56442, 110487 , 'DN1-3003-0041-SLP-PC0524', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56443, 110486 , 'DN1-3003-0041-SLP-PC0525', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56444, 110485 , 'DN1-3003-0041-SLP-PC0526', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56445, 110484 , 'DN1-3003-0041-SLP-PC0527', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56446, 110483 , 'DN1-3003-0041-SLP-PC0528', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56447, 110482 , 'DN1-3003-0041-SLP-PC0529', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 56448, 110481 , 'DN1-3003-0041-SLP-PC0530', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56498, 110473 , 'DN1-3003-0041-SLP-PC1050', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110476, 56531 , 'DN1-3003-0041-SLP-PC1085', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56537, 110472 , 'DN1-3003-0041-SLP-PC1131', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56548, 110480 , 'DN1-3003-0041-SLP-PC1159', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56618, 110479 , 'DN1-3003-0041-SLP-PC1405', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110658, 56712 , 'DN1-3003-0041-SMF-F4103', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110659, 56713 , 'DN1-3003-0041-SMF-F4104', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110660, 56714 , 'DN1-3003-0041-SMF-F4105', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110661, 56715 , 'DN1-3003-0041-SMF-F4106', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110662, 56716 , 'DN1-3003-0041-SMF-F4107', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110663, 56717 , 'DN1-3003-0041-SMF-F4108', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110664, 56718 , 'DN1-3003-0041-SMF-F4109', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110665, 56719 , 'DN1-3003-0041-SMF-F4110', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112492, 56738 , 'DN1-3003-0041-SMP-J4101', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112493, 56739 , 'DN1-3003-0041-SMP-J4102', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56740, 112494 , 'DN1-3003-0041-SMP-J652', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112495, 56743 , 'DN1-3003-0041-SMP-P112', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112496, 56761 , 'DN1-3003-0041-SMP-P507', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112497, 56768 , 'DN1-3003-0041-SMP-P86', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 112498, 56769 , 'DN1-3003-0041-SMP-P87', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112499, 56781 , 'DN1-3003-0041-SPH-X239', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112500, 56793 , 'DN1-3003-0041-SPH-X315', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112501, 56794 , 'DN1-3003-0041-SPH-X316', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113058, 56935 , 'DN1-3003-0045-SAA-WW6', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56936, 113059 , 'DN1-3003-0045-SAA-WW7', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72166, 111891 , 'DN1-3003-0045-SIL-45A202', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72350, 111887 , 'DN1-3003-0045-SIL-45A225', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111886, 72351 , 'DN1-3003-0045-SIL-45A226', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72165, 111890 , 'DN1-3003-0045-SIL-45A302', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72352, 111885 , 'DN1-3003-0045-SIL-45A341', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72164, 111889 , 'DN1-3003-0045-SIL-45A351', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72163, 111888 , 'DN1-3003-0045-SIL-45A352', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112156, 56947 , 'DN1-3003-0045-SIL-45A421', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112157, 56948 , 'DN1-3003-0045-SIL-45A422', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56949, 112158 , 'DN1-3003-0045-SIL-45A423', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56950, 112159 , 'DN1-3003-0045-SIL-45A425', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113180, 147687 , 'DN1-3003-0045-SIL-45A4551', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113181, 147688 , 'DN1-3003-0045-SIL-45A4552', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113182, 147689 , 'DN1-3003-0045-SIL-45A4553', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 112160, 56951 , 'DN1-3003-0045-SIL-45CAS301', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72160, 112291 , 'DN1-3003-0045-SIL-45F210', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112292, 72159 , 'DN1-3003-0045-SIL-45F211', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72158, 112293 , 'DN1-3003-0045-SIL-45F212', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112294, 72157 , 'DN1-3003-0045-SIL-45F214', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98442, 56954 , 'DN1-3003-0045-SIL-45F302', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98443, 56955 , 'DN1-3003-0045-SIL-45F303', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98444, 56956 , 'DN1-3003-0045-SIL-45F306', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56957, 98445 , 'DN1-3003-0045-SIL-45F310', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 56958, 98446 , 'DN1-3003-0045-SIL-45F330', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56959, 98447 , 'DN1-3003-0045-SIL-45F331', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147686, 112477 , 'DN1-3003-0045-SIL-45F354', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112112, 56961 , 'DN1-3003-0045-SIL-45F363', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112113, 56962 , 'DN1-3003-0045-SIL-45F401', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56963, 112114 , 'DN1-3003-0045-SIL-45F402', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112115, 56964 , 'DN1-3003-0045-SIL-45F403', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112116, 56965 , 'DN1-3003-0045-SIL-45F404', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112117, 56966 , 'DN1-3003-0045-SIL-45F405', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56967, 112118 , 'DN1-3003-0045-SIL-45F406', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112119, 56968 , 'DN1-3003-0045-SIL-45F408', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 112120, 56969 , 'DN1-3003-0045-SIL-45F409', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112121, 56970 , 'DN1-3003-0045-SIL-45F410', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112122, 56971 , 'DN1-3003-0045-SIL-45F411', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112123, 56972 , 'DN1-3003-0045-SIL-45F412', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56973, 112124 , 'DN1-3003-0045-SIL-45F413', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112125, 56974 , 'DN1-3003-0045-SIL-45F414', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112126, 56975 , 'DN1-3003-0045-SIL-45F415', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112127, 56976 , 'DN1-3003-0045-SIL-45F416', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112128, 56977 , 'DN1-3003-0045-SIL-45F417', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56978, 112129 , 'DN1-3003-0045-SIL-45F418', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56979, 112130 , 'DN1-3003-0045-SIL-45F419', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56980, 112131 , 'DN1-3003-0045-SIL-45F420', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112132, 56981 , 'DN1-3003-0045-SIL-45F421', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56982, 112133 , 'DN1-3003-0045-SIL-45F422', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72176, 112281 , 'DN1-3003-0045-SIL-45F423', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112134, 56983 , 'DN1-3003-0045-SIL-45F424', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112135, 56984 , 'DN1-3003-0045-SIL-45F425', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56985, 112136 , 'DN1-3003-0045-SIL-45F426', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56986, 112137 , 'DN1-3003-0045-SIL-45F427', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56987, 112138 , 'DN1-3003-0045-SIL-45F428', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 112139, 56988 , 'DN1-3003-0045-SIL-45F429', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 56989, 112140 , 'DN1-3003-0045-SIL-45F450', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56990, 112141 , 'DN1-3003-0045-SIL-45F452', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113183, 147690 , 'DN1-3003-0045-SIL-45F4551', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113184, 147691 , 'DN1-3003-0045-SIL-45F4552', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113185, 147692 , 'DN1-3003-0045-SIL-45F4553', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56991, 112142 , 'DN1-3003-0045-SIL-45F521', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56992, 112143 , 'DN1-3003-0045-SIL-45F523', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56993, 112144 , 'DN1-3003-0045-SIL-45F524', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56994, 112145 , 'DN1-3003-0045-SIL-45F525', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56995, 112146 , 'DN1-3003-0045-SIL-45F526', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56996, 112147 , 'DN1-3003-0045-SIL-45H305', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56997, 112148 , 'DN1-3003-0045-SIL-45H308', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56998, 112149 , 'DN1-3003-0045-SIL-45H314', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 56999, 112150 , 'DN1-3003-0045-SIL-45H316', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57000, 112151 , 'DN1-3003-0045-SIL-45H328', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57001, 112152 , 'DN1-3003-0045-SIL-45H329', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57002, 112153 , 'DN1-3003-0045-SIL-45H990', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57003, 112154 , 'DN1-3003-0045-SIL-45H991', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57004, 112155 , 'DN1-3003-0045-SIL-45H992', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57005, 112161 , 'DN1-3003-0045-SIL-45H993', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57006, 112162 , 'DN1-3003-0045-SIL-45H994', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57007, 112163 , 'DN1-3003-0045-SIL-45H995', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72354, 112313 , 'DN1-3003-0045-SIL-45I4528', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57008, 112164 , 'DN1-3003-0045-SIL-45K641', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57009, 112165 , 'DN1-3003-0045-SIL-45K642', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57010, 112166 , 'DN1-3003-0045-SIL-45K643', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57014, 112167 , 'DN1-3003-0045-SIL-45L203', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72153, 112295 , 'DN1-3003-0045-SIL-45L217', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57015, 112168 , 'DN1-3003-0045-SIL-45L221', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57016, 112169 , 'DN1-3003-0045-SIL-45L222', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112296, 72152 , 'DN1-3003-0045-SIL-45L224', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112297, 72151 , 'DN1-3003-0045-SIL-45L226', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112298, 72150 , 'DN1-3003-0045-SIL-45L227', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112299, 72149 , 'DN1-3003-0045-SIL-45L228', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72148, 112300 , 'DN1-3003-0045-SIL-45L290', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57017, 112170 , 'DN1-3003-0045-SIL-45L325', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112171, 57018 , 'DN1-3003-0045-SIL-45L326', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57019, 112172 , 'DN1-3003-0045-SIL-45L327', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57020, 112173 , 'DN1-3003-0045-SIL-45L328', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57021, 112174 , 'DN1-3003-0045-SIL-45L330', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112282, 72175 , 'DN1-3003-0045-SIL-45L353', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72174, 112283 , 'DN1-3003-0045-SIL-45L363', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57022, 112175 , 'DN1-3003-0045-SIL-45L401', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57023, 112176 , 'DN1-3003-0045-SIL-45L402', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57024, 112177 , 'DN1-3003-0045-SIL-45L403', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57025, 112178 , 'DN1-3003-0045-SIL-45L404', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57026, 112179 , 'DN1-3003-0045-SIL-45L405', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57027, 112180 , 'DN1-3003-0045-SIL-45L406', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57028, 112181 , 'DN1-3003-0045-SIL-45L408', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57029, 112182 , 'DN1-3003-0045-SIL-45L409', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57030, 112183 , 'DN1-3003-0045-SIL-45L410', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57031, 112184 , 'DN1-3003-0045-SIL-45L411', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57032, 112185 , 'DN1-3003-0045-SIL-45L412', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57033, 112186 , 'DN1-3003-0045-SIL-45L413', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57034, 112187 , 'DN1-3003-0045-SIL-45L414', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57035, 112188 , 'DN1-3003-0045-SIL-45L415', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57036, 112189 , 'DN1-3003-0045-SIL-45L416', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57037, 112190 , 'DN1-3003-0045-SIL-45L417', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57038, 112191 , 'DN1-3003-0045-SIL-45L418', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57039, 112192 , 'DN1-3003-0045-SIL-45L420', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57040, 112193 , 'DN1-3003-0045-SIL-45L421', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57041, 112194 , 'DN1-3003-0045-SIL-45L422', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112195, 57042 , 'DN1-3003-0045-SIL-45L423', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112196, 57043 , 'DN1-3003-0045-SIL-45L426', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57044, 112197 , 'DN1-3003-0045-SIL-45L427', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57045, 112198 , 'DN1-3003-0045-SIL-45L428', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112199, 57046 , 'DN1-3003-0045-SIL-45L430', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57047, 112200 , 'DN1-3003-0045-SIL-45L445', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72545, 112330 , 'DN1-3003-0045-SIL-45L4501', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57048, 112201 , 'DN1-3003-0045-SIL-45L523', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57049, 112202 , 'DN1-3003-0045-SIL-45L524', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57050, 112203 , 'DN1-3003-0045-SIL-45L525', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57051, 112204 , 'DN1-3003-0045-SIL-45L526', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57052, 112205 , 'DN1-3003-0045-SIL-45L531', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57053, 112206 , 'DN1-3003-0045-SIL-45L659', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57054, 112207 , 'DN1-3003-0045-SIL-45L660', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72173, 112284 , 'DN1-3003-0045-SIL-45P1001', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57055, 112208 , 'DN1-3003-0045-SIL-45P202', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72147, 112301 , 'DN1-3003-0045-SIL-45P213', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57056, 112209 , 'DN1-3003-0045-SIL-45P314', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57057, 112210 , 'DN1-3003-0045-SIL-45P316', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72146, 112302 , 'DN1-3003-0045-SIL-45P364', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57058, 112211 , 'DN1-3003-0045-SIL-45P4', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57059, 112212 , 'DN1-3003-0045-SIL-45P420', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57061, 112213 , 'DN1-3003-0045-SIL-45P426', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57062, 112214 , 'DN1-3003-0045-SIL-45P427', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72144, 112303 , 'DN1-3003-0045-SIL-45S305', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72143, 112304 , 'DN1-3003-0045-SIL-45S306', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72136, 112305 , 'DN1-3003-0045-SIL-45S4510', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72137, 112306 , 'DN1-3003-0045-SIL-45S4511', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72355, 112314 , 'DN1-3003-0045-SIL-45S4518', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72138, 112307 , 'DN1-3003-0045-SIL-45S4520', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72139, 112308 , 'DN1-3003-0045-SIL-45S4526', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72140, 112309 , 'DN1-3003-0045-SIL-45S4527', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72356, 112315 , 'DN1-3003-0045-SIL-45S4532', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72357, 112316 , 'DN1-3003-0045-SIL-45S4533', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57063, 112215 , 'DN1-3003-0045-SIL-45T1', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57067, 112216 , 'DN1-3003-0045-SIL-45T2', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57068, 112217 , 'DN1-3003-0045-SIL-45T308', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57069, 112218 , 'DN1-3003-0045-SIL-45T309', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57070, 112219 , 'DN1-3003-0045-SIL-45T314', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57071, 112220 , 'DN1-3003-0045-SIL-45T316', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57072, 112221 , 'DN1-3003-0045-SIL-45T319', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57073, 112222 , 'DN1-3003-0045-SIL-45T322', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72172, 112285 , 'DN1-3003-0045-SIL-45T332', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57074, 112223 , 'DN1-3003-0045-SIL-45T333', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72171, 112286 , 'DN1-3003-0045-SIL-45T360', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57075, 112224 , 'DN1-3003-0045-SIL-45T422', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72185, 112310 , 'DN1-3003-0045-SIL-45X196', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57077, 112225 , 'DN1-3003-0045-SIL-45X305', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72358, 112317 , 'DN1-3003-0045-SIL-45X306', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57078, 112226 , 'DN1-3003-0045-SIL-45X308', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57079, 112227 , 'DN1-3003-0045-SIL-45X314', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57080, 112228 , 'DN1-3003-0045-SIL-45X315', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57081, 112229 , 'DN1-3003-0045-SIL-45X316', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57082, 112230 , 'DN1-3003-0045-SIL-45X326', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57083, 112231 , 'DN1-3003-0045-SIL-45X327', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57084, 112232 , 'DN1-3003-0045-SIL-45X328', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57085, 112233 , 'DN1-3003-0045-SIL-45X329', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57086, 112234 , 'DN1-3003-0045-SIL-45X330', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57087, 112235 , 'DN1-3003-0045-SIL-45X331', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72345, 112312 , 'DN1-3003-0045-SIL-45X338', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112287, 72170 , 'DN1-3003-0045-SIL-45X350', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57088, 112236 , 'DN1-3003-0045-SIL-45X401', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57089, 112237 , 'DN1-3003-0045-SIL-45X402', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57090, 112238 , 'DN1-3003-0045-SIL-45X403', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57091, 112239 , 'DN1-3003-0045-SIL-45X404', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57092, 112240 , 'DN1-3003-0045-SIL-45X405', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57093, 112241 , 'DN1-3003-0045-SIL-45X406', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57094, 112242 , 'DN1-3003-0045-SIL-45X407', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57095, 112243 , 'DN1-3003-0045-SIL-45X408', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57096, 112244 , 'DN1-3003-0045-SIL-45X409', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57097, 112245 , 'DN1-3003-0045-SIL-45X410', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57098, 112246 , 'DN1-3003-0045-SIL-45X411', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57099, 112247 , 'DN1-3003-0045-SIL-45X412', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57100, 112248 , 'DN1-3003-0045-SIL-45X413', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57101, 112249 , 'DN1-3003-0045-SIL-45X414', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57102, 112250 , 'DN1-3003-0045-SIL-45X415', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57103, 112251 , 'DN1-3003-0045-SIL-45X416', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57104, 112252 , 'DN1-3003-0045-SIL-45X417', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57105, 112253 , 'DN1-3003-0045-SIL-45X418', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57106, 112254 , 'DN1-3003-0045-SIL-45X419', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57107, 112255 , 'DN1-3003-0045-SIL-45X420', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57108, 112256 , 'DN1-3003-0045-SIL-45X421', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57109, 112257 , 'DN1-3003-0045-SIL-45X422', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57110, 112258 , 'DN1-3003-0045-SIL-45X425', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57111, 112259 , 'DN1-3003-0045-SIL-45X426', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72546, 112331 , 'DN1-3003-0045-SIL-45X4501', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72360, 112318 , 'DN1-3003-0045-SIL-45X4512', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112319, 72361 , 'DN1-3003-0045-SIL-45X4514', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72362, 112320 , 'DN1-3003-0045-SIL-45X4515', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72363, 112321 , 'DN1-3003-0045-SIL-45X4516', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72364, 112322 , 'DN1-3003-0045-SIL-45X4520', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72365, 112323 , 'DN1-3003-0045-SIL-45X4521', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72366, 112324 , 'DN1-3003-0045-SIL-45X4522', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72367, 112325 , 'DN1-3003-0045-SIL-45X4523', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72368, 112326 , 'DN1-3003-0045-SIL-45X4526', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72369, 112327 , 'DN1-3003-0045-SIL-45X4527', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72370, 112328 , 'DN1-3003-0045-SIL-45X4528', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 72374, 112329 , 'DN1-3003-0045-SIL-45X4540', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113219, 113451 , 'DN1-3003-0045-SIL-45X4542', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113220, 113450 , 'DN1-3003-0045-SIL-45X4543', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113221, 113449 , 'DN1-3003-0045-SIL-45X4544', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113222, 113448 , 'DN1-3003-0045-SIL-45X4545', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113223, 113447 , 'DN1-3003-0045-SIL-45X4546', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113224, 113446 , 'DN1-3003-0045-SIL-45X4547', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113225, 113445 , 'DN1-3003-0045-SIL-45X4548', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113226, 113444 , 'DN1-3003-0045-SIL-45X4549', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113227, 113443 , 'DN1-3003-0045-SIL-45X4550', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113228, 113442 , 'DN1-3003-0045-SIL-45X4551', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57112, 112260 , 'DN1-3003-0045-SIL-45X523', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57113, 112261 , 'DN1-3003-0045-SIL-45X524', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57114, 112262 , 'DN1-3003-0045-SIL-45X525', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57115, 112263 , 'DN1-3003-0045-SIL-45X526', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57116, 112264 , 'DN1-3003-0045-SIL-45X531', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57117, 112265 , 'DN1-3003-0045-SIL-45X532', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57118, 112266 , 'DN1-3003-0045-SIL-45X641', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57119, 112267 , 'DN1-3003-0045-SIL-45X642', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57120, 112268 , 'DN1-3003-0045-SIL-45X643', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57121, 112269 , 'DN1-3003-0045-SIL-45X658', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57122, 112270 , 'DN1-3003-0045-SIL-45X659', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57123, 112271 , 'DN1-3003-0045-SIL-45X660', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57124, 112272 , 'DN1-3003-0045-SIL-45X661', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57125, 112273 , 'DN1-3003-0045-SIL-45X906', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57126, 112274 , 'DN1-3003-0045-SIL-45X907', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57127, 112275 , 'DN1-3003-0045-SIL-45X908', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57128, 112276 , 'DN1-3003-0045-SIL-45X909', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72169, 112288 , 'DN1-3003-0045-SIL-45X987', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57129, 112277 , 'DN1-3003-0045-SIL-45X990', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57130, 112278 , 'DN1-3003-0045-SIL-45X991', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57131, 112279 , 'DN1-3003-0045-SIL-45X992', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57132, 112280 , 'DN1-3003-0045-SIL-45X993', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72168, 112289 , 'DN1-3003-0045-SIL-45X994', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72167, 112290 , 'DN1-3003-0045-SIL-45X995', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72344, 112311 , 'DN1-3003-0045-SIL-47X021', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 64841, 113085 , 'DN1-3003-0045-SLE-EJ4504', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57137, 112749 , 'DN1-3003-0045-SLE-S4505', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57143, 111687 , 'DN1-3003-0045-SLP-PC0003', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57267, 98480 , 'DN1-3003-0045-SLP-PC0127', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57292, 112586 , 'DN1-3003-0045-SLP-PC0152', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 66695, 112591 , 'DN1-3003-0045-SLP-PC0245', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 66696, 112592 , 'DN1-3003-0045-SLP-PC0246', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 66697, 112593 , 'DN1-3003-0045-SLP-PC0247', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72904, 112594 , 'DN1-3003-0045-SLP-PC0353', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112750, 57441 , 'DN1-3003-0045-SLP-PC0566', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57442, 112109 , 'DN1-3003-0045-SLP-PC0567', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57443, 112587 , 'DN1-3003-0045-SLP-PC0568', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57445, 112588 , 'DN1-3003-0045-SLP-PC0570', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57446, 112589 , 'DN1-3003-0045-SLP-PC0571', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57447, 112590 , 'DN1-3003-0045-SLP-PC0572', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110465, 113453 , 'DN1-3003-0045-SLP-PC0705', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113084, 57451 , 'DN1-3003-0045-SMA-A4', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113083, 57454 , 'DN1-3003-0045-SMA-A4507', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57455, 113082 , 'DN1-3003-0045-SMA-A4508', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113081, 57460 , 'DN1-3003-0045-SMA-A5', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57463, 113080 , 'DN1-3003-0045-SMF-F196', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113060, 57467 , 'DN1-3003-0045-SMP-GW103', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70563, 112775 , 'DN1-3003-0045-SMP-J4518', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113061, 57481 , 'DN1-3003-0045-SMP-P1003', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 113062, 57491 , 'DN1-3003-0045-SMP-P4540', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113063, 57496 , 'DN1-3003-0045-SMP-P533', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110633, 57509 , 'DN1-3003-0045-SMP-P992', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113064, 70482 , 'DN1-3003-0045-SPH-X4503', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70483, 113065 , 'DN1-3003-0045-SPH-X4504', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113071, 70605 , 'DN1-3003-0045-SPT-D4513', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113079, 57521 , 'DN1-3003-0045-SPT-T152', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113078, 57526 , 'DN1-3003-0045-SPT-T26', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113077, 57528 , 'DN1-3003-0045-SPT-T28', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57537, 113076 , 'DN1-3003-0045-SPT-T4501', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113074, 70602 , 'DN1-3003-0045-SPT-T4502', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113073, 70603 , 'DN1-3003-0045-SPT-T4503', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70604, 113072 , 'DN1-3003-0045-SPT-T4504', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 70607, 113069 , 'DN1-3003-0045-SPT-T4507', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113070, 70606 , 'DN1-3003-0045-SPT-T4508', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113068, 70608 , 'DN1-3003-0045-SPT-T4511', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70609, 113067 , 'DN1-3003-0045-SPT-T4512', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113066, 70610 , 'DN1-3003-0045-SPT-T4513', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57538, 113075 , 'DN1-3003-0045-SPT-T60', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113464, 113465 , 'DN1-3003-0047-SIL-47A0924', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 111892, 57635 , 'DN1-3003-0047-SIL-47A1', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110094, 57636 , 'DN1-3003-0047-SIL-47A1052', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111893, 57637 , 'DN1-3003-0047-SIL-47A111', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57639, 111915 , 'DN1-3003-0047-SIL-47A17', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110095, 57640 , 'DN1-3003-0047-SIL-47A1774', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110096, 57641 , 'DN1-3003-0047-SIL-47A1775', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57642, 111914 , 'DN1-3003-0047-SIL-47A181', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57643, 111913 , 'DN1-3003-0047-SIL-47A19', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57644, 110097 , 'DN1-3003-0047-SIL-47A190', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110098, 57645 , 'DN1-3003-0047-SIL-47A191', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57646, 111912 , 'DN1-3003-0047-SIL-47A2', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111911, 57647 , 'DN1-3003-0047-SIL-47A201', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110099, 57648 , 'DN1-3003-0047-SIL-47A203', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57649, 110100 , 'DN1-3003-0047-SIL-47A209', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111910, 57650 , 'DN1-3003-0047-SIL-47A210', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57651, 111909 , 'DN1-3003-0047-SIL-47A211', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110147, 72162 , 'DN1-3003-0047-SIL-47A212', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110146, 72161 , 'DN1-3003-0047-SIL-47A213', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110101, 57652 , 'DN1-3003-0047-SIL-47A214', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57653, 110102 , 'DN1-3003-0047-SIL-47A215', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57654, 110103 , 'DN1-3003-0047-SIL-47A216', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72089, 110148 , 'DN1-3003-0047-SIL-47A22', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111908, 57655 , 'DN1-3003-0047-SIL-47A226', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57656, 111907 , 'DN1-3003-0047-SIL-47A231', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57657, 111906 , 'DN1-3003-0047-SIL-47A232', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111905, 57658 , 'DN1-3003-0047-SIL-47A233', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57659, 111904 , 'DN1-3003-0047-SIL-47A243', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111903, 57660 , 'DN1-3003-0047-SIL-47A254', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57661, 111902 , 'DN1-3003-0047-SIL-47A255', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57662, 111901 , 'DN1-3003-0047-SIL-47A256', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111900, 57663 , 'DN1-3003-0047-SIL-47A276', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111899, 57664 , 'DN1-3003-0047-SIL-47A277', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57665, 110104 , 'DN1-3003-0047-SIL-47A285', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57666, 110105 , 'DN1-3003-0047-SIL-47A286', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57667, 110106 , 'DN1-3003-0047-SIL-47A288', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57668, 111898 , 'DN1-3003-0047-SIL-47A3', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111897, 57669 , 'DN1-3003-0047-SIL-47A301', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111896, 57670 , 'DN1-3003-0047-SIL-47A302', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111895, 57671 , 'DN1-3003-0047-SIL-47A303', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57672, 111894 , 'DN1-3003-0047-SIL-47A304', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 110107, 57674 , 'DN1-3003-0047-SIL-47A311', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57675, 111917 , 'DN1-3003-0047-SIL-47A32', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111930, 57676 , 'DN1-3003-0047-SIL-47A333', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110108, 57677 , 'DN1-3003-0047-SIL-47A34', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110109, 57678 , 'DN1-3003-0047-SIL-47A35', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111929, 57679 , 'DN1-3003-0047-SIL-47A353', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111928, 57680 , 'DN1-3003-0047-SIL-47A354', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111927, 57681 , 'DN1-3003-0047-SIL-47A379', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57682, 111926 , 'DN1-3003-0047-SIL-47A399', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57683, 111925 , 'DN1-3003-0047-SIL-47A4', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110110, 57684 , 'DN1-3003-0047-SIL-47A40', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111924, 57685 , 'DN1-3003-0047-SIL-47A400', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111923, 57686 , 'DN1-3003-0047-SIL-47A401', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111922, 57687 , 'DN1-3003-0047-SIL-47A402', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57688, 111921 , 'DN1-3003-0047-SIL-47A403', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111920, 57689 , 'DN1-3003-0047-SIL-47A404', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57690, 111919 , 'DN1-3003-0047-SIL-47A408', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57691, 111918 , 'DN1-3003-0047-SIL-47A409', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57692, 110111 , 'DN1-3003-0047-SIL-47A41', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57693, 111961 , 'DN1-3003-0047-SIL-47A42', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 110112, 57694 , 'DN1-3003-0047-SIL-47A420', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57695, 110113 , 'DN1-3003-0047-SIL-47A421', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111960, 57696 , 'DN1-3003-0047-SIL-47A425', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57697, 111959 , 'DN1-3003-0047-SIL-47A427', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57698, 111958 , 'DN1-3003-0047-SIL-47A428', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111946, 57699 , 'DN1-3003-0047-SIL-47A429', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57700, 111945 , 'DN1-3003-0047-SIL-47A43', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111947, 57701 , 'DN1-3003-0047-SIL-47A44', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111948, 57702 , 'DN1-3003-0047-SIL-47A450', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111949, 57703 , 'DN1-3003-0047-SIL-47A451', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111950, 57704 , 'DN1-3003-0047-SIL-47A452', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57705, 111951 , 'DN1-3003-0047-SIL-47A453', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111952, 57706 , 'DN1-3003-0047-SIL-47A456', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111953, 57707 , 'DN1-3003-0047-SIL-47A457', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57708, 111954 , 'DN1-3003-0047-SIL-47A461', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57709, 110114 , 'DN1-3003-0047-SIL-47A5', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57710, 111944 , 'DN1-3003-0047-SIL-47A50', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57711, 111943 , 'DN1-3003-0047-SIL-47A51', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57712, 111942 , 'DN1-3003-0047-SIL-47A52', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111941, 57713 , 'DN1-3003-0047-SIL-47A522', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 57714, 111940 , 'DN1-3003-0047-SIL-47A523', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57715, 111939 , 'DN1-3003-0047-SIL-47A524', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57716, 111938 , 'DN1-3003-0047-SIL-47A53', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57717, 111955 , 'DN1-3003-0047-SIL-47A54', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57720, 111956 , 'DN1-3003-0047-SIL-47A55', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111957, 57727 , 'DN1-3003-0047-SIL-47A56', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111937, 57734 , 'DN1-3003-0047-SIL-47A57', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57735, 111936 , 'DN1-3003-0047-SIL-47A571', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57736, 111935 , 'DN1-3003-0047-SIL-47A572', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111934, 57737 , 'DN1-3003-0047-SIL-47A58', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57741, 111933 , 'DN1-3003-0047-SIL-47A59', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111932, 57742 , 'DN1-3003-0047-SIL-47A60', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111931, 57743 , 'DN1-3003-0047-SIL-47A601', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111962, 57744 , 'DN1-3003-0047-SIL-47A602', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111963, 57745 , 'DN1-3003-0047-SIL-47A61', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111964, 57746 , 'DN1-3003-0047-SIL-47A611', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111965, 57747 , 'DN1-3003-0047-SIL-47A632', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57748, 111966 , 'DN1-3003-0047-SIL-47A633', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111967, 57749 , 'DN1-3003-0047-SIL-47A65', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111968, 57750 , 'DN1-3003-0047-SIL-47A69', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 57751, 111969 , 'DN1-3003-0047-SIL-47A690', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57752, 111970 , 'DN1-3003-0047-SIL-47A691', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57753, 111971 , 'DN1-3003-0047-SIL-47A692', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57758, 111972 , 'DN1-3003-0047-SIL-47A693', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57764, 111988 , 'DN1-3003-0047-SIL-47A694', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111987, 57768 , 'DN1-3003-0047-SIL-47A695', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110149, 72097 , 'DN1-3003-0047-SIL-47A6961', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110144, 72341 , 'DN1-3003-0047-SIL-47A6966', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57769, 111986 , 'DN1-3003-0047-SIL-47A700', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57770, 111985 , 'DN1-3003-0047-SIL-47A701', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111984, 57771 , 'DN1-3003-0047-SIL-47A730', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57772, 111983 , 'DN1-3003-0047-SIL-47A80', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111982, 57773 , 'DN1-3003-0047-SIL-47A801', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57774, 110115 , 'DN1-3003-0047-SIL-47A803', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57775, 110116 , 'DN1-3003-0047-SIL-47A8031', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111981, 57776 , 'DN1-3003-0047-SIL-47A81', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110117, 57777 , 'DN1-3003-0047-SIL-47A818', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 111980, 57779 , 'DN1-3003-0047-SIL-47A82', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112009, 57780 , 'DN1-3003-0047-SIL-47A825', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57781, 112002 , 'DN1-3003-0047-SIL-47A826', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 112001, 57782 , 'DN1-3003-0047-SIL-47A829', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57783, 112000 , 'DN1-3003-0047-SIL-47A83', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57784, 111999 , 'DN1-3003-0047-SIL-47A830', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57785, 111998 , 'DN1-3003-0047-SIL-47A835', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57786, 111997 , 'DN1-3003-0047-SIL-47A836', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57787, 111979 , 'DN1-3003-0047-SIL-47A84', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57788, 110118 , 'DN1-3003-0047-SIL-47A843', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57789, 111978 , 'DN1-3003-0047-SIL-47A85', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57790, 111977 , 'DN1-3003-0047-SIL-47A86', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57791, 111976 , 'DN1-3003-0047-SIL-47A87', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57792, 111975 , 'DN1-3003-0047-SIL-47A88', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57793, 111974 , 'DN1-3003-0047-SIL-47A89', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57794, 111973 , 'DN1-3003-0047-SIL-47A90', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70952, 109996 , 'DN1-3003-0047-SIL-47A933', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57795, 111996 , 'DN1-3003-0047-SIL-47A94', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111995, 57796 , 'DN1-3003-0047-SIL-47A952', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57797, 111994 , 'DN1-3003-0047-SIL-47B234', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57798, 111993 , 'DN1-3003-0047-SIL-47C1', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57799, 111992 , 'DN1-3003-0047-SIL-47C101', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57800, 111991 , 'DN1-3003-0047-SIL-47C102', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57801, 111990 , 'DN1-3003-0047-SIL-47C103', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111989, 57802 , 'DN1-3003-0047-SIL-47C104', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112003, 57803 , 'DN1-3003-0047-SIL-47C105', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112004, 57804 , 'DN1-3003-0047-SIL-47C106', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57805, 112005 , 'DN1-3003-0047-SIL-47C107', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57806, 112008 , 'DN1-3003-0047-SIL-47C354', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57807, 112007 , 'DN1-3003-0047-SIL-47C408', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57808, 112006 , 'DN1-3003-0047-SIL-47C694', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57818, 112039 , 'DN1-3003-0047-SIL-47F461', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57819, 112038 , 'DN1-3003-0047-SIL-47F462', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57820, 112037 , 'DN1-3003-0047-SIL-47H233', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57821, 112036 , 'DN1-3003-0047-SIL-47H277', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57822, 112035 , 'DN1-3003-0047-SIL-47H278', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57823, 112034 , 'DN1-3003-0047-SIL-47H301', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57824, 112033 , 'DN1-3003-0047-SIL-47H353', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57825, 112010 , 'DN1-3003-0047-SIL-47H354', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57830, 110119 , 'DN1-3003-0047-SIL-47H549', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57831, 110120 , 'DN1-3003-0047-SIL-47H561', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57832, 112032 , 'DN1-3003-0047-SIL-47H691', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57833, 112031 , 'DN1-3003-0047-SIL-47H692', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 112030, 57835 , 'DN1-3003-0047-SIL-47H693', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57851, 112050 , 'DN1-3003-0047-SIL-47P1', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57852, 112049 , 'DN1-3003-0047-SIL-47P128', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57853, 112048 , 'DN1-3003-0047-SIL-47P201', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57854, 112047 , 'DN1-3003-0047-SIL-47P301', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57855, 110636 , 'DN1-3003-0047-SIL-47P351', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57856, 112046 , 'DN1-3003-0047-SIL-47P352', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57857, 112045 , 'DN1-3003-0047-SIL-47P353', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57858, 112041 , 'DN1-3003-0047-SIL-47P360', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57859, 112029 , 'DN1-3003-0047-SIL-47P404', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57860, 112028 , 'DN1-3003-0047-SIL-47P42', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57861, 112027 , 'DN1-3003-0047-SIL-47P428', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112026, 57862 , 'DN1-3003-0047-SIL-47P461', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110121, 57863 , 'DN1-3003-0047-SIL-47P501', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112025, 57864 , 'DN1-3003-0047-SIL-47P58', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57865, 112024 , 'DN1-3003-0047-SIL-47P694', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57867, 112023 , 'DN1-3003-0047-SIL-47R1', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57868, 112022 , 'DN1-3003-0047-SIL-47R10', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57869, 112021 , 'DN1-3003-0047-SIL-47R2', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57870, 112020 , 'DN1-3003-0047-SIL-47R201', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57871, 112019 , 'DN1-3003-0047-SIL-47R202', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112018, 57872 , 'DN1-3003-0047-SIL-47R3', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57873, 112017 , 'DN1-3003-0047-SIL-47R301', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57874, 112016 , 'DN1-3003-0047-SIL-47R302', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57875, 112015 , 'DN1-3003-0047-SIL-47R4', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57876, 112014 , 'DN1-3003-0047-SIL-47R428', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57877, 112013 , 'DN1-3003-0047-SIL-47R5', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57878, 112012 , 'DN1-3003-0047-SIL-47R56', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57879, 112011 , 'DN1-3003-0047-SIL-47R572', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57880, 112044 , 'DN1-3003-0047-SIL-47R58', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112043, 57881 , 'DN1-3003-0047-SIL-47R6', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57882, 112042 , 'DN1-3003-0047-SIL-47R601', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57883, 112058 , 'DN1-3003-0047-SIL-47R691', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57884, 112057 , 'DN1-3003-0047-SIL-47R692', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57885, 112056 , 'DN1-3003-0047-SIL-47R7', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57886, 112055 , 'DN1-3003-0047-SIL-47R8', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57887, 112054 , 'DN1-3003-0047-SIL-47R9', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57888, 112053 , 'DN1-3003-0047-SIL-47R901', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57889, 112052 , 'DN1-3003-0047-SIL-47R903', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57890, 112051 , 'DN1-3003-0047-SIL-47R91', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57891, 112040 , 'DN1-3003-0047-SIL-47R92', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57892, 112059 , 'DN1-3003-0047-SIL-47R93', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57893, 112060 , 'DN1-3003-0047-SIL-47R94', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57909, 112068 , 'DN1-3003-0047-SIL-47S277', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57910, 112067 , 'DN1-3003-0047-SIL-47S512', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57911, 112085 , 'DN1-3003-0047-SIL-47T461', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57912, 112086 , 'DN1-3003-0047-SIL-47U458', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72346, 110143 , 'DN1-3003-0047-SIL-47X1004', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72347, 110142 , 'DN1-3003-0047-SIL-47X1005', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72348, 110141 , 'DN1-3003-0047-SIL-47X1006', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57913, 112087 , 'DN1-3003-0047-SIL-47X11', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57914, 112088 , 'DN1-3003-0047-SIL-47X12', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57915, 112089 , 'DN1-3003-0047-SIL-47X13', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57916, 112090 , 'DN1-3003-0047-SIL-47X130', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57917, 112091 , 'DN1-3003-0047-SIL-47X14', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57918, 112092 , 'DN1-3003-0047-SIL-47X17', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 72349, 110140 , 'DN1-3003-0047-SIL-47X1700', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57920, 112093 , 'DN1-3003-0047-SIL-47X21', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112094, 57921 , 'DN1-3003-0047-SIL-47X230', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57922, 112095 , 'DN1-3003-0047-SIL-47X231', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 57923, 112084 , 'DN1-3003-0047-SIL-47X232', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57924, 112083 , 'DN1-3003-0047-SIL-47X233', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112082, 57925 , 'DN1-3003-0047-SIL-47X24', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57926, 112081 , 'DN1-3003-0047-SIL-47X25', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57927, 112080 , 'DN1-3003-0047-SIL-47X30', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57928, 112079 , 'DN1-3003-0047-SIL-47X300', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57929, 112078 , 'DN1-3003-0047-SIL-47X301', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57932, 112096 , 'DN1-3003-0047-SIL-47X327', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57933, 112097 , 'DN1-3003-0047-SIL-47X330', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110122, 57934 , 'DN1-3003-0047-SIL-47X331', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57935, 110123 , 'DN1-3003-0047-SIL-47X332', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57936, 112098 , 'DN1-3003-0047-SIL-47X333', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57937, 112099 , 'DN1-3003-0047-SIL-47X334', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57938, 112100 , 'DN1-3003-0047-SIL-47X335', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112077, 57939 , 'DN1-3003-0047-SIL-47X336', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57940, 112076 , 'DN1-3003-0047-SIL-47X351', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57941, 112075 , 'DN1-3003-0047-SIL-47X352', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57942, 112074 , 'DN1-3003-0047-SIL-47X353', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57943, 112073 , 'DN1-3003-0047-SIL-47X354', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57944, 112072 , 'DN1-3003-0047-SIL-47X355', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 110124, 57945 , 'DN1-3003-0047-SIL-47X380', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110125, 57946 , 'DN1-3003-0047-SIL-47X381', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57947, 110126 , 'DN1-3003-0047-SIL-47X4', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112066, 57948 , 'DN1-3003-0047-SIL-47X460', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110127, 57949 , 'DN1-3003-0047-SIL-47X513', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57950, 110128 , 'DN1-3003-0047-SIL-47X516', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57951, 112065 , 'DN1-3003-0047-SIL-47X614', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57953, 110129 , 'DN1-3003-0047-SIL-47X803', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57954, 110130 , 'DN1-3003-0047-SIL-47X830', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57955, 112071 , 'DN1-3003-0047-SIL-47X87', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57956, 112070 , 'DN1-3003-0047-SIL-47Y1', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110131, 57957 , 'DN1-3003-0047-SIL-47Y1774', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 57958, 110132 , 'DN1-3003-0047-SIL-47Y1775', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57959, 110133 , 'DN1-3003-0047-SIL-47Y189', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57960, 110134 , 'DN1-3003-0047-SIL-47Y203', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57961, 112069 , 'DN1-3003-0047-SIL-47Y211', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57963, 110135 , 'DN1-3003-0047-SIL-47Y285', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57964, 112064 , 'DN1-3003-0047-SIL-47Y3', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57965, 112063 , 'DN1-3003-0047-SIL-47Y461', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57966, 112062 , 'DN1-3003-0047-SIL-47Y601', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 72338, 110145 , 'DN1-3003-0047-SIL-47Y6965', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57967, 112061 , 'DN1-3003-0047-SIL-47Y952', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 57988, 110430 , 'DN1-3003-0047-SLP-PC0120', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112502, 58088 , 'DN1-3003-0047-SSA-SS5101', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 72736, 112503 , 'DN1-3003-0047-SSA-SS5201', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110885, 70818 , 'DN1-3003-0049-SAB-49BD1', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147568, 58591 , 'DN1-3003-0053-SPT-53F501', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 58592, 147567 , 'DN1-3003-0053-SPT-53F502', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147566, 58597 , 'DN1-3003-0053-SPT-53TK504', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 147565, 58598 , 'DN1-3003-0053-SPT-53TK506', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70532, 111688 , 'DN1-3003-0054-SLP-PC0011', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 70530, 111689 , 'DN1-3003-0054-SLP-PC0012', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 111690, 70529 , 'DN1-3003-0054-SLP-PC0013', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 70528, 111691 , 'DN1-3003-0054-SLP-PC0014', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 71692, 111692 , 'DN1-3003-0054-SLP-PC100', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147570, 58634 , 'DN1-3003-0054-SPH-54E101', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98721, 58647 , 'DN1-3003-0055-SAA-SA1', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98722, 58648 , 'DN1-3003-0055-SAA-SA2', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98723, 58649 , 'DN1-3003-0055-SAA-SA3', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98724, 58650 , 'DN1-3003-0055-SAA-SA4', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 58651, 98725 , 'DN1-3003-0055-SAA-SA5', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 58652, 98726 , 'DN1-3003-0055-SAA-SA6', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 58653, 98727 , 'DN1-3003-0055-SAA-SA7', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 98728, 58654 , 'DN1-3003-0055-SAA-SA8', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 58669, 110886 , 'DN1-3003-0055-SAB-BD96', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 58694, 147569 , 'DN1-3003-0055-SIC-HONIM25', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147685, 58750 , 'DN1-3003-0055-SIC-LOUCN3HPM5', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113087, 61524 , 'DN1-3003-0083-SIL-83ISS201', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62045, 112559 , 'DN1-3003-0083-SLP-PC0281', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 112819, 62075 , 'DN1-3003-0083-SPH-X397', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112820, 62076 , 'DN1-3003-0083-SPH-X398', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112821, 62082 , 'DN1-3003-0083-SPT-D298', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 112822, 62086 , 'DN1-3003-0083-SPT-D302', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62246, 110518 , 'DN1-3003-0092-SLP-PC0004', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62247, 110517 , 'DN1-3003-0092-SLP-PC0005', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62248, 110516 , 'DN1-3003-0092-SLP-PC0006', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110515, 62249 , 'DN1-3003-0092-SLP-PC0007', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62250, 110514 , 'DN1-3003-0092-SLP-PC0008', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62251, 110513 , 'DN1-3003-0092-SLP-PC0009', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62256, 110512 , 'DN1-3003-0092-SLP-PC0014', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 110511, 62259 , 'DN1-3003-0092-SLP-PC0017', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62260, 110510 , 'DN1-3003-0092-SLP-PC0018', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62263, 110509 , 'DN1-3003-0092-SLP-PC0021', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62265, 110508 , 'DN1-3003-0092-SLP-PC0023', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62266, 110507 , 'DN1-3003-0092-SLP-PC0024', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62274, 110506 , 'DN1-3003-0092-SLP-PC0033', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62275, 110505 , 'DN1-3003-0092-SLP-PC0034', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62278, 110504 , 'DN1-3003-0092-SLP-PC0037', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62282, 110503 , 'DN1-3003-0092-SLP-PC0041', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62284, 110502 , 'DN1-3003-0092-SLP-PC0043', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62285, 110501 , 'DN1-3003-0092-SLP-PC0044', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110500, 62286 , 'DN1-3003-0092-SLP-PC0045', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110499, 62293 , 'DN1-3003-0092-SLP-PC0052', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62294, 110498 , 'DN1-3003-0092-SLP-PC0053', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62295, 110497 , 'DN1-3003-0092-SLP-PC0054', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62296, 110496 , 'DN1-3003-0092-SLP-PC0055', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62298, 110495 , 'DN1-3003-0092-SLP-PC0057', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62299, 110494 , 'DN1-3003-0092-SLP-PC0058', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62300, 110493 , 'DN1-3003-0092-SLP-PC0059', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62301, 110519 , 'DN1-3003-0092-SLP-PC0060', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 110520, 62302 , 'DN1-3003-0092-SLP-PC0061', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62304, 110521 , 'DN1-3003-0092-SLP-PC0063', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62305, 110522 , 'DN1-3003-0092-SLP-PC0066', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62306, 110523 , 'DN1-3003-0092-SLP-PC0067', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62312, 110524 , 'DN1-3003-0092-SLP-PC0073', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62313, 110525 , 'DN1-3003-0092-SLP-PC0074', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62314, 110526 , 'DN1-3003-0092-SLP-PC0075', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62315, 110527 , 'DN1-3003-0092-SLP-PC0076', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62316, 110528 , 'DN1-3003-0092-SLP-PC0077', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62317, 110529 , 'DN1-3003-0092-SLP-PC0078', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62318, 110530 , 'DN1-3003-0092-SLP-PC0079', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62319, 110531 , 'DN1-3003-0092-SLP-PC0080', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62320, 110532 , 'DN1-3003-0092-SLP-PC0081', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62321, 110533 , 'DN1-3003-0092-SLP-PC0082', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62323, 110534 , 'DN1-3003-0092-SLP-PC0084', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62325, 110535 , 'DN1-3003-0092-SLP-PC0086', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110536, 62326 , 'DN1-3003-0092-SLP-PC0087', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62328, 110537 , 'DN1-3003-0092-SLP-PC0089', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62329, 110538 , 'DN1-3003-0092-SLP-PC0090', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62330, 110539 , 'DN1-3003-0092-SLP-PC0091', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 62331, 110540 , 'DN1-3003-0092-SLP-PC0092', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62332, 110541 , 'DN1-3003-0092-SLP-PC0093', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62337, 110542 , 'DN1-3003-0092-SLP-PC0098', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62338, 110543 , 'DN1-3003-0092-SLP-PC0099', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62339, 110544 , 'DN1-3003-0092-SLP-PC0100', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110545, 62340 , 'DN1-3003-0092-SLP-PC0101', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110546, 62342 , 'DN1-3003-0092-SLP-PC0103', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62343, 110547 , 'DN1-3003-0092-SLP-PC0104', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62344, 110548 , 'DN1-3003-0092-SLP-PC0105', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62345, 110549 , 'DN1-3003-0092-SLP-PC0107', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62346, 110550 , 'DN1-3003-0092-SLP-PC0108', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62347, 110551 , 'DN1-3003-0092-SLP-PC0111', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62348, 110552 , 'DN1-3003-0092-SLP-PC0112', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62349, 110553 , 'DN1-3003-0092-SLP-PC0113', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62350, 110554 , 'DN1-3003-0092-SLP-PC0114', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62351, 110555 , 'DN1-3003-0092-SLP-PC0115', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62353, 110556 , 'DN1-3003-0092-SLP-PC0117', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62354, 110557 , 'DN1-3003-0092-SLP-PC0118', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62355, 110558 , 'DN1-3003-0092-SLP-PC0119', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62356, 110559 , 'DN1-3003-0092-SLP-PC0120', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 62357, 110560 , 'DN1-3003-0092-SLP-PC0121', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110561, 62365 , 'DN1-3003-0092-SLP-PC0131', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 62371, 110562 , 'DN1-3003-0092-SLP-PC0137', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 62381, 110563 , 'DN1-3003-0092-SLP-PC0292', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 113499, 71707 , 'DN1-3003-0205-SSR-205PSV512', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113498, 71706 , 'DN1-3003-0205-SSR-205PSV513', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63087, 110136 , 'DN1-3003-0210-SIL-210C1103', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63092, 110137 , 'DN1-3003-0210-SIL-210F105', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63094, 110138 , 'DN1-3003-0210-SIL-210F1103', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 110139, 63095 , 'DN1-3003-0210-SIL-210L1010', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97481, 63107 , 'DN1-3003-0210-SMP-210P100', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113013, 63109 , 'DN1-3003-0210-SMP-210P1044', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63114, 113014 , 'DN1-3003-0210-SMP-210P1406', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113015, 63115 , 'DN1-3003-0210-SMP-210P1407', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97482, 63116 , 'DN1-3003-0210-SMP-210P515', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63117, 97483 , 'DN1-3003-0210-SMP-210P802', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63118, 97484 , 'DN1-3003-0210-SMP-210P803', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63119, 97485 , 'DN1-3003-0210-SMP-210P804', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63120, 97486 , 'DN1-3003-0210-SMP-210P805', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97524, 63121 , 'DN1-3003-0210-SMP-210P806', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 63124, 97523 , 'DN1-3003-0210-SMP-210P903', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 97522, 63125 , 'DN1-3003-0210-SMP-210P904', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63128, 113016 , 'DN1-3003-0210-SMP-210P906A', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63129, 113017 , 'DN1-3003-0210-SMP-210P906B', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63130, 97487 , 'DN1-3003-0210-SMP-210P911', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97488, 63131 , 'DN1-3003-0210-SMP-210P914', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63132, 97489 , 'DN1-3003-0210-SMP-210P915', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 97490, 63133 , 'DN1-3003-0210-SMP-210P916', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63134, 97491 , 'DN1-3003-0210-SMP-210P918', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63135, 97492 , 'DN1-3003-0210-SMP-210P919', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97521, 63136 , 'DN1-3003-0210-SMP-210P923', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63137, 97520 , 'DN1-3003-0210-SMP-210P924', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63138, 97519 , 'DN1-3003-0210-SMP-210P925', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97518, 63139 , 'DN1-3003-0210-SMP-210P938', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97517, 63140 , 'DN1-3003-0210-SMP-210P939', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97493, 63144 , 'DN1-3003-0210-SMP-210P942B', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63145, 97494 , 'DN1-3003-0210-SMP-210P944', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97495, 63146 , 'DN1-3003-0210-SMP-210P945', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97496, 63147 , 'DN1-3003-0210-SMP-210P946', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63148, 97497 , 'DN1-3003-0210-SMP-210P947', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 63149, 97498 , 'DN1-3003-0210-SMP-210P948', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63150, 97499 , 'DN1-3003-0210-SMP-210P949', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97500, 63151 , 'DN1-3003-0210-SMP-210P951', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63152, 97501 , 'DN1-3003-0210-SMP-210P952', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63153, 97502 , 'DN1-3003-0210-SMP-210P953', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63154, 97503 , 'DN1-3003-0210-SMP-210P963', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63155, 97504 , 'DN1-3003-0210-SMP-210P964', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63156, 97505 , 'DN1-3003-0210-SMP-210P965', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63157, 97506 , 'DN1-3003-0210-SMP-210P966', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63158, 97507 , 'DN1-3003-0210-SMP-210P967', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63159, 97508 , 'DN1-3003-0210-SMP-210P968', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97509, 63160 , 'DN1-3003-0210-SMP-210P969', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97510, 63161 , 'DN1-3003-0210-SMP-210P970', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97511, 63162 , 'DN1-3003-0210-SMP-210P971', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97512, 63163 , 'DN1-3003-0210-SMP-210P974', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63164, 97525 , 'DN1-3003-0210-SMP-210P977', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63165, 97526 , 'DN1-3003-0210-SMP-210P978', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63166, 97516 , 'DN1-3003-0210-SMP-210P979', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63167, 97515 , 'DN1-3003-0210-SMP-210P983', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63168, 97514 , 'DN1-3003-0210-SMP-210P984', 0; -- min: 0 max: 0
go
exec z_DeleteDuplicateFloc 97513, 63169 , 'DN1-3003-0210-SMP-210P985', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97527, 63170 , 'DN1-3003-0210-SMP-210P986', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63171, 97528 , 'DN1-3003-0210-SMP-210P987', 0; -- min: 0 max: 1
exec z_DeleteDuplicateFloc 97529, 72479 , 'DN1-3003-0210-SMP-210P988', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97530, 72480 , 'DN1-3003-0210-SMP-210P989', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 97531, 72481 , 'DN1-3003-0210-SMP-210P990', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 113021, 72487 , 'DN1-3003-0210-SPT-210F111', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63183, 98448 , 'DN1-3003-0210-SPT-210TK10', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 98449, 63185 , 'DN1-3003-0210-SPT-210TK11', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63187, 98450 , 'DN1-3003-0210-SPT-210TK13', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63188, 98451 , 'DN1-3003-0210-SPT-210TK14', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63189, 98452 , 'DN1-3003-0210-SPT-210TK15', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 98453, 63190 , 'DN1-3003-0210-SPT-210TK16', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98454, 63191 , 'DN1-3003-0210-SPT-210TK16A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63192, 98455 , 'DN1-3003-0210-SPT-210TK17', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 98456, 63193 , 'DN1-3003-0210-SPT-210TK18', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63194, 98457 , 'DN1-3003-0210-SPT-210TK1S', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 63195, 98458 , 'DN1-3003-0210-SPT-210TK20', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 98459, 63196 , 'DN1-3003-0210-SPT-210TK23', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98460, 63197 , 'DN1-3003-0210-SPT-210TK24', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 98461, 63198 , 'DN1-3003-0210-SPT-210TK25', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98462, 63199 , 'DN1-3003-0210-SPT-210TK26', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63200, 98463 , 'DN1-3003-0210-SPT-210TK27', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 98464, 63202 , 'DN1-3003-0210-SPT-210TK2S', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98465, 63203 , 'DN1-3003-0210-SPT-210TK30', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98466, 63205 , 'DN1-3003-0210-SPT-210TK32', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63207, 98467 , 'DN1-3003-0210-SPT-210TK35', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63208, 98468 , 'DN1-3003-0210-SPT-210TK36', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63209, 98469 , 'DN1-3003-0210-SPT-210TK37', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63210, 98470 , 'DN1-3003-0210-SPT-210TK38', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 63212, 98471 , 'DN1-3003-0210-SPT-210TK3S', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 98472, 63213 , 'DN1-3003-0210-SPT-210TK4', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98473, 63214 , 'DN1-3003-0210-SPT-210TK40', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98474, 63215 , 'DN1-3003-0210-SPT-210TK41', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98475, 63216 , 'DN1-3003-0210-SPT-210TK42', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98476, 63217 , 'DN1-3003-0210-SPT-210TK43', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98477, 63221 , 'DN1-3003-0210-SPT-210TK47', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98478, 63222 , 'DN1-3003-0210-SPT-210TK48', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98479, 63223 , 'DN1-3003-0210-SPT-210TK49', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 98481, 63224 , 'DN1-3003-0210-SPT-210TK5', 0; -- min: 1 max: 0
go
exec z_DeleteDuplicateFloc 113018, 63238 , 'DN1-3003-0210-SPT-210TK62', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63245, 113019 , 'DN1-3003-0210-SPT-210TK8', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 113020, 63246 , 'DN1-3003-0210-SPT-210TK9', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110490, 72488 , 'DN1-3003-0210-SPT-210V112', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110918, 72584 , 'DN1-3003-0210-SSR-210PSV811', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 110917, 72583 , 'DN1-3003-0210-SSR-210PSV812', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 65150, 111037 , 'DN1-3003-0210-SSR-210RDV43', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 147564, 63398 , 'DN1-3003-0252-SMP-252IS506A', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63523, 113057 , 'DN1-3003-0310-SMP-310P1408', 1; -- min: 1 max: 1
exec z_DeleteDuplicateFloc 110692, 63609 , 'DN1-3003-0410-SAB-400HV0015', 0; -- min: 1 max: 0
exec z_DeleteDuplicateFloc 63730, 97470 , 'DN1-3003-0410-SMP-410P1012', 0; -- min: 0 max: 0
exec z_DeleteDuplicateFloc 97449, 63555 , 'DN1-3003-0310-SPT-310V111', 0; -- min: 1 max: 0
go


-- ------------------------------------------------------
-- Convert dependencies and delete flocs

		update ActionItemDefinitionFunctionalLocation 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join ActionItemDefinitionFunctionalLocation
		on FunctionalLocationId = ToDeleteId;

		go

		update ActionItemFunctionalLocation 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join ActionItemFunctionalLocation
		on FunctionalLocationId = ToDeleteId;

		go

		update LogDefinitionFunctionalLocation 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join LogDefinitionFunctionalLocation
		on FunctionalLocationId = ToDeleteId;

		go

		update LogFunctionalLocation 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join LogFunctionalLocation
		on FunctionalLocationId = ToDeleteId;

		go

		update SAPNotification 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join SAPNotification
		on FunctionalLocationId = ToDeleteId;

		go

		update TargetAlert 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join TargetAlert
		on FunctionalLocationId = ToDeleteId;

		go

		update TargetDefinition 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join TargetDefinition
		on FunctionalLocationId = ToDeleteId;

		go

		update TargetDefinitionHistory 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join TargetDefinitionHistory
		on FunctionalLocationId = ToDeleteId;

		go

		update WorkPermit 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join WorkPermit
		on FunctionalLocationId = ToDeleteId;

		go

		update WorkPermitHistory 
		set FunctionalLocationId = ToKeepId
		from z_DuplicateFloc
		inner join WorkPermitHistory
		on FunctionalLocationId = ToDeleteId;

		go

		delete FunctionalLocationAncestor
		where exists 
		(
			select ToDeleteId 
			from z_DuplicateFloc 
			where FunctionalLocationAncestor.Id = z_DuplicateFloc.ToDeleteId
		)

		go

		delete from FunctionalLocation
		where exists 
		(
			select ToDeleteId 
			from z_DuplicateFloc 
			where FunctionalLocation.Id = z_DuplicateFloc.ToDeleteId
		)

		go


-- ------------------------------------------------------
-- drop helpers
DROP TABLE z_DuplicateFloc
GO

DROP  Procedure  z_DeleteDuplicateFloc
GO


GO
