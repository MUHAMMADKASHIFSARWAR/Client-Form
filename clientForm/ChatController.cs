using ClientForm;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using clientForm.common;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;
using System.Web;
using System.IO;

namespace clientForm
{
    public class ChatController : ApiController
    {
        private dal db;
        private DataSet ds;
        private DataTable dt;
        private client c;

        //public static bool InsertPersonRecord(string Cfid, string comment, string userid)
        //{
        //    bool InsertData;
        //    dal db = new dal();
        //    DataSet ds = new DataSet();
        //    string date = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //    Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "HICL_PRO_CFInsertComments";
        //    cmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = Cfid;
        //    cmd.Parameters.Add("datime", OracleDbType.NVarchar2).Value = date;
        //    cmd.Parameters.Add("comt", OracleDbType.NVarchar2).Value = comment;
        //    cmd.Parameters.Add("userid", OracleDbType.NVarchar2).Value = userid;
        //    db.getDataProcedure(cmd, ds);
        //    int Result = 0;
        //    if (Result > 0)
        //    {
        //        InsertData = true;
        //    }
        //    else
        //    {
        //        InsertData = false;
        //    }
        //    return InsertData;



        //}

        public System.Web.Http.Results.JsonResult<DataTable> GetComment()
        {
            dal db = new dal();
            DataTable dt = new DataTable();
            c = new client();
            if (System.Web.HttpContext.Current.Session["CFDetailid"] != null)
            {
                c.CFID = System.Web.HttpContext.Current.Session["CFDetailid"].ToString();
                c.GetComments(dt);

            }
            else
            {
                c.CFID = System.Web.HttpContext.Current.Session["CFidx"].ToString();
                c.GetComments(dt);
            }
            return Json<DataTable>(dt);

        }
        public System.Web.Http.Results.JsonResult<DataTable> GetAssignedData()
        {

            dal objdal = new dal();
            DataTable dt = objdal.GetAssigned();
            return Json<DataTable>(dt);


        }
        public System.Web.Http.Results.JsonResult<DataTable> GetApproveName()
        {

            dal objdal = new dal();
            DataTable dt = objdal.GetApprove();
            return Json<DataTable>(dt);


        }
        public System.Web.Http.Results.JsonResult<DataTable> GetViewComment(string CF_ID)
        {

            dal objdal = new dal();
            DataTable dt = objdal.ViewComment(CF_ID);
            return Json<DataTable>(dt);


        }

        public System.Web.Http.Results.JsonResult<string> GetRevertStatus(string statusid, string AssignTouser)
        {

            dal objdal = new dal();
            string cfid = HttpContext.Current.Session["CFID"].ToString();
            string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
            objdal.UpdateRevert(cfid, statusid, AssignTouser, AssignUSer);
            objdal.InsertRevert(cfid, statusid, AssignTouser, AssignUSer);

            ds = new DataSet();
            c = new client();
            c.username = HttpContext.Current.Session["USERID"].ToString();
            c.GetClientCode(ds);
            if (ds.Tables[1].Rows.Count > 0)
            {

                MailMessageModel mailmsgmdl = new MailMessageModel();
                mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();

                Email e = new Email();
                string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

                string message = "Client Rate Approval Request Against CF-No:" + " " +
                    HttpContext.Current.Session["CFID"].ToString() + " ," + " Client Name:" + " "
                    + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
                   + " " + " " + " " + signature;
                ;

                string Emailmessage = message;
                string subject = "New Client Form Request Revert from  " + "' " + AssignUSer;



                ds = new DataSet();
                c = new client();
                c.username = AssignTouser;
                c.GetClientCode(ds);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    string forwardEmailAddess = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                    e.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
                }

            }

            return Json<string>("data saved");


        }

        public System.Web.Http.Results.JsonResult<string> GetForwardStatus(string statusid, string AssignTouser)
        {

            dal objdal = new dal();
            string cfid = HttpContext.Current.Session["CFID"].ToString();
            string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
            objdal.UpdateRevert(cfid, statusid, AssignTouser, AssignUSer);
            objdal.InsertRevert(cfid, statusid, AssignTouser, AssignUSer);


            ds = new DataSet();
            c = new client();
            c.username = HttpContext.Current.Session["USERID"].ToString();
            c.GetClientCode(ds);
            if (ds.Tables[1].Rows.Count > 0)
            {

                MailMessageModel mailmsgmdl = new MailMessageModel();
                mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();

                Email e = new Email();
                string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

                string message = "Client Rate Approval Request Against CF-No:" + " " +
                    HttpContext.Current.Session["CFID"].ToString() + " ," + " Client Name:" + " "
                    + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
                   + " " + " " + " " + signature;
                ;

                string Emailmessage = message;
                string subject = "New Client Form Request Forward from  " + "' " + AssignUSer;



                ds = new DataSet();
                c = new client();
                c.username = AssignTouser;
                c.GetClientCode(ds);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    string forwardEmailAddess = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                    e.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
                }

            }
            return Json<string>("data saved");


        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateVerifyClient(string filerValue, string VerisysValue)
        {

            dal objdal = new dal();
            string cfid = HttpContext.Current.Session["CFID"].ToString();
            string AssignUSer = HttpContext.Current.Session["USERID"].ToString();

            objdal.UpdateVerifyClient(cfid, filerValue, VerisysValue, AssignUSer);



            return Json<string>("data saved");
        }
        [HttpPost]
        public System.Web.Http.Results.JsonResult<string> FileAttachment()
        {

            var httpContext = HttpContext.Current;
            if (httpContext.Request.Files.Count > 0)
            {
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
                    if (httpPostedFile != null)
                    {

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/documents"), httpPostedFile.FileName);
                        dal objdal = new dal();
                        string cfid = HttpContext.Current.Session["CFID"].ToString();
                        string filename = httpPostedFile.FileName;
                        objdal.UpdateInsertAttachment(cfid, filename);
                        httpPostedFile.SaveAs(fileSavePath);

                    }
                }
            }


            return Json<string>("data saved");
        }

    }
}