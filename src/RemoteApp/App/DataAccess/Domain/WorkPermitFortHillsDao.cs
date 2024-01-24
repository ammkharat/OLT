using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitFortHillsDao : AbstractManagedDao, IWorkPermitFortHillsDao
    {
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IUserDao userDao;
        private readonly IWorkPermitFortHillsGroupDao groupDao;
        //private readonly IFormGN59Dao formGN59Dao;
        //private readonly IFormGN7Dao formGN7Dao;
        //private readonly IFormGN24Dao formGN24Dao;
        //private readonly IFormGN6Dao formGN6Dao;
        //private readonly IFormGN75ADao formGN75ADao;
        //private readonly IFormGN1Dao formGN1Dao;
        private readonly IDocumentLinkDao documentLinkDao;
       // private readonly IAreaLabelDao areaLabelDao;

        private const string QueryByIdStoredProcedure = "QueryWorkPermitFortHillsById";
        private const string QueryWorkPermitFortHillsLatestExpirationDateByPermitRequestIdStoredProcedure = "QueryWorkPermitFortHillsLatestExpirationDateByPermitRequestId";
        private const string InsertStoredProcedure = "InsertWorkPermitFortHills";
        private const string UpdateStoredProcedure = "UpdateWorkPermitFortHills";
        private const string RemoveStoredProcedure = "RemoveWorkPermitFortHills";
        private const string QueryDoesPermitRequestFortHillsAssociationExist = "QueryDoesPermitRequestFortHillsAssociationExist";
        

        public WorkPermitFortHillsDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitFortHillsGroupDao>();
            //formGN59Dao = DaoRegistry.GetDao<IFormGN59Dao>();
            //formGN7Dao = DaoRegistry.GetDao<IFormGN7Dao>();
            //formGN24Dao = DaoRegistry.GetDao<IFormGN24Dao>();
            //formGN6Dao = DaoRegistry.GetDao<IFormGN6Dao>();
            //formGN75ADao = DaoRegistry.GetDao<IFormGN75ADao>();
            //formGN1Dao = DaoRegistry.GetDao<IFormGN1Dao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
           // areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        public WorkPermitFortHills QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<WorkPermitFortHills>(id, PopulateInstance, QueryByIdStoredProcedure);
        }

        public DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@PermitRequestId", permitRequestId);
            DateTime? latestExpiryDateTime = command.QueryForSingleResult<DateTime?>(PopulateLatestExpiryDateTime, QueryWorkPermitFortHillsLatestExpirationDateByPermitRequestIdStoredProcedure);
            return latestExpiryDateTime;
        }

        private DateTime? PopulateLatestExpiryDateTime(SqlDataReader reader)
        {
            return reader.Get<DateTime?>("LatestExpiryDateTime");
        }

        public WorkPermitFortHills Insert(WorkPermitFortHills workPermit, long? permitRequestId)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            SqlParameter permitNumberParameter = command.AddOutputParameter("@PermitNumber", SqlDbType.BigInt);

            if (permitRequestId.HasValue)
            {
                command.AddParameter("@PermitRequestId", permitRequestId);
            }

            command.Insert(workPermit, AddInsertParameters, InsertStoredProcedure);
            workPermit.Id = (long)idParameter.Value;

            SetPermitNumber(workPermit, permitNumberParameter);
         //   MaybeSetZeroEnergyFormNumber(workPermit);
            InsertNewDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return workPermit;
        }

        public void Update(WorkPermitFortHills workPermit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermit.Id);
            SqlParameter permitNumberParameter = command.AddOutputParameter("@PermitNumber", SqlDbType.BigInt);

            command.Update(workPermit, AddUpdateParameters, UpdateStoredProcedure);
            SetPermitNumber(workPermit, permitNumberParameter);
            //MaybeSetZeroEnergyFormNumber(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(workPermit);
            InsertNewDocumentLinks(workPermit);
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
       
        }

        public void Remove(WorkPermitFortHills workPermit)
        {
            ManagedCommand.Remove(workPermit, RemoveStoredProcedure);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByWorkPermitEdmontonId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedWorkPermitEdmonton);
        }

        private void AddUpdateParameters(WorkPermitFortHills workPermit, SqlCommand command)
        {
            command.AddParameter("ShouldCreatePermitNumber", workPermit.WorkPermitStatus.Id != PermitRequestBasedWorkPermitStatus.Requested.Id && workPermit.PermitNumber == null);

            if (workPermit.IssuedByUser != null)
            {
                command.AddParameter("IssuedByUserId", workPermit.IssuedByUser.IdValue);
            }
            //amit  28/05/2019 put function to add more params 
            AddInsertOrUpdateParameters(workPermit, command);
        }

        
        private void AddInsertParameters(WorkPermitFortHills workPermit, SqlCommand command)
        {            
            command.AddParameter("ShouldCreatePermitNumber", workPermit.WorkPermitStatus.Id != PermitRequestBasedWorkPermitStatus.Requested.Id);
            command.AddParameter("DataSourceId", workPermit.DataSource.IdValue);
            
            command.AddParameter("CreatedDateTime", workPermit.CreatedDateTime);
            command.AddParameter("CreatedByUserId", workPermit.CreatedBy.IdValue);

            command.AddParameter("ClonedFormDetailFortHills", workPermit.ClonedFormDetailFortHills); // Added by Vibhor : DMND0011077 - Work Permit Clone History

            if (workPermit.PermitRequestCreatedByUser != null)
            {
                command.AddParameter("PermitRequestCreatedByUserId", workPermit.PermitRequestCreatedByUser.IdValue);
            }

            AddInsertOrUpdateParameters(workPermit, command);
        }

        private void AddInsertOrUpdateParameters(WorkPermitFortHills workPermit, SqlCommand command)
        {            
            command.AddParameter("WorkPermitStatusId", workPermit.WorkPermitStatus.IdValue);
            command.AddParameter("Company", workPermit.Company);
            command.AddParameter("Occupation", workPermit.Occupation);
            command.AddParameter("NumberOfWorkers", workPermit.NumberOfWorkers);    
            command.AddParameter("WorkPermitTypeId", workPermit.WorkPermitType.IdValue);
           // command.AddParameter("DurationPermit", workPermit.DurationPermit);
            command.AddParameter("FunctionalLocationId", workPermit.FunctionalLocation.IdValue);
            command.AddParameter("Location", workPermit.Location);
            command.AddParameter("RequestedStartDateTime", workPermit.RequestedStartDateTime);
            command.AddParameter("IssuedDateTime", workPermit.IssuedDateTime);
            command.AddParameter("ExpiredDateTime", workPermit.ExpiredDateTime);
            command.AddParameter("WorkOrderNumber", workPermit.WorkOrderNumber);
            command.AddParameter("OperationNumber", workPermit.OperationNumber);
            command.AddParameter("SubOperationNumber", workPermit.SubOperationNumber);
            command.AddParameter("TaskDescription", workPermit.TaskDescription);

            command.AddParameter("PartDWorkSectionNotApplicable", workPermit.PartDWorkSectionNotApplicableToJob);
            command.AddParameter("HazardsAndOrRequirements", workPermit.HazardsAndOrRequirements);
            command.AddParameter("LastModifiedByUserId", workPermit.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", workPermit.LastModifiedDateTime);
            command.AddParameter("IssuedToSuncor", workPermit.IssuedToSuncor);
            command.AddParameter("IssuedToCompany", workPermit.IssuedToCompany);
            command.AddParameter("GroupId", workPermit.Group == null ? null : workPermit.Group.Id);
          // command.AddParameter("IssuedByUserId", workPermit.IssuedByUser.IdValue);
            command.AddParameter("PriorityId", workPermit.Prioritydata.IdValue);
            command.AddParameter("EquipmentNo", workPermit.EquipmentNo.IsNullOrEmptyOrWhitespace() ? null : workPermit.EquipmentNo);
            command.AddParameter("Craft", workPermit.Craft);
            command.AddParameter("CrewSize", workPermit.CrewSize);
            command.AddParameter("JobCoordinator", workPermit.JobCoordinator);
            command.AddParameter("CoOrdContactNumber", workPermit.CoOrdContactNumber);
            command.AddParameter("EmergencyAssemblyArea", workPermit.EmergencyAssemblyArea);
            command.AddParameter("EmergencyMeetingPoint", workPermit.EmergencyMeetingPoint);
            command.AddParameter("EmergencyContactNumber", workPermit.EmergencyContactNo);
            command.AddParameter("Locknumber", workPermit.LockBoxNumber);
            command.AddParameter("IsolationNumber", workPermit.IsolationNo);
            command.AddParameter("LockBoxnumberChecked", workPermit.LockBoxnumberChecked);

            
            command.AddParameter("RevalidationDateTime", workPermit.RevalidationDateTime);
            command.AddParameter("ExtensionDateTime", workPermit.ExtensionDateTime);
            if (workPermit.ExtensionDateTime != null)
            {
                command.AddParameter("ExtensionReasonPartJ", workPermit.ExtensionReasonPartJ);
                command.AddParameter("ExtendedByUser", workPermit.ExtendedByUser.IdValue);
            }

            command.AddParameter("PartCWorkSectionNotApplicable", workPermit.PartCWorkSectionNotApplicableToJob);
            command.AddParameter("FlameResistantWorkWear", workPermit.FlameResistantWorkWear);
            command.AddParameter("ChemicalSuit", workPermit.ChemicalSuit);
            command.AddParameter("FireWatch", workPermit.FireWatch);
            command.AddParameter("FireBlanket", workPermit.FireBlanket);
            command.AddParameter("SuppliedBreathingAir", workPermit.SuppliedBreathingAir);
            command.AddParameter("AirMover", workPermit.AirMover);
            command.AddParameter("PersonalFlotationDevice", workPermit.PersonalFlotationDevice);
            command.AddParameter("HearingProtection", workPermit.HearingProtection);
            command.AddParameter("Other1", workPermit.Other1);
            command.AddParameter("MonoGoggles", workPermit.MonoGoggles);
            command.AddParameter("ConfinedSpaceMoniter", workPermit.ConfinedSpaceMoniter);
            command.AddParameter("FireExtinguisher", workPermit.FireExtinguisher);
            command.AddParameter("SparkContainment", workPermit.SparkContainment);
            command.AddParameter("BottleWatch", workPermit.BottleWatch);
            command.AddParameter("StandbyPerson", workPermit.StandbyPerson);
            command.AddParameter("WorkingAlone", workPermit.WorkingAlone);
            command.AddParameter("SafetyGloves", workPermit.SafetyGloves);
            command.AddParameter("Other2", workPermit.Other2);
            command.AddParameter("FaceShield", workPermit.FaceShield);
            command.AddParameter("FallProtection", workPermit.FallProtection);
            command.AddParameter("ChargedFireHouse", workPermit.ChargedFireHouse);
            command.AddParameter("CoveredSewer", workPermit.CoveredSewer);
            command.AddParameter("AirPurifyingRespirator", workPermit.AirPurifyingRespirator);
            command.AddParameter("SingalPerson", workPermit.SingalPerson);
            command.AddParameter("CommunicationDevice  ", workPermit.CommunicationDevice);
            command.AddParameter("ReflectiveStrips  ", workPermit.ReflectiveStrips);
            command.AddParameter("Other3  ", workPermit.Other3);

            command.AddParameter("PartEWorkSectionNotApplicable", workPermit.PartEWorkSectionNotApplicableToJob);
            command.AddParameter("ConfinedSpace", workPermit.ConfinedSpace);
            command.AddParameter("ConfinedSpaceClass", workPermit.ConfinedSpaceClass);
            command.AddParameter("GoundDisturbance", workPermit.GroundDisturbance);
            command.AddParameter("FireProtectionAuthorization", workPermit.FireProtectionAuthorization);
            command.AddParameter("CriticalOrSeriousLifts", workPermit.CriticalOrSeriousLifts);
            command.AddParameter("VehicleEntry", workPermit.VehicleEntry);
            command.AddParameter("IndustrialRadiography", workPermit.IndustrialRadiography);
            command.AddParameter("ElectricalEncroachment", workPermit.ElectricalEncroachment);
            command.AddParameter("MSDS", workPermit.MSDS);
            command.AddParameter("OthersPartE", workPermit.OthersPartE);

            command.AddParameter("PartFWorkSectionNotApplicable", workPermit.PartFWorkSectionNotApplicableToJob);
            command.AddParameter("MechanicallyIsolated", workPermit.MechanicallyIsolated);
            command.AddParameter("BlindedOrBlanked", workPermit.BlindedOrBlanked);
            command.AddParameter("DoubleBlockedandBled", workPermit.DoubleBlockedandBled);
            command.AddParameter("DrainedAndDepressurised", workPermit.DrainedAndDepressurised);
            command.AddParameter("PurgedorNeutralised", workPermit.PurgedorNeutralised);
            command.AddParameter("ElectricallyIsolated ", workPermit.ElectricallyIsolated);
            command.AddParameter("TestBumped", workPermit.TestBumped);
            command.AddParameter("NuclearSource", workPermit.NuclearSource);
            command.AddParameter("ReceiverStafingRequirements", workPermit.ReceiverStafingRequirements);
            
            command.AddParameter("PartGWorkSectionNotApplicable", workPermit.PartGWorkSectionNotApplicableToJob);
            command.AddParameter("Frequency", workPermit.Frequency);
            command.AddParameter("Continuous", workPermit.Continuous);
            command.AddParameter("TesterName", workPermit.TesterName);
            command.AddParameter("Oxygen", workPermit.Oxygen);
            command.AddParameter("LEL", workPermit.LEL);
            command.AddParameter("H2SPPM", workPermit.H2SPPM);
            command.AddParameter("CoPPM ", workPermit.CoPPM);
            command.AddParameter("So2PPM", workPermit.So2PPM);
            command.AddParameter("Other1PartGValue", workPermit.Other1PartGValue);
            command.AddParameter("Other2PartGValue", workPermit.Other2PartGValue);

            command.AddParameter("PermitIssuer", workPermit.PermitIssuer);
            command.AddParameter("AreaAuthority", workPermit.AreaAuthority);
            command.AddParameter("CoAuthorizingIssuer", workPermit.CoAuthorizingIssuer);
            command.AddParameter("AddationalAuthority", workPermit.AddationalAuthority);
            command.AddParameter("PermitIssuerContact", workPermit.PermitIssuerContact);
            command.AddParameter("AreaAuthorityContact", workPermit.AreaAuthorityContact);
            command.AddParameter("CoAuthorizingIssuerContact", workPermit.CoAuthorizingIssuerContact);
            command.AddParameter("AddationalAuthorityContact", workPermit.AddationalAuthorityContact);
            command.AddParameter("IsFieldTourRequired", workPermit.IsFieldTourRequired);
            command.AddParameter("FieldTourConductedBy", workPermit.FieldTourConductedBy);

            command.AddParameter("PermitAcceptor", workPermit.PermitAcceptor);
            
        }

       
        private WorkPermitFortHills PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            DataSource dataSource = DataSource.GetById(reader.Get<int>("DataSourceId"));
            PermitRequestBasedWorkPermitStatus status = PermitRequestBasedWorkPermitStatus.Get(reader.Get<int>("WorkPermitStatusId"));
            WorkPermitFortHillsType type = WorkPermitFortHillsType.Get(reader.Get<int>("WorkPermitTypeId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            WorkPermitFortHillsGroup group = groupDao.QueryById(reader.Get<long>("GroupId"));

            WorkPermitFortHills permit = new WorkPermitFortHills(dataSource, status, type, createdDateTime, createdBy)
                {
                    Id = id,
                    Company = reader.Get<string>("Company"),
                    Occupation = reader.Get<string>("Occupation"),
                    NumberOfWorkers = reader.Get<int?>("NumberOfWorkers"),
                    Prioritydata = Priority.GetById(reader.Get<int>("PriorityId")),
                    FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId")),
                    Location = reader.Get<string>("Location"),
                    RequestedStartDateTime = reader.Get<DateTime>("RequestedStartDateTime"),
                    IssuedDateTime = reader.Get<DateTime?>("IssuedDateTime"),
                    ExpiredDateTime = reader.Get<DateTime>("ExpiredDateTime"),
                    PermitNumber = reader.Get<long?>("PermitNumber"),
                    WorkOrderNumber = reader.Get<string>("WorkOrderNumber"),
                    OperationNumber = reader.Get<string>("OperationNumber"),
                    SubOperationNumber = reader.Get<string>("SubOperationNumber"),
                    PartDWorkSectionNotApplicableToJob = reader.Get<bool>("PartDWorkSectionNotApplicable"),
                    TaskDescription = reader.Get<string>("TaskDescription"),
                    HazardsAndOrRequirements = reader.Get<string>("HazardsAndOrRequirements"),
                    IssuedToSuncor = reader.Get<bool>("IssuedToSuncor"),
                    IssuedToCompany = reader.Get<bool>("IssuedToCompany"),
                    Group = @group,

                    PartCWorkSectionNotApplicableToJob = reader.Get<bool>("PartCWorkSectionNotApplicable"),
                    FlameResistantWorkWear = reader.Get<bool>("FlameResistantWorkWear"),
                    ChemicalSuit = reader.Get<bool>("ChemicalSuit"),
                    FireWatch = reader.Get<bool>("FireWatch"),
                    FireBlanket = reader.Get<bool>("FireBlanket"),
                    SuppliedBreathingAir = reader.Get<bool>("SuppliedBreathingAir"),
                    AirMover = reader.Get<bool>("AirMover"),
                    PersonalFlotationDevice = reader.Get<bool>("PersonalFlotationDevice"),
                    HearingProtection = reader.Get<bool>("HearingProtection"),
                    Other1 = reader.Get<string>("Other1"),
                    MonoGoggles = reader.Get<bool>("MonoGoggles"),
                    ConfinedSpaceMoniter = reader.Get<bool>("ConfinedSpaceMoniter"),
                    FireExtinguisher = reader.Get<bool>("FireExtinguisher"),
                    SparkContainment = reader.Get<bool>("SparkContainment"),
                    BottleWatch = reader.Get<bool>("BottleWatch"),
                    StandbyPerson = reader.Get<bool>("StandbyPerson"),
                    WorkingAlone = reader.Get<bool>("WorkingAlone"),
                    SafetyGloves = reader.Get<bool>("SafetyGloves"),
                    Other2 = reader.Get<string>("Other2"),
                    FaceShield = reader.Get<bool>("FaceShield"),
                    FallProtection = reader.Get<bool>("FallProtection"),
                    ChargedFireHouse = reader.Get<bool>("ChargedFireHouse"),
                    CoveredSewer = reader.Get<bool>("CoveredSewer"),
                    AirPurifyingRespirator = reader.Get<bool>("AirPurifyingRespirator"),
                    SingalPerson = reader.Get<bool>("SingalPerson"),
                    CommunicationDevice = reader.Get<bool>("CommunicationDevice"),
                    ReflectiveStrips = reader.Get<bool>("ReflectiveStrips"),
                    Other3 = reader.Get<string>("Other3"),

                    PartEWorkSectionNotApplicableToJob = reader.Get<bool>("PartEWorkSectionNotApplicable"),
                    ConfinedSpace = reader.Get<bool>("ConfinedSpace"),
                    ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass"),
                    GroundDisturbance = reader.Get<bool>("GoundDisturbance"),
                    FireProtectionAuthorization = reader.Get<bool>("FireProtectionAuthorization"),
                    CriticalOrSeriousLifts = reader.Get<bool>("CriticalOrSeriousLifts"),
                    VehicleEntry = reader.Get<bool>("VehicleEntry"),
                    IndustrialRadiography = reader.Get<bool>("IndustrialRadiography"),
                    ElectricalEncroachment = reader.Get<bool>("ElectricalEncroachment"),
                    MSDS = reader.Get<bool>("MSDS"),
                    OthersPartE = reader.Get<string>("OthersPartE"),
                    
                    PartFWorkSectionNotApplicableToJob = reader.Get<bool>("PartFWorkSectionNotApplicable"),
                    MechanicallyIsolated = reader.Get<bool>("MechanicallyIsolated"),
                    BlindedOrBlanked = reader.Get<bool>("BlindedOrBlanked"),
                    DoubleBlockedandBled = reader.Get<bool>("DoubleBlockedandBled"),
                    DrainedAndDepressurised = reader.Get<bool>("DrainedAndDepressurised"),
                    PurgedorNeutralised = reader.Get<bool>("PurgedorNeutralised"),
                    ElectricallyIsolated = reader.Get<bool>("ElectricallyIsolated"),
                    TestBumped = reader.Get<bool>("TestBumped"),
                    NuclearSource = reader.Get<bool>("NuclearSource"),
                    ReceiverStafingRequirements = reader.Get<bool>("ReceiverStafingRequirements"),

                    PartGWorkSectionNotApplicableToJob = reader.Get<bool>("PartGWorkSectionNotApplicable"),
                    Frequency = reader.Get<string>("Frequency"),
                    Continuous = reader.Get<bool>("Continuous"),
                    TesterName = reader.Get<string>("TesterName"),
                    Oxygen = reader.Get<bool>("Oxygen"),
                    LEL = reader.Get<bool>("LEL"),
                    H2SPPM = reader.Get<bool>("H2SPPM"),
                    CoPPM = reader.Get<bool>("CoPPM"),
                    So2PPM = reader.Get<bool>("So2PPM"),
                    Other1PartGValue = reader.Get<string>("Other1PartGValue"),
                    Other2PartGValue = reader.Get<string>("Other2PartGValue"),
                    
                    PermitIssuer =  reader.Get<string>("PermitIssuer"),
                    AreaAuthority = reader.Get<string>("AreaAuthority"),
                    CoAuthorizingIssuer = reader.Get<string>("CoAuthorizingIssuer"),
                    AddationalAuthority = reader.Get<string>("AddationalAuthority"),
                    PermitIssuerContact = reader.Get<string>("PermitIssuerContact"),
                    AreaAuthorityContact = reader.Get<string>("AreaAuthorityContact"),
                    CoAuthorizingIssuerContact = reader.Get<string>("CoAuthorizingIssuerContact"),
                    AddationalAuthorityContact = reader.Get<string>("AddationalAuthorityContact"),
                    IsFieldTourRequired = reader.Get<bool>("IsFieldTourRequired"),
                    FieldTourConductedBy  = reader.Get<string>("FieldTourConductedBy"),

                    PermitAcceptor = reader.Get<string>("PermitAcceptor"),
                    //ShiftSupervisor = reader.Get<string>("ShiftSupervisor"),
                    

                };
            permit.RevalidationDateTime = reader.Get<DateTime?>("RevalidationDateTime");
            permit.ExtensionDateTime = reader.Get<DateTime?>("ExtensionDateTime");
            
            if (permit.ExtensionDateTime != null)
            {
                permit.ExtensionReasonPartJ = reader.Get<string>("ExtensionReasonPartJ");
                permit.ExtendedByUser = userDao.QueryById(reader.Get<long>("ExtendedByUser"));
            }
            if (reader["EquipmentNo"] == DBNull.Value){
                permit.EquipmentNo = string.Empty;
            }
            else
            {
                permit.EquipmentNo = Convert.ToString((reader.Get<int>("EquipmentNo"))) ;
            }
            permit.JobCoordinator = reader.Get<string>("JobCoordinator");
            permit.CoOrdContactNumber = reader.Get<string>("CoOrdContactNumber");
            permit.EmergencyAssemblyArea = reader.Get<string>("EmergencyAssemblyArea");
            permit.EmergencyMeetingPoint = reader.Get<string>("EmergencyMeetingPoint");
            permit.EmergencyContactNo = reader.Get<string>("EmergencyContactNumber");
            permit.LockBoxNumber = reader.Get<string>("Locknumber");
            permit.LockBoxnumberChecked = reader.Get<bool>("LockBoxnumberChecked");
            permit.IsolationNo = reader.Get<string>("IsolationNumber");
            permit.Prioritydata = Priority.GetById(reader.Get<int>("PriorityId"));
            
            long? permitRequestCreatedByUserId = reader.Get<long?>("PermitRequestCreatedByUserId");
            permit.PermitRequestCreatedByUser = permitRequestCreatedByUserId != null ? userDao.QueryById(permitRequestCreatedByUserId.Value) : null;

            long? issuedByUserId = reader.Get<long?>("IssuedByUserId");
            permit.IssuedByUser = issuedByUserId != null ? userDao.QueryById(issuedByUserId.Value) : null;

            permit.LastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            permit.LastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            return permit;
        }

        private Time GetTime(DateTime? value)
        {
            if (value == null)
            {
                return null;
            }

            return new Time(value.Value);
        }

        private static void SetPermitNumber(WorkPermitFortHills workPermit, SqlParameter permitNumberParameter)
        {
            if (permitNumberParameter.Value == DBNull.Value)
            {
                workPermit.PermitNumber = null;
            }
            else
            {
                workPermit.PermitNumber = (long) permitNumberParameter.Value;
            }
        }

        //private static void MaybeSetZeroEnergyFormNumber(WorkPermitFortHills workPermit)
        //{
        //    if (workPermit.ZeroEnergyFormNumber.IsNullOrEmptyOrWhitespace() && workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber && workPermit.PermitNumber != null)
        //    {
        //        workPermit.ZeroEnergyFormNumber = workPermit.PermitNumber.ToString();
        //    }
        //}

        public WorkPermitFortHills QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitFortHills permit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", permit.IdValue);
            return command.QueryForSingleResult<WorkPermitFortHills>(PopulateInstance, "QueryWorkPermitFortHillsForReuse");
        }

        public bool DoesPermitRequestFortHillsAssociationExist(List<long> permitRequests, Range<DateTime> rangeOfExistingPermits)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitStartDateTime", rangeOfExistingPermits.LowerBound);
            command.AddParameter("@WorkPermitEndDateTime", rangeOfExistingPermits.UpperBound);

            string permitRequestIds = permitRequests.ToCommaSeparatedString();
            command.AddParameter("@PermitRequestIds", permitRequestIds);

            int count = command.GetCount(QueryDoesPermitRequestFortHillsAssociationExist);

            return count > 0;
        }
        private static bool IsColumnExists(System.Data.IDataReader dr, string columnName)
        {
            bool retVal = false;

            dr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= '{0}'", columnName);
            if (dr.GetSchemaTable().DefaultView.Count > 0)
            {
                retVal = true;
            }
            return retVal;
        }
    }
}
