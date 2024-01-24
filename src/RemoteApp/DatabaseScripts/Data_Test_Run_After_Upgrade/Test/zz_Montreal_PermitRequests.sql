IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'zz_AddTestPermitRequest')
	BEGIN
		DROP  Procedure  [dbo].zz_AddTestPermitRequest
	END

GO

CREATE Procedure [dbo].zz_AddTestPermitRequest
	(
		@PERMIT_TYPE as int,
		@FLOC AS VARCHAR(MAX),
		@START AS DATETIME,
		@END AS DATETIME,
		@WORK_ORDER_NUMBER AS VARCHAR(MAX),
		@TRADE AS VARCHAR(MAX),
		@USER_NAME AS varchar(max),
		@DESCRIPTION AS VARCHAR(MAX)
	)

AS

DECLARE @USER_ID AS BIGINT;
SET @USER_ID = (select Id from [User] where username = @USER_NAME);

DECLARE @FLOC_ID AS BIGINT;
SET @FLOC_ID = (select Id from FunctionalLocation where fullhierarchy = @FLOC);

DECLARE @DATE as datetime;
set @DATE = getdate();

INSERT INTO PermitRequestMontreal
(
	WorkPermitTypeId,
    StartDate,
	EndDate,
	WorkOrderNumber,
	Trade,
	Description,
	SapDescription,
	SourceId,
	LastImportedByUserId,
	LastImportedDateTime,
	LastSubmittedByUserId,
	LastSubmittedDateTime,
	CreatedByUserId,
	CreatedDateTime,
	LastModifiedByUserId,
	LastModifiedDateTime,
	IsModified,
	CompletionStatusId,
	Deleted
)
VALUES
(	
	@PERMIT_TYPE,
	@START + datediff(day, '2011-11-21', getdate()) ,
	@END + datediff(day, '2011-11-21', getdate()) ,
	@WORK_ORDER_NUMBER,
	@TRADE,
	@DESCRIPTION,
	null, -- no SAP description possible for [Source = Manual]
	0, -- [Source = Manual]
	null,
	null,
	null,
	null,
	@USER_ID,
	@DATE,
	@USER_ID,
	@DATE,
	0,
	2,  -- incomplete
	0
)

insert into PermitRequestMontrealFunctionalLocation (PermitRequestMontrealId, FunctionalLocationId) select IDENT_CURRENT('PermitRequestMontreal'), Id from FunctionalLocation where FullHierarchy = @FLOC;

GO

-- -----------------------------------------------------------------------------------------

insert into [user] select 'ymaranda', 'Yvon', 'Maranda', '00000000', 0, 1, getdate();
insert into [user] select 'aboyer', 'Andre', 'Boyer', '00000000', 0, 1, getdate();
insert into [user] select 'ndouge', 'Natacha', 'Douge', '00000000', 0, 1, getdate();

GO

-- -----------------------------------------------------------------------------------------


