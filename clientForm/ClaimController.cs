using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Web;
using ClientForm;

namespace clientForm
{
    public class ClaimController : ApiController
    {


        public System.Web.Http.Results.JsonResult<string> InsertComment(string objData)
        {
            dal objdal = new dal();

            DataTable dt = objdal.InsertRemarks();
            return Json<string>("data saved");

        }


        public System.Web.Http.Results.JsonResult<DataTable> GetRemarks(string doc_ref_no)
        {


            if (!string.IsNullOrEmpty(doc_ref_no))
            {
                dal objDal = new dal();
                DataTable dt = objDal.GetRemarksByRefNo(doc_ref_no);
                return Json<DataTable>(dt);
            }
            return null;


        }

    }
}