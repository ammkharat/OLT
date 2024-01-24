using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class FormGN75ATest
    {
        [Test]
        public void ShouldCloneAndCopyTheGN75BOnlyIfTheFormStatusIsNotClosed()
        {
            DateTime from = new DateTime(2014, 2, 3);
            DateTime to = new DateTime(2014, 2, 5);
            User user = UserFixture.CreateUserWithGivenId(1);
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            {
                FormGN75A formGn75A = FormGN75AFixture.CreateForInsert(floc, @from, to, FormStatus.Draft);
                formGn75A.AssociatedFormGN75BNumber = 1234;

                formGn75A.ConvertToClone(user, CreateGN75BDTO(1234, FormStatus.Approved, false));
                Assert.AreEqual(1234, formGn75A.AssociatedFormGN75BNumber);                
            }

            // deleted gn75B
            {
                FormGN75A formGn75A = FormGN75AFixture.CreateForInsert(floc, @from, to, FormStatus.Closed);
                formGn75A.AssociatedFormGN75BNumber = 1234;

                formGn75A.ConvertToClone(user, CreateGN75BDTO(1234, FormStatus.Approved, true));
                Assert.IsNull(formGn75A.AssociatedFormGN75BNumber);                
            }

            // closed gn75B
            {
                FormGN75A formGn75A = FormGN75AFixture.CreateForInsert(floc, @from, to, FormStatus.Closed);
                formGn75A.AssociatedFormGN75BNumber = 1234;

                formGn75A.ConvertToClone(user, CreateGN75BDTO(1234, FormStatus.Closed, false));
                Assert.IsNull(formGn75A.AssociatedFormGN75BNumber);                
            }
        }

        private FormEdmontonGN75BDTO CreateGN75BDTO(long id, FormStatus formStatus, bool deleted)
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormEdmontonGN75BDTO dto = new FormEdmontonGN75BDTO(id, formStatus, floc.FullHierarchy, floc.FullHierarchy, "Equipment type", "52423", 1, "Fred", 1, "Sally", Clock.Now, null, Clock.Now, deleted,0); //ayman Sarnia eip DMND0008992
            return dto;
        }
    }
}
