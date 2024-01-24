-- -----------------------------------------------------
-- InsertFunctionalLocation stored procedure is dropped during upgrade.  Put it in temporarily here.
-- -----------------------------------------------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[z_InsertFunctionalLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[z_InsertFunctionalLocation]
GO

CREATE Procedure [dbo].[z_InsertFunctionalLocation]
	(
	@Id bigint Output,
	@UnitId bigint = null Output,
	@FullHierarchy varchar(90),
	@SiteId bigint, 
	@Division varchar(15), 
	@Section varchar(15) = null, 
	@Unit varchar(15) = null,
	@Equipment1 varchar(15) = null, 
	@Equipment2 varchar(25) = null,
	@Description varchar(40) = null,
	@PlantId bigint
	)
AS

DECLARE @Level TINYINT
    
IF (@Division IS NOT NULL AND @Section IS NULL)
	SET @Level = 1
IF (@Division IS NOT NULL AND @Section IS NOT NULL AND @Unit IS NULL)
	SET @Level = 2
IF (@Division IS NOT NULL AND @Section IS NOT NULL AND @Unit IS NOT NULL AND @Equipment1 IS NULL)
	SET @Level = 3
IF (@Division IS NOT NULL AND @Section IS NOT NULL AND @Unit IS NOT NULL AND @Equipment1 IS NOT NULL AND @Equipment2 IS NULL)
	SET @Level = 4
IF (@Division IS NOT NULL AND @Section IS NOT NULL AND @Unit IS NOT NULL AND @Equipment1 IS NOT NULL AND @Equipment2 IS NOT NULL)
	SET @Level = 5

INSERT INTO FunctionalLocation
(SiteId, Division, [Section], Unit, Equipment1, Equipment2, Description, FullHierarchy, Deleted, OutOfService, [Level], PlantId)
VALUES     
(@SiteId,@Division,@Section,@Unit,@Equipment1,@Equipment2,@Description,@FullHierarchy, 0, 0, @Level, @PlantId)


SET @Id= SCOPE_IDENTITY() 
DECLARE @ParentID bigint

-- Set the ParentID of this FunctionalLocation
UPDATE FunctionalLocation
	SET ParentId = (
			SELECT 
				[Id]
			FROM
				FunctionalLocation
			WHERE
				SiteId = @SiteId
				AND [Level] = (@Level - 1)
				And [Deleted] = 0
				AND CHARINDEX(FullHierarchy, @FullHierarchy) = 1)
WHERE
	Id = @Id
	AND ParentId IS NULL
	AND [Level] > 1
	
		
-- Set the ParentID of all child FunctionalLocations that are already in the database
UPDATE 
	FunctionalLocation
SET 
	ParentId = @Id
WHERE
	SiteId = @SiteId
	AND
	[Level] = (@Level + 1)
	AND
	ParentId IS NULL
	AND
	Deleted = 0
	AND
	CHARINDEX(@FullHierarchy, FullHierarchy) = 1
	
			
-- Set the UnitID of this and all Child Functional Locations
UPDATE 
	FunctionalLocation
SET
	UnitId = (
		SELECT Id
		FROM FunctionalLocation
		WHERE
			[Level] = 3
			AND
			SiteId = @SiteId
			AND
			Deleted = 0
			AND
			CHARINDEX(FullHierarchy, @FullHierarchy) = 1
		)
WHERE
	SiteId = @SiteId
	AND [Level] > 2
	AND Deleted = 0
	AND CHARINDEX(@FullHierarchy, FullHierarchy) = 1
	AND UnitId IS NULL
		
-- Insert the Ancestor records for this Functional Location	
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id from FunctionalLocation c,
functionallocation a
where 
c.id = @Id
and 
a.Deleted = 0
and
a.siteid = c.siteid
and
c.[level] > a.[level]
and CHARINDEX(a.FullHierarchy, c.FullHierarchy) = 1)

