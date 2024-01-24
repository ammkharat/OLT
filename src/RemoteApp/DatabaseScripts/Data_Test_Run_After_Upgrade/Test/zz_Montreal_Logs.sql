IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'zz_AddTestLogData')
	BEGIN
		DROP  Procedure  [dbo].zz_AddTestLogData
	END

GO

CREATE Procedure [dbo].zz_AddTestLogData
	(
		@LOG_TYPE AS INT,
		@FLOC AS VARCHAR(MAX),
		@WORK_ASSIGNMENT AS BIGINT,
		@USER_NAME AS varchar(max),
		@SHIFT_ID AS BIGINT,
		@LOG_TIME AS VARCHAR(MAX),
		@LOG_DAY_DELTA AS INT,
		@LOG_TEXT AS VARCHAR(MAX),
		@CREATED_BY_ROLE_ID AS BIGINT
	)

AS

DECLARE @USER_ID AS BIGINT;
SET @USER_ID = (select Id from [User] where username = @USER_NAME);

DECLARE @LOG_DATE AS DATETIME;
SET @LOG_DATE = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110) + ' ' + @LOG_TIME + '.000') + @LOG_DAY_DELTA;

insert into Log(RtfComments,PlainTextComments,WorkAssignmentId,SourceId,LogType,Deleted,RecommendForShiftSummary,LogDateTime,UserId,LastModifiedDateTime,LastModifiedUserId,CreationUserShiftPatternId,EHSFollowup,InspectionFollowUp,ProcessControlFollowUp,OperationsFollowUp,SupervisionFollowUp,OtherFollowUp,CreatedDateTime, CreatedByRoleId, IsOperatingEngineerLog, HasChildren) 
values(@LOG_TEXT,@LOG_TEXT,@WORK_ASSIGNMENT,0,@LOG_TYPE,0,0,@LOG_DATE,@USER_ID,@LOG_DATE,@USER_ID,@SHIFT_ID,0,0,0,0,0,0,@LOG_DATE, @CREATED_BY_ROLE_ID,0,0);
insert into LogFunctionalLocation (LogId, FunctionalLocationId) select IDENT_CURRENT('Log'), Id from FunctionalLocation where FullHierarchy = @FLOC;


if @log_type = 1 and @FLOC != 'MT1-A004-IFST' and not exists (select * from ShiftHandoverQuestionnaire where ShiftId = @SHIFT_ID and WorkAssignmentId = @WORK_ASSIGNMENT and CreatedByUserID = @USER_ID) 
begin
	insert into ShiftHandoverQuestionnaire(ShiftHandoverConfigurationName, ShiftId, WorkAssignmentId, CreatedByUserId, CreatedDateTime, LastModifiedDateTime, HasYesAnswer)
	values ('Relève de Quart Quotidien', @SHIFT_ID, @WORK_ASSIGNMENT, @USER_ID, @LOG_DATE, @LOG_DATE, 0);

	insert into ShiftHandoverQuestionnaireFunctionalLocation(ShiftHandoverQuestionnaireId, FunctionalLocationId)
	select IDENT_CURRENT('ShiftHandoverQuestionnaire'), FunctionalLocationId
	from WorkAssignmentFunctionalLocation
	where WorkAssignmentId = @WORK_ASSIGNMENT;

	insert into ShiftHandoverAnswer (ShiftHandoverQuestionnaireId, Answer, Comments, QuestionDisplayOrder, ShiftHandoverQuestionId)
	select IDENT_CURRENT('ShiftHandoverQuestionnaire'), 0, null, b.DisplayOrder, b.Id
	from ShiftHandoverConfiguration a,
	ShiftHandoverQuestion b
	where a.Name = 'Relève de Quart Quotidien'
	and a.Id = b.ShiftHandoverConfigurationId;
end


GO

-- -----------------------------------------------------------------------------------------


CREATE Procedure [dbo].zz_AddTestSummaryLogData
	(
		@FLOC AS VARCHAR(MAX),
		@WORK_ASSIGNMENT AS BIGINT,
		@USER_NAME AS varchar(max),
		@SHIFT_ID AS BIGINT,
		@LOG_TIME AS VARCHAR(MAX),
		@LOG_DAY_DELTA AS INT,
		@LOG_TEXT AS VARCHAR(MAX)
	)

AS

DECLARE @USER_ID AS BIGINT;
SET @USER_ID = (select Id from [User] where username = @USER_NAME);

DECLARE @LOG_DATE AS DATETIME;
SET @LOG_DATE = CONVERT(DATETIME, CONVERT(char(10), GetDate(), 110) + ' ' + @LOG_TIME + '.000') + @LOG_DAY_DELTA;

DECLARE @supervisor_role_id AS bigint;
SET @supervisor_role_id = (select id from role where siteId = 9 and name = 'Superviseur');

insert into SummaryLog(WorkAssignmentId,Deleted,LogDateTime,CreatedDateTime,CreationUserShiftPatternId,CreatedByUserId,LastModifiedDateTime,LastModifiedUserId,EHSFollowup,InspectionFollowUp,ProcessControlFollowUp,OperationsFollowUp,SupervisionFollowUp,OtherFollowUp,CreatedByRoleId,RtfComments,PlainTextComments,HasChildren, DataSourceId) 
values(@WORK_ASSIGNMENT,0,@LOG_DATE,@LOG_DATE,@SHIFT_ID,@USER_ID,@LOG_DATE,@USER_ID,0,0,0,0,0,0,@supervisor_role_id,@LOG_TEXT,@LOG_TEXT,0,0);
insert into SummaryLogFunctionalLocation (SummaryLogId, FunctionalLocationId) select IDENT_CURRENT('SummaryLog'), Id from FunctionalLocation where FullHierarchy = @FLOC;

