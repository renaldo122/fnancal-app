using Intertravel.Utility;
using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Test_Scenario.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            Test_ScenarioApplication.InitApplication(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            ModelBinders.Binders[typeof(DateTime)] = new DateTimeEditorExtensions.MyDateTimeModelBinder();
            ModelBinders.Binders[typeof(DateTime?)] = new DateTimeEditorExtensions.MyDateTimeModelBinder();
        }
        protected void Application_BeginRequest()
        {
            CultureInfo newCulture = (CultureInfo)
            System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            newCulture.DateTimeFormat.LongDatePattern = "dd/MM/yyyy HH:mm:ss";
            newCulture.DateTimeFormat.ShortTimePattern = "HH:mm";
            newCulture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            newCulture.DateTimeFormat.TimeSeparator = ":";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }
    }
}