-- Insert the Ancestor records for children now that the parent has been entered
INSERT INTO FunctionalLocationAncestor ([Id], [AncestorId]) (
select c.id, a.id 
	from FunctionalLocation c, functionallocation a
	where
		a.id = @Id
		and c.Deleted = 0
		and a.siteid = c.siteid
		and c.[level] > a.[level]
		and CHARINDEX(a.fullhierarchy, c.fullhierarchy) = 1
		and c.siteid = @SiteId
		and NOT EXISTS(Select [id], ancestorid from functionallocationancestor where [id] = c.id and ancestorid = a.id)
)
SET @UnitId = (SELECT UnitId From FunctionalLocation where ID = @Id)
GO 




-- -----------------------------------------------------
-- create a stored proc to help with deletes
-- -----------------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'z_DeleteBadFloc')
    BEGIN
        DROP  Procedure  z_DeleteBadFloc
    END

GO

CREATE Procedure [dbo].z_DeleteBadFloc
    (
        @ToDeleteId BIGINT,
		@DeleteFullHierarchy varchar(100),
		@CorrectFullHierarchy varchar(100),
		@CorrectDivision varchar(100)
    )

AS

begin

	if (exists(select f.Id from FunctionalLocation f where Id = @ToDeleteId and FullHierarchy = @DeleteFullHierarchy) and
		not exists(select f.Id from FunctionalLocation f where f.FullHierarchy = @CorrectFullHierarchy))
	begin

		DECLARE @Id bigint
		DECLARE @UnitId bigint
		DECLARE @SiteId bigint
		DECLARE @Section varchar(15)
		DECLARE @Unit varchar(15)
		DECLARE @Equipment1 varchar(15)
		DECLARE @Equipment2 varchar(25)
		DECLARE @Description varchar(40)
		DECLARE @PlantId bigint

		select 
			@SiteId = f.SiteId,
			@Section = f.Section,
			@Unit = f.Unit,
			@Equipment1 = f.Equipment1,
			@Equipment2 = f.Equipment2,
			@Description = f.Description,
			@PlantId = f.PlantId
		from FunctionalLocation f
		where Id = @ToDeleteId
		and FullHierarchy = @DeleteFullHierarchy;

		EXEC z_InsertFunctionalLocation
		   @Id OUTPUT
		  ,@UnitId OUTPUT
		  ,@CorrectFullHierarchy
		  ,@SiteId
		  ,@CorrectDivision
		  ,@Section
		  ,@Unit
		  ,@Equipment1
		  ,@Equipment2
		  ,@Description
		  ,@PlantId;

--		select
--		  @CorrectFullHierarchy
--		  ,@SiteId
--		  ,@CorrectDivision
--		  ,@Section
--		  ,@Unit
--		  ,@Equipment1
--		  ,@Equipment2
--		  ,@Description
--		  ,@PlantId

	end

	delete from FunctionalLocationAncestor
	where (Id = @ToDeleteId	or AncestorId = @ToDeleteId)
	and exists (select f.Id from FunctionalLocation f where Id = @ToDeleteId and FullHierarchy = @DeleteFullHierarchy);

	delete from FunctionalLocation
	where Id = @ToDeleteId
	and FullHierarchy = @DeleteFullHierarchy;

end

GO

-- -----------------------------------------------------
-- call store proc
-- -----------------------------------------------------
--select *
--from functionallocationancestor
--where ancestorid in (
--select id 
--from functionallocation
--where fullhierarchy like 'R1-%' or fullhierarchy like 'N1-%'
--)

--select *
--from functionallocation
--where id in (147819,	147818)

--select missing.*, f.id, f.siteid, f.fullhierarchy
--from 
--(
--select id, siteid, fullhierarchy
--from functionallocation
--where fullhierarchy like 'N1-%'
--) missing
--left join functionallocation f on 'D' + missing.fullhierarchy = f.fullhierarchy

--select 'exec z_DeleteBadFloc ' + convert(varchar, Id) + ', ''' + FullHierarchy + ''', ''S' + + FullHierarchy + ''', ''SR1'';'
--from functionallocation
--where fullhierarchy like 'R1-%' 
--order by fullhierarchy
--
--select 'exec z_DeleteBadFloc ' + convert(varchar, Id) + ', ''' + FullHierarchy + ''', ''D' + + FullHierarchy + ''', ''DN1'';'
--from functionallocation
--where fullhierarchy like 'N1-%' 
--order by fullhierarchy

