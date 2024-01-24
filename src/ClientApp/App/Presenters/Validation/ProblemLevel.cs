namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public enum ProblemLevel
    {
        // These should stay in this order so that we can do things like:
        // issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning
        Warning, RequiredForApproval, RequiredForSave
    }
}