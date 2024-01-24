using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using ResourcesResx = Com.Suncor.Olt.Client.Properties.Resources;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class MainNavigationListView : UserControl
    {
        public event Action<SectionKey> SelectedSectionChanged;

        public MainNavigationListView()
        {
            InitializeComponent();

            ImageList imageList = new ImageList {TransparentColor = Color.Transparent};
            imageList.Images.Add(GetImageKey(SectionKey.PrioritiesSection), ResourcesResx.priorities_48);
            imageList.Images.Add(GetImageKey(SectionKey.ActionItemSection), ResourcesResx.actionItems_48);

            imageList.Images.Add(GetImageKey(SectionKey.ReadingSection), ResourcesResx.reading_48);          //ayman action item reading

            imageList.Images.Add(GetImageKey(SectionKey.LabAlertSection), ResourcesResx.lab_alert_48);
            imageList.Images.Add(GetImageKey(SectionKey.LogSection), ResourcesResx.log_48);
            imageList.Images.Add(GetImageKey(SectionKey.LogSection_ConstSite), ResourcesResx.log_48); //RITM0443261 : Added by Vibhor {Change the name for Shift log as DWR for forms caption and in Menu and Tabs  for Construction Management Site}
            imageList.Images.Add(GetImageKey(SectionKey.RestrictionSection), ResourcesResx.target_48);
            imageList.Images.Add(GetImageKey(SectionKey.ShiftHandoverSection), ResourcesResx.shift_handover_48);
            imageList.Images.Add(GetImageKey(SectionKey.DirectiveSection), ResourcesResx.directives_48);
            imageList.Images.Add(GetImageKey(SectionKey.EventSection), ResourcesResx.target_48);
            imageList.Images.Add(GetImageKey(SectionKey.FormSection), ResourcesResx.form_48);
            imageList.Images.Add(GetImageKey(SectionKey.TargetSection), ResourcesResx.target_48);
            imageList.Images.Add(GetImageKey(SectionKey.WorkPermitSection), ResourcesResx.permit_48);
            imageList.Images.Add(GetImageKey(SectionKey.OnPremisePersonnelSection), ResourcesResx.on_premise_personnel);
            imageList.ImageSize = new Size(ResourcesResx.target_48.Width, ResourcesResx.target_48.Height);

            navigationListView.LargeImageList = imageList;

            navigationListView.SelectedIndexChanged += NavigationListView_SelectedIndexChanged;
        }

        private void NavigationListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedSectionChanged != null && SelectedSection != null)
            {
                SelectedSectionChanged(SelectedSection);
            }
        }

        private static string GetImageKey(SectionKey key)
        {
            return key.Name;
        }

        public void NavigateTo(SectionKey key)
        {
            if (key != null)
            {
                ListViewItem item = GetItem(key);
                if (item != null)
                {
                    item.Selected = true;
                    navigationListView.Select();
                }
                else
                {
                    SelectFirstItem();                    
                }
            }
            else
            {
                SelectFirstItem();
            }
        }

        private void SelectFirstItem()
        {
            if (navigationListView.Items.Count > 0)
            {
                navigationListView.Items[0].Selected = true;
            }
            navigationListView.Select();
        }

        private ListViewItem GetItem(SectionKey key)
        {
            foreach (ListViewItem item in navigationListView.Items)
            {
                SectionKey tagKey = (SectionKey)item.Tag;
                if (Equals(tagKey, key))
                {
                    return item;
                }
            }
            return null;
        }

        public void UnSelectPageInNavigationList()
        {
            navigationListView.SelectedItems.Clear();
        }

        public SectionKey SelectedSection
        {
            get
            {
                if (navigationListView.SelectedItems.Count > 0)
                {
                    ListViewItem item = navigationListView.SelectedItems[0];
                    return (SectionKey)item.Tag;
                }

                return null;
            }
        }

        public string SelectedSectionName
        {
            get
            {
                if (navigationListView.SelectedItems.Count > 0)
                {
                    ListViewItem item = navigationListView.SelectedItems[0];
                    return item.Text;
                }
                return null;
            }
        }

        public void ClearNavigation()
        {
            navigationListView.Items.Clear();
        }

        public void AddNavigation(SectionKey key)
        {
            var listViewItem = new ListViewItem { Text = key.Name, ImageKey = GetImageKey(key), Tag = key };
            navigationListView.Items.Add(listViewItem);
        }

    }
}
