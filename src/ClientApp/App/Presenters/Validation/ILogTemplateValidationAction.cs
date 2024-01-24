namespace Com.Suncor.Olt.Client.Presenters.Validation
{  
    public interface ILogTemplateValidationAction
    {
        void ClearAllErrors();
        void SetErrorForNoAssociatedWorkAssignments();
        void SetErrorForNoNameProvided();
        void SetErrorForDuplicateName();
        void SetErrorForNoTextProvided();
    }
}
