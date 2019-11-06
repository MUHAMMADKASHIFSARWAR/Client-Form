
using ClientForm;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace clientForm
{
    public partial class clientFormDetails : System.Web.UI.Page
    {
        private DataTable dt;
        private client c;
        private DataSet ds;
        private dal db;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    if (Session["Role"].ToString() == "BranchManager")
                    {
                        drpList.Visible = false;
                        btnFinal.Visible = false;
                        btnReinsuranceHide.Visible = false;
                    }
                    if (Session["Role"].ToString() == "IT")
                    {
                        btnITVerify.Visible = true;
                        ApprovalPanel.Visible = false;

                    }
                    if (Session["Role"].ToString() == "CommissionRate")
                    {
                        btnFinal.Visible = false;
                        btnReinsuranceHide.Visible = false;

                    }
                    if (Session["Role"].ToString() == "ReInsurance")
                    {

                        btnReinsuranceHide.Visible = false;
                        dropApprove.Visible = false;
                        drpList.Visible = false;
                    }




                    //if (Session["Role"].ToString() == "SuperUser")
                    //{
                    //    drpList.Visible = false;
                    //    btnFinal.Visible = false;
                    //    btnReinsuranceHide.Visible = false;

                    //}
                }

                getclientDetail();
                getAddress();
                //getContact();
                //getBranch();
                getBranchWiseRate();
                ApprovalNAme();
                getAttachments();
                GetCP();
                GetApprovedName();
                GetRevertName();

                if (Session["USERID"] != null)
                {
                    if (Session["USERID"].ToString() == "BranchManager")
                    {
                        drpList.Visible = false;
                        btnFinal.Visible = false;
                        btnReinsuranceHide.Visible = false;
                    }
                    if (Session["USERID"].ToString() == "RegionalManager")
                    {
                        btnFinal.Visible = false;
                        btnReinsuranceHide.Visible = false;
                    }
                    if (Session["USERID"].ToString() == "OMARZUBAIR")
                    {
                        dropApprove.Visible = false;
                    }
                }
            }
        }

        public void getclientDetail()
        {
            ds = new DataSet();
            db = new dal();
            c = new client();
            if (Session["CFID"] != null)
            {
                DataSet ds = new DataSet();
                c.CFID = Session["CFID"].ToString();
                c.GetClientDetails(ds);

                if (ds.Tables[1].Rows.Count > 0)
                {
                    string clientname = ds.Tables[1].Rows[0]["CLIENT_NAME"].ToString();
                    string cnic = ds.Tables[1].Rows[0]["CLIENT_CNIC"].ToString();
                    string ntn = ds.Tables[1].Rows[0]["CLIENT_NTN"].ToString();
                    string gst = ds.Tables[1].Rows[0]["CLIENT_GST"].ToString();
                    string nicExpiry = ds.Tables[1].Rows[0]["CLIENT_NIC_EXPIRY"].ToString();
                    string verisys = ds.Tables[1].Rows[0]["VERIFY_VERISYS_TYPE"].ToString();
                    string filer = ds.Tables[1].Rows[0]["VERIFY_FILER_TYPE"].ToString();
                    Session["Clientname"] = clientname;
                    Session["clientCnic"] = cnic;
                    lblClient.Text = clientname;
                    lblcnic.Text = cnic;
                    lblcnicExpiry.Text = nicExpiry;
                    lblntn.Text = ntn;
                    lblgst.Text = gst;
                    lblVerifyFilerType.Text = filer;
                    lblVerifyVerisysType.Text = verisys;

                    string issuedate = ds.Tables[1].Rows[0]["ISSUE_DATE"].ToString();
                    string reqType = ds.Tables[1].Rows[0]["PSP_STYPDESC"].ToString();
                    string category = ds.Tables[1].Rows[0]["CATEGORY_CODE"].ToString();
                    string potExposure = ds.Tables[1].Rows[0]["POTENTIAL_EXPOSURE"].ToString();
                    string potPremium = ds.Tables[1].Rows[0]["POTENTIAL_PREMIUM"].ToString();
                    string prefix = ds.Tables[1].Rows[0]["PPX_DESC"].ToString();
                    string filType = ds.Tables[1].Rows[0]["FILER_TYPE"].ToString();
                    string branch = ds.Tables[1].Rows[0]["PLC_LOCADESC"].ToString();

                    lblissueDate.Text = issuedate;
                    lblReqType.Text = reqType;
                    lblCategory.Text = category;
                    lblPotExposure.Text = potExposure;
                    lblPotPrem.Text = potPremium;
                    lblprefix.Text = prefix;
                    lblFiler.Text = filType;
                    lblBranch.Text = branch;
                    string reqUser = ds.Tables[1].Rows[0]["REQUESTUSER"].ToString();
                    string reqDate = ds.Tables[1].Rows[0]["REQUEST_DATE"].ToString();
                    string group = ds.Tables[1].Rows[0]["GROUP_NAME"].ToString();
                    string refBy = ds.Tables[1].Rows[0]["REFERENCEBY"].ToString();
                    string residentType = ds.Tables[1].Rows[0]["RESIDENT_TYPE"].ToString();
                    string customerRat = ds.Tables[1].Rows[0]["CUSTOMER_RATING"].ToString();
                    string transactionRat = ds.Tables[1].Rows[0]["TRANSACTION_RATING"].ToString();
                    string geoRating = ds.Tables[1].Rows[0]["GEOPRAPHICAL_RATING"].ToString();


                    lblReqUser.Text = reqUser;
                    lblReqDate.Text = reqDate;
                    lblGroup.Text = group;
                    lblRef.Text = refBy;
                    lblResident.Text = residentType;
                    lblCustRating.Text = customerRat;
                    lblTransRating.Text = transactionRat;
                    lblGeoRating.Text = geoRating;

                }
            }
            else
            {

            }
        }

        public void getAddress()
        {
            dt = new DataTable();
            db = new dal();
            c = new client();
            if (Session["CFID"] != null)
            {
                c.CFID = Session["CFID"].ToString();
                c.GetClientAddress(dt);
                gvAddress.DataSource = dt;
                gvAddress.DataBind();
            }
            else
            {

            }
        }
        //public void getContact()
        //{
        //    dt = new DataTable();
        //    db = new dal();
        //    c = new client();
        //    if (Session["CFID"] != null)
        //    {
        //        c.CFID = Session["CFID"].ToString();
        //        c.GetClientContact(dt);
        //        gvContact.DataSource = dt;
        //        gvContact.DataBind();
        //    }
        //    else
        //    {

        //    }
        //}
        //public void getBranch()
        //{
        //    dt = new DataTable();
        //    db = new dal();
        //    c = new client();
        //    if (Session["CFID"] != null)
        //    {
        //        c.CFID = Session["CFID"].ToString();
        //        c.GetClientBranch(dt);
        //        gvBranches.DataSource = dt;
        //        gvBranches.DataBind();
        //    }
        //    else
        //    {

        //    }
        //}
        public void getBranchWiseRate()
        {
            dt = new DataTable();
            db = new dal();
            c = new client();
            if (Session["CFID"] != null)
            {
                c.CFID = Session["CFID"].ToString();
                c.GetClientBranchWiseRate(dt);
                GvDeptRate.DataSource = dt;
                GvDeptRate.DataBind();
            }
            else
            {

            }
        }



        public void ApprovalNAme()
        {
            dt = new DataTable();
            dt.Columns.Add("ApprovalName");
            dt.Rows.Add("Fawwad");
            dt.Rows.Add("Tariq Awan");
            dt.Rows.Add("Omer Zubair");
            dt.Rows.Add("Shabir Gulam Ali");
            dt.Rows.Add("Murtaza Hussain");

            //ddlApproval.DataValueField = "ApprovalName";
            //ddlApproval.DataTextField = "ApprovalName";
            //c.getPrefix(dt);
            //ddlApproval.DataSource = dt;
            //ddlApproval.DataBind();
            //ddlApproval.Items.Insert(0, new ListItem("Approved By"));


        }

        //protected void chkfawad_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkfawad.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        c.username = "FAWWADD";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string STATUSIDX = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = STATUSIDX.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "FAWWADD";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure forward to Fawad')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}
        //            }
        //        }

        //    }





        //}

        //protected void chktariq_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chktariq.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "TariqAwan";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "TariqAwan";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure forward to TARIQ')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }
        //}

        //protected void chkOmer_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkOmer.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "OMARZUBAIR";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "OMARZUBAIR";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure forward to OMAR ZUBAIR')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }
        //}

        //protected void chkShabir_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkShabir.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "ShabirGulamAli";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "ShabirGulamAli";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure forward to Shabir Gulam Ali')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }
        //}

        //protected void chkMurtaza_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkMurtaza.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "MURTAZA.H";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "MURTAZA.H";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure forward to MURTAZA Hussain')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }

        //}
        public void getAttachments()
        {
            dt = new DataTable();
            db = new dal();
            c = new client();
            if (Session["CFidx"] != null)
            {

                c.CFID = Session["CFidx"].ToString();
                c.GetAttachment(dt);
                listAttach.DataSource = dt;
                listAttach.DataBind();

            }

            
        }

        //protected void chkFawardRevert_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkFawardRevert.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "FAWWADD";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "FAWWADD";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure revert to Fawad')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }
        //}

        //protected void chktariqRevert_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chktariqRevert.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "TariqAwan";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "TariqAwan";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure revert to TARIQ')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }


        //}

        //protected void chkOmerRevert_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkOmerRevert.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "OMARZUBAIR";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "OMARZUBAIR";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure revert to OMAR ZUBAIR')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }
        //}

        //protected void chkShabirRevert_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkShabirRevert.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "ShabirGulamAli";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "ShabirGulamAli";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure revert to Shabir Gulam Ali')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }
        //}


        //protected void chkMurtazaRevert_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkMurtazaRevert.Checked)
        //    {
        //        dt = new DataTable();
        //        db = new dal();
        //        c = new client();
        //        //if (Session["USERID"].ToString() != null)
        //        //{
        //        //c.username = Session["USERID"].ToString();
        //        c.username = "MURTAZA.H";
        //        c.GetApproveUser(dt);
        //        if (dt.Rows.Count > 0)
        //        {
        //            string approval_index = dt.Rows[0]["STATUSIDX"].ToString();
        //            if (Session["CFID"] != null)
        //            {
        //                c.CFID = Session["CFID"].ToString();
        //                c.status = approval_index.ToString();
        //                c.UpdateStatus(dt);

        //                dt = new DataTable();
        //                c = new client();
        //                c.CFID = Session["CFID"].ToString();
        //                c.username = Session["USERID"].ToString();
        //                c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                c.Assignto = "MURTAZA.H";
        //                c.insertApprovalUser(dt);
        //                string messageShow = "alert('Are u sure revert to MURTAZA Hussain')";
        //                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);
        //                //Response.Redirect("NewClientForm.aspx");
        //                //}

        //            }
        //        }
        //    }
        //}

        protected void btnfanalize_Click(object sender, EventArgs e)
        {
            try
            {


                dt = new DataTable();
                db = new dal();
                c = new client();
                if (Session["CFID"] != null)
                {
                    if (Session["Role"].ToString() == "ReInsurance")
                    {

                        c.status = "30";
                        c.Assignto = "FAWWADD";
                    }
                    else
                    {
                        c.status = "90";
                        c.Assignto = "IT";

                    }

                    c.CFID = Session["CFID"].ToString();
                    c.assignUSer = Session["USERID"].ToString();
                    c.UpdateStatus(dt);

                    dt = new DataTable();
                    c = new client();
                    c.CFID = Session["CFID"].ToString();

                    if (Session["Role"].ToString() == "ReInsurance")
                    {

                        c.Assignto = "FAWWADD";

                    }
                    else
                    {
                        c.Assignto = "IT";

                    }


                    c.username = Session["USERID"].ToString();
                    c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
                    c.insertApprovalUser(dt);


                    ds = new DataSet();
                    c = new client();
                    c.username = HttpContext.Current.Session["USERID"].ToString();
                    c.GetClientCode(ds);
                    if (ds.Tables[1].Rows.Count > 0)
                    {

                        MailMessageModel mailmsgmdl = new MailMessageModel();
                        mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                        mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();
                        Email es = new Email();
                                                string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

                        if (Session["Role"].ToString() == "ReInsurance")
                        {
                            string message = "This  Client is finalize from Re Insurance Department  Against  CF-No:" + " " +
                            HttpContext.Current.Session["CFID"].ToString() + " ," + " Client Name:" + " "
                            + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
                           + " " + " " + " " + signature;
                            ;

                            string Emailmessage = message;
                            string subject = "Finalize Client  Request Forward from  " + "' " + HttpContext.Current.Session["USERID"].ToString();

                            string forwardEmailAddess = "fawwad@habibinsurance.net";
                            es.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
                        }
                        else
                        {
                            string message = "This  Client is Finalize   Against  CF-No:" + " " +
                               HttpContext.Current.Session["CFID"].ToString() + " ," + " Client Name:" + " "
                               + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
                              + " " + " " + " " + signature;
                            ;

                            string Emailmessage = message;
                            string subject = "Finalize Client  Request Forward from  " + "' " + HttpContext.Current.Session["USERID"].ToString();

                            string forwardEmailAddess = "it.support@habibinsurance.net";
                            es.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);

                        }
                            
                        string messageShow = "alert('finalize client Successfully forward to IT Department')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);

                    }
                    //Response.Redirect("NewClientForm.aspx");
                    //}

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }



      


        public void GetCP()
        {
            db = new dal();
            c = new client();
            dt = new DataTable();
            if (Session["CFID"] != null)
            {
                c.CFID = Session["CFID"].ToString();
                c.GetContactPerson(dt);
                gvCPDetails.DataSource = dt;
                gvCPDetails.DataBind();
            }
            else
            {

            }

        }



        public void GetApprovedName()
        {
            db = new dal();
            c = new client();
            ds = new DataSet();
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "BranchManager")
                {
                    c.statusStart = "20";
                    c.statusend = "40";
                }
                else if (Session["Role"].ToString() == "OperationHead")
                {
                    if (Session["USERID"].ToString() == "FAWWADD")
                    {
                        c.statusStart = "30";
                        c.statusend = "51";
                    }
                    else if (Session["USERID"].ToString() == "Tariq")
                    {
                        c.statusStart = "40";
                        c.statusend = "51";
                    }

                }
                else if (Session["Role"].ToString() == "CommissionRate")
                {
                    c.statusStart = "21";
                    c.statusend = "31";
                }
                //if (Session["USERID"].ToString() == "BranchManager")
                //{
                //    c.statusStart = "10";
                //    c.statusend = "10";
                //}
                //if (Session["USERID"].ToString() == "Tariq")
                //{
                //    c.statusStart = "40";
                //    c.statusend = "40";
                //}

                //if (Session["USERID"].ToString() == "OMARZUBAIR")
                //{
                //    c.statusStart = "30";
                //    c.statusend = "30";
                //}

                //if (Session["USERID"].ToString() == "FAWWADD")
                //{
                //    c.statusStart = "30";
                //    c.statusend = "40";
                //}
                //if (Session["USERID"].ToString() == "SuperUser")
                //{
                //    c.statusStart = "20";
                //    c.statusend = "20";
                //}


                c.GetForward(ds);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        ListItem item = new ListItem();
                        item.Text = ds.Tables[1].Rows[i]["USERID"].ToString();
                        item.Value = ds.Tables[1].Rows[i]["STATUSIDX"].ToString();
                        chkApproved.Items.Add(item);
                    }

                }
            }
        }

        public void GetRevertName()
        {
            db = new dal();
            c = new client();
            ds = new DataSet();
            dt = new DataTable();
            if (Session["Role"] != null)
            {
                if (Session["locCodeRevert"] != null)
                {



                    c.role = Session["Role"].ToString();
                    if (Session["Role"].ToString() == "OperationHead")
                    {
                        if (Session["USERID"].ToString() == "FAWWADD")
                        {
                            c.LocCode = Session["locCodeRevert"].ToString();
                            c.statusStartRev = "9";
                            c.statusendRev = "11";

                        }
                        else if (Session["USERID"].ToString() == "Tariq")
                        {
                            c.LocCode = " ";
                            c.statusStartRev = "20";
                            c.statusendRev = "31";
                        }
                        else if (Session["USERID"].ToString() == "OMARZUBAIR")
                        {
                            c.LocCode = " ";
                            c.statusStartRev = "29";
                            c.statusendRev = "41";
                        }



                    }
                    else if (Session["USERID"].ToString() == "MURTAZA.H")
                    {
                        c.LocCode = Session["locCodeRevert"].ToString();
                        c.statusStartRev = "0";
                        c.statusendRev = "11";
                    }
                    if (c.statusStartRev != null)
                    {
                        c.GetRevert(ds);
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                ListItem item = new ListItem();
                                item.Text = ds.Tables[1].Rows[i]["USERID"].ToString();
                                item.Value = ds.Tables[1].Rows[i]["STATUSIDX"].ToString();
                                chkRevert.Items.Add(item);
                            }

                        }
                    }
                }




            }
        }

        //protected void chkApproved_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        foreach (ListItem item in chkApproved.Items)
        //        {
        //            if (item.Selected)
        //            {

        //                string name = item.Text;
        //                string statusid = item.Value;

        //                if (Session["CFID"] != null)
        //                {
        //                    c = new client();
        //                    dt = new DataTable();
        //                    c.CFID = Session["CFID"].ToString();
        //                    c.status = statusid;
        //                    c.Assignto = name;
        //                    c.assignUSer = Session["USERID"].ToString();
        //                    c.UpdateStatus(dt);

        //                    dt = new DataTable();
        //                    c = new client();
        //                    c.CFID = Session["CFID"].ToString();
        //                    c.username = Session["USERID"].ToString();
        //                    c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                    c.Assignto = name;
        //                    c.insertApprovalUser(dt);

        //                }



        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        //protected void chkRevert_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        foreach (ListItem item in chkRevert.Items)
        //        {
        //            if (item.Selected)
        //            {
        //                //string name = item.Text;
        //                //string statusid = item.Value;

        //                //if (Session["CFID"] != null)
        //                //{
        //                //    c = new client();
        //                //    dt = new DataTable();
        //                //    c.CFID = Session["CFID"].ToString();
        //                //    c.status = statusid;
        //                //    c.Assignto = name;
        //                //    c.assignUSer = Session["USERID"].ToString();
        //                //    c.UpdateStatus(dt);

        //                //    dt = new DataTable();
        //                //    c = new client();
        //                //    c.CFID = Session["CFID"].ToString();
        //                //    c.username = Session["USERID"].ToString();
        //                //    c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //                //    c.Assignto = name;
        //                //    c.insertApprovalUser(dt);

        //                //}

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        protected void btnReInsurance_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CFID"] != null)
                {
                    c = new client();
                    dt = new DataTable();
                    c.CFID = Session["CFID"].ToString();
                    c.status = "80";
                    c.Assignto = "Re-Insurance";
                    c.assignUSer = Session["USERID"].ToString();
                    c.UpdateStatus(dt);

                    dt = new DataTable();
                    c = new client();
                    c.CFID = Session["CFID"].ToString();
                    c.username = Session["USERID"].ToString();
                    c.issueDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
                    c.Assignto = "Re-Insurance";
                    c.insertApprovalUser(dt);
                    ds = new DataSet();
                    c = new client();
                    c.username = HttpContext.Current.Session["USERID"].ToString();
                    c.GetClientCode(ds);
                    if (ds.Tables[1].Rows.Count > 0)
                    {

                        MailMessageModel mailmsgmdl = new MailMessageModel();
                        mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                        mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();
                        Email es = new Email();

                        string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://103.205.177.141:8889/ClientPortal");



                        string message = "New Client Request   Against  CF-No:" + " " +
                            HttpContext.Current.Session["CFID"].ToString() + " ," + " Client Name:" + " "
                            + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
                           + " " + " " + " " + signature;
                        ;

                        string Emailmessage = message;
                        string subject = "New Client  Request Forward from  " + "' " + HttpContext.Current.Session["USERID"].ToString();

                        string forwardEmailAddess = "it.support@habibinsurance.net";
                        es.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
                        string messageShow = "alert('Forward to Re-Insurance Department')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", messageShow, true);

                    }

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }

}

