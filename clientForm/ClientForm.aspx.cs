using ClientForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clientForm
{
    public partial class ClientForm : Page
    {
        private DataTable dt;
        private client c;
        private DataSet ds;
        private dal db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetInitialRow();
                SetInitialRow();
                setGV();
                fillRequestType();
                fillPrefix();
                fillBranch();
                setRating();
                getBankName();
                //gvCFDept.DataSource = "";
                //gvCFDept.DataBind();
                ddlCustType.Items.Insert(0, new ListItem("Select Customer Type.."));
                ddlCategory.Items.Insert(0, new ListItem("Select Client Type.."));
                ddlGroupName.Items.Insert(0, new ListItem("Select Group Name.."));

            }
        }

        public void setGV()
        {
            dt = new DataTable();
            dt.Columns.Add("Department");
            dt.Rows.Add("Fire");
            dt.Rows.Add("Marine");
            dt.Rows.Add("Motor");
            dt.Rows.Add("Health");
            dt.Rows.Add("Engineering");
            dt.Rows.Add("Miscellaneous");
            gvCFDept.DataSource = dt;
            gvCFDept.DataBind();

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
                ddlPrefix.Items.Insert(0, new ListItem("Select Prefix."));
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
                ddlRequestType.Items.Insert(0, new ListItem("Select Request Type."));
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

                //ddlReqBranch.DataValueField = "PLC_LOCACODE";
                //ddlReqBranch.DataTextField = "PLC_LOCADESC";
                //ddlReqBranch.DataSource = dt;
                //ddlReqBranch.DataBind();
                //ddlReqBranch.Items.Insert(0, new ListItem("Select Requested Branch."));
                ddlBranch.Items.Insert(0, new ListItem("Select Branch."));
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
                    DropDownList ddlBussClass = (DropDownList)e.Row.FindControl("ddlBusClass");
                    db = new dal();
                    c = new client();
                    c.Department = e.Row.Cells[1].Text;
                    dt = new DataTable();
                    c.getBussClass(dt);
                    ddlBussClass.DataTextField = "PBC_DESC";
                    ddlBussClass.DataValueField = "PDP_DEPT_CODE";
                    ddlBussClass.DataSource = dt;
                    ddlBussClass.DataBind();
                    ddlBussClass.Items.Insert(0, new ListItem("Select"));

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            c = new client();
            db = new dal();
            ds = new DataSet();
            c.clientType = ddlCategory.SelectedItem.Text;
            c.GroupName = ddlGroupName.SelectedItem.Text;
            c.Prefix = ddlPrefix.SelectedValue;
            ////c.BankName = txtBank.Text;
            c.reference = txtReference.Text;
            c.ClientName = txtName.Text;
            //c.Address = txtAddress1.Text;
            //c.Address2 = txtAddress2.Text;
            c.CNIC = txtNic.Text;
            c.CNICExpiry = txtCIExpiry.Text;
            c.NTN = txtNTN.Text;
            c.GST = txtGST.Text;
            c.ContactPerson = txtContactPerson.Text;
            //c.ContactNum = txtPhone.Text;
            //c.ContactPersonNum = txtMobile.Text;
            c.Fax = txtFax.Text;
            c.ContactPersonCnic = txtContactCnic.Text;
            //c.ContactPersonCnicExpiry = txtCnicExpiry.Text;
            if (chkFiler.Checked)
            {
                c.Filer = "Yes";
            }
            else
            {
                c.Filer = "No";

            }
            c.RequestType = ddlRequestType.SelectedValue;
            c.Branch = ddlBranch.SelectedValue;
            c.RequestUser = txtReqUSer.Text;
            c.exposure = txtExposure.Text;
            c.PREMIUM = txtPotential.Text;
            c.CustomerType = ddlCustType.SelectedItem.Text;

            foreach (ListItem item in chkResNoRes.Items)
            {
                if (item.Selected)
                {
                    string resident = item.Value;
                    c.resident = resident;
                }
            }
            c.ProducerName = txtProducer.Text;
            c.Agent = txtAgent.Text;
            c.AgentRate = txtAggentRate.Text;





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
            ddlBank.Items.Insert(0, new ListItem("Select Bank Name.."));

        }


        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for DropDownList selected item   
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            //After binding the gridview, we can then extract and fill the DropDownList with Data   
            DropDownList ddl1 = (DropDownList)Gridview1.Rows[0].Cells[3].FindControl("DropDownList1");
            DropDownList ddl2 = (DropDownList)Gridview1.Rows[0].Cells[4].FindControl("DropDownList2");
           
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

                        TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox2");

                        dtCurrentTable.Rows[i]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column2"] = box2.Text;

                        //extract the DropDownList Selected Items   

                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[3].FindControl("DropDownList1");
                        DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[4].FindControl("DropDownList2");

                        // Update the DataRow with the DDL Selected Items   

                        dtCurrentTable.Rows[i]["Column3"] = ddl1.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column4"] = ddl2.SelectedItem.Text;

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

                        TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox2");

                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                        DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("DropDownList2");

                        //Fill the DropDownList with Data   
                     

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Column1"].ToString();
                            box2.Text = dt.Rows[i]["Column2"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks   
                            ddl1.ClearSelection();
                            ddl1.Items.FindByText(dt.Rows[i]["Column3"].ToString()).Selected = true;

                            ddl2.ClearSelection();
                            ddl2.Items.FindByText(dt.Rows[i]["Column4"].ToString()).Selected = true;

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
    

    }

}