if not exists (select * from ShiftHandoverQuestionnaire where ShiftId = @SHIFT_ID and WorkAssignmentId = @WORK_ASSIGNMENT and CreatedByUserID = @USER_ID)
begin
	insert into ShiftHandoverQuestionnaire(ShiftHandoverConfigurationName, ShiftId, WorkAssignmentId, CreatedByUserId, CreatedDateTime, LastModifiedDateTime, HasYesAnswer)
	values ('Relève de Quart Quotidien', @SHIFT_ID, @WORK_ASSIGNMENT, @USER_ID, @LOG_DATE, @LOG_DATE, 0);

	insert into ShiftHandoverQuestionnaireFunctionalLocation(ShiftHandoverQuestionnaireId, FunctionalLocationId)
	select IDENT_CURRENT('ShiftHandoverQuestionnaire'), FunctionalLocationId
	from WorkAssignmentFunctionalLocation
	where WorkAssignmentId = @WORK_ASSIGNMENT;

	insert into ShiftHandoverAnswer (ShiftHandoverQuestionnaireId, Answer, Comments, QuestionDisplayOrder, ShiftHandoverQuestionId)
	select IDENT_CURRENT('ShiftHandoverQuestionnaire'), 0, null, b.DisplayOrder, b.Id
	from ShiftHandoverConfiguration a,
	ShiftHandoverQuestion b
	where a.Name = 'Relève de Quart Quotidien'
	and a.Id = b.ShiftHandoverConfigurationId;
end

GO

-- -----------------------------------------------------------------------------------------

-- operators
insert into [user] values ('dboutin', 'Daniel', 'Boutin', '00000000', 0, 1, getdate());
insert into [user] values ('almorin', 'Alain', 'Morin', '00000000', 0, 1, getdate());
insert into [user] values ('gbruneau', 'Ghyslain', 'Bruneau', '00000000', 0, 1, getdate());
insert into [user] values ('tankcar', 'Tank', 'Car', '00000000', 0, 1, getdate());
-- engineers
insert into [user] values ('agagnon', 'Andreane', 'Gagnon', '00000000', 0, 1, getdate());
-- lab
insert into [user] values ('cgirard', 'Cletus', 'Girard', '00000000', 0, 1, getdate());
GO

-- -----------------------------------------------------------------------------------------

DECLARE @DA_SHIFT_ID AS BIGINT;
SET @DA_SHIFT_ID = (SELECT [ID] FROM Shift where SiteId = 9 and [Name] = 'Jour')

DECLARE @NT_SHIFT_ID AS BIGINT;
SET @NT_SHIFT_ID = (SELECT [ID] FROM Shift where SiteId = 9 and [Name] = 'Nuit')

DECLARE @brut1 AS VARCHAR(MAX);
SET @brut1 = 'MT1-A001-U010';
DECLARE @brut38 AS VARCHAR(MAX);
SET @brut38 = 'MT1-A001-U380';
DECLARE @fccu AS VARCHAR(MAX);
SET @fccu = 'MT1-A001-U020';
DECLARE @u470 AS VARCHAR(MAX);
SET @u470 = 'MT1-A002-U470';
DECLARE @u400 AS VARCHAR(MAX);
SET @u400 = 'MT1-A002-U400';
DECLARE @u410 AS VARCHAR(MAX);
SET @u410 = 'MT1-A002-U410';
DECLARE @isomax AS VARCHAR(MAX);
SET @isomax = 'MT1-A002-U430';
DECLARE @udd AS VARCHAR(MAX);
SET @udd = 'MT1-A002-U510';
DECLARE @rps AS VARCHAR(MAX);
SET @rps = 'MT1-A003-U160';
DECLARE @utilitee AS VARCHAR(MAX);
SET @utilitee = 'MT1-A003-U120';
DECLARE @tclr AS VARCHAR(MAX);
SET @tclr = 'MT1-A003-U210';


-- -----------------------------------------------------------------------------------------

DECLARE @brut1_wa AS bigint;
SET @brut1_wa = (select id from workassignment where name = 'Brut #1, #10 et #38 - Opérateur');
DECLARE @brut38_wa AS bigint;
SET @brut38_wa = (select id from workassignment where name = 'Brut #38 - Opérateur');
DECLARE @fccu_wa AS bigint;
SET @fccu_wa = (select id from workassignment where name = 'FCCU - Opérateur');
DECLARE @aromatique_wa AS bigint;
SET @aromatique_wa = (select id from workassignment where name = 'Aromatique - Opérateur');
DECLARE @isomax_wa AS bigint;
SET @isomax_wa = (select id from workassignment where name = 'Isomax / UDD - Opérateur');
DECLARE @udd_wa AS bigint;
SET @udd_wa = (select id from workassignment where name = 'UDD - Opérateur');
DECLARE @rps_wa AS bigint;
SET @rps_wa = (select id from workassignment where name = 'RP&S - Opérateur');
DECLARE @utilitee_wa AS bigint;
SET @utilitee_wa = (select id from workassignment where name = 'Utilités - Opérateur');
DECLARE @tclr_wa AS bigint;
SET @tclr_wa = (select id from workassignment where name = 'TCLR - Opérateur');
DECLARE @operator_role_id AS bigint;
SET @operator_role_id = (select id from role where siteId = 9 and name = 'Opérateur');


exec zz_AddTestLogData 1, @u470, @aromatique_wa, 'jboucher', @DA_SHIFT_ID, '12:16:18', -1, 'C-4703-E nettoyée.', @operator_role_id;
exec zz_AddTestLogData 1, @u400, @aromatique_wa, 'jboucher', @DA_SHIFT_ID, '16:38:42', -1, 'J-4002-A les blinds installés et lavage en cours.', @operator_role_id;
exec zz_AddTestLogData 1, @u470, @aromatique_wa, 'sbergeron', @NT_SHIFT_ID, '03:39:51', -0, 'Méthanol #40 6" à 32"', @operator_role_id;
exec zz_AddTestLogData 1, @u470, @aromatique_wa, 'sbergeron', @NT_SHIFT_ID, '04:53:44', -0, 'Loader J-4702A à 100%', @operator_role_id;

