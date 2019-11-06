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
    public class RemarksController : ApiController
    {
       
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
        public System.Web.Http.Results.JsonResult<string> InsertComment(string description)
        {
            dal objdal = new dal();
            //objdal.SaveClaimHoldData(UserInfo.InstanceLoad().UserID, 10, 10, objData.description, objData.doc_ref_no, UserInfo.InstanceLoad().UserID);
            return Json<string>("data saved");

        }
        public System.Web.Http.Results.JsonResult<string> GetDocuments()
        {
            dal objdal = new dal();
            //objdal.SaveClaimHoldData(UserInfo.InstanceLoad().UserID, 10, 10, objData.description, objData.doc_ref_no, UserInfo.InstanceLoad().UserID);
            return Json<string>("data saved");

        }

    }
}