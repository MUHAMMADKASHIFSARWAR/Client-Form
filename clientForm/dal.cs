using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using System.Data;
using Oracle.ManagedDataAccess.Client;
//using System.Data.OracleClient;

namespace ClientForm
{
    public class dal
    {
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataAdapter adp;
        private clientForm.client c;
        private string _CFID;
        public string CFID { get { return _CFID; } set { _CFID = value; } }
        private string _commDate;
        public string commDate { get { return _commDate; } set { _commDate = value; } }

        private string _comment;
        public string comment { get { return _comment; } set { _comment = value; } }

        private string _userid;
        public string userid { get { return _userid; } set { _userid = value; } }

        private string _LocCode;
        public string LocCode { get { return _LocCode; } set { _LocCode = value; } }

        string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];

        public bool getData(string query, DataTable dt)
        {

            con = new OracleConnection(constr);
            cmd = new OracleCommand(query);
            cmd.Connection = con;
            adp = new OracleDataAdapter(cmd);
            con.Open();
            adp.Fill(dt);
            con.Close();
            return true;
        }
        public bool getDataProcedure(OracleCommand cmd, DataSet ds) //all data from a dataset
        {

            con = new OracleConnection(constr);
            cmd.Connection = con;
            adp = new OracleDataAdapter(cmd);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return true;
        }
        public bool getDataProcedureDatatable(OracleCommand cmd, DataTable dt) //all data from a dataset
        {

            con = new OracleConnection(constr);
            cmd.Connection = con;
            adp = new OracleDataAdapter(cmd);
            con.Open();
            adp.Fill(dt);
            con.Close();
            return true;
        }
        public bool runProc(OracleCommand cmd) //all data from a dataset
        {

            con = new OracleConnection(constr);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        public bool getDataProcedureDatatable(OracleCommand cmd, DataSet ds) //all data from a dataset
        {

            con = new OracleConnection(constr);
            cmd.Connection = con;
            adp = new OracleDataAdapter(cmd);
            con.Open();
            adp.Fill(ds);
            con.Close();
            return true;
        }


        public string getDataProcedure(OracleCommand cmd, DataTable dt) //all data from a dataset
        {
            try
            {

                con = new OracleConnection(constr);
                cmd.Connection = con;
                adp = new OracleDataAdapter(cmd);
                con.Open();
                adp.Fill(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return dt.ToString();
        }

        public string insertData(OracleCommand cmd, DataTable dt) //all data from a table
        {

            con = new OracleConnection(constr);
            cmd.Connection = con;
            adp = new OracleDataAdapter(cmd);
            con.Open();
            adp.Fill(dt);
            cmd.ExecuteNonQuery();
            con.Close();
            return dt.Rows[0][0].ToString();
        }

        public DataTable GetRemarksByRefNo(string ReferenceNo)
        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["constr"];



            con = new OracleConnection(constr);

            DataSet dataset = new DataSet();

            using (OracleConnection objConn = new OracleConnection(constr))

            {

                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = objConn;

                objCmd.CommandText = "HIL.HICL_Pro_GetRemarks";

                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("intimidation_no", OracleDbType.NVarchar2).Value = ReferenceNo;
                objCmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;


                try

                {

                    objConn.Open();

                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }



            return dataset.Tables[1];
        }


        public DataTable InsertRemarks()
        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["constr"];



            con = new OracleConnection(constr);

            DataSet dataset = new DataSet();

            using (OracleConnection objConn = new OracleConnection(constr))

            {

                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = objConn;

                objCmd.CommandText = "HICL_PRO_CFInsertComments";

                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = CFID;
                objCmd.Parameters.Add("datime", OracleDbType.NVarchar2).Value = commDate;
                objCmd.Parameters.Add("comt", OracleDbType.NVarchar2).Value = comment;
                objCmd.Parameters.Add("userid", OracleDbType.NVarchar2).Value = userid;


                try

                {

                    objConn.Open();


                    OracleDataAdapter da = new OracleDataAdapter(objCmd);




                    da.Fill(dataset);

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }



            return dataset.Tables[1];
        }


        public DataTable GetComments()
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "HICL_PRO_CFInsertComments";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = c.CFID;
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }


        public DataTable GetAssigned()
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                if (HttpContext.Current.Session["clientbranch"] != null)
                {
                    if (HttpContext.Current.Session["clientbranch"].ToString() == "")
                    {
                        LocCode = "0";

                    }
                    else
                    {
                        LocCode = HttpContext.Current.Session["clientbranch"].ToString();

                    }
                }
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "CF_GetAssigned";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("branch", LocCode);

                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }

        public DataTable GetApprove()
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "GetApprove";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }

        public DataTable ViewComment(string CF_ID)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "ViewComments";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("cfid", CF_ID);
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }


        public string UpdateRevert(string CF_ID, string status, string Assignto, string assignUSer)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "HICL_Upd_status";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("@cfid", CF_ID);
                objCmd.Parameters.Add("@status", status);
                objCmd.Parameters.Add("@assignto", Assignto);
                objCmd.Parameters.Add("@asgnUser", assignUSer);

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return "";
        }



        public string InsertRevert(string CF_ID, string status, string Assignto, string assignUSer)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "HICL_PRO_InsertApprovedUser";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("@cfid", CF_ID);
                objCmd.Parameters.Add("@username", assignUSer);
                objCmd.Parameters.Add("@datetime", DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss"));
                objCmd.Parameters.Add("@assignto", Assignto);

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return "";
        }
        public string UpdateVerifyClient(string CF_ID, string verifyFiler, string verifyVerisys, string VerifyUser)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "UpdateClientVerify";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("@cfid", CF_ID);
                objCmd.Parameters.Add("@verfFilerType", verifyFiler);
                objCmd.Parameters.Add("@vefVerisysType", verifyVerisys);
                objCmd.Parameters.Add("@verifUser", VerifyUser);
                objCmd.Parameters.Add("@verifDate", DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss"));
                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return "";
        }
        public string UpdateInsertAttachment(string CF_ID, string filePath)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "HICL_PRO_CFInsertAttachment";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("@cfid", CF_ID);
                objCmd.Parameters.Add("@attachPath", filePath);
                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return "";
        }



        public string InsertClient(string clientname, string ntn, string cnic, string address, string RefNo)
        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "HICL_InsertNactaClient";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("clinetname", OracleDbType.NVarchar2).Value = clientname;
                objCmd.Parameters.Add("ntn_numb", OracleDbType.NVarchar2).Value = ntn;
                objCmd.Parameters.Add("cnic_numb", OracleDbType.NVarchar2).Value = cnic;
                objCmd.Parameters.Add("address", OracleDbType.NVarchar2).Value = address;
                objCmd.Parameters.Add("Ref_numb", OracleDbType.NVarchar2).Value = RefNo;
                objCmd.Parameters.Add("indate", DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss"));

                try

                {
                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return "";
        }



        public DataTable ViewNactaClient()
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "GetNactaClient";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }

        public string UpdateClient(string outdate, string refno)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "HICL_UpdateNactaClient";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("@outdate", outdate);
                objCmd.Parameters.Add("@refno", refno);


                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return "Updated";
        }



        public DataTable ViewNactaClearClient()
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "GetNactaClearClient";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }
        public DataTable ViewNactaAlreadyClient(string cnic, string ntn, string Refno)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "GetNactaAlreadyClient";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("cnic_no", OracleDbType.NVarchar2).Value = cnic;
                objCmd.Parameters.Add("refno", OracleDbType.NVarchar2).Value = ntn;
                objCmd.Parameters.Add("ntn_no", OracleDbType.NVarchar2).Value = Refno;
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }

        public DataTable ViewGIAClient(string cnic, string ntn)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "GetGIAClient";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("cnic_no", OracleDbType.NVarchar2).Value = cnic;
                objCmd.Parameters.Add("ntn_no", OracleDbType.NVarchar2).Value = ntn;
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }
        public DataTable ViewDept()
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "HICL_PRO_GetDept";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("PRC", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    OracleDataAdapter da = new OracleDataAdapter(objCmd);
                    da.Fill(dataset);
                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return dataset.Tables[0];
        }

    }



}