exec zz_AddTestLogData 1, @brut1, @brut1_wa, 'bbelarbi', @NT_SHIFT_ID, '23:09:56', -1, 'B-101 - Fermé le brûleur 12 qui brulait mal.', @operator_role_id;
exec zz_AddTestLogData 1, @brut1, @brut1_wa, 'bbelarbi', @NT_SHIFT_ID, '04:18:28', -0, 'RP&S ont transféré le VTB vers R-1506', @operator_role_id;
exec zz_AddTestLogData 1, @brut1, @brut1_wa, 'fdion', @DA_SHIFT_ID, '12:56:16', -1, '#1 J-132A - Ré-installé la pompe. La pompe est pressurisée et chaude', @operator_role_id;
exec zz_AddTestLogData 1, @brut1, @brut1_wa, 'fdion', @DA_SHIFT_ID, '15:18:39', -1, 'J-132A - Mis en service', @operator_role_id;

exec zz_AddTestLogData 1, @brut38, @brut38_wa, 'cvazquez', @DA_SHIFT_ID, '07:26:15', -1, 'F3802 - Lavage des boues', @operator_role_id;
exec zz_AddTestLogData 1, @brut38, @brut38_wa, 'cvazquez', @DA_SHIFT_ID, '14:03:44', -1, 'Fermer le bypass sur le FC3809', @operator_role_id;
exec zz_AddTestLogData 1, @brut38, @brut38_wa, 'ydesmarais', @NT_SHIFT_ID, '02:45:35', -0, 'R-451 décantation terminée. Démarrer pompage vers R-1503.', @operator_role_id;
exec zz_AddTestLogData 1, @brut38, @brut38_wa, 'ydesmarais', @NT_SHIFT_ID, '04:15:47', -0, 'RP&S ont dirigé le VTB vers R-1506 et fermé vers R-1503', @operator_role_id;

exec zz_AddTestLogData 1, @fccu, @fccu_wa, 'mtazi', @DA_SHIFT_ID, '14:26:35', -1, 'Poly - Mis en service le C-439-C et arrêté le C-439-A comme selon les instructions', @operator_role_id;
exec zz_AddTestLogData 1, @fccu, @fccu_wa, 'mtazi', @DA_SHIFT_ID, '13:04:58', -1, 'La maintenance ont changé le Fi-4109', @operator_role_id;
exec zz_AddTestLogData 1, @fccu, @fccu_wa, 'ndesormiers', @NT_SHIFT_ID, '18:26:17', -1, 'FCCU: REMIS LE PC-2309 EN SERVICE.', @operator_role_id;
exec zz_AddTestLogData 1, @fccu, @fccu_wa, 'ndesormiers', @NT_SHIFT_ID, '18:24:32', -1, 'FCCU: COLONNES DE NIVEAU EFFECTUÉES.', @operator_role_id;

exec zz_AddTestLogData 1, @isomax, @isomax_wa, 'dboutin', @DA_SHIFT_ID, '09:55:54', -1, 'Arrêté la pompe de lube oil auxiliaire ( J-5167 ) au J-5130 et mis en mode AUTO.', @operator_role_id;
exec zz_AddTestLogData 1, @isomax, @isomax_wa, 'frichard', @DA_SHIFT_ID, '15:09:41', -1, 'Travaux en cours pour une installation de pompage du F-4405.', @operator_role_id;
exec zz_AddTestLogData 1, @isomax, @isomax_wa, 'fgosalvez', @NT_SHIFT_ID, '01:09:41', -0, '18h00 Composition H2 SRT #44 86%(h2) 5,42(co2)', @operator_role_id;
exec zz_AddTestLogData 1, @isomax, @isomax_wa, 'slepine', @NT_SHIFT_ID, '23:58:37', -1, 'Commencé à remettre du F-4405 vers le E-4401.', @operator_role_id;

exec zz_AddTestLogData 1, @rps, @rps_wa, 'cbeaudet', @DA_SHIFT_ID, '6:25:00', -1, 'switched from R813 (2-5) to R814 (34-9)', @operator_role_id;
exec zz_AddTestLogData 1, @rps, @rps_wa, 'gbruneau', @DA_SHIFT_ID, '6:25:13', -1, 'arrèter r-813 (2-5-8) au Algosea + commencer r-814 (34-9-3) au Algosea', @operator_role_id;
exec zz_AddTestLogData 1, @rps, @rps_wa, 'almorin', @NT_SHIFT_ID, '22:42:00', -1, 'Commencé le R372[35-0-2] à Shell', @operator_role_id;
exec zz_AddTestLogData 1, @rps, @rps_wa, 'jspencer', @NT_SHIFT_ID, '22:45:14', -1, 'Started pumping TK 372 to Shell', @operator_role_id;

exec zz_AddTestLogData 1, @tclr, @tclr_wa, 'tankcar', @DA_SHIFT_ID, '17:02:42', -1, 'Quart B/D; Chargé 18 HVGO, 2 Benzene, 4 Butane, 6 Diésel -40. Déchargé du Ic4. Fait le transfert d''acide au FCCU. Fait l''entretien des voies ferrées.', @operator_role_id;

exec zz_AddTestLogData 1, @udd, @udd_wa, 'dboutin', @DA_SHIFT_ID, '12:51:21', -1, 'Arrêté la pompe de lube oil auxiliaire ( J-5167 ) au J-5130 et mis en mode AUTO.', @operator_role_id;
exec zz_AddTestLogData 1, @udd, @udd_wa, 'dboutin', @DA_SHIFT_ID, '13:30:58', -1, 'AI-51508 est calibré.', @operator_role_id;
exec zz_AddTestLogData 1, @udd, @udd_wa, 'dodesrochers', @NT_SHIFT_ID, '19:56:59', -1, 'Le RP&S a été avisé que le Haze du diesel OUT est élevé, pour corrigé le problème, le F5171 a été rinçé et l''ouverture à l''égoût du G5170B, a été augmenté, cela a amélioré le vide.', @operator_role_id;
exec zz_AddTestLogData 1, @udd, @udd_wa, 'dodesrochers', @NT_SHIFT_ID, '20:44:55', -1, 'Pris un échantillon de diesel OUT pour Haze et ppmH2O ppm H2O= 50 Haze= 1', @operator_role_id;

