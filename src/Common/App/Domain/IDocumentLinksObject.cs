using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     An object that can have document links.
    /// </summary>
    public interface IDocumentLinksObject
    {
        List<DocumentLink> DocumentLinks { get; }
        long IdValue { get; }
    }
}