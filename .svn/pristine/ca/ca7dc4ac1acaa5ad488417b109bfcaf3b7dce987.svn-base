using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.MultiGrid;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;
using Infragistics.Win;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    // Note: this is all hard-coded for Oilsands.
    public class MultiGridFormPagePresenter : AbstractMultiGridPagePresenter
    {
        public static string CanViewText = "Training";
        private static readonly OilsandsFormType InitialForm = OilsandsFormType.Training;
        private static readonly EdmontonFormType InitialFormPermitAssessment = EdmontonFormType.OilsandsPermitAssessment;
        private static readonly EdmontonFormType InitialFormProcDeviation = EdmontonFormType.ProcedureDeviation;
        private static readonly EdmontonFormType InitialFormDocumentSuggestion = EdmontonFormType.DocumentSuggestion;

        //RITM0341710 mangesh
        private static readonly EdmontonFormType InitialFormOilSample = EdmontonFormType.FortHillOilSample;
        private static readonly EdmontonFormType InitialFormDailyInspection = EdmontonFormType.FortHillDailyInspection;

        public MultiGridFormPagePresenter(MultiGridFormPage page, List<IMultiGridContext> contexts)
            : base(page,
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            page.LoadContexts(contexts);
        }

        public IMultiGridContextSelection CurrentGridContext
        {
            get { return page.CurrentGridContext.Key; }
        }


        //ayman forthills

        public static MultiGridFormPagePresenter CreateForForthills()
        {
            var page = new MultiGridFormPage();

            var authorized = new Authorized();
            var context = ClientSession.GetUserContext();

            var canViewTrainingFormInList = authorized.ToViewTrainingForm(context.UserRoleElements, context.Site) ||
                                            authorized.ToEditTrainingForm(context.UserRoleElements, context.Site) ||
                                            authorized.ToCloseTrainingForm(context.UserRoleElements, context.Site) ||
                                            authorized.ToCreateTrainingForm(context.UserRoleElements, context.Site);

            //RITM0341710 mangesh
            var canViewOilSampleFormList = authorized.ToViewFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillOilSample, context.Site) ||
                                            authorized.ToEditFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillOilSample, context.Site) ||
                                            authorized.ToApproveOrCloseFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillOilSample, context.Site) ||
                                            authorized.ToCreateFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillOilSample, context.Site);

            var canViewDailyInspectionFormList = authorized.ToViewFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillDailyInspection, context.Site) ||
                                           authorized.ToEditFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillDailyInspection, context.Site) ||
                                           authorized.ToApproveOrCloseFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillDailyInspection, context.Site) ||
                                           authorized.ToCreateFormGenericTemplate(context.UserRoleElements, null, EdmontonFormType.FortHillDailyInspection, context.Site);
            
            // ayman forthills forms
            var canViewPermitAssessment =
                authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements);

            if (canViewTrainingFormInList) //ayman training form
            {
                page.AddNodeToSelectionList(OilsandsFormType.Training);
            }

            if (canViewPermitAssessment)
            {
                page.AddNodeToSelectionList(EdmontonFormType.OilsandsPermitAssessment);
            }

            //RITM0341710 mangesh
            if (canViewOilSampleFormList)
            {
                page.AddNodeToSelectionList(EdmontonFormType.FortHillOilSample);
            }
            if (canViewDailyInspectionFormList)
            {
                page.AddNodeToSelectionList(EdmontonFormType.FortHillDailyInspection);
            }

            var formService = ClientServiceRegistry.Instance.GetService<IFormOilsandsService>();
            var edmontonService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            var contexts = new List<IMultiGridContext>(); //RITM0341710 : Bug fix Vibhor
            if (canViewTrainingFormInList)
            {
                CanViewText = "Training";
                if (canViewPermitAssessment)
                {
                   // var contexts = new List<IMultiGridContext>
                   // {
                    contexts.Add(new OilsandsTrainingFormContext(formService, page)); //RITM0341710 : Bug fix Vibhor
                    contexts.Add(new PermitAssessmentFormContext(edmontonService, page)); //RITM0341710 : Bug fix Vibhor
                   // };
                    page.SetSelectedGridSelectionListNode(InitialForm);
                   // return new MultiGridFormPagePresenter(page, contexts);
                }
                else
                {
                     //var contexts = new List<IMultiGridContext>
                    contexts.Add(new OilsandsTrainingFormContext(formService, page)); //RITM0341710 : Bug fix Vibhor
                    
                    page.SetSelectedGridSelectionListNode(InitialForm);
                   // return new MultiGridFormPagePresenter(page, contexts);

                }
            }
            else
            {
                CanViewText = "Assessment";
                //var contexts = new List<IMultiGridContext>
                contexts.Add(new PermitAssessmentFormContext(edmontonService, page)); //RITM0341710 : Bug fix Vibhor

                page.SetSelectedGridSelectionListNode(InitialFormPermitAssessment);
                //return new MultiGridFormPagePresenter(page, contexts);//RITM0341710 : Bug fix Vibhor
            }

            //RITM0341710 mangesh
             if (canViewOilSampleFormList || canViewDailyInspectionFormList)
            {
                if (canViewOilSampleFormList && !canViewDailyInspectionFormList)
                {
                    CanViewText = "OilSample";
                    //var contexts = new List<IMultiGridContext>
                    contexts.Add(new GenericTemplateFormContext(edmontonService, page, 1007)); //RITM0341710 : Bug fix Vibhor
                    page.SetSelectedGridSelectionListNode(InitialFormOilSample);
                    //return new MultiGridFormPagePresenter(page, contexts);
                }
                else if (!canViewOilSampleFormList && canViewDailyInspectionFormList)
                {
                    CanViewText = "DailyInspection";
                   // var contexts = new List<IMultiGridContext>
                    contexts.Add(new GenericTemplateFormContext(edmontonService, page, 1008)); //RITM0341710 : Bug fix Vibhor
                    page.SetSelectedGridSelectionListNode(InitialFormDailyInspection);
                   //return new MultiGridFormPagePresenter(page, contexts);
                }
                else //if (canViewOilSampleFormList && canViewDailyInspectionFormList)
                {
                    CanViewText = "OilSampleAndDailyInspection";
                    //var contexts = new List<IMultiGridContext>
                    //{
                    //    new GenericTemplateFormContext(edmontonService, page, 1007),
                    //    new GenericTemplateFormContext(edmontonService, page, 1008)
                    //};
                    contexts.Add(new GenericTemplateFormContext(edmontonService, page, 1007)); //RITM0341710 : Bug fix Vibhor
                    contexts.Add(new GenericTemplateFormContext(edmontonService, page, 1008)); //RITM0341710 : Bug fix Vibhor
                    //page.SetSelectedGridSelectionListNode(InitialFormOilSample);
                    page.SetSelectedGridSelectionListNode(InitialFormDailyInspection);
                   // return new MultiGridFormPagePresenter(page, contexts);
                }
            }
             return new MultiGridFormPagePresenter(page, contexts);
            

        }


        //ayman E&U
        public static MultiGridFormPagePresenter CreateForSiteWide()
        {
            var page = new MultiGridFormPage();

            var authorized = new Authorized();
            var context = ClientSession.GetUserContext();

            var canViewProcedureDeviationFormInList =
                authorized.ToViewProcedureDeviationOnPrioritiesPage(context.UserRoleElements, context.SiteId) ||
                authorized.ToCreateFormProcedureDeviation(context.UserRoleElements, context.SiteId) ||
                authorized.ToEditFormProcedureDeviation(context.UserRoleElements, context.SiteId);

            var CanViewTrainingForm = authorized.ToViewTrainingForm(context.UserRoleElements, context.Site) ||
                                      authorized.ToEditTrainingForm(context.UserRoleElements, context.Site) ||
                                      authorized.ToCloseTrainingForm(context.UserRoleElements, context.Site) ||
                                      authorized.ToCreateTrainingForm(context.UserRoleElements, context.Site);

            if (CanViewTrainingForm) //ayman training form
            {
                page.AddNodeToSelectionList(OilsandsFormType.Training);
            }

            //ayman e&u 
            if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
            {
                page.AddNodeToSelectionList(EdmontonFormType.DocumentSuggestion);
            }
            if (canViewProcedureDeviationFormInList)
            {
                page.AddNodeToSelectionList(EdmontonFormType.ProcedureDeviation);
            }

            var formService = ClientServiceRegistry.Instance.GetService<IFormOilsandsService>();
            var edmontonService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            if (CanViewTrainingForm)
            {
                CanViewText = "Training";
                if (canViewProcedureDeviationFormInList)
                {
                    if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                    {
                        var contexts = new List<IMultiGridContext>
                        {
                            new OilsandsTrainingFormContext(formService, page),
                            new DocumentSuggestionFormContext(edmontonService, page),
                            new ProcedureDeviationFormContext(edmontonService, page)
                        };
                        page.SetSelectedGridSelectionListNode(InitialForm);
                        return new MultiGridFormPagePresenter(page, contexts);
                    }
                    else
                    {
                        var contexts = new List<IMultiGridContext>
                        {
                            new OilsandsTrainingFormContext(formService, page),
                            new ProcedureDeviationFormContext(edmontonService, page)
                        };
                        page.SetSelectedGridSelectionListNode(InitialForm);
                        return new MultiGridFormPagePresenter(page, contexts);
                    }
                }
                else
                {
                    if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                    {
                        var contexts = new List<IMultiGridContext>
                        {
                            new OilsandsTrainingFormContext(formService, page),
                            new DocumentSuggestionFormContext(edmontonService, page)
                        };
                        page.SetSelectedGridSelectionListNode(InitialForm);
                        return new MultiGridFormPagePresenter(page, contexts);
                    }
                    else
                    {
                        var contexts = new List<IMultiGridContext>
                        {
                            new OilsandsTrainingFormContext(formService, page)
                        };
                        page.SetSelectedGridSelectionListNode(InitialForm);
                        return new MultiGridFormPagePresenter(page, contexts);
                    }
                }
            }
            else
            {
                if (canViewProcedureDeviationFormInList)
                {
                    CanViewText = "Deviation";
                    if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                    {
                        CanViewText = "Suggestion";
                        var contexts = new List<IMultiGridContext>
                        {
                            new ProcedureDeviationFormContext(edmontonService, page),
                            new DocumentSuggestionFormContext(edmontonService, page)
                        };
                        page.SetSelectedGridSelectionListNode(InitialFormProcDeviation);
                        return new MultiGridFormPagePresenter(page, contexts);
                    }
                    else
                    {
                        var contexts = new List<IMultiGridContext>
                        {
                            new ProcedureDeviationFormContext(edmontonService, page)
                        };
                        page.SetSelectedGridSelectionListNode(InitialFormProcDeviation);
                        return new MultiGridFormPagePresenter(page, contexts);
                    }
                }
                else
                {
                    if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                    {
                        CanViewText = "Suggestion";
                        var contexts = new List<IMultiGridContext>
                        {
                            new DocumentSuggestionFormContext(edmontonService, page)
                        };
                        page.SetSelectedGridSelectionListNode(InitialFormDocumentSuggestion);
                        return new MultiGridFormPagePresenter(page, contexts);
                    }
                }
            }

            return null;
        }




        public static MultiGridFormPagePresenter CreateForOilsands()
        {
            var page = new MultiGridFormPage();

            var authorized = new Authorized();
            var context = ClientSession.GetUserContext();

            var canViewProcedureDeviationFormInList =
                authorized.ToViewProcedureDeviationOnPrioritiesPage(context.UserRoleElements, context.SiteId) ||
                authorized.ToCreateFormProcedureDeviation(context.UserRoleElements, context.SiteId) ||
                authorized.ToEditFormProcedureDeviation(context.UserRoleElements, context.SiteId);

            var CanViewTrainingFormOilSands = authorized.ToViewTrainingForm(context.UserRoleElements, context.Site) ||
                                              authorized.ToEditTrainingForm(context.UserRoleElements, context.Site) ||
                                              authorized.ToCloseTrainingForm(context.UserRoleElements, context.Site) ||
                                              authorized.ToCreateTrainingForm(context.UserRoleElements, context.Site);

            if (CanViewTrainingFormOilSands) //ayman training form
            {
                page.AddNodeToSelectionList(OilsandsFormType.Training);
            }

            if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements))
            {
                page.AddNodeToSelectionList(EdmontonFormType.OilsandsPermitAssessment);
            }

            if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
            {
                page.AddNodeToSelectionList(EdmontonFormType.DocumentSuggestion);
            }

            if (canViewProcedureDeviationFormInList)
            {
                page.AddNodeToSelectionList(EdmontonFormType.ProcedureDeviation);
            }


            var formService = ClientServiceRegistry.Instance.GetService<IFormOilsandsService>();
            var edmontonService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            if (CanViewTrainingFormOilSands)
            {
                CanViewText = "Training";

                if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements))
                {
                    if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                    {
                        if (canViewProcedureDeviationFormInList)
                        {
                            var contexts = new List<IMultiGridContext>
                            {
                                new OilsandsTrainingFormContext(formService, page),
                                new PermitAssessmentFormContext(edmontonService, page),
                                new DocumentSuggestionFormContext(edmontonService, page),
                                new ProcedureDeviationFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialForm);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                        else
                        {
                            if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                            {
                                if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements))
                                {
                                    CanViewText = "Training";
                                    var contexts = new List<IMultiGridContext>
                                    {
                                        new OilsandsTrainingFormContext(formService, page),
                                        new PermitAssessmentFormContext(edmontonService, page),
                                        new DocumentSuggestionFormContext(edmontonService, page)
                                    };
                                    page.SetSelectedGridSelectionListNode(InitialForm);
                                    return new MultiGridFormPagePresenter(page, contexts);
                                }
                                else
                                {
                                    var contexts = new List<IMultiGridContext>
                                    {
                                        new OilsandsTrainingFormContext(formService, page),
                                        new DocumentSuggestionFormContext(edmontonService, page)
                                    };
                                    page.SetSelectedGridSelectionListNode(InitialForm);
                                    return new MultiGridFormPagePresenter(page, contexts);
                                }
                            }
                            else
                            {
                                if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements))
                                {
                                    var contexts = new List<IMultiGridContext>
                                    {
                                        new OilsandsTrainingFormContext(formService, page),
                                        new PermitAssessmentFormContext(edmontonService, page)
                                    };
                                    page.SetSelectedGridSelectionListNode(InitialForm);
                                    return new MultiGridFormPagePresenter(page, contexts);
                                }
                                else
                                {
                                    var contexts = new List<IMultiGridContext>
                                    {
                                        new OilsandsTrainingFormContext(formService, page)
                                    };
                                    page.SetSelectedGridSelectionListNode(InitialForm);
                                    return new MultiGridFormPagePresenter(page, contexts);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (canViewProcedureDeviationFormInList)
                        {
                            var contexts = new List<IMultiGridContext>
                            {
                                new OilsandsTrainingFormContext(formService, page),
                                new PermitAssessmentFormContext(edmontonService, page),
                                new ProcedureDeviationFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialForm);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                        else
                        {
                            var contexts = new List<IMultiGridContext>
                            {
                                new OilsandsTrainingFormContext(formService, page),
                                new PermitAssessmentFormContext(edmontonService, page),
                            };
                            page.SetSelectedGridSelectionListNode(InitialForm);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                    }
                }
                else
                {
                    if (canViewProcedureDeviationFormInList)
                    {
                        if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                        {
                            var contexts = new List<IMultiGridContext>
                            {
                                new OilsandsTrainingFormContext(formService, page),
                                new ProcedureDeviationFormContext(edmontonService, page),
                                new DocumentSuggestionFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialForm);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                        else
                        {
                            var contexts = new List<IMultiGridContext>
                            {
                                new OilsandsTrainingFormContext(formService, page),
                                new ProcedureDeviationFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialForm);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                    }
                    else
                    {
                        if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                        {
                            var contexts = new List<IMultiGridContext>
                            {
                                new OilsandsTrainingFormContext(formService, page),
                                new DocumentSuggestionFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialForm);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                        else
                        {
                            var contexts = new List<IMultiGridContext>
                            {
                                new OilsandsTrainingFormContext(formService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialForm);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                    }
                }
            }
            else // no training form
            {
                if (canViewProcedureDeviationFormInList)
                {
                    if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                    {
                        if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements))
                        {
                            CanViewText = "Assessment";
                            var contexts = new List<IMultiGridContext>
                            {
                                new PermitAssessmentFormContext(edmontonService, page),
                                new DocumentSuggestionFormContext(edmontonService, page),
                                new ProcedureDeviationFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialFormPermitAssessment);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                        else
                        {
                            CanViewText = "Suggestion";
                            var contexts = new List<IMultiGridContext>
                            {
                                new DocumentSuggestionFormContext(edmontonService, page),
                                new ProcedureDeviationFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialFormDocumentSuggestion);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                    }
                    else
                    {
                        if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements))
                        {
                            CanViewText = "Assessment";
                            var contexts = new List<IMultiGridContext>
                            {
                                new PermitAssessmentFormContext(edmontonService, page),
                                new ProcedureDeviationFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialFormPermitAssessment);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                        else
                        {
                            CanViewText = "Deviation";
                            var contexts = new List<IMultiGridContext>
                            {
                                new ProcedureDeviationFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialFormProcDeviation);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                    }
                }
                else // no training no deviation
                {
                    if (authorized.ToCreateFormSafeWorkPermitAuditQuestionnaire(context.UserRoleElements))
                    {
                        if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                        {
                            CanViewText = "Assessment";
                            var contexts = new List<IMultiGridContext>
                            {
                                new PermitAssessmentFormContext(edmontonService, page),
                                new DocumentSuggestionFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialFormPermitAssessment);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                        else
                        {
                            CanViewText = "Assessment";
                            var contexts = new List<IMultiGridContext>
                            {
                                new PermitAssessmentFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialFormPermitAssessment);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                    }
                    else
                    {
                        if (authorized.ToCreateFormDocumentSuggestion(context.UserRoleElements, context.SiteId))
                        {
                            CanViewText = "Suggestion";
                            var contexts = new List<IMultiGridContext>
                            {
                                new DocumentSuggestionFormContext(edmontonService, page)
                            };
                            page.SetSelectedGridSelectionListNode(InitialFormDocumentSuggestion);
                            return new MultiGridFormPagePresenter(page, contexts);
                        }
                    }
                }
            }
            return null;
        }

        protected override
            IMultiGridContext ChangeContext(IMultiGridContextSelection gridContextSelection)
        {
            var context = page.GetContext(gridContextSelection);
            page.SetGridAndDetails(context.Grid, context.Details);
            return context;
        }

        protected override IMultiGridContext GetInitialGridContext()
        {
            switch (CanViewText)
            {
                case "Training":
                    return page.GetContext(InitialForm);
                    break;
                case "Deviation":
                    return page.GetContext(InitialFormDocumentSuggestion);
                    break;
                case "Suggestion":
                    return page.GetContext(InitialFormDocumentSuggestion);
                    break;
                case "Assessment":
                    return page.GetContext(InitialFormPermitAssessment);
                    break;
                //RITM0341710 mangesh
                case "OilSample":
                    return page.GetContext(InitialFormOilSample);
                    break;
                case "DailyInspection":
                    return page.GetContext(InitialFormDailyInspection);
                    break;
                case "OilSampleAndDailyInspection":
                    return page.GetContext(InitialFormDailyInspection);
                    break;
                default:
                    return page.GetContext(InitialForm);
                    break;
            }

        }
    }
}