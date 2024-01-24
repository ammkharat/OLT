IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP Procedure [dbo].FunctionalLocationAddOrUndelete
	END
GO

CREATE Procedure [dbo].FunctionalLocationAddOrUndelete
  (
    @SiteId bigint,
    @Division VARCHAR(15),
    @Section VARCHAR(15),
    @Unit VARCHAR(30),
    @Equipment1 VARCHAR(15),
    @Equipment2 VARCHAR(25),
    @Description VARCHAR(50),
    @FullHierarchy VARCHAR(90), 
    @PlantId bigint,
    @Level tinyint
  )
AS

IF NOT EXISTS(SELECT * FROM FunctionalLocation
  where FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId)
  BEGIN
    INSERT INTO FunctionalLocation (
       SiteId,Division,[Section],Unit,Equipment1,Equipment2
      ,Description,FullHierarchy,OutOfService,UnitId,Deleted
      ,ParentId,[Level],PlantId,Culture
    ) VALUES (
       @SiteId   -- SiteId - bigint
      ,@Division  -- Division - varchar(15)
      ,@Section  -- Section - varchar(15)
      ,@Unit  -- Unit - varchar(30)
      ,@Equipment1  -- Equipment1 - varchar(15)
      ,@Equipment2  -- Equipment2 - varchar(25)
      ,@Description  -- Description - varchar(50)
      ,@FullHierarchy  -- FullHierarchy - varchar(90)
      ,0  -- OutOfService - bit
      ,null   -- UnitId - bigint
      ,0  -- Deleted - bit
      ,null   -- ParentId - bigint
      ,@Level   -- Level - tinyint
      ,@PlantId   -- PlantId - bigint
	  ,'fr'
    )
      
  END
  
  IF EXISTS(SELECT * FROM FunctionalLocation 
    where FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId AND DELETED = 1)
  BEGIN
    UPDATE FunctionalLocation
      SET 
      DELETED = 0,
      OutOfService = 1
    WHERE
      FullHierarchy = @FullHierarchy AND SiteId = @SiteId AND PlantId = @PlantId AND DELETED = 1
  END
GO

