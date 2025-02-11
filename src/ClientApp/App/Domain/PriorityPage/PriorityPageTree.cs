﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls.Expressions;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraCharts;
using DevExpress.XtraRichEdit.Import.OpenDocument;

namespace Com.Suncor.Olt.Client.Domain.PriorityPage
{
    public class PriorityPageTree
    {
        private readonly object lockObject = new object();

        private long nodeSequence;

        private readonly BindingList<PriorityPageNode> nodes = new BindingList<PriorityPageNode>();

        private long GetNewId()
        {
            return nodeSequence++;
        }

        public BindingList<PriorityPageNode> Nodes
        {
            get { return nodes; }
        }

        public object LockObject
        {
            get { return lockObject; }
        }

        public PriorityPageSectionNode CreateSectionNode(string groupName, PriorityPageSectionKey priorityPageSectionKey, PriorityPageSectionConfiguration sectionConfiguration)
        {
            PriorityPageSectionNode node = new PriorityPageSectionNode(this, GetNewId(), groupName, priorityPageSectionKey, sectionConfiguration);
            nodes.Add(node);
            return node;
        }

        public PriorityPageSubSectionNode CreateSubSectionNode(PriorityPageSectionNode parentNode, string groupName)
        {
            PriorityPageSubSectionNode node = new PriorityPageSubSectionNode(this, GetNewId(), parentNode, groupName);
            nodes.Add(node);
            return node;
        }

        public PriorityPageDataNode CreateDataNode(PriorityPageGroupNode parentNode, NodeData nodeData)
        {

            if (nodeData is FormSarniaNodeData && nodeData.StatusToolTip.DoesNotEqual("Waiting For Approval") )              //ayman Sarnia eip DMND0008992
                return null;

            
            // If condition Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            //if (nodeData.Text.Equals(string.Empty))
            //{
            //    //RITM0465936:Removing  CSD records fron EIP Form Section
            //    if (parentNode.GroupName.Contains("Forms Waiting For Approval") && nodeData.Text.Contains("Critical System Defeat"))
            //        return null;
            //}
            //else
            //{
            //    if (parentNode.GroupName.Contains("Forms Waiting For Approval") && ((Com.Suncor.Olt.Client.Domain.PriorityPage.FormNodeData)(nodeData)).FormType.Name.Contains("Critical System Defeat"))
            //        return null;
            //}

            //mangesh - commented above snippet and added new
            if (nodeData is FormNodeData && parentNode.GroupName.Contains("Forms Waiting For Approval"))
            {
                if (nodeData.Text.Contains("Critical System Defeat") || nodeData.OptionalText.Contains("Critical System Defeat"))
                {
                    return null;
                }
            }


            if (nodeData is DirectiveLogNodeData) //ayman temp merge
            {
                //Updated by Mukesh to fix issue.
                PriorityPageNode pnode =
                    nodes.Find(
                        nod =>
                            nod.GroupName.Trim() == Com.Suncor.Olt.Common.Localization.StringResources.ActiveDirectives);
                PriorityPageDataNode node = new PriorityPageDataNode(GetNewId(), pnode, nodeData);
                Nodes.Add(node);
                return node;
            }
            else
            {
                PriorityPageDataNode node = new PriorityPageDataNode(GetNewId(), parentNode, nodeData);
                nodes.Add(node);
                return node;
            }
        }

        public void RemoveDataNode(PriorityPageDataNode node)
        {
            nodes.Remove(node);
        }
    }
}
