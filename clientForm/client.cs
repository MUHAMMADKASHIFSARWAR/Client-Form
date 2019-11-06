using ClientForm;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clientForm
{
    public class client
    {
        private dal db;
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataAdapter adp;

        private string _companyInd;
        public string companyInd { get { return _companyInd; } set { _companyInd = value; } }

        private string _role;
        public string role { get { return _role; } set { _role = value; } }


        private string _EmployeName;
        public string EmployeName { get { return _EmployeName; } set { _EmployeName = value; } }

        private string _Phone;
        public string Phone { get { return _Phone; } set { _Phone = value; } }

        private string _SourceOfIncome;
        public string SourceOfIncome { get { return _SourceOfIncome; } set { _SourceOfIncome = value; } }
        private string _ContactPerDes;
        public string ContactPerDes { get { return _ContactPerDes; } set { _ContactPerDes = value; } }
        private string _ContactPerNo;
        public string ContactPerNo { get { return _ContactPerNo; } set { _ContactPerNo = value; } }

        private string _ContactPerEmail;
        public string ContactPerEmail { get { return _ContactPerEmail; } set { _ContactPerEmail = value; } }

        private string _LocCode;
        public string LocCode { get { return _LocCode; } set { _LocCode = value; } }

        private string _statusStart;
        public string statusStart { get { return _statusStart; } set { _statusStart = value; } }

        private string _statusStartRev;
        public string statusStartRev { get { return _statusStartRev; } set { _statusStartRev = value; } }
        private string _statusend;
        public string statusend { get { return _statusend; } set { _statusend = value; } }

        private string _statusendRev;
        public string statusendRev { get { return _statusendRev; } set { _statusendRev = value; } }

        private string _assignUSer;
        public string assignUSer { get { return _assignUSer; } set { _assignUSer = value; } }

        private string _country;
        public string country { get { return _country; } set { _country = value; } }

        private string _city;
        public string city { get { return _city; } set { _city = value; } }
        private string _zipcode;
        public string zipcode { get { return _zipcode; } set { _zipcode = value; } }





        private string _clientType;
        public string clientType { get { return _clientType; } set { _clientType = value; } }
        private string _AddressTypee;
        public string AddressTypee { get { return _AddressTypee; } set { _AddressTypee = value; } }

        private string _BankName;
        public string BankName { get { return _BankName; } set { _BankName = value; } }

        private string _GroupName;
        public string GroupName { get { return _GroupName; } set { _GroupName = value; } }

        private string _reference;
        public string reference { get { return _reference; } set { _reference = value; } }
        private string _remarks;
        public string remarks { get { return _remarks; } set { _remarks = value; } }
        private string _creationDate;
        public string creationDate { get { return _creationDate; } set { _creationDate = value; } }
        private string _status;
        public string status { get { return _status; } set { _status = value; } }

        private string _CFID;
        public string CFID { get { return _CFID; } set { _CFID = value; } }

        private string _issueDate;
        public string issueDate { get { return _issueDate; } set { _issueDate = value; } }

        private string _RequestType;
        public string RequestType { get { return _RequestType; } set { _RequestType = value; } }

        private string _Branch;
        public string Branch { get { return _Branch; } set { _Branch = value; } }

        private string _BranchReq;
        public string BranchReq { get { return _BranchReq; } set { _BranchReq = value; } }

        private string _exposure;
        public string exposure { get { return _exposure; } set { _exposure = value; } }

        private string _PREMIUM;
        public string PREMIUM { get { return _PREMIUM; } set { _PREMIUM = value; } }
        private string _Category;
        public string Category { get { return _Category; } set { _Category = value; } }

        private string _Prefix;
        public string Prefix { get { return _Prefix; } set { _Prefix = value; } }

        private string _Filer;
        public string Filer { get { return _Filer; } set { _Filer = value; } }

        private string _ProducerName;
        public string ProducerName { get { return _ProducerName; } set { _ProducerName = value; } }

        private string _Agent;
        public string Agent { get { return _Agent; } set { _Agent = value; } }

        private string _AgentRate;
        public string AgentRate { get { return _AgentRate; } set { _AgentRate = value; } }

        private string _ClientName;
        public string ClientName { get { return _ClientName; } set { _ClientName = value; } }
        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; } }

        private string _Address2;
        public string Address2 { get { return _Address2; } set { _Address2 = value; } }

        private string _Address3;
        public string Address3 { get { return _Address3; } set { _Address3 = value; } }



        private string _CNIC;
        public string CNIC { get { return _CNIC; } set { _CNIC = value; } }
        private string _GST;
        public string GST { get { return _GST; } set { _GST = value; } }

        private string _NTN;
        public string NTN { get { return _NTN; } set { _NTN = value; } }



        private string _CNICExpiry;
        public string CNICExpiry { get { return _CNICExpiry; } set { _CNICExpiry = value; } }

        private string _ContactNum;
        public string ContactNum { get { return _ContactNum; } set { _ContactNum = value; } }

        private string _Fax;
        public string Fax { get { return _Fax; } set { _Fax = value; } }
        private string _ContactPerson;
        public string ContactPerson { get { return _ContactPerson; } set { _ContactPerson = value; } }

        private string _ContactPersonCNIC;
        public string ContactPersonCNIC { get { return _ContactPersonCNIC; } set { _ContactPersonCNIC = value; } }


        private string _ContactPersonNum;
        public string ContactPersonNum { get { return _ContactPersonNum; } set { _ContactPersonNum = value; } }
        private string _ContactPersonNtn;
        public string ContactPersonNtn { get { return _ContactPersonNtn; } set { _ContactPersonNtn = value; } }
        private string _ContactPersonGst;
        public string ContactPersonGst { get { return _ContactPersonGst; } set { _ContactPersonGst = value; } }
        private string _ContactPersonAddress;
        public string ContactPersonAddress { get { return _ContactPersonAddress; } set { _ContactPersonAddress = value; } }
        private string _RequestUser;
        public string RequestUser { get { return _RequestUser; } set { _RequestUser = value; } }

        private string _ContactPersonCnic;
        public string ContactPersonCnic { get { return _ContactPersonCnic; } set { _ContactPersonCnic = value; } }


        private string _ContactPersonCnicExpiry;
        public string ContactPersonCnicExpiry { get { return _ContactPersonCnicExpiry; } set { _ContactPersonCnicExpiry = value; } }



        private string _Department;
        public string Department { get { return _Department; } set { _Department = value; } }

        private string _Business;
        public string Business { get { return _Business; } set { _Business = value; } }


        private string _BusinessCat;
        public string BusinessCat { get { return _BusinessCat; } set { _BusinessCat = value; } }


        private string _AggentRate;
        public string AggentRate { get { return _AggentRate; } set { _AggentRate = value; } }


        private string _InsuranceType;
        public string InsuranceType { get { return _InsuranceType; } set { _InsuranceType = value; } }
        private string _CustomerType;
        public string CustomerType { get { return _CustomerType; } set { _CustomerType = value; } }

        private string _EffectiveDate;
        public string EffectiveDate { get { return _EffectiveDate; } set { _EffectiveDate = value; } }

        private string _Company;
        public string Company { get { return _Company; } set { _Company = value; } }

        private string _resident;
        public string resident { get { return _resident; } set { _resident = value; } }
        private string _customerRating;
        public string customerRating { get { return _customerRating; } set { _customerRating = value; } }

        private string _TRANSACTION_RATING;
        public string TRANSACTION_RATING { get { return _TRANSACTION_RATING; } set { _TRANSACTION_RATING = value; } }
        private string _GEOPRAPHICAL_RATING;
        public string GEOPRAPHICAL_RATING { get { return _GEOPRAPHICAL_RATING; } set { _GEOPRAPHICAL_RATING = value; } }
        private string _email;
        public string email { get { return _email; } set { _email = value; } }
        private string _InsureType;
        public string InsureType { get { return _InsureType; } set { _InsureType = value; } }
        private string _comission;
        public string comission { get { return _comission; } set { _comission = value; } }
        private string _attachment;
        public string attachment { get { return _attachment; } set { _attachment = value; } }


        private string _username;
        public string username { get { return _username; } set { _username = value; } }
        private string _password;
        public string password { get { return _password; } set { _password = value; } }


        private string _Assignto;
        public string Assignto { get { return _Assignto; } set { _Assignto = value; } }
        public void getPrefix(DataTable dt)
        {
            db = new dal();
            string qry = "select distinct PPX_DESC,PPX_CODE from PR_GN_PX_PREFIX where PPX_CODE in ('001','002','003','005')";
            db.getData(qry, dt);
        }
        public void getBranch(DataTable dt)
        {
            db = new dal();
            string qry = "select  * from PR_GN_LC_LOCATION where PLC_LOCATYPE='D'";
            db.getData(qry, dt);
        }

        public void getIndustry(DataTable dt)
        {
            db = new dal();
            string qry = "select distinct PCD_DESC ,PCD_CODE from PR_GN_CD_COMP_INDUSTRY order by PCD_DESC asc";
            db.getData(qry, dt);
        }
        public void getInsuranceType(DataTable dt)
        {
            db = new dal();
            string qry = "select distinct PIY_DESC ,PIY_INSUTYPE from PR_GG_IY_INSURANCETYPE where PIY_INSUTYPE in ('O','D','I','A')";
            db.getData(qry, dt);
        }
        public void getDepartment(DataTable dt)
        {
            db = new dal();
            string qry = "select  distinct PDP_DEPTDESC,PDP_DEPTCODE  from PR_GN_DP_DEPARTMENT ";
            db.getData(qry, dt);
        }
        public void getBussniess(DataTable dt, int PDP_DEPT_CODEValue)
        {
            db = new dal();
            string qry = "select  distinct PBC_DESC,PBC_BUSICLASS_CODE from PR_GG_BC_BUSINESS_CLASS where PDP_DEPT_CODE =" + PDP_DEPT_CODEValue;
            db.getData(qry, dt);
        }

        public void getInstallments(DataTable dt)
        {
            db = new dal();
            string qry = "select distinct *  from  PR_GN_IM_INSTALLEMENT_MODES";
            db.getData(qry, dt);
        }
        //public void getRequestType(DataTable dt)
        //{
        //    db = new dal();
        //    string qry = "select  distinct PDP_DEPTDESC  from PR_GN_DP_DEPARTMENT ";
        //    db.getData(qry, dt);
        //}

        public void getRequestType(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.Get_CF_RequestType";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, dt);

        }
        public void getProducer(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Getproducer";
            cmd.Parameters.Add("branchcode", Branch);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, dt);

        }
        public void getInstallment(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetInstallment";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, dt);

        }
        public void getBussClass(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_Pro_GetBussniessClass";
            cmd.Parameters.Add("dept", Department);
            cmd.Parameters.Add("busClassCat", BusinessCat);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void getBankList(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBankList";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, dt);

        }
        public void getAgent(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetAgent";
            cmd.Parameters.Add("@branchCode", Branch);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, dt);

        }

        public void insertClientData(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_PRO_InsertClientForm";
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
            cmd.Parameters.Add("@filer", Filer);
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
            cmd.Parameters.Add("@ReqUser", RequestUser);
            cmd.Parameters.Add("@creatDate", creationDate);
            cmd.Parameters.Add("@status", status);
            cmd.Parameters.Add("@assigto", Assignto);
            cmd.Parameters.Add("@asgnUser", assignUSer);
            cmd.Parameters.Add("@resident", resident);
            cmd.Parameters.Add("@CRating", customerRating);
            cmd.Parameters.Add("@TRating", TRANSACTION_RATING);
            cmd.Parameters.Add("@GRating", GEOPRAPHICAL_RATING);

            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            string ccf_id = "CF-" + db.getDataProcedure(cmd, dt);
            //string ccf_id = "CF-" + db.insertData(cmd,dt);
            HttpContext.Current.Session["CFidx"] = ccf_id.ToString();

        }

        public void insertBank(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_PRO_CFInsertBank";
            cmd.Parameters.Add("@bank", BankName);
            cmd.Parameters.Add("@cfid", CFID);
            db.getDataProcedure(cmd, ds);

        }
        public void insertAdress(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_PRO_CFInsertAddress";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@addres", Address);
            cmd.Parameters.Add("@addresType", AddressTypee);
            cmd.Parameters.Add("@countryCode", country);
            cmd.Parameters.Add("@cityCode", city);
            cmd.Parameters.Add("@Phone", Phone);
            cmd.Parameters.Add("@faxNo", Fax);
            cmd.Parameters.Add("@emailAdress", email);

            db.getDataProcedure(cmd, ds);

        }
        public void insertPhone(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_PRO_CFInsertPhone";
            cmd.Parameters.Add("@phone", ContactNum);
            cmd.Parameters.Add("@cfid", CFID);
            db.getDataProcedure(cmd, ds);

        }
        public void insertBranch(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_PRO_CFInsertBranch";
            cmd.Parameters.Add("@branches", Branch);
            cmd.Parameters.Add("@cfid", CFID);
            db.getDataProcedure(cmd, ds);

        }
        public void insertDepart(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_PRO_CFInsertDeptAndComm";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@dept", Department);
            cmd.Parameters.Add("@buss", Business);
            cmd.Parameters.Add("@insType", InsuranceType);
            cmd.Parameters.Add("@rate", AgentRate);
            cmd.Parameters.Add("@comm", comission);
            cmd.Parameters.Add("@expos", exposure);
            cmd.Parameters.Add("@BusClassCat", BusinessCat);
            db.getDataProcedure(cmd, ds);

        }
        public void insertAgent(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_PRO_CFInsertAgentName";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@agent", Agent);
            db.getDataProcedure(cmd, ds);

        }
        public void insertAttachment(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_PRO_CFInsertAttachment";
            cmd.Parameters.Add("@cfid", HttpContext.Current.Session["CFidx"].ToString());
            cmd.Parameters.Add("@attachPath", attachment);
            cmd.Parameters.Add("@attachType", "Other");
            db.getDataProcedure(cmd, ds);

        }
       

        public void insertComplienceAttachment()
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_PRO_CFInsertAttachment";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@attachPath", attachment);
            cmd.Parameters.Add("@attachType", "Compilence");
            db.runProc(cmd);

        }

        public void insertFilerAttachment()
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_PRO_CFInsertAttachment";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@attachPath", attachment);
            cmd.Parameters.Add("@attachType", "Other");
            db.runProc(cmd);

        }
        public void GetClient(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetClientForm";
            cmd.Parameters.Add("@status_Start", statusStart);
            cmd.Parameters.Add("@status_end", statusend);
            cmd.Parameters.Add("@branch", Branch);
            cmd.Parameters.Add("usertype", role);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetClientDetails(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetClientFormDetail";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, ds);

        }
        public void GetAttachment(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_Get_PRO_CF_Attach";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }


        public void GetClientAddress(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetClientAddress";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetClientContact(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetClientContact";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetClientBranch(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetClientBranch";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetClientBranchWiseRate(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetClientBranchWiseRate";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }

        public void Login(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_LoginUser";
            cmd.Parameters.Add("@login_name", username);
            cmd.Parameters.Add("@login_pass", password);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetApproveUser(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_Get_ApproveUser";
            cmd.Parameters.Add("@branch", Branch);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }

        public void UpdateStatus(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_Upd_status";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@status", status);
            cmd.Parameters.Add("@assignto", Assignto);
            cmd.Parameters.Add("@asgnUser", assignUSer);
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void insertApprovalUser(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.HICL_PRO_InsertApprovedUser";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@username", username);
            cmd.Parameters.Add("@datetime", issueDate);
            cmd.Parameters.Add("@assignto", Assignto);
            db.getDataProcedureDatatable(cmd, dt);

        }


        public void InsertChat(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_PRO_CFInsertComments";
            cmd.Parameters.Add("cfid", OracleDbType.NVarchar2).Value = db.CFID;
            cmd.Parameters.Add("datime", OracleDbType.NVarchar2).Value = db.commDate;
            cmd.Parameters.Add("comt", OracleDbType.NVarchar2).Value = db.comment;
            cmd.Parameters.Add("userid", OracleDbType.NVarchar2).Value = db.userid;
            db.getDataProcedure(cmd, ds);

        }


        public void GetComments(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetComments";
            cmd.Parameters.Add("cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetGroup(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_GetClientGroup";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }

        public void GetContactPerson(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCF_GetContactPerson";
            cmd.Parameters.Add("cfid", CFID);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetAddressType(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAddressType";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetCountry(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCountry";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetCity(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCity";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }


        public void InsertContPerson(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_PRO_CFInsertContactPerson";
            cmd.Parameters.Add("cfid", CFID);
            cmd.Parameters.Add("ContPers", ContactPerson);
            cmd.Parameters.Add("ContPersCnic", ContactPersonCnic);
            cmd.Parameters.Add("ContPersCnicExpiry", ContactPersonCnicExpiry);
            cmd.Parameters.Add("ContPersNtn", ContactPersonNtn);
            cmd.Parameters.Add("ContPersGst", ContactPersonGst);
            cmd.Parameters.Add("ContPersAddress", ContactPersonAddress);
            cmd.Parameters.Add("ContPerNumb", ContactPersonNum);
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetApproved(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetApprove";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, ds);

        }

        public void GetRevert(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRevertUser";
            cmd.Parameters.Add("statusStartRev", statusStartRev);
            cmd.Parameters.Add("statusendRev", statusendRev);
            cmd.Parameters.Add("LocCode", LocCode);
            cmd.Parameters.Add("usertype", role);

            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, ds);

        }

        public void GetForward(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HIL.GetForwardUser";
            cmd.Parameters.Add("status_Start", statusStart);
            cmd.Parameters.Add("status_end", statusend);
            cmd.Parameters.Add("usertype", HttpContext.Current.Session["Role"].ToString());
            cmd.Parameters.Add("locCode", HttpContext.Current.Session["clientbranch"].ToString());

            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, ds);

        }
        public void GetClientCode(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_GetClientCode";
            cmd.Parameters.Add("@user_id", username);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, ds);

        }
        public void GetFinalizeClient(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFinalClient";
            cmd.Parameters.Add("@status", status);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedureDatatable(cmd, dt);

        }
        public void GetRates(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRates";
            cmd.Parameters.Add("@dept", Department);
            cmd.Parameters.Add("@buss", Business);
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, ds);

        }
        public void GetCompanyIndustry(DataTable dt)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCompIndustry";
            cmd.Parameters.Add("prc", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            db.getDataProcedure(cmd, dt);

        }
        public void UpdateCFStatus(DataSet ds)
        {
            db = new dal();
            cmd = new OracleCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HICL_CF_status";
            cmd.Parameters.Add("@cfid", CFID);
            cmd.Parameters.Add("@statusid", status);
            cmd.Parameters.Add("@assgnto", Assignto);
            db.getDataProcedure(cmd, ds);

        }


    }
}