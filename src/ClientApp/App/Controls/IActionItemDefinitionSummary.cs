using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface IActionItemDefinitionSummary
    {
        string Name { set;}
        BusinessCategory Category { set; }
        string Author { set;}
        List<FunctionalLocation> FunctionalLocations { set;}
        string Description { set;}
        event EventHandler Load;
    }
}