exec zz_AddTestLogData 1, @utilitee, @utilitee_wa, 'avertefeuill', @DA_SHIFT_ID, '14:00:00', -1, 'R-572 ouvert au AD-102.', @operator_role_id;
exec zz_AddTestLogData 1, @utilitee, @utilitee_wa, 'douazzanitou', @DA_SHIFT_ID, '14:20:50', -1, 'Ligne de ballast en eau R-572 vers AD-102', @operator_role_id;
exec zz_AddTestLogData 1, @utilitee, @utilitee_wa, 'smcneil', @NT_SHIFT_ID, '21:58:25', -1, 'Parti le pompage de l''eau de R-107 vers R-310 à faible débit.', @operator_role_id;
exec zz_AddTestLogData 1, @utilitee, @utilitee_wa, 'sstpierre', @NT_SHIFT_ID, '04:41:05', -0, 'ouvert les retours d''huile vers le réservoir F-1506 pour vider la tk-110', @operator_role_id;


-- -----------------------------------------------------------------------------------------

DECLARE @lab AS VARCHAR(MAX);
SET @lab = 'MT1-A004-IFST';

DECLARE @lab_wa_general AS bigint;
SET @lab_wa_general = (select id from workassignment where name = 'Laboratoire - Général');
DECLARE @lab_wa_octane AS bigint;
SET @lab_wa_octane = (select id from workassignment where name = 'Laboratoire - Octane');
DECLARE @lab_wa_bitume AS bigint;
SET @lab_wa_bitume = (select id from workassignment where name = 'Laboratoire - Bitume');
DECLARE @lab_wa_controlprocedure AS bigint;
SET @lab_wa_controlprocedure = (select id from workassignment where name = 'Laboratoire - Contrôle/Procédé');
DECLARE @lab_wa_chromatography AS bigint;
SET @lab_wa_chromatography = (select id from workassignment where name = 'Laboratoire - Chromatographie');
DECLARE @lab_wa_analysis AS bigint;
SET @lab_wa_analysis = (select id from workassignment where name = 'Laboratoire - Analytique');


exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'slevesque', @DA_SHIFT_ID, '17:01', -1, 'Certification de la fin de semaine: ULSD specs de pt trouble -20°C: R-501 et R-813 ULSD specs de pt trouble -12°C: R-305 et R-306 FFO specs pt trouble -12°C et pt écoulement -39°C: R-302 et R-301 RBOB specs TNP: R-1502 et R-1504', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'slevesque', @DA_SHIFT_ID, '15:51', -1, 'Dimanche, R-1505 a certifié en HFO (certificat long). La feuille pour SGS est sur la table de l''échantillonnneur (analyse de jour).', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_octane, 'alesage', @DA_SHIFT_ID, '13:15', -1, 'Changement de programme, le système ROFA sur le MON ne fonctionne plus à cause du bras mobile. Des pièces seront en commande sous peu. Les tests se font en manuel sur la cuve 4. Le carburant de chauffe peut être sur les cuves 1 ou 2. Un cahier a été commencé pour inscrire les résultats de nos tests en manuel.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_octane, 'cgirard', @DA_SHIFT_ID, '15:49', -1, 'Le système ROFA sur le MON fonctionne. Portez toute même attention. Le problème se situait au niveau du bras mobile. Max Dumais.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'slevesque', @DA_SHIFT_ID, '06:22', -1, 'Étude au FCCU aujourd''hui.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_octane, 'alesage', @DA_SHIFT_ID, '16:06', -1, 'Actuellement, le système ROFA sur le MON ne fonctionne plus à cause du bras mobile. Les tests se font en manuel sur la cuve 4. Le carburant de chauffe peut être sur les cuves 1 ou 2. Un cahier a été commencé pour inscrire les résultats de nos tests en manuel. La compagnie ROFA est sur le cas pour nous aider', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'slevesque', @DA_SHIFT_ID, '18:03', -1, 'Attention aux specs de pt trouble demandées sur les diesels en vous reférant à la feuille de groupe de contrôle de la production lorsque vous faites les certificats d''analyses.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_bitume, 'slevesque', @DA_SHIFT_ID, '07:25', -1, 'Production de bitume du 15 au 19 octobre: 1) PG58-28 à R-852. Certifier en PG 58-28 et flux 2000. 2) PG64-22 à R-472 et R-471. Faire 10%. 3)PG52-34 à R-1301. Faire 10%. 4) Flux1500 à R-851. Faire 10% ', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'slevesque', @DA_SHIFT_ID, '07:16', -1, 'Samedi, il y aura de brèves interruptions des serveurs entre 9h et 13h. Les serveurs affectés seront K, R, T, U, V, W ou X.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'slevesque', @DA_SHIFT_ID, '16:50', -1, 'Contrairement a ce qui a été mentionné dans la réunion de sécurité, pour se procurer les nouveaux couvre-chaussure, il faudra déterminer les grandeurs via les démos et placer une réquisition via Charline.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_controlprocedure, 'slevesque', @DA_SHIFT_ID, '10:29', -1, 'À partir d''aujourd''hui et pour toute la période hivernale, il faut faire un point trouble et une analyse de couleur à tous les jours sur le 51 produit.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'slevesque', @DA_SHIFT_ID, '13:42', -1, 'Jeudi 13 octobre, étude au #38. Le bilan de masse de Isomax est annulé.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'cgirard', @DA_SHIFT_ID, '15:09', -1, 'Dérogation pour wagon de propane #PROX 35494.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_general, 'cgirard', @DA_SHIFT_ID, '14:30', -1, 'Production de la fin de semaine: ULSD: R-306 specs MTL. D1L/Kero 1K/Mazout #1/Petrosol: R303 et R304. FFO: R-302. HFO: R-1506. RUL: R-1504 specs TNP. SUL: R-803.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_chromatography, 'slevesque', @DA_SHIFT_ID, '16:19', -1, 'Le regen est terminé donc il n''est plus nécessaire de faire les test d''humidité au 47 gaz de recyclage.', @operator_role_id;
exec zz_AddTestLogData 1, @lab, @lab_wa_analysis, 'slevesque', @DA_SHIFT_ID, '14:40', -1, 'La procédure pour la lubricité est maintenant dans l''intranet. La formation se poursuivra dans les prochaines semaines.', @operator_role_id;



