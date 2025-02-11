
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateWorkPermitMudsDetailsBasedOnPermitAttributeAssociation')
	BEGIN
		DROP Procedure [dbo].UpdateWorkPermitMudsDetailsBasedOnPermitAttributeAssociation
	END
GO


CREATE Procedure [dbo].[UpdateWorkPermitMudsDetailsBasedOnPermitAttributeAssociation]    
 (    
 @WorkPermitMudsId bigint,    
 @PermitAttributeId bigint,   
 @Name varchar(100)  ,  
 @WorkPermitTypeId bigint  
 )    
AS    
  
  
-- WorkPermitMudsElevatedHot  - Permis Chaud à risqué élevé -   Id = 1  
-- WorkPermitMudsModerdateHot - Permis Chaud risqué modéré  -   Id = 2  
  
-- If Id = 1 then Unchecked Travaux a chaud a risque eleve  
-- If Id = 2 then Unchecked Travaux à chaud à risque modéré from Form  
  
-- For Id =1 - Elev - Soudage, Traitement, Cuissons, Perçage, Chaufferette, Nettoyage, TravauxDansZone  
-- For Id = 2 - Mod- UtilisationMoteur,NettoyageAu,UtilisationElectronics,Radiographie,UtilisationOutlis, UtilisationEquipments,Demolition  


If(@Name = 'Amiante')    
Begin
Update WorkPermitMuds Set TemplateId = (Select Id from WorkPermitMudsTemplate Where TemplateNumber = 25 And Deleted = 0)
Where  Id = @WorkPermitMudsId  

Update WorkPermitMudsDetails 
Set 
Amiante = 1, [Procedure] = 1, ProcedureValue = 'Selon procédures du SS-PTS07',   MasqueACartouches = 1, MasqueACartouchesValue = 'Masque à cartouches P-100',
Gants = 1, GantsValue = 'caoutchouc enrubané', HabitProtecteur = 1,HabitProtecteurValue = 'couvre-tout jetable enrubanné', 
PerimetreSecurite =1 ,  PerimetreSecuriteValue = 'Amiante', AutresE = 1, AutresEValue='Sac à rebuts d amiante'
Where  Id = @WorkPermitMudsId 
  
End


If(@Name = 'Silice')    
Begin
Update WorkPermitMuds Set TemplateId = (Select Id from WorkPermitMudsTemplate Where TemplateNumber = 11 And Deleted = 0)
Where  Id = @WorkPermitMudsId  

Update WorkPermitMudsDetails 
Set 
Silice = 1, MasqueACartouches = 1, MasqueACartouchesValue = 'Masque à cartouche P-100', HabitProtecteur = 1,HabitProtecteurValue = 'couvre-tout jetable', 
PerimetreSecurite =1 ,  PerimetreSecuriteValue = 'rouge', AutresE = 1, AutresEValue='Boyau à eau'
Where  Id = @WorkPermitMudsId 
  
End


If(@Name = 'Chariot élévateur')    
Begin


Update WorkPermitMudsDetails 
Set 
Appareil = 1,  AppareilValue ='Chariot élévateur', Signaleur = 1
Where  Id = @WorkPermitMudsId 
  
End


If(@Name = 'Analyse critique de la tâche (ACT)')    
Begin
Update WorkPermitMudsDetails Set AnalyseCritiqueDeLaTache = 1
Where  Id = @WorkPermitMudsId    
End

If(@Name = 'Procédure')    
Begin
Update WorkPermitMudsDetails Set [Procedure] = 1
Where  Id = @WorkPermitMudsId    
End
  
If(@Name = 'Cadenassage multiple')  
Begin   
Update WorkPermitMudsDetails Set InterrupteursEtVannesCadenasses = 1 Where Id = @WorkPermitMudsId  
End  
  
--If(@Name = 'Cadenassage simple')  
--Begin   
--Update WorkPermitMudsDetails Set 1 = 1 Where Id = @WorkPermitMudsId  
--End  
  
If(@Name = 'Espace clos')  
Begin   
Update WorkPermitMudsDetails Set RemplirLeFormulaireDeCondition = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Échafaud')  
Begin   
Update WorkPermitMudsDetails Set TravailEnHauteur6EtPlus = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set EchafaudageApprouve = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Échelle sécurisée/Escabeau')  
Begin   
Update WorkPermitMudsDetails Set EchelleSecurisee = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Harnais 2 liens de retenue')  
Begin   
Update WorkPermitMudsDetails Set TravailEnHauteur6EtPlus = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Harnais2LiensDeRetenue = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Nacelle')  
Begin   
Update WorkPermitMudsDetails Set TravailEnHauteur6EtPlus = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Harnais2LiensDeRetenue = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Radio = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Signaleur = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set PerimetreSecurite = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Appareil = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set AlarmeDCS = 1 Where Id = @WorkPermitMudsId 
  
