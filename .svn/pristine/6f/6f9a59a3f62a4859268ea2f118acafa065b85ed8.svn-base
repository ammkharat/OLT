using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters
{    
    [TestFixture]
    public class MultiSelectFunctionalLocationTreeViewPresenterTest
    {
        private IMultiSelectFunctionalLocationTreeView mockView;

        private FunctionalLocation flocDiv1;
        private FunctionalLocation flocDiv2;
        private FunctionalLocation flocDiv1Sec1;
        private FunctionalLocation flocDiv2Sec2;
        private FunctionalLocation flocDiv2Sec3;
        private FunctionalLocation flocDiv1Sec1Un1;
        private FunctionalLocation flocDiv2Sec3Un2;
        private FunctionalLocation flocDiv2Sec3Un3;
        private FunctionalLocation flocDiv2Sec3Un4;
        private FunctionalLocation flocDiv2Sec3Un5;
        private FunctionalLocation flocDiv2Sec3Un5Eq1A;
        private FunctionalLocation flocDiv2Sec3Un5Eq1B;
        private FunctionalLocation flocDiv2Sec3Un5Eq1AEq2A;
        private FunctionalLocation flocDiv2Sec3Un5Eq1AEq2B;

        private FunctionalLocationTreeNode nodeDiv1;
        private FunctionalLocationTreeNode nodeDiv2;
        private FunctionalLocationTreeNode nodeDiv1Sec1;
        private FunctionalLocationTreeNode nodeDiv2Sec2;
        private FunctionalLocationTreeNode nodeDiv2Sec3;
        private FunctionalLocationTreeNode nodeDiv1Sec1Un1;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un2;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un3;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un4;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un5;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un5Eq1A;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un5Eq1B;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un5Eq1AEq2A;
        private FunctionalLocationTreeNode nodeDiv2Sec3Un5Eq1AEq2B;

        private MultiSelectFunctionalLocationTreeViewPresenter presenter;
        private IFunctionalLocationLookup mockFunctionalLocationLookup;

        private FunctionalLocationTreeNode[] rootNodeCollection;
        private List<FunctionalLocation> unitAndAboveFunctionalLocations = new List<FunctionalLocation>();

        private readonly Site testSite = SiteFixture.Sarnia();

        [SetUp]
        public void SetUp()
        {
            ClientSession.GetNewInstance();
            ClientSession.GetUserContext().SetSite(testSite, SiteConfigurationFixture.CreateDefaultSiteConfiguration(testSite));

            mockView = MockRepository.GenerateStrictMock<IMultiSelectFunctionalLocationTreeView>();
            mockFunctionalLocationLookup = MockRepository.GenerateStrictMock<IFunctionalLocationLookup>();
            presenter = new MultiSelectFunctionalLocationTreeViewPresenter(mockView);
            SetupFunctionalLocationTree();
        }

        [TearDown]
        public void TearDown()
        {           
        }

        #region Load
        [Test][Ignore]
        public void ShouldAddDivisionNodeWithAPlaceHolderForAllModeOnLoadEvent()
        {
            var nodes = new[] { new FunctionalLocationInfo(flocDiv1, true) };
            SetExpectationsForRootNodeCollectionForDivisionOnLoad(FunctionalLocationMode.GetAll(SiteConfigurationFixture.CreateSiteConfiguration()), nodes);
            presenter.LoadRootFunctionalLocations(mockFunctionalLocationLookup);
            mockView.VerifyAllExpectations();
            mockFunctionalLocationLookup.VerifyAllExpectations();
        }


        [Test][Ignore]
        public void ShouldOnlyLoadFlocsTheFirstTimeLoadIsCalled()
        {
            var nodes = new[] { new FunctionalLocationInfo(flocDiv1, true) };
            SetExpectationsForRootNodeCollectionForDivisionOnLoad(FunctionalLocationMode.GetAll(SiteConfigurationFixture.CreateSiteConfiguration()), nodes);

            // Call load a second time, and nothing should happen because the Nodes are already initialized.
            presenter.LoadRootFunctionalLocations(mockFunctionalLocationLookup);
            
            mockView.VerifyAllExpectations();
            mockFunctionalLocationLookup.VerifyAllExpectations();
        }
        #endregion

        #region UserSelectedFlocList

        [Test]
        public void SetUserSelectedFlocListToRootNodeShouldOnlyCheckFlocs()
        {
            List<FunctionalLocation> userSelectedFlocList = new List<FunctionalLocation> {flocDiv1};
            mockView.Expect(mock => mock.RootNodeCollection).Return(rootNodeCollection);
            mockView.Expect(m => m.SetNodeStateToUnchecked(new List<FunctionalLocation>()));
            mockView.Expect(m => m.SetNodeStateToChecked(userSelectedFlocList));
            presenter.UserSelectedFLOCList = userSelectedFlocList;
            
            mockView.VerifyAllExpectations();
            mockFunctionalLocationLookup.VerifyAllExpectations();

        }

        [Test]
        public void SetUserSelectedFlocListToAlreadyLoadedNodesShouldOnlyCheckFlocs()
        {
            mockView.Expect(mock => mock.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.LevelThreeAndAbove).Repeat.Any();
            mockView.Expect(mock => mock.RootNodeCollection).Return(rootNodeCollection);

            mockView.Expect(m => m.SetNodeStateToUnchecked(new List<FunctionalLocation>()));
            mockView.Expect(m => m.SetNodeStateToChecked(unitAndAboveFunctionalLocations));

            presenter.UserSelectedFLOCList = unitAndAboveFunctionalLocations;
            
            mockView.VerifyAllExpectations();
            mockFunctionalLocationLookup.VerifyAllExpectations();

        }

        [Test]
        public void SetUserSelectedFlocListForNotPreviouslyLoadedChildrenShouldLoadChildrenAndCheckFlocs()
        {
            mockView.Expect(mock => mock.FunctionalLocationTreeViewMode).Return(null);
            presenter.LoadRootFunctionalLocations(mockFunctionalLocationLookup);

            // + Div1
            // +-- Div1Sec1 (placeholder)
            // Previously selected flocs include both Div1 and Div1Sec1.

            var userSelectedFlocs = new List<FunctionalLocation> {flocDiv1, flocDiv1Sec1};

            nodeDiv1 = new FunctionalLocationTreeNode(flocDiv1, true);

            mockView.Expect(mock => mock.RootNodeCollection).Return(new[] { nodeDiv1 });
            mockView.Expect(mock => mock.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.LevelThreeAndAbove).Repeat.Any();

            var loadedSectionInfoFlocs = new List<FunctionalLocationInfo>();
            var sectionFlocInfo = new FunctionalLocationInfo(flocDiv1Sec1, false);
            loadedSectionInfoFlocs.Add(sectionFlocInfo);

            List<FunctionalLocationTreeNode> loadedSectionNodes = new List<FunctionalLocationTreeNode>
                                                                       {
                                                                           new FunctionalLocationTreeNode(
                                                                               sectionFlocInfo.Floc,
                                                                               sectionFlocInfo.HasChildren)
                                                                       };

            mockFunctionalLocationLookup.Expect(mock => mock.GetChildrenFor(flocDiv1)).Return(loadedSectionInfoFlocs);
            mockView.Expect(m => m.AddChildren(nodeDiv1, loadedSectionNodes));

            mockView.Expect(m => m.SetNodeStateToUnchecked(new List<FunctionalLocation>()));
            mockView.Expect(m => m.SetNodeStateToChecked(userSelectedFlocs));

            presenter.UserSelectedFLOCList = userSelectedFlocs;

            mockView.VerifyAllExpectations();
            mockFunctionalLocationLookup.VerifyAllExpectations();

        }

        [Test]
        public void ShouldReturnTheSameUserSelectedFLOCListWhenSetManually()
        {
            mockView.Expect(mock => mock.RootNodeCollection).Return(rootNodeCollection);
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateSiteConfiguration();
            mockView.Stub(mock => mock.FunctionalLocationTreeViewMode).Return(FunctionalLocationMode.GetLevelThreeAndBelow(siteConfiguration));

            // Naturally select a node (DIV2-SEC3-UN2)
            var args = new TreeViewEventArgs(nodeDiv2Sec3Un2, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv2Sec3Un2)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, args);

            // Manaully assign the UserSelectedFLOCList to a new node (DIV-SEC3-UN3)
            // This should clear out the previously selected node (DIV2-SEC3-UN2) and uncheck it.
            var expectedNewUserSelectedList = new List<FunctionalLocation> {flocDiv2Sec3Un3};
            mockView.Expect(m => m.SetNodeStateToUnchecked(new List<FunctionalLocation> {flocDiv2Sec3Un2}));
            mockView.Expect(m => m.SetNodeStateToChecked(new List<FunctionalLocation> { flocDiv2Sec3Un3 }));

            presenter.UserSelectedFLOCList = expectedNewUserSelectedList;
            
            IList<FunctionalLocation> actualNewUserSelectedFLOCList = presenter.UserSelectedFLOCList;
            Assert.AreEqual(expectedNewUserSelectedList, actualNewUserSelectedFLOCList);

            // Naturally select a node (DIV2-SEC3-UN4)
            // The UserSelectedFLOCList should now include this node and the (DIV2-SEC3-UN3)as it was naturaly selected.
            FunctionalLocation newSelectionAfterManualSelection = flocDiv2Sec3Un4;
            args = new TreeViewEventArgs(nodeDiv2Sec3Un4, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv2Sec3Un4)).Return(true);

            presenter.HandleFunctionalLocationSelected(null, args);

            expectedNewUserSelectedList.Add(newSelectionAfterManualSelection);
            actualNewUserSelectedFLOCList = presenter.UserSelectedFLOCList;
            Assert.AreEqual(expectedNewUserSelectedList, actualNewUserSelectedFLOCList);

            mockView.VerifyAllExpectations();
            mockFunctionalLocationLookup.VerifyAllExpectations();

        }

        #endregion

        #region HandleFunctionalLocationSelected

        [Test]
        public void ShouldAddNodeToUserSelectedListIfNodeIsChecked()
        {
            var eventArgs = new TreeViewEventArgs(nodeDiv1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, eventArgs);
            IList<FunctionalLocation> expectedList = new List<FunctionalLocation>(new[] {nodeDiv1.Tag});

            Assert.AreEqual(expectedList, presenter.UserSelectedFLOCList);
        }

        [Test]
        public void ShouldNotAddNodeToUserSelectedListIfNodeWasAlreadySelectedAndInTheList()
        {  
            var eventArgs = new TreeViewEventArgs(nodeDiv1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1)).Return(true);
            mockView.Expect(mock => mock.IsUnchecked(nodeDiv1)).Return(false);
            presenter.HandleFunctionalLocationSelected(null, eventArgs);
            Assert.AreEqual(1, presenter.UserSelectedFLOCList.Count);

            mockView.Expect(mock => mock.IsChecked(nodeDiv1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, eventArgs);
            Assert.AreEqual(1, presenter.UserSelectedFLOCList.Count);
        }
        [Test]
        public void ShouldReturnUserSelectedFlocListWithMoreThanOneItemsWhenMultipleNodesAreChecked()
        {
            IList<FunctionalLocation> expectedUserSelectedFlocList = new List<FunctionalLocation>
                                                                         {
                                                                             flocDiv1,
                                                                             flocDiv1Sec1
                                                                         };

            var args = new TreeViewEventArgs(nodeDiv1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, args);

            args = new TreeViewEventArgs(nodeDiv1Sec1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1Sec1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, args);

            Assert.AreEqual(expectedUserSelectedFlocList, presenter.UserSelectedFLOCList);
        }

        [Test]
        public void ShouldRemoveSelectedFLOCWhenANodeIsUnChecked()
        {
            ShouldAddNodeToUserSelectedListIfNodeIsChecked();

            var eventArgs = new TreeViewEventArgs(nodeDiv1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1)).Return(false);
            mockView.Expect(mock => mock.IsUnchecked(nodeDiv1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, eventArgs);

            Assert.AreEqual(0, presenter.UserSelectedFLOCList.Count);
        }

        [Test]
        public void ShouldReturnOnlyTopLevelUserSelectedNodeEvenWhenAChildIsSelectedFirst()
        {
            var args = new TreeViewEventArgs(nodeDiv1Sec1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1Sec1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, args);

            args = new TreeViewEventArgs(nodeDiv1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, args);

            Assert.AreEqual(new List<FunctionalLocation> { flocDiv1 }, presenter.UserSelectedFLOCList);
        }

        [Test]
        public void ShouldReturnOnlyTopMostLevelUserSelectedEvenWhenAGrandChildIsSelectedFirst()
        {
            var args = new TreeViewEventArgs(nodeDiv1Sec1Un1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1Sec1Un1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, args);

            args = new TreeViewEventArgs(nodeDiv1, TreeViewAction.Unknown);
            mockView.Expect(mock => mock.IsChecked(nodeDiv1)).Return(true);
            presenter.HandleFunctionalLocationSelected(null, args);

            Assert.AreEqual(new List<FunctionalLocation> { flocDiv1 }, presenter.UserSelectedFLOCList);
        }

        #endregion

        #region Test Helpers
        private void SetupFunctionalLocationTree()
        {
            //Divisions
            flocDiv1 = FunctionalLocationFixture.CreateNew(2, "DIV1");
            nodeDiv1 = new FunctionalLocationTreeNode(flocDiv1);

            flocDiv2 = FunctionalLocationFixture.CreateNew(3, "DIV2");
            nodeDiv2 = new FunctionalLocationTreeNode(flocDiv2);

            //Sections
            flocDiv1Sec1 = FunctionalLocationFixture.CreateNew(4, "DIV1-SEC1");
            nodeDiv1Sec1 = new FunctionalLocationTreeNode(flocDiv1Sec1);
            flocDiv2Sec2 = FunctionalLocationFixture.CreateNew(5, "DIV2-SEC2");
            nodeDiv2Sec2 = new FunctionalLocationTreeNode(flocDiv2Sec2);
            flocDiv2Sec3 = FunctionalLocationFixture.CreateNew(6, "DIV2-SEC3");
            nodeDiv2Sec3 = new FunctionalLocationTreeNode(flocDiv2Sec3);

            //Units
            flocDiv1Sec1Un1 = FunctionalLocationFixture.CreateNew(7, "DIV1-SEC1-UN1");
            nodeDiv1Sec1Un1 = new FunctionalLocationTreeNode(flocDiv1Sec1Un1);
            flocDiv2Sec3Un2 = FunctionalLocationFixture.CreateNew(8, "DIV2-SEC3-UN2");
            nodeDiv2Sec3Un2 = new FunctionalLocationTreeNode(flocDiv2Sec3Un2);
            flocDiv2Sec3Un3 = FunctionalLocationFixture.CreateNew(9, "DIV2-SEC3-UN3");
            nodeDiv2Sec3Un3 = new FunctionalLocationTreeNode(flocDiv2Sec3Un3);
            flocDiv2Sec3Un4 = FunctionalLocationFixture.CreateNew(10, "DIV2-SEC3-UN4");
            nodeDiv2Sec3Un4 = new FunctionalLocationTreeNode(flocDiv2Sec3Un4);
            flocDiv2Sec3Un5 = FunctionalLocationFixture.CreateNew(11, "DIV2-SEC3-UN5");
            nodeDiv2Sec3Un5 = new FunctionalLocationTreeNode(flocDiv2Sec3Un5);

            //EQ1
            flocDiv2Sec3Un5Eq1A = FunctionalLocationFixture.CreateNew(12, "DIV2-SEC3-UN5-EQ1A");
            nodeDiv2Sec3Un5Eq1A = new FunctionalLocationTreeNode(flocDiv2Sec3Un5Eq1A);
            flocDiv2Sec3Un5Eq1B = FunctionalLocationFixture.CreateNew(13, "DIV2-SEC3-UN5-EQ1B");
            nodeDiv2Sec3Un5Eq1B = new FunctionalLocationTreeNode(flocDiv2Sec3Un5Eq1B);

            //EQ2
            flocDiv2Sec3Un5Eq1AEq2A = FunctionalLocationFixture.CreateNew(14, "DIV2-SEC3-UN5-EQ1A-EQ2A");
            nodeDiv2Sec3Un5Eq1AEq2A = new FunctionalLocationTreeNode(flocDiv2Sec3Un5Eq1AEq2A);
            flocDiv2Sec3Un5Eq1AEq2B = FunctionalLocationFixture.CreateNew(15, "DIV2-SEC3-UN5-EQ1A-EQ2B");
            nodeDiv2Sec3Un5Eq1AEq2B = new FunctionalLocationTreeNode(flocDiv2Sec3Un5Eq1AEq2B);

            unitAndAboveFunctionalLocations = new List<FunctionalLocation>(new[] {
                flocDiv1, flocDiv2, flocDiv1Sec1, flocDiv2Sec2, flocDiv2Sec3, flocDiv1Sec1Un1, flocDiv2Sec3Un2, flocDiv2Sec3Un3,
                flocDiv2Sec3Un4, flocDiv2Sec3Un5
            });

            nodeDiv1.Nodes.Add(nodeDiv1Sec1);
            nodeDiv2.Nodes.Add(nodeDiv2Sec2);
            nodeDiv2.Nodes.Add(nodeDiv2Sec3);

            nodeDiv1Sec1.Nodes.Add(nodeDiv1Sec1Un1);
            nodeDiv2Sec3.Nodes.Add(nodeDiv2Sec3Un2);
            nodeDiv2Sec3.Nodes.Add(nodeDiv2Sec3Un3);
            nodeDiv2Sec3.Nodes.Add(nodeDiv2Sec3Un4);
            nodeDiv2Sec3.Nodes.Add(nodeDiv2Sec3Un5);

            nodeDiv2Sec3Un5.Nodes.Add(nodeDiv2Sec3Un5Eq1A);
            nodeDiv2Sec3Un5.Nodes.Add(nodeDiv2Sec3Un5Eq1B);

            nodeDiv2Sec3Un5Eq1A.Nodes.Add(nodeDiv2Sec3Un5Eq1AEq2A);
            nodeDiv2Sec3Un5Eq1A.Nodes.Add(nodeDiv2Sec3Un5Eq1AEq2B);

            rootNodeCollection = new[] { nodeDiv1, nodeDiv2 };
        }

        private void SetExpectationsForRootNodeCollectionForDivisionOnLoad(FunctionalLocationMode mode, IEnumerable<FunctionalLocationInfo> flocs)
        {
            var flocsAsList = new List<FunctionalLocationInfo>(flocs);
            var flocsAsNodes =
                new List<FunctionalLocationTreeNode>(
                    FunctionalLocationTreeNode.Convert(flocsAsList, mode));

            mockView.Stub(mock => mock.FunctionalLocationTreeViewMode).Return(mode);

            mockFunctionalLocationLookup.Expect(mock => mock.GetChildrenFor(testSite.IdValue)).Return(flocsAsList);
            mockView.Expect(m => m.RootNodeCollection).SetPropertyWithArgument(flocsAsNodes.ToArray());
        }
        #endregion
    }
}