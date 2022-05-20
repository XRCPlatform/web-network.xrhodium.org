using BitCoinRhNetwork.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using BitCoinRhNetwork.App_Start;
using Forloop.HtmlHelpers;
using System.Web.Mvc.Filters;

namespace BitCoinRhNetwork
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BitCoinRhNetworkServer.Current.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ScriptContext.ScriptPathResolver = Scripts.Render;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["initTime"] = DateTime.UtcNow;    
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.IsLocal.Equals(false))
            {
                if (Request.IsSecureConnection.Equals(false))
                {
                    Response.Redirect("https://network.xrhodium.org" + Request.RawUrl);
                }
            }
        }
    }
}