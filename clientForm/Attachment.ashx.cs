using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Web.SessionState;

namespace clientForm
{
    /// <summary>
    /// Summary description for Attachment
    /// </summary>
    public class Attachment : IHttpHandler, IRequiresSessionState
    {
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataAdapter adp;
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //string FilesPath = HttpContext.Current.Server.MapPath("~/Attachment/");
                context.Response.ContentType = "text/plain";
                
                if (context.Session["CFidx"] != null)
                {
                    string uploadedfiles = "";
                    foreach (string s in context.Request.Files)
                    {
                        HttpPostedFile file = context.Request.Files[s];
                        int fileSizeInBytes = file.ContentLength;
                        string fileName = file.FileName;

                        if (!string.IsNullOrEmpty(fileName))
                        {

                            string path = HttpContext.Current.Server.MapPath("~/documents/") + fileName;
                            file.SaveAs(path);
                            DataSet ds = new DataSet();
                            client c = new client();
                            c.attachment = fileName;
                            c.insertAttachment(ds);



                            context.Response.Write(uploadedfiles);

                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

                context.Response.Write("ERROR: " + ex.Message);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}