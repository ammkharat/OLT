namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IRestrictionDefinitionDetails : IDeletableDetails
    {
        string EditedBy { set; }
        bool Active { set; }

        string DefinitionName { set; }
        string FunctionalLocation { set; }
        string Description { set; }
        string MeasurementTag { set; }
        string ProductionTarget { set; }
        string PreviousInvocationDate { set; }

        //Added by Mukesh for RITM0219490
        int? ToleranceValue { set; }

        string FrequencyValue { set; } // DMND0010124 mangesh
    }
}