Update WorkPermitMudsDetails Set AppareilValue = N'Nacelle' Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Excavation')  
Begin   
Update WorkPermitMudsDetails Set BarricadeRigide = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Levage - Grue')  
Begin   
Update WorkPermitMudsDetails Set UtilisationMoteur = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 2  
--Update WorkPermitMudsDetails Set AlarmeDCS = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set ApprobationPourEquipDeLevage = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set PerimetreSecurite = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Radio = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Appareil = 1 Where Id = @WorkPermitMudsId  
  
Update WorkPermitMudsDetails Set AppareilValue = N'Grue' Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Unité SBS')  
Begin   
Update WorkPermitMudsDetails Set LunettesMonocoques = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set SBS = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Travaux électrique')  
Begin   
Update WorkPermitMudsDetails Set ElectriciteVolt = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Electrisation = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Utilisation d’un moteur à combustion interne (véhicules ou outil)')  
Begin   
Update WorkPermitMudsDetails Set UtilisationMoteur = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 2  
Update WorkPermitMudsDetails Set DetectionDesGazs = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Appareil = 1 Where Id = @WorkPermitMudsId  
End  
  
  
If(@Name = 'Nettoyage au jet de sable mouillé ou au jet d’eau')  
Begin   
Update WorkPermitMudsDetails Set NettoyageAU = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 2  
End  
  
If(@Name = 'Utilisation d’outils électriques non intrinsèque (batteries/électrique)')  
Begin   
Update WorkPermitMudsDetails Set UtilisationElectronics = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 2  
Update WorkPermitMudsDetails Set DetectionDesGazs = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set OutillageElectrique = 1 Where Id = @WorkPermitMudsId  
  
Update WorkPermitMudsDetails Set OutilDeLaiton = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Radiographie')  
Begin   
Update WorkPermitMudsDetails Set Radiographie = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 2  
Update WorkPermitMudsDetails Set DetectionDesGazs = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Radiations = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set PerimetreSecurite = 1 Where Id = @WorkPermitMudsId  
  
Update WorkPermitMudsDetails Set PerimetreSecuriteValue = N'Radiographie' Where Id = @WorkPermitMudsId  
  
End  
  
If(@Name = 'Utilisation d’outils pneumatiques')  
Begin   
Update WorkPermitMudsDetails Set UtilisationOutlis = 1 where Id = @WorkPermitMudsId And @WorkPermitTypeId = 2  
Update WorkPermitMudsDetails Set DetectionDesGazs = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Utilisation d’un équipement avec moteur électrique non intrinsèque')  
Begin   
Update WorkPermitMudsDetails Set UtilisationEquipments = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 2  
Update WorkPermitMudsDetails Set DetectionDesGazs = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Soudage & coupage')  
Begin   
Update WorkPermitMudsDetails Set Soudage = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 1  
Update WorkPermitMudsDetails Set IncendieExplosion = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Meulage')  
Begin   
Update WorkPermitMudsDetails Set LunettesMonocoques = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set Visiere = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set ProtectionAuditive = 1 Where Id = @WorkPermitMudsId  
Update WorkPermitMudsDetails Set IncendieExplosion = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Traitement thermique')  
Begin   
Update WorkPermitMudsDetails Set Traitement = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 1  
Update WorkPermitMudsDetails Set IncendieExplosion = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Cuissons de réfractaires')  
Begin   
Update WorkPermitMudsDetails Set Cuissons = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 1  
Update WorkPermitMudsDetails Set IncendieExplosion = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Perçage ou piquage à vif')  
Begin   
Update WorkPermitMudsDetails Set Percage = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 1  
End  
  
If(@Name = 'Chaufferette avec une flamme nue')  
Begin   
Update WorkPermitMudsDetails Set Chaufferette = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 1  
Update WorkPermitMudsDetails Set IncendieExplosion = 1 Where Id = @WorkPermitMudsId  
End  
  
If(@Name = 'Nettoyage au jet de sable conventionnel')  
Begin   
Update WorkPermitMudsDetails Set Nettoyage = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 1  
End  
  
If(@Name = 'Travaux dans la zone permissive')  
Begin   
Update WorkPermitMudsDetails Set TravauxDansZone = 1 Where Id = @WorkPermitMudsId And @WorkPermitTypeId = 1  
End  
  
If(@Name = 'Cadenassage simple')  
Begin   
Update WorkPermitMudsDetails Set VerrouillagesParTravailleurs = 1 Where Id = @WorkPermitMudsId   
End  
  
  
GRANT EXEC ON UpdateWorkPermitMudsDetailsBasedOnPermitAttributeAssociation TO PUBLIC  
GO
