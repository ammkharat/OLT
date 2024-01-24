using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client
{
    public class CustomFieldTagValueReader
    {
        private readonly ClientBackgroundWorker backgroundWorker;
        private readonly IPlantHistorianService plantHistorianService;
        private readonly Action disableControls;
        private readonly Action enableControls;
        private readonly Action<Dictionary<long, object>> onComplete;

        public CustomFieldTagValueReader(ClientBackgroundWorker backgroundWorker, IPlantHistorianService plantHistorianService, Action disableControls, Action enableControls,
            Action<Dictionary<long, object>> onComplete)
        {
            this.backgroundWorker = backgroundWorker;
            this.plantHistorianService = plantHistorianService;
            this.disableControls = disableControls;
            this.enableControls = enableControls;
            this.onComplete = onComplete;

            backgroundWorker.DoWork += ReadTagInfoValues;
            backgroundWorker.RunWorkerCompleted += DoneReadingTagInfoValues;
        }

        public void Run(List<TagInfo> tagInfos)
        {
            if (backgroundWorker.IsBusy)
            {
                throw new Exception("The CustomFieldTagValueReader is already running.");
            }

            if (disableControls != null)
            {
                disableControls();
            }

            backgroundWorker.RunWorkerAsync(tagInfos);
        }

        private void DoneReadingTagInfoValues(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            if (enableControls != null)
            {
                enableControls();
            }

            if (e.Error != null)
            {
                throw e.Error;
            }

            if (onComplete != null)
            {
                Dictionary<long, object> results = (Dictionary<long, object>)e.Result;
                onComplete(results);
            }
        }

     //Updated by Mukesh :-RITM0238302
        private void ReadTagInfoValues(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            Dictionary<long, object> results = new Dictionary<long, object>();

            List<TagInfo> tagInfos = (List<TagInfo>)doWorkEventArgs.Argument;
            foreach (TagInfo tagInfo in tagInfos)
            {
                
                if (tagInfo != null && !results.ContainsKey(tagInfo.IdValue))
                {
                    results.Add(tagInfo.IdValue, ReadAlphaNumericTagInfoValue(tagInfo));
                   
                }
            }

            doWorkEventArgs.Result = results;

            BackgroundWorker bgWorker = (BackgroundWorker)sender;
            if (bgWorker.CancellationPending)
            {
                doWorkEventArgs.Cancel = true;
            }
        }
        //private void ReadTagInfoValues(object sender, DoWorkEventArgs doWorkEventArgs)
        //{
        //    Dictionary<long, decimal?> results = new Dictionary<long, decimal?>();

        //    List<TagInfo> tagInfos = (List<TagInfo>)doWorkEventArgs.Argument;
        //    foreach (TagInfo tagInfo in tagInfos)
        //    {
        //        if (tagInfo != null && !results.ContainsKey(tagInfo.IdValue))
        //        {
        //            results.Add(tagInfo.IdValue, ReadTagInfoValue(tagInfo));
        //        }
        //    }

        //    doWorkEventArgs.Result = results;

        //    BackgroundWorker bgWorker = (BackgroundWorker)sender;
        //    if (bgWorker.CancellationPending)
        //    {
        //        doWorkEventArgs.Cancel = true;
        //    }
        //}

        private decimal? ReadTagInfoValue(TagInfo tagInfo)
        {
            decimal? value = null;

            try
            {
                string str = plantHistorianService.TagType(tagInfo);    
    
                if (tagInfo != null && plantHistorianService.CanReadTagValue(tagInfo))
                {
                    value = GetTagValueFromPlantHistorian(new ReadWriteTagConfiguration(TagDirection.Read, tagInfo));
                }
            }
            catch (Exception)
            {
                value = null;
            }

            return value;
        }

        private decimal? GetTagValueFromPlantHistorian(ReadWriteTagConfiguration config)
        {
            if (config.IsReadDirection())
            {
                return plantHistorianService.ReadTagValues(PlantHistorianOrigin.CustomFieldTagValueReader_GetTagValueFromPlantHistorian, config.Tag)[0];
            }
            return new decimal?();
        }

        #region //Added by Mukesh :-RITM0238302
        private object ReadAlphaNumericTagInfoValue(TagInfo tagInfo)
        {
            Object value = null;

            try
            {
               

                if (tagInfo != null && plantHistorianService.CanReadTagValue(tagInfo))
                {
                    value = GetTagValueFromPlantHistorianForAlphanumeric(new ReadWriteTagConfiguration(TagDirection.Read, tagInfo));
                }
            }
            catch (Exception)
            {
                value = null;
            }

            return value;
        }
        private Object GetTagValueFromPlantHistorianForAlphanumeric(ReadWriteTagConfiguration config)
        {
            if (config.IsReadDirection())
            {
                return plantHistorianService.ReadAlphaNumericTagValues(PlantHistorianOrigin.CustomFieldTagValueReader_GetTagValueFromPlantHistorian, config.Tag)[0];
            }
            return null;
        }
       

# endregion


    }
}