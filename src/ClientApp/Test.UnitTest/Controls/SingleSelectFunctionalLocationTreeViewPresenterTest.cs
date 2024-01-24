using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class SingleSelectFunctionalLocationTreeViewPresenterTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            ClientSession.GetNewInstance();
            Site sarnia = SiteFixture.Sarnia();
            ClientSession.GetUserContext().SetSite(sarnia, SiteConfigurationFixture.CreateDefaultSiteConfiguration(sarnia));
            
            mockView = MockRepository.GenerateStrictMock<IFunctionalLocationTreeView>();
            mockFlocLookup = MockRepository.GenerateStrictMock<IFunctionalLocationLookup>();
            presenter = new SingleSelectFunctionalLocationTreeViewPresenter(mockView);
        }

        #endregion

        private IFunctionalLocationTreeView mockView;
        private IFunctionalLocationLookup mockFlocLookup;
        private SingleSelectFunctionalLocationTreeViewPresenter presenter;
            

        [Test][Ignore]
        public void ShouldAddDivisionNodeWithAPlaceHolderForAllModeOnLoadEvent()
        {
            FunctionalLocationInfo[] nodes =
            {
                new FunctionalLocationInfo(
                    FunctionalLocationFixture.
                        GetAny_Division(), true)
            };
            ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode.GetAll(SiteConfigurationFixture.CreateSiteConfiguration()), nodes);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }


        [Test][Ignore]
        public void ShouldOnlyLoadFlocsTheFirstTimeLoadIsCalled()
        {
            FunctionalLocationInfo[] nodes = { new FunctionalLocationInfo(FunctionalLocationFixture.GetAny_Division(), true)};
            ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode.GetAll(SiteConfigurationFixture.CreateSiteConfiguration()), nodes);
            
            // Call load a second time, and nothing should happen because the Nodes are already initialized.
            presenter.LoadRootFunctionalLocations(mockFlocLookup);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldAddDivisionNodeWithoutAPlaceHolderForAllModeOnLoadEvent()
        {
            FunctionalLocationInfo[] nodes =
            {
                new FunctionalLocationInfo(
                    FunctionalLocationFixture.
                        GetAny_Division(), false)
            };
            ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode.GetAll(SiteConfigurationFixture.CreateSiteConfiguration()), nodes);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldAddMultipleDivisionNodesForAllModeOnLoadEvent()
        {
            FunctionalLocationInfo divFloc1 = new FunctionalLocationInfo(
                FunctionalLocationFixture.
                    CreateNew(1, "SR1"), false);

            FunctionalLocationInfo divFloc2 = new FunctionalLocationInfo(
                FunctionalLocationFixture.
                    CreateNew(2, "SR2"), true);

            FunctionalLocationInfo[] nodes =
            {
                divFloc1, divFloc2
            };
            ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode.GetAll(SiteConfigurationFixture.CreateSiteConfiguration()), nodes);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldAddDivisionNodeWithNoPlaceholderForViewModeOnLoadEvent()
        {
            FunctionalLocationInfo divFloc1 = new FunctionalLocationInfo(
                FunctionalLocationFixture.
                    CreateNew(1, "SR1"), false);

            FunctionalLocationInfo[] nodes =
            {
                divFloc1
            };
            ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode.LevelThreeAndAbove, nodes);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldAddDivisionNodeWithPlaceholderForViewModeOnLoadEvent()
        {
            FunctionalLocationInfo divFloc1 = new FunctionalLocationInfo(
                FunctionalLocationFixture.
                    CreateNew(1, "SR1"), true);

            FunctionalLocationInfo[] nodes =
            {
                divFloc1
            };
            ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode.LevelThreeAndAbove, nodes);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldAddMultipleDivisionNodesForViewModeOnLoadEvent()
        {
            FunctionalLocationInfo divFloc1 = new FunctionalLocationInfo(
                FunctionalLocationFixture.
                    CreateNew(1, "SR1"), false);

            FunctionalLocationInfo divFloc2 = new FunctionalLocationInfo(
                FunctionalLocationFixture.
                    CreateNew(2, "SR2"), true);

            FunctionalLocationInfo[] nodes = { divFloc1, divFloc2 };
            ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode.LevelThreeAndAbove, nodes);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldAddAllFlocsWhenTheListIsOnlyUnits()
        {
            FunctionalLocationInfo unitFlocA = new FunctionalLocationInfo(CreateUnit(1, "UnitA"), true);
            FunctionalLocationInfo unitFlocB = new FunctionalLocationInfo(CreateUnit(2, "UnitB"), false);
            FunctionalLocationInfo unitFlocC = new FunctionalLocationInfo(CreateUnit(3, "UnitC"), true);

            List<FunctionalLocationInfo> flocInfos = new List<FunctionalLocationInfo> { unitFlocA, unitFlocB, unitFlocC };

            ShouldSetRootNodeCollectionToUnitsOnLoad(FunctionalLocationMode.GetLevelThreeAndBelow(SiteConfigurationFixture.CreateSiteConfiguration()), ConvertFrom(flocInfos), flocInfos);
            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test][Ignore]
        public void ShouldAddOnlyUnitFlocsToTreeEvenWhenSelectedFlocsContainsSections()
        {
            FunctionalLocationInfo unitFlocA = new FunctionalLocationInfo(CreateUnit(1, "UnitA"), true);
            FunctionalLocationInfo unitFlocB = new FunctionalLocationInfo(CreateUnit(2, "UnitB"), false);
            FunctionalLocationInfo unitFlocC = new FunctionalLocationInfo(CreateUnit(3, "UnitC"), true);
            FunctionalLocationInfo sectionFloc = new FunctionalLocationInfo(FunctionalLocationFixture.GetAny_Section(), true);

            List<FunctionalLocationInfo> allFlocInfos = new List<FunctionalLocationInfo> { unitFlocA, unitFlocB, unitFlocC, sectionFloc };            
            List<FunctionalLocationInfo> unitFlocs = new List<FunctionalLocationInfo> { unitFlocA, unitFlocB, unitFlocC };

            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());

            ShouldSetRootNodeCollectionToUnitsOnLoad(FunctionalLocationMode.GetLevelThreeAndBelow(siteConfiguration),
                ConvertFrom(allFlocInfos), new List<FunctionalLocationInfo>(unitFlocs));

            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        private static List<FunctionalLocation> ConvertFrom(IEnumerable<FunctionalLocationInfo> infos)
        {
            List<FunctionalLocation> result = new List<FunctionalLocationInfo>(infos).ConvertAll(info => info.Floc);
            return result;
        }

        private void ShouldSetRootNodeCollectionToUnitsOnLoad(FunctionalLocationMode mode,
                                                              List<FunctionalLocation>
                                                                  allFlocsInSelectedFunctionalLocations,
                                                              List<FunctionalLocationInfo> unitLevelFlocInfosToAddToTree)
        {
            ClientSession.GetUserContext()
                .SetSelectedFunctionalLocations(new List<FunctionalLocation>(allFlocsInSelectedFunctionalLocations), new List<FunctionalLocation>(), new List<FunctionalLocation>());
            List<FunctionalLocationTreeNode> flocsAsNodes = FunctionalLocationTreeNode.Convert(unitLevelFlocInfosToAddToTree, mode);

            mockView.Stub(m => m.FunctionalLocationTreeViewMode).Return(mode);

            mockFlocLookup.Expect(m => m.GetUnitsFor(allFlocsInSelectedFunctionalLocations[0].Site.IdValue)).Return(unitLevelFlocInfosToAddToTree);

            mockView.Expect(m => m.RootNodeCollection).SetPropertyWithArgument(flocsAsNodes.ToArray());

            presenter.LoadRootFunctionalLocations(mockFlocLookup);
        }

        private void ShouldSetRootNodeCollectionToDivisionOnLoad(FunctionalLocationMode mode, IEnumerable<FunctionalLocationInfo> flocs)
        {
            ClientSession.GetNewInstance();
            Site sarnia = SiteFixture.Sarnia();
            ClientSession.GetUserContext().SetSite(sarnia, null);
            List<FunctionalLocationInfo> flocsAsList = new List<FunctionalLocationInfo>(flocs);
            List<FunctionalLocationTreeNode> flocsAsNodes =
                new List<FunctionalLocationTreeNode>(
                    FunctionalLocationTreeNode.Convert(flocsAsList, mode));

            mockView.Stub(m => m.FunctionalLocationTreeViewMode).Return(mode);
            mockFlocLookup.Expect(m => m.GetChildrenFor(sarnia.IdValue)).Return(flocsAsList);
            mockView.Expect(m => m.RootNodeCollection).SetPropertyWithArgument(flocsAsNodes.ToArray());
//            mockView.Expect(m => m.RootNodeCollection).SetPropertyAndIgnoreArgument().Constraints(new RhinoFunctionalLocationTreeNodeArrayEqualsConstraint(flocsAsNodes.ToArray()));

            presenter.LoadRootFunctionalLocations(mockFlocLookup);
        }

        [Test]
        public void ShouldLoadChildrenSectionForDivisionNodeInShowViewThatHasChildren()
        {
            mockView.Expect(m => m.FunctionalLocationTreeViewMode).Return(null);

            presenter.LoadRootFunctionalLocations(mockFlocLookup);

            FunctionalLocation division = FunctionalLocationFixture.CreateNew(1, "SR1");
            FunctionalLocationTreeNode node = new FunctionalLocationTreeNode(division, true);
            FunctionalLocationInfo sectionFloc = new FunctionalLocationInfo(
                FunctionalLocationFixture.GetAny_Section(), true);

            mockView.Stub(m => m.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.LevelThreeAndAbove);
            mockFlocLookup.Expect(m => m.GetChildrenFor(division)).Return(new List<FunctionalLocationInfo> {sectionFloc});
            FunctionalLocationTreeNode[] childNodes = { new FunctionalLocationTreeNode(sectionFloc.Floc, false) };

            mockView.Expect(m => m.AddChildren(node, new List<FunctionalLocationTreeNode>(childNodes)));

            presenter.LoadRealChildrenBeforeExpansion(null, new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown));

            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotLoadChildrenSectionWhenDivisionNodeDoesNotHaveChildren()
        {
            FunctionalLocation division = FunctionalLocationFixture.CreateNew(1, "SR1");
            FunctionalLocationTreeNode node = new FunctionalLocationTreeNode(division, false);

            mockView.Stub(m => m.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.LevelThreeAndAbove);

            presenter.LoadRealChildrenBeforeExpansion(null, new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown));

            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test]
        public void ShouldLoadChildrenSectionButShouldNotAddChildrenPlaceholdersToSectionWhenSectionHasNoUnits()
        {
            mockView.Expect(m => m.FunctionalLocationTreeViewMode).Return(null);

            presenter.LoadRootFunctionalLocations(mockFlocLookup);

            FunctionalLocation division = FunctionalLocationFixture.CreateNew(1, "SR1");
            FunctionalLocationTreeNode node = new FunctionalLocationTreeNode(division, true);

            mockView.Stub(m => m.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.LevelThreeAndAbove);
            mockFlocLookup.Expect(m => m.GetChildrenFor(division)).Return(new List<FunctionalLocationInfo>());

            presenter.LoadRealChildrenBeforeExpansion(null, new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown));

            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotLoadChildrenWhenCurrentNodeIsAUnitAndModeIsUnitAndAbove()
        {
            FunctionalLocation unit = CreateUnit(1, "UnitA");
            FunctionalLocationTreeNode node = new FunctionalLocationTreeNode(unit, true);// Making the unit have children, but don't load them because of mode.

            mockView.Stub(m => m.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.LevelThreeAndAbove);

            presenter.LoadRealChildrenBeforeExpansion(null, new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown));

            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        [Test]
        public void ShouldLoadUnitChildrenInUnitAndBelowMode()
        {
            mockView.Expect(m => m.FunctionalLocationTreeViewMode).Return(null); 

            presenter.LoadRootFunctionalLocations(mockFlocLookup);

            FunctionalLocation unit = CreateUnit(1, "UnitA");
            FunctionalLocationTreeNode node = new FunctionalLocationTreeNode(unit, true);
            FunctionalLocationInfo equipment1Floc = new FunctionalLocationInfo(FunctionalLocationFixture.GetAny_Equip1(), true);

            SiteConfiguration defaultSiteConfiguration = SiteConfigurationFixture.CreateSiteConfiguration();

            mockView.Stub(m => m.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.GetLevelThreeAndBelow(defaultSiteConfiguration));

            mockFlocLookup.Expect(m => m.GetChildrenFor(unit)).Return(new List<FunctionalLocationInfo> {equipment1Floc});
            FunctionalLocationTreeNode[] childNodes = { new FunctionalLocationTreeNode(equipment1Floc.Floc, false) };
            mockView.Expect(m => m.AddChildren(node, new List<FunctionalLocationTreeNode>(childNodes)));

            presenter.LoadRealChildrenBeforeExpansion(null, new TreeViewCancelEventArgs(node, false, TreeViewAction.Unknown));

            mockView.VerifyAllExpectations();
            mockFlocLookup.VerifyAllExpectations();
        }

        private static FunctionalLocation CreateUnit(long id, string unit)
        {
            return FunctionalLocationFixture.CreateNew(id, "ABC1-DEF2-" + unit);
        }
    }
}