exec z_DeleteBadFloc 147815, 'R1-PLT2-REF2-SIC-F23009', 'SR1-PLT2-REF2-SIC-F23009', 'SR1';
exec z_DeleteBadFloc 147738, 'R1-PLT4-SAP4-SIL-F44127', 'SR1-PLT4-SAP4-SIL-F44127', 'SR1';
exec z_DeleteBadFloc 147739, 'R1-PLT4-SAP4-SIL-F44215', 'SR1-PLT4-SAP4-SIL-F44215', 'SR1';

go

exec z_DeleteBadFloc 147827, 'N1-3003-0001-SLE-01EJ111', 'DN1-3003-0001-SLE-01EJ111', 'DN1';
exec z_DeleteBadFloc 147828, 'N1-3003-0001-SLP-PC0260', 'DN1-3003-0001-SLP-PC0260', 'DN1';
exec z_DeleteBadFloc 147829, 'N1-3003-0001-SLP-PC0261', 'DN1-3003-0001-SLP-PC0261', 'DN1';
exec z_DeleteBadFloc 147830, 'N1-3003-0001-SLP-PC0262', 'DN1-3003-0001-SLP-PC0262', 'DN1';
exec z_DeleteBadFloc 147831, 'N1-3003-0001-SLP-PC0263', 'DN1-3003-0001-SLP-PC0263', 'DN1';
exec z_DeleteBadFloc 147832, 'N1-3003-0001-SLP-PC0264', 'DN1-3003-0001-SLP-PC0264', 'DN1';
exec z_DeleteBadFloc 147833, 'N1-3003-0001-SLP-PC0265', 'DN1-3003-0001-SLP-PC0265', 'DN1';
exec z_DeleteBadFloc 147834, 'N1-3003-0001-SLP-PC0266', 'DN1-3003-0001-SLP-PC0266', 'DN1';
exec z_DeleteBadFloc 147816, 'N1-3003-0005-SLE-BS1', 'DN1-3003-0005-SLE-BS1', 'DN1';
exec z_DeleteBadFloc 147817, 'N1-3003-0005-SLE-BS2', 'DN1-3003-0005-SLE-BS2', 'DN1';
exec z_DeleteBadFloc 147840, 'N1-3003-0005-SLP-PC0162', 'DN1-3003-0005-SLP-PC0162', 'DN1';
exec z_DeleteBadFloc 147841, 'N1-3003-0005-SLP-PC0163', 'DN1-3003-0005-SLP-PC0163', 'DN1';
exec z_DeleteBadFloc 147842, 'N1-3003-0005-SLP-PC0164', 'DN1-3003-0005-SLP-PC0164', 'DN1';
exec z_DeleteBadFloc 147843, 'N1-3003-0005-SLP-PC0165', 'DN1-3003-0005-SLP-PC0165', 'DN1';
exec z_DeleteBadFloc 147844, 'N1-3003-0005-SLP-PC0166', 'DN1-3003-0005-SLP-PC0166', 'DN1';
exec z_DeleteBadFloc 147804, 'N1-3003-0005-SMF-F61', 'DN1-3003-0005-SMF-F61', 'DN1';
exec z_DeleteBadFloc 147805, 'N1-3003-0005-SMF-F62', 'DN1-3003-0005-SMF-F62', 'DN1';
exec z_DeleteBadFloc 147752, 'N1-3003-0005-SPH-X121', 'DN1-3003-0005-SPH-X121', 'DN1';
exec z_DeleteBadFloc 147753, 'N1-3003-0005-SPH-X341', 'DN1-3003-0005-SPH-X341', 'DN1';
exec z_DeleteBadFloc 147754, 'N1-3003-0005-SPH-X91', 'DN1-3003-0005-SPH-X91', 'DN1';
exec z_DeleteBadFloc 147755, 'N1-3003-0005-SPH-XF321', 'DN1-3003-0005-SPH-XF321', 'DN1';
exec z_DeleteBadFloc 147756, 'N1-3003-0005-SPH-XF359', 'DN1-3003-0005-SPH-XF359', 'DN1';
exec z_DeleteBadFloc 147757, 'N1-3003-0005-SPT-D181', 'DN1-3003-0005-SPT-D181', 'DN1';
exec z_DeleteBadFloc 147868, 'N1-3003-0008-SIL-08X474', 'DN1-3003-0008-SIL-08X474', 'DN1';
exec z_DeleteBadFloc 147865, 'N1-3003-0008-SLP-PC0176', 'DN1-3003-0008-SLP-PC0176', 'DN1';
exec z_DeleteBadFloc 147866, 'N1-3003-0008-SLP-PC0177', 'DN1-3003-0008-SLP-PC0177', 'DN1';
exec z_DeleteBadFloc 147867, 'N1-3003-0008-SLP-PC0178', 'DN1-3003-0008-SLP-PC0178', 'DN1';
exec z_DeleteBadFloc 147835, 'N1-3003-0010-SLP-PC0275', 'DN1-3003-0010-SLP-PC0275', 'DN1';
exec z_DeleteBadFloc 147836, 'N1-3003-0010-SLP-PC0276', 'DN1-3003-0010-SLP-PC0276', 'DN1';
exec z_DeleteBadFloc 147837, 'N1-3003-0010-SLP-PC0277', 'DN1-3003-0010-SLP-PC0277', 'DN1';
exec z_DeleteBadFloc 147838, 'N1-3003-0010-SLP-PC0278', 'DN1-3003-0010-SLP-PC0278', 'DN1';
exec z_DeleteBadFloc 147839, 'N1-3003-0010-SLP-PC0279', 'DN1-3003-0010-SLP-PC0279', 'DN1';
exec z_DeleteBadFloc 147845, 'N1-3003-0016-SLP-PC0734', 'DN1-3003-0016-SLP-PC0734', 'DN1';
exec z_DeleteBadFloc 147846, 'N1-3003-0016-SLP-PC0735', 'DN1-3003-0016-SLP-PC0735', 'DN1';
exec z_DeleteBadFloc 147847, 'N1-3003-0016-SLP-PC0736', 'DN1-3003-0016-SLP-PC0736', 'DN1';
exec z_DeleteBadFloc 147848, 'N1-3003-0016-SLP-PC0737', 'DN1-3003-0016-SLP-PC0737', 'DN1';
exec z_DeleteBadFloc 147849, 'N1-3003-0016-SLP-PC0738', 'DN1-3003-0016-SLP-PC0738', 'DN1';
exec z_DeleteBadFloc 147758, 'N1-3003-0017-SLE-DS1799', 'DN1-3003-0017-SLE-DS1799', 'DN1';
exec z_DeleteBadFloc 147759, 'N1-3003-0017-SLE-S1715', 'DN1-3003-0017-SLE-S1715', 'DN1';
exec z_DeleteBadFloc 147760, 'N1-3003-0017-SLE-S17151', 'DN1-3003-0017-SLE-S17151', 'DN1';
exec z_DeleteBadFloc 147761, 'N1-3003-0017-SLE-S17152', 'DN1-3003-0017-SLE-S17152', 'DN1';
exec z_DeleteBadFloc 147762, 'N1-3003-0017-SLE-S17153', 'DN1-3003-0017-SLE-S17153', 'DN1';
exec z_DeleteBadFloc 147763, 'N1-3003-0017-SLE-S17154', 'DN1-3003-0017-SLE-S17154', 'DN1';
exec z_DeleteBadFloc 147764, 'N1-3003-0017-SLE-S1724', 'DN1-3003-0017-SLE-S1724', 'DN1';
exec z_DeleteBadFloc 147765, 'N1-3003-0017-SMF-C17151', 'DN1-3003-0017-SMF-C17151', 'DN1';
exec z_DeleteBadFloc 147766, 'N1-3003-0017-SMF-F17150', 'DN1-3003-0017-SMF-F17150', 'DN1';
exec z_DeleteBadFloc 147767, 'N1-3003-0017-SMF-F17167', 'DN1-3003-0017-SMF-F17167', 'DN1';
exec z_DeleteBadFloc 147768, 'N1-3003-0017-SMP-J17501', 'DN1-3003-0017-SMP-J17501', 'DN1';
exec z_DeleteBadFloc 147769, 'N1-3003-0017-SMP-J17511', 'DN1-3003-0017-SMP-J17511', 'DN1';
exec z_DeleteBadFloc 147770, 'N1-3003-0017-SMP-P17114', 'DN1-3003-0017-SMP-P17114', 'DN1';
exec z_DeleteBadFloc 147771, 'N1-3003-0017-SMP-P17115', 'DN1-3003-0017-SMP-P17115', 'DN1';
exec z_DeleteBadFloc 147772, 'N1-3003-0017-SMP-P1716', 'DN1-3003-0017-SMP-P1716', 'DN1';
exec z_DeleteBadFloc 147773, 'N1-3003-0017-SMP-P17191', 'DN1-3003-0017-SMP-P17191', 'DN1';
exec z_DeleteBadFloc 147774, 'N1-3003-0017-SMP-P17201', 'DN1-3003-0017-SMP-P17201', 'DN1';
exec z_DeleteBadFloc 147775, 'N1-3003-0017-SMP-P1750', 'DN1-3003-0017-SMP-P1750', 'DN1';
exec z_DeleteBadFloc 147776, 'N1-3003-0017-SMP-P1751', 'DN1-3003-0017-SMP-P1751', 'DN1';
exec z_DeleteBadFloc 147777, 'N1-3003-0017-SMP-P1780', 'DN1-3003-0017-SMP-P1780', 'DN1';
exec z_DeleteBadFloc 147778, 'N1-3003-0017-SMP-P1794', 'DN1-3003-0017-SMP-P1794', 'DN1';
exec z_DeleteBadFloc 147779, 'N1-3003-0017-SPH-H1714', 'DN1-3003-0017-SPH-H1714', 'DN1';
exec z_DeleteBadFloc 147780, 'N1-3003-0017-SPH-H17141', 'DN1-3003-0017-SPH-H17141', 'DN1';
exec z_DeleteBadFloc 147781, 'N1-3003-0017-SPH-H1719', 'DN1-3003-0017-SPH-H1719', 'DN1';
exec z_DeleteBadFloc 147782, 'N1-3003-0017-SPH-H1720', 'DN1-3003-0017-SPH-H1720', 'DN1';
exec z_DeleteBadFloc 147783, 'N1-3003-0017-SPH-X17123', 'DN1-3003-0017-SPH-X17123', 'DN1';
exec z_DeleteBadFloc 147784, 'N1-3003-0017-SPH-X17124', 'DN1-3003-0017-SPH-X17124', 'DN1';
exec z_DeleteBadFloc 147785, 'N1-3003-0017-SPH-X17125', 'DN1-3003-0017-SPH-X17125', 'DN1';
exec z_DeleteBadFloc 147786, 'N1-3003-0017-SPH-X17126', 'DN1-3003-0017-SPH-X17126', 'DN1';
exec z_DeleteBadFloc 147787, 'N1-3003-0017-SPH-X17127', 'DN1-3003-0017-SPH-X17127', 'DN1';
exec z_DeleteBadFloc 147788, 'N1-3003-0017-SPH-X1715', 'DN1-3003-0017-SPH-X1715', 'DN1';
exec z_DeleteBadFloc 147806, 'N1-3003-0017-SPH-X17150', 'DN1-3003-0017-SPH-X17150', 'DN1';
exec z_DeleteBadFloc 147789, 'N1-3003-0017-SPH-X17152', 'DN1-3003-0017-SPH-X17152', 'DN1';
exec z_DeleteBadFloc 147790, 'N1-3003-0017-SPH-X1718', 'DN1-3003-0017-SPH-X1718', 'DN1';
exec z_DeleteBadFloc 147791, 'N1-3003-0017-SPH-X17182', 'DN1-3003-0017-SPH-X17182', 'DN1';
exec z_DeleteBadFloc 147792, 'N1-3003-0017-SPH-X1761', 'DN1-3003-0017-SPH-X1761', 'DN1';
exec z_DeleteBadFloc 147793, 'N1-3003-0017-SPH-X1763', 'DN1-3003-0017-SPH-X1763', 'DN1';
exec z_DeleteBadFloc 147794, 'N1-3003-0017-SPH-X1764', 'DN1-3003-0017-SPH-X1764', 'DN1';
exec z_DeleteBadFloc 147795, 'N1-3003-0017-SPH-X1766', 'DN1-3003-0017-SPH-X1766', 'DN1';
exec z_DeleteBadFloc 147796, 'N1-3003-0017-SPH-X1791', 'DN1-3003-0017-SPH-X1791', 'DN1';
exec z_DeleteBadFloc 147797, 'N1-3003-0017-SPT-D1773', 'DN1-3003-0017-SPT-D1773', 'DN1';
exec z_DeleteBadFloc 147798, 'N1-3003-0017-SPT-W1725', 'DN1-3003-0017-SPT-W1725', 'DN1';
exec z_DeleteBadFloc 147799, 'N1-3003-0017-SPT-W1758', 'DN1-3003-0017-SPT-W1758', 'DN1';
exec z_DeleteBadFloc 147800, 'N1-3003-0017-SPT-W1759', 'DN1-3003-0017-SPT-W1759', 'DN1';
exec z_DeleteBadFloc 147801, 'N1-3003-0017-SSF-FA17181', 'DN1-3003-0017-SSF-FA17181', 'DN1';
exec z_DeleteBadFloc 147802, 'N1-3003-0017-SSF-FA17182', 'DN1-3003-0017-SSF-FA17182', 'DN1';
exec z_DeleteBadFloc 147803, 'N1-3003-0017-SSF-FA17183', 'DN1-3003-0017-SSF-FA17183', 'DN1';
exec z_DeleteBadFloc 147823, 'N1-3003-0019-SLP-PC0490', 'DN1-3003-0019-SLP-PC0490', 'DN1';
exec z_DeleteBadFloc 147824, 'N1-3003-0019-SLP-PC0491', 'DN1-3003-0019-SLP-PC0491', 'DN1';
exec z_DeleteBadFloc 147825, 'N1-3003-0019-SLP-PC0492', 'DN1-3003-0019-SLP-PC0492', 'DN1';
exec z_DeleteBadFloc 147826, 'N1-3003-0019-SLP-PC0493', 'DN1-3003-0019-SLP-PC0493', 'DN1';
exec z_DeleteBadFloc 147813, 'N1-3003-0019-SMP-P1904', 'DN1-3003-0019-SMP-P1904', 'DN1';
exec z_DeleteBadFloc 147814, 'N1-3003-0019-SMP-P1905', 'DN1-3003-0019-SMP-P1905', 'DN1';
exec z_DeleteBadFloc 147812, 'N1-3003-0019-SMP-P800', 'DN1-3003-0019-SMP-P800', 'DN1';
exec z_DeleteBadFloc 147810, 'N1-3003-0019-SPH-X1918', 'DN1-3003-0019-SPH-X1918', 'DN1';
exec z_DeleteBadFloc 147850, 'N1-3003-0035-SLP-PC0730', 'DN1-3003-0035-SLP-PC0730', 'DN1';
exec z_DeleteBadFloc 147851, 'N1-3003-0035-SLP-PC0731', 'DN1-3003-0035-SLP-PC0731', 'DN1';
exec z_DeleteBadFloc 147852, 'N1-3003-0035-SLP-PC0732', 'DN1-3003-0035-SLP-PC0732', 'DN1';
exec z_DeleteBadFloc 147853, 'N1-3003-0035-SLP-PC0733', 'DN1-3003-0035-SLP-PC0733', 'DN1';
exec z_DeleteBadFloc 147854, 'N1-3003-0035-SLP-PC0734', 'DN1-3003-0035-SLP-PC0734', 'DN1';
exec z_DeleteBadFloc 147820, 'N1-3003-0038-SLP-PC0053', 'DN1-3003-0038-SLP-PC0053', 'DN1';
exec z_DeleteBadFloc 147740, 'N1-3003-0039-SIL-39F204', 'DN1-3003-0039-SIL-39F204', 'DN1';
exec z_DeleteBadFloc 147741, 'N1-3003-0039-SIL-39F241', 'DN1-3003-0039-SIL-39F241', 'DN1';
exec z_DeleteBadFloc 147742, 'N1-3003-0039-SIL-39F250', 'DN1-3003-0039-SIL-39F250', 'DN1';
exec z_DeleteBadFloc 147743, 'N1-3003-0039-SIL-39F3921', 'DN1-3003-0039-SIL-39F3921', 'DN1';
exec z_DeleteBadFloc 147744, 'N1-3003-0039-SIL-39F394', 'DN1-3003-0039-SIL-39F394', 'DN1';
exec z_DeleteBadFloc 147745, 'N1-3003-0039-SIL-39F527', 'DN1-3003-0039-SIL-39F527', 'DN1';
exec z_DeleteBadFloc 147746, 'N1-3003-0039-SIL-39F529', 'DN1-3003-0039-SIL-39F529', 'DN1';
exec z_DeleteBadFloc 147747, 'N1-3003-0039-SIL-39L230', 'DN1-3003-0039-SIL-39L230', 'DN1';
exec z_DeleteBadFloc 147748, 'N1-3003-0039-SIL-39L235', 'DN1-3003-0039-SIL-39L235', 'DN1';
exec z_DeleteBadFloc 147749, 'N1-3003-0039-SIL-39X025', 'DN1-3003-0039-SIL-39X025', 'DN1';
exec z_DeleteBadFloc 147750, 'N1-3003-0039-SIL-39X201', 'DN1-3003-0039-SIL-39X201', 'DN1';
exec z_DeleteBadFloc 147751, 'N1-3003-0039-SIL-39X235', 'DN1-3003-0039-SIL-39X235', 'DN1';
exec z_DeleteBadFloc 147811, 'N1-3003-0040-SLP-PC0600', 'DN1-3003-0040-SLP-PC0600', 'DN1';
exec z_DeleteBadFloc 147809, 'N1-3003-0047-SSF-FFS54', 'DN1-3003-0047-SSF-FFS54', 'DN1';
exec z_DeleteBadFloc 147818, 'N1-3003-0055-SLE', 'DN1-3003-0055-SLE', 'DN1';
exec z_DeleteBadFloc 147819, 'N1-3003-0055-SLE-BFP5501', 'DN1-3003-0055-SLE-BFP5501', 'DN1';
exec z_DeleteBadFloc 147821, 'N1-3003-0075-SCH-OC7502', 'DN1-3003-0075-SCH-OC7502', 'DN1';
exec z_DeleteBadFloc 147855, 'N1-3003-0077-SLP-PC0348', 'DN1-3003-0077-SLP-PC0348', 'DN1';
exec z_DeleteBadFloc 147856, 'N1-3003-0077-SLP-PC0349', 'DN1-3003-0077-SLP-PC0349', 'DN1';
exec z_DeleteBadFloc 147857, 'N1-3003-0077-SLP-PC0350', 'DN1-3003-0077-SLP-PC0350', 'DN1';
exec z_DeleteBadFloc 147858, 'N1-3003-0077-SLP-PC0351', 'DN1-3003-0077-SLP-PC0351', 'DN1';
exec z_DeleteBadFloc 147859, 'N1-3003-0077-SLP-PC0352', 'DN1-3003-0077-SLP-PC0352', 'DN1';
exec z_DeleteBadFloc 147860, 'N1-3003-0092-SLP-PC0162', 'DN1-3003-0092-SLP-PC0162', 'DN1';
exec z_DeleteBadFloc 147861, 'N1-3003-0092-SLP-PC0163', 'DN1-3003-0092-SLP-PC0163', 'DN1';
exec z_DeleteBadFloc 147862, 'N1-3003-0092-SLP-PC0164', 'DN1-3003-0092-SLP-PC0164', 'DN1';
exec z_DeleteBadFloc 147863, 'N1-3003-0092-SLP-PC0165', 'DN1-3003-0092-SLP-PC0165', 'DN1';
exec z_DeleteBadFloc 147864, 'N1-3003-0092-SLP-PC0166', 'DN1-3003-0092-SLP-PC0166', 'DN1';
exec z_DeleteBadFloc 147822, 'N1-3003-0145-SMP-P735', 'DN1-3003-0145-SMP-P735', 'DN1';
exec z_DeleteBadFloc 147807, 'N1-3003-0210-SLP-PC1202', 'DN1-3003-0210-SLP-PC1202', 'DN1';
exec z_DeleteBadFloc 147808, 'N1-3003-0210-SLP-PC1209', 'DN1-3003-0210-SLP-PC1209', 'DN1';


GO

-- -----------------------------------------------------
-- cleanup
-- -----------------------------------------------------
drop procedure z_DeleteBadFloc;
drop procedure z_InsertFunctionalLocation;
GO
