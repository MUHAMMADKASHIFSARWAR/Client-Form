using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.ManagedDataAccess.Client;
namespace clientForm
{
    public partial class BWReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report2.rdlc");
                DataSetNew dsCustomers = GetData("select branch,PG_PREMIUM,AG_PREMIUM,PROJECTION_PRICE,ACTUAL_PRICE,JAN_JUNE2017,JUNE2017 from BWPrem");
                ReportDataSource datasource = new ReportDataSource("BWPremium", dsCustomers.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
        }
        private DataSetNew GetData(string query)
        {
            string conString = "DATA SOURCE=192.168.20.23:1521/ORCL;USER ID=HIL;Password=HIL";
            OracleCommand cmd = new OracleCommand(query);
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleDataAdapter sda = new OracleDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataSetNew dsCustomers = new DataSetNew())
                    {
                        sda.Fill(dsCustomers, "Premium");
                        return dsCustomers;
                    }
                }
            }
        }
    }
}