using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ILogGuidelineDao : IDao
    {
        LogGuideline QueryByDivision(FunctionalLocation functionalLocation);
        LogGuideline Insert(LogGuideline logGuideline);
        void Update(LogGuideline guideline);        
    }
}
