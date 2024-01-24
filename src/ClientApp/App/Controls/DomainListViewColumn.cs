using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public abstract class DomainListViewColumn
    {
        private string name;
        private string text;

        protected DomainListViewColumn() { }

        protected DomainListViewColumn(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Text 
        { 
            get { return text; }
            set { text = value; }
        }

        public ColumnHeader ToColumnHeader()
        {
            var columnHeader = new ColumnHeader {Name = name, Text = text};
            SetColumnHeaderWidth(columnHeader);
            return columnHeader;
        }

        public abstract void SetColumnHeaderWidth(ColumnHeader columnHeader);

        public class ResizeToHeaderSizeColumn : DomainListViewColumn
        {
            public ResizeToHeaderSizeColumn() { }
            public ResizeToHeaderSizeColumn(string name, string text) : base(name, text) { }

            public override void SetColumnHeaderWidth(ColumnHeader columnHeader)
            {
                columnHeader.Width = -2;
            }
        }

        public class ManualColumn : DomainListViewColumn
        {
            private int width;

            public ManualColumn() { }
            public ManualColumn(string name, string text, int width)
                : base(name, text)
            {
                this.width = width;
            }

            public int Width 
            { 
                get { return width; }
                set { width = value; }
            }

            public override void SetColumnHeaderWidth(ColumnHeader columnHeader)
            {
                columnHeader.Width = width;
            }
        }
    }
}