--  INSERT OR UNDELETE HERE --
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U020',N'SIV',N'MOV204',N'DERIVATION ALIMENTATION HUILE FCCU',N'MT1-A001-U020-SIV-MOV204',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U065',N'SLP',N'065M000',N'CIRCUIT DE CAUSTIQUE',N'MT1-A001-U065-SLP-065M000',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U350',N'SEG',N'ACO3501',N'APPAREIL COMMUTATION 4KV-1200A (SSE5105)',N'MT1-A001-U350-SEG-ACO3501',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U350',N'SIL',N'P35157',N'VAPEUR / L-3543',N'MT1-A001-U350-SIL-P35157',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U350',N'SIL',N'T350128',N'TEMP ASPHALTE - TK-852',N'MT1-A001-U350-SIL-T350128',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U550',N'SEG',N'NTM0420',N'TRANSFORMATEUR 0420',N'MT1-A001-U550-SEG-NTM0420',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U550',N'SEG',N'NTM0430',N'TRANSFORMATEUR 0430',N'MT1-A001-U550-SEG-NTM0430',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'F040133',N'INJECTION AZOTE JOINT PALIER DE  J-441',N'MT1-A001-U560-SIL-F040133',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'F040134',N'INJECTION AZOTE JOINT PALIER NDE  J-441',N'MT1-A001-U560-SIL-F040134',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'P040324',N'HUILE LUBRIFICATION VERS PALIER J-441',N'MT1-A001-U560-SIL-P040324',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'P040325',N'FILTRE SYS. HUILE DE LUBRIFICATION J-441',N'MT1-A001-U560-SIL-P040325',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'P040326',N'GAZ D''EQUILIBRAGE PILOT PCV-441',N'MT1-A001-U560-SIL-P040326',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'P040328',N'AMONT FILTRE HUILE LUB. J-441',N'MT1-A001-U560-SIL-P040328',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'T040211',N'HUILE LUB. VERS PALIER J-441',N'MT1-A001-U560-SIL-T040211',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'T040212',N'PALIER NONE DRIVE END COMPRESSEUR J-441',N'MT1-A001-U560-SIL-T040212',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A001',N'U560',N'SIL',N'T040213',N'PALIER DRIVE END COMPRESSEUR J-441',N'MT1-A001-U560-SIL-T040213',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U400',N'SSR',N'RVF4006',N'SOUPAPE DE SURETE DU BALLON F-4006',N'MT1-A002-U400-SSR-RVF4006',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U410',N'SIL',N'F410187',N'CHROMATOGRAPHE BENZENE - AT-4101-2',N'MT1-A002-U410-SIL-F410187',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U410',N'SIL',N'F410188',N'CHROMATOGRAPHE BENZENE - AT-4101-2',N'MT1-A002-U410-SIL-F410188',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U430',N'SEG',N'NTH4302',N'TRANSFORMATEUR 4302',N'MT1-A002-U430-SEG-NTH4302',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U430',N'SEG',N'NTH4303',N'TRANSFORMATEUR 4303',N'MT1-A002-U430-SEG-NTH4303',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U440',N'SIL',N'P44224',N'TX PRESSION / LEAN BENFIELD / J-4403',N'MT1-A002-U440-SIL-P44224',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U440',N'SIL',N'P44225',N'TX PRESSION / LEAN BENFIELD / J-4403A',N'MT1-A002-U440-SIL-P44225',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U460',N'SSR',N'RVF4604',N'SOUPAPE DE SURETE DU BALLON F-4604',N'MT1-A002-U460-SSR-RVF4604',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U460',N'SSR',N'RVJ4606',N'SOUPAPE DE DECHARGE-RVJ4606',N'MT1-A002-U460-SSR-RVJ4606',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U460',N'SSR',N'RVJ4606A',N'SOUPAPE DE DECHARGE-HUILE LUBRIFIANTE',N'MT1-A002-U460-SSR-RVJ4606A',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SIL',N'P470282',N'PRESSION AZOTE JOINT MÉCANIQUE J-4704',N'MT1-A002-U470-SIL-P470282',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SIL',N'P470283',N'PRESSION AZOTE JOINT MÉCANIQUE J-4704',N'MT1-A002-U470-SIL-P470283',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SIL',N'P470284',N'PRESSION AZOTE JOINT MÉCANIQUE J-4704',N'MT1-A002-U470-SIL-P470284',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SIL',N'P470285',N'PRESSION AZOTE JOINT MÉCANIQUE J-4704A',N'MT1-A002-U470-SIL-P470285',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SIL',N'P470286',N'PRESSION AZOTE JOINT MÉCANIQUE J-4704A',N'MT1-A002-U470-SIL-P470286',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SIL',N'P470287',N'PRESSION AZOTE JOINT MÉCANIQUE J-4704A',N'MT1-A002-U470-SIL-P470287',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SLE',N'R470096',N'RESTRICTION DÉBIT JOINT MÉC J-4704',N'MT1-A002-U470-SLE-R470096',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SLE',N'R470097',N'RESTRICTION DÉBIT JOINT MÉC J-4704',N'MT1-A002-U470-SLE-R470097',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U470',N'SSR',N'RVF4708',N'SOUPAPE DE SURETE DU BALLON F-4708',N'MT1-A002-U470-SSR-RVF4708',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A002',N'U510',N'SIL',N'P510085',N'AMINE / E-5104',N'MT1-A002-U510-SIL-P510085',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A003',N'U120',N'SPH',N'U1207',N'CHAUDIERE NO 8 ( U-1207 )',N'MT1-A003-U120-SPH-U1207',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A003',N'U150',N'SIL',N'L150019',N'ANALYSEUR CHIMIQUE EN CONTINU CW',N'MT1-A003-U150-SIL-L150019',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A003',N'U172',N'SSR',N'RVJ2307B_2',N'RV-J-2307B-2',N'MT1-A003-U172-SSR-RVJ2307B_2',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A003',N'U620',N'SEG',N'UPN620004',N'PANNEAU DE DISTRIBUTION UPN-620004',N'MT1-A003-U620-SEG-UPN620004',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A003',N'U620',N'SEG',N'UPN620005',N'PANNEAU DE DISTRIBUTION UPN-620005',N'MT1-A003-U620-SEG-UPN620005',302,5;
EXEC dbo.FunctionalLocationAddOrUndelete 9, N'MT1',N'A004',N'U840',N'SMP',N'J840001',N'POMPE PORTATIVE À MOTEUR DIESEL SECT.#3',N'MT1-A004-U840-SMP-J840001',302,5;
--  INSERT OR UNDELETE ENDS HERE --

