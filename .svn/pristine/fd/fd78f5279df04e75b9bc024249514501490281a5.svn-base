using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Resources;
using DevExpress.XtraEditors;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltToggleButton : SimpleButton
    {
        public event Action<bool> Toggled;

        private readonly Size fixedSize = new Size(15, 15);
        private bool expanded;

        public OltToggleButton()
        {
            base.Size = fixedSize;
            base.Padding = new Padding(0);

            Expanded = true;

            Click += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Expanded = !Expanded;
            if (Toggled != null)
            {
                Toggled(Expanded);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Width
        {
            get { return base.Width; }
            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Height
        {
            get { return base.Height; }
            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get { return base.Padding; }    
            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool TabStop
        {
            get { return false; }
            set { }
        }

        protected override void LayoutChanged()
        {
            base.LayoutChanged();
            UpdateFocusRect();
        }

        protected override void UpdateViewInfo(Graphics g)
        {
            base.UpdateViewInfo(g);
            UpdateFocusRect();
        }

        void UpdateFocusRect()
        {
            ViewInfo.ButtonInfo.DrawFocusRectangle = false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return ""; }
            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image Image
        {
            get { return base.Image; }
            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLocation ImageLocation
        {
            get { return ImageLocation.MiddleCenter; }
            set { }
        }
        
        public bool Expanded
        {
            get { return expanded; }
            set
            {
                expanded = value;
                base.Image = expanded ? ResourceUtils.COLLAPSE : ResourceUtils.EXPAND;
            }
        }
    }
}
