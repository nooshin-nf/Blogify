using Microsoft.AspNetCore.Mvc;

namespace Blogify.Web.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
