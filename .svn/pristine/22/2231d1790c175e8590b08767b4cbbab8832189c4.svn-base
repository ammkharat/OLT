using System;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class Rule<T> : IRule<T>
    {
        private readonly Predicate<T> predicate;

        public Rule(Predicate<T> predicate)
        {
            this.predicate = predicate;
        }

        public bool Check(T someObject)
        {
            return predicate(someObject);
        }
    }
}