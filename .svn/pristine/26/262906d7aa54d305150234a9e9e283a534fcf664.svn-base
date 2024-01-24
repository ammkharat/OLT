using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public class DomainListViewColumnCollection
    {
        private readonly Dictionary<string, DomainListViewColumn> columns = new Dictionary<string, DomainListViewColumn>();

        public DomainListViewColumnCollection(params DomainListViewColumn[] columns)
        {
            Array.ForEach(columns, Add);
        }

        public void Add(DomainListViewColumn column)
        {
            columns[column.Name] = column;
        }

        public int Count
        {
            get { return columns.Count; }
        }

        public DomainListViewColumn[] ToDomainListViewColumns()
        {
            var domainColumns = new DomainListViewColumn[columns.Count];
            columns.Values.CopyTo(domainColumns, 0);
            return domainColumns;
        }

        public ColumnHeader[] ToColumnHeaders()
        {
            DomainListViewColumn[] domainColumns = ToDomainListViewColumns();

            return Array.ConvertAll(domainColumns,
                                    domainListViewColumn => domainListViewColumn.ToColumnHeader()
                );
        }

        public void SetColumnHeaderWidths(IList columnHeaders)
        {
            foreach (ColumnHeader columnHeader in columnHeaders)
            {
                columns[columnHeader.Name].SetColumnHeaderWidth(columnHeader);
            }
        }

        public void ForEach(Action<DomainListViewColumn> action)
        {
            new List<DomainListViewColumn>(columns.Values).ForEach(action);
        }
    }
}
