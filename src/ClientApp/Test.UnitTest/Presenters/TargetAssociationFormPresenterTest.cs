using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TargetAssociationFormPresenterTest
    {
        private TargetAssociationFormPresenter presenter;

        Mockery mocks;
        ITargetAssociationSelectionView mockView;
        ITargetDefinitionService serviceMock;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = (ITargetAssociationSelectionView) mocks.NewMock(typeof (ITargetAssociationSelectionView));
            serviceMock = (ITargetDefinitionService) mocks.NewMock(typeof (ITargetDefinitionService));
        }

        [Test]
        public void TestAddingAssociationThatAlreadyExistsDoesNotAddAdditionalAssociatedTargets()
        {
            TargetDefinitionDTO def = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1));
            List<TargetDefinitionDTO> associatedTargets = new List<TargetDefinitionDTO> {def};

            List<TargetDefinitionDTO> selectedTargets = new List<TargetDefinitionDTO> {def};

            presenter = new TargetAssociationFormPresenter(mockView, serviceMock, null);
            Expect.Once.On(mockView).GetProperty("AssociatedTargets").Will(Return.Value(associatedTargets));
            Expect.Once.On(mockView).GetProperty("SelectedTargets").Will(Return.Value(selectedTargets));

            Expect.Once.On(mockView).SetProperty("AssociatedTargets").To(associatedTargets);

            presenter.AddTargetAssociations(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void TestAddingAssociationToAnExistingList()
        {
            TargetDefinitionDTO def = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1));
            List<TargetDefinitionDTO> associatedTargets = new List<TargetDefinitionDTO> {def};

            TargetDefinitionDTO def2 = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(2));
            List<TargetDefinitionDTO> selectedTargets = new List<TargetDefinitionDTO> {def2};

            List<TargetDefinitionDTO> expectedResult = new List<TargetDefinitionDTO> {def, def2};

            presenter = new TargetAssociationFormPresenter(mockView, serviceMock, null);
            Expect.Once.On(mockView).GetProperty("AssociatedTargets").Will(Return.Value(associatedTargets));
            Expect.Once.On(mockView).GetProperty("SelectedTargets").Will(Return.Value(selectedTargets));

            Expect.Once.On(mockView).SetProperty("AssociatedTargets").To(IsList.Equal(expectedResult));

            presenter.AddTargetAssociations(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void TestRemovingAssociation()
        {
            TargetDefinitionDTO def = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1));
            TargetDefinitionDTO def2 = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(2));
            List<TargetDefinitionDTO> associatedTargets = new List<TargetDefinitionDTO> {def, def2};

            List<TargetDefinitionDTO> selectedTargets = new List<TargetDefinitionDTO> {def2};

            List<TargetDefinitionDTO> expectedResult = new List<TargetDefinitionDTO> {def};


            presenter = new TargetAssociationFormPresenter(mockView, serviceMock, null);
            Expect.Once.On(mockView).GetProperty("AssociatedTargets").Will(Return.Value(associatedTargets));
            Expect.Once.On(mockView).GetProperty("SelectedAssociatedTargets").Will(Return.Value(selectedTargets));

            Expect.Once.On(mockView).SetProperty("AssociatedTargets").To(IsList.Equal(expectedResult));
            Stub.On(mockView).SetProperty("RemoveButtonEnabled");
            presenter.RemoveTargetAssociations(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void TestRemovingAssociationWhereNoTargetsAreSelected()
        {
            TargetDefinitionDTO def = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1));
            TargetDefinitionDTO def2 = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(2));
            List<TargetDefinitionDTO> associatedTargets = new List<TargetDefinitionDTO> {def, def2};

            List<TargetDefinitionDTO> selectedTargets = new List<TargetDefinitionDTO>();

            List<TargetDefinitionDTO> expectedResult = new List<TargetDefinitionDTO> {def, def2};


            presenter = new TargetAssociationFormPresenter(mockView, serviceMock, null);
            Expect.Once.On(mockView).GetProperty("AssociatedTargets").Will(Return.Value(associatedTargets));
            Expect.Once.On(mockView).GetProperty("SelectedAssociatedTargets").Will(Return.Value(selectedTargets));

            Expect.Once.On(mockView).SetProperty("AssociatedTargets").To(IsList.Equal(expectedResult));
            Stub.On(mockView).SetProperty("RemoveButtonEnabled");
            
            presenter.RemoveTargetAssociations(null, null);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void TestSavingAssociationsToExistingTarget()
        {
            TargetDefinition parentTarget = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);
            TargetDefinitionDTO childTarget = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(2));

            List<TargetDefinitionDTO> associatedTargetDTOFromView = new List<TargetDefinitionDTO> {childTarget};

            presenter = new TargetAssociationFormPresenter(mockView, serviceMock, parentTarget);
            Expect.Once.On(mockView).GetProperty("AssociatedTargets").Will(Return.Value(associatedTargetDTOFromView));
            Expect.Once.On(serviceMock).Method("CheckCircularDependencyCreated").WithAnyArguments();
            Expect.Once.On(mockView).Method("CloseForm").WithNoArguments();

            presenter.SaveAssociations(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void TestSavingAssociationsToExistingTargetWhereCircularDependenctyIsFound()
        {
            TargetDefinition parentTarget = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);
            TargetDefinition childTarget = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);
            TargetDefinitionDTO childTargetAsDTO = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1));

            List<TargetDefinitionDTO> associatedTargets = new List<TargetDefinitionDTO> {childTargetAsDTO};

            LinkedTargetCircularReferenceException expectedException = new LinkedTargetCircularReferenceException(new long[] {1, 1}, childTarget);

            presenter = new TargetAssociationFormPresenter(mockView, serviceMock, parentTarget);
            Expect.Once.On(mockView).GetProperty("AssociatedTargets").Will(Return.Value(associatedTargets));
            Expect.Once.On(serviceMock).Method("CheckCircularDependencyCreated").WithAnyArguments().Will(Throw.Exception(expectedException));
            Expect.Never.On(mockView).Method("CloseForm").WithNoArguments();
            Expect.Once.On(mockView).Method("SetError").WithAnyArguments();

            presenter.SaveAssociations(null, EventArgs.Empty);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void TestSavingAssociationsToNewTarget()
        {
            TargetDefinition parentTarget = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            presenter = new TargetAssociationFormPresenter(mockView, serviceMock, parentTarget);

            LinkedTargetCircularReferenceException expectedException = new LinkedTargetCircularReferenceException(new long[] {1, 1}, TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1));
            Expect.Never.On(serviceMock).Method("CheckCircularDependencyCreated").WithAnyArguments().Will(Throw.Exception(expectedException));
            Expect.Once.On(mockView).Method("CloseForm").WithNoArguments();
            Expect.Never.On(mockView).Method("SetError").WithAnyArguments();

            presenter.SaveAssociations(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}