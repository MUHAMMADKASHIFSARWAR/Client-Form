using ClientForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace clientForm
{
    public class NactaController : ApiController
    {
        
        public System.Web.Http.Results.JsonResult<string> GetInsertClient(string clientname, string ntn, string cnic, string address, string RefNo)
        {
            dal objdal = new dal();
            objdal.InsertClient(clientname, ntn, cnic, address, RefNo);
            return Json<string>("data saved");

        }

        public System.Web.Http.Results.JsonResult<DataTable> GetNactaClient()
        {

            dal objdal = new dal();
            DataTable dt = objdal.ViewNactaClient();
            return Json<DataTable>(dt);


        }

        public System.Web.Http.Results.JsonResult<string> GetUpdateNactaClient(string refno, string outDate)
        {

            dal objdal = new dal();
             objdal.UpdateClient(outDate, refno);
            return Json<string>("Updated");


        }

        public System.Web.Http.Results.JsonResult<DataTable> GetNactaClearClient()
        {

            dal objdal = new dal();
            DataTable dt = objdal.ViewNactaClearClient();
            return Json<DataTable>(dt);


        }

        public System.Web.Http.Results.JsonResult<DataTable> GetNactaAlreadyClient(string cnic, string ntn, string Refno)
        {

            dal objdal = new dal();
            DataTable dt = objdal.ViewNactaAlreadyClient(cnic,ntn,Refno);
            return Json<DataTable>(dt);


        }

        public System.Web.Http.Results.JsonResult<DataTable> GetGIAClient(string cnic, string ntn)
        {

            dal objdal = new dal();
            DataTable dt = objdal.ViewGIAClient(cnic, ntn);
            return Json<DataTable>(dt);


        }

        public System.Web.Http.Results.JsonResult<DataTable> GetDept()
        {

            dal objdal = new dal();
            DataTable dt = objdal.ViewDept();
            return Json<DataTable>(dt);


        }
        







    }
}