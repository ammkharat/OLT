using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Remote.Caching;
using System.Net.Mail;
using System.Text;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using DevExpress.XtraRichEdit.API.Word;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.Services;

public partial class EmailApprove : System.Web.UI.Page
{
    private IDocumentLinkDao documentLinkDao;
    private FormOP14Dao formDao;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
            using (SqlConnection _connection = new SqlConnection(connStr))
            {
                long Id = long.Parse(Request.QueryString["ID"]);
                _connection.Open();
                //string connStr = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "QueryFormOP14ById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    csdFormID.Text = dr["Id"].ToString();
                    txtStartDate.Text = dr["ValidFromDateTime"].ToString();
                    // formop14.Content = dr["Content"].ToString();
                    formStatusId.Text = dr["ValidToDateTime"].ToString();
                    approveId.Text = Request.QueryString["reqid"];
                    //  formop14.CreatedByUserId = long.Parse(dr["CreatedByUserId"].ToString());
                    // formop14.CreatedDateTime = dr["CreatedDateTime"].ToString();
                    lastModifiedByUserId.Text = dr["LastModifiedByUserId"].ToString();
                    siteid.Text = dr["siteid"].ToString();
                    approvedByUserId.Text = Request.QueryString["approvedByUserId"];
                    // formop14.Deleted = Convert.ToBoolean(dr["Deleted"]);
                    criticalSystemDefeated.Text = dr["CriticalSystemDefeated"].ToString();
                    shouldBeEnabledBehaviourId.Text = 1.ToString(); //Request.QueryString["shouldBeEnabledBehaviourId"];
                    enabled.Text =Request.QueryString["enabled"];
                    txtRole.Text = Request.QueryString["approver"];
                    //formop14.IsSCADAsupportRequired = Convert.ToBoolean(dr["IsSCADAsupportRequired"]);
                    //formop14.siteid = long.Parse(dr["siteid"].ToString());
                }
                dr.Close();
            }

        }

    }


    
