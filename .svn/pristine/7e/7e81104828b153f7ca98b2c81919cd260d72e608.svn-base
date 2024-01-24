
using System;
using System.Collections.Generic;
using Infragistics.Win;
using Infragistics.Win.SupportDialogs.FilterUIProvider;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class StringFilterMenuCustomization
    {

        public StringFilterMenuCustomization(UltraGrid grid, UltraGridFilterUIProvider provider)
        {
            if (grid.DisplayLayout.Override.AllowRowFiltering != DefaultableBoolean.False)
            {
                 provider.AfterMenuPopulate += GridFilterUIProvider_AfterMenuPopulate;
            }
        }

        private void GridFilterUIProvider_AfterMenuPopulate(object sender, AfterMenuPopulateEventArgs e)
        {
            if (e.ColumnFilter.Column.DataType == typeof(String))
            {
                foreach (FilterTool tool in e.MenuItems)
                {
                    FilterMenuTool menuTool = tool as FilterMenuTool;
                    if (menuTool != null)
                    {
                        RemoveSomeMenuItems(menuTool.Tools);
                    }
                }
            }
        }

        private void RemoveSomeMenuItems(IList<FilterTool> tools)
        {
            bool removedFilterToolIsApplied = false;

            for (int i = tools.Count - 1; i >= 0; i--)
            {
                FilterTool tool = tools[i];

                if (tool.Id != "Contains" && tool.Id != "Custom Filter")
                {                    
                    if (tool.Checked)
                    {
                        removedFilterToolIsApplied = true;
                    }

                    tools.RemoveAt(i);
                }
            }

            // if one of the filters we just removed (e.g. "Starts With") was applied (i.e. had a checkmark beside it), we want to move the checkmark to the
            // custom filter tool so that the user can tell which filter is being used (all of the filters we remove from the menu are also available as a
            // custom filter, so this makes sense)
            if (removedFilterToolIsApplied)
            {
                FilterTool customFilterTool = GetCustomFilterTool(tools);
                if (customFilterTool != null)
                {
                    customFilterTool.Checked = true;    
                }                
            }
        }

        private static FilterTool GetCustomFilterTool(IList<FilterTool> tools)
        {
            FilterTool customFilterTool = null;
            for (int i = tools.Count - 1; i >= 0; i--)
            {
                FilterTool tool = tools[i];

                if (tool.Id == "Custom Filter")
                {
                    customFilterTool = tool;
                }
            }
            return customFilterTool;
        }
    }


}
