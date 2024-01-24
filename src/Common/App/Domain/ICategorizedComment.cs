using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    public interface ICategorizedComment
    {
        string CommentCategoryName { get; }
        string Text { get; }
    }

    public static class CategorizedCommentExtensions
    {
        public static bool HasText(this ICategorizedComment categorizedComment)
        {
            return !categorizedComment.Text.IsNullOrEmptyOrWhitespace();
        }
    }
}