
IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Numerodequipement'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Numerodequipement Varchar(250)
end

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Compagnie'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Compagnie varchar(250)
end

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Depressurise'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Depressurise bit NOT NULL  DEFAULT (0)

END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Vidange'
)
begin

ALTER TABLE dbo.WorkPermitMontrealDetails Add Vidange bit NOT NULL  DEFAULT (0)

END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Ventile'
)
begin

ALTER TABLE dbo.WorkPermitMontrealDetails Add Ventile bit NOT NULL  DEFAULT (0)


END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'traceursHorsService'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add traceursHorsService bit NOT NULL  DEFAULT (0)

END 

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'CadenassageRequisSimple'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add CadenassageRequisSimple bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'CadenassageRequisBoite'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add CadenassageRequisBoite bit NOT NULL  DEFAULT (0)
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'CadenassageRequisBoiteValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add CadenassageRequisBoiteValue Varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'CadenassageRequisDisjoncteur'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add CadenassageRequisDisjoncteur bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'CadenassageRequisMaitrecadenasseur'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add CadenassageRequisMaitrecadenasseur bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'ObtureEtOuDebranche'
)
begin

ALTER TABLE dbo.WorkPermitMontrealDetails Add ObtureEtOuDebranche bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'TravauxEnESPACECLOS'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add TravauxEnESPACECLOS bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'TravauxEnESPACECLOSValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add TravauxEnESPACECLOSValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Signature'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Signature bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'ROSE'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add ROSE bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'PTS'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add PTS bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'PTSValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add PTSValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'ExcavationFormulaire'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add ExcavationFormulaire bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'ExcavationFormulaireValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add ExcavationFormulaireValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'ActOuDerogationapplicable'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add ActOuDerogationapplicable bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'OutilsElectriques'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add OutilsElectriques bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'OutilsCausantDesEtincellesNues'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add OutilsCausantDesEtincellesNues bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'OutilsCausantUneFlammeNue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add OutilsCausantUneFlammeNue bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Gants'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Gants bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'GantsValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add GantsValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Botte'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Botte bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'BotteValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add BotteValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'ContenirLesEtincelles'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add ContenirLesEtincelles bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Perimetre'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Perimetre bit NOT NULL  DEFAULT (0)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealDetails]') 
         AND name = 'Perimetrevalue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealDetails Add Perimetrevalue varchar(100)

END


GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Numerodequipement'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Numerodequipement Varchar(250)
end

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Compagnie'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Compagnie varchar(250)
end




IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Depressurise'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Depressurise bit

END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Vidange'
)
begin

ALTER TABLE dbo.WorkPermitMontrealHistory Add Vidange bit

END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Ventile'
)
begin

ALTER TABLE dbo.WorkPermitMontrealHistory Add Ventile bit


END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'traceursHorsService'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add traceursHorsService bit

END 

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'CadenassageRequisSimple'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add CadenassageRequisSimple bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'CadenassageRequisBoite'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add CadenassageRequisBoite bit
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'CadenassageRequisBoiteValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add CadenassageRequisBoiteValue Varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'CadenassageRequisDisjoncteur'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add CadenassageRequisDisjoncteur bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'CadenassageRequisMaitrecadenasseur'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add CadenassageRequisMaitrecadenasseur bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'ObtureEtOuDebranche'
)
begin

ALTER TABLE dbo.WorkPermitMontrealHistory Add ObtureEtOuDebranche bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'TravauxEnESPACECLOS'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add TravauxEnESPACECLOS bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'TravauxEnESPACECLOSValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add TravauxEnESPACECLOSValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Signature'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Signature bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'ROSE'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add ROSE bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'PTS'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add PTS bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'PTSValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add PTSValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'ExcavationFormulaire'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add ExcavationFormulaire bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'ExcavationFormulaireValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add ExcavationFormulaireValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'ActOuDerogationapplicable'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add ActOuDerogationapplicable bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'OutilsElectriques'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add OutilsElectriques bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'OutilsCausantDesEtincellesNues'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add OutilsCausantDesEtincellesNues bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'OutilsCausantUneFlammeNue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add OutilsCausantUneFlammeNue bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Gants'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Gants bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'GantsValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add GantsValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Botte'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Botte bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'BotteValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add BotteValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'ContenirLesEtincelles'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add ContenirLesEtincelles bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Perimetre'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Perimetre bit

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealHistory]') 
         AND name = 'Perimetrevalue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealHistory Add Perimetrevalue varchar(100)

END


GO



IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Depressurise'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add Depressurise tinyint

END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Vidange'
)
begin

ALTER TABLE dbo.WorkPermitMontrealTemplate Add Vidange tinyint

END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Ventile'
)
begin

ALTER TABLE dbo.WorkPermitMontrealTemplate Add Ventile tinyint


END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'traceursHorsService'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add traceursHorsService tinyint

END 

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'CadenassageRequisSimple'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add CadenassageRequisSimple tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'CadenassageRequisBoite'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add CadenassageRequisBoite tinyint
END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'CadenassageRequisBoiteValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add CadenassageRequisBoiteValue Varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'CadenassageRequisDisjoncteur'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add CadenassageRequisDisjoncteur tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'CadenassageRequisMaitrecadenasseur'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add CadenassageRequisMaitrecadenasseur tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'ObtureEtOuDebranche'
)
begin

ALTER TABLE dbo.WorkPermitMontrealTemplate Add ObtureEtOuDebranche tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'TravauxEnESPACECLOS'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add TravauxEnESPACECLOS tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'TravauxEnESPACECLOSValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add TravauxEnESPACECLOSValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Signature'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add Signature tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'ROSE'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add ROSE tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'PTS'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add PTS tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'PTSValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add PTSValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'ExcavationFormulaire'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add ExcavationFormulaire tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'ExcavationFormulaireValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add ExcavationFormulaireValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'ActOuDerogationapplicable'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add ActOuDerogationapplicable tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'OutilsElectriques'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add OutilsElectriques tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'OutilsCausantDesEtincellesNues'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add OutilsCausantDesEtincellesNues tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'OutilsCausantUneFlammeNue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add OutilsCausantUneFlammeNue tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Gants'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add Gants tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'GantsValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add GantsValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Botte'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add Botte tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'BotteValue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add BotteValue varchar(100)

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'ContenirLesEtincelles'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add ContenirLesEtincelles tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Perimetre'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add Perimetre tinyint

END


IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[WorkPermitMontrealTemplate]') 
         AND name = 'Perimetrevalue'
)
begin
ALTER TABLE dbo.WorkPermitMontrealTemplate Add Perimetrevalue varchar(100)

END


GO

