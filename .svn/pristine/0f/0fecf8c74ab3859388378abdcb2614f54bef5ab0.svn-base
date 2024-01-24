using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ShiftSelectionFormPresenterTest
    {
        private Mockery mocks;
        private ShiftFormSelectionPresenter presenter;
        private IShiftSelectionForm mockView;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IShiftSelectionForm>();

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();

            List<ShiftPattern> dtos = new List<ShiftPattern>
                                                         {
                                                             dayShift,
                                                             nightShift
                                                         };

            presenter = new ShiftFormSelectionPresenter(mockView, dtos);
        }

        [Test]
        public void ShouldCallViewSetNoShiftSelectedErrorIfShiftIsNull()
        {
            Expect.Once.On(mockView).Method("ShiftWasSelected").Will(Return.Value(false));
            Expect.Once.On(mockView).SetProperty("SetNoShiftSelectedError").To(true);
            presenter.HandleAcceptButtonClick(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
