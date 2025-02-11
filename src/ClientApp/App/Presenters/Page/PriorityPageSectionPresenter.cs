﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using System.Diagnostics;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
     
    public abstract class PriorityPageSectionPresenter<TDto, TDomain>
        where TDto :DomainObject
        where TDomain : DomainObject
    {
        protected readonly IPage invokeControl;
        private readonly PriorityPageTree tree;
        protected readonly UserContext userContext;
        private readonly IRemoteEventRepeater remoteEventRepeater;
        private readonly PriorityPageSectionConfiguration sectionConfiguration;

        private PriorityPageSectionNode sectionNode;
        private PriorityPageSubSectionNode catchAllSubSectionNode;
        private readonly List<CriteriaBasedSubSectionNode> criteriaBasedSubSectionNodes = new List<CriteriaBasedSubSectionNode>();

        private int soundcount;
        Stopwatch stopwatch = new Stopwatch();
        
        protected PriorityPageSectionPresenter(
            IPage invokeControl, 
            PriorityPageTree tree, 
            UserContext userContext, 
            IRemoteEventRepeater remoteEventRepeater,
            PriorityPageSectionConfiguration sectionConfiguration)
        {
            this.invokeControl = invokeControl;
            this.tree = tree;
            this.userContext = userContext;
            this.remoteEventRepeater = remoteEventRepeater;
            this.sectionConfiguration = sectionConfiguration;

            invokeControl.Disposed += InvokeControl_Disposed;
        }

        private void InvokeControl_Disposed(object sender, EventArgs e)
        {
            UnsubscribeToEvents(remoteEventRepeater);
            invokeControl.Disposed -= InvokeControl_Disposed;
        }

        protected abstract void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater);

        protected void AddSectionNode(PriorityPageSectionKey priorityPageSectionKey)
        {
            sectionNode = tree.CreateSectionNode(priorityPageSectionKey.SectionName, priorityPageSectionKey, sectionConfiguration);            
        }

        protected void AddCatchAllSubSectionNode(string name)
        {
            catchAllSubSectionNode = sectionNode.AddSubSection(name);
        }

        protected void AddCriteriaBasedSubSectionNode(string name, ISubSectionCriteria criteria)
        {   
            PriorityPageSubSectionNode subSectionNode = sectionNode.AddSubSection(name);
            CriteriaBasedSubSectionNode criteriaBasedSubSectionNode = new CriteriaBasedSubSectionNode(subSectionNode, criteria);
            criteriaBasedSubSectionNodes.Add(criteriaBasedSubSectionNode);
        }

        protected void Load(List<TDto> dtos)
        {
            foreach (TDto dto in dtos)
            {

                PriorityPageSubSectionNode subSectionNode = GetSubSectionNode(dto);
                if (subSectionNode != null)
                {
                    subSectionNode.Add(GetNodeData(dto));
                }
            }
        }

        protected void ClearAllDataNodes()
        {
            if (catchAllSubSectionNode != null)
            {
                catchAllSubSectionNode.ClearAllDataNodes();
            }
            foreach (CriteriaBasedSubSectionNode subSectionNode in criteriaBasedSubSectionNodes)
            {
                subSectionNode.Node.ClearAllDataNodes();
            }
        }

        protected abstract bool IsRelevantItemFromServerEvent(TDomain item);
        protected abstract TDto GetDto(TDomain item,string ForAddUpdate);         //ayman action item reading
        protected abstract NodeData GetNodeData(TDto dto);

        protected void Repeater_Created(object sender, DomainEventArgs<TDomain> e) //Sound Alert
        {
            if (invokeControl.IsOnNonUiThread())
            {
                if (soundcount == 1)
                { stopwatch.Start(); }
                if (stopwatch.Elapsed.Milliseconds > 5000)
                {
                    stopwatch.Stop();
                    soundcount = 0;
                }
                 bool sound = ClientSession.GetUserContext().User.WorkPermitPrintPreference.SoundAlertEnable;
                 if (sound && (ClientSession.GetUserContext().SiteConfiguration.SoundAlertforActionItemDirectiveEventsTargets) && (stopwatch.Elapsed.Milliseconds >= 5000 || soundcount == 0))
                {
                    if (e.SelectedItem.GetType().Name == ("ActionItem") || e.SelectedItem.GetType().Name == ("Directive") || e.SelectedItem.GetType().Name == ("TargetAlert"))
                    {
                        soundcount += 1;
                         using (var soundPlayer = new System.Media.SoundPlayer(Properties.Resources.SoundAlert))
                         {
                             soundPlayer.PlaySync(); // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                         }
                     }
                }
                invokeControl.Invoke(new Action<DomainEventArgs<TDomain>>(Repeater_Created), e);
            }
            else
            {
                //bool sound = ClientSession.GetUserContext().User.WorkPermitPrintPreference.SoundAlertEnable;
                //if (sound && (ClientSession.GetUserContext().SiteConfiguration.SoundAlertforActionItemDirectiveEventsTargets))
                //{
                //     if (e.SelectedItem.GetType().Name == ("ActionItem") || e.SelectedItem.GetType().Name == ("Log") || e.SelectedItem.GetType().Name == ("TargetAlert")) ;
                //    //using (var soundPlayer = new System.Media.SoundPlayer(Properties.Resources.SoundAlert))
                //    //{
                //    //    soundPlayer.PlaySync(); // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                //    //}
                //}
                Repeater_Created(e);
            }
        }

        protected virtual void Repeater_Created(DomainEventArgs<TDomain> e)
        {
            if (IsRelevantEvent(e) && invokeControl.IsNotDisposed())
            {
                Add(GetDto(e.SelectedItem,"Add"));
            }            
        }


        protected void Repeater_Updated(object sender, DomainEventArgs<TDomain> e)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<DomainEventArgs<TDomain>>(Repeater_Updated), e);
            }
            else
            {
                Repeater_Updated(e);
            }
        }


        //ayman Sarnia eip DMND0008992 - 2
        protected void Repeater_UpdatedForEipTemplate(FormEdmontonGN75BDTO e)
        {
            if (invokeControl.IsNotDisposed())
            {
                UpdateEipTemplate(e);
            }
            else if (invokeControl.IsNotDisposed())
            {
                RemoveEipTemplate(e);
            }
        }




        //ayman Sarnia eip DMND0008992
        protected void Repeater_UpdatedForEipIssue(FormEdmontonGN75BDTO e)
        {
            if (invokeControl.IsNotDisposed())
            {
                UpdateEipIssue(e);
            }
            else if (invokeControl.IsNotDisposed())
            {
                RemoveEipIssue(e);
            }
        }

        //RITM0341710 mangesh
        protected void Repeater_UpdatedForGT(FormGenericTemplateDTO e)
        {
            if (invokeControl.IsNotDisposed())
            {
                UpdateFortHillGT(e);
            }
            else if (invokeControl.IsNotDisposed())
            {
                RemoveFortHillGT(e);
            }
        }
        //RITM0341710 - mangesh
        private PriorityPageSubSectionNode GetSubSectionNodeBasedOnDtoIdForFortHillGT(FormGenericTemplateDTO dto)
        {
            if (criteriaBasedSubSectionNodes.Count == 0 || dto == null)
            {
                return catchAllSubSectionNode;
            }

            foreach (CriteriaBasedSubSectionNode potential in criteriaBasedSubSectionNodes)
            {
                PriorityPageDataNode priorityPageDataNode = potential.Node.Find(dto.IdValue);
                if (priorityPageDataNode != null)
                {
                    return potential.Node;
                }
            }
            return catchAllSubSectionNode;
        }
        //RITM0341710 - mangesh
        protected void AddFortHillGT(FormGenericTemplateDTO dto)
        {
            NodeData nodeData = GetNodeDataForFortHillGT(dto);
            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForFortHillGT(dto);
            if (subSectionNode != null)
            {
                subSectionNode.Add(nodeData);
            }
        }
        //RITM0341710 - mangesh
        private void UpdateFortHillGT(FormGenericTemplateDTO dto)
        {
            NodeData nodeData = GetNodeDataForFortHillGT(dto);
            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForFortHillGT(dto);
            if (subSectionNode != null)
            {
                subSectionNode.Update(nodeData);
                RemoveFromOtherNodes(subSectionNode, nodeData);
            }
        }
        //RITM0341710 - mangesh
        protected virtual void RemoveFortHillGT(FormGenericTemplateDTO dto)
        {
            NodeData nodeData = GetNodeDataForFortHillGT(dto);

            // we must find the node based on which one contains the dto and not by criteria, because the criteria may have changed (e.g. update dates of dto)
            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForFortHillGT(dto);

            if (subSectionNode != null)
            {
                subSectionNode.Remove(nodeData);
            }
        }
        //RITM0341710 - mangesh
        protected NodeData GetNodeDataForFortHillGT(FormGenericTemplateDTO dto)
        {
            return new FormNodeData(dto);
        }
        
        //ayman Sarnia eip DMND0008992
        protected void Repeater_CreatedForEipIssue(FormEdmontonGN75BDTO e)
        {
            if (invokeControl.IsNotDisposed())
            {
                UpdateEipIssue(e);
            }
            else if (invokeControl.IsNotDisposed())
            {
                RemoveEipIssue(e);
            }
        }

        protected virtual void Repeater_Updated(DomainEventArgs<TDomain> e)
        {
            if (IsRelevantEvent(e) && invokeControl.IsNotDisposed())
            {
                Update(GetDto(e.SelectedItem,"Update"));
            }
            else if (invokeControl.IsNotDisposed())
            {
                Remove(GetDto(e.SelectedItem, "Remove"));
            }
        }

        protected void Repeater_Removed(object sender, DomainEventArgs<TDomain> e)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<DomainEventArgs<TDomain>>(Repeater_Removed), e);
            }
            else
            {
                Repeater_Removed(e);
            }
        }

        protected void Repeater_Removed(DomainEventArgs<TDomain> e)
        {
            if (invokeControl.IsNotDisposed())
            {
                Remove(GetDto(e.SelectedItem,"Remove"));
            }
        }

        private bool IsRelevantEvent(DomainEventArgs<TDomain> e)
        {
            if (e.SelectedItem == null)
            {
                return false;
            }
            return IsRelevantItemFromServerEvent(e.SelectedItem);
        }


        //ayman Sarnia eip DMND0008992
        protected NodeData GetNodeDataForEipIssue(FormEdmontonGN75BDTO dto)
        {
            return new FormSarniaNodeData(dto);
        }

        //ayman Sarnia eip DMND0008992
        protected void AddEipIssue(FormEdmontonGN75BDTO dto)
        {
            NodeData nodeData = GetNodeDataForEipIssue(dto);
            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForEipIssue(dto);
            if (subSectionNode != null)
            {
                subSectionNode.Add(nodeData);
            }
        }

        protected void Add(TDto dto)
        {
            if (dto != null)
            {
                NodeData nodeData = GetNodeData(dto);
                PriorityPageSubSectionNode subSectionNode = GetSubSectionNode(dto);
                if (subSectionNode != null)
                {
                    subSectionNode.Add(nodeData);
                }
            }
        }

        //ayman Sarnia eip DMND0008992 - 2
        private void UpdateEipTemplate(FormEdmontonGN75BDTO dto)
        {

            NodeData nodeData = GetNodeDataForEipIssue(dto);

            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForEipIssue(dto);
            if (subSectionNode != null)
            {
                subSectionNode.Update(nodeData);
                RemoveFromOtherNodes(subSectionNode, nodeData);
            }
        }




        //ayman Sarnia eip DMND0008992
        private void UpdateEipIssue(FormEdmontonGN75BDTO dto)
        {
            
            NodeData nodeData = GetNodeDataForEipIssue(dto);

            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForEipIssue(dto);
            if (subSectionNode != null)
            {
                subSectionNode.Update(nodeData);
                RemoveFromOtherNodes(subSectionNode, nodeData);
            }
        }

        private void Update(TDto dto)
        {
            if (dto != null)                  //ayman action item reading
            {
                NodeData nodeData = GetNodeData(dto);

                PriorityPageSubSectionNode subSectionNode = GetSubSectionNode(dto);
                if (subSectionNode != null)
                {
                    subSectionNode.Update(nodeData);
                    RemoveFromOtherNodes(subSectionNode, nodeData);
                }
            }
        }

        private void RemoveFromOtherNodes(PriorityPageSubSectionNode subSectionNode, NodeData nodeData)
        {
            foreach (CriteriaBasedSubSectionNode other in criteriaBasedSubSectionNodes)
            {
                if (!ReferenceEquals(subSectionNode, other.Node))
                {
                    other.Node.Remove(nodeData);
                }
            }
            if (!ReferenceEquals(subSectionNode, catchAllSubSectionNode) && catchAllSubSectionNode != null)
            {
                catchAllSubSectionNode.Remove(nodeData);
            }
        }


        //ayman Sarnia eip DMND0008992 = 2
        protected virtual void RemoveEipTemplate(FormEdmontonGN75BDTO dto)
        {
            NodeData nodeData = GetNodeDataForEipIssue(dto);

            // we must find the node based on which one contains the dto and not by criteria, because the criteria may have changed (e.g. update dates of dto)
            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForEipIssue(dto);

            if (subSectionNode != null)
            {
                subSectionNode.Remove(nodeData);
            }
        }


        //ayman Sarnia eip DMND0008992
        protected virtual void RemoveEipIssue(FormEdmontonGN75BDTO dto)
        {
            NodeData nodeData = GetNodeDataForEipIssue(dto);

            // we must find the node based on which one contains the dto and not by criteria, because the criteria may have changed (e.g. update dates of dto)
            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoIdForEipIssue(dto);

            if (subSectionNode != null)
            {
                subSectionNode.Remove(nodeData);
            }
        }

        protected virtual void Remove(TDto dto)
        {
            NodeData nodeData = GetNodeData(dto);

            // we must find the node based on which one contains the dto and not by criteria, because the criteria may have changed (e.g. update dates of dto)
            PriorityPageSubSectionNode subSectionNode = GetSubSectionNodeBasedOnDtoId(dto);
            
            if (subSectionNode != null)
            {
                subSectionNode.Remove(nodeData);
            }
        }

        protected List<PriorityPageSubSectionNode> PriorityPageSubSectionNodes
        {
            get 
            { 
                List<PriorityPageSubSectionNode> nodes = new List<PriorityPageSubSectionNode>();
                foreach (CriteriaBasedSubSectionNode criteriaBasedSubSectionNode in criteriaBasedSubSectionNodes)
                {
                    nodes.Add(criteriaBasedSubSectionNode.Node);
                }
                return nodes;
            }
        }

        //ayman Sarnia eip DMND0008992
        private PriorityPageSubSectionNode GetSubSectionNodeBasedOnDtoIdForEipIssue(FormEdmontonGN75BDTO dto)
        {
            if (criteriaBasedSubSectionNodes.Count == 0 || dto == null)
            {
                return catchAllSubSectionNode;
            }

            foreach (CriteriaBasedSubSectionNode potential in criteriaBasedSubSectionNodes)
            {
                PriorityPageDataNode priorityPageDataNode = potential.Node.Find(dto.IdValue);
                if (priorityPageDataNode != null)
                {
                    return potential.Node;
                }
            }

            return catchAllSubSectionNode;
        }


        private PriorityPageSubSectionNode GetSubSectionNodeBasedOnDtoId(TDto dto)
        {
            if (criteriaBasedSubSectionNodes.Count == 0 || dto == null)
            {
                return catchAllSubSectionNode;
            }

            foreach (CriteriaBasedSubSectionNode potential in criteriaBasedSubSectionNodes)
            {
                PriorityPageDataNode priorityPageDataNode = potential.Node.Find(dto.IdValue);
                if (priorityPageDataNode != null)
                {
                    return potential.Node;
                }
            }

            return catchAllSubSectionNode;
        }

        protected PriorityPageSubSectionNode GetSubSectionNode(TDto dto)
        {
            if (criteriaBasedSubSectionNodes.Count == 0)
            {
                return catchAllSubSectionNode;
            }
            else
            {
                PriorityPageSubSectionNode criteriaBasedNode = null;
                foreach (CriteriaBasedSubSectionNode potential in criteriaBasedSubSectionNodes)
                {
                    if (potential.Criteria != null && potential.Criteria.Matches(dto))
                    {
                        criteriaBasedNode = potential.Node;
                    }
                }

                if (criteriaBasedNode != null)
                {
                    return criteriaBasedNode;
                }
                else
                {
                    return catchAllSubSectionNode;
                }
            }
        }

        protected PriorityPageSectionConfiguration SectionConfiguration
        {
            get { return sectionConfiguration; }
        }

        private class CriteriaBasedSubSectionNode
        {
            public PriorityPageSubSectionNode Node { get; private set; }
            public ISubSectionCriteria Criteria { get; private set; }

            public CriteriaBasedSubSectionNode(PriorityPageSubSectionNode node, ISubSectionCriteria criteria)
            {
                Node = node;
                Criteria = criteria;
            }

        }

        protected interface ISubSectionCriteria
        {
            bool Matches(TDto dto);
        }

    }
}
