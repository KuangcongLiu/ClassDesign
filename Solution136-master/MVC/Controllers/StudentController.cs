namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class StudentController : Controller
    {
        public ActionResult Index(string student_id)
        {
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult Edit(string student_id)
        {
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult InsertCape()
        {
            return this.View();
        }

        public ActionResult EditCape(int cape_id)
        {
            ViewBag.cape_id = cape_id;
            return this.View();
        }

        public ActionResult DeleteCape(int cape_id)
        {
            ViewBag.cape_id = cape_id;
            return this.View();
        }

        public ActionResult CapeList(string student_id)
        {
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult CourseList()
        {
            return this.View();
        }


        public ActionResult EnrollmentList(string student_id)
        {
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult InsertEnrollment()
        {
            return this.View();
        }

        public ActionResult DeleteEnrollment(int schedule_id, string student_id)
        {
            ViewBag.schedule_id = schedule_id;
            ViewBag.student_id = student_id;
            return this.View();
        }

        public ActionResult ScheduleList(string student_id)
        {
            ViewBag.student_id = student_id;
            return this.View();
        }

 
        [HttpPost]
        public ActionResult Add(string studentId, string first, string last, string gender)
        {
            //// TODO: store to database... then redirect to the add page again, this is for demo only
            Response.Redirect("/Student/Add");
            return null;
        }


    }
}
