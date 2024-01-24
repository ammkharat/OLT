using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class PermitRequestEdmontonAttributesTest
    {
        [Ignore] [Test]
        public void ShouldSetAttributesOnPermit_FormRequirementsSection()
        {
            //EW	GN-59 (Issuing and Accepting a SWP)
            //EY	GN-7 (Handling and Disposal of Waste Material)

            //EX	GN-6 (Hoisting using a Suspended Man basket)
            //ET	GN-11 (Ground Disturbance Excavation)
            //EU	GN-24 (Working on a Live Flare Line)
            //EV	GN-27 (Freeze Plug Application)
            //EZ	GN-75 (Isolation and Lockout of Hazardous Fluids/Energy)


            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.GetEmptyPermitRequest();

                Assert.IsFalse(request.GN59);
                Assert.IsFalse(request.GN7);
                Assert.IsFalse(request.GN6);

                string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"EW\EY\EX\EU");
                List<string> attributeList = new List<string>(attribs);

                PermitRequestEdmontonAttributes helper = new PermitRequestEdmontonAttributes(attributeList);

                helper.SetAttributesOnPermitRequest(request);

                Assert.IsTrue(request.GN59);
                Assert.IsTrue(request.GN7);                
                Assert.IsTrue(request.GN24);
                Assert.IsTrue(request.GN6);
            }

            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.GetEmptyPermitRequest();

                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, request.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, request.GN27);                

                string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"EX\ET\EV\EZ\EH");
                List<string> attributeList = new List<string>(attribs);

                PermitRequestEdmontonAttributes helper = new PermitRequestEdmontonAttributes(attributeList);

                helper.SetAttributesOnPermitRequest(request);

                Assert.IsTrue(request.GN6);
                Assert.IsTrue(request.GN75A);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, request.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.Required, request.GN27);                
            }
        }

        [Ignore] [Test]        
        public void ShouldSet()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.GetEmptyPermitRequest();

            const string attributes = @"EA\EB\EC\ED\EE\EF\EG\EH\EI\EJ\EK\EL\EM\EN\EO\EP\EQ\ER\ES\ET\EV\EX\EZ\FA\FB\FC\FD\FE\FF\FN\FG\FH\FI\FJ\FK\FL\FV\FW\FX";

            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(attributes);
            List<string> attributeList = new List<string>(attribs);

            PermitRequestEdmontonAttributes helper = new PermitRequestEdmontonAttributes(attributeList);
            helper.SetAttributesOnPermitRequest(request);

            Assert.IsTrue(request.AirHorn);
            Assert.IsTrue(request.AirMover);
            Assert.IsTrue(request.AirPurifyingRespirator);
            Assert.IsTrue(request.AlkylationEntry);
            Assert.IsTrue(request.AsbestosMMCPrecautions);
            Assert.IsTrue(request.BarriersSigns);
            Assert.IsTrue(request.BreathingAirApparatus);
            Assert.IsTrue(request.BumpTestMonitorPriorToUse);
            Assert.IsTrue(request.ConfinedSpace);
            Assert.IsTrue(request.ContinuousGasMonitor);
            Assert.IsTrue(request.DustMask);
            Assert.IsTrue(request.EquipmentGrounded);
            Assert.IsTrue(request.FaceShield);
            Assert.IsTrue(request.FireBlanket);
            Assert.IsTrue(request.FireExtinguisher);
            Assert.IsTrue(request.FireMonitorManned);
            Assert.IsTrue(request.FireWatch);
            Assert.IsTrue(request.FlarePitEntry);

            Assert.AreEqual(WorkPermitSafetyFormState.Required, request.GN11);
            Assert.AreEqual(WorkPermitSafetyFormState.Required, request.GN27);
            Assert.IsFalse(request.GN59);
            Assert.IsTrue(request.GN6);
            Assert.IsFalse(request.GN7);
            Assert.IsFalse(request.GN24);
            Assert.IsTrue(request.GN75A);            

            Assert.IsTrue(request.Goggles);
            Assert.IsTrue(request.HighVoltagePPE);
            Assert.IsTrue(request.LifeSupportSystem);
            Assert.IsTrue(request.MechVentilationComfortOnly);
            Assert.IsTrue(request.RadioChannel);
            Assert.IsTrue(request.RescuePlan);
            Assert.IsTrue(request.RubberBoots);
            Assert.IsTrue(request.RubberGloves);
            Assert.IsTrue(request.RubberSuit);
            Assert.IsTrue(request.SafetyHarnessLifeline);
            Assert.IsTrue(request.SafetyWatch);
            Assert.IsTrue(request.SewersDrainsCovered);
            Assert.IsTrue(request.SteamHose);
            Assert.IsTrue(request.SteamHose);
            Assert.IsTrue(request.VehicleEntry);
            Assert.IsTrue(request.WorkersMonitor);      
            
            Assert.AreEqual(EdmontonPermitSpecialWorkType.Excavation, request.SpecialWorkType);

            Assert.That(request.Priority, Is.EqualTo(Priority.Normal));
        }

        [Ignore] [Test]
        public void ShouldSetSpecialWorkSection()
        {
            //FM	Special Work - Diving Operations
            //FN	Special Work - Excavation
            //FO	Special Work - Freeze Plug GN-27
            //FP	Special Work - High Voltage Electrical Work
            //FQ	Special Work - Hot Tapping
            //FR	Special Work - On-Stream Leak Sealing
            //FS	Special Work - Powder Actuated Tool Use in Operating Unit
            //FT	Special Work - Radiography Inspections
            //FU	Special Work - TransAlta Utility Work

            PermitRequestEdmonton request = PermitRequestEdmontonFixture.GetEmptyPermitRequest();

            const string specialWorkAttributes = @"FM\FN\FO\FP\FQ\FR\FS\FT\FU";

            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(specialWorkAttributes);
            List<string> attributeList = new List<string>(attribs);

            PermitRequestEdmontonAttributes helper = new PermitRequestEdmontonAttributes(attributeList);
            helper.SetAttributesOnPermitRequest(request);

            //Assert.IsTru
        }

        [Ignore] [Test]
        public void ShouldGracefullyIgnoreAttributesThatWeDoNotKnowAbout()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.GetEmptyPermitRequest();

            Assert.IsFalse(request.GN59);
            Assert.IsFalse(request.GN7);

            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"EW\ZZTOP\EY"); // ZZTOP is not an attribute OLT knows about
            List<string> attributeList = new List<string>(attribs);

            PermitRequestEdmontonAttributes attributes = new PermitRequestEdmontonAttributes(attributeList);

            attributes.SetAttributesOnPermitRequest(request);

            Assert.IsTrue(request.GN59);
            Assert.IsTrue(request.GN7);
        }

        [Ignore] [Test]
        public void ShouldSetPermitToCriticalPath()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.GetEmptyPermitRequest();
            Assert.That(request.Priority, Is.EqualTo(Priority.Normal));

            string[] attribs = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(@"EW\FZ\EY"); 
            List<string> attributeList = new List<string>(attribs);

            PermitRequestEdmontonAttributes attributes = new PermitRequestEdmontonAttributes(attributeList);

            attributes.SetAttributesOnPermitRequest(request);
            Assert.That(request.Priority, Is.EqualTo(Priority.CriticalPath));
        }

        [Ignore] [Test]
        public void ShouldSetConfinedSpaceLevel()
        {
            {
                PermitRequestEdmonton permitRequest = GetEmptyPermitRequestWithConfinedSpaceInfoCleared();
                SetAttributesOnPermitRequest(permitRequest, @"EW\FZ\EY");
                Assert.IsFalse(permitRequest.ConfinedSpace);                
            }

            {
                PermitRequestEdmonton permitRequest = GetEmptyPermitRequestWithConfinedSpaceInfoCleared();
                SetAttributesOnPermitRequest(permitRequest, @"EW\FZ\EY\GA");
                Assert.IsTrue(permitRequest.ConfinedSpace);                
                Assert.AreEqual(WorkPermitEdmonton.ConfinedSpaceLevel1, permitRequest.ConfinedSpaceClass);
            }

            {
                PermitRequestEdmonton permitRequest = GetEmptyPermitRequestWithConfinedSpaceInfoCleared();
                SetAttributesOnPermitRequest(permitRequest, @"EW\FZ\EY\GB");
                Assert.IsTrue(permitRequest.ConfinedSpace);                
                Assert.AreEqual(WorkPermitEdmonton.ConfinedSpaceLevel2, permitRequest.ConfinedSpaceClass);
            }

            {
                PermitRequestEdmonton permitRequest = GetEmptyPermitRequestWithConfinedSpaceInfoCleared();
                SetAttributesOnPermitRequest(permitRequest, @"EW\FZ\EY\GC");
                Assert.IsTrue(permitRequest.ConfinedSpace);
                Assert.AreEqual(WorkPermitEdmonton.ConfinedSpaceLevel3, permitRequest.ConfinedSpaceClass);
            }

            {
                PermitRequestEdmonton permitRequest = GetEmptyPermitRequestWithConfinedSpaceInfoCleared();
                SetAttributesOnPermitRequest(permitRequest, @"EW\FZ\EY\GC\GA\GB");
                Assert.IsTrue(permitRequest.ConfinedSpace);
                Assert.AreEqual(WorkPermitEdmonton.ConfinedSpaceLevel1, permitRequest.ConfinedSpaceClass);
            }
        }

        private PermitRequestEdmonton GetEmptyPermitRequestWithConfinedSpaceInfoCleared()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.GetEmptyPermitRequest();
            permitRequest.ConfinedSpace = false;
            permitRequest.ConfinedSpaceCardNumber = null;
            permitRequest.ConfinedSpaceClass = null;
            return permitRequest;
        }

        private void SetAttributesOnPermitRequest(PermitRequestEdmonton permitRequest, string attributeString)
        {
            PermitRequestEdmontonAttributes attributes = new PermitRequestEdmontonAttributes(new List<string>(WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(attributeString)));
            attributes.SetAttributesOnPermitRequest(permitRequest);            
        }
    }
}
