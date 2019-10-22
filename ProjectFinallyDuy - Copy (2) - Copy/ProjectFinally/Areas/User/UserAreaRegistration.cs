using System.Web.Mvc;

namespace ProjectFinally.Areas.PhanQuyen
{
    public class PhanQuyenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PhanQuyen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PhanQuyen_default",
                "PhanQuyen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}