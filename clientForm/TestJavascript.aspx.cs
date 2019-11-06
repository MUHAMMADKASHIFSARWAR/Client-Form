using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.Data.OracleClient;
using ClientForm;
using Oracle.ManagedDataAccess.Client;

namespace clientForm
{
    public partial class TestJavascript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool InsertPersonRecord(string Name, string LName)
        {
            bool InsertData;
            dal db = new dal();
            DataSet ds = new DataSet();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_PRO_CFInsertComments";
            cmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = Name;
            cmd.Parameters.Add("datime", OracleDbType.NVarchar2).Value = LName;
            //cmd.Parameters.Add("comt", OracleDbType.NVarchar2).Value = emp.comment;
            //cmd.Parameters.Add("userid", OracleDbType.NVarchar2).Value = emp.userid;
            db.getDataProcedure(cmd, ds);
            int Result = 0;
            if (Result > 0)
            {
                InsertData = true;
            }
            else
            {
                InsertData = false;
            }
            return InsertData;
        }

    }

}