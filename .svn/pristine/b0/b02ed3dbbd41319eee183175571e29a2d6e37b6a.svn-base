namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public delegate void CraftOrTradeAction();

    /// <summary>
    ///     Craft or trade as specified on a work permit.
    /// </summary>
    public interface ICraftOrTrade
    {
        string Name { get; set; }
        ICraftOrTrade Copy();

        /// <summary>
        ///     Dispatches which action to take based on the type of craft/trade this is
        ///     (system-specified or user-specified).
        /// </summary>
        void PerformAction(CraftOrTradeAction actionForSystem, CraftOrTradeAction actionForUserSpecified);
    }
}