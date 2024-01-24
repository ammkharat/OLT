using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
   public class formPatternFormatter
    {
        private readonly FormGN75BTemplatePattern formgn75btemplatePattern;

        public formPatternFormatter(FormGN75BTemplatePattern formGn75BTemplatePattern)
        {
            this.formgn75btemplatePattern = formGn75BTemplatePattern;
        }

        public string Format()
        {
            return formgn75btemplatePattern.Id + ": " + formgn75btemplatePattern.FunctionalLocation + " - " + formgn75btemplatePattern.Location;
        }
    }
}