-- Drop the temporary stored procedure
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'FunctionalLocationAddOrUndelete')
	BEGIN
		DROP Procedure FunctionalLocationAddOrUndelete
	END
GO




-------------------------------------------------
---  Insert Operational Modes for each Unit   ---
-------------------------------------------------
DECLARE @NORMAL_OPERATIONAL_MODE BIGINT;
SET @NORMAL_OPERATIONAL_MODE = 0;
DECLARE @AVAILABILITY_REASON_NONE BIGINT;
SET @AVAILABILITY_REASON_NONE = 0;

BEGIN TRANSACTION
INSERT INTO FunctionalLocationOperationalMode
( UnitId, OperationalModeId, AvailabilityReasonId, LastModifiedDateTime)
(
    Select
        FunctionalLocation.Id,
        @NORMAL_OPERATIONAL_MODE,
        @AVAILABILITY_REASON_NONE,
        GETDATE()
    FROM
        FunctionalLocation
    WHERE
		Level = 3
		AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
)
COMMIT TRANSACTION
GO

-------------------------------------------
---  Update UnitId for Unit Level Floc  ---
-------------------------------------------
BEGIN TRANSACTION
update 
	FunctionalLocation
set 
	UnitId = Id
where 
	Level = 3
	and UnitId IS NULL
COMMIT TRANSACTION	
GO

-------------------------------------------------
---  Update UnitId for Equipment1 Level Floc  ---
-------------------------------------------------
BEGIN TRANSACTION
update fl1
set 
	fl1.UnitId = fl2.UnitId
from 
	FunctionalLocation fl1,
	FunctionalLocation fl2
where 
	fl1.Level = 4
	and fl2.Level = 3
	and fl1.UnitId IS NULL
	and fl1.Siteid = fl2.SiteId
	and fl2.Division = fl1.Division
	and fl2.Section = fl1.Section
	and fl2.Unit = fl1.Unit
COMMIT TRANSACTION	
GO


-------------------------------------------------
---  Update UnitId for Equipment2 Level Floc  ---
-------------------------------------------------
BEGIN TRANSACTION
update fl1
set 
	fl1.UnitId = fl2.Id
from 
	FunctionalLocation fl1,
	FunctionalLocation fl2
where 
	fl1.[Level] = 5
	and fl2.[Level] = 3
	and fl1.SiteId = fl2.SiteId
	and fl1.UnitId IS NULL
	and fl2.Division = fl1.Division
	and fl2.Section = fl1.Section
	and fl2.Unit = fl1.Unit
COMMIT TRANSACTION
GO

-----------------------------------------------
-- Update Parent Id for Section Level Floc  ---
-----------------------------------------------
BEGIN TRANSACTION
UPDATE FunctionalLocation
SET
    ParentId = (
        SELECT DivisionFloc.id
        FROM
            FunctionalLocation DivisionFloc
        WHERE
            DivisionFloc.[Level] = 1
            AND DivisionFloc.Division = FunctionalLocation.Division)
WHERE 
    FunctionalLocation.ParentId IS NULL AND
    FunctionalLocation.[Level] = 2 
COMMIT TRANSACTION    
GO

--------------------------------------------
-- Update Parent Id for Unit Level Floc  ---
--------------------------------------------
BEGIN TRANSACTION
UPDATE FunctionalLocation
SET
    ParentId = (
        SELECT SectionFloc.id
        FROM
            FunctionalLocation SectionFloc
        WHERE
			SectionFloc.SiteId = FunctionalLocation.SiteId
            AND SectionFloc.[Level] = 2
            AND SectionFloc.[Division] = FunctionalLocation.Division
            AND SectionFloc.Section = FunctionalLocation.Section)