-- aromatics
DECLARE @unit400 AS VARCHAR(MAX);
SET @unit400 = 'MT1-A002-U400';
DECLARE @unit410 AS VARCHAR(MAX);
SET @unit410 = 'MT1-A002-U410';
DECLARE @unit450 AS VARCHAR(MAX);
SET @unit450 = 'MT1-A002-U450';
DECLARE @unit470 AS VARCHAR(MAX);
SET @unit470 = 'MT1-A002-U470';
exec zz_AddTestPermitRequest 1, @unit400, '2011-11-21', '2011-11-25', null, 'Électricien', 'ymaranda', 'passer cable  de ijb-400-103  vers mp-40/*45-100a/t et ijb -400-104a  vm /tm-4010'
exec zz_AddTestPermitRequest 3, @unit400, '2011-11-21', '2011-11-21', '30447002', 'Journalier', 'SAPUser', '20 - Disposer baril (poubelles) - Arômatiques (SPC)'
exec zz_AddTestPermitRequest 1, @unit400, '2011-11-21', '2011-11-21', '30445141', 'Inspecteur', 'SAPUser', '30 - FAIRE TEST (SERVICE TECHNIQUE) (SAS)'
exec zz_AddTestPermitRequest 1, @unit400, '2011-11-27', '2011-12-31', null, 'Calorifugeur', 'jlacroix', 'Enlever et installer isolation selon la liste aux complexes des Arômatiques. Travaux effectués par la Calorifugeur du secteur #2'
exec zz_AddTestPermitRequest 1, @unit400, '2011-11-21', '2011-11-21', null, 'Mécanicien industriel', 'lgoulet', 'J4005 ENLEVER OBTURATEURS'
exec zz_AddTestPermitRequest 1, @unit400, '2011-11-01', '2011-11-30', null, 'Instrumentation', 'cgravel', 'Routine analyseurs  40-41-42-45-46-47'
exec zz_AddTestPermitRequest 1, @unit410, '2011-11-21', '2011-11-24', null, 'Électricien', 'ymaranda', 'installer tracer sur nouvelle ligne benzene /eau pres f 4106'
exec zz_AddTestPermitRequest 1, @unit410, '2011-11-21', '2011-11-21', '160151', 'Journalier', 'glizotte', 'cassé béton sur poutre  sur la ligne d''eau 4152 à 4101'
exec zz_AddTestPermitRequest 1, @unit410, '2011-11-21', '2011-11-24', null, 'Calorifugeur', 'lmorel', 'Enlever et installer isolation sur tuyauterie au J-4152 et J-4169.'
exec zz_AddTestPermitRequest 1, @unit410, '2011-11-04', '2011-11-22', null, 'Tuyauteur', 'pdebellefeui', 'nouvelle ligne d''eau de J-4152 vers F-4101 faire traceur a vapeur ,défaire échaffaud et faire ménage'
exec zz_AddTestPermitRequest 1, @unit410, '2011-11-02', '2011-11-30', null, 'Mécanicien industriel', 'aboyer', 'vibrations équipements rotatif complexe (selon la liste)'
exec zz_AddTestPermitRequest 1, @unit450, '2011-11-21', '2011-11-21', '30443457', 'Électricien', 'SAPUser', '40 - Installer cable et attacher dans la nouv (SEG-ACO4501)'
exec zz_AddTestPermitRequest 1, @unit450, '2011-11-21', '2011-11-21', '30443457', 'Électricien', 'SAPUser', '50 - Enlevé cadenas (SEG-ACO4501)'
exec zz_AddTestPermitRequest 1, @unit470, '2011-11-21', '2011-11-25', null, 'Électricien', 'ymaranda', 'passer cable pour nouveau analyseur humiditéde mp-47-101a/t bj-47-111a et-470082'
exec zz_AddTestPermitRequest 1, @unit470, '2011-09-30', '2011-11-23', null, 'Tuyauteur', 'pdebellefeui', 'J-4701 installer paneau d''instrumentation pour nouveau analyseur d''humidité'
exec zz_AddTestPermitRequest 1, @unit470, '2011-10-11', '2011-11-23', null, 'Tuyauteur', 'pdebellefeui', 'J-4704''s faire l''installation de nouvelle tuyautrie pour seal pot faire teste hydro'
exec zz_AddTestPermitRequest 1, @unit470, '2011-11-21', '2011-11-21', '30442328', 'Calorifugeur', 'SAPUser', '50 - Refaire isolation selon liste F-4701 (SPT-F4701)'

