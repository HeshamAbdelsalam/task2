using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using System.Net.Http;
using System.Net;

using System.Text;
using webTask2.Controllers;
using System.Threading;
using System.Security.Principal;

namespace webTask2.Models
{
    public class BasicAuthenticationAttributes:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
           if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
           else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken =Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] userNamePasswordArray = decodedAuthenticationToken.Split(':');
                string userName = userNamePasswordArray[0];
                string password = userNamePasswordArray[1];
                if(UserLogin.login(userName,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName),null);
                    switch (userName.ToString())
                    {
                        case "emp":
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
                            break;
                        case "admin":
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Moved);
                            break;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

                }
            }
        }//end of method
    }
}