using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class DirectiveFixture
    {
        public static Directive CreateForInsert()
        {
            var user = UserFixture.CreateUserWithGivenId(1);
            var role = RoleFixture.GetRealRoleA(Site.SARNIA_ID);

            var directive = new Directive(new DateTime(2013, 2, 20, 9, 30, 0), new DateTime(2013, 2, 25, 11, 59, 59),     
                "content", "ptcontent", user, new DateTime(2013, 2, 20),
                user, role, new DateTime(2013, 2, 19));

            directive.WorkAssignments = WorkAssignmentFixture.GetListOfEdmontonWorkAssigments();
            directive.DocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();

            return directive;
        }
    }
}