-- crude 1
DECLARE @unit010 AS VARCHAR(MAX);
SET @unit010 = 'MT1-A001-U010';
DECLARE @unit050 AS VARCHAR(MAX);
SET @unit050 = 'MT1-A001-U050';
DECLARE @unit065 AS VARCHAR(MAX);
SET @unit065 = 'MT1-A001-U065';
DECLARE @unit090 AS VARCHAR(MAX);
SET @unit090 = 'MT1-A001-U090';
exec zz_AddTestPermitRequest 1, @unit010, '2011-11-21', '2011-11-22', null, 'Électricien', 'ymaranda', 'INSTALLER TRACER NOUVEAU BY PASS SUR LIGNE O-16730-4 ET MODIFIER HPC 010-13 ET HPN010016'
exec zz_AddTestPermitRequest 1, @unit010, '2011-11-21', '2011-11-21', 160151, 'Menuisier', 'glizotte', 'échaffaudage 1er chemin et 12eme rue'
exec zz_AddTestPermitRequest 3, @unit010, '2011-11-21', '2011-11-21', 30445264, 'Mécanicien industriel', 'SAPUser', '20 - Enlever la pompe. (SMP-J0135A)'
exec zz_AddTestPermitRequest 3, @unit010, '2011-11-21', '2011-11-21', 30445264, 'Tuyauteur', 'SAPUser', 'J-0135 A -  Vérifier le tamis'
exec zz_AddTestPermitRequest 3, @unit010, '2011-11-21', '2011-11-21', null, 'Mécanicien industriel', 'lgoulet', 'J135A  CHANGER ROULEMENT ET JOINT'
exec zz_AddTestPermitRequest 1, @unit010, '2011-05-30', '2011-12-30', null, 'Calorifugeur', 'jleduc', 'Isolation selon les demandes. Calorifugeur Secteur # 1'
exec zz_AddTestPermitRequest 1, @unit010, '2011-11-21', '2011-12-23', null, 'Mécanicien industriel', 'pturcotte', 'investiguer et vérifier les vibration des équipements rotatif du complexe '
exec zz_AddTestPermitRequest 1, @unit010, '2011-11-21', '2011-11-21', null, 'Tuyauteur', 'erleblanc', 'RÉPARER FUITE DE VAPEUR DANS L''UNITÉ'
exec zz_AddTestPermitRequest 1, @unit050, '2011-11-21', '2011-11-21', 30442368, 'Électricien', 'SAPUser', '9 - Barrer le moteur 4KVa J512A'
exec zz_AddTestPermitRequest 3, @unit050, '2011-11-21', '2011-11-21', 30442368, 'Tuyauteur', 'SAPUser', 'ENLEVER LA RVF-0504'
exec zz_AddTestPermitRequest 1, @unit050, '2011-11-21', '2011-11-21', null, 'Tuyauteur', 'erleblanc', 'RÉPARER FUITES DE VAPEUR DANS L''UNITÉ.'
exec zz_AddTestPermitRequest 3, @unit065, '2011-11-21', '2011-11-21', 30443761, 'Monteur d echaffaudage', 'SAPUser', '10 - INSTALLER ÉCHAFAUDAGE C-656 (SPH-C0656)'
exec zz_AddTestPermitRequest 1, @unit090, '2011-11-21', '2011-11-21', null, 'Électricien', 'ndouge','deplacer instrument pour shutdown'
exec zz_AddTestPermitRequest 3, @unit090, '2011-11-21', '2011-11-21', 30442365, 'Tuyauteur', 'SAPUser', 'ENLEVER LA RVJ2601A2'
 
