﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFormGN75BDao : IDao
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(FormGN75B form);


        //ayman Sarnia eip DMND0008992
        [CachedInsertOrUpdate(false, false)]
        void InsertTemplate(FormGN75B form);

        [CachedInsertOrUpdate(false, false)]
        void InsertFormGN75BSarnia(FormGN75B form);

        //ayman generic forms
        [CachedQueryByIdAndSiteId]
        FormGN75B QueryByIdAndSiteId(long id,long siteid);

        //ayman Sarnia eip DMND0008992
        [CachedQuerySarniaFormByIdAndSiteId]
        FormGN75B QuerySarniaFormByIdAndSiteId(long id, long siteid);

        //ayman Sarnia eip DMND0008992
        [CachedQueryTemplateByIdAndSiteId]
        FormGN75B QueryTemplateByIdAndSiteId(long id, long siteid);
        
        [CachedQueryById]
        FormGN75B QueryById(long id);

        [CachedQueryGN75BSarniaById]
        FormGN75B QueryGN75BSarniaById(long id);

        [CachedInsertOrUpdate(false, false)]
        void Update(FormGN75B form);


        //ayman Sarnia eip DMND0008992
        [CachedInsertOrUpdate(false, false)]
        void UpdateSarnia(FormGN75B form,string formType);


        [CachedRemove(false, false)]
        void Remove(FormGN75B form);

        [CachedRemove(false, false)]
        void RemoveSarniaEip(FormGN75B form);   //ayman Sarnia eip - 3

        //ayman Sarnia eip - 3
        [CachedRemove(false, false)]
        void RemoveTemplate(FormGN75B form);


        List<long> QueryGn75AFormsAssociatedToFormGn75BById(long gn75BFormId);

        bool HasUserReadAtLeastOneDocumentLink(long userId, long formGN75BId);
        void InsertUserReadDocumentLinkAssociation(long userId, long formGN75BId);
        bool HasUserReadAtLeastOneDocumentLinkSarnia(long userId, long formGN75BSarniaId);//INC0453097 Aarti
        void InsertUserReadDocumentLinkAssociationSarnia(long userId, long formGN75BSarniaId);//INC0453097 Aarti
        bool HasUserReadAtLeastOneDocumentLinkTemplateSarnia(long userId, long formGN75BTemplateId);//INC0453097 Aarti (OLT::EIP template Sarnia:: attachment crash)
        void InsertUserReadDocumentLinkAssociationTemplateSarnia(long userId, long formGN75BTemplateId);////INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
    }

    // Internal because it's only called from FormGN75BDao.  So, no caching is needed for this since caching is at the FormGN75BDao.
    public interface IFormGN75BIsolationDao : IDao
    {
        List<IsolationItem> QueryByFormGN75BId(long id);
        List<IsolationItem> QueryByFormGN75BTemplateId(long id);                //ayman Sarnia eip - 3
        void Insert(IsolationItem item);
        void InsertForTemplate(IsolationItem item);            //ayman Sarnia eip - 3
        void RemoveAllThatAreNotInThisList(long gn75BId, List<IsolationItem> items);
        void RemoveAllThatAreNotInThisListTemplate(long gn75BTemplateId, List<IsolationItem> items); //Aarti INC0548411 
        void Update(IsolationItem item);
        void UpdateForTemplate(IsolationItem item);                  //ayman Sarnai eip - 3
    }

    //ayman Sarnia eip DMND0008992
    public interface IFormGN75BDevicePositionDao : IDao
    {
        List<DevicePosition> QueryByFormGN75BId(long id);
        List<DevicePosition> QueryByFormGN75BSarniaId(long id);
        void Insert(DevicePosition item);
        void RemoveAllThatAreNotInThisList(long gn75BId, List<DevicePosition> items);
        void Update(DevicePosition item);
    }

}
