using System.Collections.Generic;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class TargetAlertAuthorizationTest
    {
        [Test]
        public void OnlySupervisorsAndOperatorsShouldBeAbleToRespondToTargetAlerts()
        {
            IAuthorized authorized = new Authorized();
            Assert.IsTrue(authorized.ToRespondToTargetAlerts(UserRoleElementsFixture.CreateRoleElementsForSupervisor()));
            Assert.IsTrue(authorized.ToRespondToTargetAlerts(UserRoleElementsFixture.CreateRoleElementsForOperator()));
            Assert.IsFalse(authorized.ToRespondToTargetAlerts(UserRoleElementsFixture.CreateRoleElementsForPermitScreener()));

        }


        [Test]
        public void OnlyAcknowledgeIfAllTargetAlertsDoNotRequireAResponse()
        {
            TargetAlert alert1 = CreateTargetAlert(TargetAlertStatus.StandardAlert);
            alert1.ExceedingBoundaries = true;
            alert1.RequiresResponse = true;
            TargetAlert alert2 = CreateTargetAlert(TargetAlertStatus.StandardAlert);
            alert2.ExceedingBoundaries = true;
            alert2.RequiresResponse = false;

            TargetAlertDTO alertDTO1 = new TargetAlertDTO(alert1);
            TargetAlertDTO alertDTO2 = new TargetAlertDTO(alert2);
            List<TargetAlertDTO> selectedDTOs = new List<TargetAlertDTO> {alertDTO1, alertDTO2};

            IAuthorized authorized = new Authorized();
            Assert.IsFalse(authorized.ToAcknowledgeTargetAlerts(UserRoleElementsFixture.CreateRoleElementsForSupervisor(), selectedDTOs));
        }

        private static TargetAlert CreateTargetAlert(TargetAlertStatus status)
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert();
            alert.Id = -99;
            alert.Status = status;
            return alert;
        }
    }
}