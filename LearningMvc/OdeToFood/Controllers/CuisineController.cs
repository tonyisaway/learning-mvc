namespace OdeToFood.Controllers
{
    using Filters;
    using System.Web.Mvc;

    // [Authorize]
    [Log]
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Index()
        {
            return View();
        }

        // [Authorize]
        public ActionResult Search(string name)
        {
            throw new System.Exception("Something terrible has happend");

            // Protect against XSS
            var message = Server.HtmlEncode(name);

            return Content(message);
        }
    }
}