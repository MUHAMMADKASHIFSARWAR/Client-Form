using ClientForm;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clientForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private GetReport rept;
        private dal db;
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                showReport();
            }

        }
        public void showReport()
        {
            DataTable dt = GetData();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }
        private DataTable GetData()
        {
            db = new dal();
            dt = new DataTable();
            rept = new GetReport();
            rept.getReprt(dt);
            return dt;
        }

    }
}