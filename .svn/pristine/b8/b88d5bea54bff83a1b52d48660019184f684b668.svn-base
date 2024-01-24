using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    /// <summary>
    ///     Summary description for PoorMansLoadTests
    /// </summary>
    [TestFixture]
    [Category("Integration")]
    public class PoorMansLoadTests
    {
        [Test]
        [Ignore] // Warning..should leave ignored for check in cause this inserts 100 records!!!
        public void SHouldBeAbleToInsert100ActionItemDefinitions()
        {
            var service = GenericServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
            long lastActionItemID = 1;
            ActionItemDefinition aidTemp;
            var rnd = new Random();
            for (var i = 1; i < 100; i++)
            {
                var actionItemDefinition =
                    ActionItemDefinitionFixture.CreateProcessCategoryActionItemDefinitionFortMcMurrayWithNoID();
                actionItemDefinition.FunctionalLocations.Add(GetFunctionalLocation());

                var now = DateTimeFixture.DateTimeNow;

                actionItemDefinition.LastModifiedDate = now;
                actionItemDefinition.Name = now.ToString() + now.Ticks + "INS";
                actionItemDefinition.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
                    //randomly choosing ID;

                var randomNumber = rnd.Next(3);

                switch (randomNumber)
                {
                    case 0:
                        aidTemp = service.QueryById(lastActionItemID);
                        if (aidTemp != null)
                            service.Remove(aidTemp);
                        break;
                    case 1:
                        aidTemp = service.QueryById(lastActionItemID);
                        if (aidTemp != null)
                            service.Update(aidTemp);
                        break;
                    case 2:
                        var savedActionItemDefinition =
                            (ActionItemDefinition) service.Insert(actionItemDefinition)[0].DomainObject;
                        lastActionItemID = savedActionItemDefinition.IdValue;
                        break;
                    default:
                        break;
                }
            }
        }


        [Test]
        [Ignore] // Warning..should leave ignored for check in cause this inserts 100 records!!!
        public void SHouldBeAbleToInsert100TargetDefinitions()
        {
            var service =
                GenericServiceRegistry.Instance.GetService<ITargetDefinitionService>();

            long lastID = 1;

            TargetDefinition tdTemp;
            var rnd = new Random();
            for (var i = 1; i < 100; i++)
            {
                var targetDefinition = TargetDefinitionFixture.CreateATargetWithRecurringHourlyScheduleOfEverySixHours();
                targetDefinition.FunctionalLocation = GetFunctionalLocation();
                targetDefinition.LastModifiedDate = DateTime.Now;
                targetDefinition.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                    //randomly choosing ID;                
                targetDefinition.Name = DateTimeFixture.DateTimeNow.Ticks + "INS";
                var randomNumber = rnd.Next(3);

                switch (randomNumber)
                {
                    case 0:
                        tdTemp = service.QueryById(lastID);
                        if (tdTemp != null)
                        {
                            tdTemp.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                                //randomly choosing ID;
                            service.Remove(tdTemp);
                        }
                        break;
                    case 1:
                        tdTemp = service.QueryById(lastID);
                        if (tdTemp != null)
                        {
                            tdTemp.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                                //randomly choosing ID;
                            service.Update(tdTemp, new TagChangedState());
                        }
                        break;
                    case 2:
                        var newTargetDefinition = (TargetDefinition) service.Insert(targetDefinition)[0].DomainObject;
                        lastID = newTargetDefinition.IdValue;
                        break;
                    default:
                        break;
                }
            }
        }

        [Test]
        [Ignore] // Warning..should leave ignored for check in cause this inserts 100 records!!!
        public void SHouldBeAbleToInsert100WorkPermits()
        {
            var service = GenericServiceRegistry.Instance.GetService<IWorkPermitService>();
            long lastID = 1;
            WorkPermit wpTemp;
            var rnd = new Random();
            for (var i = 1; i < 100; i++)
            {
                var workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
                workPermit.Specifics.FunctionalLocation = GetFunctionalLocation();
                workPermit.LastModifiedDate = DateTimeFixture.DateTimeNow;
                workPermit.SetCreatedBy(UserFixture.CreateOperatorOltUser1InFortMcMurrySite(), true);
                    //randomly choosing ID;
                workPermit.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                    //randomly choosing ID;

                var randomNumber = rnd.Next(3);

                switch (randomNumber)
                {
                    case 0:
                        wpTemp = service.QueryById(lastID);
                        if (wpTemp != null)
                        {
                            wpTemp.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                                //randomly choosing ID;
                            service.Remove(wpTemp);
                        }
                        break;
                    case 1:
                        wpTemp = service.QueryById(lastID);
                        if (wpTemp != null)
                        {
                            wpTemp.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                                //randomly choosing ID;
                            service.Update(wpTemp);
                        }
                        break;
                    case 2:
                        var savedWorkPermit = (WorkPermit) service.Insert(workPermit)[0].DomainObject;
                        lastID = savedWorkPermit.IdValue;
                        break;
                    default:
                        break;
                }
            }
        }

        private static FunctionalLocation GetFunctionalLocation()
        {
            var service = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            return service.QueryByFullHierarchy("EX1-FACL-BLDC", Site.OILSAND_ID);
        }
    }
}