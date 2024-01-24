namespace Com.Suncor.Olt.Common.Wcf
{
    /// <summary>
    ///     A simple Service Registry that doesn't have the complications of having to register itself as a listener of Events
    ///     from the OLT server.
    /// </summary>
    public sealed class GenericServiceRegistry : AbstractServiceRegistry
    {
        private static readonly GenericServiceRegistry instance = new GenericServiceRegistry();

        private GenericServiceRegistry()
        {
        }

        public static GenericServiceRegistry Instance
        {
            get { return instance; }
        }
    }
}