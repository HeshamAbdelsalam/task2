using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using webTask2.Models;

namespace webTask2.Controllers
{
    
 [BasicAuthenticationAttributes]
    public class ValuesController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            using (TaskDataModel db = new TaskDataModel())
            {
                switch (username.ToLower())
                {
                    case "emp":
                        Redirect("http://localhost:55480/Emp/");
                        var response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Headers.Location = new Uri("http://localhost:55480/Emp/");
                        return response;
                    //return Request.CreateResponse(HttpStatusCode.OK,
                    //    db.Users.Where(u => u.UserName.ToLower() == "user"));

                    case "admin":
                        return Request.CreateResponse(HttpStatusCode.OK, db.Users.ToList());

                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }


    }
    }

