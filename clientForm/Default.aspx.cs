using System;
using ClientForm;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using clientForm;

namespace ClientForm
{
    public partial class _Default : Page
    {
        private dal db;
        private client c;
        private System.Data.DataSet ds;
        private System.Data.DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var login_name = login_username.Text;
                var login_pass = login_password.Text;
                db = new dal();
                c = new client();
                dt = new DataTable();
                c.username = login_name;
                c.password = login_pass;
                c.Login(dt);
                if (dt.Rows.Count > 0)
                {

                    string clientcode = dt.Rows[0]["CLIENTCODE"].ToString();
                    string UserName = dt.Rows[0]["USERID"].ToString();
                    string fullname = dt.Rows[0]["NAMEDESCRIPTION"].ToString();
                    string statusidx = dt.Rows[0]["STATUSIDX"].ToString();
                    string clientbranch = dt.Rows[0]["LOC_CODE"].ToString();
                    string branch = dt.Rows[0]["LOC_DESC"].ToString();
                    string NEXTAPPROVAL = dt.Rows[0]["NEXT_APPROVAL"].ToString();
                    string Role = dt.Rows[0]["ROLE"].ToString();
                    Session["clientbranch"] = clientbranch;
                    Session["Role"] = Role;
                    Session["Branch"] = branch;
                    Session["USERID"] = UserName;
                    Session["statusidx"] = statusidx;
                    Session["NEXTAPPROVAL"] = NEXTAPPROVAL;
                    
                    Session["FullName"] = fullname;
                    Session["ClientCode"] = clientcode;
                    Response.Redirect("ClientDetails.aspx", false);
                }
                else
                {
                    lblInavlid.Text = "Invalid Username or password";
                    //string message = "alert('Invalid User Name & Password!')";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    login_username.Text = login_password.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }



        //LoggedUser objUser = objdal.isValidLogin(login_name, login_pass);
        //if (objUser == null)
        //{
        //    this.lblInavlid.Visible = true;

        //}
        //else
        //{
        //    FormsAuthentication.RedirectFromLoginPage(login_name, true);
        //    UserInfo.InstanceSave(objUser);
        //}


    }


}
