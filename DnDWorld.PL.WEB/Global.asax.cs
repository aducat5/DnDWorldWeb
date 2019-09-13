using DnDWorld.BLL.Utility;
using DnDWorld.BLL.CustomExceptions;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DnDWorld.PL.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            int logTypeID = LogTypes.Error.ToInt();
            bool logNeeded = true;
            if (exception != null)
            {
                EventLog errorLog = new EventLog()
                {
                    LogTypeID = logTypeID,
                    CreateDate = DateTime.Now,
                    LogMessage = exception.Message,
                    Detail = exception.InnerException + " - " + exception.StackTrace,
                    MachineName = Server.MachineName
                };
                

                switch (exception.GetType().Name)
                {
                    case "PageNotFoundException":
                        logNeeded = false;
                        Response.Redirect("/Home/NotFound/");
                        break;
                    case "LoginRequiredException":
                        logNeeded = false;
                        Response.Redirect("/Sign/SignIn/");
                        break;
                    case "LogoutRequiredException":
                        logNeeded = false;
                        Response.Redirect("/Home/Index/");
                        break;
                    default:
                        Response.Redirect("/Home/NotFound/");
                        break;
                }

                if(logNeeded) Logger.Log(errorLog); ;
            }
            else
            {
                EventLog errorLog = new EventLog()
                {
                    LogTypeID = logTypeID,
                    CreateDate = DateTime.Now,
                    LogMessage = "Bilinmeyen Hata",
                    MachineName = Server.MachineName,
                    Detail = "Bilinmeyen Hata"
                };
                Response.Redirect("/Home/NotFound/");
            }
        }
    }
}
