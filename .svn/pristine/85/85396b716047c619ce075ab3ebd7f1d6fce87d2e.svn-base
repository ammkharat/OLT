using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ThreadedItemPresenterHelper
    {
        public static void RefreshThreadedView(IThreadedItemsPage page, ILog logger)
        {
            if (page.ShowLogThread)
            {
                IThreadableDTO root = GetRootLog(page);
                if (root != null)
                {
                    List<IThreadableDTO> children = FindChildrenInLogList(root.Id, page);
                    page.ThreadedItemDetails.LoadLogThreadTree(root, children);
                }
                else
                {
                    logger.Warn("Unable to find a root log for the thread display. The log thread data is likely corrupted.");
                }
            }
        }

        private static IThreadableDTO GetRootLog(IThreadedItemsPage page)
        {
            IThreadableDTO firstSelectedItem = page.FirstSelectedThreadableItem;
            if (firstSelectedItem != null)
            {
                long? rootLogId = firstSelectedItem.RootLogId;
                //rootlogid of null implies it is the root (or alternatively not a child)
                if (rootLogId == null)
                {
                    return firstSelectedItem;
                }
                return page.ThreadableItems.FindById(rootLogId.Value);
            }
            return null;
        }

        private static List<IThreadableDTO> FindChildrenInLogList(long? rootId, IThreadedItemsPage page)
        {
            var children = new List<IThreadableDTO>();
            if (rootId == null)
            {
                return children;
            }
            foreach (IThreadableDTO currentDto in page.ThreadableItems)
            {
                if (currentDto.RootLogId == rootId)
                {
                    children.Add(currentDto);
                }
            }
            return children;
        }
    }
}