WHERE 
    FunctionalLocation.ParentId IS NULL AND	
    FunctionalLocation.[Level] = 3
COMMIT TRANSACTION
GO

--------------------------------------------------
-- Update Parent Id for Equipment1 Level Floc  ---
--------------------------------------------------
BEGIN TRANSACTION
UPDATE FunctionalLocation
SET ParentId = ( UnitId ) 
WHERE FunctionalLocation.[Level] = 4
COMMIT TRANSACTION
GO

--------------------------------------------------
-- Update Parent Id for Equipment2 Level Floc  ---
--------------------------------------------------
BEGIN TRANSACTION
UPDATE f
  Set f.ParentId = p.id
 from FunctionalLocation F
 INNER JOIN FunctionalLocation p
 on (
  p.siteid = f.siteid
  and p.[level] = 4
  and f.[level] = 5
  and p.Division = f.Division
  and p.[Section] = f.[Section]
  and p.Unit = f.Unit
  and p.Equipment1 = f.Equipment1
  )
where   
  f.parentid is null
  and f.[level] = 5
COMMIT TRANSACTION
GO


--------------------------------------------------
-- Update Ancestor Table                       ---
--------------------------------------------------
-- create a temp index for fast querying
CREATE NONCLUSTERED INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy]
ON [dbo].[FunctionalLocation]
([Level], [SiteId], [Division], [Section], [Unit], [Equipment1], [Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DROP_EXISTING = OFF
)
ON [PRIMARY];

DECLARE @SiteId bigint
SET @SiteId = 9

-- Child Level 2, Parent Level 1
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
a.siteid = c.siteid
and
c.[level] = 2
and
c.[level] > a.[level]
and 
c.Division = a.Division
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 3, Parent Level 1
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
a.siteid = c.siteid
and
c.[level] = 3
and
a.[level] = 1
and 
c.Division = a.Division 
and 
CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 3, Parent Level 2
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
a.siteid = c.siteid
and
c.[level] = 3
and
a.[level] = 2
and 
c.Division = a.Division and c.Section = a.Section
and 
CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 4, Parent Level 3
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.Id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
c.level = 4
and
a.level = 3
and 
c.Division = a.Division and c.Section = a.Section and c.Unit = a.Unit
and
CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 4, Parent Level 1
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
a.siteid = c.siteid
and
c.[level] = 4
and
a.[level] = 1
and 
c.Division = a.Division
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 4, Parent Level 2
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
a.siteid = c.siteid
and
c.[level] = 4
and
a.[level] = 2
and 
c.Division = a.Division and c.Section = a.Section
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 5, Parent Level 4
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
c.[level] = 5
and
a.[level] = 4
and
c.Division = a.Division and c.[Section] = a.[Section] and c.Unit = a.Unit and c.Equipment1 = a.Equipment1
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 5, Parent Level 3
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
c.level = 5
and
a.level = 3
and
c.Division = a.Division and c.Section = a.Section and c.Unit = a.Unit 
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 5, Parent Level 2
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
a.siteid = c.siteid
and
c.[level] = 5
and
a.[level] = 2
and
c.Division = a.Division and c.Section = a.Section 
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)



-- Child Level 5, Parent Level 1
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
a.siteid = @SiteId
and
a.siteid = c.siteid
and
c.[level] = 5
and
a.[level] = 1
and
c.Division = a.Division
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1
and NOT EXISTS(select id from FunctionalLocationAncestor where id = c.id and ancestorid = a.id)
)
GO

DROP INDEX [IDX_FunctionalLocation_Temp_SiteId_FullHierarchy] ON [dbo].[FunctionalLocation];
GO


