insert into site
values (8, 'Edmonton', 'Mountain Standard Time', 'Edmonton');

go

SET IDENTITY_INSERT Plant ON;

insert into plant
(Id,Name,SiteId)
values (702, 'Edmonton', 8);

SET IDENTITY_INSERT Plant OFF;

go

INSERT INTO [SiteConfiguration]
           ([SiteId]
           ,[DaysToDisplayActionItems],[DaysToDisplayShiftLogs],[DaysToDisplayShiftHandovers],[DaysToDisplayDeviationAlerts],[DaysToDisplayWorkPermits],[DaysToDisplayLabAlerts]
           ,[DaysBeforeArchivingClosedWorkPermits],[DaysBeforeDeletingPendingWorkPermits],[DaysBeforeClosingIssuedWorkPermits]
           ,[WorkPermitNotApplicableAutoSelected],[WorkPermitOptionAutoSelected]
           ,[AutoApproveWorkOrderActionItemDefinition],[AutoApproveSAPAMActionItemDefinition],[AutoApproveSAPMCActionItemDefinition]
           ,[DaysToEditDeviationAlerts]
           ,[CreateOperatingEngineerLogs],[OperatingEngineerLogDisplayName]
           ,[DorCutoffTime],[SummaryLogFunctionalLocationDisplayLevel],[AllowStandardLogAtSecondLevelFunctionalLocation]
           ,[CrossShiftDisplayName],[IncludeWorkAssignmentInPriortyScreenQuery]
           )
     VALUES(
           8
           ,7,14,7,30,15,30
           ,7,7,1
           ,1,1
           ,1,1,1
           ,7
           ,1,'Chief Engineer Log'
           ,'1753-01-01 10:00:00.000',1,1
           ,'Work Assignment Logs',1);

go

insert into shift (SapShiftId, Name, StartTime, EndTime, CreatedDateTime, SiteId)
values (0, 'D', '2011-01-01 08:00', '2011-01-01 20:00', getdate(), 8);

insert into shift (SapShiftId, Name, StartTime, EndTime, CreatedDateTime, SiteId)
values (0, 'N', '2011-01-01 20:00', '2011-01-02 08:00', getdate(), 8);

go

insert into ActionItemDefinitionAutoReApprovalConfiguration
values (8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

go

insert into TargetDefinitionAutoReApprovalConfiguration
values (8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

go



GO
