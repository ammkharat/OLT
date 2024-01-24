using System;

namespace Com.Suncor.Olt.Common.Utility
{
    public class SearchFilterEventArgs : EventArgs
    {
        public SearchFilterEventArgs(string filterString, string searchString)
        {
            SearchString = searchString;
            FilterString = filterString;
        }

        public string SearchString { get; private set; }

        public string FilterString { get; private set; }
    }
}