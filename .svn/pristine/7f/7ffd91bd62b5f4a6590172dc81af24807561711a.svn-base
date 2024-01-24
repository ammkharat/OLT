using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NMock2.Internal;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class FormTemplateDaoTest : AbstractDaoTest
    {
        private IFormTemplateDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormTemplateDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldFindByFormTypeId()
        {
            List<FormTemplate> formTemplates = dao.QueryByFormType(EdmontonFormType.GN7,8);
            Assert.AreEqual(1, formTemplates.Count);
            Assert.AreEqual(EdmontonFormType.GN7, formTemplates[0].FormType);
        }

        [Ignore] [Test]
        public void ShouldFindByFormTypeIdAndKey()
        {
            Assert.IsNotNull(dao.QueryByFormTypeAndKey(EdmontonFormType.GN1, FormTemplateKeys.GN1_PLANNING_WORKSHEET));
            Assert.IsNotNull(dao.QueryByFormTypeAndKey(EdmontonFormType.GN6, FormTemplateKeys.GN6_OTHER));
            Assert.IsNull(dao.QueryByFormTypeAndKey(EdmontonFormType.GN1, "This is not a real key."));
        }

        [Ignore] [Test]
        public void ShouldReplaceFormTemplate()
        {
            const string newTemplateText = "BICYCLE!!!!!!!!!!!!!";
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            List<FormTemplate> formTemplates = dao.QueryByFormType(EdmontonFormType.GN7,8);
            formTemplates[0].Template = newTemplateText;
            dao.Replace(formTemplates[0], user, Clock.Now,user.AvailableSites.First().IdValue);

            FormTemplate requeried = dao.QueryByFormType(EdmontonFormType.GN7,8)[0];
            Assert.AreEqual(newTemplateText, requeried.Template);
            Assert.AreNotEqual(formTemplates[0].Id, requeried.Id);
        }

        [Test]
        [Ignore]
        public void ExportSomeRTF()
        {
            FormTemplate formTemplate = dao.QueryByFormTypeAndKey(EdmontonFormType.GN1, "cseinitialentryandreviewpage");

            using(FileStream stream = File.OpenWrite(@"c:\dev\buffer\rtf-output-auto.txt"))
            {
                using(StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                {
                    writer.Write(formTemplate.Template);
                    writer.Flush();
                }               
            }
        }
    }
}
