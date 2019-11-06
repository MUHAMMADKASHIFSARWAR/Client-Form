using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clientForm
{
    public partial class ClientForm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lblUserName.Text = Session["FullName"].ToString();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();

                }
            }
        }

    }
}