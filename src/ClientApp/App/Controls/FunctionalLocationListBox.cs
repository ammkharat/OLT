using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls
{
    public class FunctionalLocationListBox : OltListBox
    {
        private const string FULL_HIERARCHY_WITH_DESCRIPTION_PROPERTY_NAME = "FullHierarchyWithDescription";

        public FunctionalLocationListBox()
        {
            base.DisplayMember = FULL_HIERARCHY_WITH_DESCRIPTION_PROPERTY_NAME;
            base.FormattingEnabled = true;
            base.HorizontalScrollbar = true;
            base.Sorted = true;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new string DisplayMember
        {
            get { return base.DisplayMember; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool FormattingEnabled
        {
            get { return base.FormattingEnabled; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool HorizontalScrollbar
        {
            get { return base.HorizontalScrollbar; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool Sorted
        {
            get { return base.Sorted; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool TabStop
        {
            get { return base.TabStop; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool Enabled
        {
            get { return base.Enabled; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new Color BackColor
        {
            get { return base.BackColor; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new object DataSource
        {
            get { return base.DataSource; }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                base.TabStop = !value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<FunctionalLocation> FunctionalLocations
        {
            get { return base.DataSource as List<FunctionalLocation> ?? new List<FunctionalLocation>(); }
            set
            {
                value.Sort(f => f.FullHierarchy);
                base.DataSource = value;
                if (base.ReadOnly)
                {
                    SelectedIndex = -1;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return (FunctionalLocation) SelectedItem; }
        }
    }
}