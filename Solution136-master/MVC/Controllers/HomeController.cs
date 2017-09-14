namespace MVC.Controllers
{
    using POCO;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Course> courses = null;
            return this.View(courses);
        }
    }
}
