using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.SupportDialogs.FilterUIProvider;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities
{
    public class FunctionalLocationFilterTool
    {
        private readonly object manuallyModifedConditionTag = new object();

        private readonly string columnKey;
        private readonly HashSet<string> sections = new HashSet<string>();
        private readonly HashSet<string> units = new HashSet<string>();

        public FunctionalLocationFilterTool(string columnKey)
        {
            this.columnKey = columnKey;
        }

        public void SetUp(UltraGrid grid, UltraGridFilterUIProvider provider)
        {
            if (grid.DisplayLayout.Override.AllowRowFiltering != DefaultableBoolean.False)
            {
                grid.AfterRowFilterChanged -= Grid_AfterRowFilterChanged;
                provider.BeforeMenuPopulate -= GridFilterUIProvider_BeforeMenuPopulate;
                grid.AfterRowFilterDropDownPopulate -= Grid_AfterRowFilterDropDownPopulate;
                provider.AfterMenuPopulate -= GridFilterUIProvider_AfterMenuPopulate;
                provider.ButtonToolClick -= GridFilterUIProvider_ButtonToolClick;

                grid.AfterRowFilterChanged += Grid_AfterRowFilterChanged;
                provider.BeforeMenuPopulate += GridFilterUIProvider_BeforeMenuPopulate;
                grid.AfterRowFilterDropDownPopulate += Grid_AfterRowFilterDropDownPopulate;
                provider.AfterMenuPopulate += GridFilterUIProvider_AfterMenuPopulate;
                provider.ButtonToolClick += GridFilterUIProvider_ButtonToolClick;
            }
        }

        private void Grid_AfterRowFilterChanged(object sender, AfterRowFilterChangedEventArgs e)
        {            
            ConvertEqualsOperatorToContainsOperator(e.Column.Key, e.NewColumnFilter.FilterConditions);
        }

        private void ConvertEqualsOperatorToContainsOperator(string key, FilterConditionsCollection filterConditions)
        {
            if (Equals(key, columnKey))
            {
                foreach (FilterCondition condition in filterConditions)
                {
                    if (!(condition is FunctionalLocationFilterCondition) && condition.ComparisionOperator == FilterComparisionOperator.Equals)
                    {
                        condition.ComparisionOperator = FilterComparisionOperator.Contains;
                        condition.Tag = manuallyModifedConditionTag;
                    }
                }
            }
        }

        private void GridFilterUIProvider_BeforeMenuPopulate(object sender, BeforeMenuPopulateEventArgs e)
        {            
            if (Equals(e.ColumnFilter.Column.Key, columnKey))
            {
                foreach (FilterCondition condition in e.ColumnFilter.FilterConditions)
                {
                    if (ReferenceEquals(condition.Tag, manuallyModifedConditionTag))
                    {
                        condition.ComparisionOperator = FilterComparisionOperator.Equals;
                        condition.Tag = null;
                    }
                }
            }
        }

        private void Grid_AfterRowFilterDropDownPopulate(object sender, AfterRowFilterDropDownPopulateEventArgs e)
        {
            if (Equals(e.Column.Key, columnKey))
            {
                sections.Clear();
                units.Clear();

                ValueListItemsCollection valueListItems = e.ValueList.ValueListItems;

                List<ValueListItem> newItems = new List<ValueListItem>();

                HashSet<string> allFlocs = new HashSet<string>();

                foreach (ValueListItem item in valueListItems)
                {
                    string dataValue = item.DataValue as string;
                    if (!string.IsNullOrEmpty(dataValue))
                    {
                        string[] flocs = dataValue.Split(',');
                        foreach (string floc in flocs)
                        {
                            string trimmedFloc = floc.Trim();
                            if (!allFlocs.Contains(trimmedFloc))
                            {
                                allFlocs.Add(trimmedFloc);
                                AddToSectionAndUnitLists(trimmedFloc);
                            }
                        }
                    }
                    else
                    {
                        newItems.Add(item);
                    }
                }

                List<string> sortedFlocs = new List<string>(allFlocs);
                sortedFlocs.Sort();
                foreach (string floc in sortedFlocs)
                {
                    ValueListItem valueListItem = new ValueListItem(floc, floc);                    
                    newItems.Add(valueListItem);
                }

                valueListItems.Clear();
                foreach (ValueListItem newItem in newItems)
                {                    
                    valueListItems.Add(newItem);
                }
            }
        }

        private void AddToSectionAndUnitLists(string floc)
        {
            FunctionalLocationHierarchy functionalLocationHierarchy = new FunctionalLocationHierarchy(floc);
            if (functionalLocationHierarchy.Level >= 2)
            {
                string level2Ancestor = functionalLocationHierarchy.GetAncestorOrSelf(2).ToString();
                sections.AddIfNotExist(level2Ancestor);
            }
            if (functionalLocationHierarchy.Level >= 3)
            {
                string level3Ancestor = functionalLocationHierarchy.GetAncestorOrSelf(3).ToString();
                units.AddIfNotExist(level3Ancestor);
            }
        }

        private void GridFilterUIProvider_ButtonToolClick(object sender, ButtonToolClickEventArgs e)
        {
            if (Equals(e.ColumnFilter.Column.Key, columnKey))
            {
                if (e.Tool.Tag is FunctionalLocationFilterCondition)
                {
                    List<FunctionalLocationFilterCondition> flocFilterConditions = GetFlocFilterConditions(e.ColumnFilter.FilterConditions);

                    FunctionalLocationFilterCondition newCondition = (FunctionalLocationFilterCondition)e.Tool.Tag;
                    List<FunctionalLocationFilterCondition> existingConditions = flocFilterConditions.FindAll(
                        obj => Equals(obj.CompareValue, newCondition.CompareValue));
                    if (existingConditions.Count > 0)
                    {
                        foreach (FunctionalLocationFilterCondition existingCondition in existingConditions)
                        {
                            flocFilterConditions.Remove(existingCondition);                            
                        }
                    }
                    else
                    {
                        flocFilterConditions.Add(newCondition);
                    }

                    e.ColumnFilter.FilterConditions.Clear();
                    foreach (FunctionalLocationFilterCondition condition in flocFilterConditions)
                    {
                        e.ColumnFilter.FilterConditions.Add(condition);
                    }
                    e.ColumnFilter.LogicalOperator = FilterLogicalOperator.Or;
                }
            }
        }

        private static List<FunctionalLocationFilterCondition> GetFlocFilterConditions(FilterConditionsCollection filterConditions)
        {
            List<FunctionalLocationFilterCondition> flocFilterConditions = new List<FunctionalLocationFilterCondition>();
            foreach (FilterCondition condition in filterConditions)
            {
                if (condition is FunctionalLocationFilterCondition)
                {
                    flocFilterConditions.Add((FunctionalLocationFilterCondition)condition);
                }
            }
            return flocFilterConditions;
        }

        private void GridFilterUIProvider_AfterMenuPopulate(object sender, AfterMenuPopulateEventArgs e)
        {
            if (Equals(e.ColumnFilter.Column.Key, columnKey))
            {
                bool isSectionOrUnitChecked = false;
                isSectionOrUnitChecked |= AddMenu(e, "SectionId", RendererStringResources.FilterSectionItem, sections);
                isSectionOrUnitChecked |= AddMenu(e, "UnitId", RendererStringResources.FilterUnitItem, units);

                if (isSectionOrUnitChecked)
                {
                    int textFiltersIndex = -1;
                    for (int i = 0; i < e.MenuItems.Count; i++)
                    {
                        FilterTool filterTool = e.MenuItems[i];
                        if (Equals(filterTool.DisplayText, InfragisticsStringResources.FilterUIProvider_Menu_TextFilters))
                        {
                            textFiltersIndex = i;
                        }
                    }
                    if (textFiltersIndex >= 0)
                    {
                        e.MenuItems.RemoveAt(textFiltersIndex);
                    }
                }
            }
            
            ConvertEqualsOperatorToContainsOperator(e.ColumnFilter.Column.Key, e.ColumnFilter.FilterConditions);
        }

        private static bool AddMenu(AfterMenuPopulateEventArgs e, string id, string displayText, HashSet<string> flocs)
        {
            if (flocs.Count > 0)
            {
                FilterMenuTool menuTool = new FilterMenuTool("FilterMenuToolFLOC" + id, displayText);

                List<string> sortedList = new List<string>(flocs);
                sortedList.Sort();

                foreach (string floc in sortedList)
                {
                    menuTool.Tools.Add(CreateButtonTool(e, floc));
                }

                e.MenuItems.Insert(e.MenuItems.Count - 1, menuTool);

                return menuTool.Checked;
            }
            else
            {
                return false;
            }
        }

        private static FilterButtonTool CreateButtonTool(AfterMenuPopulateEventArgs e, string flocString)
        {
            FilterButtonTool buttonTool = new FilterButtonTool("FilterButtonTool_" + flocString, flocString);
            buttonTool.Tag = new FunctionalLocationFilterCondition(flocString);

            foreach (var filterCondition in e.ColumnFilter.FilterConditions)
            {
                FunctionalLocationFilterCondition flocFilterCondition = filterCondition as FunctionalLocationFilterCondition;
                if (flocFilterCondition != null)
                {
                    if (Equals(flocFilterCondition.CompareValue as string, buttonTool.DisplayText))
                    {
                        buttonTool.Checked = true;
                    }
                }
            }

            return buttonTool;
        }

        [Serializable]
        private class FunctionalLocationFilterCondition : FilterCondition
        {
            public FunctionalLocationFilterCondition(string filterValue)
            {
                CompareValue = filterValue;
                ComparisionOperator = FilterComparisionOperator.Contains;
            }
        }
    }
}