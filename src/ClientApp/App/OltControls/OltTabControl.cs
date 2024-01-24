using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Appearance = Infragistics.Win.Appearance;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltTabControl : UltraTabControl, IUIElementDrawFilter
    {
        public OltTabControl()
        {
            TabSize = new Size(0, 28);
            AllowTabClosing = false;
            UseHotTracking = DefaultableBoolean.True;

//            InterTabSpacing = new DefaultableInteger(3);
            SpaceBeforeTabs = new DefaultableInteger(5);
            Style = UltraTabControlStyle.Excel;

            UseOsThemes  =  DefaultableBoolean.False;

            Appearance appearance1 = new Appearance();
            appearance1.BackGradientStyle = GradientStyle.Vertical;
            appearance1.BackColor = SystemColors.ControlLightLight;
            appearance1.BackColor2 = SystemColors.GradientInactiveCaption;
            appearance1.FontData.Bold = DefaultableBoolean.True;
            ActiveTabAppearance = appearance1;

            SelectedTabAppearance.BorderColor = SystemColors.ActiveCaption;
            SelectedTabAppearance.BorderColor2 = SelectedTabAppearance.BorderColor;
            SelectedTabAppearance.BorderColor3DBase = SelectedTabAppearance.BorderColor;

//            Appearance appearance1 = new Appearance();
//            appearance1.BackColor = Color.WhiteSmoke;
//            ActiveTabAppearance = appearance1;
//
//            Appearance appearance2 = new Appearance();
//            appearance2.BackColor = Color.WhiteSmoke;
//            ClientAreaAppearance = appearance2;

             DrawFilter = this;
        }

        public bool DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            if (drawPhase == DrawPhase.BeforeDrawBorders)
            {
                drawParams.AppearanceData.BorderColor = SelectedTabAppearance.BorderColor;
                drawParams.AppearanceData.BorderColor2 = SelectedTabAppearance.BorderColor;
                drawParams.AppearanceData.BorderColor3DBase = SelectedTabAppearance.BorderColor;
                drawParams.DrawBorders(UIElementBorderStyle.TwoColor, Border3DSide.All);
                return true;
            } 
            return false;
        } 
        
        public DrawPhase GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            if (drawParams.Element is TabPageAreaUIElement)
            {
                return DrawPhase.BeforeDrawBorders;
            } 
            return DrawPhase.None;
        } 


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new Size TabSize
        {
            get { return base.TabSize; }
            private set { base.TabSize = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool AllowTabClosing
        {
            get { return base.AllowTabClosing; }
            private set { base.AllowTabClosing = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new DefaultableBoolean UseOsThemes
        {
            get { return base.UseOsThemes; }
            private set { base.UseOsThemes = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new DefaultableBoolean UseHotTracking
        {
            get { return base.UseHotTracking; }
            private set { base.UseHotTracking = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new DefaultableInteger InterTabSpacing
        {
            get { return base.InterTabSpacing; }
            private set { base.InterTabSpacing = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new DefaultableInteger SpaceBeforeTabs
        {
            get { return base.SpaceBeforeTabs; }
            private set { base.SpaceBeforeTabs = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new UltraTabControlStyle Style
        {
            get { return base.Style; }
            private set { base.Style = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new AppearanceBase Appearance
        {
            get { return base.Appearance; }
            private set { base.Appearance = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new AppearanceBase ActiveTabAppearance
        {
            get { return base.ActiveTabAppearance; }
            private set { base.ActiveTabAppearance = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new AppearanceBase SelectedTabAppearance
        {
            get { return base.SelectedTabAppearance; }
            private set { base.SelectedTabAppearance = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new AppearanceBase ClientAreaAppearance
        {
            get { return base.ClientAreaAppearance; }
            private set { base.ClientAreaAppearance = value; }
        }

        public UltraTab CreateTab(string name, string tabText)
        {
            UltraTab existingTab = FindExistingTab(name);
            if (existingTab != null)
            {
                return existingTab;
            }
            else
            {
                UltraTabPageControl tabPageControl = new UltraTabPageControl();
                tabPageControl.Name = name;
                Controls.Add(tabPageControl);

                UltraTab tab = new UltraTab();
                tab.TabPage = tabPageControl;
                tab.Text = tabText;
                Tabs.Add(tab);

                return tab;
            }
        }

        private UltraTab FindExistingTab(string name)
        {
            foreach (UltraTab existingTab in Tabs)
            {
                if (existingTab.TabPage.Name == name)
                {
                    return existingTab;
                }
            }
            return null;
        }

        public void HideTab(UltraTabPageControl tab)
        {
            tab.Tab.Visible = false;
        }

        public void ShowTab(UltraTabPageControl tab)
        {
            tab.Tab.Visible = true;
        }
    }
}
