using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DirectiveDao : AbstractManagedDao, IDirectiveDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertDirective";
        private const string UPDATE_STORED_PROCEDURE = "UpdateDirective";
        private const string REMOVE_STORED_PROCEDURE = "RemoveDirective";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryDirectiveById";

        private const string INSERT_WORKASSIGNMENT_ASSOCIATIONS = "InsertDirectiveWorkAssignment";
        private const string DELETE_WORKASSIGNMENT_ASSOCIATIONS = "DeleteDirectiveWorkAssignmentByDirectiveId";

        private const string DELETE_FUNCTIONAL_LOCATION_ASSOCIATIONS = "DeleteDirectiveFunctionalLocationsByDirectiveId";

        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IRoleDao roleDao;
        private readonly IUserDao userDao;
        private readonly IWorkAssignmentDao workAssignmentDao;

        public DirectiveDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public void Insert(Directive directive)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(directive, AddInsertParameters, INSERT_STORED_PROCEDURE);
            directive.Id = long.Parse(idParameter.Value.ToString());

            InsertFunctionalLocations(command, directive);
            InsertWorkAssignments(command, directive);
            InsertNewDocumentLinks(directive);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(directive);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            if (directive.Imagelist != null)
            {
                InsertDirectivemage(directive);
            }

        }

        public Directive QueryById(long id)
        {
            //var command = ManagedCommand;
            //return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
            
            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

            Directive dir = ManagedCommand.QueryById<Directive>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
            if (dir != null)
            {
                SetDirectiveImage(dir);
            }

            return dir;
        }

        public void Update(Directive directive)
        {
            var command = ManagedCommand;

            command.Update(directive, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            RemoveFunctionalLocations(command, directive);
            InsertFunctionalLocations(command, directive);

            RemoveWorkAssignments(command, directive);
            InsertWorkAssignments(command, directive);

            RemoveDeletedDocumentLinks(directive);
            InsertNewDocumentLinks(directive);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(directive);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            if (directive.Imagelist != null)
            {
                InsertDirectivemage(directive);
            }

        }

        public void Remove(Directive directive)
        {
            var command = ManagedCommand;
            command.Remove(directive, REMOVE_STORED_PROCEDURE);
        }

        private static void AddUpdateParameters(Directive form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private static void AddInsertParameters(Directive directive, SqlCommand command)
        {
            SetCommonAttributes(directive, command);
            command.AddParameter("@CreatedByUserId", directive.CreatedBy.IdValue);
            command.AddParameter("@CreatedByRoleId", directive.CreatedByRole.IdValue);
            command.AddParameter("@CreatedByWorkAssignmentName", directive.CreatedByWorkAssignmentName);
            command.AddParameter("@CreatedDateTime", directive.CreatedDateTime);
            command.AddParameter("@MigrationSource", directive.MigrationSource);
            command.AddParameter("@ExtraInformationFromMigrationSource", directive.ExtraInfoFromMigrationSource);
        }

        private static void SetCommonAttributes(Directive directive, SqlCommand command)
        {
            command.AddParameter("@ActiveFromDateTime", directive.ActiveFromDateTime);
            command.AddParameter("@ActiveToDateTime", directive.ActiveToDateTime);
            command.AddParameter("@Content", directive.Content);
            command.AddParameter("@PlainTextContent", directive.PlainTextContent);
            command.AddParameter("@LastModifiedByUserId", directive.LastModifiedBy.IdValue);
            command.AddParameter("@LastModifiedDateTime", directive.LastModifiedDateTime);
        }

        private Directive PopulateInstance(SqlDataReader reader)
        {
       
            var id = reader.Get<long>("Id");

            var workAssignments = workAssignmentDao.QueryByDirectiveId(id);
            var flocs = flocDao.QueryByDirectiveId(id);
            var documentLinks = documentLinkDao.QueryByDirectiveId(id);

            var activeFromDateTime = reader.Get<DateTime>("ActiveFromDateTime");
            var activeToDateTime = reader.Get<DateTime>("ActiveToDateTime");

            var content = reader.Get<string>("Content");
            var plainTextContent = reader.Get<string>("PlainTextContent");
            var createdByWorkAssignmentName = reader.Get<string>("CreatedByWorkAssignmentName");

            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var createdByRole = roleDao.QueryById(reader.Get<long>("CreatedByRoleId"));

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var directive = new Directive(activeFromDateTime, activeToDateTime, content, plainTextContent,
                lastModifiedBy, lastModifiedDateTime, createdBy, createdByRole, createdDateTime);
            directive.Id = id;
            directive.WorkAssignments = workAssignments;
            directive.FunctionalLocations = flocs;
            directive.CreatedByWorkAssignmentName = createdByWorkAssignmentName;
            directive.DocumentLinks = documentLinks;
            directive.MigrationSource = reader.Get<string>("MigrationSource");
            directive.ExtraInfoFromMigrationSource = reader.Get<string>("ExtraInformationFromMigrationSource");

            return directive;
        }

        private void InsertFunctionalLocations(SqlCommand command, Directive directive)
        {
            if (!directive.FunctionalLocations.IsEmpty())
            {
                command.CommandText = "InsertDirectiveFunctionalLocation";
                foreach (var functionalLocation in directive.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@DirectiveId", directive.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void RemoveFunctionalLocations(SqlCommand command, Directive directive)
        {
            command.CommandText = DELETE_FUNCTIONAL_LOCATION_ASSOCIATIONS;
            command.Parameters.Clear();
            command.AddParameter("@DirectiveId", directive.IdValue);
            command.ExecuteNonQuery();
        }

        private void InsertWorkAssignments(SqlCommand command, Directive directive)
        {
            if (!directive.WorkAssignments.IsEmpty())
            {
                command.CommandText = INSERT_WORKASSIGNMENT_ASSOCIATIONS;

                foreach (var workAssignment in directive.WorkAssignments)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@DirectiveId", directive.IdValue);
                    command.AddParameter("@WorkAssignmentId", workAssignment.IdValue);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void RemoveWorkAssignments(SqlCommand command, Directive directive)
        {
            command.CommandText = DELETE_WORKASSIGNMENT_ASSOCIATIONS;
            command.Parameters.Clear();
            command.AddParameter("@DirectiveId", directive.IdValue);
            command.ExecuteNonQuery();
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByDirectiveId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedDirective);
        }

//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        private void InsertDirectivemage(Directive Dir)
        {

            foreach (ImageUploader Img in Dir.Imagelist)
            {
                if (Img.Id == 0 && Img.Action != "Remove")
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "InsertImageData";
                    command.AddParameter("@ItemID", Dir.IdValue);
                    command.AddParameter("@Name", Img.Name);
                    command.AddParameter("@Description", Img.Description);
                    command.AddParameter("@ImagePath", Img.ImagePath);
                    command.AddParameter("@Createdby", Dir.CreatedBy.Id);
                    command.AddParameter("@CreatedDate", Dir.CreatedDateTime);
                    command.AddParameter("@RecordType", (int)Img.Types);
                    command.AddParameter("@RecordFor ", (int)Img.RecordType);
                    command.ExecuteNonQuery();
                }
                else if (Convert.ToString(Img.Action).ToUpper() == "Remove".ToUpper())
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "RemoveImageData";
                    command.AddParameter("@Id", Img.Id);

                    command.ExecuteNonQuery();

                }
                else if (Img.Id > 0)
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "UpdateImageData";
                    command.AddParameter("@ID", Img.IdValue);
                    command.AddParameter("@Name", Img.Name);
                    command.AddParameter("@Description", Img.Description);
                    command.ExecuteNonQuery();
                }
            }

        }

        private void SetDirectiveImage(Directive Dir)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "GetItemImage";
            command.AddParameter("@ItemIDs", Dir.Id);
            command.AddParameter("@RecordFor", (int)ImageUploader.RecordTypes.Directive);
            SqlDataReader reader = command.ExecuteReader();
            List<ImageUploader> lst = new List<ImageUploader>();
            while (reader.Read())
            {
                ImageUploader Img = new ImageUploader();
                Img.Id = reader.Get<long>("Id");
                Img.Name = reader.Get<string>("Name");
                Img.Description = reader.Get<string>("Description");
                Img.ImagePath = reader.Get<string>("ImagePath");
                Img.Action = "";


                if (reader.Get("RecordType") != null && reader.Get<int>("RecordType") == 0)
                {
                    //Img.Types = ActionItemImage.Type.Title;
                }
                else
                {
                    Img.Types = ImageUploader.Type.Image;
                }

                if (reader.Get("RecordFor") != null && reader.Get<int>("RecordFor") == 1)
                {
                    Img.RecordType = ImageUploader.RecordTypes.Directive;
                }
                else
                {
                    Img.RecordType = ImageUploader.RecordTypes.ActionItemDef;
                }




                lst.Add(Img);
            }
            reader.Dispose();
            Dir.Imagelist = lst;
        }


    }
}