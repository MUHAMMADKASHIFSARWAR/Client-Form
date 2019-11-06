using ClientForm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clientForm
{
    public partial class clientFillForm : System.Web.UI.Page
    {
        private dal db;
        private client c;
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillRequestType();
                fillPrefix();
                fillBranch();
                fillInsurance();
                fillIndustry();
                fillDepartment();
                //ddlBussniessClass.SelectedIndex = 0;
                ddlCategory.Items.Insert(0, new ListItem("Select"));
                //ddlClientType.Items.Insert(0, new ListItem("Select Client Type.."));

            }
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
                ddlPrefix.Items.Insert(0, new ListItem("Select"));
            }
            catch (Exception ex)
            {
                lblMsg.Text = (ex.Message.ToString());
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

                ddlReqBranch.DataValueField = "PLC_LOCACODE";
                ddlReqBranch.DataTextField = "PLC_LOCADESC";
                ddlReqBranch.DataSource = dt;
                ddlReqBranch.DataBind();
                ddlReqBranch.Items.Insert(0, new ListItem("Select"));
                ddlBranch.Items.Insert(0, new ListItem("Select"));
            }
            catch (Exception ex)
            {
                lblMsg.Text = (ex.Message.ToString());
            }

        }
        public void fillIndustry()
        {
            try
            {

                //db = new dal();
                //dt = new DataTable();
                //c = new client();
                //ddlCompany.DataValueField = "PCD_CODE";
                //ddlCompany.DataTextField = "PCD_DESC";
                //c.getIndustry(dt);
                //ddlCompany.DataSource = dt;
                //ddlCompany.DataBind();
                //ddlCompany.Items.Insert(0, new ListItem("Select Company."));
            }
            catch (Exception ex)
            {
                lblMsg.Text = (ex.Message.ToString());
            }

        }
        public void fillInsurance()
        {
            try
            {

                //db = new dal();
                //dt = new DataTable();
                //c = new client();
                //ddlInsuranceType.DataValueField = "PIY_INSUTYPE";
                //ddlInsuranceType.DataTextField = "PIY_DESC";
                //c.getInsuranceType(dt);
                //ddlInsuranceType.DataSource = dt;
                //ddlInsuranceType.DataBind();
                //ddlInsuranceType.Items.Insert(0, new ListItem("Select Insurance Type."));
            }
            catch (Exception ex)
            {
                lblMsg.Text = (ex.Message.ToString());
            }

        }
        public void fillDepartment()
        {
            try
            {

                //db = new dal();
                //dt = new DataTable();
                //c = new client();
                //ddlDepartment.DataValueField = "PDP_DEPTCODE";
                //ddlDepartment.DataTextField = "PDP_DEPTDESC";
                //c.getDepartment(dt);
                //ddlDepartment.DataSource = dt;
                //ddlDepartment.DataBind();
                //ddlDepartment.Items.Insert(0, new ListItem("Select Department."));
            }
            catch (Exception ex)
            {
                lblMsg.Text = (ex.Message.ToString());
            }

        }
        public void fillBussniess(int PDP_DEPT_CODEVal)
        {
            try
            {


            }
            catch (Exception ex)
            {
                lblMsg.Text = (ex.Message.ToString());
            }

        }

        public void fillRequestType()
        {
            try
            {

                db = new dal();
                dt = new DataTable();
                c = new client();
                ddlRequestType.DataValueField = "PSP_STYPCODE";
                ddlRequestType.DataTextField = "PSP_STYPDESC";
                c.getRequestType(dt);
                ddlRequestType.DataSource = dt;
                ddlRequestType.DataBind();
                ddlRequestType.Items.Insert(0, new ListItem("Select Request Type."));
            }
            catch (Exception ex)
            {
                lblMsg.Text = (ex.Message.ToString());
            }

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int deptCode = Convert.ToInt32(ddlDepartment.SelectedValue.ToString());
            //db = new dal();
            //dt = new DataTable();
            //c = new client();
            //ddlBussniessClass.DataValueField = "PBC_BUSICLASS_CODE";
            //ddlBussniessClass.DataTextField = "PBC_DESC";
            //c.getBussniess(dt, deptCode);
            //ddlBussniessClass.DataSource = dt;
            //ddlBussniessClass.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            c.CFID = "CF-";
            c.issueDate = txtIssueDate.Text;
            if (ddlRequestType.SelectedItem.Text != "Select")
            {
                c.RequestType = ddlRequestType.SelectedValue;
            }
            else
            {
                c.RequestType = "";
            }
            if (ddlBranch.SelectedItem.Text != "Select")
            {
                c.Branch = ddlBranch.SelectedValue;
            }
            else
            {
                c.Branch = "";
            }
            if (ddlReqBranch.SelectedItem.Text != "Select")
            {
                c.BranchReq = ddlReqBranch.SelectedValue;
            }
            else
            {
                c.BranchReq = "";
            }

            c.exposure = txtExposure.Text;
            c.PREMIUM = txtPotential.Text;

            if (ddlCategory.SelectedItem.Text != "Select")
            {
                c.Category = ddlCategory.SelectedValue;
            }
            else
            {
                c.Category = "";
            }
            if (ddlPrefix.SelectedItem.Text != "Select")
            {
                c.Prefix = ddlPrefix.SelectedValue;
            }
            else
            {
                c.Prefix = "";
            }
            c.ClientName = txtName.Text;
            c.Address = txtAddress.Text;
            c.CNIC = txtNic.Text;
            c.NTN = txtNTN.Text;
            c.GST = txtGST.Text;
            c.CNICExpiry = txtCIExpiry.Text;
            if (chkFiler.Checked)
            {
                c.Filer = "Yes";
            }
            else
            {
                c.Filer = "NO";
            }
            c.ContactPerson = txtContactPerson.Text;
            c.ContactPersonNum = txtPhone.Text;
            c.ContactPersonCNIC = txtContactCnic.Text;
            c.Fax = txtFax.Text;
            c.ContactPersonCnicExpiry = txtCnicExpiry.Text;
            c.ProducerName = txtProducer.Text;
            c.Agent = txtAgent.Text;
            c.AgentRate = txtAggentRate.Text;



            //string path = Server.MapPath("documents/");
            //if (fileUplaod.HasFile)
            //{
            //    string ext = System.IO.Path.GetExtension(fileUplaod.FileName);
            //    if (ext == ".xls" || ext == ".xlsx")
            //    {
            //        fileUplaod.SaveAs(path + fileUplaod.FileName);
            //        string FilePath = "documents/" + fileUplaod.FileName;
            //    }
            //    else
            //    {
            //        string fileError = "alert('Only Excel File Select.')";
            //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", fileError, true);
            //    }
            //}

        }
    }

}
