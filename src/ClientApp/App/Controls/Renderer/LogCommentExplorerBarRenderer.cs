using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Infragistics.Win.UltraWinExplorerBar;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{   
    public class LogCommentExplorerBarRenderer : BaseExplorerBarRenderer
    {                            
        public LogCommentExplorerBarRenderer(Form form, OltExplorerBar explorerBar, int defaultHeight) 
            : base(form, explorerBar, defaultHeight, true)
        {           
        }
                                                
        public override void Dispose()
        {
            ;
        }

        protected override object GetResizableGroupType()
        {
            throw new InvalidOperationException("");
        }
        
        protected override List<UltraExplorerBarGroup> GetResizableGroups()
        {
            UltraExplorerBarGroupsCollection groups = explorerBar.Groups;
            List<UltraExplorerBarGroup> resultList = new List<UltraExplorerBarGroup>();

            foreach (UltraExplorerBarGroup group in groups)
            {
                if (group.Key != null && group.Key.StartsWith("Comments"))
                {
                    resultList.Add(group);
                }                
            }

            return resultList;
        }
    }
}
