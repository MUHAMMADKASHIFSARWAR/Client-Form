using ClientForm;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace clientForm
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        private DataTable dt;
        private client c;
        private DataSet ds;
        private dal db;
        private OracleConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getAddresType();
                GetCOuntry();
                GetCity();
                GetProducer();
                getBankName();
                fillclientGroup();
                fillCompanyIndustry();
                GetDepartment();
                GetInsuranceType();
                getAgent();
                //setRating();
                //fillBranch();
                fillPrefix();
                //GetInstallmentMode();
                //FillAdreess();
                //FillBusclass();
                //getAttachments();
                //GetApprovedName();
                //GetRevertName();
               
                if (Session["USERID"] != null)
                {
                    if (Session["USERID"].ToString() == "OMARZUBAIR")
                    {
                        dropApprove.Visible = false;
                    }


                    hdnuser.Value = Session["USERID"].ToString();
                    lblUserName.Text = Session["USERID"].ToString();
                }

                
                if (Session["Role"] != null)
                {
                    hdnUserRole.Value = Session["Role"].ToString();
                    string role = Session["Role"].ToString();
                    if (role == "Producer")
                    {
                        drpList.Visible = false;
                    }
                }

                if (Session["statusidx"] != null)
                {
                    hdnStatusidx.Value = Session["statusidx"].ToString();
                }
                if (Session["clientbranch"] != null)
                {
                    ddlBranch.SelectedValue = Session["clientbranch"].ToString();
                }


                if (Session["Branch"] != null && Session["Branch"].ToString() != "")
                {
                    dt = new DataTable();
                    dt.Columns.Add("BranchCode");
                    dt.Columns.Add("BranchDesc");
                    DataRow dr = dt.NewRow();
                    dr["BranchCode"] = Session["clientbranch"].ToString();
                    dr["BranchDesc"] = Session["Branch"].ToString();
                    dt.Rows.Add(dr);
                    ddlBranch.DataValueField = "BranchCode";
                    ddlBranch.DataTextField = "BranchDesc";
                    ddlBranch.DataSource = dt;
                    ddlBranch.DataBind();

                }
                else
                {
                    fillBranch();
                }
            }

        }


        public void getAddresType()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            ddlAddressType.DataValueField = "PAT_ADD_TYPE";
            ddlAddressType.DataTextField = "PAT_ADD_TYPE_DESC";
            c.GetAddressType(dt);
            ddlAddressType.DataSource = dt;
            ddlAddressType.DataBind();
            ddlAddressType.Items.Insert(0, new ListItem("Select Address Type"));

        }

        public void GetCOuntry()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            ddlCountry.DataValueField = "PCO_CTRY_CODE";
            ddlCountry.DataTextField = "PCO_DESC";
            c.GetCountry(dt);
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            ddlCountry.SelectedValue = "001";
        }
        public void GetCity()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            ddlCity.DataValueField = "PCT_CITYCODE";
            ddlCity.DataTextField = "PCT_CITYDESC";
            c.GetCity(dt);
            ddlCity.DataSource = dt;
            ddlCity.DataBind();
            ddlCity.SelectedValue = "001";
        }


        //public void getAttachments()
        //{
        //    dt = new DataTable();
        //    db = new dal();
        //    c = new client();
        //    if (Session["CFID"] != null)
        //    {

        //        c.CFID = Session["CFID"].ToString();
        //        c.GetAttachment(dt);
        //        listAttach.DataSource = dt;
        //        listAttach.DataBind();

        //    }

        //}
        public void getBankName()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            ddlBank.DataValueField = "BANK_CODE";
            ddlBank.DataTextField = "BANK_NAME";
            c.getBankList(dt);
            ddlBank.DataSource = dt;
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("Select Bank"));
            ddlBank.SelectedIndex = 0;

        }

        public void fillclientGroup()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlGroupName.DataValueField = "GRPCODE";
                ddlGroupName.DataTextField = "GRPNAME";
                c.GetGroup(dt);
                ddlGroupName.DataSource = dt;
                ddlGroupName.DataBind();
                ddlGroupName.Items.Insert(0, new ListItem("Select Group"));
                //ddlGroupName.Items[0].Attributes.Add("disabled", "disabled");
                ddlGroupName.SelectedIndex = 0;

                //ddlGroupName.Items[0].Attributes.Add("selected", "selected");

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public void fillCompanyIndustry()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlCompIndustry.DataValueField = "PCD_CODE";
                ddlCompIndustry.DataTextField = "PCD_DESC";
                c.GetCompanyIndustry(dt);
                ddlCompIndustry.DataSource = dt;
                ddlCompIndustry.DataBind();
                ddlCompIndustry.Items.Insert(0, new ListItem("Select Company Industory"));
                ddlCompIndustry.Items[0].Attributes.Add("disabled", "disabled");
                ddlCompIndustry.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //lblMsg.Text = (ex.Message.ToString());
            }

        }

        public void GetDepartment()
        {

            dt = new DataTable();
            dt.Columns.Add("Department");
            dt.Columns.Add("Dept_code");

            dt.Rows.Add("Fire", "11");
            dt.Rows.Add("Marine", "12");
            dt.Rows.Add("Motor", "13");
            dt.Rows.Add("Health", "17");
            dt.Rows.Add("Engineering", "15");
            dt.Rows.Add("Miscellaneous", "14");



            ddlDeptment.DataTextField = "Department";
            ddlDeptment.DataValueField = "Dept_code";
            ddlAppDept.DataTextField = "Department";
            ddlAppDept.DataValueField = "Dept_code";
            //ddlDept.DataTextField = "Department";
            //ddlDept.DataValueField = "Dept_code";
            ddlDeptment.DataSource = dt;
            ddlDeptment.DataBind();
            ddlAppDept.DataSource = dt;
            ddlAppDept.DataBind();
            ////ddlDept.DataSource = dt;
            ////ddlDept.DataBind();
            //ddlDeptment.Items.Insert(0, new ListItem("Select Department"));
            //ddlDept.Items.Insert(0, new ListItem("Select Department"));
            //ddlAppDept.Items.Insert(0, new ListItem("Select Department"));

        }


        public void GetInsuranceType()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlInsuranceType.DataValueField = "PIY_INSUTYPE";
                ddlInsuranceType.DataTextField = "PIY_DESC";
                ddlAgentInsuranceType.DataValueField = "PIY_INSUTYPE";
                ddlAgentInsuranceType.DataTextField = "PIY_DESC";
                c.getInsuranceType(dt);
                ddlInsuranceType.DataSource = dt;
                ddlInsuranceType.DataBind();
                ddlAgentInsuranceType.DataSource = dt;
                ddlAgentInsuranceType.DataBind();



                //ddlInsuranceType.Items.Insert(0, new ListItem("Select Insurance Type"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        public void GetProducer()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlProducer.DataValueField = "PDO_DEVOFFCODE";
                ddlProducer.DataTextField = "PRODUCER";
                if (HttpContext.Current.Session["clientbranch"].ToString() == "")
                {
                    c.Branch = "All";
                    c.getProducer(dt);
                }
                else
                {
                    c.Branch = HttpContext.Current.Session["clientbranch"].ToString();
                    c.getProducer(dt);
                }

                ddlProducer.DataSource = dt;
                ddlProducer.DataBind();
                ddlProducer.Items.Insert(0, new ListItem("Select Producer"));
                ddlProducer.Items[0].Attributes.Add("disabled", "disabled");
                ddlProducer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public void GetInstallmentMode()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlInstalMode.DataValueField = "PIM_INST_MODE_DESC";
                ddlInstalMode.DataTextField = "PIM_INST_MODE_DESC";
                c.getInstallments(dt);
                ddlInstalMode.DataSource = dt;
                ddlInstalMode.DataBind();
                //ddlInstalMode.Items.Insert(0, new ListItem("Select Installment Mode"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        //protected void ddlBusClassCat_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        db = new dal();
        //        c = new client();
        //        dt = new DataTable();
        //        c.Department = ddlDeptment.SelectedItem.Text;
        //        if (ddlBusClassCat.SelectedItem.Text != null)
        //        {
        //            c.BusinessCat = ddlBusClassCat.SelectedItem.Text;
        //            c.getBussClass(dt);
        //            ddlBusClass.DataTextField = "PBC_DESC";
        //            ddlBusClass.DataValueField = "PBC_BUSICLASS_CODE";
        //            ddlBusClass.DataSource = dt;
        //            ddlBusClass.DataBind();
        //            //ddlBusClass.Items.Insert(0, new ListItem("Select Busniess Class"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }

        //}

        public void getAgent()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();

            if (HttpContext.Current.Session["clientbranch"].ToString() == "")
            {
                ddlAgent.DataValueField = "PPS_PARTY_CODE";
                ddlAgent.DataTextField = "PPS_DESC";
                c.Branch = "All";
                c.getAgent(dt);
            }
            else
            {
                ddlAgent.DataValueField = "pps_agent_Code";
                ddlAgent.DataTextField = "PPS_DESC";
                c.Branch = HttpContext.Current.Session["clientbranch"].ToString();
                c.getAgent(dt);
            }


            ddlAgent.DataSource = dt;
            ddlAgent.DataBind();
            ddlAgent.Items.Insert(0, new ListItem("Select Agent Name"));
            ddlAgent.Items[0].Attributes.Add("disabled", "disabled");
            ddlAgent.SelectedIndex = 0;
            //ddlAgent.Items.Insert(0, new ListItem("Select Agent Name"));

        }

        //public void setRating()
        //{
        //    dt = new DataTable();
        //    dt.Columns.Add("Rating");
        //    dt.Rows.Add("Customer");
        //    dt.Rows.Add("Transaction");
        //    dt.Rows.Add("Geographical");
        //    GvRating.DataSource = dt;
        //    GvRating.DataBind();


        //}

        protected void chkHigh_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            CheckBox checkMed = (CheckBox)chk.FindControl("chkMed");
            CheckBox checkLow = (CheckBox)chk.FindControl("chkLow");

            checkMed.Checked = false;
            checkLow.Checked = false;

        }

        protected void chkMed_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            CheckBox checkHigh = (CheckBox)chk.FindControl("chkHigh");
            CheckBox checkLow = (CheckBox)chk.FindControl("chkLow");

            checkHigh.Checked = false;
            checkLow.Checked = false;

        }

        protected void chkLow_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            CheckBox checkMed = (CheckBox)chk.FindControl("chkMed");
            CheckBox checkHigh = (CheckBox)chk.FindControl("chkHigh");
            checkHigh.Checked = false;
            checkMed.Checked = false;

        }

        public void fillPrefix()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlPrefix.DataValueField = "PPX_CODE";
                ddlPrefix.DataTextField = "PPX_DESC";
                c.getPrefix(dt);
                ddlPrefix.DataSource = dt;
                ddlPrefix.DataBind();
                //ddlPrefix.Items.Insert(0, new ListItem("Select Prefix"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //lblMsg.Text = (ex.Message.ToString());
            }

        }

        public void fillBranch()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlBranch.DataValueField = "PLC_LOCACODE";
                ddlBranch.DataTextField = "PLC_LOCADESC";
                c.getBranch(dt);
                ddlBranch.DataSource = dt;
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("Select Branch"));
                //if (Session["clientbranch"] != null)
                //{
                //    ddlBranch.SelectedValue = Session["clientbranch"].ToString();
                //}

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        c = new client();
        //        db = new dal();
        //        ds = new DataSet();
        //        dt = new DataTable();
        //        c.CFID = "CF-";


        //        c.Branch = ddlBranch.SelectedValue;
        //        if (ddlPrefix.SelectedItem.Text == "Select Prefix")
        //        {
        //            c.Prefix = "";
        //        }
        //        else
        //        {
        //            c.Prefix = ddlPrefix.SelectedValue;
        //        }
        //        c.ClientName = txtName.Text;
        //        c.CNIC = txtNic.Text;
        //        c.issueDate = txtIssueDate.Text;
        //        c.CNICExpiry = txtExpireDate.Text;
        //        c.NTN = txtNTN.Text;
        //        c.GST = txtSTN.Text;
        //        if (ddlCategory.SelectedItem.Text == "Select")
        //        {
        //            c.clientType = "";
        //        }
        //        else
        //        {
        //            c.clientType = ddlCategory.SelectedItem.Text;
        //        }
        //        foreach (ListItem item in chkFiler.Items)
        //        {
        //            if (item.Selected)
        //            {
        //                string filer = item.Value;
        //                c.Filer = filer;
        //            }
        //        }
        //        c.EmployeName = txtNameEmpolyer.Text;
        //        c.SourceOfIncome = txtSourceIncome.Text;
        //        c.ContactPerson = txtContactPerson.Text;
        //        c.ContactPerDes = txtDesgRef.Text;
        //        c.ContactPersonCnic = txtContactCnic.Text;
        //        c.ContactPerNo = txtContactPersonMobile.Text;
        //        c.ContactPerEmail = txtContactPersonEamil.Text;
        //        c.reference = txtReference.Text;
        //        if (ddlGroupName.SelectedItem.Text == "Select Group")
        //        {
        //            c.GroupName = "";
        //        }
        //        else
        //        {
        //            c.GroupName = ddlGroupName.SelectedItem.Text;
        //        }

        //        if (ddlCompIndustry.SelectedItem.Text == "Select Company Industory")
        //        {
        //            c.companyInd = "";
        //        }
        //        else
        //        {
        //            c.companyInd = ddlCompIndustry.SelectedValue;
        //        }

        //        c.ProducerName = txtProducer.Text;
        //        c.AgentRate = txtAggentRate.Text;

        //        if (ddlAgent.SelectedItem.Text == "Select Agent Name")
        //        {
        //            c.Agent = "";
        //        }
        //        else
        //        {
        //            c.Agent = ddlAgent.SelectedValue;
        //        }


        //        //       c.RequestUser = Session["USERID"].ToString();
        //        c.RequestUser = "Kashif";
        //        c.creationDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
        //        if (Session["statusidx"] != null)
        //        {
        //            c.status = Session["statusidx"].ToString();
        //        }

        //        //c.Assignto = Session["NEXTAPPROVAL"].ToString();
        //        //c.assignUSer = Session["USERID"].ToString();


        //        foreach (ListItem item in chkResNoRes.Items)
        //        {
        //            if (item.Selected)
        //            {
        //                string resident = item.Value;
        //                c.resident = resident;
        //            }
        //        }



        //        foreach (GridViewRow row in GvRating.Rows)
        //        {
        //            if (row.Cells[0].Text == "Customer")
        //            {
        //                CheckBox high = (CheckBox)row.FindControl("chkHigh");
        //                if (high.Checked)
        //                {
        //                    string Chigt = GvRating.HeaderRow.Cells[1].Text;
        //                    c.customerRating = Chigt;
        //                }

        //                CheckBox medium = (CheckBox)row.FindControl("chkMed");
        //                if (medium.Checked)
        //                {
        //                    string Cmedium = GvRating.HeaderRow.Cells[2].Text;
        //                    c.customerRating = Cmedium;
        //                }


        //                CheckBox low = (CheckBox)row.FindControl("chkLow");
        //                if (low.Checked)
        //                {
        //                    string CLow = GvRating.HeaderRow.Cells[3].Text;
        //                    c.customerRating = CLow;
        //                }
        //            }
        //            if (row.Cells[0].Text == "Transaction")
        //            {
        //                CheckBox high = (CheckBox)row.FindControl("chkHigh");
        //                if (high.Checked)
        //                {
        //                    string Thigh = GvRating.HeaderRow.Cells[1].Text;
        //                    c.TRANSACTION_RATING = Thigh;
        //                }

        //                CheckBox medium = (CheckBox)row.FindControl("chkMed");
        //                if (medium.Checked)
        //                {
        //                    string Tmedium = GvRating.HeaderRow.Cells[2].Text;
        //                    c.TRANSACTION_RATING = Tmedium;
        //                }


        //                CheckBox low = (CheckBox)row.FindControl("chkLow");
        //                if (low.Checked)
        //                {
        //                    string TLow = GvRating.HeaderRow.Cells[3].Text;
        //                    c.TRANSACTION_RATING = TLow;
        //                }
        //            }
        //            if (row.Cells[0].Text == "Geographical")
        //            {
        //                CheckBox high = (CheckBox)row.FindControl("chkHigh");
        //                if (high.Checked)
        //                {
        //                    string Ghigt = GvRating.HeaderRow.Cells[1].Text;
        //                    c.GEOPRAPHICAL_RATING = Ghigt;
        //                }

        //                CheckBox medium = (CheckBox)row.FindControl("chkMed");
        //                if (medium.Checked)
        //                {
        //                    string Gmedium = GvRating.HeaderRow.Cells[2].Text;
        //                    c.GEOPRAPHICAL_RATING = Gmedium;
        //                }


        //                CheckBox low = (CheckBox)row.FindControl("chkLow");
        //                if (low.Checked)
        //                {
        //                    string GLow = GvRating.HeaderRow.Cells[3].Text;
        //                    c.GEOPRAPHICAL_RATING = GLow;
        //                }
        //            }

        //        }

        //        c.insertClientData(dt);

        //        if (HttpContext.Current.Session["CFidx"] != null)
        //        {
        //            string cfid = HttpContext.Current.Session["CFidx"].ToString();
        //            foreach (ListItem item in ddlBank.Items)
        //            {
        //                if (item.Selected)
        //                {
        //                    string bank = item.Value;
        //                    c = new client();
        //                    db = new dal();
        //                    ds = new DataSet();
        //                    c.BankName = bank;
        //                    c.CFID = cfid.ToString();
        //                    c.insertBank(ds);
        //                }
        //            }


        //            foreach (GridViewRow row in GvAddress.Rows)
        //            {
        //                c.AddressTypee = row.Cells[0].Text;
        //                c.Address = row.Cells[1].Text;
        //                c.country = row.Cells[2].Text;
        //                c.city = row.Cells[3].Text;
        //                c.email = row.Cells[4].Text;
        //                c.Phone = row.Cells[5].Text;
        //                c.Fax = row.Cells[6].Text;
        //                c.CFID = cfid;
        //                c.insertAdress(ds);
        //            }

        //            foreach (GridViewRow row in gvBusClass.Rows)
        //            {
        //                c.Department = row.Cells[0].Text;
        //                c.BusinessCat = row.Cells[1].Text;
        //                c.Business = row.Cells[2].Text;
        //                c.InsuranceType = row.Cells[3].Text;
        //                c.exposure = row.Cells[4].Text;
        //                c.AgentRate = row.Cells[5].Text;
        //                c.CFID = cfid;
        //                c.insertDepart(ds);
        //            }


        //            foreach (ListItem item in ddlAgent.Items)
        //            {
        //                if (item.Selected)
        //                {
        //                    string agent = item.Value;
        //                    c = new client();
        //                    db = new dal();
        //                    ds = new DataSet();
        //                    c.Agent = agent;
        //                    c.CFID = cfid.ToString();
        //                    c.insertAgent(ds);
        //                }
        //            }





        //            //foreach (string s in HttpContext.Current.Request.Files)
        //            //{
        //            //    HttpContext.Current.Response.ContentType = "text/plain";
        //            //    HttpPostedFile file = HttpContext.Current.Request.Files[s];
        //            //    int fileSizeInBytes = file.ContentLength;
        //            //    string fileName = file.FileName;
        //            //    if (!string.IsNullOrEmpty(fileName))
        //            //    {
        //            //        string path = HttpContext.Current.Server.MapPath("~/documents/") + fileName;
        //            //        file.SaveAs(path);
        //            //        c = new client();
        //            //        db = new dal();
        //            //        ds = new DataSet();
        //            //        c.CFID = HttpContext.Current.Session["CFidx"].ToString();
        //            //        c.attachment = fileName.ToString();
        //            //        c.insertAttachment(ds);


        //            //    }
        //            //}

        //            //if (txtAggentRate.Text != null)
        //            //{
        //            //    ds = new DataSet();
        //            //    c.Department = ViewState["Dept"].ToString();
        //            //    c.Business = ViewState["bussClass"].ToString();
        //            //    c.GetRates(ds);

        //            //    if (ds.Tables[1].Rows.Count > 0)
        //            //    {
        //            //        Double rate = Double.Parse(ds.Tables[1].Rows[0]["STANDARD_RATE"].ToString());
        //            //        if (Double.Parse(txtAggentRate.Text) > rate)
        //            //        {
        //            //            c.status = "70";
        //            //            c.CFID = cfid.ToString();
        //            //            c.Assignto = "MURTAZA.H";
        //            //            c.UpdateCFStatus(ds);
        //            //            string CommissionAlert = "alert('Forward to Murtaza Hussain for Over Commission !')";
        //            //            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", CommissionAlert, true);

        //            //        }

        //            //    }
        //            //}





        //        }

        //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Add Successfully');window.location ='ClientDetails.aspx';", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        public void ProcessRequest()
        {
            try
            {
                foreach (string s in HttpContext.Current.Request.Files)
                {
                    HttpContext.Current.Response.ContentType = "text/plain";
                    HttpPostedFile file = HttpContext.Current.Request.Files[s];
                    int fileSizeInBytes = file.ContentLength;
                    string fileName = file.FileName;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        string path = HttpContext.Current.Server.MapPath("~/documents/") + fileName;
                        file.SaveAs(path);
                        c = new client();
                        db = new dal();
                        ds = new DataSet();
                        c.CFID = HttpContext.Current.Session["CFidx"].ToString();
                        c.attachment = fileName.ToString();
                        c.insertAttachment(ds);


                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        [WebMethod]
        public static void InsertPersonRecord(string comment, string userid, string cfEdit)
        {
            if (comment != null)
            {

                    dal db = new dal();
                    DataSet ds = new DataSet();
                    string date = DateTime.Now.ToString("dd-MMMM-yyyy hh:mm:ss");
                    Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "HICL_PRO_CFInsertComments";
                    cmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = HttpContext.Current.Session["CFidx"].ToString();
                    cmd.Parameters.Add("datime", OracleDbType.NVarchar2).Value = date;
                    cmd.Parameters.Add("comt", OracleDbType.NVarchar2).Value = comment;
                    cmd.Parameters.Add("userid", OracleDbType.NVarchar2).Value = userid;
                    db.getDataProcedure(cmd, ds);

                }
            

        }


        [WebMethod]
        public static void InsertUpdatePersonRecord(string comment, string userid, string cfEdit)
        {
            if (comment != null)
            {
                if (HttpContext.Current.Session["CFDetailid"] != null)
                {


                    dal db = new dal();
                    DataSet ds = new DataSet();
                    string date = DateTime.Now.ToString("dd-MMMM-yyyy hh:mm:ss");
                    string cfid = HttpContext.Current.Session["CFDetailid"].ToString();
                    Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "HICL_PRO_CFInsertComments";
                    cmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = cfEdit;
                    cmd.Parameters.Add("datime", OracleDbType.NVarchar2).Value = date;
                    cmd.Parameters.Add("comt", OracleDbType.NVarchar2).Value = comment;
                    cmd.Parameters.Add("userid", OracleDbType.NVarchar2).Value = userid;
                    db.getDataProcedure(cmd, ds);
                }
                else
                {
                    dal db = new dal();
                    DataSet ds = new DataSet();
                    string date = DateTime.Now.ToString("dd-MMMM-yyyy hh:mm:ss");

                    Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "HICL_PRO_CFInsertComments";
                    cmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = HttpContext.Current.Session["CFidx"].ToString();
                    cmd.Parameters.Add("datime", OracleDbType.NVarchar2).Value = date;
                    cmd.Parameters.Add("comt", OracleDbType.NVarchar2).Value = comment;
                    cmd.Parameters.Add("userid", OracleDbType.NVarchar2).Value = userid;
                    db.getDataProcedure(cmd, ds);
                }
            }
            else
            {

            }

        }
        //protected void AddAddress_Click(object sender, EventArgs e)
        //{

        //    DataTable dt = (DataTable)ViewState["CurrentAddress"];

        //    if (dt.Columns.Count == 0)
        //    {
        //        dt.Columns.Add("AddressType", typeof(string));
        //        dt.Columns.Add("Address", typeof(string));
        //        dt.Columns.Add("Country", typeof(string));
        //        dt.Columns.Add("City", typeof(string));
        //        dt.Columns.Add("Email", typeof(string));
        //        dt.Columns.Add("Phone", typeof(string));
        //        dt.Columns.Add("Fax", typeof(string));
        //    }

        //    DataRow NewRow = dt.NewRow();
        //    NewRow[0] = ddlAddressType.SelectedItem.Text;
        //    NewRow[1] = txtAdress.Text;
        //    NewRow[2] = ddlCountry.SelectedItem.Text;
        //    NewRow[3] = ddlCity.SelectedItem.Text;
        //    NewRow[4] = txtEmail.Text;
        //    NewRow[5] = txtPhone.Text;
        //    NewRow[6] = txtFax.Text;
        //    dt.Rows.Add(NewRow);
        //    GvAddress.DataSource = dt;
        //    GvAddress.DataBind();
        //    ViewState["CurrentAddress"] = dt;

        //}


        //public void FillAdreess()
        //{
        //    DataTable dt = new DataTable();
        //    GvAddress.DataSource = dt;
        //    GvAddress.DataBind();
        //    ViewState["CurrentAddress"] = dt;
        //}

        //public void FillBusclass()
        //{
        //    DataTable dt = new DataTable();
        //    gvBusClass.DataSource = dt;
        //    gvBusClass.DataBind();
        //    ViewState["CurrentBusClass"] = dt;
        //}

        //protected void GvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GvAddress.DeleteRow(e.RowIndex);
        //    GvAddress.DataBind();

        //}

        //protected void GvAddress_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Delete")
        //    {
        //        //var id = Int32.Parse(e.CommandArgument);
        //        //GVDetail.DeleteRow(id);
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        GvAddress.DeleteRow(index);

        //        ((DataTable)ViewState["CurrentAddress"]).Rows[index].Delete();
        //        ((DataTable)ViewState["CurrentAddress"]).AcceptChanges();
        //        GvAddress.DataSource = (DataTable)ViewState["CurrentAddress"];
        //        GvAddress.DataBind();

        //        //int index = Convert.ToInt32(e.CommandArgument);
        //        //GvAddress.DeleteRow(index);
        //    }
        //}

        //protected void GvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //}

        //protected void gvBusClass_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Delete")
        //    {

        //        int index = Convert.ToInt32(e.CommandArgument);
        //        gvBusClass.DeleteRow(index);

        //        ((DataTable)ViewState["CurrentBusClass"]).Rows[index].Delete();
        //        ((DataTable)ViewState["CurrentBusClass"]).AcceptChanges();
        //        gvBusClass.DataSource = (DataTable)ViewState["CurrentBusClass"];
        //        gvBusClass.DataBind();


        //    }
        //}

        //protected void gvBusClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //}

        //protected void btnAddBusClass_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = (DataTable)ViewState["CurrentBusClass"];

        //    if (dt.Columns.Count == 0)
        //    {
        //        dt.Columns.Add("Department", typeof(string));
        //        dt.Columns.Add("BussniessClassCategory", typeof(string));
        //        dt.Columns.Add("BussniessClass", typeof(string));
        //        dt.Columns.Add("InsuranceType", typeof(string));
        //        dt.Columns.Add("Exposure", typeof(string));
        //        dt.Columns.Add("Rate", typeof(string));

        //    }

        //    DataRow NewRow = dt.NewRow();
        //    if (ddlDeptment.SelectedItem.Text == null)
        //    {
        //        NewRow[0] = "";
        //    }
        //    else
        //    {
        //        NewRow[0] = ddlDeptment.SelectedItem.Text;

        //    }
        //    if (ddlBusClassCat.SelectedItem.Text == null)
        //    {
        //        NewRow[1] = "";
        //        ;
        //    }
        //    else
        //    {
        //        NewRow[1] = ddlBusClassCat.SelectedItem.Text;
        //    }
        //    if (ddlBusClass.SelectedIndex == -1)
        //    {
        //        NewRow[2] = "";
        //    }
        //    else
        //    {
        //        NewRow[2] = ddlBusClass.SelectedItem.Text;
        //    }

        //    if (ddlInsuranceType.SelectedItem.Text == null)
        //    {
        //        NewRow[3] = "";
        //    }
        //    else
        //    {
        //        NewRow[3] = ddlInsuranceType.SelectedItem.Text;
        //    }

        //    NewRow[4] = txtExposure.Text;
        //    NewRow[5] = txtRate.Text;

        //    dt.Rows.Add(NewRow);
        //    gvBusClass.DataSource = dt;
        //    gvBusClass.DataBind();
        //    ViewState["CurrentBusClass"] = dt;

        //}


        public void GetApprovedName()
        {
            db = new dal();
            c = new client();
            ds = new DataSet();
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Producer")
                {
                    c.statusStart = "1";
                    c.statusend = "11";
                }

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


                c.GetForward(ds);
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                //    {
                //        ListItem item = new ListItem();
                //        item.Text = ds.Tables[1].Rows[i]["USERID"].ToString();
                //        item.Value = ds.Tables[1].Rows[i]["STATUSIDX"].ToString();
                //        chkApproved.Items.Add(item);
                //    }

                //}
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


    }
}




