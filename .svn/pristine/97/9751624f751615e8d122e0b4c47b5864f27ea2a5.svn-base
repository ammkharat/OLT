using System.Collections.Generic;

namespace Com.Suncor.Olt.Client.Domain
{
    public class VisibilityGroupLoginDisplayAdapter
    {
        public static string NAME_PROPERTY = "Name";
        public string Name { get; private set; }

        public static string READ_PROPERTY = "Read";
        public bool Read { get; set; }

        public bool Write { get; private set; }

        public long VisibilityGroupId { get; private set; }
        
        public VisibilityGroupLoginDisplayAdapter(long visibilityGroupId, string name, bool read, bool write)
        {
            Name = name;
            Read = read;
            Write = write;
            VisibilityGroupId = visibilityGroupId;
        }

        public static bool ListHasAtLeastOneMatchingReadAndWrite(List<VisibilityGroupLoginDisplayAdapter> adapters)
        {
            return adapters.Exists(adapter => adapter.Read && adapter.Write);
        }
    }
}
