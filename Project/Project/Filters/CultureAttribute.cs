using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Project.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = null;
            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            cultureName = cultureCookie != null ? cultureCookie.Value : "ru";

            var cultures = new List<string>() { "ru", "en", "be" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "ru";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}