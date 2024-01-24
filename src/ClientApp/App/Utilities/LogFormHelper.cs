using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class LogFormHelper
    {
        public static void SetCustomFieldPhTagAssociationControlsVisible(CustomFieldPhTagLegendControl customFieldPhTagLegendControl, OltButton importCustomFieldsButton,
            CustomFieldTableLayoutPanel customFieldTableLayoutPanel, OltPanel customFieldsPanel, bool hasPhdReadCustomField, bool hasPhdWriteCustomField)
        {
            customFieldPhTagLegendControl.Visible = hasPhdReadCustomField || hasPhdWriteCustomField;
            importCustomFieldsButton.Visible = hasPhdReadCustomField;

            if (hasPhdReadCustomField || hasPhdWriteCustomField)
            {
                customFieldsPanel.Height = customFieldTableLayoutPanel.Height + customFieldPhTagLegendControl.Height + 35;

                int yCoordOfCustomFieldControlBottom = customFieldTableLayoutPanel.Location.Y + customFieldTableLayoutPanel.Height;
                customFieldsPanel.Location = new Point(customFieldPhTagLegendControl.Location.X, yCoordOfCustomFieldControlBottom);
            }
            else
            {
                customFieldsPanel.Height = customFieldTableLayoutPanel.Height;
            }
        }

        //ayman action item reading
        public static void SetCustomFieldPhTagAssociationControlsVisibleForReading(CustomFieldPhTagLegendControl customFieldPhTagLegendControl, OltButton importCustomFieldsButton,
    CustomFieldTableLayoutPanelTracker customFieldTableLayoutPanel, OltPanel customFieldsPanel, bool hasPhdReadCustomField, bool hasPhdWriteCustomField)
        {
            customFieldPhTagLegendControl.Visible = hasPhdReadCustomField || hasPhdWriteCustomField;
            importCustomFieldsButton.Visible = hasPhdReadCustomField;

            if (hasPhdReadCustomField || hasPhdWriteCustomField)
            {
                customFieldsPanel.Height = customFieldTableLayoutPanel.Height + customFieldPhTagLegendControl.Height + 35;

                int yCoordOfCustomFieldControlBottom = customFieldTableLayoutPanel.Location.Y + customFieldTableLayoutPanel.Height;
                customFieldsPanel.Location = new Point(customFieldPhTagLegendControl.Location.X, yCoordOfCustomFieldControlBottom);
            }
            else
            {
                customFieldsPanel.Height = customFieldTableLayoutPanel.Height;
            }
        }

        public static void SetLogDateTimeError(ErrorProvider errorProvider, UserShift userShift, Control timeControl)
        {
            errorProvider.SetError(timeControl,
                String.Format(StringResources.LogActualTimeMustBeWithinCurrentShift,
                userShift.StartDateTimeWithPadding.ToTime(),
                userShift.EndDateTimeWithPadding.ToTime()));
        }

        public static IMultiSelectFunctionalLocationSelectionForm CreateFlocSelector(SiteConfiguration siteConfiguration, FunctionalLocationType functionalLocationType)
        {
            if (functionalLocationType == FunctionalLocationType.Level3)
            {
                return new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetLevelThreeAndBelow(siteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3), true);
            }
            else if (functionalLocationType == FunctionalLocationType.Level2)
            {
                return new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetLevelTwoAndBelow(siteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2), true);
            }
            //Change Log creation to display FLOC from Level 1  
            else if (functionalLocationType == FunctionalLocationType.Level1)
            {
                return new MultiSelectFunctionalLocationSelectionForm(
                    FunctionalLocationMode.GetAll(siteConfiguration),
                    new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1), true);
            }

            else
            {
                throw new ArgumentException("The functionalLocationType must be level2 or level3.");
            }
        }
    }
}
