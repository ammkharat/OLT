using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class DocumentSuggestionFormStatusImageColumn :
        AbstractImageGridColumn<DocumentSuggestionDTO, FormStatus, FormStatus, string>
    {
        private const string COLUMN_KEY = "StatusImage";
        private const int WIDTH = 50;

        protected readonly Dictionary<string, FormStatus> nameToEntityMap = new Dictionary<string, FormStatus>();

        public DocumentSuggestionFormStatusImageColumn()
            : base(
                GetStatus,
                GetStatus,
                obj => GetStatus(obj).Name,
                GetImageMapItems())
        {
            nameToEntityMap.Add(FormStatus.Draft.Name, FormStatus.Draft);
            nameToEntityMap.Add(FormStatus.InitialReview.Name, FormStatus.InitialReview);
            nameToEntityMap.Add(FormStatus.OwnerReview.Name, FormStatus.OwnerReview);
            nameToEntityMap.Add(FormStatus.RevisionInProgress.Name, FormStatus.RevisionInProgress);
            nameToEntityMap.Add(FormStatus.DocumentIssued.Name, FormStatus.DocumentIssued);
            nameToEntityMap.Add(FormStatus.DocumentArchived.Name, FormStatus.DocumentArchived);
            nameToEntityMap.Add(FormStatus.NotApproved.Name, FormStatus.NotApproved);
            nameToEntityMap.Add(FormStatus.Late.Name, FormStatus.Late);
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

        private static FormStatus GetStatus(DocumentSuggestionDTO dto)
        {
            return dto.GetStatusForDisplay();
        }

        public static List<IImageMapItem<FormStatus>> GetImageMapItems()
        {
            return new List<IImageMapItem<FormStatus>>
            {
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Draft, ResourceUtils.DRAFT),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.InitialReview,
                    ResourceUtils.FOR_REVIEW),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.OwnerReview, ResourceUtils.PENDING),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.RevisionInProgress,
                    ResourceUtils.APPROVED),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.DocumentIssued,
                    ResourceUtils.COMPLETED_PERMIT),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.DocumentArchived,
                    ResourceUtils.ARCHIVED),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.NotApproved, ResourceUtils.REJECTED),
                new SortableSimpleDomainObjectImageMapItem<FormStatus>(FormStatus.Late, ResourceUtils.LATE)
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