using ClientForm;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace clientForm
{
    public class ClientFormController : ApiController
    {
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataAdapter adp;
        private dal db;


        private DataSet ds;
        private DataTable dt;
        private client c;

        public System.Web.Http.Results.JsonResult<string> GetInsertClientDetail(string CFID, string Branch, string clientType, string Prefix, string ClientName,
            string CNIC, string issueDate, string CNICExpiry, string NTN, string GST, string filer)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                if (HttpContext.Current.Session["statusidx"] != null)
                {
                    string statusidx = HttpContext.Current.Session["statusidx"].ToString();
                    db = new dal();
                    DataTable dt = new DataTable();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = objConn;
                    cmd.CommandText = "HICL_PRO_InsertClientForm";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClientFormId", CFID);
                    cmd.Parameters.Add("@branch", Branch);
                    cmd.Parameters.Add("@clienttype", clientType);
                    cmd.Parameters.Add("@prfix", Prefix);
                    cmd.Parameters.Add("@clientName", ClientName);
                    cmd.Parameters.Add("@cnic", CNIC);
                    cmd.Parameters.Add("@issdate", issueDate);
                    cmd.Parameters.Add("@cnicExp", CNICExpiry);
                    cmd.Parameters.Add("@ntn", NTN);
                    cmd.Parameters.Add("@gst", GST);
                    cmd.Parameters.Add("@filer", filer);
                    cmd.Parameters.Add("@reqdate", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));
                    cmd.Parameters.Add("@clientstatus", statusidx);
                    cmd.Parameters.Add("@reqUSer", HttpContext.Current.Session["USERID"].ToString());
                    cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    try
                    {

                        db.getDataProcedure(cmd, dt);
                        string ccf_id = "CF-" + dt.Rows[0]["CFID"].ToString();
                        HttpContext.Current.Session["CFidx"] = ccf_id.ToString();
                        //objConn.Open();

                        //cmd.ExecuteNonQuery();
                        //OracleDataAdapter da = new OracleDataAdapter(cmd);
                        //da.Fill(dataset);
                        //string ccf_id = "CF-" + dataset.Tables[0].Rows[0]["CF_ID"].ToString();
                        //HttpContext.Current.Session["CFidx"] = ccf_id.ToString();

                    }

                    catch (Exception ex)

                    {

                        System.Console.WriteLine("Exception: {0}", ex.ToString());

                    }

                    objConn.Close();

                }

                return Json<string>("Insert Client Form");
            }
        }




        public System.Web.Http.Results.JsonResult<string> GetInsertClientForm(string CFID, string Branch, string Prefix, string ClientName, string
            CNIC, string issueDate, string CNICExpiry, string NTN, string GST, string clientType, string EmployeName, string SourceOfIncome,
            string ContactPerson, string ContactPerDes, string ContactPersonCnic, string ContactPerNo, string ContactPerEmail, string reference,
            string GroupName, string companyInd, string ProducerName, string AgentRate, string Agent, string filer,
            string CRating, string TRating, string GRating, string resident, string pep)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_PRO_InsertClientForm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientFormId", CFID);
                cmd.Parameters.Add("@branch", Branch);
                cmd.Parameters.Add("@prfix", Prefix);
                cmd.Parameters.Add("@clientName", ClientName);
                cmd.Parameters.Add("@cnic", CNIC);
                cmd.Parameters.Add("@issdate", issueDate);
                cmd.Parameters.Add("@cnicExp", CNICExpiry);
                cmd.Parameters.Add("@ntn", NTN);
                cmd.Parameters.Add("@gst", GST);
                cmd.Parameters.Add("@clienttype", clientType);
                cmd.Parameters.Add("@filer", filer);
                cmd.Parameters.Add("@EmployeName", EmployeName);
                cmd.Parameters.Add("@SourceOfIncome", SourceOfIncome);
                cmd.Parameters.Add("@contactPerson", ContactPerson);
                cmd.Parameters.Add("@ContactPerDes", ContactPerDes);
                cmd.Parameters.Add("@ContPersonCnic", ContactPersonCnic);
                cmd.Parameters.Add("@ContactPerNo", ContactPerNo);
                cmd.Parameters.Add("@ContactPerEmail", ContactPerEmail);
                cmd.Parameters.Add("@refer", reference);
                cmd.Parameters.Add("@GroupName", GroupName);
                cmd.Parameters.Add("@compIndus", companyInd);
                cmd.Parameters.Add("@producer", ProducerName);
                cmd.Parameters.Add("@rates", AgentRate);
                cmd.Parameters.Add("@Agent", Agent);
                cmd.Parameters.Add("@ReqUser", HttpContext.Current.Session["USERID"].ToString());
                cmd.Parameters.Add("@creatDate", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));
                cmd.Parameters.Add("@status", HttpContext.Current.Session["statusidx"].ToString());
                cmd.Parameters.Add("@assigto", HttpContext.Current.Session["USERID"].ToString());
                //cmd.Parameters.Add("@assigto", HttpContext.Current.Session["NEXTAPPROVAL"].ToString());
                cmd.Parameters.Add("@asgnUser", HttpContext.Current.Session["USERID"].ToString());
                cmd.Parameters.Add("@resident", resident);
                cmd.Parameters.Add("@CRating", CRating);
                cmd.Parameters.Add("@TRating", TRating);
                cmd.Parameters.Add("@GRating", GRating);
                cmd.Parameters.Add("@pepDet", pep);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {

                    //string ccf_id = "CF-" + db.getDataProcedure(cmd, dt);
                    //HttpContext.Current.Session["CFidx"] = ccf_id.ToString();
                    //objConn.Open();

                    //cmd.ExecuteNonQuery();
                    //OracleDataAdapter da = new OracleDataAdapter(cmd);
                    //da.Fill(dataset);
                    //string ccf_id = "CF-" + dataset.Tables[0].Rows[0]["CF_ID"].ToString();
                    //HttpContext.Current.Session["CFidx"] = ccf_id.ToString();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetInsertAddress(string addType, string address, string country, string city, string
           email, string ptcl, string mobile)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_PRO_CFInsertAddress";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@addres", address);
                cmd.Parameters.Add("@addresType", addType);
                cmd.Parameters.Add("@countryCode", country);
                cmd.Parameters.Add("@cityCode", city);
                cmd.Parameters.Add("@ptcl", ptcl);
                cmd.Parameters.Add("@mobile", mobile);
                cmd.Parameters.Add("@email", email);

                try
                {
                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetInsertBusClass(string dept, string Category, string busClass, string InsuranceType, string
                      exposure, string Rate)


        {


            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HIL.HICL_PRO_CFInsertDeptAndComm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@buss", busClass);
                cmd.Parameters.Add("@insType", InsuranceType);
                cmd.Parameters.Add("@rate", Rate);
                cmd.Parameters.Add("@comm", "");
                cmd.Parameters.Add("@expos", exposure);
                cmd.Parameters.Add("@BusClassCat", Category);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetInsertInstallment(string dept, string InstallMode)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertInstallmentMode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@buss", InstallMode);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateInstallment(string dept, string InstallMode, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateInstallment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@instal", InstallMode);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetInsertUpdateInstallment(string dept, string InstallMode)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateInstallment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@instal", InstallMode);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }
        //public System.Web.Http.Results.JsonResult<string> GetFileAttachment()
        //{

        //    var httpContext = HttpContext.Current;
        //    if (httpContext.Request.Files.Count > 0)
        //    {
        //        for (int i = 0; i < httpContext.Request.Files.Count; i++)
        //        {
        //            HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
        //            if (httpPostedFile != null)
        //            {

        //                var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/documents"), httpPostedFile.FileName);
        //                dal objdal = new dal();
        //                string crid = HttpContext.Current.Session["cr_id"].ToString();
        //                string filename = httpPostedFile.FileName;
        //                string busclass = null;
        //                if (HttpContext.Current.Session["GenericBusClass"] != null)
        //                {
        //                    busclass = HttpContext.Current.Session["GenericBusClass"].ToString();
        //                }


        //                //objdal.Insertdocument(crid, filename, busclass);
        //                httpPostedFile.SaveAs(fileSavePath);

        //            }
        //        }
        //    }


        //    return Json<string>("data saved");
        //}

        public System.Web.Http.Results.JsonResult<DataTable> GetMyTask()
        {
            DataTable dt = new DataTable();
            string statusStart = "0";
            string statusend = "0";
            string role = HttpContext.Current.Session["Role"].ToString();
            string Branch = HttpContext.Current.Session["clientbranch"].ToString();
            string statusidx = HttpContext.Current.Session["statusidx"].ToString();

            if (statusidx == "10")
            {
                statusStart = "1";
                statusend = "10";
            }

            if (statusidx == "30")
            {
                statusStart = "30";
                statusend = "30";
            }
            if (statusidx == "40")
            {
                statusStart = "40";
                statusend = "40";
            }
            if (statusidx == "50")
            {
                statusStart = "50";
                statusend = "50";
            }
            if (statusidx == "70")
            {
                statusStart = "69";
                statusend = "71";
            }

            if (statusidx == "80")
            {
                statusStart = "80";
                statusend = "80";
            }
            if (statusidx == "90" ||statusidx=="91")
            {
                statusStart = "89";
                statusend = "92";
            }
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientForm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@status_Start", statusStart);
                cmd.Parameters.Add("@status_end", statusend);
                cmd.Parameters.Add("@branch", Branch);
                cmd.Parameters.Add("usertype", role);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<DataTable> GetMyTaskSearch(string todate, string toform)
        {
            DataTable dt = new DataTable();
            string statusStart = "0";
            string statusend = "0";
            string role = HttpContext.Current.Session["Role"].ToString();
            string Branch = HttpContext.Current.Session["clientbranch"].ToString();
            string statusidx = HttpContext.Current.Session["statusidx"].ToString();

            if (statusidx == "10")
            {
                statusStart = "1";
                statusend = "10";
            }

            if (statusidx == "20")
            {
                statusStart = "30";
                statusend = "30";
            }
            if (statusidx == "40")
            {
                statusStart = "40";
                statusend = "40";
            }
            if (statusidx == "50")
            {
                statusStart = "50";
                statusend = "50";
            }
            if (statusidx == "70")
            {
                statusStart = "69";
                statusend = "71";
            }

            if (statusidx == "80")
            {
                statusStart = "80";
                statusend = "80";
            }
            if (statusidx == "90" || statusidx == "91")
            {
                statusStart = "89";
                statusend = "92";
            }
            //if (HttpContext.Current.Session["Role"].ToString() == "BranchManager")
            //{
            //    statusStart = "1";
            //    statusend = "10";
            //}
            //else if (HttpContext.Current.Session["USERID"].ToString() == "FAWWADD")
            //{
            //    statusStart = "30";
            //    statusend = "30";
            //}
            //else if (HttpContext.Current.Session["USERID"].ToString() == "Tariq")
            //{
            //    statusStart = "40";
            //    statusend = "40";
            //}
            //else if (HttpContext.Current.Session["USERID"].ToString() == "OMARZUBAIR")
            //{
            //    statusStart = "50";
            //    statusend = "50";
            //}
            //else if (HttpContext.Current.Session["USERID"].ToString() == "MURTAZA.H")
            //{
            //    statusStart = "70";
            //    statusend = "70";
            //}

            //else if (HttpContext.Current.Session["USERID"].ToString() == "ReInsurance")
            //{
            //    statusStart = "80";
            //    statusend = "80";
            //}

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientFormSearch";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@status_Start", statusStart);
                cmd.Parameters.Add("@status_end", statusend);
                cmd.Parameters.Add("@branch", Branch);
                cmd.Parameters.Add("usertype", role);
                cmd.Parameters.Add("todate", todate);
                cmd.Parameters.Add("fromdate", toform);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetCFDetail(string CF_ID, string LOC_CODE)
        {
           
            HttpContext.Current.Session["CFidx"] = CF_ID;
            HttpContext.Current.Session["LocCodeDetail"] = LOC_CODE;

            DataTable dt = new DataTable();
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientFormDetail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", CF_ID);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }



        public System.Web.Http.Results.JsonResult<DataTable> GetCFDocuments(string CF_ID, string attachType)
        {
            DataTable dt = new DataTable();
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_Get_PRO_CF_Attach";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", CF_ID);
                cmd.Parameters.Add("@attachType", attachType);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetApproveName()
        {
            DataTable dt = new DataTable();
            string statusStart = "0";
            string statusend = "0";
            string statusidx = HttpContext.Current.Session["statusidx"].ToString();
            if (statusidx == "0")
            {
                statusStart = "1";
                statusend = "11";
            }
            else if (statusidx == "10")
            {
                statusStart = "29";
                statusend = "31";
            }
            else if (statusidx == "30")
            {
                statusStart = "39";
                statusend = "51";
            }
          

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
                con = new OracleConnection(constr);
                DataSet dataset = new DataSet();
                using (OracleConnection objConn = new OracleConnection(constr))
                {
                    db = new dal();


                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = objConn;
                    cmd.CommandText = "HIL.GetForwardUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("status_Start", statusStart);
                    cmd.Parameters.Add("status_end", statusend);
                    cmd.Parameters.Add("usertype", HttpContext.Current.Session["Role"].ToString());
                    cmd.Parameters.Add("locCode", HttpContext.Current.Session["clientbranch"].ToString());
                    cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    try
                    {


                        objConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);


                    }

                    catch (Exception ex)

                    {

                        System.Console.WriteLine("Exception: {0}", ex.ToString());

                    }

                    objConn.Close();

                }


            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetRevertName(string LOC_CODE)
        {
            DataTable dt = new DataTable();
            string statusStartRev = "0";
            string statusendRev = "0";
            string LocCode = "0";

            if (HttpContext.Current.Session["Role"] != null)
            {
                if (HttpContext.Current.Session["Role"].ToString() == "BranchManager")
                {
                    LocCode = HttpContext.Current.Session["clientbranch"].ToString();
                    statusStartRev = "0";
                    statusendRev = "10";
                }


                else if (HttpContext.Current.Session["Role"].ToString() == "OperationHead")
                {
                    if (HttpContext.Current.Session["USERID"].ToString() == "FAWWADD")
                    {
                        LocCode = HttpContext.Current.Session["LocCodeDetail"].ToString();
                        statusStartRev = "9";
                        statusendRev = "11";

                    }
                    else if (HttpContext.Current.Session["USERID"].ToString() == "Tariq")
                    {
                        LocCode = "0";
                        statusStartRev = "30";
                        statusendRev = "31";
                    }
                    else if (HttpContext.Current.Session["USERID"].ToString() == "OMARZUBAIR")
                    {
                        LocCode = "0";
                        statusStartRev = "29";
                        statusendRev = "41";
                    }

                }
                else if (HttpContext.Current.Session["USERID"].ToString() == "MURTAZA.H")
                {
                    LocCode = LOC_CODE;
                    statusStartRev = "0";
                    statusendRev = "10";
                }

                string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
                con = new OracleConnection(constr);
                DataSet dataset = new DataSet();
                using (OracleConnection objConn = new OracleConnection(constr))
                {
                    db = new dal();


                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = objConn;
                    cmd.CommandText = "GetRevertUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("statusStartRev", statusStartRev);
                    cmd.Parameters.Add("statusendRev", statusendRev);
                    cmd.Parameters.Add("LocCode", LocCode);
                    cmd.Parameters.Add("usertype", HttpContext.Current.Session["Role"].ToString());
                    cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    try
                    {


                        objConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);


                    }

                    catch (Exception ex)

                    {

                        System.Console.WriteLine("Exception: {0}", ex.ToString());

                    }

                    objConn.Close();

                }

            }
            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<string> GetForwardStatus(string statusid, string AssignTouser,string cfEdit)
        {

            dal objdal = new dal();
            if (cfEdit != null)
            {
                //string cfid = HttpContext.Current.Session["CFDetailid"].ToString();
                string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
                objdal.UpdateRevert(cfEdit, statusid, AssignTouser, AssignUSer);
                objdal.InsertRevert(cfEdit, statusid, AssignTouser, AssignUSer);
            }
            else
            {
                string cfid = HttpContext.Current.Session["CFidx"].ToString();
                string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
                objdal.UpdateRevert(cfid, statusid, AssignTouser, AssignUSer);
                objdal.InsertRevert(cfid, statusid, AssignTouser, AssignUSer);
            }



            ds = new DataSet();
            c = new client();
            c.username = HttpContext.Current.Session["USERID"].ToString();
            c.GetClientCode(ds);
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    if (ds.Tables[1].Rows[0]["EMAIL"].ToString() != "")
            //    {
            //        MailMessageModel mailmsgmdl = new MailMessageModel();
            //        mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //        mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();

            //        Email e = new Email();
            //        string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

            //        string message = "Client Rate Approval Request Against CF-No:" + " " +
            //            HttpContext.Current.Session["CFDetailid"].ToString() + " ," + " Client Name:" + " "
            //            + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
            //           + " " + " " + " " + signature;
            //        ;

            //        string Emailmessage = message;
            //        string subject = "New Client Form Request Forward from  " + "' " + AssignUSer;



            //        ds = new DataSet();
            //        c = new client();
            //        c.username = AssignTouser;
            //        c.GetClientCode(ds);
            //        if (ds.Tables[1].Rows.Count > 0)
            //        {
            //            string forwardEmailAddess = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //            e.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
            //        }
            //    }
            //}
            return Json<string>("data saved");


        }

        public System.Web.Http.Results.JsonResult<string> GetInsertForwardStatus(string statusid, string AssignTouser)
        {
            dal objdal = new dal();
            if (HttpContext.Current.Session["CFDetailid"] != null)
            {

                string cfid = HttpContext.Current.Session["CFDetailid"].ToString();
                string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
                objdal.UpdateRevert(cfid, statusid, AssignTouser, AssignUSer);
                objdal.InsertRevert(cfid, statusid, AssignTouser, AssignUSer);
            }
            else
            {
                string cfid = HttpContext.Current.Session["CFidx"].ToString();
                string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
                objdal.UpdateRevert(cfid, statusid, AssignTouser, AssignUSer);
                objdal.InsertRevert(cfid, statusid, AssignTouser, AssignUSer);
            }

            ds = new DataSet();
            c = new client();
            c.username = HttpContext.Current.Session["USERID"].ToString();
            c.GetClientCode(ds);
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    if (ds.Tables[1].Rows[0]["EMAIL"].ToString() != "")
            //    {
            //        MailMessageModel mailmsgmdl = new MailMessageModel();
            //        mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //        mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();

            //        Email e = new Email();
            //        string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

            //        string message = "Client Rate Approval Request Against CF-No:" + " " +
            //            HttpContext.Current.Session["CFDetailid"].ToString() + " ," + " Client Name:" + " "
            //            + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
            //           + " " + " " + " " + signature;
            //        ;

            //        string Emailmessage = message;
            //        string subject = "New Client Form Request Forward from  " + "' " + AssignUSer;



            //        ds = new DataSet();
            //        c = new client();
            //        c.username = AssignTouser;
            //        c.GetClientCode(ds);
            //        if (ds.Tables[1].Rows.Count > 0)
            //        {
            //            string forwardEmailAddess = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //            e.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
            //        }
            //    }
            //}
            return Json<string>("data saved");


        }

        public System.Web.Http.Results.JsonResult<string> GetCommisionForwardStatus(string statusid, string AssignTouser, string cfEdit)
        {

            dal objdal = new dal();

            string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
            objdal.UpdateRevert(cfEdit, statusid, AssignTouser, AssignUSer);
            objdal.InsertRevert(cfEdit, statusid, AssignTouser, AssignUSer);


            ds = new DataSet();
            c = new client();
            c.username = HttpContext.Current.Session["USERID"].ToString();
            c.GetClientCode(ds);
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    if (ds.Tables[1].Rows[0]["EMAIL"].ToString() != "")
            //    {
            //        MailMessageModel mailmsgmdl = new MailMessageModel();
            //        mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //        mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();

            //        Email e = new Email();
            //        string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

            //        string message = "Client Rate Approval Request Against CF-No:" + " " +
            //            HttpContext.Current.Session["CFDetailid"].ToString() + " ," + " Client Name:" + " "
            //            + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
            //           + " " + " " + " " + signature;
            //        ;

            //        string Emailmessage = message;
            //        string subject = "New Client Form Request Forward from  " + "' " + AssignUSer;



            //        ds = new DataSet();
            //        c = new client();
            //        c.username = AssignTouser;
            //        c.GetClientCode(ds);
            //        if (ds.Tables[1].Rows.Count > 0)
            //        {
            //            string forwardEmailAddess = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //            e.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
            //        }
            //    }
            //}
            return Json<string>("data saved");


        }

        public System.Web.Http.Results.JsonResult<string> GetRevertStatus(string statusid, string AssignTouser)
        {

            dal objdal = new dal();
            string cfid = HttpContext.Current.Session["CFDetailid"].ToString();
            string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
            objdal.UpdateRevert(cfid, statusid, AssignTouser, AssignUSer);
            objdal.InsertRevert(cfid, statusid, AssignTouser, AssignUSer);


            ds = new DataSet();
            c = new client();
            c.username = HttpContext.Current.Session["USERID"].ToString();
            c.GetClientCode(ds);
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    if (ds.Tables[1].Rows[0]["EMAIL"].ToString() != "")
            //    {
            //        MailMessageModel mailmsgmdl = new MailMessageModel();
            //        mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //        mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();

            //        Email e = new Email();
            //        string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

            //        string message = "Client Rate Approval Request Against CF-No:" + " " +
            //            HttpContext.Current.Session["CFDetailid"].ToString() + " ," + " Client Name:" + " "
            //            + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
            //           + " " + " " + " " + signature;
            //        ;

            //        string Emailmessage = message;
            //        string subject = "New Client Form Request Forward from  " + "' " + AssignUSer;



            //        ds = new DataSet();
            //        c = new client();
            //        c.username = AssignTouser;
            //        c.GetClientCode(ds);
            //        if (ds.Tables[1].Rows.Count > 0)
            //        {
            //            string forwardEmailAddess = ds.Tables[1].Rows[0]["EMAIL"].ToString();
            //            e.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
            //        }
            //    }
            //}
            return Json<string>("data saved");


        }

        public System.Web.Http.Results.JsonResult<DataTable> GetNextForwardUSer()
        {
            DataTable dt = new DataTable();
            string statusStartRev = "0";
            string statusendRev = "0";
            string LocCode = "0";

            if (HttpContext.Current.Session["Role"] != null)
            {
                if (HttpContext.Current.Session["Role"].ToString() == "BranchManager")
                {
                    LocCode = HttpContext.Current.Session["clientbranch"].ToString();
                    statusStartRev = "0";
                    statusendRev = "10";
                }
                if (HttpContext.Current.Session["Role"].ToString() == "Producer")
                {
                    LocCode = HttpContext.Current.Session["clientbranch"].ToString();
                    statusStartRev = "9";
                    statusendRev = "11";
                }

                else if (HttpContext.Current.Session["Role"].ToString() == "OperationHead")
                {
                    if (HttpContext.Current.Session["USERID"].ToString() == "FAWWADD")
                    {
                        LocCode = HttpContext.Current.Session["LocCodeDetail"].ToString();
                        statusStartRev = "9";
                        statusendRev = "11";

                    }
                    else if (HttpContext.Current.Session["USERID"].ToString() == "Tariq")
                    {
                        LocCode = "0";
                        statusStartRev = "30";
                        statusendRev = "31";
                    }
                    else if (HttpContext.Current.Session["USERID"].ToString() == "OMARZUBAIR")
                    {
                        LocCode = "0";
                        statusStartRev = "29";
                        statusendRev = "41";
                    }

                }
                else if (HttpContext.Current.Session["USERID"].ToString() == "MURTAZA.H")
                {
                    LocCode = "0";
                    statusStartRev = "0";
                    statusendRev = "10";
                }

                string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
                con = new OracleConnection(constr);
                DataSet dataset = new DataSet();
                using (OracleConnection objConn = new OracleConnection(constr))
                {
                    db = new dal();


                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = objConn;
                    cmd.CommandText = "GetRevertUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("statusStartRev", statusStartRev);
                    cmd.Parameters.Add("statusendRev", statusendRev);
                    cmd.Parameters.Add("LocCode", LocCode);
                    cmd.Parameters.Add("usertype", HttpContext.Current.Session["Role"].ToString());
                    cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    try
                    {


                        objConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);


                    }

                    catch (Exception ex)

                    {

                        System.Console.WriteLine("Exception: {0}", ex.ToString());

                    }

                    objConn.Close();

                }

            }
            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetAssignedTask()
        {
            DataTable dt = new DataTable();
            string LocCode = "0";
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
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "CF_GetAssigned";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("branch", LocCode);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetAssignedTaskSearch(string todate, string formdate)
        {
            DataTable dt = new DataTable();
            string LocCode = "0";
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
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "CF_GetAssignedSearch";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("branch", LocCode);
                cmd.Parameters.Add("todate", todate);
                cmd.Parameters.Add("formdate", formdate);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }



        public System.Web.Http.Results.JsonResult<DataTable> GetAddressDetail(string CF_ID)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientAddress";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", CF_ID);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetBisClassDetail(string CF_ID)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientBranchWiseRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfids", CF_ID);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetInstallmentDetail(string CF_ID)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetInstallment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfids", CF_ID);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<DataTable> GetInsertBank(string bankCode)
        {
            string cfid = HttpContext.Current.Session["CFidx"].ToString();
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HIL.HICL_PRO_CFInsertBank";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bank", bankCode);
                cmd.Parameters.Add("@cfid", cfid);
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<DataTable> GetOverCommmisionName()
        {
            DataTable dt = new DataTable();
            string statusStartRev = "69";
            string statusendRev = "71";
            string LocCode = "0";
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetRevertUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("statusStartRev", statusStartRev);
                cmd.Parameters.Add("statusendRev", statusendRev);
                cmd.Parameters.Add("LocCode", LocCode);
                cmd.Parameters.Add("usertype", HttpContext.Current.Session["Role"].ToString());
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }



        public System.Web.Http.Results.JsonResult<string> GetCommissionStatus(string statusid, string AssignTouser)
        {

            dal objdal = new dal();
            string cfid = HttpContext.Current.Session["CFDetailid"].ToString();
            string AssignUSer = HttpContext.Current.Session["USERID"].ToString();
            objdal.UpdateRevert(cfid, statusid, AssignTouser, AssignUSer);
            objdal.InsertRevert(cfid, statusid, AssignTouser, AssignUSer);


            ds = new DataSet();
            c = new client();
            c.username = HttpContext.Current.Session["USERID"].ToString();
            c.GetClientCode(ds);
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["EMAIL"].ToString() != "")
                {
                    MailMessageModel mailmsgmdl = new MailMessageModel();
                    mailmsgmdl.email = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                    mailmsgmdl.password = ds.Tables[1].Rows[0]["OUTLOOKPASSWORD"].ToString();

                    Email e = new Email();
                    string signature = string.Format("Click <a href='{0}'>here</a> to login", "http://192.168.20.40:8889/clientform");

                    string message = "Client Over Commission Rate Approval Request Against CF-No:" + " " +
                        HttpContext.Current.Session["CFDetailid"].ToString() + " ," + " Client Name:" + " "
                        + HttpContext.Current.Session["Clientname"] + " ," + "Cnic:" + " " + HttpContext.Current.Session["clientCnic"]
                       + " " + " " + " " + signature;
                    ;

                    string Emailmessage = message;
                    string subject = "New Client Form Request Forward from  " + "' " + AssignUSer;



                    ds = new DataSet();
                    c = new client();
                    c.username = AssignTouser;
                    c.GetClientCode(ds);
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        string forwardEmailAddess = ds.Tables[1].Rows[0]["EMAIL"].ToString();
                        e.SendEmailAsyncInfoEmail(mailmsgmdl, forwardEmailAddess, Emailmessage, subject);
                    }
                }
            }
            return Json<string>("data saved");


        }
        public System.Web.Http.Results.JsonResult<DataTable> GetFinalizeClient(string statusidx)
        {
            DataTable dt = new DataTable();
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetFinalClient";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@status", statusidx);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetFinalizeClientSearch(string todate, string toform)
        {
            DataTable dt = new DataTable();


            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetFinalClientSearch";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("status", "90");
                cmd.Parameters.Add("todate", todate);
                cmd.Parameters.Add("formdate", toform);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetPrefix(string category)
        {
            DataTable dt = new DataTable();


            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetPrefx";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cat", category);

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<string> GetInsertContactPErson(string contactPerson, string designation, string mobile, string email)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertContactPerson";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@contPerson", contactPerson);
                cmd.Parameters.Add("@desig", designation);
                cmd.Parameters.Add("@CPMobile", mobile);
                cmd.Parameters.Add("@CPEmail", email);
                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }



        public System.Web.Http.Results.JsonResult<DataTable> GetInsertClientAlready()
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {

                if (HttpContext.Current.Session["CFidx"] != null)
                {
                    db = new dal();


                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = objConn;
                    cmd.CommandText = "GetClientALready";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("cfid", HttpContext.Current.Session["CFidx"].ToString());

                    cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    try
                    {


                        objConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dt);


                    }


                    catch (Exception ex)

                    {

                        System.Console.WriteLine("Exception: {0}", ex.ToString());

                    }
                }
                else
                {

                }

                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetUpdateClientAlready(string cfEdit)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientALready";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfid", cfEdit);

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }


                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<string> GetInsertClientDetailUpdate(string Branch, string clientType, string Prefix, string ClientName,
           string CNIC, string issueDate, string CNICExpiry, string NTN, string GST, string filer, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateClient";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientFormId", cfEdit);
                cmd.Parameters.Add("@branch", Branch);
                cmd.Parameters.Add("@clienttype", clientType);
                cmd.Parameters.Add("@prfix", Prefix);
                cmd.Parameters.Add("@clientName", ClientName);
                cmd.Parameters.Add("@cnic", CNIC);
                cmd.Parameters.Add("@issdate", issueDate);
                cmd.Parameters.Add("@cnicExp", CNICExpiry);
                cmd.Parameters.Add("@ntn", NTN);
                cmd.Parameters.Add("@gst", GST);
                cmd.Parameters.Add("@filer", filer);
                cmd.Parameters.Add("@reqdate", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetInsertAlreadyClientDetailUpdate(string Branch, string clientType, string Prefix, string ClientName,
         string CNIC, string issueDate, string CNICExpiry, string NTN, string GST, string filer)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateClient";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientFormId", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@branch", Branch);
                cmd.Parameters.Add("@clienttype", clientType);
                cmd.Parameters.Add("@prfix", Prefix);
                cmd.Parameters.Add("@clientName", ClientName);
                cmd.Parameters.Add("@cnic", CNIC);
                cmd.Parameters.Add("@issdate", issueDate);
                cmd.Parameters.Add("@cnicExp", CNICExpiry);
                cmd.Parameters.Add("@ntn", NTN);
                cmd.Parameters.Add("@gst", GST);
                cmd.Parameters.Add("@filer", filer);
                cmd.Parameters.Add("@reqdate", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"));


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetClientAddressAlready(string cfEdit)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientAddressALready";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfid", cfEdit);

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetInsertClientAddressAlready()
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();


                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetClientAddressALready";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfid", HttpContext.Current.Session["CFidx"].ToString());

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<string> GetUpdAddress(string addType, string address, string country, string city, string
    email, string ptcl, string mobile, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateClientAddress";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@addres", address);
                cmd.Parameters.Add("@addresType", addType);
                cmd.Parameters.Add("@countryCode", country);
                cmd.Parameters.Add("@cityCode", city);
                cmd.Parameters.Add("@ptcl", ptcl);
                cmd.Parameters.Add("@mobile", mobile);
                cmd.Parameters.Add("@email", email);

                try
                {
                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetInsrtUpdAddress(string addType, string address, string country, string city, string
  email, string ptcl, string mobile)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateClientAddress";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@addres", address);
                cmd.Parameters.Add("@addresType", addType);
                cmd.Parameters.Add("@countryCode", country);
                cmd.Parameters.Add("@cityCode", city);
                cmd.Parameters.Add("@ptcl", ptcl);
                cmd.Parameters.Add("@mobile", mobile);
                cmd.Parameters.Add("@email", email);

                try
                {
                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }
        public System.Web.Http.Results.JsonResult<string> GetUpdateContactPErson(string contactPerson, string designation, string mobile, string email, string cfEdit)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateContactPerson";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@contPerson", contactPerson);
                cmd.Parameters.Add("@desig", designation);
                cmd.Parameters.Add("@CPMobile", mobile);
                cmd.Parameters.Add("@CPEmail", email);
                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }
        public System.Web.Http.Results.JsonResult<string> GetInsertUpdateContactPErson(string contactPerson, string designation, string mobile, string email)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateContactPerson";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@contPerson", contactPerson);
                cmd.Parameters.Add("@desig", designation);
                cmd.Parameters.Add("@CPMobile", mobile);
                cmd.Parameters.Add("@CPEmail", email);
                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetContactPerson(string CF_ID)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetContactPerson";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfid", CF_ID);

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<DataTable> GetInsertAlreadyContactPerson()
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetContactPerson";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfid", HttpContext.Current.Session["CFidx"].ToString());

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<string> GetInsertUpdateAddress(string addType, string address, string country, string city, string
         email, string ptcl, string mobile, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_PRO_CFInsertAddress";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@addres", address);
                cmd.Parameters.Add("@addresType", addType);
                cmd.Parameters.Add("@countryCode", country);
                cmd.Parameters.Add("@cityCode", city);
                cmd.Parameters.Add("@ptcl", ptcl);
                cmd.Parameters.Add("@mobile", mobile);
                cmd.Parameters.Add("@email", email);

                try
                {
                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetInsertUpdateContactPErson(string contactPerson, string designation, string mobile,
            string email, string cfEdit)
        {
            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertContactPerson";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@contPerson", contactPerson);
                cmd.Parameters.Add("@desig", designation);
                cmd.Parameters.Add("@CPMobile", mobile);
                cmd.Parameters.Add("@CPEmail", email);
                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }




        public System.Web.Http.Results.JsonResult<string> GetUpdateBusClass(string dept, string Category, string busClass, string InsuranceType, string
                      exposure, string Rate, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_PRO_CFUpdateDeptAndComm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@buss", busClass);
                cmd.Parameters.Add("@insType", InsuranceType);
                cmd.Parameters.Add("@rate", Rate);
                cmd.Parameters.Add("@comm", "");
                cmd.Parameters.Add("@expos", exposure);
                cmd.Parameters.Add("@BusClassCat", Category);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetBusClassAlready(string CF_ID, string dept)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetBussClassRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfid", CF_ID);
                cmd.Parameters.Add("dept", dept);

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<DataTable> GetBusClassAlreadyInsert(string dept)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetBussClassRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("dept", dept);

                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<string> GetInsertUpdateBusClass(string dept, string Category, string busClass, string InsuranceType, string
                     exposure, string Rate, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HIL.HICL_PRO_CFInsertDeptAndComm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@buss", busClass);
                cmd.Parameters.Add("@insType", InsuranceType);
                cmd.Parameters.Add("@rate", Rate);
                cmd.Parameters.Add("@comm", "");
                cmd.Parameters.Add("@expos", exposure);
                cmd.Parameters.Add("@BusClassCat", Category);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetAlreadyInsertUpdateBusClass(string dept, string Category, string busClass, string InsuranceType, string
             exposure, string Rate)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_PRO_CFUpdateDeptAndComm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@buss", busClass);
                cmd.Parameters.Add("@insType", InsuranceType);
                cmd.Parameters.Add("@rate", Rate);
                cmd.Parameters.Add("@comm", "");
                cmd.Parameters.Add("@expos", exposure);
                cmd.Parameters.Add("@BusClassCat", Category);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }
        public System.Web.Http.Results.JsonResult<string> GetUpdateOtherDetail(string reference, string GroupName, string bank,
            string CompIndust, string resident, string pep, string ownership, string SoI, string cfEdit)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateOtherDetal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@refby", reference);
                cmd.Parameters.Add("@GroupName", GroupName);
                cmd.Parameters.Add("@bank", bank);
                cmd.Parameters.Add("@CompIndust", CompIndust);
                cmd.Parameters.Add("@resident", resident);
                cmd.Parameters.Add("@peps", pep);
                cmd.Parameters.Add("@ownship", ownership);
                cmd.Parameters.Add("@SoI", SoI);
                cmd.Parameters.Add("@cfEdit", cfEdit);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetInsertUpdateOtherDetail(string reference, string GroupName, string bank,
           string CompIndust, string resident, string pep, string ownership, string SoI)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateOtherDetal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@refby", reference);
                cmd.Parameters.Add("@GroupName", GroupName);
                cmd.Parameters.Add("@bank", bank);
                cmd.Parameters.Add("@CompIndust", CompIndust);
                cmd.Parameters.Add("@resident", resident);
                cmd.Parameters.Add("@peps", pep);
                cmd.Parameters.Add("@ownship", ownership);
                cmd.Parameters.Add("@SoI", SoI);
                cmd.Parameters.Add("@cfEdit", HttpContext.Current.Session["CFidx"].ToString());

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }



        public System.Web.Http.Results.JsonResult<DataTable> GetProducer()
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "Getproducer";
                cmd.CommandType = CommandType.StoredProcedure;
                string Branchcode = HttpContext.Current.Session["clientbranch"].ToString();
                cmd.Parameters.Add("branch", Branchcode);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetBusClass(string dept, string busclas)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_Pro_GetBussniessClass";
                cmd.Parameters.Add("dept", dept);
                cmd.Parameters.Add("busClassCat", busclas);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }



        public System.Web.Http.Results.JsonResult<string> GetUpdateBusClassRate(string Producer, string Agent)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateBusClassAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@dept", dept);
                //cmd.Parameters.Add("@busclasCat", busclasCat);
                //cmd.Parameters.Add("@busclas", busclas);
                //cmd.Parameters.Add("@AgentRate", AgentRate);
                cmd.Parameters.Add("@ProdName", Producer);
                cmd.Parameters.Add("@Agents", Agent);
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }
        public System.Web.Http.Results.JsonResult<string> GetUpdateBusClassAgentRate(string Producer, string Agent, string cfEdit)

        {

             string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateBusClassAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@dept", dept);
                //cmd.Parameters.Add("@busclasCat", busclasCat);
                //cmd.Parameters.Add("@busclas", busclas);
                //cmd.Parameters.Add("@AgentRate", AgentRate);
                cmd.Parameters.Add("@ProdName", Producer);
                cmd.Parameters.Add("@Agents", Agent);
                cmd.Parameters.Add("@cfid", cfEdit);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetEditUpdateBusClassRate(string Producer, string Agent, string cfEdit)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateBusClassAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@dept", dept);
                //cmd.Parameters.Add("@busclasCat", busclasCat);
                //cmd.Parameters.Add("@busclas", busclas);
                //cmd.Parameters.Add("@AgentRate", AgentRate);
                cmd.Parameters.Add("@ProdName", Producer);
                cmd.Parameters.Add("@Agents", Agent);
                cmd.Parameters.Add("@cfid", cfEdit);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetEditUpdateComplience(string CRating, string TRating, string GRating,
     string cfEdit)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateComplience";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CRating", CRating);
                cmd.Parameters.Add("@TRating", TRating);
                cmd.Parameters.Add("@GRating", GRating);

                cmd.Parameters.Add("@cfid", cfEdit);

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetUpdateComplience(string CRating, string TRating, string GRating
 )

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateComplience";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CRating", CRating);
                cmd.Parameters.Add("@TRating", TRating);
                cmd.Parameters.Add("@GRating", GRating);

                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());

                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetInstallmentAlready(string cfEdit)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_GetInstallment";
                cmd.Parameters.Add("cfid", cfEdit);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<DataTable> GetInsertInstallmentAlready()
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_GetInstallment";
                cmd.Parameters.Add("cfid", HttpContext.Current.Session["CFidx"].ToString());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<string> GetEditInsertInstallment(string dept, string InstallMode, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertInstallmentMode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cfid", cfEdit);
                cmd.Parameters.Add("@dept", dept);
                cmd.Parameters.Add("@buss", InstallMode);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetLoadBusClass(string busclasCat, string Dept)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_Pro_GetBussniessClass";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("dept", Dept);
                cmd.Parameters.Add("busClassCat", busclasCat);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }



        public System.Web.Http.Results.JsonResult<string> fileAttachComplience()
        {

            var httpContextFilerReq = HttpContext.Current;
            if (HttpContext.Current.Session["CFidx"] != null)
            {
                if (httpContextFilerReq.Request.Files.Count > 0)
                {
                    for (int i = 0; i < httpContextFilerReq.Request.Files.Count; i++)
                    {
                        HttpPostedFile httpPostedFile = httpContextFilerReq.Request.Files[i];
                        if (httpPostedFile != null)
                        {

                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/documents"), httpPostedFile.FileName);
                            dal objdal = new dal();
                            client c = new client();
                            string filename = httpPostedFile.FileName;
                            c.attachment = filename;
                            c.CFID = HttpContext.Current.Session["CFidx"].ToString();
                            c.insertComplienceAttachment();
                            httpPostedFile.SaveAs(fileSavePath);

                        }
                    }
                }
            }

            return Json<string>("data saved");
        }


        public System.Web.Http.Results.JsonResult<string> fileUpdateAttachComplience()
        {

            var httpContextComplienceDocument = HttpContext.Current;
            var cfid = HttpContext.Current.Request.Params["cfid"];
            if (httpContextComplienceDocument.Request.Files.Count > 0)
            {
                for (int i = 0; i < httpContextComplienceDocument.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContextComplienceDocument.Request.Files[i];
                    if (httpPostedFile != null)
                    {

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/documents"), httpPostedFile.FileName);
                        dal objdal = new dal();
                        client c = new client();
                        string filename = httpPostedFile.FileName;
                        c.attachment = filename;
                        c.CFID = cfid;
                        c.insertComplienceAttachment();
                        httpPostedFile.SaveAs(fileSavePath);

                    }
                }
            }


            return Json<string>("data saved");
        }
        public System.Web.Http.Results.JsonResult<string> fileUpdateAttachFiler()
        {

            var httpContextComplienceDocument = HttpContext.Current;
            var cfid = HttpContext.Current.Session["CFidx"].ToString();
            if (httpContextComplienceDocument.Request.Files.Count > 0)
            {
                for (int i = 0; i < httpContextComplienceDocument.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContextComplienceDocument.Request.Files[i];
                    if (httpPostedFile != null)
                    {

                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/documents"), httpPostedFile.FileName);
                        dal objdal = new dal();
                        client c = new client();
                        string filename = httpPostedFile.FileName;
                        c.attachment = filename;
                        c.CFID = cfid;
                        c.insertFilerAttachment();
                        httpPostedFile.SaveAs(fileSavePath);

                    }
                }
            }


            return Json<string>("data saved");
        }
        public System.Web.Http.Results.JsonResult<string> GetDeleteContactPerson(string contactPErsonIdx)
        {



            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_DeleteContactPerson";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ContPersnId", contactPErsonIdx);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Delete Contact Person");
        }


        public System.Web.Http.Results.JsonResult<string> GetDeleteAddress(string AddressIdx)
        {



            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_DeleteAddress";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AddressIdx", AddressIdx);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Delete Contact Person");
        }
        public System.Web.Http.Results.JsonResult<string> GetDeleteBusClass(string BusniesClassIdx)
        {



            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_DeleteBusclass";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BusClassId", BusniesClassIdx);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Delete BucClass");
        }

        public System.Web.Http.Results.JsonResult<DataTable> GetBusClassStandardRate(string Dept, string busClass)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetAgentDeptBusWiseRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("dept", Dept);
                cmd.Parameters.Add("busClass", busClass);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }


        public System.Web.Http.Results.JsonResult<string> GetInsertBusClassRate(string Dept, string insuraceCat, string Busclass,
        string insuranceType, string exposure, string StandardRate, string StandardRateType, string StandardRateAgent, string agentRate,
        string agentRateType, string agentType, string instalmentMode)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertAgentWiseRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dept", Dept);
                cmd.Parameters.Add("@insuraceCat", insuraceCat);
                cmd.Parameters.Add("@busclas", Busclass);
                cmd.Parameters.Add("@insuranceType", insuranceType);
                cmd.Parameters.Add("@expo", exposure);
                cmd.Parameters.Add("@StandardRate", StandardRate);
                cmd.Parameters.Add("@StandardRateType", StandardRateType);
                cmd.Parameters.Add("@agentRate", agentRate);
                cmd.Parameters.Add("@agentRateType", agentRateType);
                cmd.Parameters.Add("@instalmentMode", instalmentMode);
                cmd.Parameters.Add("@StandardRateAgent", StandardRateAgent);
                cmd.Parameters.Add("@agentType", agentType);
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());




                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetUpdateBusClassAndAgentRate(string Dept, string insuraceCat, string Busclass,
        string insuranceType, string exposure, string StandardRate, string StandardRateType, string StandardRateAgent, string agentRate,
        string agentRateType, string agentType, string instalmentMode, string cfEdit)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertAgentWiseRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dept", Dept);
                cmd.Parameters.Add("@insuraceCat", insuraceCat);
                cmd.Parameters.Add("@busclas", Busclass);
                cmd.Parameters.Add("@insuranceType", insuranceType);
                cmd.Parameters.Add("@expo", exposure);
                cmd.Parameters.Add("@StandardRate", StandardRate);
                cmd.Parameters.Add("@StandardRateType", StandardRateType);
                cmd.Parameters.Add("@agentRate", agentRate);
                cmd.Parameters.Add("@agentRateType", agentRateType);
                cmd.Parameters.Add("@instalmentMode", instalmentMode);
                cmd.Parameters.Add("@StandardRateAgent", StandardRateAgent);
                cmd.Parameters.Add("@agentType", agentType);
                cmd.Parameters.Add("@cfid", cfEdit);




                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetInsertAlreadyBusClassRate(string Dept, string insuraceCat, string Busclass,
           string insuranceType, string ratePropose, string standardRate, string diff, string status)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertAgentWiseRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dept", Dept);
                cmd.Parameters.Add("@insuraceCat", insuraceCat);
                cmd.Parameters.Add("@busclas", Busclass);
                cmd.Parameters.Add("@insuranceType", insuranceType);
                cmd.Parameters.Add("@ratePropose", ratePropose);
                cmd.Parameters.Add("@standardRate", standardRate);
                cmd.Parameters.Add("@rateDiff", diff);
                cmd.Parameters.Add("@AprovalStatus", status);
                cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetInserUpdatetBusClassAgentRate(string Dept, string insuraceCat, string Busclass,
       string insuranceType, string ratePropose, string standardRate, string cfEdit, string diff, string status, string idx)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_UpdateAgentWiseRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dept", Dept);
                cmd.Parameters.Add("@insuraceCat", insuraceCat);
                cmd.Parameters.Add("@busclas", Busclass);
                cmd.Parameters.Add("@insuranceType", insuranceType);
                cmd.Parameters.Add("@ratePropose", ratePropose);
                cmd.Parameters.Add("@standardRate", standardRate);
                cmd.Parameters.Add("@rateDiff", diff);
                cmd.Parameters.Add("@AprovalStatus", status);
                cmd.Parameters.Add("@busClasRatIdx", idx);
                cmd.Parameters.Add("@cfid", cfEdit);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateBusClassAgentRate(string Dept, string insuraceCat, string Busclass,
           string insuranceType, string ratePropose, string standardRate, string diff, string status, string cfEdit)

        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_InsertAgentWiseRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dept", Dept);
                cmd.Parameters.Add("@insuraceCat", insuraceCat);
                cmd.Parameters.Add("@busclas", Busclass);
                cmd.Parameters.Add("@insuranceType", insuranceType);
                cmd.Parameters.Add("@ratePropose", ratePropose);
                cmd.Parameters.Add("@standardRate", standardRate);
                cmd.Parameters.Add("@rateDiff", diff);
                cmd.Parameters.Add("@AprovalStatus", status);
                cmd.Parameters.Add("@cfid", cfEdit);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<DataTable> GetLoadBusClassAgentRate(string cfEdit)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetBussClassWiseAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfidx", cfEdit);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }
        public System.Web.Http.Results.JsonResult<DataTable> GetLoadBusClassAgentRateAlreadyInsert()
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetBussClassWiseAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfidx", HttpContext.Current.Session["CFidx"].ToString());
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }

        public System.Web.Http.Results.JsonResult<string> GetDeleteBusClassAgentRate(string BusClassRateIdx)
        {



            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "HICL_DeleteBusClassAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BusClassRateIdx", BusClassRateIdx);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Delete Contact Person");
        }



        public System.Web.Http.Results.JsonResult<DataTable> GetLoadAprovalAgentRate(string cfEdit)
        {
            DataTable dt = new DataTable();

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {


                db = new dal();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "GetApprovalAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cfidx", cfEdit);
                cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                try
                {


                    objConn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dt);


                }


                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }



                objConn.Close();

            }
            return Json<DataTable>(dt);
        }



        public System.Web.Http.Results.JsonResult<string> GetUpdateAgentRate(string agentidx, string agentrateUpd)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateAgentRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@agentidx", agentidx);
                cmd.Parameters.Add("@agentrate", agentrateUpd);
            


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateAgentStatus(string AgentApproveId, string AgentRateStatus)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateAgentStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@agentidx", AgentApproveId);
                cmd.Parameters.Add("@AgentRateStatus", AgentRateStatus);



                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateAgentRejectStatus(string AgentRejectId, string AgentRateStatus,string standardAgentRateReject)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateAgentRejectStatusAndRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AgentRejectId", AgentRejectId);
                cmd.Parameters.Add("@AgentRateStatus", AgentRateStatus);
                cmd.Parameters.Add("@standardAgentRateReject", standardAgentRateReject);


                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


        public System.Web.Http.Results.JsonResult<string> GetUpdateInstallement(string Installidx, string InstalUpd)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateInstallment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Installidx", Installidx);
                cmd.Parameters.Add("@InstalUpd", InstalUpd);



                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateInstallementStatus(string InstalApproveId, string InstalStatus)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateInstallmentStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InstalApproveId ", InstalApproveId);
                cmd.Parameters.Add("@InstalStatus", InstalStatus);



                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }



        public System.Web.Http.Results.JsonResult<string> GetUpdateStandardRate(string StandardRateidx, string standardRate,string standardRateType)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateStandardRate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StandardRateidx", StandardRateidx);
                cmd.Parameters.Add("@standardRate", standardRate);
                cmd.Parameters.Add("@standardRateType", standardRateType);




                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateStandardRateStatus(string StandardApproveId, string StandardRateStatus)


        {

            string constr = System.Configuration.ConfigurationManager.AppSettings["DashBoard"];
            con = new OracleConnection(constr);
            DataSet dataset = new DataSet();
            using (OracleConnection objConn = new OracleConnection(constr))
            {
                db = new dal();
                DataTable dt = new DataTable();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = objConn;
                cmd.CommandText = "UpdateStandardRateStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StandardApproveId ", StandardApproveId);
                cmd.Parameters.Add("@StandardRateStatus", StandardRateStatus);



                try
                {


                    objConn.Open();
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)

                {

                    System.Console.WriteLine("Exception: {0}", ex.ToString());

                }

                objConn.Close();

            }

            return Json<string>("Insert Client Form");
        }


       
     
    }

}



