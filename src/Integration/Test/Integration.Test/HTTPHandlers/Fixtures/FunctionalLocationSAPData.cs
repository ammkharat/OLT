using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures
{
    public class FunctionalLocationSAPData
    {
        private readonly string FlocMessageTemplate = "<?xml version=\"1.0\"?>" + Environment.NewLine + "" +
                                                      "<FLOCOLTData>" + Environment.NewLine + "" +
                                                      "   <FLOCRecord>" + Environment.NewLine + "" +
                                                      "       <Header></Header>" + Environment.NewLine + "" +
                                                      "       <FLOCDetails>" + Environment.NewLine + "" +
                                                      "           <PlantID>{0}</PlantID>" + Environment.NewLine + "" +
                                                      "           <FLOCID>{1}</FLOCID>" + Environment.NewLine + "" +
                                                      "           <SuperiorFLOCID>{2}</SuperiorFLOCID>" +
                                                      Environment.NewLine + "" +
                                                      "           <Description>{3}</Description>" + Environment.NewLine +
                                                      "" +
                                                      "           <Action>{4}</Action>" + Environment.NewLine + "" +
                                                      "       </FLOCDetails>" + Environment.NewLine + "" +
                                                      "   </FLOCRecord>" + Environment.NewLine + "" +
                                                      "</FLOCOLTData>" + Environment.NewLine + "";

        public string Action;
        public string Description;

        public string FlocId;
        public string PlantID;
        public string SuperiorFlocId;

        public FunctionalLocationSAPData(string plantID, string flocId, string superiorFlocId, string description,
            string action)
        {
            PlantID = plantID;
            Description = description;
            Action = action;
            FlocId = flocId;
            SuperiorFlocId = superiorFlocId;
        }

        public string CreateMessage()
        {
            var msg = string.Format(FlocMessageTemplate, PlantID,
                FlocId,
                SuperiorFlocId,
                Description,
                Action);
            return msg;
        }

        public void ReplacePart(string replacementValue, int levelToReplaceAt)
        {
            var functionalLocationHierarchy = new FunctionalLocationHierarchy(FlocId);


            if (functionalLocationHierarchy.Level >= levelToReplaceAt)
            {
                FlocId = functionalLocationHierarchy.ReplaceSegment(levelToReplaceAt, replacementValue).ToString();
            }
            else if (functionalLocationHierarchy.Level.IsOneLessThan(levelToReplaceAt))
            {
                FlocId = functionalLocationHierarchy.AppendSegment(replacementValue).ToString();
            }
            else
                throw new OLTException("Cannot append or replace to a Functional Location that has less parts.");
        }
    }
}