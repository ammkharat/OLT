using System;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class ReadWriteTagConfiguration : ComparableObject
    {
        private TagDirection direction;
        private TagInfo tag;

        public ReadWriteTagConfiguration(TagDirection direction, TagInfo tag)
        {
            this.direction = direction;
            this.tag = tag;
        }

        public TagDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public TagInfo Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public static ReadWriteTagConfiguration CreateEmpty()
        {
            return new ReadWriteTagConfiguration(TagDirection.None, TagInfo.CreateEmpty());
        }

        public bool IsReadDirection()
        {
            return Is(TagDirection.Read);
        }

        public bool IsWriteDirection()
        {
            return Is(TagDirection.Write);
        }

        public bool IsTagInValid()
        {
            return IsNot(TagDirection.None) && tag.Equals(TagInfo.CreateEmpty());
        }

        public bool IsDirectionInValid()
        {
            return Is(TagDirection.None) && !tag.Equals(TagInfo.CreateEmpty());
        }

        public bool IsWriteDirectionAndSameTagAs(ReadWriteTagConfiguration config)
        {
            if (IsWriteDirection() && config.IsWriteDirection())
            {
                if (tag.Equals(config.Tag))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasTag()
        {
            return !tag.Equals(TagInfo.CreateEmpty());
        }

        private bool Is(TagDirection tagDirection)
        {
            return direction == tagDirection;
        }

        private bool IsNot(TagDirection tagDirection)
        {
            return !Is(tagDirection);
        }
    }
}