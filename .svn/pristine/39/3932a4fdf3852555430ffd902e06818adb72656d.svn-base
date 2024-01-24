using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class AssociateTargetListViewRenderer : BaseListViewRenderer, IDomainListViewRenderer<TargetDefinitionDTO>
    {
        public ListViewItem RenderItem(TargetDefinitionDTO target)
        {
            ListViewItem result = null;

            if (target != null && FilterTest(target.StatusName) && SearchTest(target.Description))
            {
                var lvi = new DomainListViewItem<TargetDefinitionDTO>(target) {Text = target.Name};

                lvi.SubItems.Add(target.StartDate.ToLongDate());
                lvi.SubItems.Add(target.StartTime.ToString());

                lvi.SubItems.Add(target.FunctionalLocationName);

                lvi.SubItems.Add(target.TagName);

                result = lvi;

            }

            return result;

        }

        private bool FilterTest(string test)
        {
            return filterString.IsNullOrEmptyOrWhitespace() || filterString == StringResources.All || filterString == test;
        }

        private bool SearchTest(string test)
        {
            bool searchResult;
            if (test.IsNullOrEmptyOrWhitespace())
            {
                //return true if string is around
                searchResult = searchString.IsNullOrEmptyOrWhitespace();
            }
            else //test is not empty or null so check search string
            {
                if (searchString.IsNullOrEmptyOrWhitespace())
                    searchResult = true;
                else //not empty search string so search for string
                    searchResult = test.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1;
            }

            return searchResult;
        }

        public DomainListViewColumnCollection Columns
        {
            get
            {
                DomainListViewColumn colName = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                   {
                                                       Name = "Name",
                                                       Text = RendererStringResources.Name
                                                   };

                DomainListViewColumn colStartDate = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                            {
                                                                Name = "StartDate",
                                                                Text = RendererStringResources.StartDate
                                                            };

                DomainListViewColumn colStartTime = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                            {
                                                                Name = "StartTime",
                                                                Text = RendererStringResources.StartTime
                                                            };

                DomainListViewColumn colFloc = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                   {
                                                       Name = "FunctionalLocationName",
                                                       Text = RendererStringResources.Floc
                                                   };

                DomainListViewColumn colTag = new DomainListViewColumn.ResizeToHeaderSizeColumn
                                                  {
                                                      Name = "TagName",
                                                      Text = RendererStringResources.PHTag
                                                  };

                return new DomainListViewColumnCollection
                                                        (
                                                            colName,
                                                            colStartDate,
                                                            colStartTime,
                                                            colFloc,
                                                            colTag
                                                        );
            }
        }
    }
}
