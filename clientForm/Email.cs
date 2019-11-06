using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using clientForm.common;
using System.Net.Http;
using System.IO;
using System.Net;
//using Pechkin;
//using Pechkin.Synchronized;
using System.Drawing.Printing;


namespace clientForm
{
    public class Email
    {
       
      
        public void SendEmailAsyncInfoEmail(MailMessageModel objModel, string EmailAddess, string EmailMessage, string EmailSubject )
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(EmailAddess);//sending 
                mail.From = new MailAddress(objModel.email);//sending 

                mail.IsBodyHtml = true;
                string[] emailAdds = EmailAddess.Split(new String[] { ";" }, StringSplitOptions.None);
                foreach (string address in emailAdds)
                {
                    mail.To.Add(address);

                }
               
                mail.Subject = EmailSubject;
                mail.Body = EmailMessage;




                objModel.mailMessage = mail;
                AsyncMethodCaller caller = new AsyncMethodCaller(SendMailInSeperateThreadInfoEmail);
                AsyncCallback callbackHandler = new AsyncCallback(AsyncCallback);
              
                caller.BeginInvoke(objModel, callbackHandler, null);


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }
        private delegate void AsyncMethodCaller(MailMessageModel message);
        private void SendMailInSeperateThreadInfoEmail(MailMessageModel message)
        {
            try
            {

                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
                SmtpServer.Port = 587;
                //   SmtpServer.Credentials = new System.Net.NetworkCredential(message.userid, message.password);
                SmtpServer.Credentials = new System.Net.NetworkCredential(message.email, message.password);
                //SmtpServer.Credentials = new System.Net.NetworkCredential("info@habibinsurance.net", "Kuv92186");
                SmtpServer.EnableSsl = true;
             
                SmtpServer.Send(message.mailMessage);



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                // This is very necessary to catch errors since we are in
                // a different context & thread
                // Elmah.ErrorLog.GetDefault(null).Log(new Error(e));
            }
        }
        private void AsyncCallback(IAsyncResult ar)
        {
            try
            {
                AsyncResult result = (AsyncResult)ar;
                AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;

                caller.EndInvoke(ar);
                string messageError = "alert('Invalid Email.')";
                ScriptManager.RegisterClientScriptBlock((ar as Control), this.GetType(), "alert", messageError, true);
            }
            catch (Exception e)
            {
                //Elmah.ErrorLog.GetDefault(null).Log(new Error(e));
                //Elmah.ErrorLog.GetDefault(null).Log(new Error(new Exception("Emailer - This hacky asynccallback thing is puking, serves you right.")));
            }
        }
    }
}