-- -----------------------------------------------------------------------------------------

DECLARE @area1 AS VARCHAR(MAX);
SET @area1 = 'MT1-A001';
DECLARE @area2 AS VARCHAR(MAX);
SET @area2 = 'MT1-A002';
DECLARE @area3 AS VARCHAR(MAX);
SET @area3 = 'MT1-A003';

DECLARE @area1_wa AS bigint;
SET @area1_wa = (select id from workassignment where lower(name) like 'Secteur 1 - Contremaître');
DECLARE @area2_wa AS bigint;
SET @area2_wa = (select id from workassignment where lower(name) like 'Secteur 2 - Contremaître');
DECLARE @area3_wa AS bigint;
SET @area3_wa = (select id from workassignment where lower(name) like 'Secteur 3 - Contremaître');

exec zz_AddTestSummaryLogData @area1, @area1_wa, 'marbeaudry', @DA_SHIFT_ID, '07:49:19', -1, 'BRUT #1/#10: Charge @ 74.4 K, #1 @ 52.4K et #10 @ 22 K    Limite de Charge: Ing.';
exec zz_AddTestSummaryLogData @area1, @area1_wa, 'marbeaudry', @DA_SHIFT_ID, '07:54:27', -1, 'POLY: Charge @ 6.2 K / 2 RX / 1200 B/J de ppmix.  RX C En Maintenance';
exec zz_AddTestSummaryLogData @area1, @area1_wa, 'ymercier', @NT_SHIFT_ID, '18:12:43', -1, 'BRUT #38 : Charge @ 69 K   Limité par capacité de refroidissement de l''excès de LVGO. Demandé d''envoyer une partie de l''excès de gazoles vers le FCCU = hausse de charge à prévoir';
exec zz_AddTestSummaryLogData @area1, @area1_wa, 'ymercier', @NT_SHIFT_ID, '18:24:28', -1, 'ALKY : Charge @ 3 K   Aucune limite = hausse de charge';

exec zz_AddTestSummaryLogData @area2, @area2_wa, 'grainville', @DA_SHIFT_ID, '15:15:09', -1, 'Isomax: Charge au minimum.  Continuons à drainer de l''eau à la E-4401. Le DPI de la tour E-4401 est maintenant à 2.2 psi';
exec zz_AddTestSummaryLogData @area2, @area2_wa, 'grainville', @DA_SHIFT_ID, '15:29:08', -1, 'UDD: Nous sommes à monter la charge. Présentement à 25kb. le #38 à fait des ajustements de spec, nous recevons moins de kero. Avons fait aligner le stove #1.';
exec zz_AddTestSummaryLogData @area2, @area2_wa, 'rmaheux', @NT_SHIFT_ID, '03:54:09', -0, 'Isomax charge au minimum. Continuons à drainer de l''eau du E-4401.Selon les échantillons les résultats du % CO2 dans le gas sont en baissant.';
exec zz_AddTestSummaryLogData @area2, @area2_wa, 'rmaheux', @NT_SHIFT_ID, '04:00:45', -0, '#46 Charge à 37.5 k.  Réservoir 1560 à 9.4 pieds.';

exec zz_AddTestSummaryLogData @area3, @area3_wa, 'mdeguire', @DA_SHIFT_ID, '16:42:35', -1, 'demain nous allons recevoir 1 vacuum avec des eaux contaminés. venant des station 1695laurier station 13106, 172 st-charles st-therese station 12342';
exec zz_AddTestSummaryLogData @area3, @area3_wa, 'gcharlebois', @NT_SHIFT_ID, '03:50:52', -0, 'Terminé le chargement du Esta Desgagné au quai 110. La J-1859 a été préparer après le bateau tel que demandé.';
exec zz_AddTestSummaryLogData @area3, @area3_wa, 'gcharlebois', @NT_SHIFT_ID, '21:43:25', -1, 'Fin du chargement de ULSD vers le Algo Sea en provenance de 814.';
exec zz_AddTestSummaryLogData @area3, @area3_wa, 'gcharlebois', @NT_SHIFT_ID, '20:53:13', -1, 'Appelé un électricien pour prendre la tour d''éclairage au #28 pour l''installer au coin de l''avenue G et la 12e rue.';


-- -----------------------------------------------------------------------------------------


DECLARE @engineer_wa AS bigint;
SET @engineer_wa = (select id from workassignment where name = 'Ingénieur');

DECLARE @day_coordinator_1_wa AS bigint;
SET @day_coordinator_1_wa = (select id from workassignment where  name = 'Secteur 1 - Coordonnateur');

DECLARE @day_coordinator_2_wa AS bigint;
SET @day_coordinator_2_wa = (select id from workassignment where  name = 'Secteur 2 - Coordonnateur');

DECLARE @day_coordinator_3_wa AS bigint;
SET @day_coordinator_3_wa = (select id from workassignment where  name = 'Secteur 3 - Coordonnateur');

DECLARE @engineer_role_id AS bigint;
SET @engineer_role_id = (select id from role where siteId = 9 and name = 'Ingénieur');

DECLARE @day_coordinator_role_id AS bigint;
SET @day_coordinator_role_id = (select id from role where siteId = 9 and name = 'Coordonnateur des Opérations');

DECLARE @supervisor_role_id AS bigint;
SET @supervisor_role_id = (select id from role where siteId = 9 and name = 'Superviseur');

DECLARE @log_text as varchar(max);