private void UpdateData(long Id, int formStatusId, string criticalSystemDefeated, long lastModifiedByUserId, long siteid, long approveId, long approvedByUserId, string approvalDateTime, int shouldBeEnabledBehaviourId, int enabled)
    {
       // int success = 1;
         string  LastModifiedDateTime = DateTime.Now.AddHours(2).ToString();

        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
       //formDao = DaoRegistry.GetDao<IFormOP14Dao>();
      //formDao = new FormOP14Dao();
       FormOP14 frm = QueryById(Id);
      // frm.LastModifiedDateTime = GetCurrentTimeAtSite(frm.FunctionalLocations[0]);
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            //string connStr = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "UpdateFormOP14";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@FormStatusId", formStatusId);
            cmd.Parameters.AddWithValue("@ValidFromDateTime", frm.FromDateTime);
            cmd.Parameters.AddWithValue("@ValidToDateTime", frm.ToDateTime);
            cmd.Parameters.AddWithValue("@ApprovedDateTime",approvalDateTime);
            cmd.Parameters.AddWithValue("@ClosedDateTime", frm.ClosedDateTime);
            cmd.Parameters.AddWithValue("@Content", frm.Content);
            cmd.Parameters.AddWithValue("@PlainTextContent", frm.PlainTextContent);
            cmd.Parameters.AddWithValue("@IsTheCSDForAPressureSafetyValve", frm.IsTheCSDForAPressureSafetyValve);
            cmd.Parameters.AddWithValue("@CriticalSystemDefeated", criticalSystemDefeated);
            cmd.Parameters.AddWithValue("@DepartmentId", frm.Department.Id);

            cmd.Parameters.AddWithValue("@LastModifiedByUserId", lastModifiedByUserId);
            cmd.Parameters.AddWithValue("@LastModifiedDateTime",LastModifiedDateTime);
           cmd.Parameters.AddWithValue("@siteid", siteid);       //ayman generic forms
            cmd.Parameters.AddWithValue("@IsSCADAsupportRequired", frm.IsSCADASupport);


            //cmd.Parameters.AddWithValue("@CriticalSystemDefeated", criticalSystemDefeated);


           // cmd.Parameters.AddWithValue("@LastModifiedByUserId", lastModifiedByUserId);
           // cmd.Parameters.AddWithValue("@LastModifiedDateTime", LastModifiedDateTime);
           // cmd.Parameters.AddWithValue("@siteid", siteid);

            int success = cmd.ExecuteNonQuery();
            if (success > 0)
            {
                cmd.Dispose();
            }
        }
        UpdateFunctionalLocations(frm);
       
        UpdateApprovals(Id, approvedByUserId, approvalDateTime, shouldBeEnabledBehaviourId, enabled,approveId);

       // FormOP14Dao dao=new FormOP14Dao();
        //FormOP14 opform = dao.QueryById(Id);
        InsertNewDocumentLinksApproval(frm);
        RemoveDeletedDocumentLinksApproval(frm);
         TakeSnapshot(frm);

        // return success;
    }
    private  void UpdateFunctionalLocations(FormOP14 frm)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();

        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "DeleteFormOP14FunctionalLocationsByFormOP14Id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FormOP14Id", frm.Id);

            int success = cmd.ExecuteNonQuery();

            if (success > 0)
            {

                InsertFunctionalLocations(frm);
            }
            cmd.Dispose();
        }
    }

    private void InsertFunctionalLocations(FormOP14 frm)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        //formDao = DaoRegistry.GetDao<IFormOP14Dao>();
       // formDao= new FormOP14Dao();
       // FormOP14 frm = QueryById(Id);
        if (!frm.FunctionalLocations.IsEmpty())
        {
            //command.CommandText = INSERT_FORM_FUNCTIO
            foreach (FunctionalLocation functionalLocation in frm.FunctionalLocations)
            {
                using (SqlConnection _connection = new SqlConnection(connStr))
                {

                    _connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _connection;
                    cmd.CommandText = "InsertFormOP14FunctionalLocation";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormOP14Id", frm.Id);
                    cmd.Parameters.AddWithValue("@FunctionalLocationId", functionalLocation.Id);


                    int success = cmd.ExecuteNonQuery();

                    if (success > 0)
                    {
                        cmd.Dispose();
                    }
               }
            }
        
       



        }

    }

    private void RemoveDeletedDocumentLinksApproval(IDocumentLinksObject obj)
    {
       // documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        RemoveDeletedDocumentLinks(obj, QueryByFormOP14DocumentId);
    }
    public void RemoveDeletedDocumentLinks(IDocumentLinksObject documentLinksObject,
           QueryDocumentLinksByDomainObjectId queryDocumentLinksByDomainObjectId)
    {
        var retrievedLinks = queryDocumentLinksByDomainObjectId(documentLinksObject.IdValue);

        // NOTE: If you call 'Remove' directly on this same DAO below, it will not work because
        //       'QueryDocumentLinksByDomainObjectId' closes the connection on the current thread.
        //       So, we get the DAO again to obtain a new connection.
        var documentLinkDaoWithNewSqlConnection = DaoRegistry.GetDao<IDocumentLinkDao>();

        foreach (var retrievedLink in retrievedLinks)
        {
            if (!documentLinksObject.DocumentLinks.Exists(link => link.Id == retrievedLink.Id))
            {
                Remove(retrievedLink);
            }
        }
    }

    public void Remove(DocumentLink documentLink)
    {
        //ManagedCommand.ExecuteNonQuery(documentLink, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.Parameters.AddWithValue("@Id", documentLink.Id);
            cmd.ExecuteNonQuery();
        }
    }
   


    private void InsertNewDocumentLinksApproval(IDocumentLinksObject obj)
    {
       InsertNewDocumentLinks(obj,InsertForAssociatedFormOP14);
    }
   private  void InsertForAssociatedFormOP14(DocumentLink documentLink, long formOP14Id)
    {
        formOP14Id = long.Parse(csdFormID.Text);
        //const string parameterName = "@FormOP14Id";
        const string parameterName = "@FormOP14Id";
        Insert(documentLink, parameterName, formOP14Id);
       

       // Insert(documentLink, parameterName, formOP14Id);
    }
    private void Insert(DocumentLink documentLink, string parameterName, long associatedId)
    {

        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "InsertDocumentLink";
            SqlParameter parameter = new SqlParameter("@Id", SqlDbType.BigInt);
            parameter.Direction=ParameterDirection.Output;
            cmd.Parameters.Add(parameter);
            cmd.Parameters.AddWithValue(parameterName, associatedId);
            cmd.Parameters.AddWithValue("@Link", documentLink.Url);
            cmd.Parameters.AddWithValue("@Title", documentLink.Title);
            cmd.ExecuteNonQuery();
            documentLink.Id =cmd.Parameters["@Id"].GetValue<long>();  

        }
        
    }

    public void InsertNewDocumentLinks(IDocumentLinksObject documentLinksObject,
           InsertDocumentLinkForAssociatedDomainObjectId insertDocumentLinkForAssociatedDomainObjectId)
    {
        if (documentLinksObject.DocumentLinks != null)                        //ayman custom fields DMND0010030
            foreach (var documentLink in documentLinksObject.DocumentLinks)
            {
                //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
                //if (!documentLink.IsInDatabase())
                //{
                //    insertDocumentLinkForAssociatedDomainObjectId(documentLink, documentLinksObject.IdValue);
                //}
                insertDocumentLinkForAssociatedDomainObjectId(documentLink, documentLinksObject.IdValue);
                //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            }

    }


    private void UpdateApprovals(long Id, long ApprovedByUserId, string ApprovalDateTime, int ShouldBeEnabledBehaviourId, int Enabled, long approveId)
    {

        //formDao = DaoRegistry.GetDao<IFormOP14Dao>();
        //formDao=new FormOP14Dao();
        FormOP14 oform = QueryById(Id);

        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();

       
            using (SqlConnection _connection = new SqlConnection(connStr))
            {

                _connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "UpdateFormOP14Approval";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", approveId);
                cmd.Parameters.AddWithValue("@ApprovedByUserId", ApprovedByUserId);
                cmd.Parameters.AddWithValue("@ApprovalDateTime", ApprovalDateTime);
                cmd.Parameters.AddWithValue("@ShouldBeEnabledBehaviourId", ShouldBeEnabledBehaviourId);
                cmd.Parameters.AddWithValue("@Enabled", Enabled);

                int success = cmd.ExecuteNonQuery();

                if (success > 0)
                {
                    cmd.Dispose();
                }



            
        }

    }
    [WebMethod]
    public static string GetCurrentTime(string name)
    {
        return "Hello " + name + Environment.NewLine + "The Current Time is: "
            + DateTime.Now.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
          long Id =long.Parse(csdFormID.Text);
          int FormStatusId=2;
          string crsystemdefet = criticalSystemDefeated.Text;
          long siteId = long.Parse(siteid.Text);
          long approveID = long.Parse(approveId.Text);//long.Parse( Request.QueryString["reqid"]);
          long approvedByuserId = long.Parse(approvedByUserId.Text);
          string approvalDateTime = DateTime.Now.AddHours(2).ToString();
          int shouldbeEnabledBehaviourId = int.Parse(shouldBeEnabledBehaviourId.Text);
          long userID = long.Parse(approvedByUserId.Text); //long.Parse(Request.QueryString["approvedByUserId"]);
          FormOP14 frm = this.QueryById(Id);
      
         int Enabled = int.Parse(enabled.Text);
           // , int formStatusId, string criticalSystemDefeated, long lastModifiedByUserId, long siteid, long approveId, long approvedByUserId, string approvalDateTime, int shouldBeEnabledBehaviourId, int enabled

        string select = DropDownList1.SelectedValue;
        if (select == "Approve")
        {
            //if (frm.FormStatus.Id == 1)
            //{
            //    string message = "CSD form ahs been Rejected and form status is in DRAFT state.Please close the Approval Form Thank You!!";
            //    string script = "window.onload = function(){ alert('";
            //    script += message;
            //    script += "')};";
            //    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            //}
            //else
            //{
            //    if (frm.FormStatus.Id == 2)
            //    {
                   
                   var approval = frm.Approvals.FirstOrDefault(p => p.Id == approveID);
                    if (approval.ApprovedByUser != null)
                    {
                        string message = "Approval for this CSD by the said role has already been provided.Please close the Approval Form Thank You!!";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "')};";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                      
                    }
                    else
                    {
                         
                          UpdateData(Id, FormStatusId, crsystemdefet, userID, siteId, approveID, approvedByuserId,
                   approvalDateTime, shouldbeEnabledBehaviourId, Enabled);
                          Response.Redirect("Response.aspx");
                    }
                    
                
                //}
            //    else
            //    {
            //        UpdateData(Id, FormStatusId, crsystemdefet, userID, siteId, approveID, approvedByuserId,
            //       approvalDateTime, shouldbeEnabledBehaviourId, Enabled);
            //        Response.Redirect("Response.aspx");
            //    }

            //    ////FormApproval approval=this.QueryByFormOP14Id(
            //    //UpdateData(Id, FormStatusId, crsystemdefet, userID, siteId, approveID, approvedByuserId,
            //    //    approvalDateTime, shouldbeEnabledBehaviourId, Enabled);
            //}

          
           

        }
        else
        {
            var approval = frm.Approvals.FirstOrDefault(p => p.Id == approveID);
            if (approval.ApprovedByUser != null)
            {
                string message = "Approval for this CSD by the said role has already been provided.Please close the Approval Form Thank You!!";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            }
            else
            {


                FormStatusId = 1;
                UpdateData(Id, FormStatusId, crsystemdefet, userID, siteId, approveID, approvedByuserId,
                    approvalDateTime, shouldbeEnabledBehaviourId, Enabled);
                string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
                User user = QueryByUserId(approvedByuserId);
                // long siteId = long.Parse(siteid.Text);
                using (SqlConnection _connection = new SqlConnection(connStr))
                {
                    long formOP14Id = long.Parse(csdFormID.Text);
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _connection;
                    cmd.CommandText = "QueryFormApprovalsByFormOP14Id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormOP14Id", formOP14Id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {


                        string approver = dr["Approver"].ToString();
                        bool isMailSent = Convert.ToBoolean(dr["isMailSent"]);
                        SqlCommand cmdapprover = new SqlCommand();
                        cmdapprover.Connection = _connection;
                        cmdapprover.CommandText = "QueryFormGenericTemplateEmailApproverBySiteandFormTypeid";
                        cmdapprover.CommandType = CommandType.StoredProcedure;
                        cmdapprover.Parameters.AddWithValue("@SiteId", siteId);
                        cmdapprover.Parameters.AddWithValue("@FormTypeID", 3);
                        cmdapprover.Parameters.AddWithValue("@Approver", approver);
                        SqlDataReader drapprover = cmdapprover.ExecuteReader();
                        while (drapprover.Read())
                        {
                            string emailList = drapprover["EmailList"].ToString();

                            if (isMailSent)
                            {
                                bool isBodyHtml = true;
                                var smtpServer = EmailSettings.SMTPServerURL;
                                var port = EmailSettings.SMTPServerPort;
                                var fromEmailAddress = EmailSettings.FromEmailAddress;
                                var mailSender = new SMTPMailSender(smtpServer, port, new EmailAddress(fromEmailAddress));
                                string bodyText = BuildBodyText(user.FullName, txtComment.Text);

                                mailSender.SendEmail(fromEmailAddress, emailList, bodyText,
                                    "CSD#" + csdFormID.Text + " has been REJECTED");
                            }
                        }
                        drapprover.Close();

                    }
                    dr.Close();

                }
                Response.Redirect("Response.aspx");
                
            }

        }
        //string message = "CSD details has been saved successfully.";
        //string script = "window.onload = function(){ alert('";
        //script += message;
        //script += "')};";
        //ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

      
    }
    private string BuildBodyText(string username,string comment)
    {
        // var introText = "OP-14 Critical System Defeat Form#" + editObject.FormNumber + " is waiting for approval. Please log into OLT to review and approve.\n\n" + "Review the change prior to approving.";

        //string introText = "<body>"+
        //        " OP-14 Critical System Defeat Form#"+editObject.FormNumber+"is waiting for approval."+"<br/><br/> Please check the document prior to approving.<br/><br/><br/>"+
        //        "<button id=\"btnAccept\" type=\"button\" value=\"button\">Accept</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+
        //        "<button id=\"btnReject\" type=\"button\" value=\"button\">Reject</button>"+
        //       "</body>";


        
        string introText = "<!DOCTYPE html>" +
                           "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
                           "<head>" +
                          "<div>" +
                            "Hi," + "<br/><br/> The above CSD Form has been Rejected by: " + username +" or his Delegate.It has now moved to DRAFT status." + "<br/><br/>" +
                           "<b>Comments:</b>" +" "+ comment + "." + "<br/><br/><br/><br/>" +"Thanks,</br>"+"OLT Support Team" + 

                           "</body>" +

                           "</html>";
        //var workAssignments = configuration.WorkAsosignments;

        var builder = new StringBuilder();

        builder.AppendLine(introText);
        builder.AppendLine();



        return builder.ToString();
    }
    public FormOP14 QueryById(long id)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();

        
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            FormOP14 frmOp14;
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "QueryFormOP14ById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader drform = cmd.ExecuteReader();
            FormOP14 form;
            while (drform.Read())
            {
                FormStatus formStatus = FormStatus.GetById(drform.Get<int>("FormStatusId"));

                DateTime validFromDateTime = drform.Get<DateTime>("ValidFromDateTime");
                DateTime validToDateTime = drform.Get<DateTime>("ValidToDateTime");

                List<FunctionalLocation> functionalLocations = QueryByFormOP14Id(id);
                List<FormApproval> approvals = QueryByFormApprovalOP14Id(id);
                List<DocumentLink> documentLinks = QueryByFormOP14DocumentId(id);


                string content = drform.Get<string>("Content");
                string plainTextContent = drform.Get<string>("PlainTextContent");


                DateTime? approvedDateTime = drform.Get<DateTime?>("ApprovedDateTime");
                DateTime? closedDateTime = drform.Get<DateTime?>("ClosedDateTime");

                bool isTheCSDForAPressureSafetyValve = drform.Get<bool>("IsTheCSDForAPressureSafetyValve");
                string criticalSystemDefeated = drform.Get<string>("CriticalSystemDefeated");
                int departmentId = drform.Get<int>("DepartmentId");
                FormOP14Department department = FormOP14Department.GetById(departmentId);

                User createdBy = QueryByUserId(drform.Get<long>("CreatedByUserId"));
                DateTime createdDateTime = drform.Get<DateTime>("CreatedDateTime");

                User lastModifiedBy = QueryByUserId(drform.Get<long>("LastModifiedByUserId"));
                DateTime lastModifiedDateTime = drform.Get<DateTime>("LastModifiedDateTime");

                long siteId = drform.Get<long>("siteid");

                bool isMailSent = true; // reader.Get<bool>("isMailSent");
                if (siteId == 1)
                {
                    form = new FormOP14(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime, siteId, isMailSent);
                    form.FunctionalLocations = functionalLocations;
                    form.Approvals = approvals;
                    form.LastModifiedBy = lastModifiedBy;
                    form.DocumentLinks = documentLinks;
                    form.LastModifiedDateTime = lastModifiedDateTime;
                    form.ApprovedDateTime = approvedDateTime;
                    form.ClosedDateTime = closedDateTime;
                    form.Content = content;
                    form.PlainTextContent = plainTextContent;
                    form.Department = department;
                    form.IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve;
                    form.CriticalSystemDefeated = criticalSystemDefeated;
                    //DMND0010261-SELC CSD EdmontonPipeline
                    if (ColumnExists(drform, "IsSCADAsupportRequired"))
                    {
                        if (drform.Get<bool>("IsSCADAsupportRequired") != null)
                        {
                            form.IsSCADASupport = drform.Get<bool>("IsSCADAsupportRequired");
                        }
                    }
                    //end DMND0010261-SELC CSD EdmontonPipeline
                    return form;
                }
                else
                {
                    form = new FormOP14(id, formStatus, validFromDateTime, validToDateTime, createdBy, createdDateTime, siteId);
                    form.FunctionalLocations = functionalLocations;
                    form.Approvals = approvals;
                    form.LastModifiedBy = lastModifiedBy;
                    form.DocumentLinks = documentLinks;
                    form.LastModifiedDateTime = lastModifiedDateTime;
                    form.ApprovedDateTime = approvedDateTime;
                    form.ClosedDateTime = closedDateTime;
                    form.Content = content;
                    form.PlainTextContent = plainTextContent;
                    form.Department = department;
                    form.IsTheCSDForAPressureSafetyValve = isTheCSDForAPressureSafetyValve;
                    form.CriticalSystemDefeated = criticalSystemDefeated;

                    //DMND0010261-SELC CSD EdmontonPipeline
                    if (ColumnExists(drform, "IsSCADAsupportRequired"))
                    {
                        if (drform.Get<bool>("IsSCADAsupportRequired") != null)
                        {
                            form.IsSCADASupport = drform.Get<bool>("IsSCADAsupportRequired");
                        }
                    }
                    return form;
                }
            }


            return null;  
            
        }
        
    }
    public bool ColumnExists(IDataReader reader, string columnName)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
    public List<DocumentLink> QueryByFormOP14DocumentId(long id)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "QueryDocumentLinkByFormOP14Id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FormOP14Id", id);
            SqlDataReader drDoc = cmd.ExecuteReader();
            List<DocumentLink> result = new List<DocumentLink>();
            while (drDoc.Read())
            {
                var link = drDoc.Get<string>("Link");
                var title = drDoc.Get<string>("Title");

               result.Add(new DocumentLink(link, title) { Id = (drDoc.Get<long>("Id"))}) ;

                

            }
            return result;
        }
    }
    public List<FormApproval> QueryByFormApprovalOP14Id(long id)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "QueryFormApprovalsByFormOP14Id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FormOP14Id", id);
            SqlDataReader drApproval = cmd.ExecuteReader();
            List<FormApproval> result = new List<FormApproval>();
            while (drApproval.Read())
            {
                User approvedByUser = null;

                var Id = drApproval.Get<long>("Id");
                var formId = drApproval.Get<long>("FormOP14Id");
                var approver = drApproval.Get<string>("Approver");
                var approvedByUserId = drApproval.Get<long?>("ApprovedByUserId");
                var approvalDateTime = drApproval.Get<DateTime?>("ApprovalDateTime");
                var displayOrder = drApproval.Get<int>("DisplayOrder");
                var shouldBeEnabledBehaviourId = drApproval.Get<int>("ShouldBeEnabledBehaviourId");
                var behaviour = ApprovalShouldBeEnabledBehaviour.GetById(shouldBeEnabledBehaviourId);
                var enabled = drApproval.Get<bool>("Enabled");

                if (approvedByUserId != null)
                {
                    approvedByUser = QueryByUserId(approvedByUserId.Value);
                }

                result.Add(new FormApproval(Id, formId, approver, approvedByUser, approvalDateTime, null, displayOrder,behaviour, enabled));

            }

            return result;
        }
        
    }

    private List<FunctionalLocation> QueryByFormOP14Id(long id)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "QueryFunctionalLocationsByFormOP14Id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FormOP14Id", id);
            SqlDataReader drfuncloc = cmd.ExecuteReader();
            List<FunctionalLocation> result=new List<FunctionalLocation>();
            while (drfuncloc.Read())
            {
                var site = QueryBySiteId(drfuncloc.Get<long>("SiteId"));
                var b = drfuncloc.Get<byte>("Source");

                var source = b.ToEnum<FunctionalLocationSource>();

               FunctionalLocation  lstfunclocation = new FunctionalLocation(
                    drfuncloc.Get<long>("Id"),
                    site,
                    drfuncloc.Get<string>("FullHierarchy"),
                    drfuncloc.Get<string>("Description"),
                    drfuncloc.Get<bool>("Deleted"),
                    drfuncloc.Get<bool>("OutOfService"),
                    drfuncloc.Get<long>("PlantId"),
                    drfuncloc.Get<string>("Culture"), source);

                   result.Add(lstfunclocation);
            }

            return result;
        }
        
    }
    public void TakeSnapshot(FormOP14 form)
    {
       InsertHistory(form.TakeSnapshot());
     // var notifiedEvents = new List<NotifiedEvent>();
      //notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.FormOP14Update, form));
    }

    public void InsertHistory(FormOP14History history)
    {
         string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {

            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandText = "InsertFormOP14History";
            command.CommandType = CommandType.StoredProcedure;
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("PlainTextContent", history.PlainTextContent);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("Approvals", history.Approvals);
            command.AddParameter("FunctionalLocations", history.FunctionalLocations);

            command.AddParameter("ApprovedDateTime", history.ApprovedDateTime);
            command.AddParameter("ClosedDateTime", history.ClosedDateTime);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("IsTheCSDForAPressureSafetyValve", history.IsTheCSDForAPressureSafetyValve);
            command.AddParameter("CriticalSystemDefeated", history.CriticalSystemDefeated);
            command.AddParameter("DepartmentId", history.Department.Id);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
            //DMND0010261-SELC CSD EdmontonPipeline
            command.AddParameter("IsSCADAsupportRequired", history.IsSCADASupport);
            int success = command.ExecuteNonQuery();
            if (success > 0)
            {
              command.Dispose();
            }


        }
    }
    private Site QueryBySiteId(long Id)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "QuerySiteById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader drsite = cmd.ExecuteReader();
            Site site;
            while (drsite.Read())
            {
                long id = drsite.Get<long>("Id");
                string name = drsite.Get<string>("Name");
                OltTimeZoneInfo timeZone = GetOltTimeZoneInfo((drsite.Get<string>("TimeZone")));
                List<Plant> plants = QueryByPlantSiteId(id);
                string activeDirectoryKey = drsite.Get<string>("ActiveDirectoryKey");

                site = new Site(id, name, timeZone, plants, activeDirectoryKey);

                return site;
            }

            return null;
        }
    }
    private List<Plant> QueryByPlantSiteId(long siteid)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {

            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "QueryPlantBySiteId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteId", siteid);
            SqlDataReader drsite = cmd.ExecuteReader();

            List<Plant> lstplant = new List<Plant>();
            while (drsite.Read())
            {
                long id = drsite.Get<long>("Id");
                string name = drsite.Get<string>("Name");
                long siteId = drsite.Get<long>("SiteId");
                
                lstplant.Add(new Plant(id,name,siteId));
            }
            return lstplant;
        }
    }
    private OltTimeZoneInfo GetOltTimeZoneInfo(string timeZoneName)
    {
        return new OltTimeZoneInfo(timeZoneName);
    }
    private User QueryByUserId(long id)
    {
        string connStr = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
        using (SqlConnection _connection = new SqlConnection(connStr))
        {

            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "QueryUserById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader druser = cmd.ExecuteReader();
            User user;
            while (druser.Read())
            {
                 user = new User(id,
                    druser.Get<string>("Username"),
                    druser.Get<string>("Firstname"),
                    druser.Get<string>("Lastname"),
                    new List<SiteRolePlant>(),
                    druser.Get<string>("SAPId"),
                    new UserPreferences(id),
                    new UserPrintPreference(id),
                    new UserWorkPermitDefaultTimePreferences(id),
                    druser.Get<DateTime>("LastModifiedDateTime")
                    );

                return user;
            }
            druser.Close();
            //return ManagedCommand.QueryById<User>(id, PopulateShallowInstance, QUERY_BY_ID_STORED_PROCEDURE);

            return null;
        }
    }
}