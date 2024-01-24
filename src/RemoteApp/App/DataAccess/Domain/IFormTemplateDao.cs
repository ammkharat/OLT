using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormTemplateDao : IDao
    {
        List<FormTemplate> QueryAll(long siteId);

     
        List<FormTemplate> QueryByFormType(EdmontonFormType formType,long siteid);    //ayman generic forms
        FormTemplate QueryByFormTypeAndKey(EdmontonFormType formType, string key);
        void Replace(FormTemplate formTemplate, User user, DateTime now, long siteId);
        FormTemplate QueryById(long id);        
    }
}
