using System.Web.Mvc;

namespace Cosmatic_Insurance.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPanel_default",
                "AdminPanel/{controller}/{action}/{id}",
                new { Controller="Admin",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}