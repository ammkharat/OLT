namespace Com.Suncor.Olt.Client.Controls
{
    public class OltGridAppearance
    {
        private readonly bool multiLineSelectedEnabled;
        private readonly bool wrapTextEnabled;
        private readonly bool outLookStyleEnabled;
        private readonly bool extendLastColumn;
        private readonly bool canEdit;
        private readonly bool editRowSelect;
        private readonly bool allowFilterIfNonOutlook;

        public static readonly OltGridAppearance MULTI_SELECT = new OltGridAppearance(true, false, true, true, false, false, false);
        public static readonly OltGridAppearance MULTI_SELECT_WRAPPED_TEXT = new OltGridAppearance(true, true, true, true, false, false, false);
        public static readonly OltGridAppearance SINGLE_SELECT = new OltGridAppearance(false, false, true, true, false, false, false);
        public static readonly OltGridAppearance SINGLE_SELECT_WRAPPED_TEXT = new OltGridAppearance(false, true, true, true, false, false, false);
        public static readonly OltGridAppearance NON_OUTLOOK = new OltGridAppearance(false, false, false, true, false, false, false);
        public static readonly OltGridAppearance NON_OUTLOOK_WRAPPED_TEXT = new OltGridAppearance(false, true, false, true, false, false, false);
        public static readonly OltGridAppearance EDIT_CELL_SELECT = new OltGridAppearance(false, false, false, true, true, false, false);
        public static readonly OltGridAppearance EDIT_ROW_SELECT = new OltGridAppearance(false, false, false, true, true, true, false);
        public static readonly OltGridAppearance EDIT_ROW_SELECT_WRAPPED_TEXT = new OltGridAppearance(false, true, false, true, true, true, false);
        public static readonly OltGridAppearance EDIT_CELL_SELECT_WITH_FILTER = new OltGridAppearance(false, false, false, true, true, false, true);
        public static readonly OltGridAppearance EDIT_ROW_SELECT_WITH_FILTER = new OltGridAppearance(false, false, false, true, true, true, true);

        private OltGridAppearance(bool multiLineSelectedEnabled, bool wrapTextEnabled, bool outLookStyleEnabled, bool extendLastColumn, bool canEdit, bool editRowSelect, bool allowFilterIfNonOutlook)
        {
            this.multiLineSelectedEnabled = multiLineSelectedEnabled;
            this.wrapTextEnabled = wrapTextEnabled;
            this.outLookStyleEnabled = outLookStyleEnabled;
            this.extendLastColumn = extendLastColumn;
            this.canEdit = canEdit;
            this.editRowSelect = editRowSelect;
            this.allowFilterIfNonOutlook = allowFilterIfNonOutlook;
        }

        public static OltGridAppearance ExtendLastGridColumn(OltGridAppearance currentApperance)
        {
            return new OltGridAppearance(currentApperance.MultiLineSelectedEnabled, 
                                         currentApperance.WrapTextEnabled,
                                         currentApperance.OutLookStyleEnabled, 
                                         true,
                                         currentApperance.canEdit,
                                         currentApperance.editRowSelect,
                                         currentApperance.allowFilterIfNonOutlook);
        }

        public bool MultiLineSelectedEnabled
        {
            get { return multiLineSelectedEnabled; }
        }

        public bool WrapTextEnabled
        {
            get { return wrapTextEnabled; }
        }

        public bool OutLookStyleEnabled
        {
            get { return outLookStyleEnabled; }
        }

        public bool ExtendLastColumn
        {
            get { return extendLastColumn; }
        }

        public bool CanEdit
        {
            get { return canEdit; }
        }

        public bool EditRowSelect
        {
            get { return editRowSelect; }
        }

        public bool AllowFilterIfNonOutlook
        {
            get { return allowFilterIfNonOutlook; }
        }
    }
}