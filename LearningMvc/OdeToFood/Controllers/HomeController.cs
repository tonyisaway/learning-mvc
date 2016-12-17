
namespace OdeToFood.Controllers
{
    using Models;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = string.Format("{0}::{1} {2}", controller, action, id);

            ViewBag.Message = message; //"Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            var model = new AboutModel
            {
                Name = "Scott",
                Location = "Maryland, USA"
            };

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