set @log_text = 'RMPCT - UDECST: Variable contrôlée FV-047' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Bonjour,' + CHAR(13) + CHAR(10) +
'La variable contrôlée de l''ouverture de la valve FV-047 a été ajoutée au contrôleur RMPCT UDECST. Cette nouvelle variable contrôlée sera utilisée afin de limiter le soutirrage de LCN. Cette information sera aussi utilisée dans une stratégie de souffre combinée à venir pour le contrôleur UDECRX.' + CHAR(13) + CHAR(10) +
'N''hésitez pas à me contacter si vous avez des questions.' + CHAR(13) + CHAR(10) +
'Merci' + CHAR(13) + CHAR(10) +
'Hugo Lefebvre' + CHAR(13) + CHAR(10) +
'(Automation, Secteur 1)'
;
exec zz_AddTestLogData 3, @brut1, @engineer_wa, 'hulefebvre', @DA_SHIFT_ID, '14:48', -1,  @log_text, @engineer_role_id;


set @log_text = 'J-701 - Rinçage de la pompe après utilisation' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'SVP, rincer la pompe J-701 avec du condensat frais vers le réservoir R-2402 après chaque utilisation pour réduire la corrosion à l''intérieur de la pompe. Effectuer un rinçage efficace, mais avec modération pour ne pas nous retrouver avec un gros volume dans R-2402. Nous allons en faire une instruction permanente au cours des prochaines semaines.'+ CHAR(13) + CHAR(10) +
'Un impulseur neuf avec un matériau plus résistant est en commande pour des travaux futurs sur la pompe.'+ CHAR(13) + CHAR(10) +
'Jonathan Leduc'
;
exec zz_AddTestLogData 3, @brut1, @day_coordinator_1_wa, 'jleduc', @DA_SHIFT_ID, '16:00', -1, @log_text, @day_coordinator_role_id;

-- **********************

set @log_text = 'Annulé - Remplacer valve sur conduite hot reflux M38H010' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Le remplacement des valves a été reporté. Aucune préparation requise. Merci!'
;
exec zz_AddTestLogData 3, @brut38, @engineer_wa, 'agagnon', @DA_SHIFT_ID, '15:55', -1,  @log_text, @engineer_role_id;


set @log_text = 'RMPCT: Variable de viscosité (E-3803)' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Bonjour,' + CHAR(13) + CHAR(10) +
'Vous trouverez ci-joint une note explicative sur la nouvelle variable de contrôle de viscosité (mode de production Flux1500), modification apportée au contrôleur RMPCT de la colonne sous-vide E-3803. Ce nouvel estimateur utilise les paramètres internes d¿opération calculés par GCC pour évaluer la viscosité du résidu.' + CHAR(13) + CHAR(10) +
'Pour plus de détails, n¿hésitez pas à me contacter.' + CHAR(13) + CHAR(10) +
'Merci à l''avance.' + CHAR(13) + CHAR(10) +
'Hugo'
;
exec zz_AddTestLogData 3, @brut38, @engineer_wa, 'hulefebvre', @DA_SHIFT_ID, '12:38', -1,  @log_text, @engineer_role_id;

-- **********************

set @log_text = 'Vapeur à l''épuiseur (FC-2310)' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'S.V.P ne pas monter la vapeur au FC-2310 à plus de 8.5 MLBH et 60 % d''ouverture sur le contrôleur. Nous avons eût 2 résultat conséqutifs de 1.0 sur le BSW du slurry et voulons en vérifier si cela pourrait en être la cause.'
;
exec zz_AddTestLogData 3, @fccu, @day_coordinator_1_wa, 'ebeaulieu', @DA_SHIFT_ID, '14:50', -1, @log_text, @day_coordinator_role_id;

set @log_text = 'Remplacement du caustique E-406' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'S.V.P., remplacer l''inventaire de caustique du E-406 selon les procédures normales d''opération.  Le % d''usure du caustique a atteint son seuil de remplacement.  ' + CHAR(13) + CHAR(10) +
'Merci beaucoup.' + CHAR(13) + CHAR(10) +
'Julien N. (8363)'
;
exec zz_AddTestLogData 3, @fccu, @engineer_wa, 'jnadeau', @DA_SHIFT_ID, '07:18', -1,  @log_text, @engineer_role_id;

-- **********************

set @log_text = 'INFO - Savon aux égouts' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Svp voir la photo en pièce jointe.' + CHAR(13) + CHAR(10) +
'Ceci est survenu dans la nuit du 19 au 20 septembre au bio-réacteur, à notre usine de traitement des eaux (secteur 3).'  + CHAR(13) + CHAR(10) +
'La photo parle d''elle-même et montre l''impact d''une petite quantité de savon drainée aux égouts...'
;
exec zz_AddTestLogData 3, @u410, @day_coordinator_2_wa, 'mleduc', @DA_SHIFT_ID, '08:38', -1,  @log_text, @day_coordinator_role_id;

set @log_text = 'HC loading au Sulfolane' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Le Hc loading a un impact sur la récupération d''aromatique au Sulfolane. Le fait d''augmenter le ratio de solvant diminue la charge en aromatique dans le solvant et augmente sa sélectivité en aromatique. Le guide d''opération stipule présentement d''opérer avec un HC loading entre 30-35%. La limite supérieure, 35 %, représente l''opération la moins coûteuse niveau énergie. '+ CHAR(13) + CHAR(10) +
'Lors d''un test récent effectué avec M. Arcuri, le HC loading a été abaissé à 26% afin de constater l''impact sur la récupération d''aromatique. La diminution du HC loading de 31 à 28 % a été la plus significative et a permis d''augmenter la récupération en BTX de 2%. La récupération supplémentaire en BTX justifie l''opération à un HC loading plus bas. '+ CHAR(13) + CHAR(10) +
'La limite inférieur d''opération du HC loading va être abaissé à 28 % pour le mois de septemere et octobre. Avant d''effectuer les modifications au guide d''opération, il serait préférable d''opérer quelques semaines avec cette nouvelle limite. Ceci nous permettra d''accumuler des données au niveau de la consommation d''énergie et d''observer si elle n''occasionne pas de problème avec le spec de non-aromatique dans le xylène. '+ CHAR(13) + CHAR(10) +
'N''hésitez pas à me contacter si vous avez des questions ou commentaires. '+ CHAR(13) + CHAR(10) +
'Merci, '+ CHAR(13) + CHAR(10) +
'Jimmy P.' 
;
exec zz_AddTestLogData 3, @u410, @engineer_wa, 'jpoulin', @DA_SHIFT_ID, '14:44', -1,  @log_text, @engineer_role_id;

