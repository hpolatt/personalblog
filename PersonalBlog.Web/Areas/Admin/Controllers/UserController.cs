using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

    }
}
