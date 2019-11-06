using ClientForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clientForm
{
    public partial class test : System.Web.UI.Page
    {
        private DataTable dt;
        private client c;
        private DataSet ds;
        private dal db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    txtIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");



                    if (Session["Role"] != null)
                    {
                        getSession.Value = Session["Role"].ToString();
                      
                        if (Session["Role"].ToString() == "IT")
                        {
                            CForm.Visible = false;
                            CFDetail.Visible = false;
                            menu1.Visible = false;
                            home.Visible = false;
                            menu2.Visible = true;
                            menu2.Attributes.Add("class", "tab-pane fade in active");
                            ITTab.Attributes.Add("class", "active");

                        }
                        else if (Session["Role"].ToString() == "BranchManager")
                        {
                            CForm.Visible = true;
                            home.Visible = true;
                            finalize.Visible = false;
                            //menu2.Visible = false;
                            //menu1.Attributes.Add("class", "tab-pane fade in active");


                        }
                        if (Session["Role"].ToString() == "OperationHead")
                        {
                            CForm.Visible = false;
                            home.Visible = false;
                            finalize.Visible = false;
                            //menu2.Visible = false;
                            menu1.Attributes.Add("class", "tab-pane fade in active");
                            detailTab.Attributes.Add("class", "active");

                        }
                        if (Session["Role"].ToString() == "CommissionRate")
                        {
                            CForm.Visible = false;
                            home.Visible = false;
                            finalize.Visible = false;
                            //menu2.Visible = false;
                            menu1.Attributes.Add("class", "tab-pane fade in active");
                            detailTab.Attributes.Add("class", "active");


                        }
                        if (Session["Role"].ToString() == "ReInsurance")
                        {
                            CForm.Visible = false;
                            home.Visible = false;
                            finalize.Visible = false;
                            //menu2.Visible = false;
                            menu1.Attributes.Add("class", "tab-pane fade in active");
                            detailTab.Attributes.Add("class", "active");


                        }


                        if (Session["Role"].ToString() == "Producer")
                        {
                            menu2.Visible = false;
                            finalize.Visible = false;
                            AssigTab.Visible = true;
                            AssignedTab.Visible = true;
                            CFDetail.Visible = false;

                        }

                    }
                    getFinalizeclient();

                    lblUserName.Text = Session["FullName"].ToString();
                    //SetInitialRowPhone();
                    fillCompanyIndustry();
                    SetInitialRow();
                    SetInitialRowContPerson();
                    SetInitialRowDept();
                    fillclientGroup();
                    fillRequestType();
                    fillPrefix();
                    fillBranch();
                    setRating();
                    getBankName();
                    getAgent();
                    getInsType();
                    getclient();
                    //gvCFDept.DataSource = "";
                    //gvCFDept.DataBind();
                    //ddlCustType.Items.Insert(0, new ListItem("Select Customer Type.."));
                    ddlCategory.Items.Insert(0, new ListItem("Select"));
                    ddlGroupName.Items.Insert(0, new ListItem("Select"));


                    //var tab = Request.QueryString["tab"];
                    //if (tab == "2")
                    //{
                    //    CFDetail.Attributes.Add("class", "tab-pane fade in active");
                    //    menu1.Visible = false;
                    //    //CFDetail.Attributes["class"] = "tab-pane fade in active";


                    //}

                }


                catch (Exception ex)
                {

                    ex.Message.ToString();
                }
            }

        }


        public void setRating()
        {
            dt = new DataTable();
            dt.Columns.Add("Rating");
            dt.Rows.Add("Customer");
            dt.Rows.Add("Transaction");
            dt.Rows.Add("Geographical");
            GvRating.DataSource = dt;
            GvRating.DataBind();


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
                ex.Message.ToString();
                //lblMsg.Text = (ex.Message.ToString());
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
                ddlCompIndustry.Items.Insert(0, new ListItem("Select"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //lblMsg.Text = (ex.Message.ToString());
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
                ddlRequestType.Items.Insert(0, new ListItem("Select"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
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
                if (Session["clientbranch"] != null)
                {
                    ddlBranch.SelectedValue = Session["clientbranch"].ToString();
                }
                //ddlReqBranch.DataValueField = "PLC_LOCACODE";
                //ddlReqBranch.DataTextField = "PLC_LOCADESC";
                //ddlReqBranch.DataSource = dt;
                //ddlReqBranch.DataBind();
                //ddlReqBranch.Items.Insert(0, new ListItem("Select Requested Branch."));
                //ddlBranch.Items.Insert(0, new ListItem("Select Branch."));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

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

                //ddlReqBranch.DataValueField = "PLC_LOCACODE";
                //ddlReqBranch.DataTextField = "PLC_LOCADESC";
                //ddlReqBranch.DataSource = dt;
                //ddlReqBranch.DataBind();
                //ddlReqBranch.Items.Insert(0, new ListItem("Select Requested Branch."));
                //ddlBranch.Items.Insert(0, new ListItem("Select Branch."));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }


        protected void gvCFDept_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    DropDownList ddlDept = (DropDownList)e.Row.FindControl("ddlDept");

                    dt = new DataTable();
                    dt.Columns.Add("Department");
                    dt.Rows.Add("Fire");
                    dt.Rows.Add("Marine");
                    dt.Rows.Add("Motor");
                    dt.Rows.Add("Health");
                    dt.Rows.Add("Engineering");
                    dt.Rows.Add("Miscellaneous");
                    ddlDept.DataTextField = "Department";
                    ddlDept.DataValueField = "Department";
                    ddlDept.DataSource = dt;
                    ddlDept.DataBind();
                    ddlDept.Items.Insert(0, new ListItem("Select"));

                    DropDownList ddlBusClassCat = (DropDownList)e.Row.FindControl("ddlBusClassCat");
                    ddlBusClassCat.Items.Insert(0, new ListItem("Select Category"));

                    DropDownList ddlInsrType = (DropDownList)e.Row.FindControl("ddlInsrType");
                    db = new dal();
                    dt = new DataTable();
                    c = new client();
                    ddlInsrType.DataValueField = "PIY_INSUTYPE";
                    ddlInsrType.DataTextField = "PIY_DESC";
                    c.getInsuranceType(dt);
                    ddlInsrType.DataSource = dt;
                    ddlInsrType.DataBind();
                    ddlInsrType.Items.Insert(0, new ListItem("Select"));
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }



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

        public void getBankName()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            ddlBank.DataValueField = "PBN_BNK_CODE";
            ddlBank.DataTextField = "PBN_BNK_DESC";
            c.getBankList(dt);
            ddlBank.DataSource = dt;
            ddlBank.DataBind();


        }

        public void getAgent()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            ddlAgent.DataValueField = "PPS_PARTY_CODE";
            ddlAgent.DataTextField = "PPS_DESC";
            c.getAgent(dt);
            ddlAgent.DataSource = dt;
            ddlAgent.DataBind();
            ddlAgent.Items.Insert(0, new ListItem("Select Agent Name"));

        }


        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));//for TextBox value   



            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dr["Column7"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            Gridview1.DataSource = dt;
            Gridview1.DataBind();


        }

        private void AddNewRowToGrid()
        {

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   


                        DropDownList txtAddresType = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("txtAddresType");
                        TextBox txtAdress = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtAdress");
                        DropDownList txtCountry = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("txtCountry");
                        DropDownList txtCity = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("txtCity");
                        TextBox txtZipCode = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtZipCode");
                        TextBox txtFax = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtFax");
                        TextBox txtEmail = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtEmail");


                        dtCurrentTable.Rows[i]["Column1"] = txtAddresType.Text;
                        dtCurrentTable.Rows[i]["Column2"] = txtAdress.Text;
                        dtCurrentTable.Rows[i]["Column3"] = txtCountry.Text;
                        dtCurrentTable.Rows[i]["Column4"] = txtCity.Text;
                        dtCurrentTable.Rows[i]["Column5"] = txtZipCode.Text;
                        dtCurrentTable.Rows[i]["Column6"] = txtFax.Text;
                        dtCurrentTable.Rows[i]["Column7"] = txtEmail.Text;




                    }

                    //Rebind the Grid with the current data to reflect changes   
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData();
        }

        private void SetPreviousData()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DropDownList txtAddresType = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("txtAddresType");
                        TextBox txtAdress = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtAdress");
                        DropDownList txtCountry = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("txtCountry");
                        DropDownList txtCity = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("txtCity");
                        TextBox txtZipCode = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtZipCode");
                        TextBox txtFax = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtFax");
                        TextBox txtEmail = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtEmail");



                        //Fill the DropDownList with Data   


                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            txtAddresType.Text = dt.Rows[i]["Column1"].ToString();
                            txtAdress.Text = dt.Rows[i]["Column2"].ToString();
                            txtCountry.Text = dt.Rows[i]["Column3"].ToString();
                            txtCity.Text = dt.Rows[i]["Column4"].ToString();
                            txtZipCode.Text = dt.Rows[i]["Column5"].ToString();
                            txtFax.Text = dt.Rows[i]["Column6"].ToString();
                            txtEmail.Text = dt.Rows[i]["Column7"].ToString();



                            //Set the Previous Selected Items on Each DropDownList  on Postbacks   

                        }

                        rowIndex++;
                    }
                }
            }
        }



        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData();
        }

        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }


        ///Phone Grid
        /// 


        //private void SetInitialRowPhone()
        //{

        //    DataTable dt = new DataTable();
        //    DataRow dr = null;

        //    dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   



        //    dr = dt.NewRow();
        //    dr["RowNumber"] = 1;
        //    dr["Column1"] = string.Empty;
        //    dt.Rows.Add(dr);

        //    //Store the DataTable in ViewState for future reference   
        //    ViewState["CurrentTablePhone"] = dt;

        //    //Bind the Gridview   
        //    gvPhone.DataSource = dt;
        //    gvPhone.DataBind();


        //}

        //private void AddNewRowToGridPhone()
        //{

        //    if (ViewState["CurrentTablePhone"] != null)
        //    {

        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTablePhone"];
        //        DataRow drCurrentRow = null;

        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            drCurrentRow = dtCurrentTable.NewRow();
        //            drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

        //            //add new row to DataTable   
        //            dtCurrentTable.Rows.Add(drCurrentRow);
        //            //Store the current data to ViewState for future reference   

        //            ViewState["CurrentTablePhone"] = dtCurrentTable;


        //            for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
        //            {

        //                //extract the TextBox values   

        //                TextBox box1 = (TextBox)gvPhone.Rows[i].Cells[1].FindControl("TextBox1");


        //                dtCurrentTable.Rows[i]["Column1"] = box1.Text;



        //            }

        //            //Rebind the Grid with the current data to reflect changes   
        //            gvPhone.DataSource = dtCurrentTable;
        //            gvPhone.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("ViewState is null");

        //    }
        //    //Set Previous Data on Postbacks   
        //    SetPreviousDataPhone();
        //}

        //private void SetPreviousDataPhone()
        //{

        //    int rowIndex = 0;
        //    if (ViewState["CurrentTablePhone"] != null)
        //    {

        //        DataTable dt = (DataTable)ViewState["CurrentTablePhone"];
        //        if (dt.Rows.Count > 0)
        //        {

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {

        //                TextBox box1 = (TextBox)gvPhone.Rows[i].Cells[1].FindControl("TextBox1");


        //                //Fill the DropDownList with Data   


        //                if (i < dt.Rows.Count - 1)
        //                {

        //                    //Assign the value from DataTable to the TextBox   
        //                    box1.Text = dt.Rows[i]["Column1"].ToString();


        //                    //Set the Previous Selected Items on Each DropDownList  on Postbacks   

        //                }

        //                rowIndex++;
        //            }
        //        }
        //    }
        //}



        //protected void ButtonAddPhone_Click(object sender, EventArgs e)
        //{
        //    AddNewRowToGridPhone();
        //}

        //protected void gvPhone_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataTable dt = (DataTable)ViewState["CurrentTablePhone"];
        //        LinkButton lb = (LinkButton)e.Row.FindControl("LinkButtonPhone");
        //        if (lb != null)
        //        {
        //            if (dt.Rows.Count > 1)
        //            {
        //                if (e.Row.RowIndex == dt.Rows.Count - 1)
        //                {
        //                    lb.Visible = false;
        //                }
        //            }
        //            else
        //            {
        //                lb.Visible = false;
        //            }
        //        }
        //    }
        //}

        //protected void LinkButton1Phone_Click(object sender, EventArgs e)
        //{
        //    LinkButton lb = (LinkButton)sender;
        //    GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        //    int rowID = gvRow.RowIndex;
        //    if (ViewState["CurrentTablePhone"] != null)
        //    {

        //        DataTable dt = (DataTable)ViewState["CurrentTablePhone"];
        //        if (dt.Rows.Count > 1)
        //        {
        //            if (gvRow.RowIndex < dt.Rows.Count - 1)
        //            {
        //                //Remove the Selected Row data and reset row number  
        //                dt.Rows.Remove(dt.Rows[rowID]);
        //                ResetRowIDPhone(dt);
        //            }
        //        }

        //        //Store the current data in ViewState for future reference  
        //        ViewState["CurrentTablePhone"] = dt;

        //        //Re bind the GridView for the updated data  
        //        gvPhone.DataSource = dt;
        //        gvPhone.DataBind();
        //    }

        //    //Set Previous Data on Postbacks  
        //    SetPreviousDataPhone();
        //}

        //private void ResetRowIDPhone(DataTable dt)
        //{
        //    int rowNumber = 1;
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            row[0] = rowNumber;
        //            rowNumber++;
        //        }
        //    }
        //}


        public void getInsType()
        {
            db = new dal();
            dt = new DataTable();
            c = new client();
            ddlInsType.DataValueField = "PIY_INSUTYPE";
            ddlInsType.DataTextField = "PIY_DESC";
            c.getInsuranceType(dt);
            ddlInsType.DataSource = dt;
            ddlInsType.DataBind();
            ddlInsType.Items.Insert(0, new ListItem("Select"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                c = new client();
                db = new dal();
                ds = new DataSet();
                dt = new DataTable();
                c.CFID = "CF-";
                c.issueDate = txtIssueDate.Text;
                if (ddlCategory.SelectedItem.Text == "Select")
                {
                    c.clientType = "";
                }
                else
                {
                    c.clientType = ddlCategory.SelectedItem.Text;
                }
                if (ddlGroupName.SelectedItem.Text == "Select")
                {
                    c.GroupName = "";
                }
                else
                {
                    c.GroupName = ddlGroupName.SelectedItem.Text;
                }
                if (ddlPrefix.SelectedItem.Text == "Select")
                {
                    c.Prefix = "";
                }
                else
                {
                    c.Prefix = ddlPrefix.SelectedValue;
                }
                c.companyInd = ddlCompIndustry.SelectedValue;
                c.status = Session["statusidx"].ToString();
                c.ClientName = txtName.Text;
                c.CNIC = txtNic.Text;
                c.reference = txtReference.Text;
                c.CNICExpiry = txtCIExpiry.Text;
                c.Assignto = Session["NEXTAPPROVAL"].ToString();
                c.assignUSer = Session["USERID"].ToString();
                c.NTN = txtNTN.Text;
                c.GST = txtGST.Text;
                c.ContactPerson = txtContactPerson.Text;
                c.ContactPersonCnic = txtContactCnic.Text;
                c.ContactPersonCnicExpiry = txtCPnicExpire.Text;
                c.remarks = txtComment.Text;
                if (ddlInsType.SelectedItem.Text == "Select")
                {
                    c.InsuranceType = "";
                }
                else
                {
                    c.InsuranceType = ddlInsType.SelectedValue;
                }

                foreach (ListItem item in chkFiler.Items)
                {
                    if (item.Selected)
                    {
                        string filer = item.Value;
                        c.Filer = filer;
                    }
                }

                if (ddlRequestType.SelectedItem.Text == "Select")
                {
                    c.RequestType = "";
                }
                else
                {
                    c.RequestType = ddlRequestType.SelectedValue;
                }

                c.Branch = ddlBranch.SelectedValue;
                c.RequestUser = Session["USERID"].ToString();
                c.creationDate = DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss");
                if (Session["statusidx"] != null)
                {
                    c.status = Session["statusidx"].ToString();
                }

                c.exposure = txtExposure.Text;
                c.PREMIUM = txtPotential.Text;

                foreach (ListItem item in chkResNoRes.Items)
                {
                    if (item.Selected)
                    {
                        string resident = item.Value;
                        c.resident = resident;
                    }
                }
                c.ProducerName = txtProducer.Text;
                c.AgentRate = txtAggentRate.Text;



                foreach (GridViewRow row in GvRating.Rows)
                {
                    if (row.Cells[0].Text == "Customer")
                    {
                        CheckBox high = (CheckBox)row.FindControl("chkHigh");
                        if (high.Checked)
                        {
                            string Chigt = GvRating.HeaderRow.Cells[1].Text;
                            c.customerRating = Chigt;
                        }

                        CheckBox medium = (CheckBox)row.FindControl("chkMed");
                        if (medium.Checked)
                        {
                            string Cmedium = GvRating.HeaderRow.Cells[2].Text;
                            c.customerRating = Cmedium;
                        }


                        CheckBox low = (CheckBox)row.FindControl("chkLow");
                        if (low.Checked)
                        {
                            string CLow = GvRating.HeaderRow.Cells[3].Text;
                            c.customerRating = CLow;
                        }
                    }
                    if (row.Cells[0].Text == "Transaction")
                    {
                        CheckBox high = (CheckBox)row.FindControl("chkHigh");
                        if (high.Checked)
                        {
                            string Thigh = GvRating.HeaderRow.Cells[1].Text;
                            c.TRANSACTION_RATING = Thigh;
                        }

                        CheckBox medium = (CheckBox)row.FindControl("chkMed");
                        if (medium.Checked)
                        {
                            string Tmedium = GvRating.HeaderRow.Cells[2].Text;
                            c.TRANSACTION_RATING = Tmedium;
                        }


                        CheckBox low = (CheckBox)row.FindControl("chkLow");
                        if (low.Checked)
                        {
                            string TLow = GvRating.HeaderRow.Cells[3].Text;
                            c.TRANSACTION_RATING = TLow;
                        }
                    }
                    if (row.Cells[0].Text == "Geographical")
                    {
                        CheckBox high = (CheckBox)row.FindControl("chkHigh");
                        if (high.Checked)
                        {
                            string Ghigt = GvRating.HeaderRow.Cells[1].Text;
                            c.GEOPRAPHICAL_RATING = Ghigt;
                        }

                        CheckBox medium = (CheckBox)row.FindControl("chkMed");
                        if (medium.Checked)
                        {
                            string Gmedium = GvRating.HeaderRow.Cells[2].Text;
                            c.GEOPRAPHICAL_RATING = Gmedium;
                        }


                        CheckBox low = (CheckBox)row.FindControl("chkLow");
                        if (low.Checked)
                        {
                            string GLow = GvRating.HeaderRow.Cells[3].Text;
                            c.GEOPRAPHICAL_RATING = GLow;
                        }
                    }

                }

                c.insertClientData(dt);

                if (HttpContext.Current.Session["CFidx"] != null)
                {
                    string cfid = HttpContext.Current.Session["CFidx"].ToString();
                    foreach (ListItem item in ddlBank.Items)
                    {
                        if (item.Selected)
                        {
                            string bank = item.Value;
                            c = new client();
                            db = new dal();
                            ds = new DataSet();
                            c.BankName = bank;
                            c.CFID = cfid.ToString();
                            c.insertBank(ds);
                        }
                    }
                    foreach (GridViewRow row in Gridview1.Rows)
                    {
                        //string address = row.Cells[1].Text;

                        DropDownList txtAddresType = (DropDownList)row.FindControl("txtAddresType");
                        TextBox txtAdress = (TextBox)row.FindControl("txtAdress");
                        DropDownList txtCountry = (DropDownList)row.FindControl("txtCountry");
                        DropDownList txtCity = (DropDownList)row.FindControl("txtCity");
                        TextBox txtZipCode = (TextBox)row.FindControl("txtZipCode");
                        TextBox txtFax = (TextBox)row.FindControl("txtFax");
                        TextBox txtEmail = (TextBox)row.FindControl("txtEmail");


                        c = new client();
                        db = new dal();
                        ds = new DataSet();
                        c.CFID = cfid.ToString();
                        c.AddressTypee = txtAddresType.SelectedValue;
                        c.Address = txtAdress.Text;
                        c.country = txtCountry.SelectedValue;
                        c.city = txtCity.SelectedValue;
                        c.zipcode = txtZipCode.Text;
                        c.Fax = txtFax.Text;
                        c.email = txtEmail.Text;

                        c.insertAdress(ds);

                        ds = new DataSet();
                        c.GetRates(ds);

                    }
                    //foreach (GridViewRow row in gvPhone.Rows)
                    //{

                    //    TextBox Phone = (TextBox)row.FindControl("TextBox1");
                    //    c = new client();
                    //    db = new dal();
                    //    ds = new DataSet();
                    //    c.ContactNum = Phone.Text;
                    //    c.CFID = cfid.ToString();
                    //    c.insertPhone(ds);
                    //}
                    //foreach (ListItem item in ddlBranch.Items)
                    //{
                    //    if (item.Selected)
                    //    {
                    //        string branch = item.Value;
                    //        c = new client();
                    //        db = new dal();
                    //        ds = new DataSet();
                    //        c.Branch = branch;
                    //        c.CFID = cfid.ToString();
                    //        c.insertBranch(ds);
                    //    }
                    ////}
                    //c = new client();
                    //db = new dal();
                    //ds = new DataSet();
                    //c.Branch = ddlBranch.SelectedValue; 
                    //c.CFID = cfid.ToString();
                    //c.insertBranch(ds);
                    foreach (GridViewRow row in GvContactPrson.Rows)
                    {
                        TextBox contperson = (TextBox)row.FindControl("txtcontactPerson");
                        TextBox ContPersonCnic = (TextBox)row.FindControl("txtContactPersonCnic");
                        TextBox CPCnicExp = (TextBox)row.FindControl("txtContactPersonCnicExpiry");
                        TextBox ContPerNtn = (TextBox)row.FindControl("txtContactPersonNtn");
                        TextBox ContPErGst = (TextBox)row.FindControl("txtcontactPersonGst");
                        TextBox ContPErAdd = (TextBox)row.FindControl("txtContPerAddresss");
                        TextBox ContPErNub = (TextBox)row.FindControl("txtContPerNumb");

                        c = new client();
                        db = new dal();
                        dt = new DataTable();
                        c.CFID = cfid.ToString();
                        c.ContactPerson = contperson.Text;
                        c.ContactPersonCnic = ContPersonCnic.Text;
                        c.ContactPersonCnicExpiry = CPCnicExp.Text;
                        c.ContactPersonNtn = ContPerNtn.Text;
                        c.ContactPersonGst = ContPErGst.Text;
                        c.ContactPersonAddress = ContPErAdd.Text;
                        c.ContactPersonNum = ContPErNub.Text;

                        c.InsertContPerson(dt);
                    }
                    foreach (GridViewRow row in gvCFDept.Rows)
                    {

                        DropDownList Department = (DropDownList)row.FindControl("ddlDept");
                        DropDownList bussniessclassCat = (DropDownList)row.FindControl("ddlBusClassCat");
                        DropDownList bussniessclass = (DropDownList)row.FindControl("ddlBusClass");
                        DropDownList InsureType = (DropDownList)row.FindControl("ddlInsrType");
                        TextBox exposure = (TextBox)row.FindControl("txtExposure");
                        TextBox rate = (TextBox)row.FindControl("txtRate");
                        //TextBox commission = (TextBox)row.FindControl("txtCommession");
                        c = new client();
                        db = new dal();
                        ds = new DataSet();
                        c.CFID = cfid.ToString();
                        c.Department = Department.Text.ToString();
                        c.BusinessCat = bussniessclassCat.Text.ToString();
                        c.Business = bussniessclass.Text.ToString();
                        c.InsuranceType = InsureType.SelectedItem.Text.ToString();
                        c.AgentRate = rate.Text.ToString();
                        c.comission = "";
                        c.exposure = exposure.Text.ToString();
                        ViewState["Dept"] = Department.Text.ToString();
                        ViewState["bussClass"] = bussniessclass.SelectedItem.Text;

                        c.insertDepart(ds);





                    }
                    foreach (ListItem item in ddlAgent.Items)
                    {
                        if (item.Selected)
                        {
                            string agent = item.Value;
                            c = new client();
                            db = new dal();
                            ds = new DataSet();
                            c.Agent = agent;
                            c.CFID = cfid.ToString();
                            c.insertAgent(ds);
                        }
                    }

                    foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);

                        if (fileName != "")
                        {
                            postedFile.SaveAs(Server.MapPath("~/documents/") + fileName);
                            //string fullpath = (Server.MapPath("~/documents/") + fileName);

                            c = new client();
                            db = new dal();
                            ds = new DataSet();
                            c.CFID = cfid.ToString();
                            c.attachment = fileName.ToString();
                            c.insertAttachment(ds);

                        }
                    }
                    if (txtAggentRate.Text != null)
                    {
                        ds = new DataSet();
                        c.Department = ViewState["Dept"].ToString();
                        c.Business = ViewState["bussClass"].ToString();
                        c.GetRates(ds);

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            Double rate = Double.Parse(ds.Tables[1].Rows[0]["STANDARD_RATE"].ToString());
                            if (Double.Parse(txtAggentRate.Text) > rate)
                            {
                                c.status = "70";
                                c.CFID = cfid.ToString();
                                c.Assignto = "MURTAZA.H";
                                c.UpdateCFStatus(ds);
                                string CommissionAlert = "alert('Forward to Murtaza Hussain for Over Commission !')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", CommissionAlert, true);

                            }
                           
                        }
                    }

                    //lblSuccess.Text = string.Format("{0} files have been uploaded successfully.", FileUpload1.PostedFiles.Count);



                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Add Successfully');window.location ='NewClientForm.aspx';", true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }


        public void getclient()
        {
            dt = new DataTable();
            db = new dal();
            c = new client();
            if (Session["Role"] != null)
            {
                c.role = Session["Role"].ToString();


                if (Session["clientbranch"] != null)
                {


                    c.Branch = Session["clientbranch"].ToString();
                    if (Session["Role"].ToString() == "BranchManager")
                    {
                        c.statusStart = "0";
                        c.statusend = "10";
                    }
                    else if (Session["USERID"].ToString() == "FAWWADD")
                    {
                        c.statusStart = "30";
                        c.statusend = "30";
                    }
                    else if (Session["USERID"].ToString() == "Tariq")
                    {
                        c.statusStart = "40";
                        c.statusend = "40";
                    }
                    else if (Session["USERID"].ToString() == "OMARZUBAIR")
                    {
                        c.statusStart = "50";
                        c.statusend = "50";
                    }
                    else if (Session["USERID"].ToString() == "MURTAZA.H")
                    {
                        c.statusStart = "70";
                        c.statusend = "70";
                    }

                    else if (Session["USERID"].ToString() == "ReInsurance")
                    {
                        c.statusStart = "80";
                        c.statusend = "80";
                    }


                    c.GetClient(dt);
                    gvClientForm.DataSource = dt;
                    gvClientForm.DataBind();
                    Session["clientData"] = dt;
                    string ToDate = DateTime.Now.ToShortDateString();
                    string SetToDate = DateTime.Parse(DateTime.Parse(ToDate).ToString("dd/MMM/yyyy")).ToString("dd/MMM/yyyy");
                    txtToDate.Text = SetToDate;
                    txtFromDate.Text = "01/Jan/2018";
                }
            }
            //if (Session["USERID"] != null)
            //{

            //    c.username = Session["USERID"].ToString();
            //    c.GetApproveUser(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        string getStatusidx = dt.Rows[0]["STATUSIDX"].ToString();
            //        dt = new DataTable();
            //        c.status = getStatusidx.ToString();
            //        c.GetClient(dt);
            //        gvClientForm.DataSource = dt;
            //        gvClientForm.DataBind();

            //        Session["clientData"] = dt;
            //        string ToDate = DateTime.Now.ToShortDateString();
            //        string SetToDate = DateTime.Parse(DateTime.Parse(ToDate).ToString("dd/MMM/yyyy")).ToString("dd/MMM/yyyy");
            //        txtToDate.Text = SetToDate;
            //        txtFromDate.Text = "01/Jan/2018";
            //    }

            //}

            else
            {

            }



        }
        public void getFinalizeclient()
        {
            dt = new DataTable();
            db = new dal();
            c = new client();
            ds = new DataSet();
            if (Session["USERID"] != null)
            {

              
                c.status = "90";
                c.GetFinalizeClient(dt);
                gvFinaliazeclient.DataSource = dt;
                gvFinaliazeclient.DataBind();
                Session["getFinalizeClient"] = dt;
                string ToDate = DateTime.Now.ToShortDateString();
                string SetToDate = DateTime.Parse(DateTime.Parse(ToDate).ToString("dd/MMM/yyyy")).ToString("dd/MMM/yyyy");
                txttoDateFinal.Text = SetToDate;
                txtfromDateFinal.Text = "01/Jan/2018";


            }

            else
            {

            }



        }



        protected void gvClientForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvClientForm.PageIndex = e.NewPageIndex;
                if (Session["FilterClientData"] == null)
                {
                    this.getclient();
                }
                else
                {
                    gvClientForm.DataSource = Session["FilterClientData"];
                    gvClientForm.DataBind();
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }



        protected void linkViewDetail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            string cfid = gvClientForm.DataKeys[i].Values["CF_ID"].ToString();
            Session["CFID"] = cfid;
            string locCode = gvClientForm.DataKeys[i].Values["LOC_CODE"].ToString();
            Session["locCodeRevert"] = locCode;
            //Response.Redirect("clientFormDetails.aspx?cfid="+ cfid);
            this.mp2.Show();
        }

        protected void lnkGVReload_Click(object sender, EventArgs e)
        {
            getclient();
        }



        protected void lnkFinalize_Click(object sender, EventArgs e)
        {
            getFinalizeclient();
        }

        protected void gvFinaliazeclient_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvFinaliazeclient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvFinaliazeclient.PageIndex = e.NewPageIndex;
                if (Session["FilterClientDataFinal"] == null)
                {
                    this.getclient();
                }
                else
                {
                    gvFinaliazeclient.DataSource = Session["FilterClientDataFinal"];
                    gvFinaliazeclient.DataBind();
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["clientData"];
                string expression = string.Empty;
                if (dt != null)
                {
                    if (txtToDate.Text != "" && txtFromDate.Text != "")
                    {
                        string ToDate = txtToDate.Text;
                        string SetToDate = DateTime.Parse(DateTime.Parse(ToDate).ToString("dd/MMMM/yyyy")).ToString("MM-dd-yyyy");
                        string FromDate = txtFromDate.Text;
                        string SetFromDate = DateTime.Parse(DateTime.Parse(FromDate).ToString("dd/MMMM/yyyy")).ToString("MM-dd-yyyy");
                        expression += "CFDate >='" + SetFromDate + "' AND CFDate <='" + SetToDate + "'";



                    }

                    if (txtClient.Text != "")
                    {
                        expression += "AND CLIENT_NAME like '%" + txtClient.Text + "%'";


                    }

                    if (txtcnics.Text != "")
                    {
                        expression += "AND CLIENT_CNIC like '%" + txtcnics.Text + "%'";

                    }
                    if (txtgsts.Text != "")
                    {
                        expression += "AND CLIENT_GST like '%" + txtgsts.Text + "%'";

                    }
                    if (txtntns.Text != "")
                    {
                        expression += "AND CLIENT_NTN like '%" + txtntns.Text + "%'";

                    }


                    expression = expression.TrimStart("AND".ToCharArray()).TrimEnd("AND".ToCharArray());

                }
                if (!String.IsNullOrEmpty(expression))
                {
                    DataRow[] filteredRows = dt.Select(expression);
                    if (filteredRows.Length > 0)
                    {
                        DataTable newDataTable = filteredRows.CopyToDataTable<DataRow>();
                        Session["FilterClientData"] = newDataTable;
                        gvClientForm.DataSource = Session["FilterClientData"];
                        gvClientForm.DataBind();
                    }
                    else
                    {
                        gvClientForm.DataSource = null;
                        gvClientForm.DataBind();

                    }

                }

            }


            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnSearchFinal_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["getFinalizeClient"];
                string expression = string.Empty;
                if (dt != null)
                {
                    if (txtToDate.Text != "" && txtFromDate.Text != "")
                    {
                        string ToDate = txttoDateFinal.Text;
                        string SetToDate = DateTime.Parse(DateTime.Parse(ToDate).ToString("dd/MMMM/yyyy")).ToString("MM-dd-yyyy");
                        string FromDate = txtfromDateFinal.Text;
                        string SetFromDate = DateTime.Parse(DateTime.Parse(FromDate).ToString("dd/MMMM/yyyy")).ToString("MM-dd-yyyy");
                        expression += "CFDate >='" + SetFromDate + "' AND CFDate <='" + SetToDate + "'";



                    }

                    if (txtclientFinal.Text != "")
                    {
                        expression += "AND CLIENT_NAME like '%" + txtclientFinal.Text + "%'";


                    }

                    if (txtcnicFinal.Text != "")
                    {
                        expression += "AND CLIENT_CNIC like '%" + txtcnicFinal.Text + "%'";

                    }
                    if (txtgstFinal.Text != "")
                    {
                        expression += "AND CLIENT_GST like '%" + txtgstFinal.Text + "%'";

                    }
                    if (txtntnFinal.Text != "")
                    {
                        expression += "AND CLIENT_NTN like '%" + txtntnFinal.Text + "%'";

                    }


                    expression = expression.TrimStart("AND".ToCharArray()).TrimEnd("AND".ToCharArray());

                }
                if (!String.IsNullOrEmpty(expression))
                {
                    DataRow[] filteredRows = dt.Select(expression);
                    if (filteredRows.Length > 0)
                    {
                        DataTable newDataTable = filteredRows.CopyToDataTable<DataRow>();
                        Session["FilterClientDataFinal"] = newDataTable;
                        gvFinaliazeclient.DataSource = Session["FilterClientDataFinal"];
                        gvFinaliazeclient.DataBind();
                    }
                    else
                    {
                        gvFinaliazeclient.DataSource = null;
                        gvFinaliazeclient.DataBind();

                    }

                }

            }


            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void linkFinalView_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            string cfid = gvFinaliazeclient.DataKeys[i].Values["CF_ID"].ToString();
            Session["CFID"] = cfid;




            this.mpF.Show();
        }

        protected void lnkContPersonDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTableContPerson"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTableContPerson"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowIDContPerson(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTableContPerson"] = dt;

                //Re bind the GridView for the updated data  
                GvContactPrson.DataSource = dt;
                GvContactPrson.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousDataContPerson();
        }

        protected void GvContactPrson_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableContPerson"];
                LinkButton lb = (LinkButton)e.Row.FindControl("lnkContPersonDelete");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }


        private void SetInitialRowContPerson()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));//for TextBox value   





            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dr["Column7"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTableContPerson"] = dt;

            //Bind the Gridview   
            GvContactPrson.DataSource = dt;
            GvContactPrson.DataBind();


        }

        private void AddNewRowToGridContPerson()
        {

            if (ViewState["CurrentTableContPerson"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableContPerson"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTableContPerson"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox contperson = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtcontactPerson");
                        TextBox ContPersonCnic = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContactPersonCnic");
                        TextBox CPCnicExp = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContactPersonCnicExpiry");
                        TextBox ContPerNtn = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContactPersonNtn");
                        TextBox ContPErGst = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtcontactPersonGst");
                        TextBox ContPErAdd = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContPerAddresss");
                        TextBox ContPErNub = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContPerNumb");

                        dtCurrentTable.Rows[i]["Column1"] = contperson.Text;
                        dtCurrentTable.Rows[i]["Column2"] = ContPersonCnic.Text;
                        dtCurrentTable.Rows[i]["Column3"] = CPCnicExp.Text;
                        dtCurrentTable.Rows[i]["Column4"] = ContPerNtn.Text;
                        dtCurrentTable.Rows[i]["Column5"] = ContPErGst.Text;
                        dtCurrentTable.Rows[i]["Column6"] = ContPErAdd.Text;
                        dtCurrentTable.Rows[i]["Column7"] = ContPErNub.Text;

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GvContactPrson.DataSource = dtCurrentTable;
                    GvContactPrson.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousDataContPerson();
        }

        private void SetPreviousDataContPerson()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTableContPerson"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTableContPerson"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox contperson = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtcontactPerson");
                        TextBox ContPersonCnic = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContactPersonCnic");
                        TextBox CPCnicExp = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContactPersonCnicExpiry");
                        TextBox ContPerNtn = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContactPersonNtn");
                        TextBox ContPErGst = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtcontactPersonGst");
                        TextBox ContPErAdd = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContPerAddresss");
                        TextBox ContPErNumb = (TextBox)GvContactPrson.Rows[i].Cells[1].FindControl("txtContPerNumb");


                        //Fill the DropDownList with Data   


                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            contperson.Text = dt.Rows[i]["Column1"].ToString();
                            ContPersonCnic.Text = dt.Rows[i]["Column2"].ToString();
                            CPCnicExp.Text = dt.Rows[i]["Column3"].ToString();
                            ContPerNtn.Text = dt.Rows[i]["Column4"].ToString();
                            ContPErGst.Text = dt.Rows[i]["Column5"].ToString();
                            ContPErGst.Text = dt.Rows[i]["Column6"].ToString();
                            ContPErNumb.Text = dt.Rows[i]["Column7"].ToString();


                            //Set the Previous Selected Items on Each DropDownList  on Postbacks   

                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void btnContPerson_Click(object sender, EventArgs e)
        {
            AddNewRowToGridContPerson();
        }

        private void ResetRowIDContPerson(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        protected void btnDeptAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGridDept();
            //Button ddlDeptSend = (Button)sender;
            //GridViewRow row = (GridViewRow)ddlDeptSend.NamingContainer;
            //DropDownList Dept = (DropDownList)row.FindControl("ddlDept");
            //Dept.SelectedItem.Text.ToString();
        }

        protected void lnkDepartmentDelete_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTableDept"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTableDept"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowIDDept(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTableContPerson"] = dt;

                //Re bind the GridView for the updated data  
                gvCFDept.DataSource = dt;
                gvCFDept.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousDataDept();
        }

        protected void gvCFDept_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableDept"];
                LinkButton lb = (LinkButton)e.Row.FindControl("lnkDepartmentDelete");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        private void SetInitialRowDept()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));//for TextBox value   





            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dr["Column7"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTableDept"] = dt;

            //Bind the Gridview   
            gvCFDept.DataSource = dt;
            gvCFDept.DataBind();


        }

        private void AddNewRowToGridDept()
        {

            if (ViewState["CurrentTableDept"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableDept"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTableDept"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   
                        DropDownList Department = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlDept");
                        DropDownList BussClassCat = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlBusClassCat");
                        DropDownList bussniessclass = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlBusClass");
                        DropDownList InsuranceType = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlInsrType");
                        TextBox Exposure = (TextBox)gvCFDept.Rows[i].Cells[1].FindControl("txtExposure");
                        TextBox Rate = (TextBox)gvCFDept.Rows[i].Cells[1].FindControl("txtRate");
                        //TextBox Commession = (TextBox)gvCFDept.Rows[i].Cells[1].FindControl("txtCommession");



                        dtCurrentTable.Rows[i]["Column1"] = Department.Text;
                        dtCurrentTable.Rows[i]["Column2"] = BussClassCat.Text;
                        dtCurrentTable.Rows[i]["Column3"] = bussniessclass.Text;
                        dtCurrentTable.Rows[i]["Column4"] = InsuranceType.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column5"] = Exposure.Text;
                        dtCurrentTable.Rows[i]["Column6"] = Rate.Text;





                    }

                    //Rebind the Grid with the current data to reflect changes   
                    gvCFDept.DataSource = dtCurrentTable;
                    gvCFDept.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousDataDept();
        }


        private void SetPreviousDataDept()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTableDept"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTableDept"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DropDownList Department = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlDept");
                        DropDownList BussClassCat = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlBusClassCat");
                        DropDownList bussniessclass = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlBusClass");
                        DropDownList InsuranceType = (DropDownList)gvCFDept.Rows[i].Cells[1].FindControl("ddlInsrType");
                        TextBox Exposure = (TextBox)gvCFDept.Rows[i].Cells[1].FindControl("txtExposure");
                        TextBox Rate = (TextBox)gvCFDept.Rows[i].Cells[1].FindControl("txtRate");
                        //TextBox Commession = (TextBox)gvCFDept.Rows[i].Cells[1].FindControl("txtCommession");


                        //Fill the DropDownList with Data   


                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            Department.Text = dt.Rows[i]["Column1"].ToString();
                            BussClassCat.SelectedItem.Text = dt.Rows[i]["Column2"].ToString();
                            bussniessclass.Text = dt.Rows[i]["Column3"].ToString();
                            InsuranceType.SelectedItem.Text = dt.Rows[i]["Column4"].ToString();
                            Exposure.Text = dt.Rows[i]["Column5"].ToString();
                            Rate.Text = dt.Rows[i]["Column6"].ToString();
                            //Commession.Text = dt.Rows[i]["Column7"].ToString();


                            //Set the Previous Selected Items on Each DropDownList  on Postbacks   

                        }

                        rowIndex++;


                    }
                }
            }

        }
        private void ResetRowIDDept(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        protected void ddlBusClassCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlDeptSend = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlDeptSend.NamingContainer;
            DropDownList Dept = (DropDownList)row.FindControl("ddlDept");
            DropDownList BusClassCat = (DropDownList)row.FindControl("ddlBusClassCat");
            DropDownList Department = (DropDownList)row.FindControl("ddlDept");

            // BusClassCat.SelectedItem.Text = Session["BussClass"].ToString();


            DropDownList ddlBussClass = (DropDownList)row.FindControl("ddlBusClass");

            db = new dal();
            c = new client();
            dt = new DataTable();
            c.Department = Department.SelectedItem.Text;
            if (BusClassCat.SelectedItem.Text != null)
            {
                c.BusinessCat = BusClassCat.SelectedItem.Text;
                c.getBussClass(dt);
                ddlBussClass.DataTextField = "PBC_DESC";
                ddlBussClass.DataValueField = "PBC_BUSICLASS_CODE";
                ddlBussClass.DataSource = dt;
                ddlBussClass.DataBind();
                ddlBussClass.Items.Insert(0, new ListItem("Select"));
            }


        }

        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DropDownList txtAddresType = (DropDownList)e.Row.FindControl("txtAddresType");
                    db = new dal();
                    dt = new DataTable();
                    c = new client();
                    txtAddresType.DataValueField = "PAT_ADD_TYPE";
                    txtAddresType.DataTextField = "PAT_ADD_TYPE_DESC";
                    c.GetAddressType(dt);
                    txtAddresType.DataSource = dt;
                    txtAddresType.DataBind();
                    txtAddresType.Items.Insert(0, new ListItem("Select"));

                    DropDownList txtCountry = (DropDownList)e.Row.FindControl("txtCountry");
                    db = new dal();
                    dt = new DataTable();
                    c = new client();
                    txtCountry.DataValueField = "PCO_CTRY_CODE";
                    txtCountry.DataTextField = "PCO_DESC";
                    c.GetCountry(dt);
                    txtCountry.DataSource = dt;
                    txtCountry.DataBind();
                    txtCountry.SelectedValue = "001";
                    //txtCountry.Items.Insert(0, new ListItem("Select"));

                    DropDownList txtCity = (DropDownList)e.Row.FindControl("txtCity");
                    db = new dal();
                    dt = new DataTable();
                    c = new client();
                    txtCity.DataValueField = "PCT_CITYCODE";
                    txtCity.DataTextField = "PCT_CITYDESC";
                    c.GetCity(dt);
                    txtCity.DataSource = dt;
                    txtCity.DataBind();
                    txtCity.SelectedValue = "001";




                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }


    }
}