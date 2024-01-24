namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public interface IRule<T>
    {
        bool Check(T someObject);
    }
}