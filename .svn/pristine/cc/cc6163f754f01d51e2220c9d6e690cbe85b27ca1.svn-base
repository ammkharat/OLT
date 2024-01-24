using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class FunctionalLocationSearchResultTest
    {
        [Test]
        public void ShouldMoveToOrJustBefore()
        {
            AssertMoveToOrJustBefore(0);
            AssertMoveToOrJustBefore(1);
            AssertMoveToOrJustBefore(2);
            AssertMoveToOrJustBefore(4);
            AssertMoveToOrJustBefore(3);
        }

        private static FunctionalLocationSearchResult GetResult(int numberOfSetupMoveNexts)
        {
            List<FunctionalLocationDTO> dtos = new List<FunctionalLocationDTO>
            {
                new FunctionalLocationDTO(1, "a1"),
                new FunctionalLocationDTO(2, "b1"),
                new FunctionalLocationDTO(3, "c1")
            };

            FunctionalLocationSearchResult result = new FunctionalLocationSearchResult(dtos);
            for (int i = 0; i < numberOfSetupMoveNexts; i++)
            {
                result.MoveNext();
            }
            return result;
        }

        private static void AssertMoveToOrJustBefore(int numberOfSetupMoveNexts)
        {
            {
                FunctionalLocationSearchResult result = GetResult(numberOfSetupMoveNexts);
                result.MoveToOrJustBefore(CreateFloc(999, "a0"));
                Assert.IsTrue(result.MoveNext());
                Assert.AreEqual(1, result.Current.Id);
            }
            {
                FunctionalLocationSearchResult result = GetResult(numberOfSetupMoveNexts);
                result.MoveToOrJustBefore(CreateFloc(1, "a1"));
                Assert.AreEqual(1, result.Current.Id);
            }

            {
                FunctionalLocationSearchResult result = GetResult(numberOfSetupMoveNexts);
                result.MoveToOrJustBefore(CreateFloc(999, "b0"));
                Assert.AreEqual(1, result.Current.Id);
            }
            {
                FunctionalLocationSearchResult result = GetResult(numberOfSetupMoveNexts);
                result.MoveToOrJustBefore(CreateFloc(2, "b1"));
                Assert.AreEqual(2, result.Current.Id);
            }
            {
                FunctionalLocationSearchResult result = GetResult(numberOfSetupMoveNexts);
                result.MoveToOrJustBefore(CreateFloc(999, "c0"));
                Assert.AreEqual(2, result.Current.Id);
            }
            {
                FunctionalLocationSearchResult result = GetResult(numberOfSetupMoveNexts);
                result.MoveToOrJustBefore(CreateFloc(3, "c1"));

                bool moveNext = result.MoveNext();
                Assert.IsTrue(!moveNext || 1 == result.Current.Id);
            }
            {
                FunctionalLocationSearchResult result = GetResult(numberOfSetupMoveNexts);
                result.MoveToOrJustBefore(CreateFloc(999, "d0"));
                Assert.IsTrue(result.MoveNext());
                Assert.AreEqual(1, result.Current.Id);
            }
        }

        private static FunctionalLocation CreateFloc(long id, string division)
        {
            return new FunctionalLocation(id, null, division, null, false, false, 0, "en", FunctionalLocationSource.SAP);
        }
    }
}