-- **********************

set @log_text = 'Unité 48 (sour water) en arrêt' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'PVI, l''unité de traitement des eaux acide (sour water # 48) sera en arrêt pour 2-4 jours à compter de lundi le 19 septembre.' + CHAR(13) + CHAR(10) +
'Les eaux acide de la Raffinerie seront donc acheminées vers le R-310.' + CHAR(13) + CHAR(10) +
'Durant cette période, svp minimiser la quantité de produit acheminé vers le réseau d''eau acide.' + CHAR(13) + CHAR(10) +
'Le drainage normal (bottines, etc.) peut s''effectuer comme d''habitude.'
;
exec zz_AddTestLogData 3, @isomax, @day_coordinator_2_wa, 'mleduc', @DA_SHIFT_ID, '8:40', -1,  @log_text, @day_coordinator_role_id;

set @log_text = 'Limite L''eau de lavage à 32 gpm maximum jusqu''à mercredi' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Bonjour, le #48 seront en baisse de charge pour le nettoyage d''un de leur échangeur. Il faut limiter l''eau que nous leur envoyons de ce soir jusqu''à mercredi soir. Si on ne va pas au-delà de 32 gpm, on respecte toujours notre 5% minimum pour une charge au-delà de 20 MBPD. Merci!'
;
exec zz_AddTestLogData 3, @isomax, @engineer_wa, 'alheureux', @DA_SHIFT_ID, '09:09', -1,  @log_text, @engineer_role_id;

-- **********************

set @log_text = 'Nouvelle limite minimale de disponibilité d''H2' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Suite à une rencontre avec le fournisseur de catalyseur, la limite minimale de disponibilité d''H2 a été augmentée à 4.25.'
;
exec zz_AddTestLogData 3, @udd, @engineer_wa, 'mboissonneau', @DA_SHIFT_ID, '14:27', -1,  @log_text, @engineer_role_id;


-- **********************

set @log_text = 'Plan d''urgence pour deversement marin au quai' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Nouveau dans Intranet Plan d''urgence -Quai'+ CHAR(13) + CHAR(10) +
'Plan de mesure d''urgence déversement marin'+ CHAR(13) + CHAR(10) +
'Merci'+ CHAR(13) + CHAR(10) +
'Robert'
;
exec zz_AddTestLogData 3, @rps, @day_coordinator_3_wa, 'rasselin', @DA_SHIFT_ID, '16:15', -1, @log_text, @day_coordinator_role_id;

set @log_text = 'Retour de Benoit Labelle sur son équipe.' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Bonjour, Prenez note que Benoit Labelle retournera sur l''équipe "C" le 16 septembre. Il travaillera le 14 septembre de nuit sur l''équipe "D", sera en congé le 15 septembre et travaillera le 16 sur l''équipe "C".'
;
exec zz_AddTestLogData 3, @rps, @area3_wa, 'gcharlebois', @DA_SHIFT_ID, '14:46', -1,  @log_text, @supervisor_role_id;

-- **********************

set @log_text = 'Vérification des niveaux' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Cette fin de semaine faire la vérification des niveaux et me remettre la feuiille pour archiver'
;
exec zz_AddTestLogData 3, @utilitee, @day_coordinator_3_wa, 'rnardozza', @DA_SHIFT_ID, '16:20', -1,  @log_text, @day_coordinator_role_id;

set @log_text = 'Formation sur les joints mécanique' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
'Messieurs,'+ CHAR(13) + CHAR(10) +
'Le quart "C" devra se présenter 1 heure avant son quart de travail jeudi le 22 septembre pour une formation obligatoire sur les joints mécanique à la salle Alberta de l''ingénierie, vous serai avec vos confrères du RP&S. La formation débute à 16H30 et se termine vers 17H30. Lorsque les autres dates de formation seront confirmé nous vous les communiquerons.'
;
exec zz_AddTestLogData 3, @utilitee, @area3_wa, 'ypimpare', @DA_SHIFT_ID, '15:50', -1,  @log_text, @supervisor_role_id;


go

-- -----------------------------------------------------------------------------------------

CREATE Procedure [dbo].zz_AddTestActionItemData
	(
		@FLOC AS VARCHAR(MAX),
		@USER_NAME AS varchar(max),
		@NAME AS VARCHAR(MAX),
		@DESCRIPTION AS VARCHAR(MAX)
	)

AS

DECLARE @USER_ID AS BIGINT;
SET @USER_ID = (select Id from [User] where username = @USER_NAME);

insert Schedule ( LastModifiedDateTime,LastInvokedDateTime,ScheduleTypeId,StartDateTime,EndDateTime,FromTime,ToTime,DailyFrequency,WeeklyFrequency,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,DayOfMonth,WeekOfMonth,DayOfWeek,January,February,March,April,May,June,July,August,September,October,November,December,Deleted,SiteId )  
select getdate(),null,3,convert(datetime, convert(varchar, getdate(), 110), 110)+1,convert(datetime, convert(varchar, getdate(), 110), 110)+5,'1900-01-01 07:00','1900-01-01 16:00',1,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,0,9
insert ActionItemDefinition ( Name,BusinessCategoryId,ActionItemDefinitionStatusId,ScheduleId,RequiresApproval,Active,ResponseRequired,Description,SourceId,SapOperationId,LastModifiedUserId,LastModifiedDateTime,CreatedByUserId,CreatedDateTime,Deleted,OperationalModeId,PriorityId,WorkAssignmentId,CreateAnActionItemForEachFunctionalLocation )  
select @NAME,b.Id,1,IDENT_CURRENT('Schedule'),0,1,0,@DESCRIPTION,0,null,@USER_ID,getdate(),@USER_ID,getdate(),0,0,1,null,1 from BusinessCategory b where b.name = 'Équipement'
insert ActionItemDefinitionFunctionalLocation ( ActionItemDefinitionId,FunctionalLocationId )  
select IDENT_CURRENT('ActionItemDefinition'), f.id from functionallocation f  where f.siteid = 9 and f.fullhierarchy = @FLOC