-- rp&s
DECLARE @unit170 AS VARCHAR(MAX);
SET @unit170 = 'MT1-A003-U170';
DECLARE @unit171 AS VARCHAR(MAX);
SET @unit171 = 'MT1-A003-U171';
DECLARE @unit172 AS VARCHAR(MAX);
SET @unit172 = 'MT1-A003-U172';
DECLARE @unit173 AS VARCHAR(MAX);
SET @unit173 = 'MT1-A003-U173';
DECLARE @unit174 AS VARCHAR(MAX);
SET @unit174 = 'MT1-A003-U174';
DECLARE @unit190 AS VARCHAR(MAX);
SET @unit190 = 'MT1-A003-U190';
DECLARE @unit200 AS VARCHAR(MAX);
SET @unit200 = 'MT1-A003-U200';
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', null, 'Journalier', 'ndouge', 'excavation ligne incendie avec un hydro-vac, 3e rue et ave C'
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', null, 'Journalier', 'ndouge', 'raccordement ligne incendie'
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', null,		 'Électricien', 'ndouge','approche instrumentation T-808' 
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', '160151', 'Journalier', 'glizotte', 'excavation pour sondage de la ligne NPL 1, 3ieme avenue'
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', '160151', 'Journalier', 'glizotte', 'Excavation pour sondage et tuyauterie sur 1iere rue et avenue c'
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', '160151', 'Journalier', 'glizotte', 'faire forme pour béton et remblais, projet propane '
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', '160151', 'Journalier', 'glizotte', 'remblaie merlon avec 2 excavatrices, pépine et camion'
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', '160151', 'Journalier', 'glizotte', 'remblais de la tuyauterie à la 3iem et H avec plaque vibrante et rouleau compacteur'
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', '30446633', 'Journalier', 'SAPUser', '10 - Faire le ménage garage Bitumar (FST-SAB)'
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-21', '2011-11-21', '30441830', 'Journalier', 'SAPUser', '10 - nettoyage générale secteur TCLR (SAA)'
exec zz_AddTestPermitRequest 1, @unit170, '2011-09-15', '2011-12-30', null, 'Calorifugeur', 'ccyr', 'isolation selon la liste secteur RPS '
exec zz_AddTestPermitRequest 1, @unit170, '2011-11-04', '2011-12-30', null, 'Tuyauteur', 'ccyr', 'reparation travaux mineur selon la liste secteur RPS au complet'
exec zz_AddTestPermitRequest 1, @unit171, '2011-11-18', '2011-11-21', null, 'Tuyauteur', 'pdebellefeui', 'installer hose de la TK-4003 jusqu''au lanceur pour MPL 2'
exec zz_AddTestPermitRequest 1, @unit171, '2011-11-21', '2011-12-23', null, 'Mécanicien industriel', 'pturcotte', 'investiguer et vérifier les vibration des équipements rotatif du complexe'
exec zz_AddTestPermitRequest 1, @unit172, '2011-11-04', '2011-11-25', null, 'Tuyauteur', 'pdebellefeui', 'faire installation de spool et lanceur pour la ligne MPL1 au nord ouest de la TK 1506 '
exec zz_AddTestPermitRequest 1, @unit172, '2011-11-21', '2011-11-21', '45475069', 'Mécanicien industriel', 'SAPUser', '10 - Entretien PULSATION DAMPENER J2307A/ J2307B'
exec zz_AddTestPermitRequest 1, @unit172, '2011-11-21', '2011-11-21', '45475069', 'Électricien', 'SAPUser', '2 - Mettre tracer hors service (SMP) &  Remettre tracer en service '
exec zz_AddTestPermitRequest 1, @unit172, '2011-11-21', '2011-11-21', '45475069', 'Calorifugeur', 'SAPUser', '5 - Enlever couverture sur dampener (SMP) et remettre au besoin'
exec zz_AddTestPermitRequest 1, @unit173, '2011-11-21', '2011-11-21', '30441985', 'Menuisier', 'SAPUser', '10 - FAB.PASSERELLES BOIS J-1701(TEXTE)'
exec zz_AddTestPermitRequest 3, @unit173, '2011-11-21', '2011-11-21', '30443300', 'Opérateur de camion sous-vide', 'SAPUser', '10 - NETTOYER PUISARD AD-1751 (SIL-L1731751)'
exec zz_AddTestPermitRequest 1, @unit173, '2011-11-21', '2011-11-21', '30443300', 'Instrumentation', 'SAPUser', '20 - VÉRIFIER LT-1731751, PUISARD AD-1751 (SIL-L1731751)'
exec zz_AddTestPermitRequest 1, @unit174, '2011-11-21', '2011-11-21', '160151',	 'Journalier', 'glizotte', 'remblais eau d''incendie ave K et 3iem chemin'
exec zz_AddTestPermitRequest 1, @unit190, '2011-11-21', '2011-11-25', null, 'Électricien', 'ymaranda', 'faire raccordement des cables pour protection haut niveau tk 1801'
exec zz_AddTestPermitRequest 1, @unit190, '2011-11-21', '2011-11-25', null, 'Électricien', 'ymaranda','INSTALLER TRACER POUR LIGNE DE SUCON J1926' 
exec zz_AddTestPermitRequest 1, @unit190, '2011-11-21', '2011-11-29', null, 'Électricien', 'ymaranda', 'mobiliser et passer cale pour tk 499 protection haut niveau et branchement tk 1801'
exec zz_AddTestPermitRequest 1, @unit190, '2011-11-21', '2011-11-25', null, 'Tuyauteur', 'pdebellefeui', 'changer ligne de 12" entre TK 499 et 191'
exec zz_AddTestPermitRequest 4, @unit190, '2011-11-21', '2011-11-21', '160151',	 'Journalier', 'glizotte', 'relocalisé les dormants au tk-191 et coupé armature'
exec zz_AddTestPermitRequest 1, @unit200, '2011-11-21', '2011-11-21', '160151',	 'Journalier', 'glizotte', 'décoffrage et ramasser toile isolante et cloture 3iem avenue coté nord de sherbrooke '
exec zz_AddTestPermitRequest 1, @unit200, '2011-11-21', '2011-11-21', '160151',	 'Journalier', 'glizotte', 'décoffrage et remblais 3iem avenue coté sud de sherbrooke'
exec zz_AddTestPermitRequest 1, @unit200, '2011-11-21', '2011-11-21', '160151',	 'Journalier', 'glizotte', 'remblais de la conduites 2ieme et 3ieme coté nord shebrooke Distillat #2'

go

-- -----------------------------------------------------------------------------------------

DROP  Procedure  [dbo].zz_AddTestPermitRequest;

