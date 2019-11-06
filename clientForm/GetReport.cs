using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using ClientForm;

namespace clientForm
{
    public class GetReport
    {
        private dal db;
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataAdapter adp;
        public void getReprt(DataTable dt)
        {
            db = new dal();
            string qry = @"select * from HICL_BW_PRE b
left outer join
(
select plc_loc_code, plc_Desc,case when plc_loc_code = '10103' then sum(cbd) else sum(alldept) end Prem from(

select a.plc_loc_code, lc.plc_desc,

case when a.client_code = '1300019811' then sum(coalesce(a.grossprem, 0)) + sum(coalesce(a.admin, 0)) else 0 end CBD,

case when a.client_code <> '1300019811' then sum(coalesce(a.grossprem, 0)) + sum(coalesce(a.admin, 0)) else 0 end ALLDept

from premium_view a

left outer join pr_gn_lc_location lc on(a.plc_loc_code = lc.plc_loc_code)

where issuedate between '01-june-2018' and '30-june-2018'

group by a.plc_loc_code, plc_desc, client_Code)

group by plc_loc_code, plc_Desc

order by plc_loc_code, plc_Desc


) curprem
on (curprem.plc_loc_code = b.plc_loc_code)";
            
            db.getData(qry, dt);
        }
    }
}