insert ActionItem ( ResponseRequired,ActionItemStatusId,BusinessCategoryId,Description,StartDateTime,EndDateTime,ShiftAdjustedEndDateTime,SourceId,LastModifiedUserId,LastModifiedDateTime,createdByScheduleTypeId,Deleted,Name,PreviousActionItemStatusId,StatusModifiedUserId,StatusModifiedDateTime,CreatedByActionItemDefinitionId,PriorityId,WorkAssignmentId )  
select 0,1,b.Id,@DESCRIPTION,convert(datetime, convert(varchar, getdate(), 110) + ' 07:00', 110), convert(datetime, convert(varchar, getdate(), 110) + ' 16:00', 110), convert(datetime, convert(varchar, getdate(), 110) + ' 18:00', 110),0,@USER_ID,getdate(),3,0,@NAME,0,-1,getdate(),IDENT_CURRENT('ActionItemDefinition'),1,null from BusinessCategory b where b.name = 'Équipement'
insert ActionItemFunctionalLocation ( ActionItemId,FunctionalLocationId )  
select IDENT_CURRENT('ActionItem'), f.id from functionallocation f  where f.siteid = 9 and f.fullhierarchy = @FLOC

GO

DECLARE @brut1 AS VARCHAR(MAX);
SET @brut1 = 'MT1-A001-U010';
DECLARE @brut38 AS VARCHAR(MAX);
SET @brut38 = 'MT1-A001-U380';
DECLARE @fccu AS VARCHAR(MAX);
SET @fccu = 'MT1-A001-U020';
DECLARE @u400 AS VARCHAR(MAX);
SET @u400 = 'MT1-A002-U400';
DECLARE @isomax AS VARCHAR(MAX);
SET @isomax = 'MT1-A002-U430';
DECLARE @udd AS VARCHAR(MAX);
SET @udd = 'MT1-A002-U510';
DECLARE @rps AS VARCHAR(MAX);
SET @rps = 'MT1-A003-U160';
DECLARE @utilitee AS VARCHAR(MAX);
SET @utilitee = 'MT1-A003-U120';
DECLARE @tclr AS VARCHAR(MAX);
SET @tclr = 'MT1-A003-U210';


exec zz_AddTestActionItemData @u400, 'ehuppee', 'J-4022', 'Demain les tuyauteurs viendront vérifier le check valve de la pompe J-4022. Il faut donc préparer la pompe pour se travail qui se fera au masque racal. Si les valves sont étanches un rinçage à l''eau serait utile. À vous d''évaluer.';
exec zz_AddTestActionItemData @brut1, 'jleduc', 'SOV au fond de E-103', 'SVP, préparer la conduite de fond de E-103 pour permettre l''installation de la SOV jeudi matin. Utiliser la dérivation et bloquer la section où la SOV sera installée. À faire en prévision d''être drainé avec un camion sous vide jeudi matin (doit ne pas être trop chaud et ne pas figer). Suivre Énergie Zéro.  Merci, Jonathan';
exec zz_AddTestActionItemData @brut38, 'jleduc', 'G/G F-3902', 'SVP, purger à la vapeur le GG du F-3902 lundi soir puisqu''il sera amené à l''atelier mardi. Merci, Jonathan Leduc';
exec zz_AddTestActionItemData @fccu, 'ebeaulieu', 'F-294B (coke catcher)', 'S.V.P Préparer le F-294 B pour la maintenance pour vendredi matin selon Energie zéro. La fiche énergie zéro pour cet équipement est disponible dans l''Intranet. Il se peut que ce soit difficile de confirmer qu''il est bien dépressurisé. Si tel est le cas, cadenasser les valves quand même et demain on prendra les précautions nécessaire pour effectuer les travaux. Merci!'
exec zz_AddTestActionItemData @isomax, 'ydumais', 'J-4309', 'SVP ouvrir les valves pour réchauffer la pompe J-4309 pour lundi matin. La pompe sera branché lundi et enligner Merci';
exec zz_AddTestActionItemData @rps, 'plavigne', 'Purge du cocon # 3', 'Purger l''O2 du cocon # 3 ce week-end (10-11 déc). Ne pas le mettre en service. Lundi le 12 décembre l''isolation les traceurs sur les legs du gage seront installés.';
exec zz_AddTestActionItemData @rps, 'plavigne', 'Mise hors service du L-2003-A', 'Mettre hors service le coalesceur L-2003-A dans la nuit Mardi à Mercredi.(22 au 23 novembre). Les filtres seront changés Mercredi matin 23 novembre 2011. Initialiser la procédure et me la remettre une fois les travaux complétés';
exec zz_AddTestActionItemData @utilitee, 'rnardozza', 'Forebay', 'Cette nuit by passé la forebay en prévision de son nettoyage demain. Utilisé les procédures existantes, y apporter vos commentaires et me les remettre s.v.p.';
exec zz_AddTestActionItemData @udd, 'ydumais', 'Changer G-5171-A', 'Dimanche soir,transférer le G-5171-A vers le B et préparer le A pour un changement de cartouches lundi matin. Nous suivons les pré-filtres au mois et le A est dû pour le changement';
go


-- -----------------------------------------------------------------------------------------

DROP  Procedure  [dbo].zz_AddTestLogData;
DROP  Procedure  [dbo].zz_AddTestSummaryLogData;
DROP  Procedure  [dbo].zz_AddTestActionItemData;
Go