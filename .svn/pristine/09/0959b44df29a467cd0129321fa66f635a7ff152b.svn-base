using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using log4net;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class LogDetailThreadTreeView : OltTreeView
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LogDetailThreadTreeView));

        private IThreadableDTO rootLogDto;
        private List<IThreadableDTO> children;

        public LogDetailThreadTreeView()
        {
            InitializeComponent();
        }

        public LogDetailThreadTreeView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public IThreadableDTO SelectedLogDTO
        {
            get
            {
                if(SelectedNode == null)
                {
                    return null;
                }
                long id = Convert.ToInt64(SelectedNode.Name);
                IThreadableDTO selectedDto = rootLogDto.Id == id ? rootLogDto : children.FindById(id);
                return selectedDto;
            }
            set
            {
                if(value == null)
                {
                    return;
                }
                TreeNode[] result = Nodes.Find(Convert.ToString(value.Id), true);
                if(result.Length != 0)
                {
                    SelectedNode = result[0];
                }
                else if(result.Length > 0)
                {
                    logger.Error("There is an issue setting the selected log in the thread view. There is more than one matching log in the tree");
                }
                else
                {
                    logger.Error("There is an issue setting the selected log in the thread view. There are no matching logs in the tree");
                }
            }
        }

        public void LoadLogDetailTree(IThreadableDTO root, List<IThreadableDTO> childList)
        {
            rootLogDto = root;
            children = childList;
            children.Sort();
            Nodes.Clear();
            Nodes.Add(rootLogDto.Id.ToString(), rootLogDto.ToDisplayString());
            foreach(IThreadableDTO child in children)
            {
                if(child.Id == rootLogDto.Id)
                {
                    continue;
                }
                TreeNode[] nodes = Nodes.Find(child.ReplyToLogId.ToString(), true);
                if(nodes.Length == 1)
                {
                    nodes[0].Nodes.Add(child.Id.ToString(), child.ToDisplayString());
                }
                else
                {
                    logger.Error("There is a problem with the Log Thread Tree: more than one log was found with the same ID");
                }
            }
        }

    }
}