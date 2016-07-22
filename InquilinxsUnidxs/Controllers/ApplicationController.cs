using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InquilinxsUnidxs.Controllers
{
    public class ApplicationController : Controller
    {
        private const string _status = "422 Unprocessable Entity";
        private const int _statusCode = 422;
        private const string _statusDescription = "Entity validation failed. See errors for details.";

        protected void SetUnprocessableEntityResponse()
        {
            this.Response.Status = _status;
            this.Response.StatusCode = _statusCode;
            this.Response.StatusDescription = _statusDescription;
        }
    }
}