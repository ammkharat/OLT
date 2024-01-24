using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ProcedureDeviationFormStatusImageColumn :
        AbstractImageGridColumn<ProcedureDeviationDTO, FormStatus, FormStatus, string>
    {
        private const string COLUMN_KEY = "StatusImage";
        private const int WIDTH = 50;

        protected readonly Dictionary<string, FormStatus> nameToEntityMap = new Dictionary<string, FormStatus>();

        public ProcedureDeviationFormStatusImageColumn()
            : base(
                GetStatus,
                GetStatus,
                obj => GetStatus(obj).Name,
                GetImageMapItems())
        {
            nameToEntityMap.Add(FormStatus.Draft.Name, FormStatus.Draft);
            nameToEntityMap.Add(FormStatus.RevisionInProgress.Name, FormStatus.RevisionInProgress);
            nameToEntityMap.Add(FormStatus.Approved.Name, FormStatus.Approved);
            nameToEntityMap.Add(FormStatus.Complete.Name, FormStatus.Complete);
            nameToEntityMap.Add(FormStatus.Cancelled.Name, FormStatus.Cancelled);
            nameToEntityMap.Add(FormStatus.ExtensionReview.Name, FormStatus.ExtensionReview);
            nameToEntityMap.Add(FormStatus.Expired.Name, FormStatus.Expired);
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.State; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }

        private static FormStatus GetStatus(ProcedureDeviationDTO dto)
        {
            return dto.GetStatusForDisplay();
        }

        public static List<IImageMapItem<FormStatus>> GetImageMapItems()
        {
            return new List<IImageMapItem<FormStatus>>
            {
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Draft, ResourceUtils.DRAFT),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.RevisionInProgress,
                    ResourceUtils.APPROVED),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Approved,
                    ResourceUtils.PENDING),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Complete,
                    ResourceUtils.COMPLETED_PERMIT),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Cancelled, ResourceUtils.VOID),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.ExtensionReview, ResourceUtils.LATE),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Expired, ResourceUtils.EXPIRED)
            };
        }

        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems,
            FormStatus key)
        {
            var valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName,
                imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<FormStatus>(nameToEntityMap, imageMap);
        }
    }
}