-- DELETE RECORDS HERE --
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A001-U550-SEG-NTM0411%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A001-U550-SEG-NTM0412%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A002-U450-SPH-C4515%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U160-SIL-A1670%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U160-SIL-A1671%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U160-SIL-A1672%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U170-SEG-BBP2301%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U170-SEG-IPU2302AC%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U170-SSR-RVJ2307B_2%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U170-SWM-OUTIL%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U172-SSR-RVO000008%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A003-U172-SSR-RVO000009%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A004-U540-SWM-OUTIL%' and SiteId = 9 and Level >= 5
UPDATE dbo.FunctionalLocation SET Deleted = 1 where FullHierarchy like N'MT1-A004-U840-SWM-OUTIL%' and SiteId = 9 and Level >= 5
-- DELETE RECORDS ENDS HERE --
GO

-- UPDATE DESCRIPTIONS HERE --
UPDATE dbo.FunctionalLocation SET Description = N'CIRCUIT D''AIR D"INSTRUMENTATION' where FullHierarchy = 'MT1-A001-U010-SLP-010U500' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'D283 ALIMEN. HUILE A L''INJECTEUR "A"' where FullHierarchy = 'MT1-A001-U020-SIL-F02302' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'POMPE " LIGHT CYCLE " (Hors-Service)' where FullHierarchy = 'MT1-A001-U020-SMP-J0284' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE D''OXYGENE O-27592-4"' where FullHierarchy = 'MT1-A001-U020-SSR-M27592' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE D''OXYGENE O-27592-4"' where FullHierarchy = 'MT1-A001-U020-SSR-RVO27592' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'POMPE D''ALIM. "PRIME G"' where FullHierarchy = 'MT1-A001-U050-SMP-J0504A' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'POMPE D''ALIM. "PRIME G"' where FullHierarchy = 'MT1-A001-U050-SMP-J0504B' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'Rés. condensat "power trap skid"' where FullHierarchy = 'MT1-A001-U050-SPT-F0513' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'ALIMENTATION VERS "PETROMONT"' where FullHierarchy = 'MT1-A001-U065-SIL-F0430' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RETOUR DE "PETROMONT"' where FullHierarchy = 'MT1-A001-U065-SIL-F0450' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'GAZ/ "PETROMONT" HAUTE PRESSION' where FullHierarchy = 'MT1-A001-U065-SIL-P0430' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'GAZ VENANT DE "PETROMONT"' where FullHierarchy = 'MT1-A001-U065-SIL-P0434' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'GAZ/"PETROMONT"' where FullHierarchy = 'MT1-A001-U065-SIL-T0430' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'GAZ/"PETROMONT"' where FullHierarchy = 'MT1-A001-U065-SIL-T0431' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RÉSERVOIR HYDROPNEUMATIQUE au "CHLLER"' where FullHierarchy = 'MT1-A001-U065-SPT-F0657' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RÉSERVOIR HYDROPNEUMATIQUE au "CHLLER"' where FullHierarchy = 'MT1-A001-U065-SPT-F0658' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'UNITÉ DE RÉFRIGÉRATION "CHILLER" AGGREKO' where FullHierarchy = 'MT1-A001-U065-SPT-L0652' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COND 0-584-6" RVV/CANMET' where FullHierarchy = 'MT1-A001-U100-SSR-M0584' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COND 0-584-6" RVV/CANMET' where FullHierarchy = 'MT1-A001-U100-SSR-RVO584' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'440-DEA-109-8"-UD-12' where FullHierarchy = 'MT1-A001-U390-SIL-Z4428' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'APPAREIL DE COMMUTATION PRINC ACO-4301' where FullHierarchy = 'MT1-A002-U430-SEG-ACO4301' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COMPRES. GAZ APPOINT "A"' where FullHierarchy = 'MT1-A002-U430-SSR-J4301A' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COMPRES. GAZ APPOINT "B"' where FullHierarchy = 'MT1-A002-U430-SSR-J4301B' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COMPRES. GAZ APPOINT "C"' where FullHierarchy = 'MT1-A002-U430-SSR-J4301C' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COMPRES. GAZ APPOINT "A"' where FullHierarchy = 'MT1-A002-U430-SSR-RVJ4301A1' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COMPRES. GAZ APPOINT "B"' where FullHierarchy = 'MT1-A002-U430-SSR-RVJ4301B1' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-COMPRES. GAZ APPOINT "C"' where FullHierarchy = 'MT1-A002-U430-SSR-RVJ4301C1' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'APPAREIL DE COMMUTATION PRINC ACO-4403' where FullHierarchy = 'MT1-A002-U440-SEG-ACO4403' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'APPAREIL DE COMMUTATION 4.16 KV ACO-4404' where FullHierarchy = 'MT1-A002-U440-SEG-ACO4404' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'INDIC DEBIT / 440-BF-105-2"-UD-3' where FullHierarchy = 'MT1-A002-U440-SIL-F44107' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'INDIC DEBIT / 440-BF-139-2"-SD-1' where FullHierarchy = 'MT1-A002-U440-SIL-F44116' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'INDIC DEBIT / 440-BD-123-1/2"-SB-1' where FullHierarchy = 'MT1-A002-U440-SIL-F44118' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'PRESSION E-4401' where FullHierarchy = 'MT1-A002-U440-SIL-P4431' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'17''9" B4402' where FullHierarchy = 'MT1-A002-U440-SIL-T44080' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'15''9" D4402' where FullHierarchy = 'MT1-A002-U440-SIL-T44081' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'13''9" B4402' where FullHierarchy = 'MT1-A002-U440-SIL-T44082' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'11''9" B4402' where FullHierarchy = 'MT1-A002-U440-SIL-T44083' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'9''9" B4402' where FullHierarchy = 'MT1-A002-U440-SIL-T44084' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'TEMPERATURE 440-O-146-10"-UD-3' where FullHierarchy = 'MT1-A002-U440-SIL-T44229' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'D4403 NO 2 = 13''8 1/2"' where FullHierarchy = 'MT1-A002-U440-SIL-T4489' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'D4403 NO 4 = 17''11 1/2"' where FullHierarchy = 'MT1-A002-U440-SIL-T4490' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SILENCIEUX DU "DEGASSIFER" E4405' where FullHierarchy = 'MT1-A002-U440-SLE-L4458' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RV-114-20" & BD-108-20"' where FullHierarchy = 'MT1-A002-U440-SLP-440Y038' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME PILOTE "A" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51401A' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME PILOTE "B" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51401B' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME PILOTE "C" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51401C' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME PILOTE "D" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51401D' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME BRULEUR "A" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51410A' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME BRULEUR "B" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51410B' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME BRULEUR "C" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51410C' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉTEC. FLAMME BRULEUR "D" B-5101' where FullHierarchy = 'MT1-A002-U510-SIL-B51410D' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SECTION "1" ÉPUISEUR E-5102' where FullHierarchy = 'MT1-A002-U510-SIL-T51502' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SECTION "2" ÉPUISEUR E-5102' where FullHierarchy = 'MT1-A002-U510-SIL-T51504' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SECTION "3" ÉPUISEUR E-5102' where FullHierarchy = 'MT1-A002-U510-SIL-T51505' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SECTION "6" ÉPUISEUR E-5102' where FullHierarchy = 'MT1-A002-U510-SIL-T51506' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE DE J-5120 VERS O-0044-8"' where FullHierarchy = 'MT1-A002-U510-SIV-MOV51268S' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE DE J-5130 VERS O-0044-8"' where FullHierarchy = 'MT1-A002-U510-SIV-MOV51340S' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE DE J-5130 VERS O-0186-8"' where FullHierarchy = 'MT1-A002-U510-SIV-MOV51368S' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RECHAUFFEUR AZOTE "DRY SEAL"  J5120' where FullHierarchy = 'MT1-A002-U510-SPH-C5125' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RECHAUFFEUR AZOTE "DRY SEAL" J5130' where FullHierarchy = 'MT1-A002-U510-SPH-C5135' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'DÉBIT AIR AU "SHOOTBLOWER" /  U1207' where FullHierarchy = 'MT1-A003-U120-SIL-F12712' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE 12" ALIMENTATION EAU BRUTE' where FullHierarchy = 'MT1-A003-U160-SIL-P1624' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RVO-10161-8" 61R/D (EST TK808' where FullHierarchy = 'MT1-A003-U170-SSR-M10161' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE RVO-15896 -12" D/L MOV16148' where FullHierarchy = 'MT1-A003-U170-SSR-M15896' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'REFOUL J1816 12"D/L (EST TK804)' where FullHierarchy = 'MT1-A003-U170-SSR-M1816' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'REFOUL J1816 12"D/L (EST TK804)' where FullHierarchy = 'MT1-A003-U170-SSR-RV1816' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RVO-10161-8" 61R/D (EST TK808' where FullHierarchy = 'MT1-A003-U170-SSR-RVO10161' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'CONDUITE RVO-15896 -12" D/L MOV16148' where FullHierarchy = 'MT1-A003-U170-SSR-RVO15896' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH. 16" AU SUD DE 1507' where FullHierarchy = 'MT1-A003-U171-SSR-M1670' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH. 16" AU SUD DE 1507' where FullHierarchy = 'MT1-A003-U171-SSR-S1670' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RAFFINAT VERS LIGNE 10" DU QUAI' where FullHierarchy = 'MT1-A003-U172-SIV-MOV16146' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'Injection de "Claoud Point Improver"' where FullHierarchy = 'MT1-A003-U172-SSR-J1653' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-ALIM CAT 6" G+12E' where FullHierarchy = 'MT1-A003-U172-SSR-M10276' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-DIESEL 4" G+12E' where FullHierarchy = 'MT1-A003-U172-SSR-M17051' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-54 TRANSFERT 10" G+4E' where FullHierarchy = 'MT1-A003-U172-SSR-M17055' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-ESS 1ER DIST 6" G+12E' where FullHierarchy = 'MT1-A003-U172-SSR-M18026' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-54 TRANSFERT 10" G+4E' where FullHierarchy = 'MT1-A003-U172-SSR-RV17055' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'Injection de "Claoud Point Improver"' where FullHierarchy = 'MT1-A003-U172-SSR-RVJ1653' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-ALIM CAT 6" G+12E' where FullHierarchy = 'MT1-A003-U172-SSR-RVO10276' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-DIESEL 4" G+12E' where FullHierarchy = 'MT1-A003-U172-SSR-RVO17051' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE DECH-ESS 1ER DIST 6" G+12E' where FullHierarchy = 'MT1-A003-U172-SSR-RVO18026' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'8" FORESHORE LINE' where FullHierarchy = 'MT1-A003-U190-SLP-190L000' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE SURETÉ 8" FORESHORE LINE' where FullHierarchy = 'MT1-A003-U190-SSR-M19000' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RV DE 20" HFO SORTIE TUNNEL' where FullHierarchy = 'MT1-A003-U190-SSR-M19176' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RV COND. 12" Benz. SORTIE TUNNEL' where FullHierarchy = 'MT1-A003-U190-SSR-M19179' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'RV CONDUITE O1929-8" (MOV1904)' where FullHierarchy = 'MT1-A003-U190-SSR-M19291' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'SOUPAPE DE SURETÉ 8" FORESHORE LINE' where FullHierarchy = 'MT1-A003-U190-SSR-RVO19000' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'VAPEUR TÊTE TORCHE SUD 6"' where FullHierarchy = 'MT1-A003-U260-SIL-S2643' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'EPURATEUR DES GAZ ("DAF")' where FullHierarchy = 'MT1-A003-U280-SPC-L28115' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'BALLON DE PRESSURISATION "DAF" SUD' where FullHierarchy = 'MT1-A003-U280-SPT-F2815' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'BALLON DE PRESSURISATION "DAF" NORD' where FullHierarchy = 'MT1-A003-U280-SPT-F2816' and SiteId = 9
UPDATE dbo.FunctionalLocation SET Description = N'POMPE D''INJECTION DE "TRAVAID"' where FullHierarchy = 'MT1-A003-U480-SMP-J4815' and SiteId = 9
-- UPDATE DESCRIPTIONS ENDS HERE --
GO

-- ------------------------------

INSERT INTO DbVersion (
   VersionNumber
) VALUES (
   '4.1.5248'  -- VersionNumber - varchar(20)
)
GO