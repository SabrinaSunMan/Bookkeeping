using System.Web.Mvc;

namespace Bookkeeping.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Bookkeeping.Areas.Manage.Controllers" }
            );
           // context.MapRoute(
           //    "Manage_default",
           //    "{controller}/{action}/{id}",
           //    new { action = "Index", id = UrlParameter.Optional }
           //);
        }
    }
}